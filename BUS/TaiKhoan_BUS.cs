using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static TaiKhoan_DTO LayTK(string ten, string mk)
        {
            return TaiKhoan_DAO.LayTK(ten, mk);
        }
        public static string LayTenTK(string ten, string mk)
        {
            return TaiKhoan_DAO.LayTenTK(ten, mk);
        }

        public static string LayTenNV(string ten, string mk)
        {
            return TaiKhoan_DAO.LayTenNV(ten, mk);
        }

        public static string Quyen(string ten, string mk)
        {
            return TaiKhoan_DAO.Quyen(ten, mk);
        }

        public static bool DoiMK(string ten, string mkm, string mkc)
        {
            if (TaiKhoan_DAO.DoiMK(ten, mkm, mkc) == true)
                return TaiKhoan_DAO.DoiMK(ten, mkm, mkc);
            else return false;
        }

        public static NhanVien_DTO ThongTinNV(string ten, string mk)
        {
            return TaiKhoan_DAO.ThongTinNV(ten, mk);
        }

        public static bool SuaThongTin(string ma, string ten, string gioitinh, DateTime ngay, string cm, string dt, string hv, string diachi, string email, string honnhan)
        {
            return TaiKhoan_DAO.SuaThongTin(ma, ten, gioitinh, ngay, cm, dt, hv, diachi, email, honnhan);
        }

        public static List<NhanVien_DTO> NVChuaTK()
        {
            return TaiKhoan_DAO.NhanVienChuaCoTaiKhoan();
        }

        public static bool ThemTK(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.ThemTK(tk);
        }

        public static List<TaiKhoan_DTO> NVCoTK()
        {
            return TaiKhoan_DAO.NhanVienCoTaiKhoan();
        }

        public static bool XoaTK(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.XoaTK(tk);
        }

        public static bool SuaTK(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.SuaTK(tk);
        }
    }
}
