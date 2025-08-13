using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inventoryProject.Models;

namespace inventoryProject.Controllers
{
    public class purchasesController : Controller
    {
        private StockManageEntities db = new StockManageEntities();

        // GET: purchases
        public ActionResult Index()
        {
            var purchases = db.purchases.Include(p => p.product).Include(p => p.store).Include(p => p.supplier).Include(p => p.transaction_type);
            return View(purchases.ToList());
        }

        // GET: purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase purchase = db.purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: purchases/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name");
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name");
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name");
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name");
            return View();
        }

        // POST: purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "purchase_id,product_id,supplier_id,store_id,transaction_id,purchase_date,quantity,rate,total_price,vat,discount,net_total_price,stock_status,memo_no,coomments")] purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", purchase.product_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", purchase.store_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", purchase.supplier_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", purchase.transaction_id);
            return View(purchase);
        }

        // GET: purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase purchase = db.purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", purchase.product_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", purchase.store_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", purchase.supplier_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", purchase.transaction_id);
            return View(purchase);
        }

        // POST: purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "purchase_id,product_id,supplier_id,store_id,transaction_id,purchase_date,quantity,rate,total_price,vat,discount,net_total_price,stock_status,memo_no,coomments")] purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", purchase.product_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", purchase.store_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", purchase.supplier_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", purchase.transaction_id);
            return View(purchase);
        }

        // GET: purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase purchase = db.purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            purchase purchase = db.purchases.Find(id);
            db.purchases.Remove(purchase);
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
