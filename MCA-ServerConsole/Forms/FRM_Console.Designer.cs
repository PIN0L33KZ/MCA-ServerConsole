﻿namespace MCA_ServerConsole.Forms
{
    partial class FRM_Console
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Console));
            PNL_Top = new Panel();
            LBL_JarFile = new Label();
            CBX_JarFile = new ComboBox();
            PBX_ServerImage = new PictureBox();
            LBL_ServerName = new Label();
            TRV_Directory = new TreeView();
            CMS_TRV_Directory = new ContextMenuStrip(components);
            TMI_EditFile = new ToolStripMenuItem();
            TMI_SEP1 = new ToolStripSeparator();
            TMI_DeleteFile = new ToolStripMenuItem();
            IGL_TRV_Directory = new ImageList(components);
            PNL_Left = new Panel();
            PNL_Fill = new Panel();
            PNL_Fill_Fill = new Panel();
            RTB_ServerLog = new RichTextBox();
            PNL_Fill_Bottom = new Panel();
            BTN_SendCommand = new Button();
            TBX_CommandText = new TextBox();
            TSP_StatusBar = new ToolStrip();
            TSL_ServerStatus = new ToolStripLabel();
            TSL_GameVersion = new ToolStripLabel();
            TSL_PortStatus = new ToolStripLabel();
            TSL_DefaultGamemode = new ToolStripLabel();
            PNL_Fill_Top = new Panel();
            BTN_StopServer = new Button();
            BTN_ReloadServer = new Button();
            BTN_StartServer = new Button();
            PNL_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBX_ServerImage).BeginInit();
            CMS_TRV_Directory.SuspendLayout();
            PNL_Left.SuspendLayout();
            PNL_Fill.SuspendLayout();
            PNL_Fill_Fill.SuspendLayout();
            PNL_Fill_Bottom.SuspendLayout();
            TSP_StatusBar.SuspendLayout();
            PNL_Fill_Top.SuspendLayout();
            SuspendLayout();
            // 
            // PNL_Top
            // 
            PNL_Top.Controls.Add(LBL_JarFile);
            PNL_Top.Controls.Add(CBX_JarFile);
            PNL_Top.Controls.Add(PBX_ServerImage);
            PNL_Top.Controls.Add(LBL_ServerName);
            PNL_Top.Dock = DockStyle.Top;
            PNL_Top.Location = new Point(0, 0);
            PNL_Top.Name = "PNL_Top";
            PNL_Top.Size = new Size(1010, 45);
            PNL_Top.TabIndex = 0;
            // 
            // LBL_JarFile
            // 
            LBL_JarFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LBL_JarFile.AutoSize = true;
            LBL_JarFile.Location = new Point(797, 14);
            LBL_JarFile.Name = "LBL_JarFile";
            LBL_JarFile.Size = new Size(74, 15);
            LBL_JarFile.TabIndex = 4;
            LBL_JarFile.Text = "Server jar file";
            // 
            // CBX_JarFile
            // 
            CBX_JarFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CBX_JarFile.Cursor = Cursors.Hand;
            CBX_JarFile.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_JarFile.FormattingEnabled = true;
            CBX_JarFile.Location = new Point(877, 11);
            CBX_JarFile.Name = "CBX_JarFile";
            CBX_JarFile.Size = new Size(121, 23);
            CBX_JarFile.TabIndex = 3;
            // 
            // PBX_ServerImage
            // 
            PBX_ServerImage.Dock = DockStyle.Left;
            PBX_ServerImage.Location = new Point(0, 0);
            PBX_ServerImage.Name = "PBX_ServerImage";
            PBX_ServerImage.Size = new Size(45, 45);
            PBX_ServerImage.SizeMode = PictureBoxSizeMode.Zoom;
            PBX_ServerImage.TabIndex = 2;
            PBX_ServerImage.TabStop = false;
            // 
            // LBL_ServerName
            // 
            LBL_ServerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LBL_ServerName.AutoEllipsis = true;
            LBL_ServerName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LBL_ServerName.Location = new Point(51, 11);
            LBL_ServerName.Name = "LBL_ServerName";
            LBL_ServerName.Size = new Size(740, 23);
            LBL_ServerName.TabIndex = 0;
            LBL_ServerName.Text = "Server: {name}";
            // 
            // TRV_Directory
            // 
            TRV_Directory.ContextMenuStrip = CMS_TRV_Directory;
            TRV_Directory.Dock = DockStyle.Fill;
            TRV_Directory.ImageIndex = 0;
            TRV_Directory.ImageList = IGL_TRV_Directory;
            TRV_Directory.Location = new Point(0, 5);
            TRV_Directory.Name = "TRV_Directory";
            TRV_Directory.SelectedImageIndex = 0;
            TRV_Directory.Size = new Size(286, 451);
            TRV_Directory.TabIndex = 2;
            TRV_Directory.NodeMouseClick += TRV_Directory_NodeMouseClick;
            TRV_Directory.NodeMouseDoubleClick += TRV_Directory_NodeMouseDoubleClick;
            // 
            // CMS_TRV_Directory
            // 
            CMS_TRV_Directory.Items.AddRange(new ToolStripItem[] { TMI_EditFile, TMI_SEP1, TMI_DeleteFile });
            CMS_TRV_Directory.Name = "CMS_TRV_Directory";
            CMS_TRV_Directory.Size = new Size(125, 54);
            // 
            // TMI_EditFile
            // 
            TMI_EditFile.Image = Properties.Resources.edit;
            TMI_EditFile.Name = "TMI_EditFile";
            TMI_EditFile.Size = new Size(124, 22);
            TMI_EditFile.Text = "View/Edit";
            TMI_EditFile.Click += TMI_EditFile_Click;
            // 
            // TMI_SEP1
            // 
            TMI_SEP1.Name = "TMI_SEP1";
            TMI_SEP1.Size = new Size(121, 6);
            // 
            // TMI_DeleteFile
            // 
            TMI_DeleteFile.Image = Properties.Resources.delete;
            TMI_DeleteFile.Name = "TMI_DeleteFile";
            TMI_DeleteFile.Size = new Size(124, 22);
            TMI_DeleteFile.Text = "Delete";
            TMI_DeleteFile.Click += TMI_DeleteFile_Click;
            // 
            // IGL_TRV_Directory
            // 
            IGL_TRV_Directory.ColorDepth = ColorDepth.Depth32Bit;
            IGL_TRV_Directory.ImageStream = (ImageListStreamer)resources.GetObject("IGL_TRV_Directory.ImageStream");
            IGL_TRV_Directory.TransparentColor = Color.Transparent;
            IGL_TRV_Directory.Images.SetKeyName(0, "rootFolder");
            IGL_TRV_Directory.Images.SetKeyName(1, "folder");
            IGL_TRV_Directory.Images.SetKeyName(2, "file");
            IGL_TRV_Directory.Images.SetKeyName(3, "javaFile");
            // 
            // PNL_Left
            // 
            PNL_Left.Controls.Add(TRV_Directory);
            PNL_Left.Dock = DockStyle.Left;
            PNL_Left.Location = new Point(0, 45);
            PNL_Left.Name = "PNL_Left";
            PNL_Left.Padding = new Padding(0, 5, 0, 0);
            PNL_Left.Size = new Size(286, 456);
            PNL_Left.TabIndex = 1;
            // 
            // PNL_Fill
            // 
            PNL_Fill.Controls.Add(PNL_Fill_Fill);
            PNL_Fill.Controls.Add(PNL_Fill_Bottom);
            PNL_Fill.Controls.Add(PNL_Fill_Top);
            PNL_Fill.Dock = DockStyle.Fill;
            PNL_Fill.Location = new Point(286, 45);
            PNL_Fill.Name = "PNL_Fill";
            PNL_Fill.Size = new Size(724, 456);
            PNL_Fill.TabIndex = 2;
            // 
            // PNL_Fill_Fill
            // 
            PNL_Fill_Fill.Controls.Add(RTB_ServerLog);
            PNL_Fill_Fill.Dock = DockStyle.Fill;
            PNL_Fill_Fill.Location = new Point(0, 45);
            PNL_Fill_Fill.Name = "PNL_Fill_Fill";
            PNL_Fill_Fill.Padding = new Padding(5);
            PNL_Fill_Fill.Size = new Size(724, 340);
            PNL_Fill_Fill.TabIndex = 3;
            // 
            // RTB_ServerLog
            // 
            RTB_ServerLog.BorderStyle = BorderStyle.FixedSingle;
            RTB_ServerLog.Dock = DockStyle.Fill;
            RTB_ServerLog.HideSelection = false;
            RTB_ServerLog.Location = new Point(5, 5);
            RTB_ServerLog.Name = "RTB_ServerLog";
            RTB_ServerLog.ReadOnly = true;
            RTB_ServerLog.Size = new Size(714, 330);
            RTB_ServerLog.TabIndex = 1;
            RTB_ServerLog.Text = "";
            RTB_ServerLog.TextChanged += RTB_ServerLog_TextChanged;
            // 
            // PNL_Fill_Bottom
            // 
            PNL_Fill_Bottom.Controls.Add(BTN_SendCommand);
            PNL_Fill_Bottom.Controls.Add(TBX_CommandText);
            PNL_Fill_Bottom.Controls.Add(TSP_StatusBar);
            PNL_Fill_Bottom.Dock = DockStyle.Bottom;
            PNL_Fill_Bottom.Location = new Point(0, 385);
            PNL_Fill_Bottom.Name = "PNL_Fill_Bottom";
            PNL_Fill_Bottom.Size = new Size(724, 71);
            PNL_Fill_Bottom.TabIndex = 2;
            // 
            // BTN_SendCommand
            // 
            BTN_SendCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BTN_SendCommand.Cursor = Cursors.Hand;
            BTN_SendCommand.Enabled = false;
            BTN_SendCommand.Location = new Point(632, 12);
            BTN_SendCommand.Name = "BTN_SendCommand";
            BTN_SendCommand.Size = new Size(83, 23);
            BTN_SendCommand.TabIndex = 2;
            BTN_SendCommand.Text = "Send";
            BTN_SendCommand.UseVisualStyleBackColor = true;
            BTN_SendCommand.Click += BTN_SendCommand_Click;
            // 
            // TBX_CommandText
            // 
            TBX_CommandText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBX_CommandText.Enabled = false;
            TBX_CommandText.Location = new Point(9, 12);
            TBX_CommandText.Name = "TBX_CommandText";
            TBX_CommandText.Size = new Size(617, 23);
            TBX_CommandText.TabIndex = 1;
            TBX_CommandText.KeyDown += TBX_CommandText_KeyDown;
            // 
            // TSP_StatusBar
            // 
            TSP_StatusBar.Dock = DockStyle.Bottom;
            TSP_StatusBar.GripStyle = ToolStripGripStyle.Hidden;
            TSP_StatusBar.Items.AddRange(new ToolStripItem[] { TSL_ServerStatus, TSL_GameVersion, TSL_PortStatus, TSL_DefaultGamemode });
            TSP_StatusBar.Location = new Point(0, 46);
            TSP_StatusBar.Name = "TSP_StatusBar";
            TSP_StatusBar.Size = new Size(724, 25);
            TSP_StatusBar.TabIndex = 0;
            // 
            // TSL_ServerStatus
            // 
            TSL_ServerStatus.Image = Properties.Resources.stopped;
            TSL_ServerStatus.Name = "TSL_ServerStatus";
            TSL_ServerStatus.Size = new Size(101, 22);
            TSL_ServerStatus.Text = "Server stopped";
            // 
            // TSL_GameVersion
            // 
            TSL_GameVersion.Name = "TSL_GameVersion";
            TSL_GameVersion.Size = new Size(0, 22);
            // 
            // TSL_PortStatus
            // 
            TSL_PortStatus.Name = "TSL_PortStatus";
            TSL_PortStatus.Size = new Size(0, 22);
            // 
            // TSL_DefaultGamemode
            // 
            TSL_DefaultGamemode.Name = "TSL_DefaultGamemode";
            TSL_DefaultGamemode.Size = new Size(0, 22);
            // 
            // PNL_Fill_Top
            // 
            PNL_Fill_Top.Controls.Add(BTN_StopServer);
            PNL_Fill_Top.Controls.Add(BTN_ReloadServer);
            PNL_Fill_Top.Controls.Add(BTN_StartServer);
            PNL_Fill_Top.Dock = DockStyle.Top;
            PNL_Fill_Top.Location = new Point(0, 0);
            PNL_Fill_Top.Name = "PNL_Fill_Top";
            PNL_Fill_Top.Size = new Size(724, 45);
            PNL_Fill_Top.TabIndex = 0;
            // 
            // BTN_StopServer
            // 
            BTN_StopServer.Anchor = AnchorStyles.Top;
            BTN_StopServer.Cursor = Cursors.Hand;
            BTN_StopServer.Enabled = false;
            BTN_StopServer.Location = new Point(410, 11);
            BTN_StopServer.Name = "BTN_StopServer";
            BTN_StopServer.Size = new Size(83, 23);
            BTN_StopServer.TabIndex = 0;
            BTN_StopServer.Text = "Stop Server";
            BTN_StopServer.UseVisualStyleBackColor = true;
            BTN_StopServer.Click += BTN_StopServer_Click;
            // 
            // BTN_ReloadServer
            // 
            BTN_ReloadServer.Anchor = AnchorStyles.Top;
            BTN_ReloadServer.Cursor = Cursors.Hand;
            BTN_ReloadServer.Enabled = false;
            BTN_ReloadServer.Location = new Point(321, 11);
            BTN_ReloadServer.Name = "BTN_ReloadServer";
            BTN_ReloadServer.Size = new Size(83, 23);
            BTN_ReloadServer.TabIndex = 0;
            BTN_ReloadServer.Text = "Reload Server";
            BTN_ReloadServer.UseVisualStyleBackColor = true;
            BTN_ReloadServer.Click += BTN_ReloadServer_Click;
            // 
            // BTN_StartServer
            // 
            BTN_StartServer.Anchor = AnchorStyles.Top;
            BTN_StartServer.Cursor = Cursors.Hand;
            BTN_StartServer.Location = new Point(232, 11);
            BTN_StartServer.Name = "BTN_StartServer";
            BTN_StartServer.Size = new Size(83, 23);
            BTN_StartServer.TabIndex = 0;
            BTN_StartServer.Text = "Start Server";
            BTN_StartServer.UseVisualStyleBackColor = true;
            BTN_StartServer.Click += BTN_StartServer_Click;
            // 
            // FRM_Console
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1010, 501);
            Controls.Add(PNL_Fill);
            Controls.Add(PNL_Left);
            Controls.Add(PNL_Top);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(737, 383);
            Name = "FRM_Console";
            Text = "Minecraft Advanced Server Console :: Console";
            FormClosing += FRM_Console_FormClosing;
            PNL_Top.ResumeLayout(false);
            PNL_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBX_ServerImage).EndInit();
            CMS_TRV_Directory.ResumeLayout(false);
            PNL_Left.ResumeLayout(false);
            PNL_Fill.ResumeLayout(false);
            PNL_Fill_Fill.ResumeLayout(false);
            PNL_Fill_Bottom.ResumeLayout(false);
            PNL_Fill_Bottom.PerformLayout();
            TSP_StatusBar.ResumeLayout(false);
            TSP_StatusBar.PerformLayout();
            PNL_Fill_Top.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PNL_Top;
        private Label LBL_ServerName;
        private TreeView TRV_Directory;
        private PictureBox PBX_ServerImage;
        private ComboBox CBX_JarFile;
        private Label LBL_JarFile;
        private ImageList IGL_TRV_Directory;
        private Panel PNL_Left;
        private Panel PNL_Fill;
        private Panel PNL_Fill_Top;
        private Button BTN_StartServer;
        private Button BTN_StopServer;
        private Button BTN_ReloadServer;
        private Panel PNL_Fill_Bottom;
        private RichTextBox RTB_ServerLog;
        private Panel PNL_Fill_Fill;
        private ToolStrip TSP_StatusBar;
        private ToolStripLabel TSL_ServerStatus;
        private ToolStripLabel TSL_GameVersion;
        private ToolStripLabel TSL_PortStatus;
        private ToolStripLabel TSL_DefaultGamemode;
        private TextBox TBX_CommandText;
        private Button BTN_SendCommand;
        private ContextMenuStrip CMS_TRV_Directory;
        private ToolStripMenuItem TMI_DeleteFile;
        private ToolStripMenuItem TMI_EditFile;
        private ToolStripSeparator TMI_SEP1;
    }
}