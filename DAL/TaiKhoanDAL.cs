using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class TaiKhoanDAL : DatabaseService
    {
        public bool KiemTraTaiKhoan(TaiKhoan taikhoan)
        {
            SqlParameter parUid = new SqlParameter("@uid", System.Data.SqlDbType.VarChar);
            parUid.Value = taikhoan.Username;
            SqlParameter parPwd = new SqlParameter("@pwd", System.Data.SqlDbType.VarChar);
            parPwd.Value = taikhoan.Password;

            SqlDataReader reader = ReadDataPars("select * from TaiKhoan where Username = @uid and Password = @pwd", new[] { parUid, parPwd });


            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public bool KiemTraMatKhau(string mk)
        {
            SqlParameter parPwd = new SqlParameter("@pwd", System.Data.SqlDbType.VarChar);
            parPwd.Value = mk;

            SqlDataReader reader = ReadDataPars("select * from TaiKhoan where Password = @pwd", new[] {parPwd });
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public bool SuaMatKhau(string mk)
        {
            string sql = "update TaiKhoan set Password = @mk";
            SqlParameter parMK = new SqlParameter("@mk", System.Data.SqlDbType.VarChar);
            parMK.Value = mk;
            bool kq = WriteData(sql, new[] { parMK});
            return kq;
        }
    }
}
