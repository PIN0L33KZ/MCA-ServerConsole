namespace MCA_ServerConsole
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Activates DPI-Awareness
            Application.SetHighDpiMode(HighDpiMode.SystemAware);


            if(MessageBox.Show("DEBUG: Reset settings?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FRM_Startup());
        }
    }
}