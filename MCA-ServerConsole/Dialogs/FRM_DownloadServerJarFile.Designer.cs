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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DownloadServerJarFile));
            LBL_ServerVersion = new Label();
            LBL_ServerType = new Label();
            CBX_ServerType = new Guna.UI2.WinForms.Guna2ComboBox();
            CBX_ServerVersion = new Guna.UI2.WinForms.Guna2ComboBox();
            PGB_Download = new Guna.UI2.WinForms.Guna2ProgressBar();
            BTN_DownloadServerJarFile = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // LBL_ServerVersion
            // 
            LBL_ServerVersion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LBL_ServerVersion.AutoSize = true;
            LBL_ServerVersion.BackColor = Color.Transparent;
            LBL_ServerVersion.Font = new Font("Lexend", 11.25F);
            LBL_ServerVersion.ForeColor = Color.FromArgb(235, 234, 234);
            LBL_ServerVersion.Location = new Point(21, 61);
            LBL_ServerVersion.Name = "LBL_ServerVersion";
            LBL_ServerVersion.Size = new Size(116, 24);
            LBL_ServerVersion.TabIndex = 1;
            LBL_ServerVersion.Text = "Server version";
            // 
            // LBL_ServerType
            // 
            LBL_ServerType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LBL_ServerType.AutoSize = true;
            LBL_ServerType.BackColor = Color.Transparent;
            LBL_ServerType.Font = new Font("Lexend", 11.25F);
            LBL_ServerType.ForeColor = Color.FromArgb(235, 234, 234);
            LBL_ServerType.Location = new Point(21, 19);
            LBL_ServerType.Name = "LBL_ServerType";
            LBL_ServerType.Size = new Size(89, 24);
            LBL_ServerType.TabIndex = 1;
            LBL_ServerType.Text = "Server Typ";
            // 
            // CBX_ServerType
            // 
            CBX_ServerType.AutoRoundedCorners = true;
            CBX_ServerType.BackColor = Color.Transparent;
            CBX_ServerType.BorderColor = Color.FromArgb(80, 76, 76);
            CBX_ServerType.BorderThickness = 2;
            CBX_ServerType.Cursor = Cursors.Hand;
            CBX_ServerType.CustomizableEdges = customizableEdges1;
            CBX_ServerType.DrawMode = DrawMode.OwnerDrawFixed;
            CBX_ServerType.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_ServerType.FillColor = Color.FromArgb(58, 55, 55);
            CBX_ServerType.FocusedColor = Color.FromArgb(162, 123, 90);
            CBX_ServerType.FocusedState.BorderColor = Color.FromArgb(162, 123, 90);
            CBX_ServerType.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBX_ServerType.ForeColor = Color.FromArgb(235, 234, 234);
            CBX_ServerType.HoverState.BorderColor = Color.FromArgb(194, 165, 142);
            CBX_ServerType.ItemHeight = 30;
            CBX_ServerType.Location = new Point(172, 13);
            CBX_ServerType.MaxDropDownItems = 10;
            CBX_ServerType.Name = "CBX_ServerType";
            CBX_ServerType.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CBX_ServerType.Size = new Size(156, 36);
            CBX_ServerType.TabIndex = 5;
            CBX_ServerType.TextOffset = new Point(0, 1);
            CBX_ServerType.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            CBX_ServerType.SelectedIndexChanged += CBX_ServerType_SelectedIndexChanged;
            // 
            // CBX_ServerVersion
            // 
            CBX_ServerVersion.AutoRoundedCorners = true;
            CBX_ServerVersion.BackColor = Color.Transparent;
            CBX_ServerVersion.BorderColor = Color.FromArgb(80, 76, 76);
            CBX_ServerVersion.BorderThickness = 2;
            CBX_ServerVersion.Cursor = Cursors.Hand;
            CBX_ServerVersion.CustomizableEdges = customizableEdges3;
            CBX_ServerVersion.DrawMode = DrawMode.OwnerDrawFixed;
            CBX_ServerVersion.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_ServerVersion.FillColor = Color.FromArgb(58, 55, 55);
            CBX_ServerVersion.FocusedColor = Color.FromArgb(162, 123, 90);
            CBX_ServerVersion.FocusedState.BorderColor = Color.FromArgb(162, 123, 90);
            CBX_ServerVersion.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBX_ServerVersion.ForeColor = Color.FromArgb(235, 234, 234);
            CBX_ServerVersion.HoverState.BorderColor = Color.FromArgb(194, 165, 142);
            CBX_ServerVersion.ItemHeight = 30;
            CBX_ServerVersion.Location = new Point(172, 55);
            CBX_ServerVersion.MaxDropDownItems = 10;
            CBX_ServerVersion.Name = "CBX_ServerVersion";
            CBX_ServerVersion.ShadowDecoration.CustomizableEdges = customizableEdges4;
            CBX_ServerVersion.Size = new Size(156, 36);
            CBX_ServerVersion.TabIndex = 5;
            CBX_ServerVersion.TextOffset = new Point(0, 1);
            CBX_ServerVersion.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            CBX_ServerVersion.SelectedIndexChanged += CBX_ServerVersion_SelectedIndexChanged;
            // 
            // PGB_Download
            // 
            PGB_Download.AutoRoundedCorners = true;
            PGB_Download.BorderColor = Color.FromArgb(80, 76, 76);
            PGB_Download.BorderThickness = 1;
            PGB_Download.CustomizableEdges = customizableEdges5;
            PGB_Download.FillColor = Color.FromArgb(58, 55, 55);
            PGB_Download.Location = new Point(21, 97);
            PGB_Download.Name = "PGB_Download";
            PGB_Download.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            PGB_Download.ProgressColor = Color.FromArgb(162, 123, 90);
            PGB_Download.ProgressColor2 = Color.FromArgb(162, 123, 90);
            PGB_Download.ShadowDecoration.CustomizableEdges = customizableEdges6;
            PGB_Download.Size = new Size(307, 15);
            PGB_Download.TabIndex = 6;
            PGB_Download.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            PGB_Download.Visible = false;
            // 
            // BTN_DownloadServerJarFile
            // 
            BTN_DownloadServerJarFile.Animated = true;
            BTN_DownloadServerJarFile.AutoRoundedCorners = true;
            BTN_DownloadServerJarFile.BackColor = Color.Transparent;
            BTN_DownloadServerJarFile.BorderColor = Color.Empty;
            BTN_DownloadServerJarFile.Cursor = Cursors.Hand;
            BTN_DownloadServerJarFile.CustomizableEdges = customizableEdges7;
            BTN_DownloadServerJarFile.DisabledState.BorderColor = Color.DarkGray;
            BTN_DownloadServerJarFile.DisabledState.CustomBorderColor = Color.DarkGray;
            BTN_DownloadServerJarFile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BTN_DownloadServerJarFile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BTN_DownloadServerJarFile.FillColor = Color.FromArgb(162, 123, 90);
            BTN_DownloadServerJarFile.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTN_DownloadServerJarFile.ForeColor = Color.White;
            BTN_DownloadServerJarFile.Location = new Point(21, 118);
            BTN_DownloadServerJarFile.Name = "BTN_DownloadServerJarFile";
            BTN_DownloadServerJarFile.ShadowDecoration.CustomizableEdges = customizableEdges8;
            BTN_DownloadServerJarFile.Size = new Size(307, 39);
            BTN_DownloadServerJarFile.TabIndex = 7;
            BTN_DownloadServerJarFile.Text = "Download";
            BTN_DownloadServerJarFile.Click += BTN_DownloadServerJarFile_Click;
            // 
            // FRM_DownloadServerJarFile
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(38, 34, 34);
            ClientSize = new Size(335, 165);
            Controls.Add(BTN_DownloadServerJarFile);
            Controls.Add(PGB_Download);
            Controls.Add(CBX_ServerVersion);
            Controls.Add(CBX_ServerType);
            Controls.Add(LBL_ServerType);
            Controls.Add(LBL_ServerVersion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FRM_DownloadServerJarFile";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MCA Console Download";
            Load += FRM_DownloadServerJarFile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LBL_ServerVersion;
        private Label LBL_ServerType;
        private Guna.UI2.WinForms.Guna2ComboBox CBX_ServerType;
        private Guna.UI2.WinForms.Guna2ComboBox CBX_ServerVersion;
        private Guna.UI2.WinForms.Guna2ProgressBar PGB_Download;
        private Guna.UI2.WinForms.Guna2Button BTN_DownloadServerJarFile;
    }
}