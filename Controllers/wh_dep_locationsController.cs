using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mgmt.Models;

namespace mgmt.Controllers
{
    public class wh_dep_locationsController : Controller
    {
        private mgmtEntities db = new mgmtEntities();

        // GET: wh_dep_locations
        public ActionResult Index()
        {
            var wh_dep_locations = db.wh_dep_locations.Include(w => w.wh_dep);
            return View(wh_dep_locations.ToList());
        }

        // GET: wh_dep_locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_dep_locations wh_dep_locations = db.wh_dep_locations.Find(id);
            if (wh_dep_locations == null)
            {
                return HttpNotFound();
            }
            return View(wh_dep_locations);
        }

        // GET: wh_dep_locations/Create
        public ActionResult Create()
        {
            ViewBag.id_wh_dep = new SelectList(db.wh_dep, "id", "dep_name");
            return View();
        }

        // POST: wh_dep_locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_wh_dep,name")] wh_dep_locations wh_dep_locations)
        {
            if (ModelState.IsValid)
            {
                db.wh_dep_locations.Add(wh_dep_locations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_wh_dep = new SelectList(db.wh_dep, "id", "dep_name", wh_dep_locations.id_wh_dep);
            return View(wh_dep_locations);
        }

        // GET: wh_dep_locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_dep_locations wh_dep_locations = db.wh_dep_locations.Find(id);
            if (wh_dep_locations == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_wh_dep = new SelectList(db.wh_dep, "id", "dep_name", wh_dep_locations.id_wh_dep);
            return View(wh_dep_locations);
        }

        // POST: wh_dep_locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_wh_dep,name")] wh_dep_locations wh_dep_locations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wh_dep_locations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_wh_dep = new SelectList(db.wh_dep, "id", "dep_name", wh_dep_locations.id_wh_dep);
            return View(wh_dep_locations);
        }

        // GET: wh_dep_locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_dep_locations wh_dep_locations = db.wh_dep_locations.Find(id);
            if (wh_dep_locations == null)
            {
                return HttpNotFound();
            }
            return View(wh_dep_locations);
        }

        // POST: wh_dep_locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wh_dep_locations wh_dep_locations = db.wh_dep_locations.Find(id);
            db.wh_dep_locations.Remove(wh_dep_locations);
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
