using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BAL
{
    public class HopDongBAL
    {
        public HopDong LayThongTinKH(string cm)
        {
            HopDongDAL dal = new HopDongDAL();
            HopDong hd = dal.LayThongTinKH(cm);
            return hd;
        }
    }
}
