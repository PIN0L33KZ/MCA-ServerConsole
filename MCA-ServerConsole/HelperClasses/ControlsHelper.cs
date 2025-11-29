namespace MCA_ServerConsole.HelperClasses
{
    public class ControlsHelper
    {
        public static void SupressEnterKey(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        public static void CutNewLines(object? sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2TextBox textBox)
            {
                string text = textBox.Text.Replace("\r", "").Replace("\n", "");
                if (textBox.Text != text)
                {
                    textBox.Text = text;
                    textBox.SelectionStart = textBox.TextLength;
                }
            }
        }
    }
}