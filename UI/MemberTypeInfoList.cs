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
    public partial class MemberTypeInfoList : Form
    {
        public MemberTypeInfoList()
        {
            InitializeComponent();
        }
        private MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
        private void MemberTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = mtiBll.GetList();
        }

        //确认或修该
        private void button1_Click(object sender, EventArgs e)
        {
            //根据输入，构造对象
            MemberTypeInfo mti = new MemberTypeInfo()
            {
                MTitle = textBox1.Text,
                MDiscount = Convert.ToDecimal(textBox2.Text)
            };
            if (button1.Text.Equals("添加"))
            {
                //添加逻辑
                if (mtiBll.Add(mti))
                {
                    button2_Click(null, null);
                    LoadList();
                    UpdateTypeEvent();
                }
                else MessageBox.Show("添加失败，请稍后重试！！！");
            }
            else
            {
                //修改逻辑
                mti.MId = Convert.ToInt32(textBox3.Text);
                if (mtiBll.Edit(mti))
                {
                    button2_Click(null, null);
                    LoadList();
                    UpdateTypeEvent();
                }
                else MessageBox.Show("修改失败，请重试！！！");
            }
        }
        //取消操作
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "添加时无编号";
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Text = "添加";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取双击的单元格所在的行
            var row = dataGridView1.Rows[e.RowIndex];
            //将行中的数组显示到控件中
            textBox3.Text = row.Cells["MId"].Value.ToString();
            textBox1.Text = row.Cells["MTitle"].Value.ToString();
            textBox2.Text = row.Cells["MDiscount"].Value.ToString();
            button1.Text = "修改";
        }
        //删除操作
        private void button3_Click(object sender, EventArgs e)
        {
            //获取选中的行，找到对应的编号
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (mtiBll.Remove(id))
                    {
                        LoadList();
                        UpdateTypeEvent();
                    }
                    else MessageBox.Show("删除失败，请稍后重试！！！");
                }
            }
            else MessageBox.Show("请选择要删除的数据");
        }
        public event Action UpdateTypeEvent;
    }
}
