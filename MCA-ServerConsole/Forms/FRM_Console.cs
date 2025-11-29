using MCA_ServerConsole.Classes;
using MCA_ServerConsole.Dialogs;
using MCA_ServerConsole.HelperClasses;
using MCA_ServerConsole.Properties;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace MCA_ServerConsole.Forms
{
    public partial class FRM_Console : Form
    {
        private readonly JavaProcessHandler _javaProcessHandler;
        private readonly FileSystemManager _fileSystemManager;
        private readonly UIHandler _uiHandler;

        [DllImport("user32.dll")]
        [SupportedOSPlatform("windows")]
        private static extern bool HideCaret(IntPtr hWnd);

        public FRM_Console()
        {
            InitializeComponent();

            // Initialize Handler
            _uiHandler = new UIHandler(TSL_ServerStatus, TSL_GameVersion, TSL_PortStatus, TSL_DefaultGamemode, CPG_Start, BTN_StartServer, BTN_ReloadServer, BTN_StopServer, BTN_AddJavaFile, CBX_JarFile, NUD_ServerRam, TBX_CommandText, BTN_SendCommand, BTN_SaveOutput, RTB_ServerLog, CMS_RTB_ServerLog, TSW_ShowJavaConsole, _javaProcessHandler);
            _javaProcessHandler = new JavaProcessHandler(HandleKeyword);
            _fileSystemManager = new FileSystemManager(UpdateDirectoryStructure);

            // Setup Initial Content
            InitializeFormContent();
            SetupFileSystemWatcher(Properties.Settings.Default.ServerDirectory);

            // Hide caret in RichTextBox
            RTB_ServerLog.GotFocus += (s, e) => HideCaret(RTB_ServerLog.Handle);
            RTB_ServerLog.MouseDown += (s, e) => HideCaret(RTB_ServerLog.Handle);
            RTB_ServerLog.TextChanged += (s, e) => HideCaret(RTB_ServerLog.Handle);
        }

        private void InitializeFormContent()
        {
            try
            {
                PBX_ServerImage.Image = ImageHelper.ConvertStringToImage(Properties.Settings.Default.ServerImage);
                LBL_ServerName.Text = Properties.Settings.Default.ServerName;
                NUD_ServerRam.Maximum = SystemHelper.GetAvailableRAM();
                TSL_ServerStatus.Text = "Server stopped";
                TSL_ServerStatus.Image = Properties.Resources.stopped;
                TSL_AppVersion.Text = $"v.{Assembly.GetExecutingAssembly().GetName().Version}";

                LoadDirectoryStructure();
                LoadJarFiles(Properties.Settings.Default.ServerDirectory);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Initialization error: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDirectoryStructure()
        {
            try
            {
                if(InvokeRequired)
                {
                    Invoke(new Action(LoadDirectoryStructure));
                    return;
                }

                _fileSystemManager.LoadFolderStructure(Properties.Settings.Default.ServerDirectory, TRV_Directory);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading directory structure: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDirectoryStructure()
        {
            try
            {
                if(InvokeRequired)
                {
                    Invoke(new Action(UpdateDirectoryStructure));
                    return;
                }

                _fileSystemManager.UpdateFolderStructure(Properties.Settings.Default.ServerDirectory, TRV_Directory);
                UpdateJarFiles(Properties.Settings.Default.ServerDirectory);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading directory structure: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateJarFiles(string rootPath)
        {
            try
            {
                string? selectedItem = CBX_JarFile.SelectedItem?.ToString();

                string[] jarFiles = JavaHelper.GetJarFiles(rootPath);

                List<string> currentItems = CBX_JarFile.Items.Cast<string>().ToList();

                List<string> newFiles = jarFiles.Except(currentItems).ToList();

                List<string> removedFiles = currentItems.Except(jarFiles).ToList();

                foreach(string? removedFile in removedFiles)
                {
                    CBX_JarFile.Items.Remove(removedFile);
                }

                foreach(string? newFile in newFiles)
                {
                    _ = CBX_JarFile.Items.Add(newFile);
                }

                // Re-select item if it still exists
                if(selectedItem != null && jarFiles.Contains(selectedItem))
                {
                    CBX_JarFile.SelectedItem = selectedItem;
                }
                else if(CBX_JarFile.Items.Count > 0)
                {
                    CBX_JarFile.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error updating .jar files: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJarFiles(string rootPath)
        {
            try
            {
                string[] jarFiles = JavaHelper.GetJarFiles(rootPath);
                CBX_JarFile.Items.Clear();

                if(jarFiles.Length > 0)
                {
                    foreach(string jarFile in jarFiles)
                    {
                        _ = CBX_JarFile.Items.Add(jarFile);
                    }
                    CBX_JarFile.SelectedIndex = 0;
                }
                else
                {
                    _ = MessageBox.Show("No .jar files found in the server directory.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading .jar files: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupFileSystemWatcher(string path)
        {
            try
            {
                _fileSystemManager.SetupWatcher(path);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error initializing file watcher: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BTN_StartServer_Click(object sender, EventArgs e)
        {
            try
            {
                if(CBX_JarFile.SelectedItem == null)
                {
                    _ = MessageBox.Show("Please select a .jar file to start the server.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string javaGui = TSW_ShowJavaConsole.Checked ? "" : "nogui";

                _javaProcessHandler.KillJavaProcess();
                RTB_ServerLog.Clear();

                await _javaProcessHandler.StartJavaProcessAsync(
                    $"-Xmx{NUD_ServerRam.Value}G -jar {CBX_JarFile.SelectedItem} {javaGui}",
                    AppendLog,
                    error => AppendLog($"[ERROR] {error}")
                );
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error starting server: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_StopServer_Click(object sender, EventArgs e)
        {
            try
            {
                _javaProcessHandler?.StopJavaProcess();
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error stopping server: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_ReloadServer_Click(object sender, EventArgs e)
        {
            try
            {
                _javaProcessHandler?.ReloadJavaProcess();
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error reloading server: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppendLog(string text)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(() => AppendLog(text)));
            }
            else
            {
                RTB_ServerLog.AppendText(text + Environment.NewLine);
            }
        }

        private void HandleKeyword(string keyword, string output)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(() => HandleKeyword(keyword, output)));
                return;
            }

            switch(keyword.ToLower())
            {
                case "agree to the eula":
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                case "sun.nio.ch.filedispatcherimpl.write0": // (indicates that a server instance is already running)
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                case "starting":
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                case "server version":
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                case "server on":
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                case "game type":
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                case "done":
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                case "stopping server":
                    _uiHandler.UpdateUI(keyword, output);
                    break;

                default:
                    AppendLog($"[INFO] {output}");
                    break;
            }
        }

        private void TRV_Directory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Set the selected node for right-click or left-click
            if(e.Button is MouseButtons.Right or MouseButtons.Left)
            {
                TRV_Directory.SelectedNode = e.Node;
            }
        }

        private void TRV_Directory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string? path = e.Node.Tag?.ToString();

                if(string.IsNullOrEmpty(path))
                {
                    _ = MessageBox.Show("Invalid path.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(File.Exists(path))
                {
                    string? parentDirectory = Path.GetDirectoryName(path);
                    if(!string.IsNullOrEmpty(parentDirectory))
                    {
                        _ = System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{path}\"");
                    }
                    else
                    {
                        _ = MessageBox.Show("Unable to locate the parent directory.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error opening file: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(_javaProcessHandler != null && !_javaProcessHandler.IsProcessExited)
                {
                    _ = MessageBox.Show("The server is still running! Please stop the server before exiting.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error during form closing: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void RTB_ServerLog_TextChanged(object sender, EventArgs e)
        {
            RTB_ServerLog.SelectionStart = RTB_ServerLog.TextLength;
            RTB_ServerLog.ScrollToCaret();
        }

        private void BTN_SendCommand_Click(object sender, EventArgs e)
        {
            TBX_CommandText.Text = TBX_CommandText.Text.Replace("/", ""); // Remove slashes
            _ = TBX_CommandText.Text.Trim();
            if(TBX_CommandText.Text.Length == 0)
            {
                return;
            }

            AppendLog($"> {TBX_CommandText.Text.Trim()}");
            _javaProcessHandler.SendToJavaProcess(TBX_CommandText.Text.Trim());
            TBX_CommandText.Clear();
        }

        private void TBX_CommandText_KeyDown(object sender, KeyEventArgs e)
        {
            _ = TBX_CommandText.Text.Trim();

            if(TBX_CommandText.Text.Length == 0)
            {
                return;
            }

            if(e.KeyCode == Keys.Enter)
            {
                BTN_SendCommand.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void TMI_EditFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected node
                TreeNode? selectedNode = TRV_Directory.SelectedNode;
                if(selectedNode == null || selectedNode.Tag == null)
                {
                    _ = MessageBox.Show("Please select a file to view or edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? path = selectedNode.Tag.ToString();
                if(File.Exists(path))
                {
                    if(path.Contains(".png"))
                    {
                        _ = Process.Start(new ProcessStartInfo()
                        {
                            FileName = path,
                            UseShellExecute = true,
                        });

                        return;
                    }
                    else if(!(path.EndsWith(".json") || path.EndsWith(".png") || path.EndsWith(".properties") || path.EndsWith(".log") || path.EndsWith(".txt")))
                    {
                        _ = MessageBox.Show("This file can't be opened within this application.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    // Open file in default editor
                    FRM_CodeEditor codeEditorForm = new(path);
                    _ = codeEditorForm.ShowDialog();
                }
                else if(Directory.Exists(path))
                {
                    _ = Process.Start("explorer.exe", path);
                }
                else
                {
                    _ = MessageBox.Show("The selected file does not exist.", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception) { }
        }

        private void TMI_DeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected node
                TreeNode? selectedNode = TRV_Directory.SelectedNode;
                if(selectedNode == null || selectedNode.Tag == null)
                {
                    _ = MessageBox.Show("Please select a file or folder to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? path = selectedNode.Tag.ToString();
                if(MessageBox.Show($"Delete {StringHelper.CutTillLastPart(path, "\\")}?", "MCA Console", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                if(File.Exists(path))
                {
                    // Delete file
                    File.Delete(path);
                    _ = MessageBox.Show("File deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(Directory.Exists(path))
                {
                    // Delete folder
                    Directory.Delete(path, true);
                    _ = MessageBox.Show("Folder deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _ = MessageBox.Show("The selected item does not exist.", "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error deleting file or folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_SaveOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog sFD = new()
            {
                Filter = "Text file (*.txt) | *.txt",
                Title = "Save console output",
                FileName = $"MCAC_Output_{DateTime.Now:yyyy-MM-dd}_{DateTime.Now:HH-mm}"
            };

            if(sFD.ShowDialog() == DialogResult.OK)
            {
                WriteFileContent(sFD.FileName, RTB_ServerLog.Text);
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

        private void TMI_SaveOutput_Click(object sender, EventArgs e)
        {
            BTN_SaveOutput.PerformClick();
        }

        private void BTN_AddJavaFile_Click(object sender, EventArgs e)
        {
            FRM_DownloadServerJarFile downloadJarFileForm = new(Properties.Settings.Default.ServerDirectory);
            _ = downloadJarFileForm.ShowDialog(this);
        }
    }
}

/// ToDo:
/// Context menu stips to open up player and settings manager etc.