using MCA_ServerConsole.Classes;
using MCA_ServerConsole.HelperClasses;
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
            _uiHandler = new UIHandler(TSL_ServerStatus, TSL_GameVersion, TSL_PortStatus, TSL_DefaultGamemode, BTN_StartServer, BTN_ReloadServer, BTN_StopServer, CBX_JarFile, TBX_CommandText, BTN_SendCommand);
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
                LBL_ServerName.Text = LBL_ServerName.Text.Replace(@"{name}", Properties.Settings.Default.ServerName);

                LoadDirectoryStructure();
                LoadJarFiles(Properties.Settings.Default.ServerDirectory);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Initialization error: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _ = MessageBox.Show($"Error loading directory structure: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _ = MessageBox.Show($"Error loading directory structure: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _ = MessageBox.Show($"Error updating .jar files: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _ = MessageBox.Show("No .jar files found in the server directory.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading .jar files: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _ = MessageBox.Show($"Error initializing file watcher: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BTN_StartServer_Click(object sender, EventArgs e)
        {
            try
            {
                if(CBX_JarFile.SelectedItem == null)
                {
                    _ = MessageBox.Show("Please select a .jar file to start the server.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RTB_ServerLog.Clear();

                await _javaProcessHandler.StartJavaProcessAsync(
                    $"-jar {CBX_JarFile.SelectedItem} nogui",
                    AppendLog,
                    error => AppendLog($"[ERROR] {error}")
                );
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error starting server: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _ = MessageBox.Show($"Error stopping server: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _ = MessageBox.Show($"Error reloading server: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TRV_Directory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string? path = e.Node.Tag?.ToString();

                if(string.IsNullOrEmpty(path))
                {
                    _ = MessageBox.Show("Invalid path.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        _ = MessageBox.Show("Unable to locate the parent directory.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error opening file: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(_javaProcessHandler != null && !_javaProcessHandler.IsProcessExited)
                {
                    _ = MessageBox.Show("The server is still running! Please stop the server before exiting.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error during form closing: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            AppendLog($"> {TBX_CommandText.Text.Trim()}");
            _javaProcessHandler.SendToJavaProcess(TBX_CommandText.Text.Trim());
            TBX_CommandText.Clear();
        }

        private void TBX_CommandText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BTN_SendCommand.PerformClick();
            }
        }
    }
}

/// ToDo:
/// Add Save Log button
/// EULA editor to accept EULA right away
/// RAM & CPU usage graphs
/// Context menu stips to open up player and settings manager etc.