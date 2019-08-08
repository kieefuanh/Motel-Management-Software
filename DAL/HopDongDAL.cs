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
    public class HopDongDAL: DatabaseService
    {
        public bool ThemHopDong(HopDong hd)
        {
            OpenConnection();
            string sql = "insert into HopDong values(@mahd, @ngaythue, @ngaytra, @maphong, @chuthich, @cmnd, @coc)";
            SqlParameter parMaHD = new SqlParameter("@mahd",SqlDbType.VarChar);
            parMaHD.Value = hd.MaHopDong;
            SqlParameter parMaPhong = new SqlParameter("@maphong", SqlDbType.VarChar);
            parMaPhong.Value = hd.MaPhong;
            SqlParameter parCMND = new SqlParameter("@cmnd", SqlDbType.VarChar);
            parCMND.Value = hd.CMND;
            SqlParameter parNgayThue = new SqlParameter("@ngaythue", SqlDbType.DateTime);
            parNgayThue.Value = hd.NgayThue;
            SqlParameter parNgayTra = new SqlParameter("@ngaytra", SqlDbType.DateTime);
            parNgayTra.Value = hd.NgayTra;
            SqlParameter parChuThich = new SqlParameter("@chuthich", SqlDbType.NVarChar);
            parChuThich.Value = hd.ChuThich;
            SqlParameter parCoc = new SqlParameter("@coc", SqlDbType.Float);
            parCoc.Value = hd.Coc;

            bool kq = WriteData(sql, new[] { parMaHD, parNgayThue, parNgayTra, parMaPhong, parChuThich, parCMND, parCoc });
            return kq;
        }
        //lấy mã  Phòng, mã hop73 đồng, ngày trả, ngày thuê theo cmnd đưa vào
        public  HopDong LayThongTinKH(string cm)
        {
            string sql = "select * from HopDong where CMND=@cm";
            HopDong hd = new HopDong();
            SqlParameter parCM = new SqlParameter("@cm",SqlDbType.VarChar);
            parCM.Value = cm;
            SqlDataReader reader = ReadDataPars(sql,new[] { parCM});
            if(reader.Read())
            {
                hd.MaPhong = reader.GetString(3);
                hd.MaHopDong = reader.GetString(0);
                hd.NgayThue = reader.GetDateTime(1);
                hd.NgayTra = reader.GetDateTime(2);
            }
            return hd;

        }
        
    }
}
