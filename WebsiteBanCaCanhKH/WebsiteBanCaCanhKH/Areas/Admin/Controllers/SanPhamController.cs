using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebsiteBanCaCanhKH.Models;

namespace WebsiteBanCaCanhKH.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult DsSanPham()
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            List<HangHoa> kq = db.HangHoas.ToList();
            return View(kq);
        }
        public ActionResult ChiTietSP(int? MaHang)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            HangHoa kq = db.HangHoas.Find(MaHang);
            return View(kq);
        }

        public ActionResult ThemSpmoi()
        {
            return View(new HangHoa());
        }
        [HttpPost]
        public ActionResult ThemSpmoi(HangHoa ca, HttpPostedFileBase fileAnh)
        {
            if (string.IsNullOrEmpty(ca.TenHang) == true)
            {
                ModelState.AddModelError("", "Tên sản phẩm không để trống");
                return View(ca);
            }
            if(fileAnh.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/");
                string pathEmail = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathEmail);
                ca.Anh= "" + fileAnh.FileName;
            }
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            db.HangHoas.Add(ca);
            db.SaveChanges();
            if (ca.MaHang > 0)
            {
                return View();
            }
            else
            {
                ModelState.AddModelError("", "không lưu được");
                return View(ca); 
            }
        }
        public ActionResult SuaSanPham(int MaHang)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            var suasp= db.HangHoas.Find(MaHang);
            return View(suasp);
        }
        [HttpPost]
        public ActionResult SuaSanPham(HangHoa ca,  HttpPostedFileBase fileAnh)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            var updateCTSP = db.HangHoas.Find(ca.MaHang);
            if (string.IsNullOrEmpty(ca.TenHang) == true)
            {
            ModelState.AddModelError("", "Tên Sản Phẩm Không Để Trống");
            return View(ca);
            }
            if (ca.Gia <= 0)
            {
                ModelState.AddModelError("", "Giá bán phải lớn hơn 0");
                return View(ca);
            }
            else
            {
                updateCTSP.TenHang = ca.TenHang;
                updateCTSP.TenNSX = ca.TenNSX;
                updateCTSP.TenLoaiHang = ca.TenLoaiHang;
                updateCTSP.SoLuong = ca.SoLuong;
                updateCTSP.DonViTinh = ca.DonViTinh;
                updateCTSP.Gia = ca.Gia;
                updateCTSP.Anh = ca.Anh;
                db.SaveChanges();
                return RedirectToAction("DsSanPham");
            }
        }
        public ActionResult XoaSanPham(int MaHang)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            var xoa = db.HangHoas.Find(MaHang);
            db.HangHoas.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("DsSanPham");
        }
    }
}