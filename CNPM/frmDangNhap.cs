using BAL;
using DTO;
using System;
using System.Windows.Forms;

namespace CNPM
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {

            TaiKhoanBAL bal = new TaiKhoanBAL();
            TaiKhoan acc = new TaiKhoan();
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;


            if (bal.KiemTraTaiKhoan(acc))
            {
                frmTrangChu f = new frmTrangChu();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Sai thông tin đăng nhập");
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
