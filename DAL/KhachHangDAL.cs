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
    public class KhachHangDAL: DatabaseService
    {
        

        //sẽ lưu lại tên, năm sinh, sdt, hộ khẩu và giói tính dựa vào mã đc nhập
        public bool SuaKH(string cm)
        {
            OpenConnection();
            string sql = "update KhachHang(TenKH, NamSinh, HoKhau, SDT, GioiTinh) Where CMND=@ma";
            SqlParameter parCM = new SqlParameter("@ma", SqlDbType.VarChar);
            parCM.Value = cm;
            bool kq = WriteData(sql,new[] { parCM});
            return kq;
            
        }
        //xóa thông tin theo mã
        public bool XoaKH(string cm)
        {
            OpenConnection();
            string sql = "delete KhachHang where CMND = @ma ";
            SqlParameter parCM = new SqlParameter("@ma",SqlDbType.VarChar);
            parCM.Value = cm;
            bool kq = WriteData(sql,new[] { parCM});
            return kq;
        }
        //tải ds lên grid view
        public List<KhachHang> TaiKH()
        {
            OpenConnection();
            List<KhachHang> dskh = new List<KhachHang>();
            
            string sql = "select * from KhachHang";
            SqlDataReader reader = ReadData(sql);
            while(reader.Read())
            {
                KhachHang k = new KhachHang();
                k.TenKH = reader.GetString(0);
                k.CMND = reader.GetString(2);
                k.HoKhau = reader.GetString(3);
                k.SDT = reader.GetString(4);
                k.NamSinh = reader.GetInt32(1);
                if (reader.GetInt32(5) == 1)
                {
                    k.GioiTinh = "Nam";
                }
                else
                    k.GioiTinh = "Nữ";

                dskh.Add(k);
            }
            reader.Close();
            return dskh;
        }
        //kt xem cmnd có bị trùng hay không
        public bool KTTrung(string cmnd)
        {
            OpenConnection();
            string sql = "select * from KhachHang where CMND=@cmnd";
            SqlParameter par = new SqlParameter("@cmnd",SqlDbType.VarChar);
            par.Value = cmnd;
            SqlDataReader reader = ReadDataPars(sql,new[] { par }) ;
            int dem = 0;
            while(reader.Read())
            {
                dem++;
            }
            reader.Close();
            if (dem != 0) return true;
            return false;
        }
        //lưu thông tin, nếu cmnd bị trùng thì lưu đè lên. Nếu ko trùng thì lưu mới
        public bool LuuThongTin(KhachHang k)
        {
            OpenConnection();
            string cmnd = k.CMND;
            if(KTTrung(cmnd) == true)
            {
                string sql = "update KhachHang set TenKH = @ten, NamSinh = @namsinh, SDT = @sdt," +
                    " HoKhau = @hokhau, GioiTinh=@gioitinh where CMND = @cmnd";

                SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
                string ten = ToiUuChuoi(k.TenKH);
                parTen.Value = ten;
                SqlParameter parNam = new SqlParameter("@namsinh", SqlDbType.Int);
                parNam.Value = k.NamSinh;
                SqlParameter parHoKhau = new SqlParameter("@hokhau", SqlDbType.NVarChar);
                parHoKhau.Value = k.HoKhau;
                SqlParameter parSDT = new SqlParameter("@sdt", SqlDbType.VarChar);
                parSDT.Value = k.SDT;
                SqlParameter parGT = new SqlParameter("@gioitinh", SqlDbType.Int);
                if (string.Compare(k.GioiTinh,"Nam") == 0)
                {
                    parGT.Value = 1;
                }
                else
                    parGT.Value = 0;
                SqlParameter parCM = new SqlParameter("@cmnd", SqlDbType.Int);
                parCM.Value = cmnd;

                bool kq = WriteData(sql, new[] { parTen, parNam, parSDT, parHoKhau, parGT, parCM });
                return kq;
            }
            else
            {
                string sql = "insert into KhachHang values(@ten, @namsinh, @cmnd, @hokhau, @sdt, @gioitinh)";
                SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
                string ten = ToiUuChuoi(k.TenKH);
                parTen.Value = ten;
                SqlParameter parNamSinh = new SqlParameter("@namsinh", SqlDbType.Int);
                parNamSinh.Value = k.NamSinh;
                SqlParameter parCM = new SqlParameter("@cmnd", SqlDbType.VarChar);
                parCM.Value = k.CMND;
                SqlParameter parHoKhau = new SqlParameter("@hokhau", SqlDbType.NVarChar);
                parHoKhau.Value = k.HoKhau;
                SqlParameter parSDT = new SqlParameter("@sdt", SqlDbType.NVarChar);
                parSDT.Value = k.SDT;
                SqlParameter parGT = new SqlParameter("@gioitinh", SqlDbType.Int);
                if (string.Compare(k.GioiTinh, "Nam") == 0)
                {
                    parGT.Value = 1;

                }
                else
                {
                    parGT.Value = 0;

                }

                bool kq = WriteData(sql, new[] { parTen, parNamSinh, parCM, parHoKhau, parSDT, parGT });
                return kq;
            }

        }
        //Tìm theo cmnd, trả về 1 khách hàng
        public KhachHang TimTheoCMND(string cmnd)
        {
            string sql = "select * from KhachHang where CMND=@cmnd";
            KhachHang k = new KhachHang();
            OpenConnection();
            SqlParameter parCM = new SqlParameter("@cmnd",SqlDbType.VarChar);
            parCM.Value = cmnd;
            SqlDataReader reader = ReadDataPars(sql, new[] { parCM});
            if(reader.Read())
            {
                k.TenKH = reader.GetString(0);
                k.NamSinh = reader.GetInt32(1); ;
                k.CMND = reader.GetString(2);
                k.HoKhau = reader.GetString(3);
                k.SDT = reader.GetString(4);
                if (reader.GetInt32(5) == 1)
                {
                    k.GioiTinh = "Nam";
                }
                else
                    k.GioiTinh = "Nữ";

            }
            reader.Close();
            return k;
        }
        //tải thông tin khách tìm đc lên grid view theo cm
        public List<KhachHang> Tai1KHTheoCM(string cm)
        {
            OpenConnection();
            List<KhachHang> dskh = new List<KhachHang>();

            string sql = "select * from KhachHang where CMND =@cm";
            SqlParameter parCM = new SqlParameter("@cm",SqlDbType.VarChar);
            parCM.Value = cm;
            SqlDataReader reader = ReadDataPars(sql,new[] { parCM});
            if (reader.Read())
            {
                KhachHang k = new KhachHang();
                k.TenKH = reader.GetString(0);
                k.CMND = cm;
                k.HoKhau = reader.GetString(3);
                k.SDT = reader.GetString(4);
                k.NamSinh = reader.GetInt32(1);
                if (reader.GetInt32(5) == 1)
                {
                    k.GioiTinh = "Nam";
                }
                else
                    k.GioiTinh = "Nữ";

                dskh.Add(k);
            }
            reader.Close();
            return dskh;
        }
        //Tìm Theo Tên KH
        public KhachHang TimTheoTen(string ten)
        {
            string sql = "select * from KhachHang where TenKH=@ten";
            KhachHang k = new KhachHang();
            OpenConnection();
            ten = ToiUuChuoi(ten); //Làm Cho tất chuỗi đưa vào đc viết hoa đầu và bớt khoảng trắng thừa
            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            
            parTen.Value = ten; ;
            SqlDataReader reader = ReadDataPars(sql, new[] { parTen });
            if (reader.Read())
            {
                k.TenKH = reader.GetString(0);
                k.NamSinh = reader.GetInt32(1); ;
                k.CMND = reader.GetString(2);
                k.HoKhau = reader.GetString(3);
                k.SDT = reader.GetString(4);
                if (reader.GetInt32(5) == 1)
                {
                    k.GioiTinh = "Nam";
                }
                else
                    k.GioiTinh = "Nữ";

            }
            reader.Close();
            return k;
        }
            //Tải 1 Kh dựa theo tên
            public List<KhachHang> Tai1KHTheoTen(string ten)
            {
                OpenConnection();
                List<KhachHang> dskh = new List<KhachHang>();
                ten = ToiUuChuoi(ten);
                string sql = "select * from KhachHang where TenKH =@ten";
                SqlParameter parCM = new SqlParameter("@ten", SqlDbType.NVarChar);
                parCM.Value = ten;
                SqlDataReader reader = ReadDataPars(sql, new[] { parCM });
                if (reader.Read())
                {
                    KhachHang k = new KhachHang();
                    k.TenKH = reader.GetString(0);
                    k.CMND = reader.GetString(2);
                    k.HoKhau = reader.GetString(3);
                    k.SDT = reader.GetString(4);
                    k.NamSinh = reader.GetInt32(1);
                    if (reader.GetInt32(5) == 1)
                    {
                        k.GioiTinh = "Nam";
                    }
                    else
                        k.GioiTinh = "Nữ";

                    dskh.Add(k);
                }
                reader.Close();
                return dskh;
            }
        
    }
}
