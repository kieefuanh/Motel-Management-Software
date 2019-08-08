using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BAL
{
    public class KhachHangBAL
    {
        public bool LuuThongTin(KhachHang khach)
        {
            KhachHangDAL dal = new KhachHangDAL();
            bool kq = dal.LuuThongTin(khach);
            return kq;
        }
        public bool SuaKH(KhachHang khach)
        {
            KhachHangDAL dal = new KhachHangDAL();
            string cm = khach.CMND;
            bool kq = dal.SuaKH(cm);
            return kq;
        }
        public bool SuaKH(string cm)
        {
            KhachHangDAL dal = new KhachHangDAL();
            bool kq = dal.SuaKH(cm);
            return kq;
        }
        public bool XoaKH(string cm)
        {
            KhachHangDAL dal = new KhachHangDAL();
            bool kq = dal.XoaKH(cm);
            return kq;
        }
        public bool XoaKH( KhachHang khach)
        {
            KhachHangDAL dal = new KhachHangDAL();
            string cm = khach.CMND;
            bool kq = dal.XoaKH(cm);
            return kq;
        }
        public List<KhachHang>  TaiKH()
        {
            KhachHangDAL dal = new KhachHangDAL();
            List <KhachHang> dskh = dal.TaiKH();
            return dskh;
        }
        public KhachHang TimTheoCM (string cm)
        {
            KhachHangDAL dal = new KhachHangDAL();
            KhachHang k = dal.TimTheoCMND(cm);
            return k;
        }
        public List<KhachHang> Tai1KH(string cm)
        {
            KhachHangDAL dal = new KhachHangDAL();
            List<KhachHang> dskh = dal.TaiKH();
            return dskh;
        }
        public KhachHang TimTheoTen(string ten)
        {
            KhachHangDAL dal = new KhachHangDAL();
            KhachHang k = dal.TimTheoTen(ten);
            return k;
        }
    }
}
