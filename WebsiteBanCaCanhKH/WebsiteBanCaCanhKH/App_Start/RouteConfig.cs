using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteBanCaCanhKH
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebsiteBanCaCanhKH.Controllers" }
            );

            routes.MapRoute(

            name: "DanhSachCa",

            url: "San-Pham/Danh-Sach-San-Pham",

            defaults: new { controller = "DSSanPham", action = "DanhSachCa" }

            );


            routes.MapRoute(

            name: "DSSanPham",

            url: "DS-San-Pham",

            defaults: new { controller = "DSSanPham", action = "DanhSachCa" }

            );




            routes.MapRoute(

            name: "SuaChiTietSP",

            url: "San-Pham/Sua/{MaHang}",

            defaults: new { controller = "DSSanPham", action = "SuaChiTietSP", MaHang = @"\d{1,4}" }

            );


            routes.MapRoute(

            name: "ChiTietSP",

            url: "San-Pham/{TenHang}/{MaHang}",

            defaults: new { controller = "DSSanPham", action = "SuaChiTietSP", TenHang = (string)null, MaHang = @"\d{1,4}" }

            );
        }
    }
}
