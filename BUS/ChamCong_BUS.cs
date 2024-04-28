using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChamCong_BUS
    {
        public static bool ThemChamCong(string ma, DateTime ngay, string tinhtrang)
        {
            return ChamCong_DAO.ThemChamCong(ma, ngay, tinhtrang);
        }

        public static List<ChamCong_DTO> LayCC(DateTime ngay)
        {
            return ChamCong_DAO.LayCC(ngay);
        }

        public static List<ChamCong_DTO> LayCC1()
        {
            return ChamCong_DAO.LayCC1();
        }

        public static string LayCC2(DateTime ngay)
        {
            return ChamCong_DAO.LayCC2(ngay);
         }

        public static bool XoaCC(DateTime ngay)
        {
            return ChamCong_DAO.XoaCC(ngay);
        }
    }
}
