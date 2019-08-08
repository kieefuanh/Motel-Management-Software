using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BAL
{
    public class HoaDonBAL
    {
        public List<HoaDon> DSHoaDon()
        {
            HoaDonDAL dal = new HoaDonDAL();
            return dal.DSHoaDon();
        }
        public bool SuaHD(HoaDon hd)
        {
            return new HoaDonDAL().SuaHD(hd);
        }
        public bool XoaHD(string ma)
        {
            return new HoaDonDAL().XoaHD(ma);
        }
        public HoaDon TimHDTheoMaHoaDon(string ma)
        {
            return new HoaDonDAL().TimHDTheoMaHoaDon(ma);
        }
        public HoaDon TimHDTheoMaHopDong(string ma)
        {
            return new HoaDonDAL().TimHDTheoMaHopDong(ma);
        }
        public bool ThemHD(HoaDon hd)
        {
            HoaDonDAL dal = new HoaDonDAL();
            if (TimHDTheoMaHoaDon(hd.MaHoaDon) == null)
                return dal.ThemHD(hd);
            else
                return false;
        }
    }
}
