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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CodeEditor));
            PNL_Fill = new Panel();
            PNL_Bottom = new Panel();
            BTN_SaveFile = new Button();
            PNL_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // PNL_Fill
            // 
            PNL_Fill.Dock = DockStyle.Fill;
            PNL_Fill.Location = new Point(0, 0);
            PNL_Fill.Name = "PNL_Fill";
            PNL_Fill.Size = new Size(800, 411);
            PNL_Fill.TabIndex = 0;
            // 
            // PNL_Bottom
            // 
            PNL_Bottom.Controls.Add(BTN_SaveFile);
            PNL_Bottom.Dock = DockStyle.Bottom;
            PNL_Bottom.Location = new Point(0, 411);
            PNL_Bottom.Name = "PNL_Bottom";
            PNL_Bottom.Size = new Size(800, 39);
            PNL_Bottom.TabIndex = 1;
            // 
            // BTN_SaveFile
            // 
            BTN_SaveFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTN_SaveFile.Location = new Point(12, 8);
            BTN_SaveFile.Name = "BTN_SaveFile";
            BTN_SaveFile.Size = new Size(776, 23);
            BTN_SaveFile.TabIndex = 0;
            BTN_SaveFile.Text = "Save";
            BTN_SaveFile.UseVisualStyleBackColor = true;
            BTN_SaveFile.Click += BTN_SaveFile_Click;
            // 
            // FRM_CodeEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PNL_Fill);
            Controls.Add(PNL_Bottom);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRM_CodeEditor";
            Text = "Minecraft Advanced Server Console :: Code Editor";
            FormClosing += FRM_CodeEditor_FormClosing;
            PNL_Bottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PNL_Fill;
        private Panel PNL_Bottom;
        private Button BTN_SaveFile;
    }
}