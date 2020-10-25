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
    public class MemberTypeInfoDal
    {
        public List<MemberTypeInfo> GetList()
        {
            string sql = "select * from MemberTypeInfo where MIsDelete=0";
            DataTable dt = SqliteHelper.GteList(sql);
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MTitle = row["MTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["MDiscount"])
                });
            }
            return list;
        }

        public int Insert(MemberTypeInfo mit)
        {
            //构造插入语句，注意：必须列与值要相对应
            string sql = "insert into MemberTypeInfo(MTitle,MDiscount,MIsDelete) values(@title,@discount,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",mit.MTitle),
                new SQLiteParameter("@discount",mit.MDiscount)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update(MemberTypeInfo mit)
        {
            //构造sql语句
            string sql = "update MemberTypeInfo set MTitle=@title,MDiscount=@discount where MId=@id";
            SQLiteParameter[] ps = 
            {
                new SQLiteParameter("@title",mit.MTitle),
                new SQLiteParameter("@discount",mit.MDiscount),
                new SQLiteParameter("@id",mit.MId)
            };
            //执行并返回搜影响行数
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            //逻辑删除，将MIsDelete标记改为1表示删除
            string sql = "update MemberTypeInfo set MIsDelete=1 where MId=@id";
            SQLiteParameter ps = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
