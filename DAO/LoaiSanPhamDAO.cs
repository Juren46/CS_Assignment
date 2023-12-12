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
    public class LoaiSanPhamDAO
    {
        public LoaiSanPhamDAO() { }

        public List<LoaiSanPham> LayTatCaLoaiSanPham()
        {
            List<LoaiSanPham> listLoaiSanPham = [];

            string query = "select * from LoaiSanPham";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        LoaiSanPham loaiSanPham = new()
                        {
                            MaLoaiSanPham = row["maLoaiSanPham"].ToString(),
                            TenLoaiSanPham = row["tenLoaiSanPham"].ToString(),
                            TrangThai = row["trangThai"].ToString()
                        };

                        listLoaiSanPham.Add(loaiSanPham);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listLoaiSanPham;
        }

        public LoaiSanPham LayLoaiSanPhamTheoMa(string maLoaiSanPham)
        {
            LoaiSanPham loaiSanPham = new();

            string query = "select * from LoaiSanPham where maLoaiSanPham = @maLoaiSanPham";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maLoaiSanPham", SqlDbType.Char) { Value = maLoaiSanPham }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    loaiSanPham.MaLoaiSanPham = dataTable.Rows[0]["maLoaiSanPham"].ToString();
                    loaiSanPham.TenLoaiSanPham = dataTable.Rows[0]["tenLoaiSanPham"].ToString();
                    loaiSanPham.TrangThai = dataTable.Rows[0]["trangThai"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return loaiSanPham;
        }

        public List<LoaiSanPham> TimKiemLoaiSanPham(string tuKhoa, string trangThai)
        {
            List<LoaiSanPham> listLoaiSanPham = [];

            string query = "select * from LoaiSanPham " +
                           "where (@tuKhoa = '' or lower(maLoaiSanPham) like @tuKhoa " +
                           "or tenLoaiSanPham collate Latin1_General_CI_AI like @tuKhoa) " +
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
                        LoaiSanPham loaiSanPham = new()
                        {
                            MaLoaiSanPham = row["maLoaiSanPham"].ToString(),
                            TenLoaiSanPham = row["tenLoaiSanPham"].ToString(),
                            TrangThai = row["trangThai"].ToString()
                        };

                        listLoaiSanPham.Add(loaiSanPham);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listLoaiSanPham;
        }

        public int DemSoLoaiSanPham()
        {
            int soLoaiSanPham = 0;

            string query = "select count(*) as soLoaiSanPham from LoaiSanPham";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
                soLoaiSanPham = (int)dataTable.Rows[0]["soLoaiSanPham"];

            return soLoaiSanPham;
        }

        public bool ThemLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            string query = "insert into LoaiSanPham values (@maLoaiSanPham, @tenLoaiSanPham, @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maLoaiSanPham", SqlDbType.Char) { Value = loaiSanPham.MaLoaiSanPham },
                new SqlParameter("@tenLoaiSanPham", SqlDbType.NVarChar) { Value = loaiSanPham.TenLoaiSanPham },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = loaiSanPham.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool XoaLoaiSanPham(string maLoaiSanPham)
        {
            string query = "update LoaiSanPham set trangThai = N'Đã xóa' where maLoaiSanPham = @maLoaiSanPham";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maLoaiSanPham", SqlDbType.Char) { Value = maLoaiSanPham }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool ChinhSuaLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            string query = "update LoaiSanPham set tenLoaiSanPham = @tenLoaiSanPham, trangThai = @trangThai where maLoaiSanPham = @maLoaiSanPham";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maLoaiSanPham", SqlDbType.Char) { Value = loaiSanPham.MaLoaiSanPham },
                new SqlParameter("@tenLoaiSanPham", SqlDbType.NVarChar) { Value = loaiSanPham.TenLoaiSanPham },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = loaiSanPham.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
