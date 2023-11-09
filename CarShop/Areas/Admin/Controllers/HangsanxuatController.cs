using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarShop.Models;

namespace CarShop.Areas.Admin.Controllers
{
    
    public class HangsanxuatController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: Admin/Hangsanxuat
        public ActionResult Index()
        {
            return View(db.HangSXes.ToList());
        }

        // GET: Admin/Hangsanxuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangsanxuat = db.HangSXes.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        // GET: Admin/Hangsanxuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hangsanxuat/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "MaHang, TenHang")] HangSX hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.HangSXes.Add(hangsanxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangsanxuat);
        }

        // GET: Admin/Hangsanxuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangsanxuat = db.HangSXes.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        // POST: Admin/Hangsanxuat/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "MaHang,TenHang")] HangSX hangsanxuat)
        {

            if (ModelState.IsValid)
            {
                //db.Entry(hangsanxuat).State = EntityState.Modified;
                db.Entry(hangsanxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangsanxuat);
        }

        // GET: Admin/Hangsanxuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSX hangsanxuat = db.HangSXes.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangSX hangsanxuat = db.HangSXes.Find(id);
            db.HangSXes.Remove(hangsanxuat);
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
