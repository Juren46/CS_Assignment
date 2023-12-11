using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanQuyen
    {
        public string MaPhanQuyen {  get; set; }
        public string TenPhanQuen { get; set; }

        public PhanQuyen() 
        { 
            MaPhanQuyen = string.Empty;
            TenPhanQuen = string.Empty;
        }

        public PhanQuyen(string maPhanQuyen, string tenPhanQuen)
        {
            MaPhanQuyen = maPhanQuyen;
            TenPhanQuen = tenPhanQuen;
        }
    }
}
