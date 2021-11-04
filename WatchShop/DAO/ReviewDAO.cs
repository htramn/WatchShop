using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchShop.EntityFramework;

namespace WatchShop.DAO
{
    public class ReviewDAO
    {
        WatchShopContext db = null;
        public ReviewDAO()
        {
            db = new WatchShopContext();

        }
        public long Insert(Review entity)
        {
            db.Reviews.Add(entity);
            db.SaveChanges();
            return entity.ReviewId;
        }
    }
}