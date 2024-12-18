namespace MCA_ServerConsole
{
    public partial class FRM_Startup : Form
    {
        public FRM_Startup()
        {
            InitializeComponent();
        }

        private void FRM_Startup_Load(object sender, EventArgs e)
        {
            try
            {
                // Keep showing the setup form until ServerDirectory is set
                while(string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerDirectory))
                {
                    using FRM_Setup setupForm = new();
                    Hide(); // Hide the main form during setup
                    DialogResult dialogResult = setupForm.ShowDialog();

                    if(dialogResult != DialogResult.OK)
                    {
                        // User cancelled the setup
                        _ = MessageBox.Show(this, "Setup was cancelled. The application cannot continue without a server directory.",
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                }

                // Show main form again
                Show();
            }
            catch(Exception ex)
            {
                // Handle any unexpected errors
                _ = MessageBox.Show(this, $"An unexpected error occurred: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Exit the application if an unrecoverable error occurs
            }

            // Continue with application
        }
    }
}