namespace Sin_Reborn
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.statMultiplierLabel = new System.Windows.Forms.Label();
            this.apMultiplierLabel = new System.Windows.Forms.Label();
            this.scalingDifficultyCheckBox = new System.Windows.Forms.CheckBox();
            this.runMods = new System.Windows.Forms.Timer(this.components);
            this.statNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.apNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.nightmareRadioButton = new System.Windows.Forms.RadioButton();
            this.chimeraRadioButton = new System.Windows.Forms.RadioButton();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // statMultiplierLabel
            // 
            resources.ApplyResources(this.statMultiplierLabel, "statMultiplierLabel");
            this.statMultiplierLabel.BackColor = System.Drawing.Color.Transparent;
            this.statMultiplierLabel.ForeColor = System.Drawing.Color.White;
            this.statMultiplierLabel.Name = "statMultiplierLabel";
            this.toolTips.SetToolTip(this.statMultiplierLabel, resources.GetString("statMultiplierLabel.ToolTip"));
            // 
            // apMultiplierLabel
            // 
            resources.ApplyResources(this.apMultiplierLabel, "apMultiplierLabel");
            this.apMultiplierLabel.BackColor = System.Drawing.Color.Transparent;
            this.apMultiplierLabel.ForeColor = System.Drawing.Color.White;
            this.apMultiplierLabel.Name = "apMultiplierLabel";
            this.toolTips.SetToolTip(this.apMultiplierLabel, resources.GetString("apMultiplierLabel.ToolTip"));
            // 
            // scalingDifficultyCheckBox
            // 
            resources.ApplyResources(this.scalingDifficultyCheckBox, "scalingDifficultyCheckBox");
            this.scalingDifficultyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.scalingDifficultyCheckBox.ForeColor = System.Drawing.Color.White;
            this.scalingDifficultyCheckBox.Name = "scalingDifficultyCheckBox";
            this.toolTips.SetToolTip(this.scalingDifficultyCheckBox, resources.GetString("scalingDifficultyCheckBox.ToolTip"));
            this.scalingDifficultyCheckBox.UseVisualStyleBackColor = false;
            this.scalingDifficultyCheckBox.CheckedChanged += new System.EventHandler(this.ScalingDifficultyCheckBox_CheckedChanged);
            // 
            // runMods
            // 
            this.runMods.Enabled = true;
            this.runMods.Interval = 10;
            this.runMods.Tick += new System.EventHandler(this.RunMods_Tick);
            // 
            // statNumericUpDown
            // 
            this.statNumericUpDown.DecimalPlaces = 1;
            resources.ApplyResources(this.statNumericUpDown, "statNumericUpDown");
            this.statNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.statNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            65536});
            this.statNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.statNumericUpDown.Name = "statNumericUpDown";
            this.statNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.statNumericUpDown.ValueChanged += new System.EventHandler(this.StatNumericUpDown_ValueChanged);
            // 
            // apNumericUpDown
            // 
            this.apNumericUpDown.DecimalPlaces = 1;
            resources.ApplyResources(this.apNumericUpDown, "apNumericUpDown");
            this.apNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.apNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            65536});
            this.apNumericUpDown.Name = "apNumericUpDown";
            this.apNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.apNumericUpDown.ValueChanged += new System.EventHandler(this.APNumericUpDown_ValueChanged);
            // 
            // nightmareRadioButton
            // 
            resources.ApplyResources(this.nightmareRadioButton, "nightmareRadioButton");
            this.nightmareRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.nightmareRadioButton.ForeColor = System.Drawing.Color.White;
            this.nightmareRadioButton.Name = "nightmareRadioButton";
            this.toolTips.SetToolTip(this.nightmareRadioButton, resources.GetString("nightmareRadioButton.ToolTip"));
            this.nightmareRadioButton.UseVisualStyleBackColor = false;
            this.nightmareRadioButton.CheckedChanged += new System.EventHandler(this.NightmareRadioButton_CheckedChanged);
            // 
            // chimeraRadioButton
            // 
            resources.ApplyResources(this.chimeraRadioButton, "chimeraRadioButton");
            this.chimeraRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.chimeraRadioButton.ForeColor = System.Drawing.Color.White;
            this.chimeraRadioButton.Name = "chimeraRadioButton";
            this.toolTips.SetToolTip(this.chimeraRadioButton, resources.GetString("chimeraRadioButton.ToolTip"));
            this.chimeraRadioButton.UseVisualStyleBackColor = false;
            this.chimeraRadioButton.CheckedChanged += new System.EventHandler(this.ChimeraRadioButton_CheckedChanged);
            // 
            // customRadioButton
            // 
            resources.ApplyResources(this.customRadioButton, "customRadioButton");
            this.customRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.customRadioButton.ForeColor = System.Drawing.Color.White;
            this.customRadioButton.Name = "customRadioButton";
            this.customRadioButton.UseVisualStyleBackColor = false;
            this.customRadioButton.CheckedChanged += new System.EventHandler(this.CustomRadioButton_CheckedChanged);
            // 
            // toolTips
            // 
            this.toolTips.AutomaticDelay = 50;
            this.toolTips.AutoPopDelay = 10000;
            this.toolTips.InitialDelay = 50;
            this.toolTips.ReshowDelay = 10;
            // 
            // trayNotifyIcon
            // 
            resources.ApplyResources(this.trayNotifyIcon, "trayNotifyIcon");
            this.trayNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotifyIcon_MouseClick);
            // 
            // Dashboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.customRadioButton);
            this.Controls.Add(this.chimeraRadioButton);
            this.Controls.Add(this.nightmareRadioButton);
            this.Controls.Add(this.apNumericUpDown);
            this.Controls.Add(this.statNumericUpDown);
            this.Controls.Add(this.scalingDifficultyCheckBox);
            this.Controls.Add(this.apMultiplierLabel);
            this.Controls.Add(this.statMultiplierLabel);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dashboard_MouseMove);
            this.Resize += new System.EventHandler(this.Dashboard_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.statNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label statMultiplierLabel;
        private System.Windows.Forms.Label apMultiplierLabel;
        private System.Windows.Forms.CheckBox scalingDifficultyCheckBox;
        private System.Windows.Forms.Timer runMods;
        private System.Windows.Forms.NumericUpDown statNumericUpDown;
        private System.Windows.Forms.NumericUpDown apNumericUpDown;
        private System.Windows.Forms.RadioButton nightmareRadioButton;
        private System.Windows.Forms.RadioButton chimeraRadioButton;
        private System.Windows.Forms.RadioButton customRadioButton;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.NotifyIcon trayNotifyIcon;
    }
}

