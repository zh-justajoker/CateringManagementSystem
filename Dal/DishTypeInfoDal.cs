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
    public class DishTypeInfoDal
    {
        public List<DishTypeInfo> GetList()
        {
            string sql = "select * from DishTypeInfo where DIsDelete=0";
            DataTable dt = SqliteHelper.GteList(sql);
            List<DishTypeInfo> list = new List<DishTypeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTitle = row["DTitle"].ToString()
                });
            }
            return list;
        }
        public int Insert(DishTypeInfo dti)
        {
            string sql = "insert into DishTypeInfo(DTitle,DIsDelete) values(@title,0)";
            SQLiteParameter ps = new SQLiteParameter("@title", dti.DTitle);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(DishTypeInfo dti)
        {
            string sql = "update DishTypeInfo set DTitle=@title where DId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",dti.DTitle),
                new SQLiteParameter("@id",dti.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Delete(int id)
        {
            string sql = "update DishTypeInfo set DIsDelete=1 where DId=@id";
            SQLiteParameter ps = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
