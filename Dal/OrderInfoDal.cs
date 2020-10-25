using Model;
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
    public class OrderInfoDal
    {
        public int KaiDan(int tableId)
        {
            string sql = "insert into OrderInfo(ODate,IsPay,TableId) values(datetime('now','localtime'),0,@tid);"
                + " update TableInfo set TIsFree=0 where TId=@tid";
            SQLiteParameter ps = new SQLiteParameter("@tid", tableId);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int GetOidByTid(int tid)
        {
            string sql = "select OId from OrderInfo where TableId=@tid and IsPay=0";
            SQLiteParameter ps = new SQLiteParameter("@tid", tid);
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, ps));
        }
        public decimal GetMoneyByTid(int tid)
        {
            string sql = "select OMoney from OrderInfo where TableId=@tid and IsPay=0";
            SQLiteParameter ps = new SQLiteParameter("@tid", tid);
            return Convert.ToDecimal(SqliteHelper.ExecuteScalar(sql, ps));
        }
        public int DianCai(int orderId,int dishId)
        {
            string sql = "select count(*) from OrderDetailInfo where OrderId=@oid and DishId=@did";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid",orderId),
                new SQLiteParameter("@did",dishId)
            };
            int count = Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, ps));
            if (count == 0)
            {
                //当前订单中没有指定菜品，则进行添加
                sql = "insert into OrderDetailInfo(OrderId,DishId,Count) values(@oid,@did,1)";
            }
            else
            {
                //当前订单中已经存在此菜品，则进行数量更新
                sql = "update OrderDetailInfo set Count=Count+1 where OrderId=@oid and DishId=@did";
            }
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public List<OrderDetailInfo> GetOrderDetail(int orderId)
        {
            string sql = "select odi.*,di.DTitle,di.DPrice from OrderDetailInfo odi" + " inner join DishInfo di"
                + " on odi.DishId=di.Did" + " where odi.OrderId=@oid";
            SQLiteParameter ps = new SQLiteParameter("@oid", orderId);
            DataTable dt = SqliteHelper.GteList(sql, ps);
            List<OrderDetailInfo> list = new List<OrderDetailInfo>();
            foreach(DataRow row in dt.Rows)
            {
                list.Add(new OrderDetailInfo()
                {
                    OId = Convert.ToInt32(row["OId"]),
                    OrderId = orderId,
                    DishId = Convert.ToInt32(row["DishId"]),
                    Count = Convert.ToInt32(row["Count"]),
                    DishTitle = row["DTitle"].ToString(),
                    DishPrice =Convert.ToDecimal(row["DPrice"])
                });
            }
            return list;
        }
        public int UpdateDishCount(int oid, int count)
        {
            string sql = "update OrderDetailInfo set Count=@count where OId=@oid";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@count",count),
                new SQLiteParameter("@oid",oid)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int DeleteDish(int oid)
        {
            string sql = "delete from OrderDetailInfo where oid=@oid";
            SQLiteParameter ps = new SQLiteParameter("@oid", oid);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int XiaDan(int orderId, decimal totalMoney)
        {
            string sql = "update OrderInfo set OMoney=@totalMoney where OId=@oid";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid",orderId),
                new SQLiteParameter("@totalMoney",totalMoney)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int JieZhang(int tableId, int memberId, decimal discount, decimal payMoney)
        {
            using (SQLiteConnection coon = new SQLiteConnection(ConfigurationManager.ConnectionStrings["cater"].ConnectionString))
            {
                coon.Open();
                //开启事务
                SQLiteTransaction tran = coon.BeginTransaction();
                int counter = 0;
                try
                {
                    //创建command对象,并与事务相关联
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Transaction = tran;
                    //1、更改订单状态：ispay=1
                    string sql = "update OrderInfo set IsPay=1";
                    //1.1、如果是会员则记录下来
                    if (memberId > 0)
                    {
                        sql += ",MemberId=" + memberId + ",Discount=" + discount;
                    }
                    sql += " where TableId=" + tableId + " and IsPay=0";
                    cmd.CommandText = sql;
                    counter += cmd.ExecuteNonQuery();

                    //2、将餐桌状态更改为1空闲
                    sql = "update TableInfo set TIsFree=1 where TId=" + tableId;
                    cmd.CommandText = sql;
                    counter += cmd.ExecuteNonQuery();

                    //3、如果使用余额结账，则更新会员余额
                    if (payMoney > 0)
                    {
                        sql = "update MemberInfo set MMoney=MMoney-" + payMoney + " where MId=" + memberId;
                        cmd.CommandText = sql;
                        counter += cmd.ExecuteNonQuery();
                    }
                    
                    //操作成功，则提交确定之前所有的操作
                    tran.Commit();
                }
                catch
                {
                    counter = 0;
                    //一旦出错，则回滚，放弃之前所有的操作
                    tran.Rollback();
                }
                return counter;
            }
        }
    }
}
