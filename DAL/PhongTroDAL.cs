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
    public class PhongTroDAL:DatabaseService
    {
        public bool ThemPhongTro(PhongTro pt)
        {
            string sql = "insert into PhongTro values(@ma, @tinhtrang, @gia, @diachi)";
            OpenConnection();
            SqlParameter parMa = new SqlParameter("@ma",SqlDbType.VarChar);
            parMa.Value = pt.MaPhong;
            SqlParameter parTT = new SqlParameter("@tinhtrang", SqlDbType.NVarChar);
            parTT.Value = pt.TinhTrang;
            SqlParameter parGia = new SqlParameter("@gia", SqlDbType.Int);
            parGia.Value = pt.GiaPhong;
            bool kq = WriteData(sql, new[] {parMa,parTT,parGia });
            SqlParameter parDC = new SqlParameter("@diachi", SqlDbType.NVarChar);
            parDC.Value = pt.DiaChi;
            return kq;

        }
        //lấy thông tin tất cả phòng để đưa và datagrid view
        public List<PhongTro> TaiDSPhongTro()
        {
            List<PhongTro> dspt = new List<PhongTro>();
            OpenConnection();
            string sql = "select * from PhongTro";
            SqlDataReader reader = ReadData(sql);
            while (reader.Read())
            {
                PhongTro pt = new PhongTro();
                pt.MaPhong = reader.GetString(0);
                pt.TinhTrang = reader.GetString(1);
                pt.GiaPhong = reader.GetDouble(2);
                pt.DiaChi = reader.GetString(3);

                dspt.Add(pt);
            }
            reader.Close();
            return dspt;
        }

        //Lấy Thông Tin 1 phòng
        public PhongTro ThongTin1Phong(string ma)
        {
            PhongTro pt = new PhongTro();
            OpenConnection();
            string sql = "select * from PhongTro where MaPhong = @ma";
            SqlParameter parMa = new SqlParameter("@ma",SqlDbType.VarChar);
            parMa.Value = ma;
            SqlDataReader reader = ReadDataPars(sql,new[] { parMa});
            if(reader.Read())
            {
                pt.MaPhong = reader.GetString(0);
                pt.GiaPhong = reader.GetInt32(2);
                pt.TinhTrang = reader.GetString(1);
                pt.DiaChi = reader.GetString(3);
            }
            reader.Close();
            return pt;           
        }
    }
}
