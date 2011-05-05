namespace Break
{
    partial class Preferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkPlaySound = new System.Windows.Forms.LinkLabel();
            this.btnBrowse_Sound = new System.Windows.Forms.Button();
            this.txtBreakSound = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.ofdBreakSound = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbUseCustomSound = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbUseCustomSound);
            this.groupBox1.Controls.Add(this.lnkPlaySound);
            this.groupBox1.Controls.Add(this.btnBrowse_Sound);
            this.groupBox1.Controls.Add(this.txtBreakSound);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Break Sound";
            // 
            // lnkPlaySound
            // 
            this.lnkPlaySound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPlaySound.AutoSize = true;
            this.lnkPlaySound.Location = new System.Drawing.Point(251, 60);
            this.lnkPlaySound.Name = "lnkPlaySound";
            this.lnkPlaySound.Size = new System.Drawing.Size(61, 13);
            this.lnkPlaySound.TabIndex = 2;
            this.lnkPlaySound.TabStop = true;
            this.lnkPlaySound.Text = "Play Sound";
            this.lnkPlaySound.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPlaySound_LinkClicked);
            // 
            // btnBrowse_Sound
            // 
            this.btnBrowse_Sound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse_Sound.Location = new System.Drawing.Point(318, 35);
            this.btnBrowse_Sound.Name = "btnBrowse_Sound";
            this.btnBrowse_Sound.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse_Sound.TabIndex = 1;
            this.btnBrowse_Sound.Text = "Browse...";
            this.btnBrowse_Sound.UseVisualStyleBackColor = true;
            this.btnBrowse_Sound.Click += new System.EventHandler(this.btnBrowse_Sound_Click);
            // 
            // txtBreakSound
            // 
            this.txtBreakSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBreakSound.Location = new System.Drawing.Point(6, 37);
            this.txtBreakSound.Name = "txtBreakSound";
            this.txtBreakSound.Size = new System.Drawing.Size(306, 20);
            this.txtBreakSound.TabIndex = 0;
            this.txtBreakSound.TextChanged += new System.EventHandler(this.txtBreakSound_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(337, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(256, 174);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // ofdBreakSound
            // 
            this.ofdBreakSound.Title = "Select Break Sound...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 50);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Work Duration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "How long is each work session? (in minutes)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Break.Properties.Settings.Default, "BreakMinutes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Location = new System.Drawing.Point(228, 18);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = global::Break.Properties.Settings.Default.BreakMinutes;
            // 
            // cbUseCustomSound
            // 
            this.cbUseCustomSound.AutoSize = true;
            this.cbUseCustomSound.Checked = global::Break.Properties.Settings.Default.UseCustomSound;
            this.cbUseCustomSound.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Break.Properties.Settings.Default, "UseDefaultSound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbUseCustomSound.Location = new System.Drawing.Point(6, 19);
            this.cbUseCustomSound.Name = "cbUseCustomSound";
            this.cbUseCustomSound.Size = new System.Drawing.Size(114, 17);
            this.cbUseCustomSound.TabIndex = 3;
            this.cbUseCustomSound.Text = "Use custom sound";
            this.cbUseCustomSound.UseVisualStyleBackColor = true;
            this.cbUseCustomSound.CheckedChanged += new System.EventHandler(this.cbUseCustomSound_CheckedChanged);
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(424, 209);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.ShowInTaskbar = false;
            this.Text = "Break Preferences";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkPlaySound;
        private System.Windows.Forms.Button btnBrowse_Sound;
        private System.Windows.Forms.TextBox txtBreakSound;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox cbUseCustomSound;
        private System.Windows.Forms.OpenFileDialog ofdBreakSound;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}