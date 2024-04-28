using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhuCap_DTO
    {
        public string MaNhanVien { get; set; }
        public string TenNV { get; set; }
        public string LoaiPC { get; set; }
        public int Tien { get; set; }
        public DateTime TuNgay { get; set; }

        public DateTime DenNgay { get; set; }
    }
}
