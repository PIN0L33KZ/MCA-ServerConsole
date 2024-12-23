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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Startup));
            PGB_Loading = new ProgressBar();
            SuspendLayout();
            // 
            // PGB_Loading
            // 
            PGB_Loading.Location = new Point(12, 21);
            PGB_Loading.MarqueeAnimationSpeed = 50;
            PGB_Loading.Name = "PGB_Loading";
            PGB_Loading.Size = new Size(379, 23);
            PGB_Loading.Style = ProgressBarStyle.Marquee;
            PGB_Loading.TabIndex = 0;
            PGB_Loading.UseWaitCursor = true;
            PGB_Loading.Value = 10;
            // 
            // FRM_Startup
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(403, 64);
            Controls.Add(PGB_Loading);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FRM_Startup";
            Text = "Minecraft Advanced Server Console :: Loading";
            Load += FRM_Startup_Load;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar PGB_Loading;
    }
}
