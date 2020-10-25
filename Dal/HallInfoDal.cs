using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class HallInfoDal
    {
        public List<HallInfo> GetList()
        {
            string sql = "select * from HallInfo where HIsDelete=0";
            DataTable dt = SqliteHelper.GteList(sql);
            List<HallInfo> list = new List<HallInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HallInfo
                {
                    HId = Convert.ToInt32(row["HId"]),
                    HTitle = row["HTitle"].ToString()
                });
            }
            return list;
        }
        public int Insert(HallInfo hi)
        {
            string sql = "insert into HallInfo(HTitle,HIsDelete) values(@title,0)";
            SQLiteParameter ps = new SQLiteParameter("@title", hi.HTitle);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(HallInfo hi)
        {
            string sql = "update HallInfo set HTitle=@title where HId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",hi.HTitle),
                new SQLiteParameter("id",hi.HId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Delete(int id)
        {
            string sql = "update HallInfo set HIsDelete=1 where Hid=@id";
            SQLiteParameter ps = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
