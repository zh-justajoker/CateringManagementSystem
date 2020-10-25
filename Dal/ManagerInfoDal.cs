using Common;
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
    public class ManagerInfoDal
    {
        public List<ManagerInfo> GetList(ManagerInfo mi)
        {
            //构造集合对象
            List<ManagerInfo> list = new List<ManagerInfo>();
            //构造sql语句
            string sql = "select * from ManagerInfo ";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            //拼接查询条件
            if (mi != null)
            {
                sql += "where MName=@name and MPwd=@pwd";
                listP.Add( new SQLiteParameter("@name", mi.MName));
                listP.Add(new SQLiteParameter("@pwd", Md5Helper.GetMd5(mi.MPwd)));
                
            }
            //执行查询，获取数据
            DataTable dt = SqliteHelper.GteList(sql,listP.ToArray());
            //遍历数据表中的行，将数据转存到集合中
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MName = row["MName"].ToString(),
                    MPwd = row["MPwd"].ToString(),
                    MType = Convert.ToInt32(row["MType"])
                });
            }
            //返回数据
            return list;
        }
        public int Insert(ManagerInfo mi)
        {
            //构造sql语句
            string sql = "insert into ManagerInfo(Mname,MPwd,MType) values(@name,@pwd,@type)";
            //数组的初始化器
            SQLiteParameter[] ps = new SQLiteParameter[]
            {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@pwd",Md5Helper.GetMd5(mi.MPwd)),
                new SQLiteParameter("@type",mi.MType)
            };
            //执行
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            string sql = "delete from ManagerInfo where MId=@id";
            SQLiteParameter pms = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, pms);
        }

        public int Update(ManagerInfo mi)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            string sql = "update ManagerInfo set MName=@name,";
            list.Add(new SQLiteParameter("@name", mi.MName));
            if (!mi.MPwd.Equals("******"))
            {
                sql += "MPwd=@pwd,";
                list.Add(new SQLiteParameter("@pwd", Md5Helper.GetMd5(mi.MPwd)));
            }
            sql += "MType=@type where MId=@id";
            list.Add(new SQLiteParameter("@type", mi.MType));
            list.Add(new SQLiteParameter("@id", mi.MId));
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }
    }
}
