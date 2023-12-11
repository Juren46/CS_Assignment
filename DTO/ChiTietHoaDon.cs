using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDon
    {
        public string MaHoaDon {  get; set; }
        public string MaSanPham { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public ulong ThanhTien { get; set; }

        public ChiTietHoaDon() 
        { 
            MaHoaDon = string.Empty;
            MaSanPham = string.Empty;
        }

        public ChiTietHoaDon(string maHoaDon, string maSanPham, int donGia, int soLuong, ulong thanhTien)
        {
            MaHoaDon = maHoaDon;
            MaSanPham = maSanPham;
            DonGia = donGia;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }
    }
}
