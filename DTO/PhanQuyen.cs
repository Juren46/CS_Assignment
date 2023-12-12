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
        public string TenPhanQuyen { get; set; }

        public PhanQuyen() 
        { 
            MaPhanQuyen = string.Empty;
            TenPhanQuyen = string.Empty;
        }

        public PhanQuyen(string maPhanQuyen, string tenPhanQuyen)
        {
            MaPhanQuyen = maPhanQuyen;
            TenPhanQuyen = tenPhanQuyen;
        }
    }
}
