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
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
        }
        //退出
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo();
            mi.MName = textBox1.Text;
            mi.MPwd = textBox2.Text;
            ManagerInfoBll miBll = new ManagerInfoBll();
            if (miBll.Login(mi))
            {
                MainForm mainForm = new MainForm();
                mainForm.Tag = mi.MType;
                mainForm.Show();
                this.Visible = false;
            }
            else MessageBox.Show("用户名或密码错误！！！");
        }

       
    }
}
