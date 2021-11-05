using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchShop.EntityFramework;

namespace WatchShop.DAO
{
    public class ProductDAO
    {
        WatchShopContext db = null;
        public ProductDAO()
        {
            db = new WatchShopContext();
        }
        public Product GetById(int? id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetRelatedProducts(int? id)
        {
            var category = db.Products.Find(id).CategoryId;
            var list = db.Products.Where(p => p.CategoryId == category&&p.ProductId!=id)
                                  .OrderBy(p=>p.CreatedDate).Take(10);
            return list;
        }
    }
}