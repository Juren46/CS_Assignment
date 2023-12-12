using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS.ChucNangKhac
{
    public class KiemTraDinhDang
    {
        public KiemTraDinhDang() { }

        public static bool KiemTraSoDienThoai(string soDienThoai)
        {
            string pattern = @"^(0\d{9,10}|84\d{9,10}|\+84\d{9,10})$";

            return Regex.IsMatch(soDienThoai, pattern);
        }

        public static bool KiemTraEmail(string email)
        {
            return MailAddress.TryCreate(email, out _);
        }
    }
}
