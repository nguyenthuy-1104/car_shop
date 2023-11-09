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
    public class NguoidungController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: Admin/Nguoidung
        public ActionResult Index()
        {
            var nguoidung = db.NguoiDungs.Include(n => n.PhanQuyen);
            return View(nguoidung.ToList());
        }

        // GET: Admin/Nguoidung/Details/5
       // public ActionResult Details(int? id)
       //{
       //     return View();
       // }

        //// GET: Admin/Nguoidungs/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen");
        //    return View();
        //}

        //// POST: Admin/Nguoidungs/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaNguoiDung,HoTen,Email,DienThoai,MatKhau,IDQuyen")] Nguoidung nguoidung)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Nguoidungs.Add(nguoidung);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
        //    return View(nguoidung);
        //}

        // GET: Admin/Nguoidung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoidung = db.NguoiDungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // POST: Admin/Nguoidung/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "MaNguoiDung,HoTen,Email,DienThoai,DiaChi,MatKhau,IDQuyen")] NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoidung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
            return View(nguoidung);
        }

        // GET: Admin/Nguoidung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoidung = db.NguoiDungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // POST: Admin/Nguoidung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDung nguoidung = db.NguoiDungs.Find(id);
            db.NguoiDungs.Remove(nguoidung);
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
