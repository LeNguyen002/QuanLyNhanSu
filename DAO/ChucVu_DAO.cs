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
    public class ChucVu_DAO
    {
        static SqlConnection con;
        public static bool ThemCV(ChucVu_DTO cv)
        {
            string sTruyVan = string.Format(@"insert into ChucVu values(N'{0}',N'{1}')", cv.MaCV, cv.TenCv);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaCV(string ma)
        {
            string sTruyVan = string.Format(@"delete from ChucVu where MaCV=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        
    }
}
