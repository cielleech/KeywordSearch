namespace KeyWordSerch
{
    partial class FormSingle
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnMatch = new System.Windows.Forms.Button();
            this.cbbKeyWords = new System.Windows.Forms.ComboBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.l1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRank = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lday = new System.Windows.Forms.Label();
            this.nudGetNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGetNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.ForeColor = System.Drawing.Color.Green;
            this.txtLog.Location = new System.Drawing.Point(1, 85);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(940, 433);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            this.txtLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtLog_LinkClicked);
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(387, 44);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(75, 23);
            this.btnMatch.TabIndex = 2;
            this.btnMatch.Text = "Start";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // cbbKeyWords
            // 
            this.cbbKeyWords.Location = new System.Drawing.Point(71, 8);
            this.cbbKeyWords.Name = "cbbKeyWords";
            this.cbbKeyWords.Size = new System.Drawing.Size(835, 20);
            this.cbbKeyWords.TabIndex = 3;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(18, 12);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(47, 12);
            this.lTitle.TabIndex = 4;
            this.lTitle.Text = "关键字:";
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Location = new System.Drawing.Point(210, 49);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(17, 12);
            this.l1.TabIndex = 6;
            this.l1.Text = "前";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "条";
            // 
            // nudRank
            // 
            this.nudRank.Location = new System.Drawing.Point(229, 45);
            this.nudRank.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudRank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRank.Name = "nudRank";
            this.nudRank.Size = new System.Drawing.Size(46, 21);
            this.nudRank.TabIndex = 8;
            this.nudRank.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(73, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(123, 21);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // lday
            // 
            this.lday.AutoSize = true;
            this.lday.Location = new System.Drawing.Point(6, 49);
            this.lday.Name = "lday";
            this.lday.Size = new System.Drawing.Size(59, 12);
            this.lday.TabIndex = 10;
            this.lday.Text = "抓取日期:";
            // 
            // nudGetNumber
            // 
            this.nudGetNumber.Location = new System.Drawing.Point(317, 45);
            this.nudGetNumber.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudGetNumber.Name = "nudGetNumber";
            this.nudGetNumber.Size = new System.Drawing.Size(46, 21);
            this.nudGetNumber.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "条";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "第";
            // 
            // FormSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 519);
            this.Controls.Add(this.nudGetNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lday);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.nudRank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.cbbKeyWords);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.txtLog);
            this.Name = "FormSingle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单个搜索...";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGetNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.ComboBox cbbKeyWords;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRank;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lday;
        private System.Windows.Forms.NumericUpDown nudGetNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

