using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShop.Models
{
    public class GioHang
    {
        //private int iMaSP;

        //public int IMaSP
        //{
        //    get { return iMaSP; }
        //    set { iMaSP = value; }
        //}
        Qlbanhang db = new Qlbanhang();
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sHinhanh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int Masp)
        {
            iMasp = Masp;
            Sanpham sp = db.Sanphams.Single(n => n.Masp == iMasp);
            sTensp = sp.Tensp;
            sHinhanh = sp.Hinhanh;
            dDonGia = double.Parse(sp.Giatien.ToString());
            iSoLuong = 1;
        }

    }
}