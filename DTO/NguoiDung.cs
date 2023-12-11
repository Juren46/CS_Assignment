using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung
    {
        public string MaNguoiDung {  get; set; }
        public string MaPhanQuyen { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau {  get; set; }
        public string HoTen {  get; set; }
        public string? GioiTinh { get; set; }
        public DateOnly? NgaySinh {  get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email {  get; set; }
        public string? DiaChi {  get; set; }
        public string TrangThai {  get; set; }

        public NguoiDung() 
        { 
            MaNguoiDung = string.Empty;
            MaPhanQuyen = string.Empty;
            TenDangNhap = string.Empty;
            MatKhau = string.Empty;
            HoTen = string.Empty;
            TrangThai = "Đang hoạt động";
        }

        public NguoiDung(string maNguoiDung, string maPhanQuyen, string tenDangNhap, string matKhau, string hoTen, string? gioiTinh, DateOnly? ngaySinh, string? soDienThoai, string? email, string? diaChi, string trangThai)
        {
            MaNguoiDung = maNguoiDung;
            MaPhanQuyen = maPhanQuyen;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            Email = email;
            DiaChi = diaChi;
            TrangThai = trangThai;
        }
    }
}
