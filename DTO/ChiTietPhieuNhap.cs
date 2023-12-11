using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaSanPham { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public ulong ThanhTien { get; set; }

        public ChiTietPhieuNhap()
        {
            MaPhieuNhap = string.Empty;
            MaSanPham = string.Empty;
        }

        public ChiTietPhieuNhap(string maPhieuNhap, string maSanPham, int donGia, int soLuong, ulong thanhTien)
        {
            MaPhieuNhap = maPhieuNhap;
            MaSanPham = maSanPham;
            DonGia = donGia;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }
    }
}
