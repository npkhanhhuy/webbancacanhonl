using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebsiteBanCaCanhKH.Models;

namespace WebsiteBanCaCanhKH.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        QLBanCaCanhOnline data = new QLBanCaCanhOnline();
        // GET: Admin/Home
        public ActionResult Index()
        {            
            if (Session["TenDN"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
                return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var sTenDN = collection["TenDN"];
            var sMatKhau = collection["MatKhau"];
            if (string.IsNullOrEmpty(sTenDN))
            {
                ViewData["Err1"] = "Bạn chưa nhập tên đăng nhập";
            }
            else if (string.IsNullOrEmpty(sMatKhau))
            {
                ViewData["Err2"] = "Phải nhập mật khẩu";
            }
            else
            {
                User kh = data.Users.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau && n.PhanQuyen == 1);
                User admin = data.Users.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau && n.PhanQuyen == 0);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
                    Session["TenDN"] = kh;
                    ViewBag.TBwelcome = "Chào mừng " + sTenDN;
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                if (admin != null)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
                    Session["TenDN"] = admin;
                    ViewBag.TBwelcome = "Chào mừng " + sTenDN;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Remove("TenDN");
            FormsAuthentication.SignOut();

            return Redirect("/Home/Index");
        }
        public ActionResult DSKhachHang()
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            List<User> kq = db.Users.ToList();
            return View(kq);
        }
        [HttpPost]
        public ActionResult XoaKhachHang(int MaUser)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            var xoa = db.Users.Find(MaUser);
            db.Users.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("DsKhachHang");
        }
        public ActionResult DSDonHang()
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            List<DonHang> kq = db.DonHangs.ToList();
            return View(kq);
        }
        public ActionResult XoaDonHang(int MaDonHang)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            var xoa = db.DonHangs.Find(MaDonHang);
            db.DonHangs.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("DsDonHang");
        }
    }
}