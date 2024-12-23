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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Setup));
            LBL_ServerName = new Label();
            TBX_ServerName = new TextBox();
            ERP_Main = new ErrorProvider(components);
            LBL_ServerIP = new Label();
            TBX_ServerAddress = new TextBox();
            LBL_ServerDirectory = new Label();
            TBX_ServerDirectory = new TextBox();
            BTN_SelectServerDirectory = new Button();
            PBX_ServerImage = new PictureBox();
            BTX_SelectServerImage = new Button();
            BTN_SaveSetup = new Button();
            BTN_AddServerFile = new Button();
            ((System.ComponentModel.ISupportInitialize)ERP_Main).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBX_ServerImage).BeginInit();
            SuspendLayout();
            // 
            // LBL_ServerName
            // 
            LBL_ServerName.AutoSize = true;
            LBL_ServerName.Location = new Point(12, 15);
            LBL_ServerName.Name = "LBL_ServerName";
            LBL_ServerName.Size = new Size(72, 15);
            LBL_ServerName.TabIndex = 0;
            LBL_ServerName.Text = "Server name";
            // 
            // TBX_ServerName
            // 
            TBX_ServerName.Location = new Point(101, 12);
            TBX_ServerName.MaxLength = 30;
            TBX_ServerName.Name = "TBX_ServerName";
            TBX_ServerName.PlaceholderText = "MyServer";
            TBX_ServerName.Size = new Size(197, 23);
            TBX_ServerName.TabIndex = 0;
            TBX_ServerName.WordWrap = false;
            // 
            // ERP_Main
            // 
            ERP_Main.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ERP_Main.ContainerControl = this;
            // 
            // LBL_ServerIP
            // 
            LBL_ServerIP.AutoSize = true;
            LBL_ServerIP.Location = new Point(12, 44);
            LBL_ServerIP.Name = "LBL_ServerIP";
            LBL_ServerIP.Size = new Size(82, 15);
            LBL_ServerIP.TabIndex = 0;
            LBL_ServerIP.Text = "Server address";
            // 
            // TBX_ServerAddress
            // 
            TBX_ServerAddress.Location = new Point(101, 41);
            TBX_ServerAddress.MaxLength = 15;
            TBX_ServerAddress.Name = "TBX_ServerAddress";
            TBX_ServerAddress.PlaceholderText = "127.0.0.1";
            TBX_ServerAddress.Size = new Size(114, 23);
            TBX_ServerAddress.TabIndex = 1;
            TBX_ServerAddress.WordWrap = false;
            // 
            // LBL_ServerDirectory
            // 
            LBL_ServerDirectory.AutoSize = true;
            LBL_ServerDirectory.Location = new Point(12, 73);
            LBL_ServerDirectory.Name = "LBL_ServerDirectory";
            LBL_ServerDirectory.Size = new Size(81, 15);
            LBL_ServerDirectory.TabIndex = 0;
            LBL_ServerDirectory.Text = "Server storage";
            // 
            // TBX_ServerDirectory
            // 
            TBX_ServerDirectory.Location = new Point(101, 70);
            TBX_ServerDirectory.Name = "TBX_ServerDirectory";
            TBX_ServerDirectory.Size = new Size(197, 23);
            TBX_ServerDirectory.TabIndex = 2;
            TBX_ServerDirectory.WordWrap = false;
            // 
            // BTN_SelectServerDirectory
            // 
            BTN_SelectServerDirectory.Location = new Point(304, 69);
            BTN_SelectServerDirectory.Name = "BTN_SelectServerDirectory";
            BTN_SelectServerDirectory.Size = new Size(25, 25);
            BTN_SelectServerDirectory.TabIndex = 3;
            BTN_SelectServerDirectory.Text = "...";
            BTN_SelectServerDirectory.UseVisualStyleBackColor = true;
            BTN_SelectServerDirectory.Click += BTN_SelectServerDirectory_Click;
            // 
            // PBX_ServerImage
            // 
            PBX_ServerImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PBX_ServerImage.Image = Properties.Resources.Default_Server_Image;
            PBX_ServerImage.Location = new Point(361, 12);
            PBX_ServerImage.Name = "PBX_ServerImage";
            PBX_ServerImage.Size = new Size(80, 80);
            PBX_ServerImage.SizeMode = PictureBoxSizeMode.Zoom;
            PBX_ServerImage.TabIndex = 4;
            PBX_ServerImage.TabStop = false;
            // 
            // BTX_SelectServerImage
            // 
            BTX_SelectServerImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BTX_SelectServerImage.Location = new Point(361, 98);
            BTX_SelectServerImage.Name = "BTX_SelectServerImage";
            BTX_SelectServerImage.Size = new Size(80, 25);
            BTX_SelectServerImage.TabIndex = 4;
            BTX_SelectServerImage.Text = "Select";
            BTX_SelectServerImage.UseVisualStyleBackColor = true;
            BTX_SelectServerImage.Click += BTX_SelectServerImage_Click;
            // 
            // BTN_SaveSetup
            // 
            BTN_SaveSetup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTN_SaveSetup.Location = new Point(12, 206);
            BTN_SaveSetup.Name = "BTN_SaveSetup";
            BTN_SaveSetup.Size = new Size(431, 25);
            BTN_SaveSetup.TabIndex = 5;
            BTN_SaveSetup.Text = "Save";
            BTN_SaveSetup.UseVisualStyleBackColor = true;
            BTN_SaveSetup.Click += BTN_SaveSetup_Click;
            // 
            // BTN_AddServerFile
            // 
            BTN_AddServerFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTN_AddServerFile.Location = new Point(12, 175);
            BTN_AddServerFile.Name = "BTN_AddServerFile";
            BTN_AddServerFile.Size = new Size(431, 25);
            BTN_AddServerFile.TabIndex = 5;
            BTN_AddServerFile.Text = "Add java file (*.jar)";
            BTN_AddServerFile.UseVisualStyleBackColor = true;
            BTN_AddServerFile.Click += BTN_AddServerFile_Click;
            // 
            // FRM_Setup
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(455, 243);
            Controls.Add(PBX_ServerImage);
            Controls.Add(BTN_AddServerFile);
            Controls.Add(BTN_SaveSetup);
            Controls.Add(BTX_SelectServerImage);
            Controls.Add(BTN_SelectServerDirectory);
            Controls.Add(TBX_ServerDirectory);
            Controls.Add(LBL_ServerDirectory);
            Controls.Add(TBX_ServerAddress);
            Controls.Add(LBL_ServerIP);
            Controls.Add(TBX_ServerName);
            Controls.Add(LBL_ServerName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRM_Setup";
            Text = "Minecraft Advanced Server Console :: Setup";
            Load += FRM_Setup_Load;
            ((System.ComponentModel.ISupportInitialize)ERP_Main).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBX_ServerImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LBL_ServerName;
        private TextBox TBX_ServerName;
        private ErrorProvider ERP_Main;
        private TextBox TBX_ServerAddress;
        private Label LBL_ServerIP;
        private TextBox TBX_ServerDirectory;
        private Label LBL_ServerDirectory;
        private Button BTN_SelectServerDirectory;
        private PictureBox PBX_ServerImage;
        private Button BTX_SelectServerImage;
        private Button BTN_SaveSetup;
        private Button BTN_AddServerFile;
    }
}