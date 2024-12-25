using FastColoredTextBoxNS;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MCA_ServerConsole.Dialogs
{
    public partial class FRM_CodeEditor : Form
    {
        private readonly string _filePath;
        private FastColoredTextBox FCT_CodeEditor;

        // Define styles once and reuse them
        private readonly TextStyle CommentStyle = new TextStyle(new SolidBrush(Color.FromArgb(39, 174, 96)), null, FontStyle.Italic);
        private readonly TextStyle KeyStyle = new TextStyle(new SolidBrush(Color.FromArgb(41, 128, 185)), null, FontStyle.Bold);
        private readonly TextStyle ValueStyle = new TextStyle(new SolidBrush(Color.FromArgb(231, 76, 60)), null, FontStyle.Regular);
        private readonly TextStyle EscapeStyle = new TextStyle(new SolidBrush(Color.FromArgb(22, 160, 133)), null, FontStyle.Bold);
        private readonly TextStyle TimeStyle = new TextStyle(new SolidBrush(Color.FromArgb(41, 128, 185)), null, FontStyle.Bold);
        private readonly TextStyle LogLevelStyle = new TextStyle(new SolidBrush(Color.FromArgb(231, 76, 60)), null, FontStyle.Bold);
        private readonly TextStyle ThreadStyle = new TextStyle(new SolidBrush(Color.FromArgb(39, 174, 96)), null, FontStyle.Italic);

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
                        this.Text += $" ({fileExtension} File)";
                        break;

                    case ".properties":
                        FCT_CodeEditor.TextChanged += ApplySyntaxHighlighting;
                        this.Text += $" ({fileExtension} File)";
                        break;

                    case ".txt":
                        this.Text += $" ({fileExtension} File)";
                        break;
                    
                    case ".log":
                        FCT_CodeEditor.TextChanged += ApplySyntaxHighlighting;
                        this.Text += $" ({fileExtension} File)";
                        break;

                    default:
                        MessageBox.Show("No syntax highlighting available for this file type.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                FCT_CodeEditor.Text = ReadFileContent(_filePath);

                // Add the editor to the panel
                PNL_Fill.Controls.Add(FCT_CodeEditor);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error initializing code editor: {ex.Message}",
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
                MessageBox.Show($"Error applying syntax highlighting: {ex.Message}",
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

        private static string ReadFileContent(string filePath)
        {
            try
            {
                if(!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file '{filePath}' does not exist.");
                }

                return File.ReadAllText(filePath).Trim();
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access to the file is denied: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}",
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
                MessageBox.Show($"Access to write the file is denied: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error writing to file: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                WriteFileContent(_filePath, FCT_CodeEditor.Text);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error during save operation: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}