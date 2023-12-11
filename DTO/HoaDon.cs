using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public string MaHoaDon {  get; set; }
        public string MaNhanVien {  get; set; }
        public string? MaKhachHang { get; set; }
        public string? MaKhuyenMai {  get; set; }
        public string? TenKhuyenMai { get; set; }
        public DateTime ThoiGianTao {  get; set; }
        public ulong TongTien {  get; set; }
        public ulong GiamGia {  get; set; }
        public ulong ThanhTien { get; set; }
        public ulong TienNhan {  get; set; }
        public ulong TienThua { get; set; }

        public HoaDon() 
        { 
            MaHoaDon = string.Empty;
            MaNhanVien = string.Empty;
        } 

        public HoaDon(string maHoaDon, string maNhanVien, string? maKhachHang, string? maKhuyenMai, string? tenKhuyenMai, DateTime thoiGianTao, ulong tongTien, ulong giamGia, ulong thanhTien, ulong tienNhan, ulong tienThua)
        {
            MaHoaDon = maHoaDon;
            MaNhanVien = maNhanVien;
            MaKhachHang = maKhachHang;
            MaKhuyenMai = maKhuyenMai;
            TenKhuyenMai = tenKhuyenMai;
            ThoiGianTao = thoiGianTao;
            TongTien = tongTien;
            GiamGia = giamGia;
            ThanhTien = thanhTien;
            TienNhan = tienNhan;
            TienThua = tienThua;
        }
    }
}
