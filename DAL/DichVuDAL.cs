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
    public class DichVuDAL : DatabaseService
    {
        public List<DichVu> DSDichVu()
        {
            SqlDataReader reader = ReadData("select * from DichVu");
            List<DichVu> dsDV = new List<DichVu>();
            while (reader.Read())
            {
                string madv= reader.GetString(0);
                string tendv = reader.GetString(1);
                double gia = double.Parse(reader.GetString(2));
                string dongia = reader.GetString(3);
                DichVu dv = new DichVu();
                dv.MaDichVu = madv;
                dv.TenDichVu = tendv;
                dv.Gia = gia;
                dv.DonGia = dongia;
            }
            reader.Close();
            return dsDV;
        }
        public DichVu TimDVTheoTen(string TenDV)
        {
            SqlDataReader reader = ReadData("select * from DichVu where Thang like %"+TenDV+"%");
            string madv = reader.GetString(0);
            double gia = double.Parse(reader.GetString(2));
            string dongia = reader.GetString(3);
            DichVu dv = new DichVu();
            dv.MaDichVu = madv;
            dv.TenDichVu = TenDV;
            dv.Gia = gia;
            dv.DonGia = dongia;
            return dv;
        }
        public DichVu TimDVTheoMa(string MaDV)
        {
            SqlDataReader reader = ReadData("select * from DichVu where Thang = "+MaDV);
            string tendv = reader.GetString(1);
            double gia = double.Parse(reader.GetString(2));
            string dongia = reader.GetString(3);
            DichVu dv = new DichVu();
            dv.MaDichVu = MaDV;
            dv.TenDichVu = tendv;
            dv.Gia = gia;
            dv.DonGia = dongia;
            return dv;
        }
        public bool XoaDV(string MaDV)
        {
            string sql = "delete from DichVu where MaDV = @madv";
            SqlParameter parMadv = new SqlParameter("@madv", SqlDbType.VarChar);
            parMadv.Value = MaDV;
            bool kq = WriteData(sql, new[] { parMadv });
            return kq;
        }
        public bool ThemDV(DichVu dv)
        {
            string sql = "insert into DichVu values(@madv,@tendv,@gia,@dongia)";
            SqlParameter parMadv = new SqlParameter("@madv", System.Data.SqlDbType.VarChar);
            parMadv.Value = dv.MaDichVu;
            SqlParameter parTendv = new SqlParameter("@tendv", System.Data.SqlDbType.NVarChar);
            parTendv.Value = dv.TenDichVu;
            SqlParameter parGia = new SqlParameter("@gia", System.Data.SqlDbType.Float);
            parGia.Value = dv.Gia;
            SqlParameter parDongia = new SqlParameter("@dongia", System.Data.SqlDbType.NVarChar);
            parDongia.Value = dv.DonGia;
            bool kq = WriteData(sql, new[] { parMadv, parTendv, parGia, parDongia});
            return kq;
        }
        public bool SuaDV(DichVu dv)
        {
            string sql = "update DichVu set MaDV = @madv, TenDV = @tendv, Gia = @gia, DonGia = @dongia";
            SqlParameter parMadv = new SqlParameter("@madv", System.Data.SqlDbType.VarChar);
            parMadv.Value = dv.MaDichVu;
            SqlParameter parTendv = new SqlParameter("@tendv", System.Data.SqlDbType.NVarChar);
            parTendv.Value = dv.TenDichVu;
            SqlParameter parGia = new SqlParameter("@sl", System.Data.SqlDbType.Float);
            parGia.Value = dv.Gia;
            SqlParameter parDongia = new SqlParameter("@dongia", System.Data.SqlDbType.NVarChar);
            parDongia.Value = dv.DonGia;
            bool kq = WriteData(sql, new[] { parMadv, parTendv, parGia, parDongia });
            return kq;
        }
    }
}
