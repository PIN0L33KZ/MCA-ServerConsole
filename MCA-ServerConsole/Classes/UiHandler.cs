using MCA_ServerConsole.Dialogs;
using MCA_ServerConsole.HelperClasses;
using Guna.UI2.WinForms;

namespace MCA_ServerConsole.Classes
{
    public class UIHandler(ToolStripLabel serverStatusLabel, ToolStripLabel gameVersionLabel, ToolStripLabel portStatusLabel, ToolStripLabel defaultGamemodeLabel, Guna2CircleProgressBar serverStartLoading, Guna2Button startServerButton, Guna2Button reloadServerButton, Guna2Button stopServerButton, Guna2Button addJavaFileButton, Guna2ComboBox jarFileSelectionComboBox, Guna2NumericUpDown serverRam, Guna2TextBox commandTextBox, Guna2Button sendCommandButton, Guna2Button saveConsoleOutputButton, RichTextBox serverLog, ContextMenuStrip contextMenuStrip, Guna2ToggleSwitch javaConsole, JavaProcessHandler processHandler)
    {
        private readonly ToolStripLabel _serverStatusLabel = serverStatusLabel;
        private readonly ToolStripLabel _gameVersionLabel = gameVersionLabel;
        private readonly ToolStripLabel _portStatusLabel = portStatusLabel;
        private readonly ToolStripLabel _defaultGamemodeLabel = defaultGamemodeLabel;
        private readonly Guna2CircleProgressBar _serverStartLoading = serverStartLoading;
        private readonly Guna2Button _startServerButton = startServerButton;
        private readonly Guna2Button _reloadServerButton = reloadServerButton;
        private readonly Guna2Button _stopServerButton = stopServerButton;
        private readonly Guna2Button _addJavaFileButton = addJavaFileButton;
        private readonly Guna2ComboBox _jarFileSelectionComboBox = jarFileSelectionComboBox;
        private readonly Guna2NumericUpDown _serverRam = serverRam;
        private readonly Guna2TextBox _commandTextBox = commandTextBox;
        private readonly Guna2Button _sendCommandButton = sendCommandButton;
        private readonly Guna2Button _saveConsoleOutputButton = saveConsoleOutputButton;
        private readonly RichTextBox _serverLog = serverLog;
        private readonly ContextMenuStrip _menuStrip = contextMenuStrip;
        private readonly Guna2ToggleSwitch _javaConsole = javaConsole;

        public void UpdateUI(string keyword, string output)
        {
            switch(keyword)
            {
                // User needs to accept the EULA
                case "agree to the eula":
                    _serverStatusLabel.Text = "Server is waiting for user action";
                    _serverStatusLabel.Image = Properties.Resources.waiting;
                    _startServerButton.Enabled = true;
                    _serverStartLoading.Visible = false;
                    _addJavaFileButton.Enabled = true;
                    _javaConsole.Enabled = true;
                    _jarFileSelectionComboBox.Enabled = true;
                    _serverRam.Enabled = true;

                    bool agreed = false;

                    while(!agreed)
                    {
                        _ = MessageBox.Show("You need to agree to Minecraft's EULA", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        FRM_EulaEditor eulaEditor = new();
                        if(eulaEditor.ShowDialog() == DialogResult.OK)
                        {
                            agreed = true;
                        }
                    }

                    _startServerButton.PerformClick();
                    break;

                case "sun.nio.ch.filedispatcherimpl.write0":
                    _serverStatusLabel.Text = "Server crashed";
                    _serverStatusLabel.Image = Properties.Resources.health;

                    if(MessageBox.Show("There is already a server process running in the background, shutdown now?", "MCA Console", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    {
                        _startServerButton.Enabled = true;
                        _serverStartLoading.Visible = false;
                        _addJavaFileButton.Enabled = true;
                        _javaConsole.Enabled = true;
                        _serverRam.Enabled = true;
                        _jarFileSelectionComboBox.Enabled = true;
                        return;
                    }

                    JavaProcessHandler.KillAlreadyRunningJavaProcesses();
                    _startServerButton.Enabled = true;
                    _serverStartLoading.Visible = false;
                    _startServerButton.PerformClick();
                    break;

                // Indicates that the server is starting
                case "starting":
                    _serverStatusLabel.Text = "Server starting... ";
                    _serverStatusLabel.Image = Properties.Resources.starting;
                    _startServerButton.Enabled = false;
                    _serverStartLoading.Visible = true;
                    _javaConsole.Enabled = false;
                    _reloadServerButton.Enabled = false;
                    _stopServerButton.Enabled = false;
                    _saveConsoleOutputButton.Enabled = false;
                    _addJavaFileButton.Enabled = false;
                    _serverLog.ContextMenuStrip = null;
                    _jarFileSelectionComboBox.Enabled = false;
                    _serverRam.Enabled = false;
                    break;

                // Contains game version
                case "server version":
                    _gameVersionLabel.Text = $"Minecraft version: {StringHelper.CutTillLastPart(output)} |";
                    break;

                // Contains port and network interface
                case "server on":
                    _portStatusLabel.Text = $"Port: {StringHelper.CutTillLastPart(output)} |";
                    break;

                // Contains default gamemode
                case "game type":
                    _defaultGamemodeLabel.Text = $"Default gamemode: {StringHelper.NormalizeCaseing(StringHelper.CutTillLastPart(output))}";
                    break;

                // Indicates that the server is started successfully
                case "done":
                    _serverStatusLabel.Text = "Server running |";
                    _serverStatusLabel.Image = Properties.Resources.running;
                    _startServerButton.Enabled = false;
                    _serverStartLoading.Visible = false;
                    _javaConsole.Enabled = false;
                    _reloadServerButton.Enabled = true;
                    _stopServerButton.Enabled = true;
                    _addJavaFileButton.Enabled = false;
                    _saveConsoleOutputButton.Enabled = false;
                    _serverLog.ContextMenuStrip = null;
                    _jarFileSelectionComboBox.Enabled = false;
                    _serverRam.Enabled = false;
                    _commandTextBox.Enabled = true;
                    _sendCommandButton.Enabled = true;
                    break;

                // Indicates that the server is stoped successfully
                case "stopping server":
                    _serverStatusLabel.Text = "Server stopped";
                    _serverStatusLabel.Image = Properties.Resources.stopped;
                    _startServerButton.Enabled = true;
                    _javaConsole.Enabled = true;
                    _reloadServerButton.Enabled = false;
                    _stopServerButton.Enabled = false;
                    _addJavaFileButton.Enabled = true;
                    _saveConsoleOutputButton.Enabled = true;
                    _serverLog.ContextMenuStrip = _menuStrip;
                    _jarFileSelectionComboBox.Enabled = true;
                    _serverRam.Enabled = true;
                    _gameVersionLabel.Text = "";
                    _portStatusLabel.Text = "";
                    _defaultGamemodeLabel.Text = "";
                    _commandTextBox.Enabled = false;
                    _commandTextBox.Text = "";
                    _sendCommandButton.Enabled = false;
                    break;

                default:
                    break;
            }
        }
    }
}