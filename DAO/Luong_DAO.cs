using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class Luong_DAO
    {
        static SqlConnection con;
        public static List<Luong_DTO> LayLuong()
        {
            string sTruyVan = "select MaNhanVien, TenNV, NhanVien.HeSoLuong, 0 as NL, 0 as T, 0 as P, 0 as Tien, 0 as TL From NhanVien, Luong where NhanVien.HeSoLuong = Luong.HeSoLuong";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Luong_DTO> lstLuong = new List<Luong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Luong_DTO l = new Luong_DTO();
                l.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                l.TenNV = dt.Rows[i]["TenNV"].ToString();
                l.HeSoLuong = int.Parse(dt.Rows[i]["HeSoLuong"].ToString());
                l.NL = int.Parse(dt.Rows[i]["NL"].ToString());
                l.T = int.Parse(dt.Rows[i]["T"].ToString());
                l.P = int.Parse(dt.Rows[i]["P"].ToString());
                l.PhuCap = int.Parse(dt.Rows[i]["Tien"].ToString());
                l.TL = int.Parse(dt.Rows[i]["TL"].ToString());
                lstLuong.Add(l);
            }
            DataProvider.DongKetNoi(con);
            return lstLuong;
        }

        public static string LayCV(string ma)
        {
            string sTruyVan = string.Format(@"select TenCv from NhanVien, HopDong, ChucVu, PhongBan where NhanVien.MaHD = HopDong.MaHD and HopDong.MaPB = PhongBan.MaPB and HopDong.MaCV = ChucVu.MaCV and NhanVien.MaNhanVien = N'{0}'",ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string cv = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv = dt.Rows[i]["TenCv"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return cv;
        }

        public static string LayCB(string ma)
        {
            string sTruyVan = string.Format(@"select LuongCB from NhanVien,Luong where NhanVien.MaNhanVien = N'{0}' and Luong.HeSoLuong=NhanVien.HeSoLuong", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string cv = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv = dt.Rows[i]["LuongCB"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return cv;
        }

        public static string LayCBTheoHS(string hs)
        {
            string sTruyVan = string.Format(@"select LuongCB from Luong where HeSoLuong=N'{0}'", hs);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string cv = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv = dt.Rows[i]["LuongCB"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return cv;
        }

        public static string LaySoNgayLam(string ma,DateTime ngaydau,DateTime ngaycuoi)
        {
            
            string sTruyVan = string.Format(@"select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong where MaNhanVien = N'{0}' and (Ngay >= N'{1}' and Ngay <= N'{2}') and TinhTrang = N'Đi Làm' Group By MaNhanVien", ma,ngaydau,ngaycuoi);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string cv = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv = dt.Rows[i]["NgayLam"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return cv;

        }

        public static string LayNghiCP(string ma, DateTime ngaydau, DateTime ngaycuoi)
        {

            string sTruyVan = string.Format(@"select MaNhanVien, COUNT(Ngay)as NgayLam from ChamCong where MaNhanVien = N'{0}' and (Ngay >= N'{1}' and Ngay <= N'{2}') and TinhTrang = N'Nghỉ Có Phép' Group By MaNhanVien", ma, ngaydau, ngaycuoi);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string cv = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv = dt.Rows[i]["NgayLam"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return cv;

        }

        public static int LayTienThuong(string ma, DateTime ngaydau, DateTime ngaycuoi)
        {

            string sTruyVan = string.Format(@"select Tien, Loai from ThuongPhat where MaNhanVien = N'{0}' and (Ngay >= N'{1}' and Ngay <= N'{2}') and Loai = N'Thưởng'", ma, ngaydau, ngaycuoi);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            int cv = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv += int.Parse(dt.Rows[i]["Tien"].ToString());
            }
            DataProvider.DongKetNoi(con);
            return cv;

        }

        public static int LayTienPhat(string ma, DateTime ngaydau, DateTime ngaycuoi)
        {

            string sTruyVan = string.Format(@"select Tien, Loai from ThuongPhat where MaNhanVien = N'{0}' and (Ngay >= N'{1}' and Ngay <= N'{2}') and Loai = N'Phạt'", ma, ngaydau, ngaycuoi);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            int cv = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv += int.Parse(dt.Rows[i]["Tien"].ToString());
            }
            DataProvider.DongKetNoi(con);
            return cv;

        }

        public static int LayPhuCap(string ma, DateTime ngaycuoi)
        {

            string sTruyVan = string.Format(@"select MaNhanVien, Sum(Tien) as Tien From PhuCap where MaNhanVien = N'{0}' and (TuNgay <= N'{1}' and DenNgay <= N'{1}') group by MaNhanVien",ma,ngaycuoi);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            int cv = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cv += int.Parse(dt.Rows[i]["Tien"].ToString());
            }
            DataProvider.DongKetNoi(con);
            return cv;

        }

        public static bool SuaLuongCB(int hesoluong,int luongcb)
        {
            string sTruyVan = string.Format(@"Update Luong set LuongCB = N'{0}' where HeSoLuong = N'{1}'",luongcb,hesoluong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

    }
}
