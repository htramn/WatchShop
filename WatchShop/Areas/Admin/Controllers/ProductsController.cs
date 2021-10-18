using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatchShop.EntityFramework;

namespace WatchShop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private WatchShopContext db = new WatchShopContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.CreatedPerson).Include(p => p.Material).Include(p => p.ModifiedPerson).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName");
            ViewBag.CreatedBy = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.MaterialId = new SelectList(db.Materials, "MaterialId", "MaterialName");
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Description,Price,PromotionPrice,Quantity,Image,MoreImages,TopHot,FaceRadius,FaceThickness,WireLength,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MaterialId,ColorId,SupplierId,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", product.ColorId);
            ViewBag.CreatedBy = new SelectList(db.Users, "UserId", "UserName", product.CreatedBy);
            ViewBag.MaterialId = new SelectList(db.Materials, "MaterialId", "MaterialName", product.MaterialId);
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "UserName", product.ModifiedBy);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", product.ColorId);
            ViewBag.CreatedBy = new SelectList(db.Users, "UserId", "UserName", product.CreatedBy);
            ViewBag.MaterialId = new SelectList(db.Materials, "MaterialId", "MaterialName", product.MaterialId);
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "UserName", product.ModifiedBy);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Description,Price,PromotionPrice,Quantity,Image,MoreImages,TopHot,FaceRadius,FaceThickness,WireLength,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MaterialId,ColorId,SupplierId,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ModifiedDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", product.ColorId);
            ViewBag.CreatedBy = new SelectList(db.Users, "UserId", "UserName", product.CreatedBy);
            ViewBag.MaterialId = new SelectList(db.Materials, "MaterialId", "MaterialName", product.MaterialId);
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "UserName", product.ModifiedBy);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
