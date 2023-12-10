using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using mgmt.Models;
using Microsoft.AspNet.Identity;

namespace mgmt.Controllers
{
    [Authorize]
    public class wh_listController : Controller
    {
        private mgmtEntities db = new mgmtEntities();

        // GET: wh_list
        public ActionResult Index()
        {
            var wh_list = db.get_wh_list_byUser(User.Identity.GetUserId());
            return View(wh_list.ToList());
        }

        // GET: wh_list/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_list wh_list = db.wh_list.Find(id);
            if (wh_list == null)
            {
                return HttpNotFound();
            }
            return View(wh_list);
        }

        // GET: wh_list/Create
        public ActionResult Create()
        {
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: wh_list/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,id_user,dt")] wh_list wh_list)
        {
            if (ModelState.IsValid)
            {
                wh_list.id_user = User.Identity.GetUserId();
                wh_list.dt = DateTime.Now;
                db.wh_list.Add(wh_list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", wh_list.id_user);
            return View(wh_list);
        }

        // GET: wh_list/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_list wh_list = db.wh_list.Find(id);
            if (wh_list == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", wh_list.id_user);
            return View(wh_list);
        }

        // POST: wh_list/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,id_user,dt")] wh_list wh_list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wh_list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", wh_list.id_user);
            return View(wh_list);
        }

        // GET: wh_list/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wh_list wh_list = db.wh_list.Find(id);
            if (wh_list == null)
            {
                return HttpNotFound();
            }
            return View(wh_list);
        }

        // POST: wh_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wh_list wh_list = db.wh_list.Find(id);
            db.wh_list.Remove(wh_list);
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
