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
    public class DishInfoDal
    {
        public List<DishInfo> GetList(DishInfo di)
        {
            string sql = "select di.*,dti.DTitle as TyPeTitle from DishInfo di" + " inner join DishTypeInfo dti" + " on di.DTypeId=dti.DId" + " where di.DIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (!string.IsNullOrEmpty(di.DTitle))
            {
                sql += " and di.DTitle like @title";
                listP.Add(new SQLiteParameter("@title", "%" + di.DTitle + "%"));
            }
            if (di.DTypeId > 0)
            {
                sql += " and di.DTypeId like @tid";
                listP.Add(new SQLiteParameter("@tid", "%" + di.DTypeId + "%"));
            }
            if (!string.IsNullOrEmpty(di.DChar))
            {
                sql += " and di.Dchar like @dchar";
                listP.Add(new SQLiteParameter("@dchar", "%" + di.DChar + "%"));
            }
            sql += " order by di.DId desc";
            DataTable dt = SqliteHelper.GteList(sql,listP.ToArray());
            List<DishInfo> list = new List<DishInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTitle = row["DTitle"].ToString(),
                    DTypeId = Convert.ToInt32(row["DTypeId"]),
                    DChar = row["DChar"].ToString(),
                    DPrice = Convert.ToDecimal(row["DPrice"]),
                    TypeTitle = row["TypeTitle"].ToString()
                });
            }
            return list;
        }
        public int Insert(DishInfo di)
        {
            string sql = "insert into DishInfo(DTitle,DPrice,DTypeId,DChar,DIsDelete) values(@title,@price,@tid,@char,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("tid",di.DTypeId),
                new SQLiteParameter("char",di.DChar)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(DishInfo di)
        {
            string sql = "update DishInfo set DTitle=@title,Dprice=@price,Dchar=@char,DTypeId=@tid where DId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@char",di.DChar),
                new SQLiteParameter("@tid",di.DTypeId),
                new SQLiteParameter("@id",di.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Delete(int id)
        {
            string sql = "update DishInfo set DIsDelete=1 where DId=@id";
            SQLiteParameter ps = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
