using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class ThuongPhat_BUS
    {
        public static List<ThuongPhat_DTO> LayTP()
        {
            return ThuongPhat_DAO.LayTP();
        }

        public static bool ThemTP(string ma, ThuongPhat_DTO tp)
        {
            return ThuongPhat_DAO.ThemTP(ma,tp);
        }

        public static bool XoaTP(string ma, ThuongPhat_DTO tp)
        {
            return ThuongPhat_DAO.XoaTP(ma, tp);
        }

    }
}
