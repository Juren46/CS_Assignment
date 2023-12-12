using DAO;
using DTO;
using BUS.ChucNangKhac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NguoiDungBUS
    {
        readonly NguoiDungDAO nguoiDungDAO;

        public NguoiDungBUS() 
        { 
            nguoiDungDAO = new();
        }

        public List<NguoiDung> LayTatCaNguoiDung()
        {
            return nguoiDungDAO.LayTatCaNguoiDung();
        }

        public NguoiDung LayNguoiDungTheoMa(string maNguoiDung = "")
        {
            return nguoiDungDAO.LayNguoiDungTheoMa(maNguoiDung);
        }

        public NguoiDung LayNguoiDungTheoTenDangNhap(string tenDangNhap = "")
        {
            return nguoiDungDAO.LayNguoiDungTheoTenDangNhap(tenDangNhap);
        }

        public List<NguoiDung> LayNguoiDungTheoPhanQuyen(string maPhanQuyen = "")
        {
            return nguoiDungDAO.LayNguoiDungTheoPhanQuyen(maPhanQuyen);
        }

        public List<NguoiDung> TimKiemNguoiDung(string tuKhoa = "", string maPhanQuyen = "", string gioiTinh = "", string trangThai = "")
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            return nguoiDungDAO.TimKiemNguoiDung(tuKhoa, maPhanQuyen, gioiTinh, trangThai);
        }

        public int DemSoNguoiDungTheoPhanQuyen(string maPhanQuyen = "")
        {
            return nguoiDungDAO.DemSoNguoiDungTheoPhanQuyen(maPhanQuyen);
        }

        public bool TenDangNhapTonTai(string tenDangNhap = "")
        {
            return nguoiDungDAO.TenDangNhapTonTai(tenDangNhap);
        }

        public bool KiemTraDangHoatDong(string tenDangNhap = "")
        {
           return nguoiDungDAO.KiemTraDangHoatDong(tenDangNhap);
        }

        public bool KiemTraDangNhap(string tenDangNhap = "", string matKhau = "")
        {
            return nguoiDungDAO.KiemTraDangNhap(tenDangNhap, matKhau);
        }

        public string DangNhap(string tenDangNhap = "", string matKhau = "")
        {
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (!KiemTraDangNhap(tenDangNhap, matKhau))
                return "Thông tin đăng nhập không chính xác!";

            if (!KiemTraDangHoatDong(tenDangNhap))
                return "Tài khoản đã ngừng hoạt động!";

            return "Đăng nhập thành công!";
        }

        public string ThemNguoiDung(NguoiDung nguoiDung)
        {
            if (string.IsNullOrEmpty(nguoiDung.MaNguoiDung) || string.IsNullOrEmpty(nguoiDung.MaPhanQuyen) || string.IsNullOrEmpty(nguoiDung.TenDangNhap) || string.IsNullOrEmpty(nguoiDung.MatKhau) || string.IsNullOrEmpty(nguoiDung.HoTen))
                return "Vui lòng nhập đầy đủ thông tin (phân quyền, họ tên, thông tin đăng nhập không được để trống)!";

            if (TenDangNhapTonTai(nguoiDung.TenDangNhap))
                return "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!";

            if (!string.IsNullOrEmpty(nguoiDung.SoDienThoai) && KiemTraDinhDang.KiemTraSoDienThoai(nguoiDung.SoDienThoai))
                return "Vui lòng nhập đúng số điện thoại!";

            if (!string.IsNullOrEmpty(nguoiDung.Email) && KiemTraDinhDang.KiemTraEmail(nguoiDung.Email))
                return "Vui lòng nhập đúng email!";

            if (nguoiDung.NgaySinh.HasValue)
                nguoiDung.NgaySinh = DateOnly.ParseExact(nguoiDung.NgaySinh?.ToString("yyyy/MM/dd"), "yyyy/MM/dd", null);

            if (nguoiDungDAO.ThemNguoiDung(nguoiDung))
                return "Thêm người dùng thành công!";
            else
                return "Thêm người dùng thất bại!";
        }

        public string ChinhSuaNguoiDung(NguoiDung nguoiDung)
        {
            if (string.IsNullOrEmpty(nguoiDung.TenDangNhap) || string.IsNullOrEmpty(nguoiDung.MatKhau) || string.IsNullOrEmpty(nguoiDung.HoTen))
                return "Vui lòng nhập đầy đủ thông tin (Họ tên, thông tin đăng nhập không được để trống)!";

            if (TenDangNhapTonTai(nguoiDung.TenDangNhap))
                return "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!";

            if (!string.IsNullOrEmpty(nguoiDung.SoDienThoai) && KiemTraDinhDang.KiemTraSoDienThoai(nguoiDung.SoDienThoai))
                return "Vui lòng nhập đúng số điện thoại!";

            if (!string.IsNullOrEmpty(nguoiDung.Email) && KiemTraDinhDang.KiemTraEmail(nguoiDung.Email))
                return "Vui lòng nhập đúng email!";

            if (nguoiDung.NgaySinh.HasValue)
                nguoiDung.NgaySinh = DateOnly.ParseExact(nguoiDung.NgaySinh?.ToString("yyyy/MM/dd"), "yyyy/MM/dd", null);

            if (nguoiDungDAO.ChinhSuaNguoiDung(nguoiDung))
                return "Chỉnh sửa thông tin người dùng thành công!";
            else
                return "Chỉnh sửa thông tin người dùng thất bại!";
        }

        public string DoiMatKhau(string maNguoiDung = "", string matKhauCu = "", string matKhauMoi = "", string xacNhanMatKhau = "")
        {
            if (string.IsNullOrEmpty(maNguoiDung) || string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(xacNhanMatKhau))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (!KiemTraDangNhap(LayNguoiDungTheoMa(maNguoiDung).TenDangNhap, matKhauCu))
                return "Mật khẩu cũ không chính xác!";

            if (matKhauMoi.Equals(matKhauCu))
                return "Mật khẩu mới phải khác mật khẩu cũ!";

            if (matKhauMoi.Equals(xacNhanMatKhau))
                return "Xác nhận mật khẩu mới không chính xác!";

            NguoiDung nguoiDung = LayNguoiDungTheoMa(maNguoiDung);
            nguoiDung.MatKhau = matKhauMoi;

            if (ChinhSuaNguoiDung(nguoiDung).Equals("Chỉnh sửa thông tin người dùng thành công!"))
                return "Đổi mật khẩu thành công!";
            else
                return "Đổi mật khẩu thất bại!";
        }

        public string XoaNguoiDung(string maNguoiDung = "")
        {
            if (nguoiDungDAO.XoaNguoiDung(maNguoiDung))
                return "Xóa người dùng thành công!";
            else
                return "Xóa người dùng thất bại!";
        }
    }
}
