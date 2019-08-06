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
        public HoaDon LayHD(string ma)
        {
            HoaDonDAL dal = new HoaDonDAL();
            List<HoaDon> dsHD = dal.DSHoaDon();
            foreach (HoaDon dv in dsHD)
            {
                if (dv.MaHoaDon == ma)
                    return dv;
            }
            return null;
        }
        public bool ThemHD(HoaDon hd)
        {
            HoaDonDAL dal = new HoaDonDAL();
            if (LayHD(hd.MaHoaDon) == null)
                return dal.ThemHD(hd);
            else
                return false;
        }
    }
}
