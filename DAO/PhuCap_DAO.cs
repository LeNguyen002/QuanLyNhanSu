using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class PhuCap_DAO
    {
        static SqlConnection con;
        public static List<PhuCap_DTO> LayPC()
        {
            string sTruyVan = "select pc.*,TenNV from PhuCap pc,NhanVien where NhanVien.MaNhanVien=pc.MaNhanVien";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PhuCap_DTO> lstPhuCap = new List<PhuCap_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhuCap_DTO pc = new PhuCap_DTO();
                pc.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                pc.TenNV = dt.Rows[i]["TenNV"].ToString();
                pc.Tien = int.Parse(dt.Rows[i]["Tien"].ToString());
                pc.LoaiPC = dt.Rows[i]["LoaiPC"].ToString();
                pc.TuNgay = DateTime.Parse(dt.Rows[i]["TuNgay"].ToString());
                pc.DenNgay = DateTime.Parse(dt.Rows[i]["DenNgay"].ToString());
                lstPhuCap.Add(pc);
            }
            DataProvider.DongKetNoi(con);
            return lstPhuCap;
        }

        public static bool ThemPC(PhuCap_DTO pc)
        {
            string sTruyVan = string.Format(@"insert into PhuCap values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", pc.MaNhanVien,pc.LoaiPC,pc.Tien,pc.TuNgay,pc.DenNgay);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool SuaPC(PhuCap_DTO pc)
        {
            string sTruyVan = string.Format(@"update PhuCap set LoaiPC=N'{0}', Tien=N'{1}', TuNgay=N'{2}', DenNgay=N'{3}' where MaNhanVien=N'{4}'", pc.LoaiPC, pc.Tien, pc.TuNgay, pc.DenNgay, pc.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaPC(PhuCap_DTO pc)
        {
            string sTruyVan = string.Format(@"delete PhuCap where MaNhanVien=N'{0}' and LoaiPC=N'{1}'", pc.MaNhanVien,pc.LoaiPC);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
