using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DTO;

namespace CNPM
{
    public partial class frmNguoiThue : Form
    {
        public frmNguoiThue()
        {
            InitializeComponent();

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DgvNguoiThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //thông tin trong text box thay đổi lúc nhấn vào dgv 
            txtHoTen.Text = dgvNguoiThue.SelectedRows[0].Cells[0].Value.ToString();
            txtNgaySinh.Text = dgvNguoiThue.SelectedRows[0].Cells[1].Value.ToString();
            txtCMND.Text = dgvNguoiThue.SelectedRows[0].Cells[2].Value.ToString();
            txtHoKhau.Text = dgvNguoiThue.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dgvNguoiThue.SelectedRows[0].Cells[4].Value.ToString();
            txtDienThoai.Text =dgvNguoiThue.SelectedRows[0].Cells[5].Value.ToString();
            
            btnSua.Enabled = true;
            //hiển thị mã phòng, ngày thuê, ngày trả theo thông tin đc chọn trong dgv            
            HopDongBAL bal = new HopDongBAL();
            HopDong hd = bal.LayThongTinKH(txtCMND.Text);
            txtMaPhong.Text = hd.MaPhong;
            txtKetThuc.Text = hd.NgayTra.ToString();
            txtBatDau.Text = hd.NgayThue.ToString();

        }

        private void FrmNguoiThue_Load(object sender, EventArgs e)
        {
            TaiDL();
            string[] cmbox = {"Nam", "Nữ" };
            comboBox1.DataSource = cmbox;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
           
        }
        private void TaiDL()
        {
            KhachHangBAL bal = new KhachHangBAL();
            dgvNguoiThue.DataSource = bal.TaiKH();
        }
        private void LamTrongTextBox()
        {
            txtBatDau.Text = "";
            txtCMND.Text = "";
            txtDienThoai.Text = "";
            txtHoKhau.Text = "";
            txtHoTen.Text = "";
            txtKetThuc.Text = "";
            txtMaPhong.Text = "";
            txtNgaySinh.Text = "00";
            txtCMND.Focus();
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            LamTrongTextBox();
            btnLuu.Enabled = true;

        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            KhachHang k = new KhachHang();
            k.CMND = txtCMND.Text;
            k.TenKH = txtHoTen.Text;
            k.HoKhau = txtHoKhau.Text;
            k.NamSinh = int.Parse(txtNgaySinh.Text);
            k.SDT = txtDienThoai.Text;
            k.GioiTinh = comboBox1.SelectedItem.ToString();
            KhachHangBAL bal = new KhachHangBAL();
            bool kq = bal.LuuThongTin(k);
            if (kq)
            {
                MessageBox.Show("Lưu Thành Công");
            }
            else
            {
                MessageBox.Show("Lưu Thất Bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TaiDL();
        }

        private void TxtTimNguoiThue_TextChanged(object sender, EventArgs e)
        {
            KhachHangBAL bal = new KhachHangBAL();
            string cm = txtTimNguoiThue.Text;
            KhachHang k = bal.TimTheoCM(cm);
            if(k != null)
            {
                dgvNguoiThue.DataSource= bal.Tai1KH(k.CMND);
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Khách Có CMND ["+txtTimNguoiThue.Text+"] " );
            }
        }
    }
}
