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
    public partial class FormB : Form
    {
        public FormB()
        {
            InitializeComponent();
        }
        public event Action<string> SetTxtEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            //调用事件，事件中绑定的所有方法都会被执行
            SetTxtEvent(textBox1.Text);
        }

        private void FormB_Load(object sender, EventArgs e)
        {

        }
    }
}
