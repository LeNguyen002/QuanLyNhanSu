using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TaiKhoan_DAO
    {
        static SqlConnection con;

        public static TaiKhoan_DTO LayTK(string ten,string mk)
        {
            string sTruyVan = string.Format(@"select * from Taikhoan where TenDangNhap=N'{0}' and MatKhau=N'{1}'", ten, mk);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            //DataProvider.DongKetNoi(con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            TaiKhoan_DTO tk1 = new TaiKhoan_DTO();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO nv = new TaiKhoan_DTO();
                tk1.TenDangNhap = dt.Rows[i]["TenDangNhap"].ToString();
                tk1.MatKhau = dt.Rows[i]["MatKhau"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return tk1;

        }

        public static string LayTenNV(string ten, string mk)
        {
            string sTruyVan = string.Format(@"select tk.*,nv.TenNV from Taikhoan tk,NhanVien nv where TenDangNhap=N'{0}' and MatKhau=N'{1}' and nv.MaNhanVien = tk.MaNhanVien", ten, mk);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            //DataProvider.DongKetNoi(con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string tk1 = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO nv = new TaiKhoan_DTO();
                tk1 = dt.Rows[i]["TenNV"].ToString(); 
            }
            DataProvider.DongKetNoi(con);
            return tk1;
        }

        public static string Quyen(string ten,string mk)
        {
            string sTruyVan = string.Format(@"select * from Taikhoan where TenDangNhap=N'{0}' and MatKhau=N'{1}'", ten, mk);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            //DataProvider.DongKetNoi(con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string tk1 = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO nv = new TaiKhoan_DTO();
                tk1 = dt.Rows[i]["TenQuyenHan"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return tk1;
        }

        public static string LayTenTK(string ten, string mk)
        {
            string sTruyVan = string.Format(@"select * from Taikhoan where TenDangNhap=N'{0}' and MatKhau=N'{1}'", ten, mk);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            //DataProvider.DongKetNoi(con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string tk1 = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tk1 = dt.Rows[i]["TenDangNhap"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return tk1;
        }

        public static bool DoiMK(string ten,string mkm,string mkc)
        {
            string sTruyVan = string.Format(@"update Taikhoan set MatKhau = N'{0}' where TenDangNhap=N'{1}' and MatKhau=N'{2}'", mkm, ten,mkc);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static NhanVien_DTO ThongTinNV(string ten,string mk)
        {
            string sTruyVan = string.Format(@"select nv.* from Taikhoan tk,NhanVien nv where TenDangNhap=N'{0}' and MatKhau=N'{1}' and nv.MaNhanVien = tk.MaNhanVien", ten, mk);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO tk1 = new NhanVien_DTO();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO nv = new TaiKhoan_DTO();
                tk1.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                tk1.TenNV = dt.Rows[i]["TenNV"].ToString();
                tk1.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                tk1.NgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                tk1.SoCM = dt.Rows[i]["SoCM"].ToString();
                tk1.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                tk1.TrinhDoHV = dt.Rows[i]["TrinhDoHV"].ToString();
                tk1.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                tk1.Email = dt.Rows[i]["Email"].ToString();
                tk1.Hinh = dt.Rows[i]["Hinh"].ToString();
                tk1.TTHonNhan = dt.Rows[i]["TTHonNhan"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return tk1;
        }

        public static bool SuaThongTin(string ma,string ten,string gioitinh,DateTime ngay,string cm,string dt,string hv,string diachi,string email,string honnhan)
        {
            string sTruyVan = string.Format(@"update NhanVien set TenNV = N'{0}',GioiTinh = N'{1}',NgaySinh = N'{2}',SoCM = N'{3}',DienThoai = N'{4}',TrinhDoHV = N'{5}',DiaChi = N'{6}',Email = N'{7}',TTHonNhan = N'{8}' where MaNhanVien=N'{9}'", ten, gioitinh,ngay,cm,dt,hv,diachi,email,honnhan,ma);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static List<NhanVien_DTO> NhanVienChuaCoTaiKhoan()
        {
            string sTruyVan = "select NhanVien.MaNhanVien, TenNV, ChucVu.TenCv from ((NhanVien inner join HopDong on NhanVien.MaHD = HopDong.MaHD) inner join ChucVu on HopDong.MaCV = ChucVu.MaCV) left join Taikhoan on NhanVien.MaNhanVien = Taikhoan.MaNhanVien where TenDangNhap is null";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVien_DTO> lstNhanVien = new List<NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                nv.TenNV = dt.Rows[i]["TenNV"].ToString();
                nv.TenCv = dt.Rows[i]["TenCv"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }

        public static bool ThemTK(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format(@"insert into Taikhoan values(N'{0}',N'{1}',N'{2}',N'{3}')", tk.MaNhanVien,tk.TenDangNhap,tk.MatKhau,tk.TenQuyenHan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }



        public static List<TaiKhoan_DTO> NhanVienCoTaiKhoan()
        {
            string sTruyVan = "select NhanVien.MaNhanVien, TenNV, TenDangNhap, MatKhau, TenQuyenHan from NhanVien, Taikhoan where NhanVien.MaNhanVien = Taikhoan.MaNhanVien";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TaiKhoan_DTO> lstNhanVien = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO nv = new TaiKhoan_DTO();
                nv.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                nv.TenDangNhap = dt.Rows[i]["TenDangNhap"].ToString();
                nv.TenNV = dt.Rows[i]["TenNV"].ToString();
                nv.MatKhau = dt.Rows[i]["MatKhau"].ToString();
                nv.TenQuyenHan = dt.Rows[i]["TenQuyenHan"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }

        public static bool XoaTK(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format(@"delete from Taikhoan where MaNhanVien=N'{0}'", tk.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaTK(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format(@"update Taikhoan set TenDangNhap=N'{0}', MatKhau=N'{1}',TenQuyenHan=N'{2}' where MaNhanVien=N'{3}'", tk.TenDangNhap,tk.MatKhau,tk.TenQuyenHan,tk.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        



    }
}
