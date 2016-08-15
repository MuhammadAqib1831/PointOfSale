using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointofSaleApplication.Model;
using PointofSaleApplication.Data;

namespace PointofSaleApplication.Controllers
{
    public class Order_MasterController : Controller
    {
        private POSDbContext db = new POSDbContext();

        // GET: /Order_Master/
        public ActionResult Index()
        {
            return View(db.ordermasters.ToList());
        }

        // GET: /Order_Master/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster ordermaster = db.ordermasters.Find(id);
            if (ordermaster == null)
            {
                return HttpNotFound();
            }
            return View(ordermaster);
        }

        // GET: /Order_Master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Order_Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,CreatiomTime,TotalSum,status,Synchronized")] OrderMaster ordermaster)
        {
            if (ModelState.IsValid)
            {
                ordermaster.Id= Guid.NewGuid();
                db.ordermasters.Add(ordermaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordermaster);
        }

        // GET: /Order_Master/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster ordermaster = db.ordermasters.Find(id);
            if (ordermaster == null)
            {
                return HttpNotFound();
            }
            return View(ordermaster);
        }

        // POST: /Order_Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,CreatiomTime,TotalSum,status,Synchronized")] OrderMaster ordermaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordermaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordermaster);
        }

        // GET: /Order_Master/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster ordermaster = db.ordermasters.Find(id);
            if (ordermaster == null)
            {
                return HttpNotFound();
            }
            return View(ordermaster);
        }

        // POST: /Order_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OrderMaster ordermaster = db.ordermasters.Find(id);
            db.ordermasters.Remove(ordermaster);
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
