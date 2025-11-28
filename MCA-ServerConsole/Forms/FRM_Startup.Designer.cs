namespace MCA_ServerConsole
{
    partial class FRM_Startup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Startup));
            PGB_Loading = new Guna.UI2.WinForms.Guna2ProgressBar();
            SuspendLayout();
            // 
            // PGB_Loading
            // 
            PGB_Loading.AutoRoundedCorners = true;
            PGB_Loading.CustomizableEdges = customizableEdges1;
            PGB_Loading.FillColor = Color.FromArgb(58, 55, 55);
            PGB_Loading.Location = new Point(12, 21);
            PGB_Loading.Name = "PGB_Loading";
            PGB_Loading.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            PGB_Loading.ProgressColor = Color.FromArgb(162, 123, 90);
            PGB_Loading.ProgressColor2 = Color.FromArgb(162, 123, 90);
            PGB_Loading.ShadowDecoration.CustomizableEdges = customizableEdges2;
            PGB_Loading.Size = new Size(379, 23);
            PGB_Loading.TabIndex = 1;
            PGB_Loading.Text = "guna2ProgressBar1";
            PGB_Loading.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // FRM_Startup
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(38, 34, 34);
            ClientSize = new Size(403, 64);
            Controls.Add(PGB_Loading);
            Cursor = Cursors.WaitCursor;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FRM_Startup";
            Text = "MCA Console startup";
            Load += FRM_Startup_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ProgressBar PGB_Loading;
    }
}
