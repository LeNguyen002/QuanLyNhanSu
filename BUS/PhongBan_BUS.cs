using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class PhongBan_BUS
    {
        public static List<PhongBan_DTO> LayPB()
        {
            return PhongBan_DAO.LayPB();
        }

        public static bool ThemPB(PhongBan_DTO pb)
        {
            return PhongBan_DAO.ThemPB(pb);
        }

        public static bool XoaPB(PhongBan_DTO pb)
        {
            if (pb.SoNV != 0)
                return false;
            return PhongBan_DAO.XoaPB(pb);
        }

        public static bool SuaPB(PhongBan_DTO pb, string mapb)
        {
            return PhongBan_DAO.SuaPB(pb,mapb);
        }

        public static string TimMaPBBangTen(string tenpb)
        {
            return PhongBan_DAO.TimMaPBBangTen(tenpb);
        }
    }
}
