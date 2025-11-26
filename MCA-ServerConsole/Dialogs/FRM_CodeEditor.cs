using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace MCA_ServerConsole.Dialogs
{
    public partial class FRM_CodeEditor : Form
    {
        private readonly string _filePath;
        private FastColoredTextBox FCT_CodeEditor;

        // Define styles once and reuse them
        private readonly TextStyle CommentStyle = new(new SolidBrush(Color.FromArgb(16, 172, 132)), null, FontStyle.Italic);
        private readonly TextStyle KeyStyle = new(new SolidBrush(Color.FromArgb(95, 39, 205)), null, FontStyle.Bold);
        private readonly TextStyle ValueStyle = new(new SolidBrush(Color.FromArgb(238, 82, 83)), null, FontStyle.Regular);
        private readonly TextStyle EscapeStyle = new(new SolidBrush(Color.FromArgb(46, 134, 222)), null, FontStyle.Bold);
        private readonly TextStyle TimeStyle = new(new SolidBrush(Color.FromArgb(46, 134, 222)), null, FontStyle.Bold);
        private readonly TextStyle LogLevelStyle = new(new SolidBrush(Color.FromArgb(255, 159, 67)), null, FontStyle.Bold);
        private readonly TextStyle ThreadStyle = new(new SolidBrush(Color.FromArgb(16, 172, 132)), null, FontStyle.Italic);

        public FRM_CodeEditor(string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
            }

            _filePath = filePath;
            InitializeComponent();
            InitializeCodeEditor();
        }

        private void InitializeCodeEditor()
        {
            try
            {
                // Setup FastColoredTextBox
                FCT_CodeEditor = new FastColoredTextBox
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Consolas", 10),
                    Language = Language.Custom,
                    AutoIndent = true,
                    ShowLineNumbers = true,
                    WordWrap = false,
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                // Remove existing TextChanged events to prevent multiple bindings
                FCT_CodeEditor.TextChanged -= ApplySyntaxHighlighting;

                // Determine syntax highlighting based on file type
                string fileExtension = Path.GetExtension(_filePath)?.ToLower() ?? string.Empty;

                switch(fileExtension)
                {
                    case ".json":
                        FCT_CodeEditor.TextChanged += ApplySyntaxHighlighting;
                        Text += $" ({fileExtension} File)";
                        break;

                    case ".properties":
                        FCT_CodeEditor.TextChanged += ApplySyntaxHighlighting;
                        Text += $" ({fileExtension} File)";
                        break;

                    case ".txt":
                        Text += $" ({fileExtension} File)";
                        break;

                    case ".log":
                        FCT_CodeEditor.TextChanged += ApplySyntaxHighlighting;
                        Text += $" ({fileExtension} File)";
                        break;

                    default:
                        _ = MessageBox.Show("No syntax highlighting available for this file type.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                FCT_CodeEditor.Text = ReadFileContent(_filePath);
                FCT_CodeEditor.IsChanged = false;

                // Add the editor to the panel
                PNL_Fill.Controls.Add(FCT_CodeEditor);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error initializing code editor: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close(); // Close the form if initialization fails
            }
        }

        private void ApplySyntaxHighlighting(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Determine file extension
                string fileExtension = Path.GetExtension(_filePath)?.ToLower() ?? string.Empty;

                if(fileExtension == ".json")
                {
                    ApplyJsonSyntaxHighlighting(e);
                }
                else if(fileExtension == ".properties")
                {
                    ApplyPropertiesSyntaxHighlighting(e);
                }
                else if(fileExtension == ".log")
                {
                    ApplyLogFileSyntaxHighlighting(e);
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error applying syntax highlighting: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyJsonSyntaxHighlighting(TextChangedEventArgs e)
        {
            // Define patterns for JSON highlighting
            string[] patterns =
            [
                @"\/\/.*?$|\/\*.*?\*\/",                   // Comments (// or /* */)
                @"""[\w\s]+""(?=\s*:)",                   // Keys
                @"""(\\.|[^""\\])*""(?=\s*[,}\]])",       // String values
                @"\\[bfnrt\\/""']|\b(true|false|null)\b"  // Escape sequences and booleans/null
            ];

            // Apply styles to the changed range only
            e.ChangedRange.ClearStyle(CommentStyle, KeyStyle, ValueStyle, EscapeStyle);
            ApplyStylesToPatterns(e, patterns, [CommentStyle, KeyStyle, ValueStyle, EscapeStyle]);
        }

        private void ApplyPropertiesSyntaxHighlighting(TextChangedEventArgs e)
        {
            // Define patterns for .properties highlighting
            string[] patterns =
            [
                @"^[\s]*[#|!].*$",            // Comments (# or !)
                @"^[^=:\s]+(?=[\s]*[=:])",    // Keys before `=` or `:`
                @"(?<=[=:]).*$",              // Values after `=` or `:`
                @"\\[nrt\\]"                 // Escape sequences
            ];

            // Apply styles to the changed range only
            e.ChangedRange.ClearStyle(CommentStyle, KeyStyle, ValueStyle, EscapeStyle);
            ApplyStylesToPatterns(e, patterns, [CommentStyle, KeyStyle, ValueStyle, EscapeStyle]);
        }

        private void ApplyLogFileSyntaxHighlighting(TextChangedEventArgs e)
        {
            // Patterns for log file syntax
            string[] patterns =
            [
                @"\[\d{2}:\d{2}:\d{2}\]",                // Time format [HH:mm:ss]
                @"\b(INFO|WARN|ERROR|DEBUG|TRACE)\b",    // Log levels
                @"\[.*?\]"                              // Threads (e.g., [Server thread/INFO])
            ];

            // Clear and reapply styles
            e.ChangedRange.ClearStyle(TimeStyle, LogLevelStyle, ThreadStyle);
            ApplyStylesToPatterns(e, patterns, [TimeStyle, LogLevelStyle, ThreadStyle]);
        }

        private static void ApplyStylesToPatterns(TextChangedEventArgs e, string[] patterns, TextStyle[] styles)
        {
            for(int i = 0; i < patterns.Length; i++)
            {
                if(i < styles.Length)
                {
                    e.ChangedRange.SetStyle(styles[i], patterns[i], RegexOptions.Multiline);
                }
            }
        }

        private string ReadFileContent(string filePath)
        {
            try
            {
                return !File.Exists(filePath)
                    ? throw new FileNotFoundException($"The file '{filePath}' does not exist.")
                    : File.ReadAllText(filePath).Trim();
            }
            catch(UnauthorizedAccessException ex)
            {
                _ = MessageBox.Show($"Access to the file is denied: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch(IOException ex) when((ex.HResult & 0xFFFF) == 32)
            {
                _ = MessageBox.Show($"This file is currently being used by your Server. Stop the server to edit this file.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return string.Empty;
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error reading file: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private static void WriteFileContent(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content.Trim());
            }
            catch(UnauthorizedAccessException ex)
            {
                _ = MessageBox.Show($"Access to write the file is denied: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error writing to file: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                if(FCT_CodeEditor.IsChanged)
                {
                    WriteFileContent(_filePath, FCT_CodeEditor.Text);
                }

                FCT_CodeEditor.IsChanged = false;
                Close();
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error during save operation: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_CodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Check if the text has changed
                if(FCT_CodeEditor.IsChanged)
                {
                    // Prompt the user to save changes
                    DialogResult result = MessageBox.Show(
                        "You have unsaved changes. Do you want to save before closing?",
                        "Unsaved Changes",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning
                    );

                    switch(result)
                    {
                        case DialogResult.Yes:
                            WriteFileContent(_filePath, FCT_CodeEditor.Text);
                            break;

                        case DialogResult.No:
                            // Allow the form to close without saving
                            break;

                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error during closing: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Prevent the form from closing on error
            }
        }
    }
}