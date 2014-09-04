using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KeyWordSerch.Data.SerchItemsDataSetTableAdapters;

namespace KeyWordSerch
{
    public partial class FormView : FormBase
    {
        public FormView()
        {
            InitializeComponent();
            if (PubConst.Level == 2)
            {
                sellerShopUrlDataGridViewTextBoxColumn.Visible = false;
                itemSoldQuantityDataGridViewTextBoxColumn.Visible = false;
            }
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            // TODO: 这行代码将数据加载到表“serchItemsDataSet.T_ItemSerchResult”中。您可以根据需要移动或移除它。
            this.t_ItemSerchResultTableAdapter.FillByInterval(this.serchItemsDataSet.T_ItemSerchResult, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"));
            T_KeyWordsTableAdapter keyAdapter = new T_KeyWordsTableAdapter();
            DataTable table = keyAdapter.GetData();
            foreach (DataRow row in table.Rows)
            {
                string k = row[1].ToString();
                cbbKeyWord.Items.Add(k);
            }
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "itemTitleDataGridViewTextBoxColumn")
            {
                int Flag = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["flagDataGridViewTextBoxColumn"].Value);
                if (Flag > 0 && Flag < 3)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "itemUrlDataGridViewTextBoxColumn")
            {
                string target = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (!string.IsNullOrEmpty(target))
                {
                    Process.Start(target);
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "sellerShopUrlDataGridViewTextBoxColumn")
            {
                string target = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (!string.IsNullOrEmpty(target))
                {
                    Process.Start(target);
                }

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "itemTitleDataGridViewTextBoxColumn")
            {
                string target = dataGridView1.Rows[e.RowIndex].Cells["itemUrlDataGridViewTextBoxColumn"].Value.ToString();
                if (!string.IsNullOrEmpty(target))
                {
                    Process.Start(target);
                }

            }
        }

        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable table = serchItemsDataSet.T_ItemSerchResult.GetChanges();
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    if (MessageBox.Show("数据已改动,是否保存?", "请确认...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        tItemSerchResultBindingSource.EndEdit();

                        t_ItemSerchResultTableAdapter.Update(serchItemsDataSet.T_ItemSerchResult);
                    }
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string keyWord = cbbKeyWord.Text;
            string beginDate = dtpBeginDate.Value.ToString("yyyyMMdd");
            string endDate = dtpEndDate.Value.ToString("yyyyMMdd");
            if (!string.IsNullOrEmpty(keyWord))
            {
                this.t_ItemSerchResultTableAdapter.FillByKeyWordAndInterVal(this.serchItemsDataSet.T_ItemSerchResult, beginDate, endDate, keyWord);
            }
            else
            {
                this.t_ItemSerchResultTableAdapter.FillByInterval(this.serchItemsDataSet.T_ItemSerchResult, beginDate, endDate);
            }
        }
    }
}