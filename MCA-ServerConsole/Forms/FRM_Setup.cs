using MCA_ServerConsole.HelperClasses;
using MCA_ServerConsole.Properties;

namespace MCA_ServerConsole
{
    public partial class FRM_Setup : Form
    {

        public FRM_Setup()
        {
            InitializeComponent();
        }

        private void FRM_Setup_Load(object sender, EventArgs e)
        {
            try
            {
                // Load and validate server name
                if(!string.IsNullOrWhiteSpace(Settings.Default.ServerName))
                {
                    TBX_ServerName.Text = Settings.Default.ServerName;
                }

                // Load and validate server address
                if(!string.IsNullOrWhiteSpace(Settings.Default.ServerAddress) && StringHelper.IsValidIPv4(Settings.Default.ServerAddress))
                {
                    TBX_ServerAddress.Text = Settings.Default.ServerAddress;
                }
            }
            catch(Exception ex)
            {
                // General error handling for unexpected issues
                _ = MessageBox.Show(this, "An error occurred while loading settings: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Load existing setup for ServerDirectory
                if(!string.IsNullOrWhiteSpace(Settings.Default.ServerDirectory))
                {
                    if(Directory.Exists(Settings.Default.ServerDirectory))
                    {
                        TBX_ServerDirectory.Text = Settings.Default.ServerDirectory;
                    }
                    else
                    {
                        _ = MessageBox.Show(this, "The saved server directory does not exist. Please configure a new directory.",
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Load existing setup for ServerImage
                if(!string.IsNullOrWhiteSpace(Settings.Default.ServerImage))
                {
                    try
                    {
                        Image serverImage = ImageHelper.ConvertStringToImage(Settings.Default.ServerImage);
                        if(serverImage != null)
                        {
                            PBX_ServerImage.Image = serverImage;
                        }
                    }
                    catch(Exception ex)
                    {
                        _ = MessageBox.Show(this, "An error occurred while loading the server image: " + ex.Message,
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                // General catch for unexpected errors during form load
                _ = MessageBox.Show(this, "An unexpected error occurred while loading the setup: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_SelectServerDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                // Folder browser dialog configuration
                FolderBrowserDialog fBD = new()
                {
                    Description = "Select where to store your server's files.",
                    ShowHiddenFiles = false,
                    ShowNewFolderButton = true,
                    SelectedPath = Settings.Default.ServerDirectory.Length > 0
                        ? Settings.Default.ServerDirectory + '\\'
                        : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + '\\'
                };

                // User cancels the dialog
                if(fBD.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Validate the selected path
                if(string.IsNullOrWhiteSpace(fBD.SelectedPath) || !Directory.Exists(fBD.SelectedPath))
                {
                    _ = MessageBox.Show(this, "Invalid directory selected. Please try again.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //// Update the textbox with the selected directory
                TBX_ServerDirectory.Text = fBD.SelectedPath;
                TBX_ServerDirectory.SelectionStart = TBX_ServerDirectory.TextLength;
                TBX_ServerDirectory.ScrollToCaret();
            }
            catch(Exception ex)
            {
                // Catch unexpected errors and display them
                _ = MessageBox.Show(this, "An unexpected error occurred: " + ex.Message, "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTX_SelectServerImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Open file dialog configuration
                OpenFileDialog oFD = new()
                {
                    CheckFileExists = true,
                    Filter = "Images (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg",
                    ShowHiddenFiles = false,
                    Title = "Select a server image",
                    InitialDirectory = Settings.Default.ServerDirectory.Length > 0
                        ? Settings.Default.ServerDirectory + '\\'
                        : Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + '\\'
                };

                // User cancels the dialog
                if(oFD.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // User selected an invalid file
                if(string.IsNullOrWhiteSpace(oFD.FileName))
                {
                    _ = MessageBox.Show("No file selected", "Minecraft Advanced Server Console");
                    return;
                }

                // Load image
                PBX_ServerImage.Image = Image.FromFile(oFD.FileName);
            }
            catch(Exception ex)
            {
                // Catch any error and display
                _ = MessageBox.Show("Error: " + ex.Message, "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_SaveSetup_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset all previous error messages
                ERP_Main.Clear();

                // Check for missing inputs
                int errorCount = 0;

                // Validate server name
                if(string.IsNullOrWhiteSpace(TBX_ServerName.Text))
                {
                    ERP_Main.SetError(TBX_ServerName, "Please enter a server name");
                    errorCount++;
                }

                // Validate server address
                if(string.IsNullOrWhiteSpace(TBX_ServerAddress.Text) || !StringHelper.IsValidIPv4(TBX_ServerAddress.Text))
                {
                    ERP_Main.SetError(TBX_ServerAddress, "Please enter a valid IPv4 address");
                    errorCount++;
                }

                // Validate server directory
                if(string.IsNullOrWhiteSpace(TBX_ServerDirectory.Text) || !Directory.Exists(TBX_ServerDirectory.Text))
                {
                    ERP_Main.SetError(BTN_SelectServerDirectory, "Please select a valid directory");
                    errorCount++;
                }

                // Check if errors exist
                if(errorCount > 0)
                {
                    _ = MessageBox.Show(this, "Please correct the highlighted errors before saving.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save settings
                Settings.Default.ServerName = TBX_ServerName.Text.Trim();
                Settings.Default.ServerAddress = TBX_ServerAddress.Text.Trim();
                Settings.Default.ServerDirectory = TBX_ServerDirectory.Text.Trim();
                Settings.Default.ServerImage = ImageHelper.ConvertImageToString(new Bitmap(PBX_ServerImage.Image, new Size(64, 64)));

                // Save server Image
                var bmp = new Bitmap(PBX_ServerImage.Image, new Size(64, 64));
                bmp.Save(Properties.Settings.Default.ServerDirectory + @"\server-icon.png");

                Settings.Default.Save();

                DialogResult = DialogResult.OK;
                Close();

                // Confirmation message
                _ = MessageBox.Show(this, "Setup saved successfully!",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                // General error handling
                _ = MessageBox.Show(this, "An unexpected error occurred while saving the setup: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_AddServerFile_Click(object sender, EventArgs e)
        {
            FRM_DownloadServerJarFile downloadJarFileForm = new();
            _ = downloadJarFileForm.ShowDialog(this);
        }

    }
}