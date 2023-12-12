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
    public class PhieuNhapDAO
    {
        public PhieuNhapDAO() { }

        public List<PhieuNhap> LayTatCaPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = [];

            string query = "select * from PhieuNhap";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        PhieuNhap PhieuNhap = new()
                        {
                            MaPhieuNhap = row["maPhieuNhap"].ToString(),
                            MaNhaCungCap = row["maNhaCungCap"].ToString(),
                            MaNguoiTao = row["maPhieuNhap"].ToString(),
                            MaNguoiDuyet = row["maNguoiDuyet"]?.ToString(),
                            MaNguoiNhap = row["maNguoiNhap"]?.ToString(),
                            ThoiGianTao = (DateTime)row["thoiGianTao"],
                            ThoiGianDuyet = (DateTime?)row["thoiGianDuyet"],
                            ThoiGianNhap = (DateTime?)row["thoiGianNhap"],
                            ThanhTien = (ulong)row["thanhTien"],
                            TrangThai = row["trangThai"].ToString()
                        };

                        listPhieuNhap.Add(PhieuNhap);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listPhieuNhap;
        }

        public PhieuNhap LayPhieuNhapTheoMa(string maPhieuNhap)
        {
            PhieuNhap phieuNhap = new();

            string query = "select * from PhieuNhap where maPhieuNhap = @maPhieuNhap";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maPhieuNhap", SqlDbType.Char) { Value = maPhieuNhap }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    phieuNhap.MaPhieuNhap = dataTable.Rows[0]["maPhieuNhap"].ToString();
                    phieuNhap.MaNhaCungCap = dataTable.Rows[0]["maNhaCungCap"].ToString();
                    phieuNhap.MaNguoiTao = dataTable.Rows[0]["maPhieuNhap"].ToString();
                    phieuNhap.MaNguoiDuyet = dataTable.Rows[0]["maNguoiDuyet"]?.ToString();
                    phieuNhap.MaNguoiNhap = dataTable.Rows[0]["maNguoiNhap"]?.ToString();
                    phieuNhap.ThoiGianTao = (DateTime)dataTable.Rows[0]["thoiGianTao"];
                    phieuNhap.ThoiGianDuyet = (DateTime?)dataTable.Rows[0]["thoiGianDuyet"];
                    phieuNhap.ThoiGianNhap = (DateTime?)dataTable.Rows[0]["thoiGianNhap"];
                    phieuNhap.ThanhTien = (ulong)dataTable.Rows[0]["thanhTien"];
                    phieuNhap.TrangThai = dataTable.Rows[0]["trangThai"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return phieuNhap;
        }

        public List<PhieuNhap> TimKiemPhieuNhap(string tuKhoa, string tuyChonThoiGian, DateTime thoiGian, string trangThai)
        {
            List<PhieuNhap> listPhieuNhap = [];

            string query = "select * from PhieuNhap " +
                           "where (@tuKhoa = '' or lower(maPhieuNhap) like @tuKhoa) " +
                           "and (@trangThai = '' or trangThai = @trangThai)";
            
            /*switch (trangThai)
            {
                case "Chưa duyệt":
                    switch ()
            }*/

            SqlParameter[] parameters =
            [
                new SqlParameter("@tuKhoa", SqlDbType.NVarChar) { Value = "%" + tuKhoa + "%" },
                new SqlParameter("@thoiGian", SqlDbType.DateTime2) { Value = thoiGian },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = trangThai }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        PhieuNhap PhieuNhap = new()
                        {
                            MaPhieuNhap = row["maPhieuNhap"].ToString(),
                            MaNhaCungCap = row["maNhaCungCap"].ToString(),
                            MaNguoiTao = row["maPhieuNhap"].ToString(),
                            MaNguoiDuyet = row["maNguoiDuyet"]?.ToString(),
                            MaNguoiNhap = row["maNguoiNhap"]?.ToString(),
                            ThoiGianTao = (DateTime)row["thoiGianTao"],
                            ThoiGianDuyet = (DateTime?)row["thoiGianDuyet"],
                            ThoiGianNhap = (DateTime?)row["thoiGianNhap"],
                            ThanhTien = (ulong)row["thanhTien"],
                            TrangThai = row["trangThai"].ToString()
                        };

                        listPhieuNhap.Add(PhieuNhap);
                    }
                    catch (Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listPhieuNhap;
        }

        public int DemSoPhieuNhapTheoNgay(DateTime ngay) 
        { 
            int soPhieuNhap = 0;

            string query = "select count(*) as soPhieuNhap from PhieuNhap where convert(DATE, thoiGianTao) = @ngay";

            SqlParameter[] parameters =
            [
                new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay.Date }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
                soPhieuNhap = (int)dataTable.Rows[0]["soPhieuNhap"];

            return soPhieuNhap;
        }

        /*public bool DuyetPhieuNhap(string maPhieuNhap, string tuyChonDuyet)
        {
            string query = "update PhieuNhap set trangThai = @trangThai where maPhieuNhap = @maPhieuNhap;";

            string trangThai = "";

            switch (tuyChonDuyet)
            {
                case "Duyệt":
                    trangThai = "Đã duyệt";
                    break;
                case "Không duyệt":
                    trangThai = "Không duyệt";
                    break;
            }

            SqlParameter[] parameters =
            [
                new SqlParameter("@maPhieuNhap", SqlDbType.Char) { Value = maPhieuNhap },
                new SqlParameter("@trangThai", SqlDbType.NVarChar) { Value = trangThai },
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public bool NhapHang(string maPhieuNhap)
        {
            string query = "update PhieuNhap set trangThai = N'Đã nhập hàng' where maPhieuNhap = @maPhieuNhap;";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maPhieuNhap", SqlDbType.Char) { Value = maPhieuNhap }
            ];

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }*/
    }
}
