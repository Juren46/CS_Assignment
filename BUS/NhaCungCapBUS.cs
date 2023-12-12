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
    public class NhaCungCapBUS
    {
        NhaCungCapDAO NhaCungCapDAO { get; set; }

        public NhaCungCapBUS()
        {
            NhaCungCapDAO = new NhaCungCapDAO();
        }

        public List<NhaCungCap> LayTatCaNhaCungCap()
        {
            return NhaCungCapDAO.LayTatCaNhaCungCap();
        }

        public NhaCungCap LayNhaCungCapTheoMa(string maNhaCungCap = "")
        {
            return NhaCungCapDAO.LayNhaCungCapTheoMa(maNhaCungCap);
        }

        public List<NhaCungCap> TimKiemNhaCungCap(string tuKhoa = "", string trangThai = "")
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            return NhaCungCapDAO.TimKiemNhaCungCap(tuKhoa, trangThai);
        }

        public int DemSoNhaCungCap()
        {
            return NhaCungCapDAO.DemSoNhaCungCap();
        }

        public string ThemNhaCungCap(NhaCungCap nhaCungCap)
        {
            if (string.IsNullOrEmpty(nhaCungCap.TenNhaCungCap))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (!string.IsNullOrEmpty(nhaCungCap.SoDienThoai) && KiemTraDinhDang.KiemTraSoDienThoai(nhaCungCap.SoDienThoai))
                return "Vui lòng nhập đúng số điện thoại!";

            if (!string.IsNullOrEmpty(nhaCungCap.Email) && KiemTraDinhDang.KiemTraEmail(nhaCungCap.Email))
                return "Vui lòng nhập đúng email!";

            if (NhaCungCapDAO.ThemNhaCungCap(nhaCungCap))
                return "Thêm nhà cung cấp thành công!";
            else
                return "Thêm nhà cung cấp thất bại!";
        }

        public string XoaNhaCungCap(string maNhaCungCap)
        {
            if (NhaCungCapDAO.XoaNhaCungCap(maNhaCungCap))
                return "Xóa loại sản phẩm thành công!";

            return "Xóa loại sản phẩm thất bại!";
        }

        public string ChinhSuaNhaCungCap(NhaCungCap nhaCungCap)
        {
            if (string.IsNullOrEmpty(nhaCungCap.TenNhaCungCap))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (!string.IsNullOrEmpty(nhaCungCap.SoDienThoai) && KiemTraDinhDang.KiemTraSoDienThoai(nhaCungCap.SoDienThoai))
                return "Vui lòng nhập đúng số điện thoại!";

            if (!string.IsNullOrEmpty(nhaCungCap.Email) && KiemTraDinhDang.KiemTraEmail(nhaCungCap.Email))
                return "Vui lòng nhập đúng email!";

            if (NhaCungCapDAO.ChinhSuaNhaCungCap(nhaCungCap))
                return "Chỉnh sửa thông tin loại sản phẩm thành công!";
            else
                return "Chỉnh sửa thông tin loại sản phẩm thất bại!";
        }
    }
}
