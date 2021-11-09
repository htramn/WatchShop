using System;
using System.Data;
using System.Data.Entity;
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
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.ProductName.ToLower().Contains(keyword.ToLower()))
                .Select(x => x.ProductName).ToList();
        }

        public IEnumerable<Product> GetRelatedProducts(int? id)
        {
            var category = db.Products.Find(id).CategoryId;
            var list = db.Products.Where(p => p.CategoryId == category && p.ProductId!=id)
                                  .OrderBy(p=>p.CreatedDate).Take(10);
            return list;
        }
        //Danh sách mặc định
        public IEnumerable<Product> GetListProducts()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.CreatedPerson)
                .Include(p => p.Material).Include(p => p.ModifiedPerson).Include(p => p.Supplier)
                .OrderBy(p=>p.ProductName);
            
            return products;
        }
        public IEnumerable<Product> SearchResult(string searchContent)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.CreatedPerson)
                .Include(p => p.Material).Include(p => p.ModifiedPerson).Include(p => p.Supplier)
                .Where(p=>p.ProductName.ToLower().Contains(searchContent.ToLower())
                    || p.Description.ToLower().Contains(searchContent.ToLower()))
                .OrderBy(p => p.ProductName);

            return products;
        }

        // sản phẩm mới nhất
        public IEnumerable<Product> Newest()
        {
            var products = GetListProducts().OrderBy(p=>p.CreatedDate);
            return products;
        }
        //sắp xếp theo giá giảm dần
        public IEnumerable<Product> DescendingPrice()
        {
            var products = GetListProducts().OrderByDescending(p => p.SalePrice);
            return products;
        }
        //Sắp xếp theo giá tăng dần
        public IEnumerable<Product> AscendingPrice()
        {
            var products = GetListProducts().OrderBy(p => p.SalePrice);
            return products;
        }
        //Sản phẩm bán chạy nhất
        public IEnumerable<Product> BestSeller()
        {
            var products = GetListProducts().OrderByDescending(p => p.orderDetails.Count);
            return products;
        }
        public IEnumerable<Product> PromotionList()
        {
            var products = GetListProducts().Where(p => p.PromotionPrice!=null).OrderBy(p => p.ProductName); ;
            return products;
        }
        public IEnumerable<Product> NewestPromotion()
        {
            var products = PromotionList().OrderBy(p => p.CreatedDate);
            return products;
        }
        //sắp xếp theo giá giảm dần
        public IEnumerable<Product> DescendingPricePromotion()
        {
            var products = PromotionList().OrderByDescending(p => p.SalePrice);
            return products;
        }
        //Sắp xếp theo giá tăng dần
        public IEnumerable<Product> AscendingPricePromotion()
        {
            var products = PromotionList().OrderBy(p => p.SalePrice);
            return products;
        }
        //Sản phẩm bán chạy nhất
        public IEnumerable<Product> BestSellerPromotion()
        {
            var products = PromotionList().OrderByDescending(p => p.orderDetails.Count);
            return products;
        }
    }
}