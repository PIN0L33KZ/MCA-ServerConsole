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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_EulaEditor));
            WBV_EulaText = new Microsoft.Web.WebView2.WinForms.WebView2();
            PNL_Bottom = new Panel();
            BTN_AgreeEula = new Button();
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
            WBV_EulaText.Size = new Size(800, 411);
            WBV_EulaText.TabIndex = 0;
            WBV_EulaText.ZoomFactor = 1D;
            WBV_EulaText.NavigationCompleted += WBV_EulaText_NavigationCompleted;
            // 
            // PNL_Bottom
            // 
            PNL_Bottom.Controls.Add(BTN_AgreeEula);
            PNL_Bottom.Dock = DockStyle.Bottom;
            PNL_Bottom.Location = new Point(0, 411);
            PNL_Bottom.Name = "PNL_Bottom";
            PNL_Bottom.Size = new Size(800, 39);
            PNL_Bottom.TabIndex = 1;
            // 
            // BTN_AgreeEula
            // 
            BTN_AgreeEula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTN_AgreeEula.Cursor = Cursors.Hand;
            BTN_AgreeEula.DialogResult = DialogResult.OK;
            BTN_AgreeEula.Enabled = false;
            BTN_AgreeEula.Location = new Point(12, 8);
            BTN_AgreeEula.Name = "BTN_AgreeEula";
            BTN_AgreeEula.Size = new Size(776, 23);
            BTN_AgreeEula.TabIndex = 0;
            BTN_AgreeEula.Text = "I agree to the EULA shown above!";
            BTN_AgreeEula.UseVisualStyleBackColor = true;
            BTN_AgreeEula.Click += BTN_AgreeEula_Click;
            // 
            // FRM_EulaEditor
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(WBV_EulaText);
            Controls.Add(PNL_Bottom);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "FRM_EulaEditor";
            Text = "Minecraft Advanced Server Console :: EULA Editor";
            Load += FRM_EulaEditor_Load;
            ((System.ComponentModel.ISupportInitialize)WBV_EulaText).EndInit();
            PNL_Bottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 WBV_EulaText;
        private Panel PNL_Bottom;
        private Button BTN_AgreeEula;
    }
}