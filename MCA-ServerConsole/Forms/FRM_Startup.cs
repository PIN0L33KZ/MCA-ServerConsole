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
                // 1) Server-Verzeichnis sicherstellen
                if(!EnsureServerDirectoryConfigured())
                {
                    Application.Exit();
                    return;
                }

                // 2) Java sicherstellen
                if(!EnsureJavaInstalled())
                {
                    Application.Exit();
                    return;
                }

                // 3) server.jar sicherstellen
                if(!EnsureServerJarExists())
                {
                    Application.Exit();
                    return;
                }

                // 4) Console starten
                using FRM_Console consoleForm = new();
                Hide();
                if(consoleForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Exit();
                }
                else
                {
                    Application.Restart(); // restart app if any error occurs during FRM_Console is shown
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, $"An unexpected error occurred: {ex.Message}",
                    "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Stellt sicher, dass ein gültiges ServerDirectory gesetzt ist.
        /// Öffnet bei Bedarf FRM_Setup, bietet aber immer einen Exit-Weg.
        /// </summary>
        private bool EnsureServerDirectoryConfigured()
        {
            while(string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerDirectory) ||
                   !Directory.Exists(Properties.Settings.Default.ServerDirectory))
            {
                using FRM_Setup setupForm = new();
                Hide();
                DialogResult setupDialogResult = setupForm.ShowDialog(this);
                Show();

                if(setupDialogResult != DialogResult.OK)
                {
                    DialogResult msgResult = MessageBox.Show(
                        this,
                        "Setup was cancelled. The application cannot continue without a server directory.\n" +
                        "Do you want to exit the application?",
                        "MCA Console",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if(msgResult == DialogResult.Yes)
                    {
                        return false; // User möchte beenden
                    }

                    // User möchte nicht beenden → nochmal versuchen (loop läuft weiter)
                    continue;
                }

                // Setup war OK → Konfiguration prüfen
                if(string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerDirectory) ||
                    !Directory.Exists(Properties.Settings.Default.ServerDirectory))
                {
                    DialogResult retryResult = MessageBox.Show(
                        this,
                        "The selected server directory is invalid. Do you want to run the setup again?",
                        "MCA Console",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if(retryResult == DialogResult.No)
                    {
                        return false;
                    }

                    continue;
                }
            }

            return true;
        }

        /// <summary>
        /// Stellt sicher, dass Java installiert ist.
        /// Kein Endlos-Loop mehr, User kann abbrechen.
        /// </summary>
        private bool EnsureJavaInstalled()
        {
            while(!JavaHelper.IsJavaInstalled())
            {
                DialogResult result = MessageBox.Show(
                    this,
                    "Java/OpenJDK is not installed or not added to PATH.\n" +
                    "Please install Java or OpenJDK to continue.\n\n" +
                    "Click 'Retry' after installation, or 'Cancel' to exit.",
                    "MCA Console",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Warning);

                if(result == DialogResult.Cancel)
                {
                    return false;
                }

                // Retry → while-Schleife prüft erneut und macht weiter
            }

            return true;
        }

        /// <summary>
        /// Stellt sicher, dass im ServerDirectory eine server.jar vorhanden ist.
        /// Wenn nicht: Setup anbieten, ansonsten Exit.
        /// </summary>
        private bool EnsureServerJarExists()
        {
            while(!JavaHelper.JarFileExists(Properties.Settings.Default.ServerDirectory))
            {
                DialogResult result = MessageBox.Show(
                    this,
                    "No server jar file detected in the configured server directory.\n" +
                    "Do you want to open the setup to download or select a server jar now?",
                    "MCA Console",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if(result == DialogResult.No)
                {
                    // User will nicht nochmal ins Setup → Anwendung beenden
                    return false;
                }

                // User hat "Ja" gewählt → Setup erneut anzeigen
                using FRM_Setup setupForm = new();
                Hide();
                DialogResult setupDialogResult = setupForm.ShowDialog(this);
                Show();

                if(setupDialogResult != DialogResult.OK)
                {
                    DialogResult retrySetup = MessageBox.Show(
                        this,
                        "Setup was cancelled. Without a server jar file the application cannot continue.\n" +
                        "Do you want to try the setup again?",
                        "MCA Console",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if(retrySetup == DialogResult.No)
                    {
                        return false;
                    }

                    // Yes → zurück in die while-Schleife, erneut prüfen / Setup anbieten
                    continue;
                }

                // Setup war OK, Schleife prüft im nächsten Durchlauf erneut, ob jetzt eine JAR da ist.
            }

            return true;
        }
    }
}