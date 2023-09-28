using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanCaCanhKH.Models
{
    public class GioHang
    {
        QLBanCaCanhOnline db = new QLBanCaCanhOnline();
        public int iMaHang { get; set; }
        public string sTenHang { get; set; }
        public string sAnhBia { get; set; }
        public double dGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dGia; }
        }
        public GioHang(int ms)
        {
            iMaHang = ms;
            HangHoa s = db.HangHoas.Single(n => n.MaHang == iMaHang);
            sTenHang = s.TenHang;
            sAnhBia = s.Anh;
            dGia = double.Parse(s.Gia.ToString());
            iSoLuong = 1;
        }
    }
}