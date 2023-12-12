using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO SanPhamDAO { get; set; }

        public SanPhamBUS()
        {
            SanPhamDAO = new SanPhamDAO();
        }

        public List<SanPham> LayTatCaSanPham()
        {
            return SanPhamDAO.LayTatCaSanPham();
        }

        public SanPham LaySanPhamTheoMa(string maSanPham = "")
        {
            return SanPhamDAO.LaySanPhamTheoMa(maSanPham);
        }

        public List<SanPham> TimKiemSanPham(string tuKhoa = "", string maLoaiSanPham = "", string trangThai = "")
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            return SanPhamDAO.TimKiemSanPham(tuKhoa, maLoaiSanPham, trangThai);
        }

        public int DemSoSanPham()
        {
            return SanPhamDAO.DemSoSanPham();
        }

        public string ThemSanPham(SanPham sanPham)
        {
            if (string.IsNullOrEmpty(sanPham.MaLoaiSanPham) || string.IsNullOrEmpty(sanPham.TenSanPham) || string.IsNullOrEmpty(sanPham.DonViTinh) || sanPham.Anh == null || sanPham.Anh.Length <= 0)
                return "Vui lòng nhập đầy đủ thông tin!";

            if (sanPham.GiaBan == 0)
                return "Giá bán phải lớn hơn 0 đ!";

            if (SanPhamDAO.ThemSanPham(sanPham))
                return "Thêm sản phẩm thành công!";
            else
                return "Thêm sản phẩm thất bại!";
        }

        public string XoaSanPham(string maSanPham)
        {
            if (SanPhamDAO.XoaSanPham(maSanPham))
                return "Xóa sản phẩm thành công!";

            return "Xóa sản phẩm thất bại!";
        }

        public string ChinhSuaSanPham(SanPham sanPham)
        {
            if (string.IsNullOrEmpty(sanPham.MaLoaiSanPham) || string.IsNullOrEmpty(sanPham.TenSanPham) || string.IsNullOrEmpty(sanPham.DonViTinh) || sanPham.Anh == null || sanPham.Anh.Length <= 0)
                return "Vui lòng nhập đầy đủ thông tin!";

            if (sanPham.GiaBan == 0)
                return "Giá bán phải lớn hơn 0 đ!";

            if (SanPhamDAO.ChinhSuaSanPham(sanPham))
                return "Chỉnh sửa thông tin sản phẩm thành công!";
            else
                return "Chỉnh sửa thông tin sản phẩm thất bại!";
        }

        
    }
}

