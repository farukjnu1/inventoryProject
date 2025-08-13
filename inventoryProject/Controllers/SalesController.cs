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
    public class SalesController : Controller
    {
        private StockManageEntities db = new StockManageEntities();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.customer).Include(s => s.transaction_type).Include(s => s.store).Include(s => s.transaction_type1);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name");
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name");
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name");
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sale_id,product_id,customer_id,store_id,transaction_id,sale_date,quantity,rate,total_price,vat,discount,net_total_price,stock_status,memo_no,coomments")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name", sale.customer_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", sale.transaction_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", sale.store_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", sale.transaction_id);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name", sale.customer_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", sale.transaction_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", sale.store_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", sale.transaction_id);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sale_id,product_id,customer_id,store_id,transaction_id,sale_date,quantity,rate,total_price,vat,discount,net_total_price,stock_status,memo_no,coomments")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name", sale.customer_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", sale.transaction_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", sale.store_id);
            ViewBag.transaction_id = new SelectList(db.transaction_type, "transaction_id", "transaction_type_name", sale.transaction_id);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
