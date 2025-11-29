namespace MCA_ServerConsole.Dialogs
{
    partial class FRM_EulaEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_EulaEditor));
            WBV_EulaText = new Microsoft.Web.WebView2.WinForms.WebView2();
            PNL_Bottom = new Panel();
            BTN_AgreeEula = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)WBV_EulaText).BeginInit();
            PNL_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // WBV_EulaText
            // 
            WBV_EulaText.AllowExternalDrop = false;
            WBV_EulaText.CreationProperties = null;
            WBV_EulaText.DefaultBackgroundColor = Color.White;
            WBV_EulaText.Dock = DockStyle.Fill;
            WBV_EulaText.Location = new Point(0, 0);
            WBV_EulaText.Name = "WBV_EulaText";
            WBV_EulaText.Size = new Size(800, 390);
            WBV_EulaText.TabIndex = 0;
            WBV_EulaText.ZoomFactor = 1D;
            WBV_EulaText.NavigationCompleted += WBV_EulaText_NavigationCompleted;
            // 
            // PNL_Bottom
            // 
            PNL_Bottom.Controls.Add(BTN_AgreeEula);
            PNL_Bottom.Dock = DockStyle.Bottom;
            PNL_Bottom.Location = new Point(0, 390);
            PNL_Bottom.Name = "PNL_Bottom";
            PNL_Bottom.Size = new Size(800, 60);
            PNL_Bottom.TabIndex = 1;
            // 
            // BTN_AgreeEula
            // 
            BTN_AgreeEula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTN_AgreeEula.Animated = true;
            BTN_AgreeEula.AutoRoundedCorners = true;
            BTN_AgreeEula.BackColor = Color.Transparent;
            BTN_AgreeEula.BorderColor = Color.Empty;
            BTN_AgreeEula.Cursor = Cursors.Hand;
            BTN_AgreeEula.CustomizableEdges = customizableEdges1;
            BTN_AgreeEula.DialogResult = DialogResult.OK;
            BTN_AgreeEula.DisabledState.BorderColor = Color.DarkGray;
            BTN_AgreeEula.DisabledState.CustomBorderColor = Color.DarkGray;
            BTN_AgreeEula.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BTN_AgreeEula.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BTN_AgreeEula.Enabled = false;
            BTN_AgreeEula.FillColor = Color.FromArgb(162, 123, 90);
            BTN_AgreeEula.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTN_AgreeEula.ForeColor = Color.White;
            BTN_AgreeEula.Location = new Point(10, 13);
            BTN_AgreeEula.Margin = new Padding(10);
            BTN_AgreeEula.Name = "BTN_AgreeEula";
            BTN_AgreeEula.ShadowDecoration.CustomizableEdges = customizableEdges2;
            BTN_AgreeEula.Size = new Size(780, 37);
            BTN_AgreeEula.TabIndex = 7;
            BTN_AgreeEula.Text = "I agree to the EULA shown above!";
            BTN_AgreeEula.Click += BTN_AgreeEula_Click;
            // 
            // FRM_EulaEditor
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(38, 34, 34);
            ClientSize = new Size(800, 450);
            Controls.Add(WBV_EulaText);
            Controls.Add(PNL_Bottom);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "FRM_EulaEditor";
            Text = "MCA Console EULA Editor";
            Load += FRM_EulaEditor_Load;
            ((System.ComponentModel.ISupportInitialize)WBV_EulaText).EndInit();
            PNL_Bottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 WBV_EulaText;
        private Panel PNL_Bottom;
        private Guna.UI2.WinForms.Guna2Button BTN_AgreeEula;
    }
}