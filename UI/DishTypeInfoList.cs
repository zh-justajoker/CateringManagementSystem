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
    public partial class DishTypeInfoList : Form
    {
        public DishTypeInfoList()
        {
            InitializeComponent();
        }
        private DishTypeInfoBll dtiBll = new DishTypeInfoBll();
        public event Action UpdateTypeEvent;
        private void DishTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtiBll.GetList();
        }
        //添加\修改
        private void button1_Click(object sender, EventArgs e)
        {
            DishTypeInfo dti = new DishTypeInfo();
            dti.DTitle = textBox1.Text;
            if (button1.Text.Equals("添加"))
            {
                //添加
                if (dtiBll.Add(dti))
                {
                    button2_Click(null, null);
                    LoadList();
                    UpdateTypeEvent();
                }
                else MessageBox.Show("添加失败，请稍后重试");
            }
            else
            {
                //修改
                dti.DId = Convert.ToInt32(textBox3.Text);
                if (dtiBll.Edit(dti))
                {
                    button2_Click(null, null);
                    LoadList();
                    UpdateTypeEvent();
                }
                else MessageBox.Show("修改失败，请稍后重试");
            }
        }

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
        
        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = Convert.ToInt32(rows[0].Cells[0].Value);
                    if (dtiBll.Remove(id))
                    {
                        LoadList();
                        UpdateTypeEvent();
                    }
                    else MessageBox.Show("删除失败，请稍后重试");
                }
                else MessageBox.Show("请先选择行！！！");
            }
        }
    }
}
