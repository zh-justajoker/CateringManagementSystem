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
    public class MemberInfoDal
    {
        public List<MemberInfo> GetList(MemberInfo mi)
        {
            //连接查询
            string sql = "select mi.*,mti.MTitle,mti.MDiscount from MemberInfo mi"+ " inner join MemberTypeInfo mti " + "on mi.MTypeId=mti.MId " + "where mi.MIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (mi.MId > 0)
            {
                sql += " and mi.MId=@mid";
                listP.Add(new SQLiteParameter("@mid", mi.MId));
            }
            if (!string.IsNullOrEmpty(mi.MName))
            {
                sql += " and mi.MName like @name";
                listP.Add(new SQLiteParameter("@name", "%" + mi.MName + "%"));
            }
            if (!string.IsNullOrEmpty(mi.MPhone))
            {
                sql += " and mi.MPhone like @phone";
                listP.Add(new SQLiteParameter("@phone", "%" + mi.MPhone + "%"));
            }
            DataTable dt = SqliteHelper.GteList(sql,listP.ToArray());
            List<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MName = row["MName"].ToString(),
                    MMoney = Convert.ToDecimal(row["MMoney"]),
                    MPhone = row["MPhone"].ToString(),
                    MTypeId = Convert.ToInt32(row["MTypeId"]),
                    TypeTitle = row["MTitle"].ToString(),
                    TypeDiscount = Convert.ToDecimal(row["MDiscount"])
                });
            }
            return list;
        }
        public int Insert(MemberInfo mi)
        {
            string sql = "insert into MemberInfo(MTypeId,MName,MPhone,MMoney,MIsDelete) values (@tid,@name,@phone,@money,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@tid",mi.MTypeId),
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money",mi.MMoney)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(MemberInfo mi)
        {
            string sql = "update MemberInfo set MName=@name,MPhone=@phone,MMoney=@money,MTypeId=@tid where MId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money",mi.MMoney),
                new SQLiteParameter("@tid",mi.MTypeId),
                new SQLiteParameter("@id",mi.MId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);

        }
        public int Delete(int id)
        {
            string sql = "update MemberInfo set MIsDelete=1 where MId=@id";
            SQLiteParameter ps = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
