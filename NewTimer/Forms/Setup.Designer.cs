namespace NewTimer.Forms
{
    partial class Setup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.tabDuration = new System.Windows.Forms.TabPage();
            this.flwTimeSuggestionsDuration = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadDuration = new System.Windows.Forms.Button();
            this.btnSaveDuration = new System.Windows.Forms.Button();
            this.btnStartDuration = new System.Windows.Forms.Button();
            this.tabTime = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl24h1 = new System.Windows.Forms.Label();
            this.chk24h = new System.Windows.Forms.CheckBox();
            this.flwTimeSuggestions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadCountdown = new System.Windows.Forms.Button();
            this.btnSaveCountdown = new System.Windows.Forms.Button();
            this.btnStartTime = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.chkAdv = new System.Windows.Forms.CheckBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.cboxColors = new NewTimer.FormParts.ColorSchemeComboBox();
            this.knbMonth = new NewTimer.FormParts.Setup.Knob();
            this.knbDay = new NewTimer.FormParts.Setup.Knob();
            this.knbSec = new NewTimer.FormParts.Setup.KnobDual();
            this.knbMin = new NewTimer.FormParts.Setup.KnobDual();
            this.knbHour = new NewTimer.FormParts.Setup.KnobHour();
            this.knbDurSec = new NewTimer.FormParts.Setup.KnobDual();
            this.knbDurMin = new NewTimer.FormParts.Setup.KnobDual();
            this.knbDurHour = new NewTimer.FormParts.Setup.Knob();
            this.tabDuration.SuspendLayout();
            this.tabTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDuration
            // 
            this.tabDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabDuration.Controls.Add(this.flwTimeSuggestionsDuration);
            this.tabDuration.Controls.Add(this.btnLoadDuration);
            this.tabDuration.Controls.Add(this.btnSaveDuration);
            this.tabDuration.Controls.Add(this.btnStartDuration);
            this.tabDuration.Controls.Add(this.knbDurSec);
            this.tabDuration.Controls.Add(this.knbDurMin);
            this.tabDuration.Controls.Add(this.knbDurHour);
            this.tabDuration.Location = new System.Drawing.Point(4, 22);
            this.tabDuration.Name = "tabDuration";
            this.tabDuration.Padding = new System.Windows.Forms.Padding(3);
            this.tabDuration.Size = new System.Drawing.Size(396, 289);
            this.tabDuration.TabIndex = 1;
            this.tabDuration.Text = "Duration";
            // 
            // flwTimeSuggestionsDuration
            // 
            this.flwTimeSuggestionsDuration.Location = new System.Drawing.Point(0, 257);
            this.flwTimeSuggestionsDuration.Margin = new System.Windows.Forms.Padding(0);
            this.flwTimeSuggestionsDuration.Name = "flwTimeSuggestionsDuration";
            this.flwTimeSuggestionsDuration.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.flwTimeSuggestionsDuration.Size = new System.Drawing.Size(396, 31);
            this.flwTimeSuggestionsDuration.TabIndex = 14;
            this.flwTimeSuggestionsDuration.WrapContents = false;
            // 
            // btnLoadDuration
            // 
            this.btnLoadDuration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadDuration.Location = new System.Drawing.Point(354, 174);
            this.btnLoadDuration.Name = "btnLoadDuration";
            this.btnLoadDuration.Size = new System.Drawing.Size(34, 32);
            this.btnLoadDuration.TabIndex = 13;
            this.btnLoadDuration.Text = "L";
            this.btnLoadDuration.UseVisualStyleBackColor = true;
            this.btnLoadDuration.Click += new System.EventHandler(this.OnClickLoad);
            // 
            // btnSaveDuration
            // 
            this.btnSaveDuration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveDuration.Location = new System.Drawing.Point(315, 174);
            this.btnSaveDuration.Name = "btnSaveDuration";
            this.btnSaveDuration.Size = new System.Drawing.Size(33, 32);
            this.btnSaveDuration.TabIndex = 12;
            this.btnSaveDuration.Text = "S";
            this.btnSaveDuration.UseVisualStyleBackColor = true;
            this.btnSaveDuration.Click += new System.EventHandler(this.OnClickSave);
            // 
            // btnStartDuration
            // 
            this.btnStartDuration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartDuration.Location = new System.Drawing.Point(315, 212);
            this.btnStartDuration.Name = "btnStartDuration";
            this.btnStartDuration.Size = new System.Drawing.Size(75, 38);
            this.btnStartDuration.TabIndex = 9;
            this.btnStartDuration.Text = "Start Countdown";
            this.btnStartDuration.UseVisualStyleBackColor = true;
            // 
            // tabTime
            // 
            this.tabTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabTime.Controls.Add(this.label1);
            this.tabTime.Controls.Add(this.lbl24h1);
            this.tabTime.Controls.Add(this.chk24h);
            this.tabTime.Controls.Add(this.flwTimeSuggestions);
            this.tabTime.Controls.Add(this.btnLoadCountdown);
            this.tabTime.Controls.Add(this.btnSaveCountdown);
            this.tabTime.Controls.Add(this.btnStartTime);
            this.tabTime.Controls.Add(this.lblYear);
            this.tabTime.Controls.Add(this.numYear);
            this.tabTime.Controls.Add(this.knbMonth);
            this.tabTime.Controls.Add(this.knbDay);
            this.tabTime.Controls.Add(this.chkAdv);
            this.tabTime.Controls.Add(this.knbSec);
            this.tabTime.Controls.Add(this.knbMin);
            this.tabTime.Controls.Add(this.knbHour);
            this.tabTime.Location = new System.Drawing.Point(4, 22);
            this.tabTime.Name = "tabTime";
            this.tabTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabTime.Size = new System.Drawing.Size(396, 289);
            this.tabTime.TabIndex = 0;
            this.tabTime.Text = "Set time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "time";
            // 
            // lbl24h1
            // 
            this.lbl24h1.AutoSize = true;
            this.lbl24h1.Location = new System.Drawing.Point(261, 220);
            this.lbl24h1.Name = "lbl24h1";
            this.lbl24h1.Size = new System.Drawing.Size(50, 13);
            this.lbl24h1.TabIndex = 16;
            this.lbl24h1.Text = "Use 24 h";
            // 
            // chk24h
            // 
            this.chk24h.AutoSize = true;
            this.chk24h.Location = new System.Drawing.Point(294, 236);
            this.chk24h.Name = "chk24h";
            this.chk24h.Size = new System.Drawing.Size(15, 14);
            this.chk24h.TabIndex = 15;
            this.chk24h.UseVisualStyleBackColor = true;
            this.chk24h.CheckedChanged += new System.EventHandler(this.OnChangeHourMode);
            // 
            // flwTimeSuggestions
            // 
            this.flwTimeSuggestions.Location = new System.Drawing.Point(0, 258);
            this.flwTimeSuggestions.Margin = new System.Windows.Forms.Padding(0);
            this.flwTimeSuggestions.Name = "flwTimeSuggestions";
            this.flwTimeSuggestions.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.flwTimeSuggestions.Size = new System.Drawing.Size(396, 31);
            this.flwTimeSuggestions.TabIndex = 12;
            this.flwTimeSuggestions.WrapContents = false;
            // 
            // btnLoadCountdown
            // 
            this.btnLoadCountdown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadCountdown.Location = new System.Drawing.Point(354, 174);
            this.btnLoadCountdown.Name = "btnLoadCountdown";
            this.btnLoadCountdown.Size = new System.Drawing.Size(34, 32);
            this.btnLoadCountdown.TabIndex = 11;
            this.btnLoadCountdown.Text = "L";
            this.btnLoadCountdown.UseVisualStyleBackColor = true;
            this.btnLoadCountdown.Click += new System.EventHandler(this.OnClickLoad);
            // 
            // btnSaveCountdown
            // 
            this.btnSaveCountdown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveCountdown.Location = new System.Drawing.Point(315, 174);
            this.btnSaveCountdown.Name = "btnSaveCountdown";
            this.btnSaveCountdown.Size = new System.Drawing.Size(33, 32);
            this.btnSaveCountdown.TabIndex = 10;
            this.btnSaveCountdown.Text = "S";
            this.btnSaveCountdown.UseVisualStyleBackColor = true;
            this.btnSaveCountdown.Click += new System.EventHandler(this.OnClickSave);
            // 
            // btnStartTime
            // 
            this.btnStartTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartTime.Location = new System.Drawing.Point(315, 212);
            this.btnStartTime.Name = "btnStartTime";
            this.btnStartTime.Size = new System.Drawing.Size(75, 38);
            this.btnStartTime.TabIndex = 8;
            this.btnStartTime.Text = "Start Countdown";
            this.btnStartTime.UseVisualStyleBackColor = true;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.lblYear.Location = new System.Drawing.Point(260, 132);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 13);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "Year";
            this.lblYear.Visible = false;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(263, 148);
            this.numYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(46, 20);
            this.numYear.TabIndex = 6;
            this.numYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYear.Visible = false;
            // 
            // chkAdv
            // 
            this.chkAdv.AutoSize = true;
            this.chkAdv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.chkAdv.Location = new System.Drawing.Point(305, 6);
            this.chkAdv.Name = "chkAdv";
            this.chkAdv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAdv.Size = new System.Drawing.Size(75, 17);
            this.chkAdv.TabIndex = 3;
            this.chkAdv.Text = "Advanced";
            this.chkAdv.UseVisualStyleBackColor = true;
            this.chkAdv.CheckedChanged += new System.EventHandler(this.OnAdvancedToggled);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabTime);
            this.tabs.Controls.Add(this.tabDuration);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(404, 315);
            this.tabs.TabIndex = 0;
            // 
            // cboxColors
            // 
            this.cboxColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxColors.FormattingEnabled = true;
            this.cboxColors.Location = new System.Drawing.Point(319, 169);
            this.cboxColors.Name = "cboxColors";
            this.cboxColors.Size = new System.Drawing.Size(73, 21);
            this.cboxColors.TabIndex = 14;
            // 
            // knbMonth
            // 
            this.knbMonth.Boldness = 15F;
            this.knbMonth.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbMonth.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.knbMonth.Location = new System.Drawing.Point(134, 132);
            this.knbMonth.MaxValue = 12F;
            this.knbMonth.MinValue = 1;
            this.knbMonth.Name = "knbMonth";
            this.knbMonth.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbMonth.ReadOnly = false;
            this.knbMonth.Size = new System.Drawing.Size(120, 120);
            this.knbMonth.Step = 1;
            this.knbMonth.TabIndex = 5;
            this.knbMonth.Text = "Month";
            this.knbMonth.Value = 1F;
            this.knbMonth.Visible = false;
            // 
            // knbDay
            // 
            this.knbDay.Boldness = 15F;
            this.knbDay.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbDay.ForeColor = System.Drawing.Color.SeaGreen;
            this.knbDay.Location = new System.Drawing.Point(8, 132);
            this.knbDay.MaxValue = 31F;
            this.knbDay.MinValue = 1;
            this.knbDay.Name = "knbDay";
            this.knbDay.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbDay.ReadOnly = false;
            this.knbDay.Size = new System.Drawing.Size(120, 120);
            this.knbDay.Step = 1;
            this.knbDay.TabIndex = 4;
            this.knbDay.Text = "Day";
            this.knbDay.Value = 1F;
            this.knbDay.Visible = false;
            // 
            // knbSec
            // 
            this.knbSec.Boldness = 15F;
            this.knbSec.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbSec.ForeColor = System.Drawing.Color.DarkKhaki;
            this.knbSec.Location = new System.Drawing.Point(260, 6);
            this.knbSec.MaxValue = 59F;
            this.knbSec.MinValue = 0;
            this.knbSec.Name = "knbSec";
            this.knbSec.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbSec.ReadOnly = false;
            this.knbSec.Size = new System.Drawing.Size(120, 120);
            this.knbSec.Step = 1;
            this.knbSec.TabIndex = 2;
            this.knbSec.Text = "Second";
            this.knbSec.Value = 0F;
            this.knbSec.Visible = false;
            // 
            // knbMin
            // 
            this.knbMin.Boldness = 15F;
            this.knbMin.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbMin.ForeColor = System.Drawing.Color.DarkCyan;
            this.knbMin.Location = new System.Drawing.Point(134, 6);
            this.knbMin.MaxValue = 59F;
            this.knbMin.MinValue = 0;
            this.knbMin.Name = "knbMin";
            this.knbMin.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbMin.ReadOnly = false;
            this.knbMin.Size = new System.Drawing.Size(120, 120);
            this.knbMin.Step = 5;
            this.knbMin.TabIndex = 1;
            this.knbMin.Text = "Minute";
            this.knbMin.Value = 0F;
            // 
            // knbHour
            // 
            this.knbHour.Boldness = 15F;
            this.knbHour.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbHour.ForeColor = System.Drawing.Color.Firebrick;
            this.knbHour.Location = new System.Drawing.Point(8, 6);
            this.knbHour.MaxValue = 23F;
            this.knbHour.MinValue = 0;
            this.knbHour.Name = "knbHour";
            this.knbHour.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbHour.ReadOnly = false;
            this.knbHour.Size = new System.Drawing.Size(120, 120);
            this.knbHour.Step = 1;
            this.knbHour.TabIndex = 0;
            this.knbHour.Text = "Hour";
            this.knbHour.Value = 0F;
            // 
            // knbDurSec
            // 
            this.knbDurSec.Boldness = 15F;
            this.knbDurSec.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbDurSec.ForeColor = System.Drawing.Color.Gold;
            this.knbDurSec.Location = new System.Drawing.Point(245, 6);
            this.knbDurSec.MaxValue = 59F;
            this.knbDurSec.MinValue = 0;
            this.knbDurSec.Name = "knbDurSec";
            this.knbDurSec.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbDurSec.ReadOnly = false;
            this.knbDurSec.Size = new System.Drawing.Size(130, 130);
            this.knbDurSec.Step = 1;
            this.knbDurSec.TabIndex = 2;
            this.knbDurSec.Text = "Seconds";
            this.knbDurSec.Value = 0F;
            // 
            // knbDurMin
            // 
            this.knbDurMin.Boldness = 15F;
            this.knbDurMin.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbDurMin.ForeColor = System.Drawing.Color.Blue;
            this.knbDurMin.Location = new System.Drawing.Point(119, 6);
            this.knbDurMin.MaxValue = 59F;
            this.knbDurMin.MinValue = 0;
            this.knbDurMin.Name = "knbDurMin";
            this.knbDurMin.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbDurMin.ReadOnly = false;
            this.knbDurMin.Size = new System.Drawing.Size(120, 120);
            this.knbDurMin.Step = 1;
            this.knbDurMin.TabIndex = 1;
            this.knbDurMin.Text = "Minutes";
            this.knbDurMin.Value = 0F;
            // 
            // knbDurHour
            // 
            this.knbDurHour.Boldness = 15F;
            this.knbDurHour.CircleTrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.knbDurHour.ForeColor = System.Drawing.Color.Red;
            this.knbDurHour.Location = new System.Drawing.Point(8, 6);
            this.knbDurHour.MaxValue = 48F;
            this.knbDurHour.MinValue = 0;
            this.knbDurHour.Name = "knbDurHour";
            this.knbDurHour.NumberFont = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.knbDurHour.ReadOnly = false;
            this.knbDurHour.Size = new System.Drawing.Size(110, 110);
            this.knbDurHour.Step = 1;
            this.knbDurHour.TabIndex = 0;
            this.knbDurHour.Text = "Hours";
            this.knbDurHour.Value = 0F;
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(404, 314);
            this.Controls.Add(this.cboxColors);
            this.Controls.Add(this.tabs);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Setup";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.tabDuration.ResumeLayout(false);
            this.tabTime.ResumeLayout(false);
            this.tabTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabDuration;
        private System.Windows.Forms.Button btnStartDuration;
        private FormParts.Setup.KnobDual knbDurSec;
        private FormParts.Setup.KnobDual knbDurMin;
        private FormParts.Setup.Knob knbDurHour;
        private System.Windows.Forms.TabPage tabTime;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private FormParts.Setup.Knob knbMonth;
        private FormParts.Setup.Knob knbDay;
        private System.Windows.Forms.CheckBox chkAdv;
        private FormParts.Setup.KnobDual knbSec;
        private FormParts.Setup.KnobDual knbMin;
        private FormParts.Setup.KnobHour knbHour;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Button btnLoadCountdown;
        private System.Windows.Forms.Button btnSaveCountdown;
        private System.Windows.Forms.Button btnLoadDuration;
        private System.Windows.Forms.Button btnSaveDuration;
        internal System.Windows.Forms.Button btnStartTime;
        private System.Windows.Forms.FlowLayoutPanel flwTimeSuggestions;
        private System.Windows.Forms.FlowLayoutPanel flwTimeSuggestionsDuration;
        private FormParts.ColorSchemeComboBox cboxColors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl24h1;
        private System.Windows.Forms.CheckBox chk24h;
    }
}