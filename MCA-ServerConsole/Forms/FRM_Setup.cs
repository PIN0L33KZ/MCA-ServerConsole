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
                if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerName))
                {
                    TBX_ServerName.Text = Properties.Settings.Default.ServerName;
                }

                // Load and validate server address
                if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerAddress) && RegexTest.IsValidIPv4(Properties.Settings.Default.ServerAddress))
                {
                    TBX_ServerAddress.Text = Properties.Settings.Default.ServerAddress;
                }
            }
            catch(Exception ex)
            {
                // General error handling for unexpected issues
                MessageBox.Show(this, "An error occurred while loading settings: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Load existing setup for ServerDirectory
                if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerDirectory))
                {
                    if(Directory.Exists(Properties.Settings.Default.ServerDirectory))
                    {
                        TBX_ServerDirectory.Text = Properties.Settings.Default.ServerDirectory;
                    }
                    else
                    {
                        MessageBox.Show(this, "The saved server directory does not exist. Please configure a new directory.",
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Load existing setup for ServerImage
                if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerImage))
                {
                    try
                    {
                        var serverImage = ImageHelper.ConvertStringToImage(Properties.Settings.Default.ServerImage);
                        if(serverImage != null)
                        {
                            PBX_ServerImage.Image = serverImage;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(this, "An error occurred while loading the server image: " + ex.Message,
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                // General catch for unexpected errors during form load
                MessageBox.Show(this, "An unexpected error occurred while loading the setup: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_SelectServerDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                // Folder browser dialog configuration
                var fBD = new FolderBrowserDialog()
                {
                    Description = "Select where to store your server's files.",
                    ShowHiddenFiles = false,
                    ShowNewFolderButton = true,
                    SelectedPath = Properties.Settings.Default.ServerDirectory.Length > 0
                        ? Properties.Settings.Default.ServerDirectory + '\\'
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
                    MessageBox.Show(this, "Invalid directory selected. Please try again.", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(this, "An unexpected error occurred: " + ex.Message, "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTX_SelectServerImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Open file dialog configuration
                var oFD = new OpenFileDialog()
                {
                    CheckFileExists = true,
                    Filter = "Images (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg",
                    ShowHiddenFiles = false,
                    Title = "Select a server image",
                    InitialDirectory = Properties.Settings.Default.ServerDirectory.Length > 0
                        ? Properties.Settings.Default.ServerDirectory + '\\'
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
                    MessageBox.Show("No file selected", "Minecraft Advanced Server Console");
                    return;
                }

                // Load image
                PBX_ServerImage.Image = Image.FromFile(oFD.FileName);
            }
            catch(Exception ex)
            {
                // Catch any error and display
                MessageBox.Show("Error: " + ex.Message, "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(string.IsNullOrWhiteSpace(TBX_ServerAddress.Text) || !RegexTest.IsValidIPv4(TBX_ServerAddress.Text))
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
                    MessageBox.Show(this, "Please correct the highlighted errors before saving.",
                        "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save settings
                Properties.Settings.Default.ServerName = TBX_ServerName.Text.Trim();
                Properties.Settings.Default.ServerAddress = TBX_ServerAddress.Text.Trim();
                Properties.Settings.Default.ServerDirectory = TBX_ServerDirectory.Text.Trim();
                Properties.Settings.Default.ServerImage = ImageHelper.ConvertImageToString(PBX_ServerImage.Image);

                Properties.Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
                Close();

                // Confirmation message
                MessageBox.Show(this, "Setup saved successfully!",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                // General error handling
                MessageBox.Show(this, "An unexpected error occurred while saving the setup: " + ex.Message,
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_AddServerFile_Click(object sender, EventArgs e)
        {
            var downloadJarFileForm = new FRM_DownloadServerJarFile();
            downloadJarFileForm.ShowDialog(this);
        }
    }
}