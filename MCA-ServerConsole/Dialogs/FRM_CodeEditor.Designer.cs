namespace MCA_ServerConsole.Dialogs
{
    partial class FRM_CodeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CodeEditor));
            PNL_Fill = new Panel();
            HSB_1 = new Guna.UI2.WinForms.Guna2HScrollBar();
            PNL_Bottom = new Panel();
            BTN_SaveFile = new Guna.UI2.WinForms.Guna2Button();
            PNL_Fill.SuspendLayout();
            PNL_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // PNL_Fill
            // 
            PNL_Fill.BorderStyle = BorderStyle.FixedSingle;
            PNL_Fill.Controls.Add(HSB_1);
            PNL_Fill.Dock = DockStyle.Fill;
            PNL_Fill.Location = new Point(0, 0);
            PNL_Fill.Name = "PNL_Fill";
            PNL_Fill.Size = new Size(800, 390);
            PNL_Fill.TabIndex = 0;
            // 
            // HSB_1
            // 
            HSB_1.BackColor = Color.FromArgb(38, 34, 34);
            HSB_1.BorderRadius = 4;
            HSB_1.Dock = DockStyle.Bottom;
            HSB_1.FillColor = Color.FromArgb(58, 55, 55);
            HSB_1.HighlightOnWheel = true;
            HSB_1.InUpdate = false;
            HSB_1.LargeChange = 10;
            HSB_1.Location = new Point(0, 370);
            HSB_1.Name = "HSB_1";
            HSB_1.ScrollbarSize = 18;
            HSB_1.Size = new Size(798, 18);
            HSB_1.TabIndex = 0;
            HSB_1.ThumbColor = Color.FromArgb(80, 76, 76);
            HSB_1.ThumbStyle = Guna.UI2.WinForms.Enums.ThumbStyle.Inset;
            HSB_1.Scroll += HSB_1_Scroll;
            // 
            // PNL_Bottom
            // 
            PNL_Bottom.Controls.Add(BTN_SaveFile);
            PNL_Bottom.Dock = DockStyle.Bottom;
            PNL_Bottom.Location = new Point(0, 390);
            PNL_Bottom.Name = "PNL_Bottom";
            PNL_Bottom.Size = new Size(800, 60);
            PNL_Bottom.TabIndex = 1;
            // 
            // BTN_SaveFile
            // 
            BTN_SaveFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTN_SaveFile.Animated = true;
            BTN_SaveFile.AutoRoundedCorners = true;
            BTN_SaveFile.BackColor = Color.Transparent;
            BTN_SaveFile.BorderColor = Color.Empty;
            BTN_SaveFile.Cursor = Cursors.Hand;
            BTN_SaveFile.CustomizableEdges = customizableEdges1;
            BTN_SaveFile.DialogResult = DialogResult.OK;
            BTN_SaveFile.DisabledState.BorderColor = Color.DarkGray;
            BTN_SaveFile.DisabledState.CustomBorderColor = Color.DarkGray;
            BTN_SaveFile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BTN_SaveFile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BTN_SaveFile.FillColor = Color.FromArgb(162, 123, 90);
            BTN_SaveFile.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTN_SaveFile.ForeColor = Color.White;
            BTN_SaveFile.Location = new Point(10, 10);
            BTN_SaveFile.Margin = new Padding(10);
            BTN_SaveFile.Name = "BTN_SaveFile";
            BTN_SaveFile.ShadowDecoration.CustomizableEdges = customizableEdges2;
            BTN_SaveFile.Size = new Size(780, 40);
            BTN_SaveFile.TabIndex = 8;
            BTN_SaveFile.Text = "Save";
            BTN_SaveFile.Click += BTN_SaveFile_Click;
            // 
            // FRM_CodeEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 34, 34);
            ClientSize = new Size(800, 450);
            Controls.Add(PNL_Fill);
            Controls.Add(PNL_Bottom);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "FRM_CodeEditor";
            Text = "MCA Console Code Editor";
            FormClosing += FRM_CodeEditor_FormClosing;
            PNL_Fill.ResumeLayout(false);
            PNL_Bottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PNL_Fill;
        private Panel PNL_Bottom;
        private Guna.UI2.WinForms.Guna2Button BTN_SaveFile;
        private Guna.UI2.WinForms.Guna2HScrollBar HSB_1;
    }
}