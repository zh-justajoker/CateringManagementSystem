using Bll;
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
    public partial class TabControlTest : Form
    {
        public TabControlTest()
        {
            InitializeComponent();
        }

        private void TabControlTest_Load(object sender, EventArgs e)
        {
            //查询厅包表
            HallInfoBll hiBll = new HallInfoBll();
            var list = hiBll.GetList();
            //遍历集合，向tabcontrol中添加页
            foreach (var hallInfo in list)
            {
                var tabPage = new TabPage(hallInfo.HTitle);
                //tabPage.Controls.Add()
                tabControl1.TabPages.Add(tabPage);
            }
        }
    }
}
