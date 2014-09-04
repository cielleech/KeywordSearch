namespace KeyWordSerch
{
    partial class FormRank
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tItemSerchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serchItemsDataSet = new KeyWordSerch.Data.SerchItemsDataSet();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.lbegindate = new System.Windows.Forms.Label();
            this.t_ItemSerchResultTableAdapter = new KeyWordSerch.Data.SerchItemsDataSetTableAdapters.T_ItemSerchResultTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tItemSerchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serchItemsDataSet)).BeginInit();
            this.gbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tItemSerchResultBindingSource
            // 
            this.tItemSerchResultBindingSource.DataMember = "T_ItemSerchResult";
            this.tItemSerchResultBindingSource.DataSource = this.serchItemsDataSet;
            // 
            // serchItemsDataSet
            // 
            this.serchItemsDataSet.DataSetName = "SerchItemsDataSet";
            this.serchItemsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBeginDate.Location = new System.Drawing.Point(87, 28);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(111, 21);
            this.dtpBeginDate.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(222, 26);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.btnQuery);
            this.gbQuery.Controls.Add(this.lbegindate);
            this.gbQuery.Controls.Add(this.dtpBeginDate);
            this.gbQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbQuery.Location = new System.Drawing.Point(0, 0);
            this.gbQuery.Name = "gbQuery";
            this.gbQuery.Size = new System.Drawing.Size(944, 65);
            this.gbQuery.TabIndex = 5;
            this.gbQuery.TabStop = false;
            // 
            // lbegindate
            // 
            this.lbegindate.AutoSize = true;
            this.lbegindate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbegindate.Location = new System.Drawing.Point(12, 32);
            this.lbegindate.Name = "lbegindate";
            this.lbegindate.Size = new System.Drawing.Size(59, 12);
            this.lbegindate.TabIndex = 0;
            this.lbegindate.Text = "查询日期:";
            // 
            // t_ItemSerchResultTableAdapter
            // 
            this.t_ItemSerchResultTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rank,
            this.ItemNumber,
            this.ItemTitle,
            this.Quantity,
            this.SoldDate});
            this.dataGridView1.Location = new System.Drawing.Point(0, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(944, 447);
            this.dataGridView1.TabIndex = 6;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            this.Rank.Width = 50;
            // 
            // ItemNumber
            // 
            this.ItemNumber.DataPropertyName = "ItemNumber";
            this.ItemNumber.HeaderText = "ItemNumber";
            this.ItemNumber.Name = "ItemNumber";
            this.ItemNumber.ReadOnly = true;
            this.ItemNumber.Width = 120;
            // 
            // ItemTitle
            // 
            this.ItemTitle.DataPropertyName = "ItemTitle";
            this.ItemTitle.HeaderText = "ItemTitle";
            this.ItemTitle.Name = "ItemTitle";
            this.ItemTitle.ReadOnly = true;
            this.ItemTitle.Width = 540;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 60;
            // 
            // SoldDate
            // 
            this.SoldDate.DataPropertyName = "SoldDate";
            this.SoldDate.HeaderText = "SoldDate";
            this.SoldDate.Name = "SoldDate";
            this.SoldDate.ReadOnly = true;
            this.SoldDate.Width = 80;
            // 
            // FormRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 519);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbQuery);
            this.Name = "FormRank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结果排名...";
            this.Load += new System.EventHandler(this.FormView_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tItemSerchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serchItemsDataSet)).EndInit();
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KeyWordSerch.Data.SerchItemsDataSet serchItemsDataSet;
        private System.Windows.Forms.BindingSource tItemSerchResultBindingSource;
        private KeyWordSerch.Data.SerchItemsDataSetTableAdapters.T_ItemSerchResultTableAdapter t_ItemSerchResultTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.Label lbegindate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldDate;
    }
}