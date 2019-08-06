using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HoaDonDAL : DatabaseService
    {
        public List<HoaDon> DSHoaDon()
        {
            SqlDataReader reader = ReadData("select * from HoaDon");
            List<HoaDon> dsHD = new List<HoaDon>();
            while (reader.Read())
            {
                string mahd = reader.GetString(0);
                string mahdg = reader.GetString(1);
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = mahd;
                hd.MaHopDong = mahdg;
            }
            reader.Close();
            return dsHD;
        }
        public bool XoaHD(string mahd)
        {
            string sql = "delete from HoaDon where MaHoaDon = @mahd";
            SqlParameter parMahd = new SqlParameter("@mahd", SqlDbType.VarChar);
            parMahd.Value = mahd;
            bool kq = WriteData(sql, new[] { parMahd });
            return kq;
        }
        public bool ThemHD(HoaDon hd)
        {
            string sql = "insert into HoaDon values(@mahd,@mahdg)";
            SqlParameter parMahd = new SqlParameter("@mahd", System.Data.SqlDbType.VarChar);
            parMahd.Value = hd.MaHoaDon;
            SqlParameter parMahdg = new SqlParameter("@mahdg", System.Data.SqlDbType.VarChar);
            parMahdg.Value = hd.MaHopDong;
            bool kq = WriteData(sql, new[] { parMahd, parMahdg });
            return kq;
        }
        public bool SuaHD(HoaDon hd)
        {
            string sql = "update HoaDon set MaHoaDon = @mahd, MaHopDong = @mahdg";
            SqlParameter parMahd = new SqlParameter("@mahd", System.Data.SqlDbType.VarChar);
            parMahd.Value = hd.MaHoaDon;
            SqlParameter parMahdg = new SqlParameter("@mahdg", System.Data.SqlDbType.VarChar);
            parMahdg.Value = hd.MaHopDong;
            bool kq = WriteData(sql, new[] { parMahd, parMahdg });
            return kq;
        }
    }
}
