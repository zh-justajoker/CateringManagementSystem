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

namespace UI.test
{
    public partial class ListViewTest : Form
    {
        public ListViewTest()
        {
            InitializeComponent();
        }

        private void ListViewTest_Load(object sender, EventArgs e)
        {
            //构造查询条件
            TableInfo tiSearch = new TableInfo();
            tiSearch.THallId = 0;
            tiSearch.IsFreeSearch = -1;
            //查询餐桌数据
            TableInfoBll tiBll = new TableInfoBll();
            var list = tiBll.GetList(tiSearch);
            //遍历数据，构造列表项，并加入列表中
            foreach(var ti in list)
            {
                //在创建列表项时，根据使用状态设置图片
                ListViewItem item = new ListViewItem(ti.TTitle, ti.TIsFree ? 1 : 0);
                listView1.Items.Add(item);
            }
        }
    }
}
