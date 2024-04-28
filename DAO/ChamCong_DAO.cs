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
    public class ChamCong_DAO
    {
        static SqlConnection con;
        public static bool ThemChamCong(string ma,DateTime ngay,string tinhtrang)
        {
            string sTruyVan = string.Format(@"insert into ChamCong values(N'{0}',N'{1}',N'{2}')", ma, ngay,tinhtrang);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static List<ChamCong_DTO> LayCC(DateTime ngay)
        {
            string sTruyVan = string.Format(@"select ChamCong.MaNhanVien, NhanVien.TenNV,TinhTrang from ChamCong inner join NhanVien on ChamCong.MaNhanVien = NhanVien.MaNhanVien where Ngay = N'{0}' order by MaNhanVien", ngay);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChamCong_DTO> lstChamCong = new List<ChamCong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChamCong_DTO cc = new ChamCong_DTO();
                cc.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                cc.TenNV = dt.Rows[i]["TenNV"].ToString();
                cc.TinhTrang = dt.Rows[i]["TinhTrang"].ToString();
                lstChamCong.Add(cc);
            }
            DataProvider.DongKetNoi(con);
            return lstChamCong;
        }

        public static List<ChamCong_DTO> LayCC1()
        {
            string sTruyVan = "Select MaNhanVien, TenNV from NhanVien";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChamCong_DTO> lstChamCong = new List<ChamCong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChamCong_DTO cc = new ChamCong_DTO();
                cc.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                cc.TenNV = dt.Rows[i]["TenNV"].ToString();
                lstChamCong.Add(cc);
            }
            DataProvider.DongKetNoi(con);
            return lstChamCong;
        }

        public static string LayCC2(DateTime ngay)
        {
            string sTruyVan = string.Format(@"Select Top 1 Ngay from ChamCong where Ngay = N'{0}'", ngay);
            con = DataProvider.MoKetNoi();
            string n= null;
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChamCong_DTO> lstChamCong = new List<ChamCong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                n = dt.Rows[i]["Ngay"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return n;
        }

        public static bool XoaCC(DateTime ngay)
        {
            string sTruyVan = string.Format(@"delete from ChamCong where Ngay=N'{0}'", ngay);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
