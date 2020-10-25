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
    public partial class ManagerInfoList : Form
    {
        public ManagerInfoList()
        {
            InitializeComponent();
        }

        ManagerInfoBll miBll = new ManagerInfoBll();
        private void ManagerInfoList_Load(object sender, EventArgs e)
        {

            #region 原来的代码
            ////1、创建连接对象
            //string constr = ConfigurationManager.ConnectionStrings["cater"].ConnectionString;
            //using (SQLiteConnection conn = new SQLiteConnection(constr))
            //{
            //    //2、构造command对象
            //    string sql = "select * from managerinfo";
            //    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            //    //3、打开、执行命令
            //    conn.Open();
            //    SQLiteDataReader reader = cmd.ExecuteReader();
            //    //4、读取结果
            //    List<ManagerInfo> list = new List<ManagerInfo>();
            //    while (reader.Read())
            //    {
            //        list.Add(new ManagerInfo()
            //        {
            //            MId = Convert.ToInt32(reader["MId"]),
            //            MName = reader["MName"].ToString(),
            //            MPwd = reader["MPwd"].ToString(),
            //            MType=Convert.ToInt32(reader["MType"])
            //        });
            //    }
            //    //5、使用
            //    dataGridView1.DataSource = list;
            //}
            #endregion
            #region 新版三层代码
            LoadList();
            #endregion
        }
        void LoadList()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = miBll.GetList();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "经理";
                        break;
                    case "0":
                        e.Value = "店员";
                        break;
                }
            }
        }
        //添加操作
        private void button1_Click(object sender, EventArgs e)
        {
            //接收控件的值，用于构造对象
            ManagerInfo mi = new ManagerInfo()
            {
                MName = textBox1.Text,
                MPwd = textBox2.Text,
                MType = radioButton1.Checked ? 1 : 0
            };
            //判断当前是要进行添加操作，还是要进行修改操作
            if (button1.Text == "添加")
            {
                if (miBll.Add(mi))
                {
                    button2_Click(null, null);
                    LoadList();
                    MessageBox.Show("添加成功");
                }
                else MessageBox.Show("添加失败，请重试！！！");
            }
            else
            {
                mi.MId = Convert.ToInt32(textBox3.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                    MessageBox.Show("修改成功");
                }
                else MessageBox.Show("修改失败，请稍后重试！！！");
            }
        }
        
        //取消操作
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "添加时无编号";
            textBox1.Text = "";
            textBox2.Text = "";
            radioButton2.Checked = true;
            button1.Text = "添加";
        }
        //删除操作
        private void button3_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int id = Convert.ToInt32(rows[0].Cells[0].Value);
                    if (miBll.Remove(id))
                    {
                        LoadList();
                    }
                    else MessageBox.Show("删除失败，请稍后重试！！！");
                }
            }
            else MessageBox.Show("还没选中要选中的行！！！");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //当双击单元格时，将内容显示到控件，以备修改
            var row = dataGridView1.Rows[e.RowIndex];
            textBox3.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = "******";
            if (row.Cells[2].Value.ToString() == "1")
            {
                radioButton1.Checked = true;
            }
            else radioButton2.Checked = true;
            button1.Text = "修改";
        }

        
    }
}
