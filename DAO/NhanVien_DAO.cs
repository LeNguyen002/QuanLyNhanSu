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
    public class NhanVien_DAO
    {
        static SqlConnection con;
        public static List<NhanVien_DTO> LayNV()
        {
            string sTruyVan = "select * from NhanVien, HopDong, ChucVu, PhongBan where NhanVien.MaHD = HopDong.MaHD and HopDong.MaPB = PhongBan.MaPB and HopDong.MaCV = ChucVu.MaCV";
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
                nv.MaPB = dt.Rows[i]["MaPB"].ToString();
                nv.MaHD = dt.Rows[i]["MaHD"].ToString();
                nv.HeSoLuong = int.Parse(dt.Rows[i]["HeSoLuong"].ToString());
                nv.TenNV = dt.Rows[i]["TenNV"].ToString();
                nv.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                nv.NgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                nv.NgayVaoLam = DateTime.Parse(dt.Rows[i]["NgayVaoLam"].ToString());
                nv.SoCM = dt.Rows[i]["SoCM"].ToString();
                nv.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                nv.TrinhDoHV = dt.Rows[i]["TrinhDoHV"].ToString();
                nv.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                nv.Email = dt.Rows[i]["Email"].ToString();
                nv.TTHonNhan = dt.Rows[i]["TTHonNhan"].ToString();
                nv.MaCV = dt.Rows[i]["MaCV"].ToString();
                nv.TenCv = dt.Rows[i]["TenCv"].ToString();
                nv.TenPB = dt.Rows[i]["TenPB"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }





        public static bool ThemNV(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"insert into NhanVien values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}')", nv.MaNhanVien, nv.MaPB,nv.MaHD,nv.HeSoLuong,nv.TenNV,nv.GioiTinh,nv.NgaySinh,nv.SoCM,nv.DienThoai,nv.TrinhDoHV,nv.DiaChi,nv.Email,nv.Hinh,nv.TTHonNhan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool ThemHD(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"insert into HopDong values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", nv.MaHD,nv.NgayVaoLam,nv.HeSoLuong,nv.MaCV,nv.MaPB);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static string TimTopMaHD()
        {
            string sTruyVan = "select Top 1 MaHD from HopDong order by MaHD desc";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            string ma = "";
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                 ma = dt.Rows[i]["MaHD"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return ma; 
        }

        public static string TimTopMaNV()
        {
            string sTruyVan = "select Top 1 MaNhanVien from NhanVien order by MaNhanVien desc";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            string ma = "";
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ma = dt.Rows[i]["MaNhanVien"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return ma;
        }

        public static string TimMaCVBangTen(string tencv)
        {
            string sTruyVan = string.Format(@"select MaCV from ChucVu where TenCV=N'{0}'",tencv);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            string ma = "";
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ma = dt.Rows[i]["MaCV"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return ma;
        }


        public static bool SuaNV(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"update NhanVien set MaPB=N'{0}',MaHD=N'{1}',HeSoLuong=N'{2}',TenNV=N'{3}',GioiTinh=N'{4}',NgaySinh=N'{5}',SoCM=N'{6}',DienThoai=N'{7}',TrinhDoHV=N'{8}',DiaChi=N'{9}',Email=N'{10}',TTHonNhan=N'{11}' where MaNhanVien=N'{12}'", nv.MaPB,nv.MaHD,nv.HeSoLuong,nv.TenNV,nv.GioiTinh,nv.NgaySinh,nv.SoCM,nv.DienThoai,nv.TrinhDoHV,nv.DiaChi,nv.Email,nv.TTHonNhan,nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaHD(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"update HopDong set NgayVaoLam=N'{0}', HeSoLuong=N'{1}', MaCV=N'{2}', MaPB=N'{3}' where MaHD=N'{4}'", nv.NgayVaoLam,nv.HeSoLuong, nv.MaCV,nv.MaPB,nv.MaHD);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaCTCV(NhanVien_DTO nv,string ld)
        {
            string sTruyVan = string.Format(@"update ctChucVu set MaCV=N'{0}', NgayBatDau=N'{1}', LyDo=N'{2}' where MaNhanVien=N'{3}'", nv.MaCV, nv.NgayVaoLam, ld, nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static List<PhongBan_DTO> LayPhongBan()
        {
            string sTruyVan = "select * from PhongBan";
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
                lstPhongBan.Add(pb);
            }
            DataProvider.DongKetNoi(con);
            return lstPhongBan;
        }

        public static List<ChucVu_DTO> LayChucVu()
        {
            string sTruyVan = "select * from ChucVu";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChucVu_DTO> lstChucVu = new List<ChucVu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChucVu_DTO cv = new ChucVu_DTO();
                cv.MaCV = dt.Rows[i]["MaCV"].ToString();
                cv.TenCv = dt.Rows[i]["TenCv"].ToString();
                lstChucVu.Add(cv);
            }
            DataProvider.DongKetNoi(con);
            return lstChucVu;
        }

        public static bool ThemCTCV(NhanVien_DTO nv,string ld)
        {
            string sTruyVan = string.Format(@"insert into ctChucVu(MaNhanVien, MaCV, NgayBatDau, LyDo) values(N'{0}',N'{1}',N'{2}',N'{3}')", nv.MaNhanVien, nv.MaCV, nv.NgayVaoLam,ld);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaNV(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete NhanVien where MaNhanVien=N'{0}'", nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaCTCV(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete ctChucVu where MaNhanVien=N'{0}'", nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaHD(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete HopDong where MaHD=N'{0}'", nv.MaHD);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaChamCong(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete ChamCong where MaNhanVien=N'{0}'", nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaTaiKhoan(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete TaiKhoan where MaNhanVien=N'{0}'", nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaThuongPhat(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete ThuongPhat where MaNhanVien=N'{0}'", nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaPhuCap(NhanVien_DTO nv)
        {
            string sTruyVan = string.Format(@"delete PhuCap where MaNhanVien=N'{0}'", nv.MaNhanVien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }


        public static string LayMaTheoTen(string ma)
        {
            string sTruyVan = string.Format(@"select MaNhanVien from NhanVien where TenNV=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            string ten = "";
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ten = dt.Rows[i]["MaNhanVien"].ToString();
            }
            DataProvider.DongKetNoi(con);
            return ten;
        }

        public static List<ChamCong_DTO> ThongKeNVNghiTheoNgay(DateTime ngay)
        {
            string sTruyVan = string.Format(@"select NhanVien.MaNhanVien, TenNV, Ngay,TinhTrang from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien where Ngay = N'{0}' and (TinhTrang = N'Nghỉ Không Phép' or TinhTrang = N'Nghỉ Có Phép')", ngay);
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

        public static List<ChamCong_DTO> ThongKeNVNghiTheoThang(DateTime tungay,DateTime denngay)
        {
            string sTruyVan = string.Format(@"select NhanVien.MaNhanVien, TenNV, Ngay,TinhTrang from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien where Ngay >= N'{0}' and Ngay <= N'{1}' and (TinhTrang = N'Nghỉ Không Phép' or TinhTrang = N'Nghỉ Có Phép') order by Ngay", tungay,denngay);
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
                cc.Ngay = DateTime.Parse(dt.Rows[i]["Ngay"].ToString());
                lstChamCong.Add(cc);
            }
            DataProvider.DongKetNoi(con);
            return lstChamCong;
        }

        public static List<ChamCong_DTO> ChamCongTheoThangTheoTenNV(string ten,DateTime tungay, DateTime denngay)
        {
            string sTruyVan = string.Format(@"select NhanVien.MaNhanVien, TenNV, TinhTrang, Ngay from NhanVien inner join ChamCong on NhanVien.MaNhanVien = ChamCong.MaNhanVien where TenNV like N'{0}' and Ngay >= N'{1}' and Ngay <= N'{2}' order by Ngay", ten,tungay, denngay);
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
                cc.Ngay = DateTime.Parse(dt.Rows[i]["Ngay"].ToString());
                lstChamCong.Add(cc);
            }
            DataProvider.DongKetNoi(con);
            return lstChamCong;
        }

        public static List<LichSu_DTO> LayLichSu()
        {
            string sTruyVan = "select NhanVien.MaNhanVien,TenNV,TenCv,NgayBatDau,LyDo from NhanVien,ChucVu,ctChucVu,HopDong where NhanVien.MaNhanVien = ctChucVu.MaNhanVien and HopDong.MaHD = NhanVien.MaHD and ChucVu.MaCV = ctChucVu.MaCV";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LichSu_DTO> lstChamCong = new List<LichSu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LichSu_DTO ls = new LichSu_DTO();
                ls.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                ls.TenNV = dt.Rows[i]["TenNV"].ToString();
                ls.TenCv = dt.Rows[i]["TenCv"].ToString();
                ls.NgayBatDau = DateTime.Parse(dt.Rows[i]["NgayBatDau"].ToString());
                ls.LyDo = dt.Rows[i]["LyDo"].ToString();
                lstChamCong.Add(ls);  
                    
            }
            DataProvider.DongKetNoi(con);
            return lstChamCong;
        }

        public static List<LichSu_DTO> LayLichSuTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select NhanVien.MaNhanVien,TenNV,TenCv,NgayBatDau,LyDo from NhanVien,ChucVu,ctChucVu,HopDong where NhanVien.MaNhanVien = ctChucVu.MaNhanVien and HopDong.MaHD = NhanVien.MaHD and ChucVu.MaCV = ctChucVu.MaCV and NhanVien.MaNhanVien=N'{0}'",ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LichSu_DTO> lstChamCong = new List<LichSu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LichSu_DTO ls = new LichSu_DTO();
                ls.MaNhanVien = dt.Rows[i]["MaNhanVien"].ToString();
                ls.TenNV = dt.Rows[i]["TenNV"].ToString();
                ls.TenCv = dt.Rows[i]["TenCv"].ToString();
                ls.NgayBatDau = DateTime.Parse(dt.Rows[i]["NgayBatDau"].ToString());
                ls.LyDo = dt.Rows[i]["LyDo"].ToString();
                lstChamCong.Add(ls);

            }
            DataProvider.DongKetNoi(con);
            return lstChamCong;
        }

        public static List<NhanVien_DTO> TimNhanVienTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from NhanVien, HopDong, ChucVu, PhongBan where NhanVien.MaHD = HopDong.MaHD and HopDong.MaPB = PhongBan.MaPB and HopDong.MaCV = ChucVu.MaCV and TenNV like N'%{0}%'", ten);
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
                nv.MaPB = dt.Rows[i]["MaPB"].ToString();
                nv.MaHD = dt.Rows[i]["MaHD"].ToString();
                nv.HeSoLuong = int.Parse(dt.Rows[i]["HeSoLuong"].ToString());
                nv.TenNV = dt.Rows[i]["TenNV"].ToString();
                nv.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                nv.NgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                nv.NgayVaoLam = DateTime.Parse(dt.Rows[i]["NgayVaoLam"].ToString());
                nv.SoCM = dt.Rows[i]["SoCM"].ToString();
                nv.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                nv.TrinhDoHV = dt.Rows[i]["TrinhDoHV"].ToString();
                nv.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                nv.Email = dt.Rows[i]["Email"].ToString();
                nv.TTHonNhan = dt.Rows[i]["TTHonNhan"].ToString();
                nv.MaCV = dt.Rows[i]["MaCV"].ToString();
                nv.TenCv = dt.Rows[i]["TenCv"].ToString();
                nv.TenPB = dt.Rows[i]["TenPB"].ToString();
                lstNhanVien.Add(nv);
            }
            //DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
    }
}
