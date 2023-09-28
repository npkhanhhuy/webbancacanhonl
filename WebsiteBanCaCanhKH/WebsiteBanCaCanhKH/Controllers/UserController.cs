using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebsiteBanCaCanhKH.Models;

namespace WebsiteBanCaCanhKH.Controllers
{
    public class UserController : Controller
    {
        QLBanCaCanhOnline data = new QLBanCaCanhOnline();
        // GET: User
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, User kh)
        {
            var STenDN = collection["TenDN"];
            var sHoTen = collection["HoTen"];
            var sMatKhau = collection["MatKhau"];
            var sMatKhauNhapLai = collection["MatKhauNL"];
            var sEmail = collection["Email"];
            var sDiaChi = collection["DiaChi"];
            var sSDT = collection["SDT"];
            var dNgaySinh = string.Format("{0:MM/dd/yyyy}", collection["NgaySinh"]);
            if (String.IsNullOrEmpty(sHoTen))
            {
                ViewData["err1"] = "(*)Họ tên không được rỗng";
            }
            else if (String.IsNullOrEmpty(STenDN))
            {
                ViewData["err2"] = "(*)Tên đăng nhập không được rỗng";
            }
            else if (String.IsNullOrEmpty(sMatKhau))
            {
                ViewData["err3"] = "(*)Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(sMatKhauNhapLai))
            {
                ViewData["err4"] = "(*)Phải nhập lại mật khẩu";
            }
            else if (sMatKhau != sMatKhauNhapLai)
            {
                ViewData["err4"] = "(*)Mật khẩu nhập lại không khớp";
            }
            else if (String.IsNullOrEmpty(sEmail))
            {
                ViewData["err5"] = "(*)Email không được rỗng";
            }
            else if (String.IsNullOrEmpty(sSDT))
            {
                ViewData["err6"] = "(*)Số điện thoại không được rỗng";
            }
            else if (data.Users.SingleOrDefault(n => n.TenDN == STenDN) != null)
            {
                ViewBag.ThongBao = "(*)Tên đăng nhập đã tồn tại";
            }
            else if (data.Users.SingleOrDefault(n => n.Email == sEmail) != null)
            {
                ViewBag.ThongBao = "(*)Email đã được sử dụng";
            }
            else
            {
                kh.TenDN = STenDN;
                kh.HoTen = sHoTen;
                kh.MatKhau = sMatKhau;
                kh.Email = sEmail;
                kh.DiaChi = sDiaChi;
                kh.SDT = sSDT;
                kh.NgaySinh = DateTime.Parse(dNgaySinh);
                kh.PhanQuyen = int.Parse("1");
                data.Users.Add(kh);
                data.SaveChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
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
                User kh = data.Users.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau && n.PhanQuyen==1);
                User admin = data.Users.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau && n.PhanQuyen == 0);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
                    Session["TenDN"] = kh;
                    ViewBag.TBwelcome = "Chào mừng " + sTenDN;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                if(admin != null)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
                    Session["TenDN"] = admin;
                    ViewBag.TBwelcome = "Chào mừng " + sTenDN;
                    return Redirect("/Admin/Home/Index");
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

            return RedirectToAction("Index", "Home");
        }
        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogout");
        }
        public ActionResult SuaThongTinKH(int MaUser)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            var suattkh = db.Users.Find(MaUser);
            return View(suattkh);
        }
        [HttpPost]
        public ActionResult SuaThongTinKH(User user)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            var updateTT = db.Users.Find(user.MaUser);
            if (string.IsNullOrEmpty(user.HoTen) == true)
            {
                ModelState.AddModelError("", "Tên Không Để Trống");
                return View(user);
            }
            else
            {
                updateTT.HoTen = user.HoTen;
                updateTT.MatKhau = user.MatKhau;
                updateTT.Email = user.Email;
                updateTT.DiaChi = user.DiaChi;
                updateTT.SDT = user.SDT;
                updateTT.NgaySinh = user.NgaySinh;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}