using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarShop.Models;
using PagedList;

namespace CarShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: Admin/Home
        public ActionResult Index(int? page, string SearchString, string currentFilter)
        {
            var listSp = new List<Sanpham>();

            if(SearchString != null)
            {
                page = 1;
            } else
            {
                SearchString = currentFilter;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy ra sản phẩm từ khoá tìm kiếm
                listSp = db.Sanphams.Where(n => n.Tensp.Contains(SearchString)).ToList();
            } else
            {
                // không tất cả trong bản sản phẩm
                listSp = db.Sanphams.ToList();
            }

            ViewBag.currentFilter = SearchString;
       
            //var sp = db.Sanphams.OrderBy(x => x.Masp);
            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            // xắp xếp đưa sản phẩm mới lên đầu
            listSp = listSp.OrderBy(x => x.Masp).ToList();

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(listSp.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Home/Details/5
        public ActionResult Details(int id)
        {
            var car = db.Sanphams.Find(id);
            return View(car);

        }

        // GET: Admin/Home/Create
        public ActionResult Create()
        {
            var hangselected = new SelectList(db.HangSXes, "MaHang", "TenHang");
            ViewBag.MaHang = hangselected;
            return View();

        }

        // POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create( Sanpham sanpham)
        {
            try
            {
                //Thêm  sản phẩm mới
                db.Sanphams.Add(sanpham);
                // Lưu lại
                db.SaveChanges();
                // Thành công chuyển đến trang index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            // Hiển thị dropdownlist
            var car = db.Sanphams.Find(id);
            var hangselected = new SelectList(db.HangSXes, "MaHang", "TenHang", car.MaHang);
            ViewBag.MaHang = hangselected;
            // 
            return View(car);
        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Sanpham sanpham)
        {
            try
            {
                // Sửa sản phẩm theo mã sản phẩm
                var oldItem = db.Sanphams.Find(sanpham.Masp);
                oldItem.Tensp = sanpham.Tensp;
                oldItem.Giatien = sanpham.Giatien;
                oldItem.Soluong = sanpham.Soluong;
                oldItem.Mota = sanpham.Mota;
                oldItem.Hinhanh = sanpham.Hinhanh;
                oldItem.MaHang = sanpham.MaHang;
               
                // lưu lại
                db.SaveChanges();
                // xong chuyển qua index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            var car = db.Sanphams.Find(id);
            return View(car);
        }

        // POST: Admin/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var car = db.Sanphams.Find(id);
                // Xoá
                db.Sanphams.Remove(car);
                // Lưu lại
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
