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
            OpenConnection();
            SqlDataReader reader = ReadData("select * from DichVu");
            List<DichVu> dsDV = new List<DichVu>();
            while (reader.Read())
            {
                string madv= reader.GetString(0);
                string tendv = reader.GetString(1);
                double gia = reader.GetDouble(2);
                string dongia = reader.GetString(3);
                DichVu dv = new DichVu();
                dv.MaDichVu = madv;
                dv.TenDichVu = tendv;
                dv.Gia = gia;
                dv.DonGia = dongia;
                dsDV.Add(dv);
            }
            reader.Close();
            return dsDV;
        }
        public List<DichVu> TimDVTheoTen(string TenDV)
        {
            OpenConnection();
            SqlDataReader reader = ReadData("select * from DichVu where TenDV like N'%"+TenDV+"%'");
            //SqlParameter parTen = new SqlParameter("@tendv", SqlDbType.NVarChar);
            //parTen.Value = TenDV;
            List<DichVu> dsDV = new List<DichVu>();
            while (reader.Read())
            {
                string madv = reader.GetString(0);
                string tendv = reader.GetString(1);
                double gia = reader.GetDouble(2);
                string dongia = reader.GetString(3);
                DichVu dv = new DichVu();
                dv.MaDichVu = madv;
                dv.TenDichVu = tendv;
                dv.Gia = gia;
                dv.DonGia = dongia;
                dsDV.Add(dv);
            }
            reader.Close();
            return dsDV;
        }
        public DichVu TimDVTheoMa(string MaDV)
        {
            SqlDataReader reader = ReadData("select * from DichVu where MaDV = '"+MaDV+"'");
            //SqlParameter parMadv = new SqlParameter("@madv", SqlDbType.VarChar);
            //parMadv.Value = MaDV;
            if (reader.Read())
            {
                string madv = reader.GetString(0);
                string tendv = reader.GetString(1);
                double gia = reader.GetDouble(2);
                string dongia = reader.GetString(3);
                DichVu dv = new DichVu();
                dv.MaDichVu = madv;
                dv.TenDichVu = tendv;
                dv.Gia = gia;
                dv.DonGia = dongia;
                reader.Close();
                return dv;
            }
            else
            {
                return null;
            }
        }
        public bool XoaDV(string MaDV)
        {
            OpenConnection();
            string sql = "delete from DichVu where MaDV = @madv";
            SqlParameter parMadv = new SqlParameter("@madv", SqlDbType.VarChar);
            parMadv.Value = MaDV;
            bool kq = WriteData(sql, new[] { parMadv });
            return kq;
        }
        public bool ThemDV(DichVu dv)
        {
            string sql = "insert into DichVu values (@madv,@tendv,@gia,@dongia)";
            SqlParameter parMadv = new SqlParameter("@madv", SqlDbType.VarChar);
            parMadv.Value = dv.MaDichVu;
            SqlParameter parTendv = new SqlParameter("@tendv", SqlDbType.NVarChar);
            parTendv.Value = dv.TenDichVu;
            SqlParameter parGia = new SqlParameter("@gia", SqlDbType.Float);
            parGia.Value = dv.Gia;
            SqlParameter parDongia = new SqlParameter("@dongia", SqlDbType.NVarChar);
            parDongia.Value = dv.DonGia;
            bool kq = WriteData(sql, new[] { parMadv, parTendv, parGia, parDongia});
            return kq;
        }
        public bool SuaDV(DichVu dv)
        {
            string sql = "update DichVu set TenDV = @tendv, Gia = @gia, DonGia = @dongia where MaDV = @madv";
            SqlParameter parMadv = new SqlParameter("@madv", System.Data.SqlDbType.VarChar);
            parMadv.Value = dv.MaDichVu;
            SqlParameter parTendv = new SqlParameter("@tendv", System.Data.SqlDbType.NVarChar);
            parTendv.Value = dv.TenDichVu;
            SqlParameter parGia = new SqlParameter("@gia", System.Data.SqlDbType.Float);
            parGia.Value = dv.Gia;
            SqlParameter parDongia = new SqlParameter("@dongia", System.Data.SqlDbType.NVarChar);
            parDongia.Value = dv.DonGia;
            bool kq = WriteData(sql, new[] { parMadv, parTendv, parGia, parDongia });
            return kq;
        }
    }
}
