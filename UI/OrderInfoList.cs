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
    public partial class OrderInfoList : Form
    {
        public OrderInfoList()
        {
            InitializeComponent();
        }
        private OrderInfoBll oiBll = new OrderInfoBll();
        private int orderId;
        private void OrderInfoList_Load(object sender, EventArgs e)
        {
            //获取传递过来的餐桌编号
            int tableId = Convert.ToInt32(Tag);
            this.Text = tableId.ToString();
            //根据餐桌编号，查找订单编号
            orderId = oiBll.GetOidByTid(tableId);
            //加载所有的菜品信息
            LoadDishInfo();
            LoadDishTypeInfo();
            LoadOrderList();
        }

        private void LoadDishInfo()
        {
            DishInfo di = new DishInfo();
            di.DChar = textBox1.Text;
            di.DTypeId = Convert.ToInt32(comboBox1.SelectedValue);
            DishInfoBll diBll = new DishInfoBll();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = diBll.GetList(di);
            
        }
        private void LoadDishTypeInfo()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();
            var list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });
            comboBox1.DisplayMember = "DTitle";
            comboBox1.ValueMember = "DId";
            comboBox1.DataSource = list;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int dishId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            if (oiBll.DianCai(orderId, dishId))
            {
                LoadOrderList();
            }
        }
        private void LoadOrderList()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = oiBll.GetOrderDetail(orderId);
            GetOrderMoney();
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView2.Rows[e.RowIndex];
            int oid = Convert.ToInt32(row.Cells[0].Value);
            int count= Convert.ToInt32(row.Cells[2].Value);
            if (oiBll.UpdateDishCount(oid, count))
            {
                GetOrderMoney();
            }
        }
        private void GetOrderMoney()
        {
            decimal total = 0;
            var rows = dataGridView2.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                int count = Convert.ToInt32(rows[i].Cells[2].Value);
                decimal price = Convert.ToDecimal(rows[i].Cells[3].Value);
                total += count * price;
            }
            lbMoney.Text = total.ToString();
        }

        private void buttonshanchu_Click(object sender, EventArgs e)
        {
            var row = dataGridView2.SelectedRows[0];
            int oid = Convert.ToInt32(row.Cells[0].Value);
            if (oiBll.DeleteDish(oid))
            {
                LoadOrderList();
            }
        }

        private void buttonxiadan_Click(object sender, EventArgs e)
        {
            decimal totalMoney = Convert.ToDecimal(lbMoney.Text);
            if (oiBll.XiaDan(orderId, totalMoney))
            {
                this.Close();
            }
        }
    }
}
