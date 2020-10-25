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
    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
        }
        //点击按钮，打开新窗体
        private void button1_Click(object sender, EventArgs e)
        {
            FormB formB = new FormB();
            //为窗体B绑定事件的处理函数
            formB.SetTxtEvent += SetTxt;
            formB.Show();
        }
        //Action<T>表示无返回值的委托类型
        //Func<T>表示有返回值的委托类型
        private void SetTxt(string txt1)
        {
            //用于事件处理的方法，将传递过来的值显示到文本框中
            textBox1.Text = txt1;
        }

        private void FormA_Load(object sender, EventArgs e)
        {

        }
    }
}
