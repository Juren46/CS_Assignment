using BUS.ChucNangKhac;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHangBUS
    {
        KhachHangDAO KhachHangDAO {  get; set; }

        public KhachHangBUS()
        {
            KhachHangDAO = new();
        }

        public List<KhachHang> LayTatCaKhachHang()
        {
            return KhachHangDAO.LayTatCaKhachHang();
        }

        public KhachHang LayKhachHangTheoMa(string maKhachHang = "")
        {
            return KhachHangDAO.LayKhachHangTheoMa(maKhachHang);
        }

        public List<KhachHang> TimKiemKhachHang(string tuKhoa = "", string hangThanhVien = "", string trangThai = "")
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            return KhachHangDAO.TimKiemKhachHang(tuKhoa, hangThanhVien, trangThai);
        }

        public int DemSoKhachHang()
        {
            return KhachHangDAO.DemSoKhachHang();
        }

        public string ThemKhachHang(KhachHang khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.HoTen) || string.IsNullOrEmpty(khachHang.SoDienThoai))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (!KiemTraDinhDang.KiemTraSoDienThoai(khachHang.SoDienThoai))
                return "Vui lòng nhập đúng số điện thoại!";
            
            if (KhachHangDAO.ThemKhachHang(khachHang))
                return "Thêm khách hàng thành công!";
            else
                return "Thêm khách hàng thất bại!";
        }

        public string ChinhSuaKhachHang(KhachHang khachHang)
        {
            if (string.IsNullOrEmpty(khachHang.HoTen) || string.IsNullOrEmpty(khachHang.SoDienThoai))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (!KiemTraDinhDang.KiemTraSoDienThoai(khachHang.SoDienThoai))
                return "Vui lòng nhập đúng số điện thoại!";

            if (KhachHangDAO.ChinhSuaKhachHang(khachHang))
                return "Chỉnh sửa thông tin khách hàng thành công!";
            else
                return "Chỉnh sửa thông tin khách hàng thất bại!";
        }

        public string XoaKhachHang(string maKhachHang = "")
        {
            if (KhachHangDAO.XoaKhachHang(maKhachHang))
                return "Xóa khách hàng thành công!";
            else
                return "Xóa khách hàng thất bại!";
        }
    }
}
