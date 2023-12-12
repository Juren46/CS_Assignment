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
    public class PhanQuyenDAO
    {
        public PhanQuyenDAO() { }

        public List<PhanQuyen> LayTatCaPhanQuyen()
        {
            List<PhanQuyen> listPhanQuyen = [];

            string query = "select * from PhanQuyen";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach(DataRow row in dataTable.Rows)
                {
                    try
                    {
                        PhanQuyen phanQuyen = new()
                        {
                            MaPhanQuyen = row["maPhanQuyen"].ToString(),
                            TenPhanQuyen = row["tenPhanQuyen"].ToString()
                        };

                        listPhanQuyen.Add(phanQuyen);
                    }
                    catch(Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listPhanQuyen;
        }

        public PhanQuyen LayPhanQuyenTheoMa(string maPhanQuyen)
        {
            PhanQuyen phanQuyen = new();

            string query = "select * from PhanQuyen where maPhanQuyen = @maPhanQuyen";

            SqlParameter[] parameters =
            [
                new SqlParameter("@maPhanQuyen", SqlDbType.Char) { Value = maPhanQuyen }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    phanQuyen.MaPhanQuyen = dataTable.Rows[0]["maPhanQuyen"].ToString();
                    phanQuyen.TenPhanQuyen = dataTable.Rows[0]["tenPhanQuyen"].ToString();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return phanQuyen;
        }

        public List<PhanQuyen> TimKiemPhanQuyen(string tuKhoa)
        {
            List<PhanQuyen> listPhanQuyen = [];
            
            string query = "select * from PhanQuyen " +
                           "where (@tuKhoa = '' or lower(maPhanQuyen) like @tuKhoa " +
                           "or tenPhanQuyen collate Latin1_General_CI_AI like @tuKhoa)";

            SqlParameter[] parameters =
            [
                new SqlParameter("@tuKhoa", SqlDbType.NVarChar) { Value = "%" + tuKhoa + "%" }
            ];

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        PhanQuyen phanQuyen = new()
                        {
                            MaPhanQuyen = row["maPhanQuyen"].ToString(),
                            TenPhanQuyen = row["tenPhanQuyen"].ToString()
                        };

                        listPhanQuyen.Add(phanQuyen);
                    }
                    catch(Exception e) { Debug.WriteLine(e.Message); }
                }
            }

            return listPhanQuyen;
        }
    }
}
