using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchShop.EntityFramework;
using System.Data;
using System.Data.Entity;

namespace WatchShop.DAO
{
    public class BlogDAO
    {
        public WatchShopContext db = null;
        public BlogDAO()
        {
            db = new WatchShopContext();
        }
        public void Insert(Blog entity)
        {
            db.Blogs.Add(entity);
            db.SaveChanges();

        }
        public void Update(Blog entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void Delete(Blog entity)
        {
            db.Blogs.Remove(entity);
            db.SaveChanges();

        }
        public Blog GetById(int? id)
        {
            return db.Blogs.Find(id);
        }
        public IEnumerable<Blog> GetListBlogs()
        {
            return db.Blogs.Include(b => b.CreatedPerson).Include(b => b.ModifiedPerson).OrderByDescending(b=>b.CreatedDate);
        }
    }
}