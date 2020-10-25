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
    public partial class OrderPay : Form
    {
        public OrderPay()
        {
            InitializeComponent();
        }

        private OrderInfoBll oiBll = new OrderInfoBll();
        private void OrderPay_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            this.Text="为【"+this.Tag+"】餐桌结账付款";
            lbxfjine.Text = oiBll.GetMoneyByTid(Convert.ToInt32(this.Tag)).ToString();
            lbysjine.Text = lbxfjine.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBox1.Checked;
            if (!checkBox1.Checked)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                lbyue.Text = "0";
                lbdengji.Text = "普通会员";
                lbzhekou.Text = "1";
                lbysjine.Text = lbxfjine.Text;
                checkBox2.Checked = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            GetMemberInfo();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            GetMemberInfo();
        }
        private void GetMemberInfo()
        {
            MemberInfo mi = new MemberInfo();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                mi.MId = Convert.ToInt32(textBox1.Text);
            }
            mi.MPhone = textBox2.Text;
            MemberInfoBll miBll = new MemberInfoBll();
            var list = miBll.GetList(mi);
            if (list.Count == 1)
            {
                mi = list[0];
                textBox1.Text = mi.MId.ToString();
                textBox2.Text = mi.MPhone;
                lbyue.Text = mi.MMoney.ToString();
                lbdengji.Text = mi.TypeTitle;
                lbzhekou.Text = mi.TypeDiscount.ToString();
                //根据折扣，更新应付折扣金额的值
                decimal payMoneyDiscount = mi.TypeDiscount * Convert.ToDecimal(lbxfjine.Text);
                lbysjine.Text = payMoneyDiscount.ToString();
            }
            else MessageBox.Show("会员信息有误，请核对！！！");
        }
        public event Action SetTableFreeEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            //已知数据：餐桌编号tableid
            //需要的数据：会员编号，折扣，折扣金额
            //获取餐桌编号
            int tableId = Convert.ToInt32(this.Tag);
            //如果使用会员，则获取会员编号及折扣，否则编号为0
            //会员编号为0时，不是不使用会员信息
            int memberId = 0;
            decimal discount = 0;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                memberId = int.Parse(textBox1.Text);
                discount = Convert.ToDecimal(lbzhekou.Text);
            }
            //结账金额
            //如果不使用余额结账，则payMoney为0
            decimal payMoney = 0;
            if (checkBox2.Checked)
            {
                //如果使余额结账，则判断：
                decimal totalMoney = decimal.Parse(lbyue.Text);
                decimal payDiscount = decimal.Parse(lbysjine.Text);
                //余额大于应付，则传递应付
                if (totalMoney > payDiscount)
                {
                    payMoney = payDiscount;
                }
                //如果余额较小，则传递余额，是会员余额不会小于0
                else payMoney = totalMoney;
            }
            if (oiBll.JieZhang(tableId, memberId, discount, payMoney))
            {
                //4、更改结账的餐桌的状态图片
                SetTableFreeEvent();
                MessageBox.Show("结账成功，欢迎下次光临!!!");
                this.Close();
            }
            else MessageBox.Show("结账失败！！！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
