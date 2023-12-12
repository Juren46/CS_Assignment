using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NguoiDungDAO
    {
        public NguoiDungDAO() { }

        public List<NguoiDung> LayTatCaNguoiDung()
        {
            List<NguoiDung> listNguoiDung = [];

            string query = "select * from NguoiDung";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        NguoiDung nguoiDung = new()
                        {
                            MaNguoiDung = row["maNguoiDung"].ToString(),
                            MaPhanQuyen = row["maPhanQuyen"].ToString(),
                            TenDangNhap = row["tenDangNhap"].ToString(),
                            MatKhau = row["matKhau"].ToString(),
                            HoTen = row["hoTen"].ToString(),
                            NgaySinh = row["ngaySinh"] == DBNull.Value ? null : (DateOnly?)row["ngaySinh"],
                            GioiTinh = row["gioiTinh"]?.ToString(),
                            SoDienThoai = row["soDienThoai"]?.ToString(),
                            Email = row["email"]?.ToString(),
                            DiaChi = row["diaChi"]?.ToString(),
                            TrangThai = row["trangThai"].ToString()
                        };

                        listNguoiDung.Add(nguoiDung);
                    }
                    catch(Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listNguoiDung;
        }

        public NguoiDung LayNguoiDungTheoMa(string maNguoiDung)
        {
            NguoiDung nguoiDung = new();

            string query = "select * from NguoiDung where maNguoiDung = @maNguoiDung";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNguoiDung", SqlDbType.Char) { Value = maNguoiDung }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    nguoiDung.MaNguoiDung = dataTable.Rows[0]["maNguoiDung"].ToString();
                    nguoiDung.MaPhanQuyen = dataTable.Rows[0]["maPhanQuyen"].ToString();
                    nguoiDung.TenDangNhap = dataTable.Rows[0]["tenDangNhap"].ToString();
                    nguoiDung.MatKhau = dataTable.Rows[0]["matKhau"].ToString();
                    nguoiDung.HoTen = dataTable.Rows[0]["hoTen"].ToString();
                    nguoiDung.NgaySinh = dataTable.Rows[0]["ngaySinh"] == DBNull.Value ? null : (DateOnly?)dataTable.Rows[0]["ngaySinh"];
                    nguoiDung.GioiTinh = dataTable.Rows[0]["gioiTinh"]?.ToString();
                    nguoiDung.SoDienThoai = dataTable.Rows[0]["soDienThoai"]?.ToString();
                    nguoiDung.Email = dataTable.Rows[0]["email"]?.ToString();
                    nguoiDung.DiaChi = dataTable.Rows[0]["diaChi"]?.ToString();
                    nguoiDung.TrangThai = dataTable.Rows[0]["trangThai"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return nguoiDung;
        }

        public NguoiDung LayNguoiDungTheoTenDangNhap(string tenDangNhap)
        {
            NguoiDung nguoiDung = new();

            string query = "select * from NguoiDung where tenDangNhap = @tenDangNhap";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tenDangNhap", SqlDbType.VarChar) { Value = tenDangNhap }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    nguoiDung.MaNguoiDung = dataTable.Rows[0]["maNguoiDung"].ToString();
                    nguoiDung.MaPhanQuyen = dataTable.Rows[0]["maPhanQuyen"].ToString();
                    nguoiDung.TenDangNhap = dataTable.Rows[0]["tenDangNhap"].ToString();
                    nguoiDung.MatKhau = dataTable.Rows[0]["matKhau"].ToString();
                    nguoiDung.HoTen = dataTable.Rows[0]["hoTen"].ToString();
                    nguoiDung.NgaySinh = dataTable.Rows[0]["ngaySinh"] == DBNull.Value ? null : (DateOnly?)dataTable.Rows[0]["ngaySinh"];
                    nguoiDung.GioiTinh = dataTable.Rows[0]["gioiTinh"]?.ToString();
                    nguoiDung.SoDienThoai = dataTable.Rows[0]["soDienThoai"]?.ToString();
                    nguoiDung.Email = dataTable.Rows[0]["email"]?.ToString();
                    nguoiDung.DiaChi = dataTable.Rows[0]["diaChi"]?.ToString();
                    nguoiDung.TrangThai = dataTable.Rows[0]["trangThai"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return nguoiDung;
        }

        public List<NguoiDung> LayNguoiDungTheoPhanQuyen(string maPhanQuyen)
        {
            List<NguoiDung> listNguoiDung = [];

            string query = "select * from NguoiDung where maPhanQuyen = @maPhanQuyen";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maPhanQuyen", SqlDbType.VarChar) { Value = maPhanQuyen }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        NguoiDung nguoiDung = new()
                        {
                            MaNguoiDung = row["maNguoiDung"].ToString(),
                            MaPhanQuyen = row["maPhanQuyen"].ToString(),
                            TenDangNhap = row["tenDangNhap"].ToString(),
                            MatKhau = row["matKhau"].ToString(),
                            HoTen = row["hoTen"].ToString(),
                            NgaySinh = row["ngaySinh"] == DBNull.Value ? null : (DateOnly?)row["ngaySinh"],
                            GioiTinh = row["gioiTinh"]?.ToString(),
                            SoDienThoai = row["soDienThoai"]?.ToString(),
                            Email = row["email"]?.ToString(),
                            DiaChi = row["diaChi"]?.ToString(),
                            TrangThai = row["trangThai"].ToString()
                        };

                        listNguoiDung.Add(nguoiDung);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listNguoiDung;
        }

        public List<NguoiDung> TimKiemNguoiDung(string tuKhoa, string maPhanQuyen, string gioiTinh, string trangThai)
        {
            List<NguoiDung> listNguoiDung = [];

            string query = "select * from NguoiDung " +
                           "where (@tuKhoa = '' or lower(maNguoiDung) like @tuKhoa " +
                           "or lower(tenDangNhap) like @tuKhoa " +
                           "or hoTen collate Latin1_General_CI_AI like @tuKhoa " +
                           "or soDienThoai like @tuKhoa " +
                           "or lower(email) like @tuKhoa " +
                           "or lower(diaChi) collate Latin1_General_CI_AI like @tuKhoa) " +
                           "and (@maPhanQuyen = '' or maPhanQuyen = @maPhanQuyen) " +
                           "and (@gioiTinh = '' or gioiTinh = @gioiTinh) " +
                           "and (@trangThai = '' or trangThai = @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tuKhoa", SqlDbType.NVarChar) { Value = "%" + tuKhoa + "%" },
                new SqlParameter("@maPhanQuyen", SqlDbType.Char) { Value = maPhanQuyen },
                new SqlParameter("@gioiTinh", SqlDbType.NVarChar) { Value = gioiTinh },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = trangThai },
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        NguoiDung nguoiDung = new()
                        {
                            MaNguoiDung = row["maNguoiDung"].ToString(),
                            MaPhanQuyen = row["maPhanQuyen"].ToString(),
                            TenDangNhap = row["tenDangNhap"].ToString(),
                            MatKhau = row["matKhau"].ToString(),
                            HoTen = row["hoTen"].ToString(),
                            NgaySinh = row["ngaySinh"] == DBNull.Value ? null : (DateOnly?)row["ngaySinh"],
                            GioiTinh = row["gioiTinh"]?.ToString(),
                            SoDienThoai = row["soDienThoai"]?.ToString(),
                            Email = row["email"]?.ToString(),
                            DiaChi = row["diaChi"]?.ToString(),
                            TrangThai = row["trangThai"].ToString()
                        };

                        listNguoiDung.Add(nguoiDung);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listNguoiDung;
        }

        public int DemSoNguoiDungTheoPhanQuyen(string maPhanQuyen)
        {
            int soNguoiDung = 0;

            string query = "select count(*) as soNguoiDung from NguoiDung where maPhanQuyen = @maPhanQuyen";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maPhanQuyen", SqlDbType.Char) { Value = maPhanQuyen }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
                soNguoiDung = (int)dataTable.Rows[0]["soNguoiDung"];

            return soNguoiDung;
        }

        public bool TenDangNhapTonTai(string tenDangNhap)
        {
            bool tonTai = false;

            string query = "select * from NguoiDung where tenDangNhap = @tenDangNhap";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tenDangNhap", SqlDbType.VarChar) { Value = tenDangNhap }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
                tonTai = true;

            return tonTai;
        }

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            bool thanhCong = false;

            string query = "select * from NguoiDung where tenDangNhap = @tenDangNhap and matKhau = @matKhau";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tenDangNhap", SqlDbType.VarChar) { Value = tenDangNhap },
                new SqlParameter("@matKhau", SqlDbType.VarChar) { Value = matKhau }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
                thanhCong = true;

            return thanhCong;
        }

        public bool KiemTraDangHoatDong(string tenDangNhap)
        {
            bool dangHoatDong = false;

            string query = "select * from NguoiDung where tenDangNhap = @tenDangNhap and trangThai = N'Đang hoạt động'";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tenDangNhap", SqlDbType.VarChar) { Value = tenDangNhap }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
                dangHoatDong = true;

            return dangHoatDong;
        }

        public bool ThemNguoiDung(NguoiDung nguoiDung)
        {
            string query = "insert into NguoiDung values (@maNguoiDung, @maPhanQuyen, @tenDangNhap, @matKhau, @hoTen, @gioiTinh, @ngaySinh, @soDienThoai, @email, @diaChi, @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNguoiDung", SqlDbType.Char) { Value = nguoiDung.MaNguoiDung },
                new SqlParameter("@maPhanQuyen", SqlDbType.Char) { Value = nguoiDung.MaPhanQuyen },
                new SqlParameter("@tenDangNhap", SqlDbType.VarChar) { Value = nguoiDung.TenDangNhap },
                new SqlParameter("@matKhau", SqlDbType.VarChar) { Value = nguoiDung.MatKhau },
                new SqlParameter("@hoTen", SqlDbType.NVarChar) { Value = nguoiDung.HoTen },

                new SqlParameter("@gioiTinh", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(nguoiDung.GioiTinh) ? DBNull.Value : nguoiDung.GioiTinh },
                new SqlParameter("@ngaySinh", SqlDbType.Date) { Value = nguoiDung.NgaySinh.HasValue ? DBNull.Value : nguoiDung.NgaySinh },
                new SqlParameter("@soDienThoai", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nguoiDung.SoDienThoai) ? DBNull.Value : nguoiDung.SoDienThoai },
                new SqlParameter("@email", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nguoiDung.Email) ? DBNull.Value : nguoiDung.Email },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(nguoiDung.DiaChi) ? DBNull.Value : nguoiDung.DiaChi },

                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = nguoiDung.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool XoaNguoiDung(string maNguoiDung)
        {
            string query = "update NguoiDung set trangThai = N'Đã xóa' where maNguoiDung = @maNguoiDung";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNguoiDung", SqlDbType.Char) { Value = maNguoiDung }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool ChinhSuaNguoiDung(NguoiDung nguoiDung)
        {
            string query = "update NguoiDung set tenDangNhap = @tenDangNhap, matKhau = @matKhau, hoTen = @hoTen, gioiTinh = @gioiTinh, ngaySinh = @ngaySinh, soDienThoai = @soDienThoai, email = @email, diaChi = @diaChi, trangThai = @trangThai where maNguoiDung = @maNguoiDung";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNguoiDung", SqlDbType.Char) { Value = nguoiDung.MaNguoiDung },
                new SqlParameter("@tenDangNhap", SqlDbType.VarChar) { Value = nguoiDung.TenDangNhap },
                new SqlParameter("@matKhau", SqlDbType.VarChar) { Value = nguoiDung.MatKhau },
                new SqlParameter("@hoTen", SqlDbType.NVarChar) { Value = nguoiDung.HoTen },

                new SqlParameter("@gioiTinh", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(nguoiDung.GioiTinh) ? DBNull.Value : nguoiDung.GioiTinh },
                new SqlParameter("@ngaySinh", SqlDbType.Date) { Value = nguoiDung.NgaySinh.HasValue ? DBNull.Value : nguoiDung.NgaySinh },
                new SqlParameter("@soDienThoai", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nguoiDung.SoDienThoai) ? DBNull.Value : nguoiDung.SoDienThoai },
                new SqlParameter("@email", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nguoiDung.Email) ? DBNull.Value : nguoiDung.Email },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(nguoiDung.MaNguoiDung) ? DBNull.Value : nguoiDung.DiaChi },

                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = nguoiDung.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
