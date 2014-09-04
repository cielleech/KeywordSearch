namespace KeyWordSerch
{
    partial class ProccessControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lKeyWord = new System.Windows.Forms.Label();
            this.lMsg = new System.Windows.Forms.Label();
            this.progressBar1 = new KeyWordSerch.XpProgressBar();
            this.loadingCircle1 = new KeyWordSerch.LoadingCircle();
            this.SuspendLayout();
            // 
            // lKeyWord
            // 
            this.lKeyWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lKeyWord.BackColor = System.Drawing.SystemColors.Control;
            this.lKeyWord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lKeyWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lKeyWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(91)))), ((int)(((byte)(27)))));
            this.lKeyWord.Location = new System.Drawing.Point(3, 3);
            this.lKeyWord.Name = "lKeyWord";
            this.lKeyWord.Size = new System.Drawing.Size(588, 18);
            this.lKeyWord.TabIndex = 1;
            // 
            // lMsg
            // 
            this.lMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lMsg.ForeColor = System.Drawing.Color.Green;
            this.lMsg.Location = new System.Drawing.Point(3, 51);
            this.lMsg.Name = "lMsg";
            this.lMsg.Size = new System.Drawing.Size(588, 30);
            this.lMsg.TabIndex = 2;
            this.lMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.ColorBackGround = System.Drawing.Color.White;
            this.progressBar1.ColorBarBorder = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(240)))), ((int)(((byte)(170)))));
            this.progressBar1.ColorBarCenter = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(10)))));
            this.progressBar1.ColorText = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(91)))), ((int)(((byte)(27)))));
            this.progressBar1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.progressBar1.Location = new System.Drawing.Point(33, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Position = 0;
            this.progressBar1.PositionMax = 100;
            this.progressBar1.PositionMin = 0;
            this.progressBar1.Size = new System.Drawing.Size(551, 22);
            this.progressBar1.SteepDistance = ((byte)(0));
            this.progressBar1.SteepWidth = ((byte)(5));
            this.progressBar1.TabIndex = 5;
            this.progressBar1.TextShadowAlpha = ((byte)(0));
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = false;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 6;
            this.loadingCircle1.Location = new System.Drawing.Point(4, 25);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 9;
            this.loadingCircle1.OuterCircleRadius = 7;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(22, 22);
            this.loadingCircle1.SpokeThickness = 4;
            this.loadingCircle1.StylePreset = KeyWordSerch.LoadingCircle.StylePresets.Firefox;
            this.loadingCircle1.TabIndex = 4;
            this.loadingCircle1.Text = "loadingCircle1";
            // 
            // ProccessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.loadingCircle1);
            this.Controls.Add(this.lMsg);
            this.Controls.Add(this.lKeyWord);
            this.Name = "ProccessControl";
            this.Size = new System.Drawing.Size(600, 84);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lKeyWord;
        private System.Windows.Forms.Label lMsg;
        private KeyWordSerch.LoadingCircle loadingCircle1;
        private XpProgressBar progressBar1;
    }
}
