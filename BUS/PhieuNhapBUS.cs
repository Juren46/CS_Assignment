using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuNhapBUS
    {
        PhieuNhapDAO PhieuNhapDAO { get; set; }
        
        public PhieuNhapBUS()
        {
            PhieuNhapDAO = new PhieuNhapDAO();
        }

        public List<PhieuNhap> LayTatCaPhieuNhap()
        {
            return PhieuNhapDAO.LayTatCaPhieuNhap();
        }

        public PhieuNhap LayPhieuNhapTheoMa(string maPhieuNhap = "")
        {
            return PhieuNhapDAO.LayPhieuNhapTheoMa(maPhieuNhap);
        }
    }
}
