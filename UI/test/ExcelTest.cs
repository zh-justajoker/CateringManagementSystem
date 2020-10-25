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
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using Model;

namespace UI.test
{
    public partial class ExcelTest : Form
    {
        public ExcelTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //导出：将数据库中的数据，存储到一个Excel中
            //1、查询数据
            ManagerInfoBll miBll = new ManagerInfoBll();
            var list = miBll.GetList();
            //2、生成Excel
            //2.1 生成workbook
            //2.2 生成sheet
            //2.3 遍历集合，生成行
            //2.4 根据对象生成单元格
            //创建工作本
            HSSFWorkbook workbook = new HSSFWorkbook();
            //创建工作表
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("管理员");
            //创建标题行
            HSSFRow row = (HSSFRow)sheet.CreateRow(0);
            //样式操作
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment= NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            //设置字体
            var font = workbook.CreateFont();
            font.FontHeightInPoints = 16;
            font.Boldweight = 1;
            style.SetFont(font);
            //创建单元格
            HSSFCell cellId = (HSSFCell)row.CreateCell(0);
            cellId.CellStyle = style;
            cellId.SetCellValue("编号");
            HSSFCell cellName = (HSSFCell)row.CreateCell(1);
            cellName.SetCellValue("用户名");
            cellName.CellStyle = style;
            HSSFCell cellPwd = (HSSFCell)row.CreateCell(2);
            cellPwd.SetCellValue("密码");
            cellPwd.CellStyle = style;
            HSSFCell cellType = (HSSFCell)row.CreateCell(3);
            cellType.SetCellValue("类型");
            cellType.CellStyle = style;

            //遍历集合，生成行
            int index = 1;
            foreach (var item in list)
            {
                var row1 = sheet.CreateRow(index++);
                var cell0 = row1.CreateCell(0);
                cell0.SetCellValue(item.MId);
                var cell1 = row1.CreateCell(1);
                cell1.SetCellValue(item.MName);
                var cell2 = row1.CreateCell(2);
                cell2.SetCellValue(item.MPwd);
                var cell3 = row1.CreateCell(3);
                cell3.SetCellValue(item.MType == 0 ? "店员" : "经理");
            }

            FileStream file = new FileStream(@"D:\database\a.xls",FileMode.Create,FileAccess.Write);
            workbook.Write(file);
            file.Dispose();
            MessageBox.Show("OK");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(@"D:\database\a.xls", FileMode.Open, FileAccess.Read);
            //根据文件流创建工作本
            HSSFWorkbook workbook = new HSSFWorkbook(file);
            //读取sheet
            var sheet= workbook.GetSheetAt(0);
            //逐行读取数据
            List<ManagerInfo> list = new List<ManagerInfo>();
            var index = sheet.LastRowNum;
            for (int i = 1; i <= index; i++)
            {
                HSSFRow row = (HSSFRow)sheet.GetRow(i);
                ManagerInfo mi = new ManagerInfo();
                //获取单元格数
                mi.MId = Convert.ToInt32(row.GetCell(0).NumericCellValue);
                mi.MName = row.GetCell(1).StringCellValue;
                mi.MPwd = row.GetCell(2).StringCellValue;
                mi.MType = row.GetCell(3).StringCellValue.Equals("经理") ? 1 : 0;
                list.Add(mi);
            }
            dataGridView1.DataSource = list;
            file.Dispose();
        }
    }
}
