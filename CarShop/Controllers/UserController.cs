using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarShop.Models;

namespace CarShop.Controllers
{
    public class UserController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        private object userlog;

        // ĐĂNG KÝ
        [HttpGet]
        public ActionResult Dangki()
        {
            return View();
        }

        // ĐĂNG KÝ PHƯƠNG THỨC POST
        /*[HttpPost]
        public ActionResult Dangky(NguoiDung nguoidung)
        {
            try
            {
                // Thêm người dùng  mới
                db.NguoiDungs.Add(nguoidung);
                // Lưu lại vào cơ sở dữ liệu
                db.SaveChanges();
                // Nếu dữ liệu đúng thì trả về trang đăng nhập
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Dangnhap");
                }
                return View("Dangky");

            }
            catch
            {
                return View();
            }
        }*/

        //Đăng kí theo phương thức Post
        [HttpPost]
        public ActionResult Dangki(NguoiDung _user)
        {
            if (ModelState.IsValid) {
                var check = db.NguoiDungs.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.NguoiDungs.Add(_user);
                    db.SaveChanges();

                    // Nếu đăng kí thành công thì điều hướng trang đăng kí về đăng nhập
                    return RedirectToAction("Dangnhap");

                } else
                {
                    ViewBag.error = "Email đã tồn tại! Vui lòng sử dụng email khác!";
                    return View();
                }
            }
            return View();
        }

        //Get login
        public ActionResult Dangnhap()
        {
            return View();
        }

        //method login
        [HttpPost]
        public ActionResult Login(FormCollection userlog)
        {
            string userMail = userlog["Email"].ToString();
            string password = userlog["MatKhau"].ToString();
         
            var check =  db.NguoiDungs.SingleOrDefault(x => x.Email.Equals(userMail) && x.MatKhau.Equals(password));
            if(check == null)
            {
                ViewBag.Fail = "Email hoặc mật khẩu không hợp lệ ?";
                return View("Dangnhap");
            }
            else
            {
                if (userMail == "Admin@gmail.com")
                {
                    Session["use"] = check;
                    return RedirectToAction("Index", "Admin/Home");
                }
                else
                {
                    Session["use"] = check;
                    return RedirectToAction("Index", "Home");
                }

            }
        }

        public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index", "Home");

        }
    }
}   