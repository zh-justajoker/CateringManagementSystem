using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.International.Converters.PinYinConverter;

namespace UI.test
{
    public partial class PinyinTest : Form
    {
        public PinyinTest()
        {
            InitializeComponent();
        }

        private void PinyinTest_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = PinyinHelper.GetPinyin(textBox1.Text);
            /*//清空文本字符串
            label1.Text = "";
            //获取用户输入的字符串
            string txt = textBox1.Text;
            //逐个遍历字符，获取对应的拼音
            foreach (char c in txt)
            {
                //判断指定的字符，是否是汉字
                if (ChineseChar.IsValidChar(c))
                {
                    //是汉字，则构造字符对象
                    ChineseChar cc = new ChineseChar(c);
                    //拼接返回的是集合，因为存在多音字的情况
                    //foreach (var c1 in cc.Pinyins)
                    //{
                    //    label1.Text += c1 + " ";
                    //}
                    //获取拼音首字母
                    label1.Text += cc.Pinyins[0][0];
                }
                else label1.Text += c;//不是汉字，直接拼接
               
            }*/
        }
    }
}
