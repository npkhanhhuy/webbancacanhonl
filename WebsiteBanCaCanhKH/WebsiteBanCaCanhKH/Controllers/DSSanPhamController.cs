using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebsiteBanCaCanhKH.Models;
using PagedList;
using System.Web.UI;

namespace WebsiteBanCaCanhKH.Controllers
{
    public class DSSanPhamController : Controller
    {
        // GET: SanPham
        // Cá
        public ActionResult DanhSachCa(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "cá" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);

        }
        public ActionResult DanhSachHo(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "hồ" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);
        }
        public ActionResult DanhSachMayOxy(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "máy oxy" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);
        }
        public ActionResult DanhSachCayTS(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "cây thủy sinh" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);
        }
        public ActionResult DanhSachDen(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "đèn" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);
        }
        public ActionResult DanhSachMayBom(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "máy bơm" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);
        }
        public ActionResult DanhSachTA(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "thức ăn" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);
        }
        public ActionResult DanhSachThuoc(string searchString, int? page)
        {
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 12;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = from HangHoa in db.HangHoas.ToList() where HangHoa.TenLoaiHang == "thuốc" select HangHoa;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    sp = sp.Where(s => s.TenHang.Contains(searchString)).ToList();
                }
            }
            catch (Exception ex) { }
            sp.OrderByDescending(v => v.MaHang);

            var cas = sp.ToPagedList(page.Value, recordsPerPage);
            return View(cas);
        }
 
    }
}