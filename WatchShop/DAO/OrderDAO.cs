using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchShop.EntityFramework;

namespace WatchShop.DAO
{
    public class OrderDAO
    {
        WatchShopContext db = null;
        public OrderDAO()
        {
            db = new WatchShopContext();
        }

        public int Insert(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity.OrderId;
        }

        public void InsertOrderDetail(OrderDetail OD)
        {
            db.OrderDetails.Add(OD);
            db.SaveChanges();
        }
    }
}