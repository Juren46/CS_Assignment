using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhanQuyenBUS
    {
        readonly PhanQuyenDAO phanQuyenDAO;

        public PhanQuyenBUS() 
        { 
            phanQuyenDAO = new();
        }

        public List<PhanQuyen> LayTatCaPhanQuyen()
        {
            return phanQuyenDAO.LayTatCaPhanQuyen();
        }

        public PhanQuyen LayPhanQuyenTheoMa(string maPhanQuyen)
        {
            return phanQuyenDAO.LayPhanQuyenTheoMa(maPhanQuyen);
        }

        public List<PhanQuyen> TimKiemPhanQuyen(string tuKhoa = "")
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            return phanQuyenDAO.TimKiemPhanQuyen(tuKhoa);
        }
    }
}
