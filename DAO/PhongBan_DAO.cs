using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class PhongBan_DAO
    {
        static SqlConnection con;

        public static List<PhongBan_DTO> LayPB()
        {
            string sTruyVan = "select PhongBan.MaPB, TenPB, count(NhanVien.MaPB) as SoNV from PhongBan left join NhanVien on PhongBan.MaPB = NhanVien.MaPB GROUP BY PhongBan.MaPB, TenPB";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PhongBan_DTO> lstPhongBan = new List<PhongBan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhongBan_DTO pb = new PhongBan_DTO();
                pb.MaPB = dt.Rows[i]["MaPB"].ToString();
                pb.TenPB = dt.Rows[i]["TenPB"].ToString();
                pb.SoNV = int.Parse(dt.Rows[i]["SoNV"].ToString());
                lstPhongBan.Add(pb);
            }
            DataProvider.DongKetNoi(con);
            return lstPhongBan;
        }

        public static bool ThemPB(PhongBan_DTO pb)
        {
            string sTruyVan = string.Format(@"insert into PhongBan values(N'{0}',N'{1}')", pb.MaPB, pb.TenPB);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaPB(PhongBan_DTO pb)
        {
            string sTruyVan = string.Format(@"delete PhongBan where MaPB=N'{0}'", pb.MaPB);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaPB(PhongBan_DTO pb,string mapb)
        {
            string sTruyVan = string.Format(@"update PhongBan set MaPB=N'{0}', TenPB=N'{1}' where MaPB=N'{2}'", pb.MaPB, pb.TenPB, mapb);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static string TimMaPBBangTen(string tenpb)
        {
            string sTruyVan = string.Format(@"select MaPB from PhongBan where TenPB=N'{0}'", tenpb);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            string ma = "";
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ma = dt.Rows[i]["MaPB"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return ma;
        }
    }
}
