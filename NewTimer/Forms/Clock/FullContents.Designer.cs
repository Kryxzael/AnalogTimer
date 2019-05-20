namespace NewTimer.Forms.Clock
{
    partial class FullContents
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clock1 = new NewTimer.Forms.Clock.ClockControl();
            this.SuspendLayout();
            // 
            // clock1
            // 
            this.clock1.Location = new System.Drawing.Point(24, 0);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(250, 250);
            this.clock1.TabIndex = 0;
            // 
            // FullContents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clock1);
            this.Name = "FullContents";
            this.Size = new System.Drawing.Size(312, 251);
            this.ResumeLayout(false);

        }

        #endregion

        private ClockControl clock1;
    }
}
