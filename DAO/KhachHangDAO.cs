using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        public KhachHangDAO() { }

        public List<KhachHang> LayTatCaKhachHang()
        {
            List<KhachHang> listKhachHang = [];

            string query = "select * from KhachHang";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        KhachHang khachHang = new()
                        {
                            MaKhachHang = row["maKhachHang"].ToString(),
                            HoTen = row["hoTen"].ToString(),
                            SoDienThoai = row["soDienThoai"].ToString(),
                            HangThanhVien = row["hangThanhVien"].ToString(),
                            DiemThanhVien = (int)row["diemThanhVien"],
                            TrangThai = row["trangThai"].ToString()
                        };

                        listKhachHang.Add(khachHang);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listKhachHang;
        }

        public KhachHang LayKhachHangTheoMa(string maKhachHang)
        {
            KhachHang khachHang = new();

            string query = "select * from KhachHang where maKhachHang = @maKhachHang";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maKhachHang", SqlDbType.Char) { Value = maKhachHang }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    khachHang.MaKhachHang = dataTable.Rows[0]["maKhachHang"].ToString();
                    khachHang.HoTen = dataTable.Rows[0]["hoTen"].ToString();
                    khachHang.SoDienThoai = dataTable.Rows[0]["soDienThoai"].ToString();
                    khachHang.HangThanhVien = dataTable.Rows[0]["hangThanhVien"].ToString();
                    khachHang.DiemThanhVien = (int)dataTable.Rows[0]["diemThanhVien"];
                    khachHang.TrangThai = dataTable.Rows[0]["trangThai"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return khachHang;
        }

        public List<KhachHang> TimKiemKhachHang(string tuKhoa, string hangThanhVien, string trangThai)
        {
            List<KhachHang> listKhachHang = [];

            string query = "select * from KhachHang " +
                           "where (@tuKhoa = '' or lower(maKhachHang) like @tuKhoa " +
                           "or hoTen collate Latin1_General_CI_AI like @tuKhoa) " +
                           "and (@hangThanhVien = '' or hangThanhVien = @hangThanhVien) " +
                           "and (@trangThai = '' or trangThai = @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tuKhoa", SqlDbType.NVarChar) { Value = "%" + tuKhoa + "%" },
                new SqlParameter("@hangThanhVien", SqlDbType.NVarChar) { Value = hangThanhVien },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = trangThai }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        KhachHang khachHang = new()
                        {
                            MaKhachHang = row["maKhachHang"].ToString(),
                            HoTen = row["hoTen"].ToString(),
                            SoDienThoai = row["soDienThoai"].ToString(),
                            HangThanhVien = row["hangThanhVien"].ToString(),
                            DiemThanhVien = (int)row["diemThanhVien"],
                            TrangThai = row["trangThai"].ToString()
                        };

                        listKhachHang.Add(khachHang);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listKhachHang;
        }

        public int DemSoKhachHang()
        {
            int soKhachHang = 0;

            string query = "select count(*) as soKhachHang from KhachHang";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
                soKhachHang = (int)dataTable.Rows[0]["soKhachHang"];

            return soKhachHang;
        }

        public bool ThemKhachHang(KhachHang khachHang)
        {
            string query = "insert into KhachHang values (@maKhachHang, @hoTen, @soDienThoai, @hangThanhVien, @diemThanhVien, @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maKhachHang", SqlDbType.Char) { Value = khachHang.MaKhachHang },
                new SqlParameter("@hoTen", SqlDbType.NVarChar) { Value = khachHang.HoTen },
                new SqlParameter("@soDienThoai", SqlDbType.VarChar) { Value = khachHang.SoDienThoai },
                new SqlParameter("@hangThanhVien", SqlDbType.NVarChar) { Value = khachHang.HangThanhVien },
                new SqlParameter("@diemThanhVien", SqlDbType.Int) { Value = khachHang.DiemThanhVien },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = khachHang.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool XoaKhachHang(string maKhachHang)
        {
            string query = "update KhachHang set trangThai = N'Đã xóa' where maKhachHang = @maKhachHang";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maKhachHang", SqlDbType.Char) { Value = maKhachHang }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool ChinhSuaKhachHang(KhachHang khachHang)
        {
            string query = "update KhachHang set hoTen = @hoTen, soDienThoai = @soDienThoai where maKhachHang = @maKhachHang";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maKhachHang", SqlDbType.Char) { Value = khachHang.MaKhachHang },
                new SqlParameter("@hoTen", SqlDbType.NVarChar) { Value = khachHang.HoTen },
                new SqlParameter("@soDienThoai", SqlDbType.VarChar) { Value = khachHang.SoDienThoai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
