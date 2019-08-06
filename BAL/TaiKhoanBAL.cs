using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BAL
{
    public class TaiKhoanBAL
    {
        public bool KiemTraTaiKhoan(TaiKhoan taikhoan)
        {
            return new TaiKhoanDAL().KiemTraTaiKhoan(taikhoan);
        }
        public bool KiemTraMatKhau(string mk)
        {
            return new TaiKhoanDAL().KiemTraMatKhau(mk);
        }
        public bool SuaMatKhau(string mk)
        {
            return new TaiKhoanDAL().SuaMatKhau(mk);
        }
    }
}
