using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchShop.EntityFramework;

namespace WatchShop.DAO
{
    public class ContactDAO
    {
        WatchShopContext db = null;
        public ContactDAO()
        {
            db = new WatchShopContext();

        }
        public long Insert(ContactEmail entity)
        {
            db.contactEmails.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
    }
}