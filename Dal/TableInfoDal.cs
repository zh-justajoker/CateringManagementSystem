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
    public class TableInfoDal
    {
        public List<TableInfo> GetList(TableInfo ti)
        {
            string sql = "select ti.*,hi.HTitle as HallTitle from TableInfo ti" +
                " inner join HallInfo hi"+" on ti.THallId=hi.HId " +" where ti.TIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (ti.THallId > 0)
            {
                sql += " and ti.THallId=@hid";
                listP.Add(new SQLiteParameter("@hid", ti.THallId));
            }
            if (ti.IsFreeSearch > -1)
            {
                sql += " and ti.TIsFree=@isFree";
                listP.Add(new SQLiteParameter("@isFree", ti.IsFreeSearch));
            }
            sql += " order by ti.TId desc";
            DataTable dt = SqliteHelper.GteList(sql,listP.ToArray());
            List<TableInfo> list = new List<TableInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TableInfo()
                {
                    TId = Convert.ToInt32(row["TId"]),
                    TTitle = row["TTitle"].ToString(),
                    THallId = Convert.ToInt32(row["THallId"]),
                    HallTitle = row["HallTitle"].ToString(),
                    TIsFree = Convert.ToBoolean(row["TIsFree"])
                });
            }
            return list;
        }

        public int Insert(TableInfo ti)
        {
            string sql = "insert into TableInfo(TTitle,THallId,TIsFree,TIsDelete) values(@title,@hid,@free,0) ";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",ti.TTitle),
                new SQLiteParameter("@hid",ti.THallId),
                new SQLiteParameter("@free",ti.TIsFree)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(TableInfo ti)
        {
            string sql = "update TableInfo set TTitle=@title,THallId=@hid,TIsFree=@free where TId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",ti.TTitle),
                new SQLiteParameter("@hid",ti.THallId),
                new SQLiteParameter("@free",ti.TIsFree),
                new SQLiteParameter("@id",ti.TId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Delete(int id)
        {
            string sql = "update TableInfo set TIsDelete=1 where TId=@id";
            SQLiteParameter ps = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
