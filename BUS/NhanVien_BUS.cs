using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static List<NhanVien_DTO> LayNV()
        {
            return NhanVien_DAO.LayNV();
        }

        public static bool ThemNV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.ThemNV(nv);
        }

        public static bool ThemHD(NhanVien_DTO nv)
        {
            return NhanVien_DAO.ThemHD(nv);
        }

        public static bool ThemCTCV(NhanVien_DTO nv, string ld)
        {
            return NhanVien_DAO.ThemCTCV(nv, ld);
        }

        public static string TimTopMaHD()
        {
            return NhanVien_DAO.TimTopMaHD();
        }

        public static string TimTopMaNV()
        {
            return NhanVien_DAO.TimTopMaNV();
        }

        public static string TimMaCVBangTen(string tencv)
        {
            return NhanVien_DAO.TimMaCVBangTen(tencv);
        }

        public static List<PhongBan_DTO> LayPhongBan()
        {
            return NhanVien_DAO.LayPhongBan();
        }

        public static List<ChucVu_DTO> LayChucVu()
        {
            return NhanVien_DAO.LayChucVu();
        }

        public static bool XoaNV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaNV(nv);
        }
        public static bool XoaCTCV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaCTCV(nv);
        }
        public static bool XoaHD(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaHD(nv);
        }

        public static bool XoaTaiKhoan(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaTaiKhoan(nv);
        }

        public static bool XoaChamCong(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaChamCong(nv);
        }

        public static bool XoaPhuCap(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaPhuCap(nv);
        }

        public static bool XoaThuongPhat(NhanVien_DTO nv)
        {
            return NhanVien_DAO.XoaThuongPhat(nv);
        }

        public static bool SuaNV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.SuaNV(nv);
        }
        public static bool SuaHD(NhanVien_DTO nv)
        {
            return NhanVien_DAO.SuaHD(nv);
        }

        public static bool SuaCTCV(NhanVien_DTO nv,string ld)
        {
            return NhanVien_DAO.SuaCTCV(nv,ld);
        }

        public static string LayMaTheoTen(string ma)
        {
            return NhanVien_DAO.LayMaTheoTen(ma);
        }

        public static List<ChamCong_DTO> ThongKeNVNghiTheoNgay(DateTime ngay)
        {
            return NhanVien_DAO.ThongKeNVNghiTheoNgay(ngay);
        }

        public static List<ChamCong_DTO> ThongKeNVNghiTheoThang(DateTime tunday,DateTime denngay)
        {
            return NhanVien_DAO.ThongKeNVNghiTheoThang(tunday,denngay);
        }

        public static List<ChamCong_DTO> ChamCongTheoThangTheoTenNV(string ten, DateTime tungay, DateTime denngay)
        {
            return NhanVien_DAO.ChamCongTheoThangTheoTenNV(ten, tungay, denngay);
        }

        public static List<LichSu_DTO> LayLichSu()
        {
            return NhanVien_DAO.LayLichSu();
        }

        public static List<LichSu_DTO> LayLichSuTheoMa(string ma)
        {
            return NhanVien_DAO.LayLichSuTheoMa(ma);
        }

        public static List<NhanVien_DTO> TimNhanVienTheoTen(string ten)
        {
            return NhanVien_DAO.TimNhanVienTheoTen(ten);
        }
    }
}
