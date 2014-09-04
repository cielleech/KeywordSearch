namespace KeyWordSerch
{
    partial class FormView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tItemSerchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serchItemsDataSet = new KeyWordSerch.Data.SerchItemsDataSet();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbbKeyWord = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.gbQuery = new System.Windows.Forms.GroupBox();
            this.lkeyWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbegindate = new System.Windows.Forms.Label();
            this.t_ItemSerchResultTableAdapter = new KeyWordSerch.Data.SerchItemsDataSetTableAdapters.T_ItemSerchResultTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReTry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSoldQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSoldByDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellerShopUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serchDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyWordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tItemSerchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serchItemsDataSet)).BeginInit();
            this.gbQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.ReTry,
            this.flagDataGridViewTextBoxColumn,
            this.dayIdDataGridViewTextBoxColumn,
            this.Rank,
            this.itemTitleDataGridViewTextBoxColumn,
            this.salePriceDataGridViewTextBoxColumn,
            this.itemSoldQuantityDataGridViewTextBoxColumn,
            this.itemSoldByDayDataGridViewTextBoxColumn,
            this.postageDataGridViewTextBoxColumn,
            this.Color,
            this.ColorSold,
            this.itemNumberDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.sellerIdDataGridViewTextBoxColumn,
            this.itemUrlDataGridViewTextBoxColumn,
            this.sellerShopUrlDataGridViewTextBoxColumn,
            this.serchDateTimeDataGridViewTextBoxColumn,
            this.keyWordDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tItemSerchResultBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(944, 448);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
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
            this.btnQuery.Location = new System.Drawing.Point(855, 27);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbbKeyWord
            // 
            this.cbbKeyWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbKeyWord.FormattingEnabled = true;
            this.cbbKeyWord.Location = new System.Drawing.Point(439, 28);
            this.cbbKeyWord.Name = "cbbKeyWord";
            this.cbbKeyWord.Size = new System.Drawing.Size(410, 20);
            this.cbbKeyWord.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndDate.Location = new System.Drawing.Point(269, 28);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(111, 21);
            this.dtpEndDate.TabIndex = 4;
            // 
            // gbQuery
            // 
            this.gbQuery.Controls.Add(this.btnQuery);
            this.gbQuery.Controls.Add(this.lkeyWord);
            this.gbQuery.Controls.Add(this.cbbKeyWord);
            this.gbQuery.Controls.Add(this.label1);
            this.gbQuery.Controls.Add(this.dtpEndDate);
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
            // lkeyWord
            // 
            this.lkeyWord.AutoSize = true;
            this.lkeyWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkeyWord.Location = new System.Drawing.Point(386, 32);
            this.lkeyWord.Name = "lkeyWord";
            this.lkeyWord.Size = new System.Drawing.Size(47, 12);
            this.lkeyWord.TabIndex = 6;
            this.lkeyWord.Text = "关键字:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(204, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "终止日期:";
            // 
            // lbegindate
            // 
            this.lbegindate.AutoSize = true;
            this.lbegindate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbegindate.Location = new System.Drawing.Point(12, 32);
            this.lbegindate.Name = "lbegindate";
            this.lbegindate.Size = new System.Drawing.Size(59, 12);
            this.lbegindate.TabIndex = 0;
            this.lbegindate.Text = "起始日期:";
            // 
            // t_ItemSerchResultTableAdapter
            // 
            this.t_ItemSerchResultTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 40;
            // 
            // ReTry
            // 
            this.ReTry.DataPropertyName = "ReTry";
            this.ReTry.HeaderText = "ReTry";
            this.ReTry.Name = "ReTry";
            this.ReTry.Width = 40;
            // 
            // flagDataGridViewTextBoxColumn
            // 
            this.flagDataGridViewTextBoxColumn.DataPropertyName = "Flag";
            this.flagDataGridViewTextBoxColumn.HeaderText = "Flag";
            this.flagDataGridViewTextBoxColumn.Name = "flagDataGridViewTextBoxColumn";
            this.flagDataGridViewTextBoxColumn.Width = 40;
            // 
            // dayIdDataGridViewTextBoxColumn
            // 
            this.dayIdDataGridViewTextBoxColumn.DataPropertyName = "DayId";
            this.dayIdDataGridViewTextBoxColumn.HeaderText = "MatchDate";
            this.dayIdDataGridViewTextBoxColumn.Name = "dayIdDataGridViewTextBoxColumn";
            this.dayIdDataGridViewTextBoxColumn.Width = 70;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "排名";
            this.Rank.Name = "Rank";
            this.Rank.Width = 55;
            // 
            // itemTitleDataGridViewTextBoxColumn
            // 
            this.itemTitleDataGridViewTextBoxColumn.DataPropertyName = "ItemTitle";
            this.itemTitleDataGridViewTextBoxColumn.HeaderText = "ItemTitle";
            this.itemTitleDataGridViewTextBoxColumn.Name = "itemTitleDataGridViewTextBoxColumn";
            this.itemTitleDataGridViewTextBoxColumn.Width = 450;
            // 
            // salePriceDataGridViewTextBoxColumn
            // 
            this.salePriceDataGridViewTextBoxColumn.DataPropertyName = "SalePrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.salePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.salePriceDataGridViewTextBoxColumn.HeaderText = "售价";
            this.salePriceDataGridViewTextBoxColumn.Name = "salePriceDataGridViewTextBoxColumn";
            this.salePriceDataGridViewTextBoxColumn.Width = 60;
            // 
            // itemSoldQuantityDataGridViewTextBoxColumn
            // 
            this.itemSoldQuantityDataGridViewTextBoxColumn.DataPropertyName = "ItemSoldQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.itemSoldQuantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemSoldQuantityDataGridViewTextBoxColumn.FillWeight = 60F;
            this.itemSoldQuantityDataGridViewTextBoxColumn.HeaderText = "总销量";
            this.itemSoldQuantityDataGridViewTextBoxColumn.Name = "itemSoldQuantityDataGridViewTextBoxColumn";
            this.itemSoldQuantityDataGridViewTextBoxColumn.Width = 70;
            // 
            // itemSoldByDayDataGridViewTextBoxColumn
            // 
            this.itemSoldByDayDataGridViewTextBoxColumn.DataPropertyName = "ItemSoldByDay";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.itemSoldByDayDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.itemSoldByDayDataGridViewTextBoxColumn.FillWeight = 60F;
            this.itemSoldByDayDataGridViewTextBoxColumn.HeaderText = "天销量";
            this.itemSoldByDayDataGridViewTextBoxColumn.Name = "itemSoldByDayDataGridViewTextBoxColumn";
            this.itemSoldByDayDataGridViewTextBoxColumn.Width = 70;
            // 
            // postageDataGridViewTextBoxColumn
            // 
            this.postageDataGridViewTextBoxColumn.DataPropertyName = "Postage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0";
            this.postageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.postageDataGridViewTextBoxColumn.HeaderText = "邮费";
            this.postageDataGridViewTextBoxColumn.Name = "postageDataGridViewTextBoxColumn";
            this.postageDataGridViewTextBoxColumn.Width = 60;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "颜色";
            this.Color.Name = "Color";
            // 
            // ColorSold
            // 
            this.ColorSold.DataPropertyName = "ColorSold";
            this.ColorSold.HeaderText = "颜色销量";
            this.ColorSold.Name = "ColorSold";
            // 
            // itemNumberDataGridViewTextBoxColumn
            // 
            this.itemNumberDataGridViewTextBoxColumn.DataPropertyName = "ItemNumber";
            this.itemNumberDataGridViewTextBoxColumn.HeaderText = "ItemNumber";
            this.itemNumberDataGridViewTextBoxColumn.Name = "itemNumberDataGridViewTextBoxColumn";
            this.itemNumberDataGridViewTextBoxColumn.Width = 80;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.Width = 150;
            // 
            // sellerIdDataGridViewTextBoxColumn
            // 
            this.sellerIdDataGridViewTextBoxColumn.DataPropertyName = "SellerId";
            this.sellerIdDataGridViewTextBoxColumn.HeaderText = "SellerId";
            this.sellerIdDataGridViewTextBoxColumn.Name = "sellerIdDataGridViewTextBoxColumn";
            this.sellerIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // itemUrlDataGridViewTextBoxColumn
            // 
            this.itemUrlDataGridViewTextBoxColumn.DataPropertyName = "ItemUrl";
            this.itemUrlDataGridViewTextBoxColumn.HeaderText = "ItemUrl";
            this.itemUrlDataGridViewTextBoxColumn.Name = "itemUrlDataGridViewTextBoxColumn";
            this.itemUrlDataGridViewTextBoxColumn.Width = 255;
            // 
            // sellerShopUrlDataGridViewTextBoxColumn
            // 
            this.sellerShopUrlDataGridViewTextBoxColumn.DataPropertyName = "SellerShopUrl";
            this.sellerShopUrlDataGridViewTextBoxColumn.HeaderText = "SellerShopUrl";
            this.sellerShopUrlDataGridViewTextBoxColumn.Name = "sellerShopUrlDataGridViewTextBoxColumn";
            this.sellerShopUrlDataGridViewTextBoxColumn.Width = 400;
            // 
            // serchDateTimeDataGridViewTextBoxColumn
            // 
            this.serchDateTimeDataGridViewTextBoxColumn.DataPropertyName = "SerchDateTime";
            this.serchDateTimeDataGridViewTextBoxColumn.HeaderText = "SerchDate";
            this.serchDateTimeDataGridViewTextBoxColumn.Name = "serchDateTimeDataGridViewTextBoxColumn";
            this.serchDateTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // keyWordDataGridViewTextBoxColumn
            // 
            this.keyWordDataGridViewTextBoxColumn.DataPropertyName = "KeyWord";
            this.keyWordDataGridViewTextBoxColumn.HeaderText = "KeyWord";
            this.keyWordDataGridViewTextBoxColumn.Name = "keyWordDataGridViewTextBoxColumn";
            this.keyWordDataGridViewTextBoxColumn.Width = 400;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 519);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbQuery);
            this.Name = "FormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "搜索结果...";
            this.Load += new System.EventHandler(this.FormView_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tItemSerchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serchItemsDataSet)).EndInit();
            this.gbQuery.ResumeLayout(false);
            this.gbQuery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private KeyWordSerch.Data.SerchItemsDataSet serchItemsDataSet;
        private System.Windows.Forms.BindingSource tItemSerchResultBindingSource;
        private KeyWordSerch.Data.SerchItemsDataSetTableAdapters.T_ItemSerchResultTableAdapter t_ItemSerchResultTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbbKeyWord;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.Label lkeyWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbegindate;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReTry;
        private System.Windows.Forms.DataGridViewTextBoxColumn flagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSoldQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSoldByDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellerShopUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serchDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyWordDataGridViewTextBoxColumn;
    }
}