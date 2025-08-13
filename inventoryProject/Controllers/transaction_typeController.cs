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
    public class transaction_typeController : Controller
    {
        private StockManageEntities db = new StockManageEntities();

        // GET: transaction_type
        public ActionResult Index()
        {
            return View(db.transaction_type.ToList());
        }

        // GET: transaction_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaction_type transaction_type = db.transaction_type.Find(id);
            if (transaction_type == null)
            {
                return HttpNotFound();
            }
            return View(transaction_type);
        }

        // GET: transaction_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: transaction_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transaction_id,transaction_type_name")] transaction_type transaction_type)
        {
            if (ModelState.IsValid)
            {
                db.transaction_type.Add(transaction_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction_type);
        }

        // GET: transaction_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaction_type transaction_type = db.transaction_type.Find(id);
            if (transaction_type == null)
            {
                return HttpNotFound();
            }
            return View(transaction_type);
        }

        // POST: transaction_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transaction_id,transaction_type_name")] transaction_type transaction_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction_type);
        }

        // GET: transaction_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaction_type transaction_type = db.transaction_type.Find(id);
            if (transaction_type == null)
            {
                return HttpNotFound();
            }
            return View(transaction_type);
        }

        // POST: transaction_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transaction_type transaction_type = db.transaction_type.Find(id);
            db.transaction_type.Remove(transaction_type);
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
