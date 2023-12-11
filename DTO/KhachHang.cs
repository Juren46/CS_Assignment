using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string MaKhachHang {  get; set; }
        public string HoTen {  get; set; }
        public string SoDienThoai { get; set; }
        public string HangThanhVien {  get; set; }
        public int DiemThanhVien { get; set; }
        public string TrangThai { get; set; }

        public KhachHang() 
        { 
            MaKhachHang = string.Empty;
            HoTen = string.Empty;
            SoDienThoai = string.Empty;
            HangThanhVien = "Đồng";
            TrangThai = "Đang hoạt động";
        }

        public KhachHang(string maKhachHang, string hoTen, string soDienThoai, string hangThanhVien, int diemThanhVien, string trangThai)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            HangThanhVien = hangThanhVien;
            DiemThanhVien = diemThanhVien;
            TrangThai = trangThai;
        }
    }
}
