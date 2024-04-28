using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ChucVu_BUS
    {
        public static bool ThemCV(ChucVu_DTO cv)
        {
            return ChucVu_DAO.ThemCV(cv);
        }

        public static bool XoaCV(string ma)
        {
            return ChucVu_DAO.XoaCV(ma);
        }
    }
}
