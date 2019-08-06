using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BAL
{
    public class ChiTietHoaDonBAL
    {
        public List<ChiTietHoaDon> DSChiTietHoaDon()
        {
            ChiTietHoaDonDAL dal = new ChiTietHoaDonDAL();
            return dal.DSChiTietHoaDon();
        }
        public bool SuaCTHD(ChiTietHoaDon cthd)
        {
            return new ChiTietHoaDonDAL().SuaCTHD(cthd);
        }
        public bool XoaCTHD(string mahd)
        {
            return new ChiTietHoaDonDAL().XoaCTHD(mahd);
        }
        public ChiTietHoaDon LayCTHD(string mahd)
        {
            ChiTietHoaDonDAL dal = new ChiTietHoaDonDAL();
            List<ChiTietHoaDon> dsCTHD = dal.DSChiTietHoaDon();
            foreach (ChiTietHoaDon ct in dsCTHD)
            {
                if (ct.MaHD == mahd)
                    return ct;
            }
            return null;
        }
        public bool ThemCTHD(ChiTietHoaDon cthd)
        {
            ChiTietHoaDonDAL dal = new ChiTietHoaDonDAL();
            if (LayCTHD(cthd.MaHD) == null)
                return dal.ThemCTHD(cthd);
            else
                return false;
        }
    }
}
