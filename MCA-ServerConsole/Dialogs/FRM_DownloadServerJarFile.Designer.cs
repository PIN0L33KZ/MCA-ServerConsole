namespace MCA_ServerConsole.Properties
{
    partial class FRM_DownloadServerJarFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DownloadServerJarFile));
            LBL_ServerVersion = new Label();
            CBX_ServerVersion = new ComboBox();
            LBL_ServerType = new Label();
            CBX_ServerType = new ComboBox();
            BTN_DownloadServerJarFile = new Button();
            PGB_Download = new ProgressBar();
            SuspendLayout();
            // 
            // LBL_ServerVersion
            // 
            LBL_ServerVersion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LBL_ServerVersion.AutoSize = true;
            LBL_ServerVersion.Location = new Point(21, 54);
            LBL_ServerVersion.Name = "LBL_ServerVersion";
            LBL_ServerVersion.Size = new Size(80, 15);
            LBL_ServerVersion.TabIndex = 1;
            LBL_ServerVersion.Text = "Server version";
            // 
            // CBX_ServerVersion
            // 
            CBX_ServerVersion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CBX_ServerVersion.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_ServerVersion.Enabled = false;
            CBX_ServerVersion.FormattingEnabled = true;
            CBX_ServerVersion.Location = new Point(107, 50);
            CBX_ServerVersion.Name = "CBX_ServerVersion";
            CBX_ServerVersion.Size = new Size(95, 23);
            CBX_ServerVersion.TabIndex = 2;
            // 
            // LBL_ServerType
            // 
            LBL_ServerType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LBL_ServerType.AutoSize = true;
            LBL_ServerType.Location = new Point(21, 25);
            LBL_ServerType.Name = "LBL_ServerType";
            LBL_ServerType.Size = new Size(60, 15);
            LBL_ServerType.TabIndex = 1;
            LBL_ServerType.Text = "Server Typ";
            // 
            // CBX_ServerType
            // 
            CBX_ServerType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CBX_ServerType.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_ServerType.FormattingEnabled = true;
            CBX_ServerType.Location = new Point(107, 21);
            CBX_ServerType.Name = "CBX_ServerType";
            CBX_ServerType.Size = new Size(95, 23);
            CBX_ServerType.TabIndex = 2;
            CBX_ServerType.SelectedIndexChanged += CBX_ServerType_SelectedIndexChanged;
            // 
            // BTN_DownloadServerJarFile
            // 
            BTN_DownloadServerJarFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTN_DownloadServerJarFile.Location = new Point(21, 119);
            BTN_DownloadServerJarFile.Name = "BTN_DownloadServerJarFile";
            BTN_DownloadServerJarFile.Size = new Size(181, 23);
            BTN_DownloadServerJarFile.TabIndex = 3;
            BTN_DownloadServerJarFile.Text = "Download";
            BTN_DownloadServerJarFile.UseVisualStyleBackColor = true;
            BTN_DownloadServerJarFile.Click += BTN_DownloadServerJarFile_Click;
            // 
            // PGB_Download
            // 
            PGB_Download.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PGB_Download.Location = new Point(21, 79);
            PGB_Download.Name = "PGB_Download";
            PGB_Download.Size = new Size(181, 23);
            PGB_Download.TabIndex = 4;
            PGB_Download.UseWaitCursor = true;
            PGB_Download.Visible = false;
            // 
            // FRM_DownloadServerJarFile
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(222, 154);
            Controls.Add(PGB_Download);
            Controls.Add(BTN_DownloadServerJarFile);
            Controls.Add(CBX_ServerType);
            Controls.Add(LBL_ServerType);
            Controls.Add(CBX_ServerVersion);
            Controls.Add(LBL_ServerVersion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FRM_DownloadServerJarFile";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Minecraft Advanced Server Console :: Java File";
            Load += FRM_DownloadServerJarFile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LBL_ServerVersion;
        private ComboBox CBX_ServerVersion;
        private Label LBL_ServerType;
        private ComboBox CBX_ServerType;
        private Button BTN_DownloadServerJarFile;
        private ProgressBar PGB_Download;
    }
}