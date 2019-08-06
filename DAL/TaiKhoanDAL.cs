using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
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
    }
}
