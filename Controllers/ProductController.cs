using Lab05.Models.NorthWind;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindEntities ctx = new NorthwindEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(ctx.Products.ToList());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(ctx.Suppliers, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(ctx.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,UnitPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                ctx.Products.Add(product);
                await ctx.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(ctx.Suppliers, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(ctx.Categories, "CategoryID", "CategoryName");
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ctx.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Suppliers = new SelectList(
                ctx.Suppliers
                .OrderBy(s => s.CompanyName),
                "SupplierID", "CompanyName", product.SupplierID);

            ViewBag.Categories = new SelectList(
                ctx.Categories
                .OrderBy(c => c.CategoryName),
                "CategoryID", "CategoryName", product.CategoryID);

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,UnitPrice")] Product product)
        {
            ViewBag.Suppliers = new SelectList(
                ctx.Suppliers
                .OrderBy(s => s.CompanyName),
                "SupplierID", "CompanyName", product.SupplierID);

            ViewBag.Categories = new SelectList(
                ctx.Categories
                .OrderBy(c => c.CategoryName),
                "CategoryID", "CategoryName", product.CategoryID);

            if (ModelState.IsValid)
            {
                ctx.Entry(product).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
