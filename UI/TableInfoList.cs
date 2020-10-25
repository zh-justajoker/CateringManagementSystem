using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class TableInfoList : Form
    {
        public TableInfoList()
        {
            InitializeComponent();
        }

        private TableInfoBll tiBll = new TableInfoBll();
        private void TableInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadSearch();
        }
        private void LoadSearch()
        {
            HallInfoBll hiBll = new HallInfoBll();
            var list = hiBll.GetList();
            list.Insert(0, new HallInfo()
            {
                HId = 0,
                HTitle = "全部"
            });
            comboBox3.DisplayMember = "HTitle";
            comboBox3.ValueMember = "HId";
            comboBox3.DataSource = list;

            comboBox1.DisplayMember = "HTitle";
            comboBox1.ValueMember = "HId";
            comboBox1.DataSource = hiBll.GetList();

            List<TableState> listState = new List<TableState>();
            listState.Add(new TableState(-1, "全部"));
            listState.Add(new TableState(0, "非空闲"));
            listState.Add(new TableState(1, "空闲"));
            comboBox2.DisplayMember = "Title";
            comboBox2.ValueMember = "State";
            comboBox2.DataSource = listState;
        }

        private void LoadList()
        {
            TableInfo ti = new TableInfo();
            ti.THallId = Convert.ToInt32(comboBox3.SelectedValue);
            ti.IsFreeSearch= Convert.ToInt32(comboBox2.SelectedValue);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = tiBll.GetList(ti);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Convert.ToBoolean(e.Value)) e.Value = "是";
                else e.Value = "否";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void buttonxianshi_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            LoadList();
        }
        //取消操作
        private void buttoncancel_Click(object sender, EventArgs e)
        {
            textBh.Text = "添加时无编号";
            textXm.Text = "";
            comboBox1.SelectedIndex = 0;
            radioButton1.Checked = true;
            buttonadd.Text = "添加";
        }
        //添加\修改
        private void buttonadd_Click(object sender, EventArgs e)
        {
            TableInfo ti = new TableInfo();
            ti.TTitle = textXm.Text;
            ti.THallId = Convert.ToInt32(comboBox1.SelectedValue);
            ti.TIsFree = radioButton1.Checked;
            if (buttonadd.Text.Equals("添加"))
            {
                //添加
                if (tiBll.Add(ti))
                {
                    buttoncancel_Click(null, null);
                    LoadList();
                }
                else MessageBox.Show("添加失败，请稍后重试！！！");
            }
            else
            {
                //修改
                ti.TId = Convert.ToInt32(textBh.Text);
                if (tiBll.Edit(ti))
                {
                    buttoncancel_Click(null, null);
                    LoadList();
                }
                else MessageBox.Show("修改失败，请稍后重试！！！");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBh.Text = row.Cells[0].Value.ToString();
            textXm.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            if (Convert.ToBoolean(row.Cells[3].Value))
            {
                radioButton1.Checked = true;
            }
            else radioButton2.Checked = true;
            buttonadd.Text = "修改";
        }

        //删除操作
        private void buttonshanchu_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = Convert.ToInt32(rows[0].Cells[0].Value);
                    if (tiBll.Remove(id))
                    {
                        LoadList();
                    }
                    else MessageBox.Show("删除失败，请稍后重试！！！");
                }
            }
            else MessageBox.Show("请重新选择行！！！");
        }
        //厅包管理
        private void buttonfenlei_Click(object sender, EventArgs e)
        {
            HallInfoList hiList = new HallInfoList();
            hiList.RefreshHallEvent += RefreshHallInfo;
            hiList.Show();
        }

        private void RefreshHallInfo()
        {
            LoadList();
            LoadSearch();
        }
    }
}
