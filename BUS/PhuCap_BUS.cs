using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class PhuCap_BUS
    {
        public static List<PhuCap_DTO> LayPC()
        {
            return PhuCap_DAO.LayPC();
        }

        public static bool ThemPC(PhuCap_DTO pc)
        {
            return PhuCap_DAO.ThemPC(pc);
        }

        public static bool SuaPC(PhuCap_DTO pc)
        {
            return PhuCap_DAO.SuaPC(pc);
        }

        public static bool XoaPC(PhuCap_DTO pc)
        {
            return PhuCap_DAO.XoaPC(pc);
        }
    }
}
