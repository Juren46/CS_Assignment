using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuyenMai
    {
        public string MaKhuyenMai {  get; set; }
        public string TenKhuyenMai { get; set; }
        public string LoaiGiaTri { get; set; }
        public float GiaTri { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        
        public KhuyenMai() 
        { 
            MaKhuyenMai = string.Empty;
            TenKhuyenMai = string.Empty;
            LoaiGiaTri = string.Empty;
        }

        public KhuyenMai(string maKhuyenMai, string tenKhuyenMai, string loaiGiaTri, float giaTri, DateTime thoiGianBatDau, DateTime thoiGianKetThuc)
        {
            MaKhuyenMai = maKhuyenMai;
            TenKhuyenMai = tenKhuyenMai;
            LoaiGiaTri = loaiGiaTri;
            GiaTri = giaTri;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianKetThuc = thoiGianKetThuc;
        }
    }
}
