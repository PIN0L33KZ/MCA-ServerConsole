using MCA_ServerConsole.Classes;
using MCA_ServerConsole.HelperClasses;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace MCA_ServerConsole.Forms
{
    public partial class FRM_Console : Form
    {
        private FileSystemWatcher _fileSystemWatcher = new();
        private JavaProcessHandler _javaProcessHandler = new();

        [DllImport("user32.dll")]
        [SupportedOSPlatform("windows")]
        private static extern bool HideCaret(IntPtr hWnd);

        public FRM_Console()
        {
            InitializeComponent();
            InitializeFormContent();


            RTB_ServerLog.GotFocus += (s, e) => HideCaret(RTB_ServerLog.Handle);
            RTB_ServerLog.MouseDown += (s, e) => HideCaret(RTB_ServerLog.Handle);
            RTB_ServerLog.TextChanged += (s, e) => HideCaret(RTB_ServerLog.Handle);
        }

        private void InitializeFormContent()
        {
            try
            {
                // Load server image and name
                PBX_ServerImage.Image = ImageHelper.ConvertStringToImage(Properties.Settings.Default.ServerImage);
                LBL_ServerName.Text = LBL_ServerName.Text.Replace(@"{name}", Properties.Settings.Default.ServerName);

                // Initialize file watcher and load treeview content
                SetupFileSystemWatcher(Properties.Settings.Default.ServerDirectory);
                LoadFolderAndFileStructureWithIcons(Properties.Settings.Default.ServerDirectory, TRV_Directory);
                LoadJarFiles(Properties.Settings.Default.ServerDirectory, CBX_JarFile);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Initialization error: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRM_Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(_javaProcessHandler != null && !_javaProcessHandler.IsProcessExited)
                {
                    _ = MessageBox.Show("The server is still running! Please stop the server before exiting.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error during closing: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void TRV_Directory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                // Abrufen des Pfads aus der Tag-Eigenschaft des Knotens
                string? path = e.Node.Tag?.ToString();

                if(string.IsNullOrEmpty(path))
                {
                    _ = MessageBox.Show("Invalid path.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(File.Exists(path))
                {
                    // Öffnet das übergeordnete Verzeichnis und hebt die Datei hervor
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
                _ = MessageBox.Show($"An error occurred: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LoadJarFiles(string rootPath, ComboBox comboBox)
        {
            try
            {
                string[] jarFiles = JavaHelper.GetJarFiles(rootPath);
                comboBox.Items.Clear();

                if(jarFiles.Length > 0)
                {
                    foreach(string jarFile in jarFiles)
                    {
                        _ = comboBox.Items.Add(jarFile);
                    }
                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    _ = MessageBox.Show("No .jar files found in the server directory.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading .jar files: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LoadFolderAndFileStructureWithIcons(string rootPath, TreeView treeView)
        {
            try
            {
                treeView.Nodes.Clear();

                TreeNode rootNode = new(Path.GetFileName(rootPath))
                {
                    Tag = rootPath,
                    ImageKey = "folder",
                    SelectedImageKey = "folder"
                };
                _ = treeView.Nodes.Add(rootNode);

                LoadSubDirectoriesAndFilesWithIcons(rootPath, rootNode);

                // Expand first and second levels
                foreach(TreeNode node in treeView.Nodes)
                {
                    node.Expand();
                    foreach(TreeNode childNode in node.Nodes)
                    {
                        childNode.Expand();
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading folder structure: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LoadSubDirectoriesAndFilesWithIcons(string directoryPath, TreeNode parentNode)
        {
            try
            {
                foreach(string subdirectory in Directory.GetDirectories(directoryPath))
                {
                    TreeNode subNode = new(Path.GetFileName(subdirectory))
                    {
                        Tag = subdirectory,
                        ImageKey = "folder",
                        SelectedImageKey = "folder"
                    };
                    _ = parentNode.Nodes.Add(subNode);

                    LoadSubDirectoriesAndFilesWithIcons(subdirectory, subNode);
                }

                foreach(string file in Directory.GetFiles(directoryPath))
                {
                    TreeNode fileNode = new(Path.GetFileName(file))
                    {
                        Tag = file,
                        ImageKey = "file",
                        SelectedImageKey = "file"
                    };
                    _ = parentNode.Nodes.Add(fileNode);
                }
            }
            catch(UnauthorizedAccessException)
            {
                _ = parentNode.Nodes.Add(new TreeNode("Access Denied")
                {
                    ImageKey = "file",
                    SelectedImageKey = "file"
                });
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading files or directories: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task StartJavaServerAsync()
        {
            try
            {
                if(CBX_JarFile.SelectedItem == null)
                {
                    _ = MessageBox.Show("Please select a .jar file to start the server.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _javaProcessHandler = new JavaProcessHandler();

                await _javaProcessHandler.StartJavaProcessAsync($"-jar {CBX_JarFile.SelectedItem} nogui", AppendLog, error => AppendLog($"[ERROR] {error}"));
            }
            catch(Exception ex)
            {
                AppendLog($"[ERROR] An unexpected error occurred: {ex.Message}");
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

        private async void BTN_StartServer_Click(object sender, EventArgs e)
        {
            RTB_ServerLog.Clear();

            await StartJavaServerAsync();
        }

        private void BTN_StopServer_Click(object sender, EventArgs e)
        {
            try
            {
                _javaProcessHandler?.StopJavaProcess();
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error stopping server: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupFileSystemWatcher(string path)
        {
            try
            {
                _fileSystemWatcher = new FileSystemWatcher
                {
                    Path = path,
                    IncludeSubdirectories = true,
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite
                };

                _fileSystemWatcher.Created += OnFileSystemChanged;
                _fileSystemWatcher.Deleted += OnFileSystemChanged;
                _fileSystemWatcher.Renamed += OnFileSystemChanged;
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error initializing file watcher: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFileSystemChanged(object sender, FileSystemEventArgs e)
        {
            Invoke(new Action(() =>
            {
                LoadFolderAndFileStructureWithIcons(Properties.Settings.Default.ServerDirectory, TRV_Directory);
                LoadJarFiles(Properties.Settings.Default.ServerDirectory, CBX_JarFile);
            }));
        }

        private void RTB_ServerLog_TextChanged(object sender, EventArgs e)
        {
            RTB_ServerLog.SelectionStart = RTB_ServerLog.TextLength;
            RTB_ServerLog.ScrollToCaret();
        }

    }
}

/// ToDo:
/// Activate/Deactivate Buttons based on Console output
/// Add Save Log button
/// Add Input box to send commands
/// Readout basic stats IP/Interface/Port/Uptime/Minecraft Version/Default Gamemode etc.
/// EULA editor to accept EULA right away
/// RAM & CPU usage graphs
/// Context menu stips to open up player and settings manager etc.