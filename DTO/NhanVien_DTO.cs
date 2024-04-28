using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        public string MaNhanVien { get; set; }
        public string MaPB { get; set; }
        public string MaHD { get; set; }
        public int HeSoLuong { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; } 
        public DateTime NgaySinh { get; set; }
        public string SoCM { get; set; }
        public string DienThoai { get; set; }
        public string TrinhDoHV { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Hinh { get; set; }
        public string TTHonNhan { get; set; }
        public string TenCv { get; set; }

        public DateTime NgayVaoLam { get; set; }
        public string MaCV { get; set; }

        public string TenPB { get; set; }

    }
}
