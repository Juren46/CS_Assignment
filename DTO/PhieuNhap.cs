using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap
    {
        public string MaPhieuNhap {  get; set; }
        public string MaNhaCungCap { get; set; }
        public string MaNguoiTao {  get; set; }
        public string? MaNguoiDuyet {  get; set; }
        public string? MaNguoiNhap {  get; set; }
        public DateTime ThoiGianTao {  get; set; }
        public DateTime? ThoiGianDuyet { get; set; }
        public DateTime? ThoiGianNhap {  get; set; }
        public ulong ThanhTien { get; set; }
        public string TrangThai { get; set; }

        public PhieuNhap() 
        { 
            MaPhieuNhap = string.Empty;
            MaNhaCungCap = string.Empty;
            MaNguoiTao = string.Empty;
            TrangThai = "Chờ duyệt";
        }

        public PhieuNhap(string maPhieuNhap, string maNhaCungCap, string maNguoiTao, string? maNguoiDuyet, string? maNguoiNhap, DateTime thoiGianTao, DateTime? thoiGianDuyet, DateTime? thoiGianNhap, ulong thanhTien, string trangThai)
        {
            MaPhieuNhap = maPhieuNhap;
            MaNhaCungCap = maNhaCungCap;
            MaNguoiTao = maNguoiTao;
            MaNguoiDuyet = maNguoiDuyet;
            MaNguoiNhap = maNguoiNhap;
            ThoiGianTao = thoiGianTao;
            ThoiGianDuyet = thoiGianDuyet;
            ThoiGianNhap = thoiGianNhap;
            ThanhTien = thanhTien;
            TrangThai = trangThai;
        }
    }
}
