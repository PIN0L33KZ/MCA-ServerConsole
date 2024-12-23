using MCA_ServerConsole.Forms;
using MCA_ServerConsole.HelperClasses;

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
                while(string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerDirectory) || !Directory.Exists(Properties.Settings.Default.ServerDirectory))
                {
                    using FRM_Setup setupForm = new();
                    Hide(); // Hide the main form during setup
                    DialogResult setupDialogResult = setupForm.ShowDialog();

                    if(setupDialogResult != DialogResult.OK)
                    {
                        // User cancelled the setup
                        _ = MessageBox.Show(this, "Setup was cancelled. The application cannot continue without a server directory.",
                            "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                }

                Show();
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, $"An unexpected error occurred: {ex.Message}",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            // Check if Java or OpenJDK is installed
            while(!JavaHelper.IsJavaInstalled())
            {
                _ = MessageBox.Show("Java/OpenJDK is not installed or not added to PATH. Please install Java or OpenJDK to continue.",
                    "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Check if server.jar file exists
            while(!JavaHelper.JarFileExists(Properties.Settings.Default.ServerDirectory))
            {
                _ = MessageBox.Show("No server jar file detected! Please download a server jar file to continue.",
                     "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Continue with console form
            using FRM_Console consoleForm = new();
            Hide();
            if(consoleForm.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }

            // Restart if any error occures during FRM_Console
            Application.Restart();
        }
    }
}