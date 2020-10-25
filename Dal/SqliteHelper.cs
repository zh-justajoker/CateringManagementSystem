using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SqliteHelper
    {
        public static string Constr = ConfigurationManager.ConnectionStrings["cater"].ConnectionString;
        public static DataTable GteList(string sql,params SQLiteParameter[] ps)
        {
            //构造连接对象
            using (SQLiteConnection conn = new SQLiteConnection(Constr))
            {
                //构造连接器对象
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddRange(ps);
                //数据表对象
                DataTable dt = new DataTable();
                //将数据存到table中
                adapter.Fill(dt);
                //返回数据表
                return dt;
            }

        }

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Constr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static object ExecuteScalar(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection coon = new SQLiteConnection(Constr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, coon);
                cmd.Parameters.AddRange(ps);
                coon.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
