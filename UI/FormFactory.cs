using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class FormFactory
    {
        //定义静态变量，用于存储单例对象
        private static ManagerInfoList managerInfoList;
        //创建对象的方法
        public static ManagerInfoList CreateMIL()
        {
            //判断对象是否存在，或是否已经被释放
            if (managerInfoList == null || managerInfoList.IsDisposed)
            {
                //新建对象
                managerInfoList = new ManagerInfoList();
            }
            //直接返回对象
            return managerInfoList;
        }
        //菜单管理
        private static DishInfoList dishInfoList;
        public static DishInfoList GreateDIL()
        {
            if (dishInfoList == null || dishInfoList.IsDisposed)
            {
                dishInfoList = new DishInfoList();
            }
            return dishInfoList;
        }
        //餐桌管理
        private static TableInfoList tableInfoList;
        public static TableInfoList GreateTIL()
        {
            if(tableInfoList==null || tableInfoList.IsDisposed)
            {
                tableInfoList = new TableInfoList();
            }
            return tableInfoList;
        }
        //结账付款
        private static OrderPay orderPay;
        public static OrderPay GreateOP()
        {
            if (orderPay == null || orderPay.IsDisposed)
            {
                orderPay = new OrderPay();
            }
            return orderPay;
        }
    }
}
