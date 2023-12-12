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
    public class SanPhamDAO
    {
        public SanPhamDAO() { }

        public List<SanPham> LayTatCaSanPham()
        {
            List<SanPham> listSanPham = [];

            string query = "select * from SanPham";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        SanPham sanPham = new()
                        {
                            MaSanPham = row["maSanPham"].ToString(),
                            MaLoaiSanPham = row["maLoaiSanPham"].ToString(),
                            TenSanPham = row["tenSanPham"].ToString(),
                            DonViTinh = row["DonViTinh"].ToString(),
                            SoLuong = (int)row["SoLuong"],
                            GiaBan = (int)row["tenSanPham"],
                            Anh = (byte[])row["tenSanPham"],
                            TrangThai = row["trangThai"].ToString()
                        };

                        listSanPham.Add(sanPham);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listSanPham;
        }

        public SanPham LaySanPhamTheoMa(string maSanPham)
        {
            SanPham sanPham = new();

            string query = "select * from SanPham where maSanPham = @maSanPham";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maSanPham", SqlDbType.Char) { Value = maSanPham }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    sanPham.MaSanPham = dataTable.Rows[0]["maSanPham"].ToString();
                    sanPham.MaLoaiSanPham = dataTable.Rows[0]["maLoaiSanPham"].ToString();
                    sanPham.TenSanPham = dataTable.Rows[0]["tenSanPham"].ToString();
                    sanPham.DonViTinh = dataTable.Rows[0]["DonViTinh"].ToString();
                    sanPham.SoLuong = (int)dataTable.Rows[0]["SoLuong"];
                    sanPham.GiaBan = (int)dataTable.Rows[0]["tenSanPham"];
                    sanPham.Anh = (byte[])dataTable.Rows[0]["tenSanPham"];
                    sanPham.TrangThai = dataTable.Rows[0]["trangThai"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return sanPham;
        }

        public List<SanPham> TimKiemSanPham(string tuKhoa, string maLoaiSanPham, string trangThai)
        {
            List<SanPham> listSanPham = [];

            string query = "select * from SanPham " +
                "where (@tuKhoa = '' or lower(maSanPham) like @tuKhoa " +
                "or tenSanPham collate Latin1_General_CI_AI like @tuKhoa) " +
                "and (@maLoaiSanPham = '' or maLoaiSanPham = @maLoaiSanPham) " +
                "and (@trangThai = '' or trangThai = @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tuKhoa", SqlDbType.NVarChar) { Value = "%" + tuKhoa + "%" },
                new SqlParameter("@maLoaiSanPham", SqlDbType.Char) { Value = maLoaiSanPham },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = trangThai }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        SanPham sanPham = new()
                        {
                            MaSanPham = row["maSanPham"].ToString(),
                            MaLoaiSanPham = row["maLoaiSanPham"].ToString(),
                            TenSanPham = row["tenSanPham"].ToString(),
                            DonViTinh = row["DonViTinh"].ToString(),
                            SoLuong = (int)row["SoLuong"],
                            GiaBan = (int)row["tenSanPham"],
                            Anh = (byte[])row["tenSanPham"],
                            TrangThai = row["trangThai"].ToString()
                        };

                        listSanPham.Add(sanPham);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listSanPham;
        }

        public int DemSoSanPham()
        {
            int soSanPham = 0;

            string query = "select count(*) as soSanPham from SanPham";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
                soSanPham = (int)dataTable.Rows[0]["soSanPham"];

            return soSanPham;
        }

        public bool ThemSanPham(SanPham sanPham)
        {
            string query = "insert into SanPham values (@maSanPham, @maLoaiSanPham, @tenSanPham, @donViTinh, @soLuong, @giaBan, @anh, @trangThai)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maSanPham", SqlDbType.Char) { Value = sanPham.MaSanPham },
                new SqlParameter("@maLoaiSanPham", SqlDbType.Char) { Value = sanPham.MaLoaiSanPham },
                new SqlParameter("@tenSanPham", SqlDbType.NVarChar) { Value = sanPham.TenSanPham },
                new SqlParameter("@donViTinh", SqlDbType.NVarChar) { Value = sanPham.DonViTinh },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = sanPham.SoLuong },
                new SqlParameter("@giaBan", SqlDbType.Money) { Value = sanPham.GiaBan },
                new SqlParameter("@anh", SqlDbType.Image) { Value = sanPham.Anh },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = sanPham.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool XoaSanPham(string maSanPham)
        {
            string query = "update SanPham set trangThai = N'Ngừng kinh doanh' where maSanPham = @maSanPham";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maSanPham", SqlDbType.Char) { Value = maSanPham }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool ChinhSuaSanPham(SanPham sanPham)
        {
            string query = "update SanPham set tenSanPham = @tenSanPham, donViTinh = @donViTinh, @soLuong = soLuong, giaBan = @giaBan, anh = @anh, trangThai = @trangThai where maSanPham = @maSanPham;" +
                           "update SanPham set trangThai = N'Hết hàng' where maSanPham = @maSanPham and soLuong = 0; " +
                           "update SanPham set trangThai = N'Đang bán' where maSanPham = @maSanPham and soLuong > 0";
            
            SqlParameter[] parameters =
            [
                new SqlParameter("@maSanPham", SqlDbType.Char) { Value = sanPham.MaSanPham },
                new SqlParameter("@maLoaiSanPham", SqlDbType.Char) { Value = sanPham.MaLoaiSanPham },
                new SqlParameter("@tenSanPham", SqlDbType.NVarChar) { Value = sanPham.TenSanPham },
                new SqlParameter("@donViTinh", SqlDbType.NVarChar) { Value = sanPham.DonViTinh },
                new SqlParameter("@soLuong", SqlDbType.Int) { Value = sanPham.SoLuong },
                new SqlParameter("@giaBan", SqlDbType.Money) { Value = sanPham.GiaBan },
                new SqlParameter("@anh", SqlDbType.Image) { Value = sanPham.Anh },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = sanPham.TrangThai }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
