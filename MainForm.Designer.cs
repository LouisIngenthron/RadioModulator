namespace DialogRadioModifier
{
    partial class MainForm
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
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarStart = new System.Windows.Forms.TrackBar();
            this.trackBarEnd = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.waveformVisualizer1 = new DialogRadioModifier.WaveformVisualizer();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxQuality = new System.Windows.Forms.ComboBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxNormalize = new System.Windows.Forms.CheckBox();
            this.checkBoxCaps = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEnd)).BeginInit();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(108, 23);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Open Source File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Time:";
            // 
            // trackBarStart
            // 
            this.trackBarStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarStart.Location = new System.Drawing.Point(75, 21);
            this.trackBarStart.Maximum = 100;
            this.trackBarStart.Name = "trackBarStart";
            this.trackBarStart.Size = new System.Drawing.Size(388, 45);
            this.trackBarStart.TabIndex = 4;
            this.trackBarStart.Scroll += new System.EventHandler(this.trackBarStart_Scroll);
            // 
            // trackBarEnd
            // 
            this.trackBarEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarEnd.Location = new System.Drawing.Point(75, 72);
            this.trackBarEnd.Maximum = 100;
            this.trackBarEnd.Name = "trackBarEnd";
            this.trackBarEnd.Size = new System.Drawing.Size(388, 45);
            this.trackBarEnd.TabIndex = 6;
            this.trackBarEnd.Scroll += new System.EventHandler(this.trackBarEnd_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Time:";
            // 
            // waveformVisualizer1
            // 
            this.waveformVisualizer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveformVisualizer1.BackColor = System.Drawing.SystemColors.Window;
            this.waveformVisualizer1.Location = new System.Drawing.Point(12, 41);
            this.waveformVisualizer1.Name = "waveformVisualizer1";
            this.waveformVisualizer1.Size = new System.Drawing.Size(776, 212);
            this.waveformVisualizer1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Radio Quality:";
            // 
            // comboBoxQuality
            // 
            this.comboBoxQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuality.FormattingEnabled = true;
            this.comboBoxQuality.Items.AddRange(new object[] {
            "Great",
            "Okay",
            "Poor",
            "Awful"});
            this.comboBoxQuality.Location = new System.Drawing.Point(93, 130);
            this.comboBoxQuality.Name = "comboBoxQuality";
            this.comboBoxQuality.Size = new System.Drawing.Size(370, 23);
            this.comboBoxQuality.TabIndex = 9;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxOptions.Controls.Add(this.checkBoxNormalize);
            this.groupBoxOptions.Controls.Add(this.checkBoxCaps);
            this.groupBoxOptions.Controls.Add(this.trackBarStart);
            this.groupBoxOptions.Controls.Add(this.comboBoxQuality);
            this.groupBoxOptions.Controls.Add(this.label1);
            this.groupBoxOptions.Controls.Add(this.label3);
            this.groupBoxOptions.Controls.Add(this.label2);
            this.groupBoxOptions.Controls.Add(this.trackBarEnd);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 259);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(469, 239);
            this.groupBoxOptions.TabIndex = 10;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxNormalize
            // 
            this.checkBoxNormalize.AutoSize = true;
            this.checkBoxNormalize.Location = new System.Drawing.Point(6, 198);
            this.checkBoxNormalize.Name = "checkBoxNormalize";
            this.checkBoxNormalize.Size = new System.Drawing.Size(115, 19);
            this.checkBoxNormalize.TabIndex = 11;
            this.checkBoxNormalize.Text = "Normalize Audio";
            this.checkBoxNormalize.UseVisualStyleBackColor = true;
            // 
            // checkBoxCaps
            // 
            this.checkBoxCaps.AutoSize = true;
            this.checkBoxCaps.Location = new System.Drawing.Point(6, 173);
            this.checkBoxCaps.Name = "checkBoxCaps";
            this.checkBoxCaps.Size = new System.Drawing.Size(249, 19);
            this.checkBoxCaps.TabIndex = 10;
            this.checkBoxCaps.Text = "Include static caps on either end of the file";
            this.checkBoxCaps.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(655, 475);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(133, 23);
            this.buttonExport.TabIndex = 11;
            this.buttonExport.Text = "Export Processed File";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.waveformVisualizer1);
            this.Controls.Add(this.buttonOpenFile);
            this.Name = "MainForm";
            this.Text = "Audio Radio Modulator";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEnd)).EndInit();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button buttonOpenFile;
        private Label label1;
        private TrackBar trackBarStart;
        private TrackBar trackBarEnd;
        private Label label2;
        private WaveformVisualizer waveformVisualizer1;
        private Label label3;
        private ComboBox comboBoxQuality;
        private GroupBox groupBoxOptions;
        private Button buttonExport;
        private CheckBox checkBoxCaps;
        private CheckBox checkBoxNormalize;
    }
}