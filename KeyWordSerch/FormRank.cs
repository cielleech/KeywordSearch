using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KeyWordSerch.Data.SerchItemsDataSetTableAdapters;
using KeyWordSerch.Data;

namespace KeyWordSerch
{
    public partial class FormRank : FormBase
    {
        public FormRank()
        {
            InitializeComponent();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            DataManager dm = new DataManager();
            dataGridView1.DataSource = dm.GetRank(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
        }



        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataManager dm = new DataManager();
            dataGridView1.DataSource = dm.GetRank(dtpBeginDate.Value.AddDays(-1).ToString("yyyy-MM-dd"));
        }
    }
}