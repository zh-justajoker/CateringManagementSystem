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
    public partial class MemberInfoList : Form
    {
        //将构造方法变成私有
        private MemberInfoList()
        {
            InitializeComponent();
        }
        //通过指定的方式来创建窗体对象
        private static MemberInfoList mil;
        public static MemberInfoList Create()
        {
            //判断是否不存在
            if (mil == null)
            {
                //新建对象
                mil = new MemberInfoList();
            }
            //返回对象
            return mil;
        }
        private MemberInfoBll miBll = new MemberInfoBll();
        private void MemberInfoList_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }
        private void LoadList()
        {
            MemberInfo mi = new MemberInfo();
            mi.MName = textXms.Text;
            mi.MPhone = textSjs.Text;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = miBll.GetList(mi);

        }
        private void LoadTypeList()
        {
            //获取会员分类对象，查询会员分类信息
            MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
            List<MemberTypeInfo> list = mtiBll.GetList();
            //将会员信息绑定到控件上
            comboBox1.DisplayMember = "MTitle";//显示的属性
            comboBox1.ValueMember = "MId";//用于存储值得属性
            comboBox1.DataSource = list;
        }

        //添加\修改操作
        private void buttontianjia_Click(object sender, EventArgs e)
        {
            MemberInfo mi = new MemberInfo();
            mi.MName = textXmt.Text;
            mi.MMoney = Convert.ToDecimal(textMoney.Text);
            mi.MPhone = textSjt.Text;
            mi.MTypeId = Convert.ToInt32(comboBox1.SelectedValue);
            if (buttontianjia.Text.Equals("添加"))
            {
                //添加
                if (miBll.Add(mi))
                {
                    buttonquxiao_Click(null, null);
                    LoadList();
                }
                else MessageBox.Show("添加失败，请稍后重试！！！");
            }
            else
            {
                //修改
                mi.MId = Convert.ToInt32(textBh.Text);
                if (miBll.Edit(mi))
                {
                    buttonquxiao_Click(null, null);
                    LoadList();
                }
                else MessageBox.Show("修改失败，请稍后重试！！！");
            }
        }

        private void buttonquxiao_Click(object sender, EventArgs e)
        {
            textBh.Text = "添加时无编号";
            textXmt.Text = "";
            textMoney.Text = "";
            textSjt.Text = "";
            comboBox1.SelectedIndex = 0;
            buttontianjia.Text = "添加";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBh.Text = row.Cells[0].Value.ToString();
            textXmt.Text = row.Cells[1].Value.ToString();
            textSjt.Text = row.Cells[3].Value.ToString();
            textMoney.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            buttontianjia.Text = "修改";
        }

        private void buttonxianshi_Click(object sender, EventArgs e)
        {
            textXms.Text = "";
            textSjs.Text = "";
            LoadList();
        }

        private void textXms_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void textSjs_Leave(object sender, EventArgs e)
        {
            LoadList();
        }
        //删除操作
        private void buttonshanchu_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (miBll.Remove(id))
                    {
                        LoadList();
                    }
                    else MessageBox.Show("删除失败，请稍后重试！！！");
                }
            }
            else MessageBox.Show("请选择一行进行删除！！！");
        }

        private void buttonleixing_Click(object sender, EventArgs e)
        {
            MemberTypeInfoList mtiList = new MemberTypeInfoList();
            mtiList.UpdateTypeEvent += UpdateType;
            mtiList.Show();
        }

        private void MemberInfoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            mil = null;
        }
        private void UpdateType()
        {
            LoadList();
            LoadTypeList();
        }
    }
}
