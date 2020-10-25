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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ListViewItem itemTable;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.Tag.ToString() == "0")
            {
             menuManager.Visible = false;
            }
            LoadHallInfo();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //员工管理
        private void menuManager_Click(object sender, EventArgs e)
        {
            //单例实现1
            ManagerInfoList miList = FormFactory.CreateMIL();
            miList.Show();
            miList.Focus();
        }
        //会员管理
        private void menuMember_Click(object sender, EventArgs e)
        {
            //单例实现2
            MemberInfoList miList = MemberInfoList.Create();
            miList.Show();
            miList.Focus();
        }

        private void menuDish_Click(object sender, EventArgs e)
        {
            DishInfoList diList = FormFactory.GreateDIL();
            diList.Show();
            diList.Focus();
        }

        private void menuTable_Click(object sender, EventArgs e)
        {
            TableInfoList tiList = FormFactory.GreateTIL();
            tiList.Show();
            tiList.Focus();
        }
        private void LoadHallInfo()
        {
            HallInfoBll hiBll = new HallInfoBll();
            var list = hiBll.GetList();
            foreach(var hallInfo in list)
            {
                TabPage page = new TabPage(hallInfo.HTitle);
                page.Tag = hallInfo.HId;
                tabControl1.TabPages.Add(page);
            }

            tabControl1_SelectedIndexChanged(null, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //操作过程：选择一个tabPage，然后根据当前选中的TabPage存储的厅包编号，查找里面的餐桌
            //然后创建ListView，加入所有的餐桌，再讲ListView加到当前选中的TabPage中
            //1/获取选中的tabPage
            var tabPage = tabControl1.SelectedTab;
            int hallId = Convert.ToInt32(tabPage.Tag);

            //2、查询餐桌
            TableInfo tiSearch = new TableInfo();
            tiSearch.THallId = hallId;//厅包的条件
            tiSearch.IsFreeSearch = -1;//空闲状态的要求，-1表示全部
            TableInfoBll tiBll = new TableInfoBll();
            var listTableInfo = tiBll.GetList(tiSearch);

            //3、创建ListView，加入项
            ListView listView = new ListView();
            listView.LargeImageList = imageList1;
            listView.Dock = DockStyle.Fill;
            listView.MultiSelect = false;

            //为ListView绑定双击事件，以获得被双击的项，从而完成点菜
            listView.DoubleClick += listview_DoubleClick;
            //为ListView绑定单击事件，以获得被选中的餐桌，用于结账
            listView.Click += ListView_Click;
            foreach (var tableInfo in listTableInfo)
            {
                ListViewItem item = new ListViewItem(tableInfo.TTitle, tableInfo.TIsFree ? 0 : 1);
                item.Tag = tableInfo.TId;
                listView.Items.Add(item);
            }

            //4、将ListView加入当前选中的TabPage
            tabPage.Controls.Add(listView);
            
        }

        private void ListView_Click(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            itemTable = listView.SelectedItems[0];
        }

        private void listview_DoubleClick(object sender, EventArgs e)
        {
            //得到双击的listview
            ListView listView = sender as ListView;
            //当项被双击后，会被选择，得到当前选择的ListViewItem
            ListViewItem item = listView.SelectedItems[0];
            int tableId = Convert.ToInt32(item.Tag);

            //如果当前餐桌是空闲状态，则进行开单操作
            if (item.ImageIndex == 0)
            {
                OrderInfoBll oiBll = new OrderInfoBll();
                if (oiBll.KaiDan(tableId))
                {
                    //将当前餐桌的状态改为占用
                    item.ImageIndex = 1;
                }
            }
            else
            {
                //如果不是空闲状态，则进行加菜操作
            }
            //打开点菜窗体
            OrderInfoList orderInfoList = new OrderInfoList();
            orderInfoList.Tag = tableId;//将餐桌编号传递过去，用于进行订单编号的查找
            orderInfoList.Show();

        }

        private void menuOrder_Click(object sender, EventArgs e)
        {
            //如果没有餐桌选中，则提示
            if (itemTable == null)
            {
                MessageBox.Show("请选择要结账的餐桌！！！");
                return;
            }
            //判断当前选中的餐桌是否为空闲，如果是不则需要结账
            if (itemTable.ImageIndex == 0)
            {
                MessageBox.Show("当前餐桌并未开单，无需结账！！！");
                return;
            }
            OrderPay orderPay = FormFactory.GreateOP();
            orderPay.Tag = itemTable.Tag;
            orderPay.SetTableFreeEvent += SetTableFree;
            orderPay.Show();
            orderPay.Focus();
        }
        private void SetTableFree()
        {
            itemTable.ImageIndex = 0;
        }
    }
}
