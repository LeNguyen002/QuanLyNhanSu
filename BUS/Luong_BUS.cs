using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class Luong_BUS
    {
        public static List<Luong_DTO> LayLuong()
        {
            return Luong_DAO.LayLuong();
        }

        public static string LayCV(string ma)
        {
            return Luong_DAO.LayCV(ma);
        }

        public static string LayCB(string ma)
        {
            return Luong_DAO.LayCB(ma);
        }

        public static string LayCBTheoHS(string ma)
        {
            return Luong_DAO.LayCBTheoHS(ma);
        }

        public static string LaySoNgayLam(string ma,DateTime ngaydau,DateTime ngaycuoi)
        {
            return Luong_DAO.LaySoNgayLam(ma, ngaydau, ngaycuoi);
        }

        public static string LayNghiCP(string ma, DateTime ngaydau, DateTime ngaycuoi)
        {
            return Luong_DAO.LayNghiCP(ma, ngaydau, ngaycuoi);
        }

        public static int LayTienThuong(string ma, DateTime ngaydau, DateTime ngaycuoi)
        {
            return Luong_DAO.LayTienThuong(ma, ngaydau, ngaycuoi);
        }

        public static int LayTienPhat(string ma, DateTime ngaydau, DateTime ngaycuoi)
        {
            return Luong_DAO.LayTienPhat(ma, ngaydau, ngaycuoi);
        }

        public static int LayPhuCap(string ma, DateTime ngaycuoi)
        {
            return Luong_DAO.LayPhuCap(ma, ngaycuoi);
        }

        public static bool SuaLuongCB(int hs, int luong)
        {
            return Luong_DAO.SuaLuongCB(hs, luong);
        }
    }
}
