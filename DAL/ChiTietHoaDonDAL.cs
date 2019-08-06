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
    public class ChiTietHoaDonDAL : DatabaseService
    {
        public List<ChiTietHoaDon> DSChiTietHoaDon()
        {
            SqlDataReader reader = ReadData("select * from ChiTietHoaDon");
            List<ChiTietHoaDon> dsCTHD = new List<ChiTietHoaDon>();
            while (reader.Read())
            {
                string mahd = reader.GetString(0);
                float tpt = float.Parse(reader.GetString(1));
                int sldv = int.Parse(reader.GetString(2));
                string madv = reader.GetString(3);
                int thang = int.Parse(reader.GetString(4));
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHD = mahd;
                cthd.TienPhaiTra = tpt;
                cthd.MaDV = madv;
                cthd.SoLuongDV = sldv;
                cthd.Thang = thang;
            }
            reader.Close();
            return dsCTHD;
        }
        public bool XoaCTHD(string MaHD)
        {
            string sql = "delete from ChiTietHoaDon where MaHD = @mahd";
            SqlParameter parMahd = new SqlParameter("@mahd", SqlDbType.VarChar);
            parMahd.Value = MaHD;
            bool kq = WriteData(sql, new[] { parMahd });
            return kq;
        }
        public bool ThemCTHD(ChiTietHoaDon cthd)
        {
            string sql = "insert into ChiTietHoaDon values(@mahd,@tpt,@sl,@madv,@thang)";
            SqlParameter parMahd = new SqlParameter("@mahd", System.Data.SqlDbType.VarChar);
            parMahd.Value = cthd.MaHD;
            SqlParameter parTpt = new SqlParameter("@tpt", System.Data.SqlDbType.Float);
            parTpt.Value = cthd.TienPhaiTra;
            SqlParameter parSldv = new SqlParameter("@sl", System.Data.SqlDbType.Int);
            parSldv.Value = cthd.SoLuongDV;
            SqlParameter parMadv = new SqlParameter("@madv", System.Data.SqlDbType.VarChar);
            parMadv.Value = cthd.MaDV;
            SqlParameter parThang = new SqlParameter("@thang", System.Data.SqlDbType.Int);
            parThang.Value = cthd.Thang;
            bool kq = WriteData(sql, new[] { parMahd, parTpt, parSldv, parMadv, parThang });
            return kq;
        }
        public bool SuaCTHD(ChiTietHoaDon cthd)
        {
            string sql = "update ChiTietHoaDon set MaHD = @mahd, TienPhaiTra = @tpt, SoLuongDV = @sldv, MaDV = @madv, Thang = @thang";
            SqlParameter parMahd = new SqlParameter("@mahd", System.Data.SqlDbType.VarChar);
            parMahd.Value = cthd.MaHD;
            SqlParameter parTpt = new SqlParameter("@tpt", System.Data.SqlDbType.Float);
            parTpt.Value = cthd.TienPhaiTra;
            SqlParameter parSoLuong = new SqlParameter("@sl", System.Data.SqlDbType.Int);
            parSoLuong.Value = cthd.SoLuongDV;
            SqlParameter parMadv = new SqlParameter("@madv", System.Data.SqlDbType.VarChar);
            parMadv.Value = cthd.MaDV;
            SqlParameter parThang = new SqlParameter("@thang", System.Data.SqlDbType.VarChar);
            parThang.Value = cthd.Thang;
            bool kq = WriteData(sql, new[] { parMahd, parTpt, parSoLuong, parMadv, parThang });
            return kq;
        }
    }
}
