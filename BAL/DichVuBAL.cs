using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BAL
{
    public class DichVuBAL
    {
        public List<DichVu> DSDichVu()
        {
            DichVuDAL dal = new DichVuDAL();
            return dal.DSDichVu();
        }
        public bool SuaDV(DichVu dv)
        {
            return new DichVuDAL().SuaDV(dv);
        }
        public bool XoaDV(string ma)
        {
            return new DichVuDAL().XoaDV(ma);
        }
        public DichVu LayDV(string ma)
        {
            DichVuDAL dal = new DichVuDAL();
            List<DichVu> dsDV = dal.DSDichVu();
            foreach (DichVu dv in dsDV)
            {
                if (dv.MaDichVu == ma)
                    return dv;
            }
            return null;
        }
        public bool ThemDV(DichVu dv)
        {
            DichVuDAL dal = new DichVuDAL();
            if (LayDV(dv.MaDichVu) == null)
                return dal.ThemDV(dv);
            else
                return false;
        }
    }
}
