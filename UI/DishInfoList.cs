using Bll;
using Common;
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
    public partial class DishInfoList : Form
    {
        public DishInfoList()
        {
            InitializeComponent();
        }
        private DishInfoBll diBll = new DishInfoBll();
        private void DishInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }

        private void LoadList()
        {
            DishInfo di = new DishInfo();
            if (!string.IsNullOrEmpty(textXms.Text))
            {
                di.DTitle = textXms.Text;
            }
            di.DTypeId = Convert.ToInt32(comboBox2.SelectedValue);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = diBll.GetList(di);
        }
        private void LoadTypeList()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();
            //绑定添加与修改的分类
            comboBox1.DisplayMember = "DTitle";
            comboBox1.ValueMember = "DId";
            comboBox1.DataSource = dtiBll.GetList();
            //绑定查询的分类
            var list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });
            comboBox2.DisplayMember = "DTitle";
            comboBox2.ValueMember = "DId";
            comboBox2.DataSource = list;
        }

        //添加\修改操作
        private void buttonadd_Click(object sender, EventArgs e)
        {
            DishInfo di = new DishInfo();
            di.DTitle = textXmt.Text;
            di.DTypeId= Convert.ToInt32(comboBox1.SelectedValue);
            di.DPrice = Convert.ToDecimal(textjg.Text);
            di.DChar = textpy.Text;
            if (buttonadd.Text.Equals("添加"))
            {
                //添加
                if (diBll.Add(di))
                {
                   
                }
                else MessageBox.Show("添加失败，请稍后重试！！！");
            }
            else
            {
                //修改
                di.DId = Convert.ToInt32(textBh.Text);
                if (diBll.Edit(di))
                {
                    buttoncancel_Click(null, null);
                    LoadList();
                }
                else MessageBox.Show("修改失败，请稍后重试！！！");
            }
        }

        private void textXmt_Leave(object sender, EventArgs e)
        {
            textpy.Text = PinyinHelper.GetPinyin(textXmt.Text);
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            textBh.Text = "添加时无编号";
            textXmt.Text = "";
            textjg.Text = "";
            textpy.Text = "";
            comboBox1.SelectedIndex = 0;
            buttonadd.Text = "添加";
        }

        //双击修改
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBh.Text = row.Cells[0].Value.ToString();
            textXmt.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            textjg.Text = row.Cells[3].Value.ToString();
            textpy.Text = row.Cells[4].Value.ToString();
            buttonadd.Text = "修改";
        }

        //删除操作
        private void buttonshanchu_Click(object sender, EventArgs e)
        {
            var rows= dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = Convert.ToInt32(rows[0].Cells[0].Value);
                    if (diBll.Remove(id))
                    {
                        LoadList();
                    }
                    else MessageBox.Show("删除失败，请稍后重试！！！");
                }
            }
            else MessageBox.Show("请先选择行！！！");
        }
        //分类管理
        private void buttonfenlei_Click(object sender, EventArgs e)
        {
            DishTypeInfoList dtiList = new DishTypeInfoList();
            dtiList.UpdateTypeEvent += UpdateType;
            dtiList.Show();
        }
        private void UpdateType()
        {
            LoadList();
            LoadTypeList();
        }

        private void textXms_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void buttonxianshi_Click(object sender, EventArgs e)
        {
            textXms.Text = "";
            comboBox2.SelectedIndex = 0;
            LoadList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
