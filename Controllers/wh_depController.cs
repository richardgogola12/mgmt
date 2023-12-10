using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mgmt.Models;
using Microsoft.AspNet.Identity;

namespace mgmt.Controllers
{
    [Authorize]
    public class wh_depController : Controller
    {
        private mgmtEntities db = new mgmtEntities();

        // GET: wh_dep
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var wh_dep = db.get_dep_list_by_wh(id);
            ViewBag.id_wh = id;
            return View(wh_dep.ToList());
        }

        // GET: wh_dep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_dep wh_dep = db.wh_dep.Find(id);
            if (wh_dep == null)
            {
                return HttpNotFound();
            }
            return View(wh_dep);
        }

        // GET: wh_dep/Create
        public ActionResult Create()
        {
            ViewBag.id_wh = new SelectList(db.wh_list, "id", "name");
            return View();
        }

        // POST: wh_dep/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_wh,dep_name")] wh_dep wh_dep)
        {
            if (ModelState.IsValid)
            {
                db.wh_dep.Add(wh_dep);
                db.SaveChanges();
                return RedirectToAction("Index", "wh_dep", new { id = wh_dep.id_wh });
            }

            ViewBag.id_wh = new SelectList(db.wh_list, "id", "name", wh_dep.id_wh);
            return View(wh_dep);
        }

        // GET: wh_dep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_dep wh_dep = db.wh_dep.Find(id);
            if (wh_dep == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_wh = new SelectList(db.wh_list, "id", "name", wh_dep.id_wh);
            return View(wh_dep);
        }

        // POST: wh_dep/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_wh,dep_name")] wh_dep wh_dep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wh_dep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "wh_dep", new { id = wh_dep.id_wh } );
            }
            ViewBag.id_wh = new SelectList(db.wh_list, "id", "name", wh_dep.id_wh);
            return View(wh_dep);
        }

        // GET: wh_dep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_dep wh_dep = db.wh_dep.Find(id);
            if (wh_dep == null)
            {
                return HttpNotFound();
            }
            return View(wh_dep);
        }

        // POST: wh_dep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wh_dep wh_dep = db.wh_dep.Find(id);
            db.wh_dep.Remove(wh_dep);
            db.SaveChanges();
            return RedirectToAction("Index", "wh_dep", new { id = wh_dep.id_wh });
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
