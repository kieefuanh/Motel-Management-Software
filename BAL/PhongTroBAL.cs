using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BAL
{
    public class PhongTroBAL
    {
        public bool ThenPT(PhongTro pt)
        {
            PhongTroDAL dal = new PhongTroDAL();
            bool kq = dal.ThemPhongTro(pt);
            return kq;
        }

        public List<PhongTro> TaiDSPhongTro()
        {
            PhongTroDAL dal = new PhongTroDAL();
            List<PhongTro> dspt = dal.TaiDSPhongTro();
            return dspt;
        }

        public PhongTro LayThongTin1Phong(string ma)
        {
            PhongTroDAL dal = new PhongTroDAL();
            PhongTro pt = dal.ThongTin1Phong(ma);
            return pt;
        }
    }
}
