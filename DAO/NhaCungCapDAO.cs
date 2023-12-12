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
    public class NhaCungCapDAO
    {
        public NhaCungCapDAO() { }

        public List<NhaCungCap> LayTatCaNhaCungCap()
        {
            List<NhaCungCap> listNhaCungCap = [];

            string query = "select * from NhaCungCap";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        NhaCungCap nhaCungCap = new()
                        {
                            MaNhaCungCap = row["maNhaCungCap"].ToString(),
                            TenNhaCungCap = row["tenNhaCungCap"].ToString(),
                            SoDienThoai = row["soDienThoai"]?.ToString(),
                            Email = row["email"]?.ToString(),
                            DiaChi = row["diaChi"]?.ToString(),
                            TrangThai = row["trangThai"].ToString()
                        };

                        listNhaCungCap.Add(nhaCungCap);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listNhaCungCap;
        }

        public NhaCungCap LayNhaCungCapTheoMa(string maNhaCungCap)
        {
            NhaCungCap nhaCungCap = new();

            string query = "select * from NhaCungCap where maNhaCungCap = @maNhaCungCap";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNhaCungCap", SqlDbType.Char) { Value = maNhaCungCap }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    nhaCungCap.MaNhaCungCap = dataTable.Rows[0]["maNhaCungCap"].ToString();
                    nhaCungCap.TenNhaCungCap = dataTable.Rows[0]["tenNhaCungCap"].ToString();
                    nhaCungCap.SoDienThoai = dataTable.Rows[0]["SoDienThoai"]?.ToString();
                    nhaCungCap.Email = dataTable.Rows[0]["email"]?.ToString();
                    nhaCungCap.DiaChi = dataTable.Rows[0]["diaChi"]?.ToString();
                    nhaCungCap.TrangThai = dataTable.Rows[0]["trangThai"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return nhaCungCap;
        }

        public List<NhaCungCap> TimKiemNhaCungCap(string tuKhoa, string trangThai)
        {
            List<NhaCungCap> listNhaCungCap = [];

            string query = "select * from nhaCungCap " +
                           "where (@tuKhoa = '' or lower(maNhaCungCap) like @tuKhoa " +
                           "or tenNhaCungCap collate Latin1_General_CI_AI like @tuKhoa " +
                           "or soDienThoai like @tuKhoa " +
                           "or lower(email) like tuKhoa " +
                           "or diaChi collate Latin1_General_CI_AI like @tuKhoa) " +
                           "and (@trangThai = '' or trangThai = @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tuKhoa", SqlDbType.NVarChar) { Value = "%" + tuKhoa + "%" },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = trangThai }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        NhaCungCap NhaCungCap = new()
                        {
                            MaNhaCungCap = row["maNhaCungCap"].ToString(),
                            TenNhaCungCap = row["tenNhaCungCap"].ToString(),
                            SoDienThoai = row["soDienThoai"]?.ToString(),
                            Email = row["email"]?.ToString(),
                            DiaChi = row["diaChi"]?.ToString(),
                            TrangThai = row["trangThai"].ToString()
                        };

                        listNhaCungCap.Add(NhaCungCap);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listNhaCungCap;
        }

        public int DemSoNhaCungCap()
        {
            int soNhaCungCap = 0;

            string query = "select count(*) as soNhaCungCap from NhaCungCap";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
                soNhaCungCap = (int)dataTable.Rows[0]["soNhaCungCap"];

            return soNhaCungCap;
        }

        public bool ThemNhaCungCap(NhaCungCap nhaCungCap)
        {
            string query = "insert into NhaCungCap values (@maNhaCungCap, @tenNhaCungCap, @soDienThoai, @email, @diaChi, @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNhaCungCap", SqlDbType.Char) { Value = nhaCungCap.MaNhaCungCap },
                new SqlParameter("@tenNhaCungCap", SqlDbType.NVarChar) { Value = nhaCungCap.TenNhaCungCap },

                new SqlParameter("@soDienThoai", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nhaCungCap.SoDienThoai) ? DBNull.Value : nhaCungCap.SoDienThoai },
                new SqlParameter("@email", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nhaCungCap.Email) ? DBNull.Value : nhaCungCap.Email },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(nhaCungCap.DiaChi) ? DBNull.Value : nhaCungCap.DiaChi },

                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = nhaCungCap.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool XoaNhaCungCap(string maNhaCungCap)
        {
            string query = "update NhaCungCap set trangThai = N'Ngừng hợp tác' where maNhaCungCap = @maNhaCungCap";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNhaCungCap", SqlDbType.Char) { Value = maNhaCungCap }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool ChinhSuaNhaCungCap(NhaCungCap nhaCungCap)
        {
            string query = "update NhaCungCap set tenNhaCungCap = @tenNhaCungCap, soDienThoai = @soDienThoai, email = @email, diaChi = @diaChi, trangThai = @trangThai where maNhaCungCap = @maNhaCungCap";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maNhaCungCap", SqlDbType.Char) { Value = nhaCungCap.MaNhaCungCap },
                new SqlParameter("@tenNhaCungCap", SqlDbType.NVarChar) { Value = nhaCungCap.TenNhaCungCap },

                new SqlParameter("@soDienThoai", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nhaCungCap.SoDienThoai) ? DBNull.Value : nhaCungCap.SoDienThoai },
                new SqlParameter("@email", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(nhaCungCap.Email) ? DBNull.Value : nhaCungCap.Email },
                new SqlParameter("@diaChi", SqlDbType.NVarChar) { Value = string.IsNullOrEmpty(nhaCungCap.DiaChi) ? DBNull.Value : nhaCungCap.DiaChi },

                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = nhaCungCap.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
