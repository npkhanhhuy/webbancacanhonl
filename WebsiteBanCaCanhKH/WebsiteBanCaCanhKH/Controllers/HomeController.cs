using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanCaCanhKH.Models;
using PagedList;

namespace WebsiteBanCaCanhKH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchString, int? page)
        {  
            QLBanCaCanhOnline db = new QLBanCaCanhOnline();
            int recordsPerPage = 20;

            if (!page.HasValue)
            {
                page = 1;
            }
            ViewBag.Keyword = searchString;

            var sp = db.HangHoas.ToList();
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


        public ActionResult GioiThieu()
        {

            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult Tintuc()
        {

            return View();
        }
        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogout");
        }
        public ActionResult top10loaica()
        {

            return View();
        }
    }
}