namespace KeyWordSerch
{
    partial class FormSerch
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
            this.components = new System.ComponentModel.Container();
            this.BtnStart = new System.Windows.Forms.Button();
            this.lKeyword1 = new System.Windows.Forms.Label();
            this.lKeyWord2 = new System.Windows.Forms.Label();
            this.lKeyWord4 = new System.Windows.Forms.Label();
            this.lKeyWord3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listKeyWords = new System.Windows.Forms.ListBox();
            this.BtnViewResult = new System.Windows.Forms.Button();
            this.BtnSingle = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lSuccessCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lFailureCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lFreeCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lContent = new System.Windows.Forms.ToolStripStatusLabel();
            this.lNextTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lTimeTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.lTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.proccessControl2 = new KeyWordSerch.ProccessControl();
            this.proccessControl3 = new KeyWordSerch.ProccessControl();
            this.proccessControl1 = new KeyWordSerch.ProccessControl();
            this.proccessControl4 = new KeyWordSerch.ProccessControl();
            this.BtnRank = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.proccessDetailControl1 = new KeyWordSerch.ProccessDetailControl();
            this.btnContinue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listFailureKeyWords = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnSet = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(680, 12);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(45, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lKeyword1
            // 
            this.lKeyword1.AutoSize = true;
            this.lKeyword1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lKeyword1.ForeColor = System.Drawing.Color.Green;
            this.lKeyword1.Location = new System.Drawing.Point(6, 45);
            this.lKeyword1.Name = "lKeyword1";
            this.lKeyword1.Size = new System.Drawing.Size(61, 12);
            this.lKeyword1.TabIndex = 6;
            this.lKeyword1.Text = "Thread1:";
            // 
            // lKeyWord2
            // 
            this.lKeyWord2.AutoSize = true;
            this.lKeyWord2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lKeyWord2.ForeColor = System.Drawing.Color.Green;
            this.lKeyWord2.Location = new System.Drawing.Point(6, 137);
            this.lKeyWord2.Name = "lKeyWord2";
            this.lKeyWord2.Size = new System.Drawing.Size(61, 12);
            this.lKeyWord2.TabIndex = 7;
            this.lKeyWord2.Text = "Thread2:";
            // 
            // lKeyWord4
            // 
            this.lKeyWord4.AutoSize = true;
            this.lKeyWord4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lKeyWord4.ForeColor = System.Drawing.Color.Green;
            this.lKeyWord4.Location = new System.Drawing.Point(6, 326);
            this.lKeyWord4.Name = "lKeyWord4";
            this.lKeyWord4.Size = new System.Drawing.Size(61, 12);
            this.lKeyWord4.TabIndex = 9;
            this.lKeyWord4.Text = "Thread4:";
            // 
            // lKeyWord3
            // 
            this.lKeyWord3.AutoSize = true;
            this.lKeyWord3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lKeyWord3.ForeColor = System.Drawing.Color.Green;
            this.lKeyWord3.Location = new System.Drawing.Point(6, 231);
            this.lKeyWord3.Name = "lKeyWord3";
            this.lKeyWord3.Size = new System.Drawing.Size(61, 12);
            this.lKeyWord3.TabIndex = 10;
            this.lKeyWord3.Text = "Thread3:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(74, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 1);
            this.label1.TabIndex = 11;
            this.label1.Text = "KeyWord1:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(74, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(595, 1);
            this.label3.TabIndex = 13;
            this.label3.Text = "KeyWord1:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(74, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(595, 1);
            this.label4.TabIndex = 14;
            this.label4.Text = "KeyWord1:";
            // 
            // listKeyWords
            // 
            this.listKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listKeyWords.FormattingEnabled = true;
            this.listKeyWords.ItemHeight = 12;
            this.listKeyWords.Location = new System.Drawing.Point(680, 56);
            this.listKeyWords.Name = "listKeyWords";
            this.listKeyWords.Size = new System.Drawing.Size(258, 220);
            this.listKeyWords.TabIndex = 15;
            // 
            // BtnViewResult
            // 
            this.BtnViewResult.Location = new System.Drawing.Point(730, 12);
            this.BtnViewResult.Name = "BtnViewResult";
            this.BtnViewResult.Size = new System.Drawing.Size(45, 23);
            this.BtnViewResult.TabIndex = 16;
            this.BtnViewResult.Text = "View";
            this.BtnViewResult.UseVisualStyleBackColor = true;
            this.BtnViewResult.Click += new System.EventHandler(this.BtnViewResult_Click);
            // 
            // BtnSingle
            // 
            this.BtnSingle.Location = new System.Drawing.Point(780, 12);
            this.BtnSingle.Name = "BtnSingle";
            this.BtnSingle.Size = new System.Drawing.Size(45, 23);
            this.BtnSingle.TabIndex = 17;
            this.BtnSingle.Text = "Single";
            this.BtnSingle.UseVisualStyleBackColor = true;
            this.BtnSingle.Click += new System.EventHandler(this.BtnSingle_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lCount,
            this.toolStripStatusLabel3,
            this.lSuccessCount,
            this.toolStripStatusLabel5,
            this.lFailureCount,
            this.toolStripStatusLabel4,
            this.lFreeCount,
            this.lContent,
            this.lNextTime,
            this.lTimeTitle,
            this.lTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(944, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "已完成:";
            // 
            // lCount
            // 
            this.lCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(27, 17);
            this.lCount.Text = "0/0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel3.Text = "成功:";
            // 
            // lSuccessCount
            // 
            this.lSuccessCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lSuccessCount.Name = "lSuccessCount";
            this.lSuccessCount.Size = new System.Drawing.Size(15, 17);
            this.lSuccessCount.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel5.Text = "失败:";
            // 
            // lFailureCount
            // 
            this.lFailureCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lFailureCount.Name = "lFailureCount";
            this.lFailureCount.Size = new System.Drawing.Size(15, 17);
            this.lFailureCount.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel4.Text = "剩余:";
            // 
            // lFreeCount
            // 
            this.lFreeCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lFreeCount.Name = "lFreeCount";
            this.lFreeCount.Size = new System.Drawing.Size(15, 17);
            this.lFreeCount.Text = "0";
            // 
            // lContent
            // 
            this.lContent.Name = "lContent";
            this.lContent.Size = new System.Drawing.Size(514, 17);
            this.lContent.Spring = true;
            this.lContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lNextTime
            // 
            this.lNextTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lNextTime.Name = "lNextTime";
            this.lNextTime.Size = new System.Drawing.Size(99, 17);
            this.lNextTime.Text = "尚未开始搜索...";
            // 
            // lTimeTitle
            // 
            this.lTimeTitle.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lTimeTitle.Name = "lTimeTitle";
            this.lTimeTitle.Size = new System.Drawing.Size(39, 17);
            this.lTimeTitle.Text = "用时:";
            // 
            // lTime
            // 
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(53, 17);
            this.lTime.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // proccessControl2
            // 
            this.proccessControl2.Location = new System.Drawing.Point(69, 107);
            this.proccessControl2.Name = "proccessControl2";
            this.proccessControl2.Proxy = null;
            this.proccessControl2.Size = new System.Drawing.Size(600, 84);
            this.proccessControl2.TabIndex = 3;
            // 
            // proccessControl3
            // 
            this.proccessControl3.Location = new System.Drawing.Point(69, 201);
            this.proccessControl3.Name = "proccessControl3";
            this.proccessControl3.Proxy = null;
            this.proccessControl3.Size = new System.Drawing.Size(600, 84);
            this.proccessControl3.TabIndex = 2;
            // 
            // proccessControl1
            // 
            this.proccessControl1.Location = new System.Drawing.Point(69, 13);
            this.proccessControl1.Name = "proccessControl1";
            this.proccessControl1.Proxy = null;
            this.proccessControl1.Size = new System.Drawing.Size(600, 84);
            this.proccessControl1.TabIndex = 1;
            // 
            // proccessControl4
            // 
            this.proccessControl4.Location = new System.Drawing.Point(69, 295);
            this.proccessControl4.Name = "proccessControl4";
            this.proccessControl4.Proxy = null;
            this.proccessControl4.Size = new System.Drawing.Size(600, 84);
            this.proccessControl4.TabIndex = 4;
            // 
            // BtnRank
            // 
            this.BtnRank.Location = new System.Drawing.Point(830, 12);
            this.BtnRank.Name = "BtnRank";
            this.BtnRank.Size = new System.Drawing.Size(45, 23);
            this.BtnRank.TabIndex = 22;
            this.BtnRank.Text = "Rank";
            this.BtnRank.UseVisualStyleBackColor = true;
            this.BtnRank.Click += new System.EventHandler(this.BtnRank_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = global::KeyWordSerch.Properties.Resources.frm;
            this.notifyIcon1.Text = "搜索任务尚未启动..";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem2.Text = "还原";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem1.Text = "退出";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 388);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主搜索区";
            // 
            // proccessDetailControl1
            // 
            this.proccessDetailControl1.Location = new System.Drawing.Point(69, 407);
            this.proccessDetailControl1.Name = "proccessDetailControl1";
            this.proccessDetailControl1.Proxy = null;
            this.proccessDetailControl1.Size = new System.Drawing.Size(600, 67);
            this.proccessDetailControl1.TabIndex = 25;
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Font = new System.Drawing.Font("宋体", 9F);
            this.btnContinue.ForeColor = System.Drawing.Color.Black;
            this.btnContinue.Location = new System.Drawing.Point(6, 410);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(61, 23);
            this.btnContinue.TabIndex = 24;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(2, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 96);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "二次搜索";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(74, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(595, 1);
            this.label5.TabIndex = 28;
            this.label5.Text = "KeyWord1:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(74, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(595, 1);
            this.label2.TabIndex = 27;
            this.label2.Text = "KeyWord1:";
            // 
            // listFailureKeyWords
            // 
            this.listFailureKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listFailureKeyWords.ForeColor = System.Drawing.Color.DarkGray;
            this.listFailureKeyWords.FormattingEnabled = true;
            this.listFailureKeyWords.ItemHeight = 12;
            this.listFailureKeyWords.Location = new System.Drawing.Point(680, 299);
            this.listFailureKeyWords.Name = "listFailureKeyWords";
            this.listFailureKeyWords.Size = new System.Drawing.Size(258, 172);
            this.listFailureKeyWords.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(683, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "失败列表:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(683, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "搜索列表:";
            // 
            // BtnSet
            // 
            this.BtnSet.Location = new System.Drawing.Point(880, 12);
            this.BtnSet.Name = "BtnSet";
            this.BtnSet.Size = new System.Drawing.Size(45, 23);
            this.BtnSet.TabIndex = 31;
            this.BtnSet.Text = "Set";
            this.BtnSet.UseVisualStyleBackColor = true;
            this.BtnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // FormSerch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 519);
            this.Controls.Add(this.BtnSet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listFailureKeyWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.proccessDetailControl1);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnRank);
            this.Controls.Add(this.BtnViewResult);
            this.Controls.Add(this.BtnSingle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listKeyWords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lKeyWord3);
            this.Controls.Add(this.lKeyWord4);
            this.Controls.Add(this.lKeyWord2);
            this.Controls.Add(this.lKeyword1);
            this.Controls.Add(this.proccessControl2);
            this.Controls.Add(this.proccessControl3);
            this.Controls.Add(this.proccessControl1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.proccessControl4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormSerch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主搜索...";
            this.Load += new System.EventHandler(this.FormSerch_Load);
            this.Shown += new System.EventHandler(this.FormSerch_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSerch_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private ProccessControl proccessControl1;
        private ProccessControl proccessControl3;
        private ProccessControl proccessControl2;
        private ProccessControl proccessControl4;
        private System.Windows.Forms.Label lKeyword1;
        private System.Windows.Forms.Label lKeyWord2;
        private System.Windows.Forms.Label lKeyWord4;
        private System.Windows.Forms.Label lKeyWord3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listKeyWords;
        private System.Windows.Forms.Button BtnViewResult;
        private System.Windows.Forms.Button BtnSingle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lCount;
        private System.Windows.Forms.ToolStripStatusLabel lContent;
        private System.Windows.Forms.ToolStripStatusLabel lTimeTitle;
        private System.Windows.Forms.ToolStripStatusLabel lTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button BtnRank;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lSuccessCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lFailureCount;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ProccessDetailControl proccessDetailControl1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listFailureKeyWords;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnSet;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lFreeCount;
        private System.Windows.Forms.ToolStripStatusLabel lNextTime;
        private System.Windows.Forms.Timer timer3;
    }
}