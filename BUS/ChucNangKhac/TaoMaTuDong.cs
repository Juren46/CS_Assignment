using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ChucNangKhac
{
    public class TaoMaTuDong
    {
        public TaoMaTuDong() { }

        public static string TaoMaNguoiDung(string maPhanQuyen)
        {
            int soNguoiDung = new NguoiDungBUS().DemSoNguoiDungTheoPhanQuyen(maPhanQuyen);

            string maNguoiDung = "";

            switch (maPhanQuyen)
            {
                case "PQ01":
                    maNguoiDung = string.Format("ADM{0:D5}", ++soNguoiDung);
                    break;
                case "PQ02":
                    maNguoiDung = string.Format("QLY{0:D5}", ++soNguoiDung);
                    break;
                case "PQ03":
                    maNguoiDung = string.Format("NBH{0:D5}", ++soNguoiDung);
                    break;
                case "PQ04":
                    maNguoiDung = string.Format("NVK{0:D5}", ++soNguoiDung);
                    break;
            }

            return maNguoiDung;
        }
    }
}
