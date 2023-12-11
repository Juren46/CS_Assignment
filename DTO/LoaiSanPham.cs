using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSanPham
    {
        public string MaLoaiSanPham {  get; set; }
        public string TenLoaiSanPham { get; set; }
        public string TrangThai { get; set; }

        public LoaiSanPham() 
        { 
            MaLoaiSanPham = string.Empty;
            TenLoaiSanPham = string.Empty;
            TrangThai = "Đang sử dụng";
        }

        public LoaiSanPham(string maLoaiSanPham, string tenLoaiSanPham, string trangThai)
        {
            MaLoaiSanPham = maLoaiSanPham;
            TenLoaiSanPham = tenLoaiSanPham;
            TrangThai = trangThai;
        }
    }
}
