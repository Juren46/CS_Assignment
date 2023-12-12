using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiSanPhamBUS
    {
        LoaiSanPhamDAO LoaiSanPhamDAO { get; set; }

        public LoaiSanPhamBUS()
        {
            LoaiSanPhamDAO = new LoaiSanPhamDAO();
        }

        public List<LoaiSanPham> LayTatCaLoaiSanPham()
        {
            return LoaiSanPhamDAO.LayTatCaLoaiSanPham();
        }

        public LoaiSanPham LayLoaiSanPhamTheoMa(string maLoaiSanPham = "")
        {
            return LoaiSanPhamDAO.LayLoaiSanPhamTheoMa(maLoaiSanPham);
        }

        public List<LoaiSanPham> TimKiemLoaiSanPham(string tuKhoa = "", string trangThai = "")
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            return LoaiSanPhamDAO.TimKiemLoaiSanPham(tuKhoa, trangThai);
        }

        public int DemSoLoaiSanPham()
        {
            return LoaiSanPhamDAO.DemSoLoaiSanPham();
        }

        public string ThemLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            if (string.IsNullOrEmpty(loaiSanPham.TenLoaiSanPham))
                return "Vui lòng nhập đầy đủ thông tin!";
            
            if (LoaiSanPhamDAO.ThemLoaiSanPham(loaiSanPham))
                return "Thêm loại sản phẩm thành công!";
            else
                return "Thêm loại sản phẩm thất bại!";
        }

        public string XoaLoaiSanPham(string maLoaiSanPham)
        {
            if (LoaiSanPhamDAO.XoaLoaiSanPham(maLoaiSanPham))
                return "Xóa loại sản phẩm thành công!";

            return "Xóa loại sản phẩm thất bại!";
        }

        public string ChinhSuaLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            if (string.IsNullOrEmpty(loaiSanPham.TenLoaiSanPham))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (LoaiSanPhamDAO.ChinhSuaLoaiSanPham(loaiSanPham))
                return "Chỉnh sửa thông tin loại sản phẩm thành công!";
            else
                return "Chỉnh sửa thông tin loại sản phẩm thất bại!";
        }
    }
}
