namespace MCA_ServerConsole
{
    partial class FRM_Setup
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Setup));
            LBL_ServerName = new Label();
            ERP_Main = new ErrorProvider(components);
            LBL_ServerIP = new Label();
            LBL_ServerDirectory = new Label();
            TBX_ServerName = new Guna.UI2.WinForms.Guna2TextBox();
            TBX_ServerAddress = new Guna.UI2.WinForms.Guna2TextBox();
            TBX_ServerDirectory = new Guna.UI2.WinForms.Guna2TextBox();
            BTN_SelectServerDirectory = new Guna.UI2.WinForms.Guna2Button();
            BTN_SelectServerImage = new Guna.UI2.WinForms.Guna2Button();
            TBX_ServerLogo = new Label();
            BTN_AddServerFile = new Guna.UI2.WinForms.Guna2Button();
            BTN_SaveSetup = new Guna.UI2.WinForms.Guna2Button();
            PBX_ServerImage = new Guna.UI2.WinForms.Guna2PictureBox();
            VSP_1 = new Guna.UI2.WinForms.Guna2VSeparator();
            ((System.ComponentModel.ISupportInitialize)ERP_Main).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBX_ServerImage).BeginInit();
            SuspendLayout();
            // 
            // LBL_ServerName
            // 
            LBL_ServerName.AutoSize = true;
            LBL_ServerName.Font = new Font("Lexend", 11.25F);
            LBL_ServerName.ForeColor = Color.FromArgb(235, 234, 234);
            LBL_ServerName.Location = new Point(12, 23);
            LBL_ServerName.Name = "LBL_ServerName";
            LBL_ServerName.Size = new Size(104, 24);
            LBL_ServerName.TabIndex = 0;
            LBL_ServerName.Text = "Server name";
            // 
            // ERP_Main
            // 
            ERP_Main.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ERP_Main.ContainerControl = this;
            // 
            // LBL_ServerIP
            // 
            LBL_ServerIP.AutoSize = true;
            LBL_ServerIP.Font = new Font("Lexend", 11.25F);
            LBL_ServerIP.ForeColor = Color.FromArgb(235, 234, 234);
            LBL_ServerIP.Location = new Point(12, 75);
            LBL_ServerIP.Name = "LBL_ServerIP";
            LBL_ServerIP.Size = new Size(121, 24);
            LBL_ServerIP.TabIndex = 0;
            LBL_ServerIP.Text = "Server address";
            // 
            // LBL_ServerDirectory
            // 
            LBL_ServerDirectory.AutoSize = true;
            LBL_ServerDirectory.Font = new Font("Lexend", 11.25F);
            LBL_ServerDirectory.ForeColor = Color.FromArgb(235, 234, 234);
            LBL_ServerDirectory.Location = new Point(12, 127);
            LBL_ServerDirectory.Name = "LBL_ServerDirectory";
            LBL_ServerDirectory.Size = new Size(119, 24);
            LBL_ServerDirectory.TabIndex = 0;
            LBL_ServerDirectory.Text = "Server storage";
            // 
            // TBX_ServerName
            // 
            TBX_ServerName.Animated = true;
            TBX_ServerName.AutoRoundedCorners = true;
            TBX_ServerName.BorderColor = Color.FromArgb(103, 99, 99);
            TBX_ServerName.BorderThickness = 2;
            TBX_ServerName.CustomizableEdges = customizableEdges13;
            TBX_ServerName.DefaultText = "";
            TBX_ServerName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TBX_ServerName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TBX_ServerName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TBX_ServerName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TBX_ServerName.FillColor = Color.FromArgb(58, 55, 55);
            TBX_ServerName.FocusedState.BorderColor = Color.FromArgb(162, 123, 90);
            TBX_ServerName.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBX_ServerName.ForeColor = Color.FromArgb(235, 234, 234);
            TBX_ServerName.HoverState.BorderColor = Color.FromArgb(194, 165, 142);
            TBX_ServerName.Location = new Point(150, 14);
            TBX_ServerName.Margin = new Padding(4, 5, 4, 5);
            TBX_ServerName.Multiline = true;
            TBX_ServerName.Name = "TBX_ServerName";
            TBX_ServerName.PlaceholderForeColor = Color.FromArgb(151, 148, 148);
            TBX_ServerName.PlaceholderText = "Server name";
            TBX_ServerName.SelectedText = "";
            TBX_ServerName.ShadowDecoration.CustomizableEdges = customizableEdges14;
            TBX_ServerName.Size = new Size(228, 42);
            TBX_ServerName.TabIndex = 0;
            TBX_ServerName.TextAlign = HorizontalAlignment.Center;
            TBX_ServerName.TextOffset = new Point(2, -1);
            TBX_ServerName.WordWrap = false;
            // 
            // TBX_ServerAddress
            // 
            TBX_ServerAddress.Animated = true;
            TBX_ServerAddress.AutoRoundedCorners = true;
            TBX_ServerAddress.BorderColor = Color.FromArgb(103, 99, 99);
            TBX_ServerAddress.BorderThickness = 2;
            TBX_ServerAddress.CustomizableEdges = customizableEdges11;
            TBX_ServerAddress.DefaultText = "127.0.0.1";
            TBX_ServerAddress.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TBX_ServerAddress.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TBX_ServerAddress.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TBX_ServerAddress.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TBX_ServerAddress.FillColor = Color.FromArgb(58, 55, 55);
            TBX_ServerAddress.FocusedState.BorderColor = Color.FromArgb(162, 123, 90);
            TBX_ServerAddress.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBX_ServerAddress.ForeColor = Color.FromArgb(235, 234, 234);
            TBX_ServerAddress.HoverState.BorderColor = Color.FromArgb(194, 165, 142);
            TBX_ServerAddress.Location = new Point(150, 66);
            TBX_ServerAddress.Margin = new Padding(4, 5, 4, 5);
            TBX_ServerAddress.Multiline = true;
            TBX_ServerAddress.Name = "TBX_ServerAddress";
            TBX_ServerAddress.PlaceholderForeColor = Color.FromArgb(151, 148, 148);
            TBX_ServerAddress.PlaceholderText = "127.0.0.1";
            TBX_ServerAddress.SelectedText = "";
            TBX_ServerAddress.ShadowDecoration.CustomizableEdges = customizableEdges12;
            TBX_ServerAddress.Size = new Size(96, 42);
            TBX_ServerAddress.TabIndex = 1;
            TBX_ServerAddress.TextAlign = HorizontalAlignment.Center;
            TBX_ServerAddress.TextOffset = new Point(2, -1);
            TBX_ServerAddress.WordWrap = false;
            // 
            // TBX_ServerDirectory
            // 
            TBX_ServerDirectory.Animated = true;
            TBX_ServerDirectory.AutoRoundedCorners = true;
            TBX_ServerDirectory.BackColor = Color.Transparent;
            TBX_ServerDirectory.BorderColor = Color.FromArgb(103, 99, 99);
            TBX_ServerDirectory.BorderThickness = 2;
            customizableEdges9.BottomRight = false;
            customizableEdges9.TopRight = false;
            TBX_ServerDirectory.CustomizableEdges = customizableEdges9;
            TBX_ServerDirectory.DefaultText = "";
            TBX_ServerDirectory.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TBX_ServerDirectory.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TBX_ServerDirectory.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TBX_ServerDirectory.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TBX_ServerDirectory.FillColor = Color.FromArgb(58, 55, 55);
            TBX_ServerDirectory.FocusedState.BorderColor = Color.FromArgb(162, 123, 90);
            TBX_ServerDirectory.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBX_ServerDirectory.ForeColor = Color.FromArgb(235, 234, 234);
            TBX_ServerDirectory.HoverState.BorderColor = Color.FromArgb(194, 165, 142);
            TBX_ServerDirectory.Location = new Point(150, 118);
            TBX_ServerDirectory.Margin = new Padding(4, 5, 4, 5);
            TBX_ServerDirectory.Multiline = true;
            TBX_ServerDirectory.Name = "TBX_ServerDirectory";
            TBX_ServerDirectory.PlaceholderForeColor = Color.FromArgb(151, 148, 148);
            TBX_ServerDirectory.PlaceholderText = "C:\\Users\\...";
            TBX_ServerDirectory.SelectedText = "";
            TBX_ServerDirectory.ShadowDecoration.CustomizableEdges = customizableEdges10;
            TBX_ServerDirectory.Size = new Size(341, 42);
            TBX_ServerDirectory.TabIndex = 2;
            TBX_ServerDirectory.TextOffset = new Point(2, -1);
            TBX_ServerDirectory.WordWrap = false;
            TBX_ServerDirectory.TextChanged += TBX_ServerDirectory_TextChanged;
            // 
            // BTN_SelectServerDirectory
            // 
            BTN_SelectServerDirectory.Animated = true;
            BTN_SelectServerDirectory.AutoRoundedCorners = true;
            BTN_SelectServerDirectory.BackColor = Color.Transparent;
            BTN_SelectServerDirectory.BorderColor = Color.FromArgb(103, 99, 99);
            BTN_SelectServerDirectory.BorderThickness = 2;
            BTN_SelectServerDirectory.CheckedState.BorderColor = Color.FromArgb(162, 123, 90);
            BTN_SelectServerDirectory.Cursor = Cursors.Hand;
            customizableEdges7.BottomLeft = false;
            customizableEdges7.TopLeft = false;
            BTN_SelectServerDirectory.CustomizableEdges = customizableEdges7;
            BTN_SelectServerDirectory.DisabledState.BorderColor = Color.DarkGray;
            BTN_SelectServerDirectory.DisabledState.CustomBorderColor = Color.DarkGray;
            BTN_SelectServerDirectory.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BTN_SelectServerDirectory.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BTN_SelectServerDirectory.FillColor = Color.FromArgb(58, 55, 55);
            BTN_SelectServerDirectory.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTN_SelectServerDirectory.ForeColor = Color.White;
            BTN_SelectServerDirectory.HoverState.BorderColor = Color.FromArgb(194, 165, 142);
            BTN_SelectServerDirectory.Location = new Point(488, 118);
            BTN_SelectServerDirectory.Name = "BTN_SelectServerDirectory";
            BTN_SelectServerDirectory.ShadowDecoration.CustomizableEdges = customizableEdges8;
            BTN_SelectServerDirectory.Size = new Size(87, 42);
            BTN_SelectServerDirectory.TabIndex = 3;
            BTN_SelectServerDirectory.Text = "Select";
            BTN_SelectServerDirectory.Click += BTN_SelectServerDirectory_Click;
            // 
            // BTN_SelectServerImage
            // 
            BTN_SelectServerImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BTN_SelectServerImage.Animated = true;
            BTN_SelectServerImage.BackColor = Color.Transparent;
            BTN_SelectServerImage.BorderRadius = 10;
            BTN_SelectServerImage.Cursor = Cursors.Hand;
            BTN_SelectServerImage.CustomizableEdges = customizableEdges5;
            BTN_SelectServerImage.DisabledState.BorderColor = Color.DarkGray;
            BTN_SelectServerImage.DisabledState.CustomBorderColor = Color.DarkGray;
            BTN_SelectServerImage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BTN_SelectServerImage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BTN_SelectServerImage.FillColor = Color.Transparent;
            BTN_SelectServerImage.Font = new Font("Segoe UI", 9F);
            BTN_SelectServerImage.ForeColor = Color.White;
            BTN_SelectServerImage.HoverState.Image = Properties.Resources.open;
            BTN_SelectServerImage.ImageSize = new Size(40, 40);
            BTN_SelectServerImage.Location = new Point(628, 76);
            BTN_SelectServerImage.Name = "BTN_SelectServerImage";
            BTN_SelectServerImage.PressedDepth = 90;
            BTN_SelectServerImage.ShadowDecoration.CustomizableEdges = customizableEdges6;
            BTN_SelectServerImage.Size = new Size(80, 80);
            BTN_SelectServerImage.TabIndex = 4;
            BTN_SelectServerImage.UseTransparentBackground = true;
            BTN_SelectServerImage.Click += BTN_SelectServerImage_Click;
            // 
            // TBX_ServerLogo
            // 
            TBX_ServerLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TBX_ServerLogo.AutoSize = true;
            TBX_ServerLogo.Font = new Font("Lexend", 11.25F);
            TBX_ServerLogo.ForeColor = Color.FromArgb(235, 234, 234);
            TBX_ServerLogo.Location = new Point(620, 159);
            TBX_ServerLogo.Name = "TBX_ServerLogo";
            TBX_ServerLogo.Size = new Size(96, 24);
            TBX_ServerLogo.TabIndex = 0;
            TBX_ServerLogo.Text = "Server Icon";
            // 
            // BTN_AddServerFile
            // 
            BTN_AddServerFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BTN_AddServerFile.Animated = true;
            BTN_AddServerFile.AutoRoundedCorners = true;
            BTN_AddServerFile.BackColor = Color.Transparent;
            BTN_AddServerFile.BorderColor = Color.FromArgb(162, 123, 90);
            BTN_AddServerFile.BorderThickness = 2;
            BTN_AddServerFile.Cursor = Cursors.Hand;
            BTN_AddServerFile.CustomizableEdges = customizableEdges3;
            BTN_AddServerFile.DisabledState.BorderColor = Color.DarkGray;
            BTN_AddServerFile.DisabledState.CustomBorderColor = Color.DarkGray;
            BTN_AddServerFile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BTN_AddServerFile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BTN_AddServerFile.Enabled = false;
            BTN_AddServerFile.FillColor = Color.Empty;
            BTN_AddServerFile.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTN_AddServerFile.ForeColor = Color.FromArgb(162, 123, 90);
            BTN_AddServerFile.Location = new Point(372, 208);
            BTN_AddServerFile.Name = "BTN_AddServerFile";
            BTN_AddServerFile.ShadowDecoration.CustomizableEdges = customizableEdges4;
            BTN_AddServerFile.Size = new Size(203, 39);
            BTN_AddServerFile.TabIndex = 5;
            BTN_AddServerFile.Text = "Add Java file (*.jar)";
            BTN_AddServerFile.Click += BTN_AddServerFile_Click;
            // 
            // BTN_SaveSetup
            // 
            BTN_SaveSetup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BTN_SaveSetup.Animated = true;
            BTN_SaveSetup.AutoRoundedCorners = true;
            BTN_SaveSetup.BackColor = Color.Transparent;
            BTN_SaveSetup.BorderColor = Color.Empty;
            BTN_SaveSetup.Cursor = Cursors.Hand;
            BTN_SaveSetup.CustomizableEdges = customizableEdges1;
            BTN_SaveSetup.DisabledState.BorderColor = Color.DarkGray;
            BTN_SaveSetup.DisabledState.CustomBorderColor = Color.DarkGray;
            BTN_SaveSetup.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BTN_SaveSetup.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BTN_SaveSetup.FillColor = Color.FromArgb(162, 123, 90);
            BTN_SaveSetup.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTN_SaveSetup.ForeColor = Color.White;
            BTN_SaveSetup.Location = new Point(12, 208);
            BTN_SaveSetup.Name = "BTN_SaveSetup";
            BTN_SaveSetup.ShadowDecoration.CustomizableEdges = customizableEdges2;
            BTN_SaveSetup.Size = new Size(177, 39);
            BTN_SaveSetup.TabIndex = 6;
            BTN_SaveSetup.Text = "Save and exit setup";
            BTN_SaveSetup.Click += BTN_SaveSetup_Click;
            // 
            // PBX_ServerImage
            // 
            PBX_ServerImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PBX_ServerImage.BackColor = Color.Transparent;
            PBX_ServerImage.BorderRadius = 10;
            PBX_ServerImage.CustomizableEdges = customizableEdges15;
            PBX_ServerImage.FillColor = Color.Empty;
            PBX_ServerImage.Image = Properties.Resources.Default_Server_Image;
            PBX_ServerImage.ImageRotate = 0F;
            PBX_ServerImage.Location = new Point(628, 76);
            PBX_ServerImage.Name = "PBX_ServerImage";
            PBX_ServerImage.ShadowDecoration.CustomizableEdges = customizableEdges16;
            PBX_ServerImage.Size = new Size(80, 80);
            PBX_ServerImage.SizeMode = PictureBoxSizeMode.Zoom;
            PBX_ServerImage.TabIndex = 11;
            PBX_ServerImage.TabStop = false;
            PBX_ServerImage.UseTransparentBackground = true;
            // 
            // VSP_1
            // 
            VSP_1.FillColor = Color.FromArgb(58, 55, 55);
            VSP_1.FillStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            VSP_1.FillThickness = 2;
            VSP_1.Location = new Point(595, 13);
            VSP_1.Name = "VSP_1";
            VSP_1.Size = new Size(10, 233);
            VSP_1.TabIndex = 12;
            // 
            // FRM_Setup
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(38, 34, 34);
            ClientSize = new Size(728, 259);
            Controls.Add(VSP_1);
            Controls.Add(BTN_SaveSetup);
            Controls.Add(BTN_AddServerFile);
            Controls.Add(BTN_SelectServerImage);
            Controls.Add(BTN_SelectServerDirectory);
            Controls.Add(TBX_ServerDirectory);
            Controls.Add(TBX_ServerAddress);
            Controls.Add(TBX_ServerName);
            Controls.Add(TBX_ServerLogo);
            Controls.Add(LBL_ServerDirectory);
            Controls.Add(LBL_ServerIP);
            Controls.Add(LBL_ServerName);
            Controls.Add(PBX_ServerImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FRM_Setup";
            Text = "MCA Console Setup";
            Load += FRM_Setup_Load;
            ((System.ComponentModel.ISupportInitialize)ERP_Main).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBX_ServerImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LBL_ServerName;
        private ErrorProvider ERP_Main;
        private Label LBL_ServerIP;
        private Label LBL_ServerDirectory;
        private Guna.UI2.WinForms.Guna2TextBox TBX_ServerName;
        private Guna.UI2.WinForms.Guna2TextBox TBX_ServerAddress;
        private Guna.UI2.WinForms.Guna2TextBox TBX_ServerDirectory;
        private Guna.UI2.WinForms.Guna2Button BTN_SelectServerDirectory;
        private Guna.UI2.WinForms.Guna2Button BTN_SelectServerImage;
        private Label TBX_ServerLogo;
        private Guna.UI2.WinForms.Guna2Button BTN_SaveSetup;
        private Guna.UI2.WinForms.Guna2Button BTN_AddServerFile;
        private Guna.UI2.WinForms.Guna2PictureBox PBX_ServerImage;
        private Guna.UI2.WinForms.Guna2VSeparator VSP_1;
    }
}