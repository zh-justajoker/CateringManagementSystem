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
    public partial class HallInfoList : Form
    {
        public HallInfoList()
        {
            InitializeComponent();
        }
        private HallInfoBll hiBll = new HallInfoBll();
        public event Action RefreshHallEvent;
        private void HallInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = hiBll.GetList();
        }
        //添加\修改
        private void button1_Click(object sender, EventArgs e)
        {
            HallInfo hi = new HallInfo();
            hi.HTitle = textBox1.Text;
            if (button1.Text.Equals("添加"))
            {
                //添加
                if (hiBll.Add(hi))
                {
                    button2_Click(null, null);
                    LoadList();
                    RefreshHallEvent();
                }
                else MessageBox.Show("添加失败，请稍后重试！！！");

            }
            else
            {
                hi.HId = Convert.ToInt32(textBox3.Text);
                //修改
                if (hiBll.Edit(hi))
                {
                    button2_Click(null, null);
                    LoadList();
                    RefreshHallEvent();
                }
                else MessageBox.Show("修改失败，请稍后重试！！！");
            }
        }
        //取消操作
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "添加时无编号";
            button1.Text = "添加";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBox3.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            button1.Text = "修改";
        }
        //删除操作
        private void button3_Click(object sender, EventArgs e)
        {
            var row1 = dataGridView1.SelectedRows;
            if (row1.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = Convert.ToInt32(row1[0].Cells[0].Value);
                    if (hiBll.Remove(id))
                    {
                        LoadList();
                        RefreshHallEvent();
                    }
                    else MessageBox.Show("删除失败，请稍后重试！！！");
                }
            }
            else MessageBox.Show("请选中这一行！！！");
        }

    }
}
