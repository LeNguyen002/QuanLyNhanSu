using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class ThuongPhat_DAO
    {
        static SqlConnection con;
        public static List<ThuongPhat_DTO> LayTP()
        {
            string sTruyVan = "select TenNV,Loai,Tien,LyDo,Ngay from NhanVien, ThuongPhat where NhanVien.MaNhanVien = ThuongPhat.MaNhanVien";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ThuongPhat_DTO> lstThuongPhat = new List<ThuongPhat_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThuongPhat_DTO tp = new ThuongPhat_DTO();
                tp.TenNhanVien = dt.Rows[i]["TenNV"].ToString();
                tp.Loai = dt.Rows[i]["Loai"].ToString();
                tp.Tien = int.Parse(dt.Rows[i]["Tien"].ToString());
                tp.LyDo = dt.Rows[i]["LyDo"].ToString();
                tp.Ngay = DateTime.Parse(dt.Rows[i]["Ngay"].ToString());
                lstThuongPhat.Add(tp);
            }
            DataProvider.DongKetNoi(con);
            return lstThuongPhat;
        }

        public static bool ThemTP(string ma,ThuongPhat_DTO tp)
        {
            string sTruyVan = string.Format(@"insert into ThuongPhat values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", ma,tp.Loai,tp.Tien,tp.LyDo,tp.Ngay);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaTP(string ma, ThuongPhat_DTO tp)
        {
            string sTruyVan = string.Format(@"delete ThuongPhat where MaNhanVien = N'{0}' and Loai = N'{1}' and Tien = N'{2}' and LyDo = N'{3}'", ma, tp.Loai, tp.Tien, tp.LyDo, tp.Ngay);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
