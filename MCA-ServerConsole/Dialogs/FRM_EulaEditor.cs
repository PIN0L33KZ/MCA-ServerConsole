using Microsoft.Web.WebView2.Core;

namespace MCA_ServerConsole.Dialogs
{
    public partial class FRM_EulaEditor : Form
    {

        public FRM_EulaEditor()
        {
            InitializeComponent();
        }

        private void WBV_EulaText_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            BTN_AgreeEula.Enabled = true;
        }

        private async void FRM_EulaEditor_Load(object sender, EventArgs e)
        {
            try
            {
                await WBV_EulaText.EnsureCoreWebView2Async();
                WBV_EulaText.CoreWebView2.Navigate(@"https://aka.ms/MinecraftEULA");
                WBV_EulaText.ZoomFactor = 0.5;
                await WBV_EulaText.CoreWebView2.Profile.ClearBrowsingDataAsync(CoreWebView2BrowsingDataKinds.Cookies);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_AgreeEula_Click(object sender, EventArgs e)
        {
            try
            {
                string eulaFile = Properties.Settings.Default.ServerDirectory + @"\eula.txt";

                string fileContent = File.ReadAllText(eulaFile);
                string updatedContent = fileContent.Replace("eula=false", "eula=true");

                File.WriteAllText(eulaFile, updatedContent);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while writing to eula.txt: {ex.Message}");
            }
        }
    }
}