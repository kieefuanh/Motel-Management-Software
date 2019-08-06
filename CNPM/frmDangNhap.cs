using BAL;
using DTO;
using System;
using System.Windows.Forms;
using CNPM.Classes;

namespace CNPM
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            string fileLogin = Application.StartupPath + "\\login.dat";
            IOUtil iou = new IOUtil();
            object data = iou.DocFile(fileLogin);
            if (data != null)
            {
                Login log = data as Login;
                if (log.Save)
                {
                    txtUsername.Text = log.UserName;
                    txtPassword.Text = log.Password;
                    ckbLuuThongTin.Checked = true;
                }
            }
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {

            TaiKhoanBAL bal = new TaiKhoanBAL();
            TaiKhoan acc = new TaiKhoan();
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;


            if (bal.KiemTraTaiKhoan(acc))
            {
                string filelogin = Application.StartupPath + "\\login.dat";
                IOUtil iou = new IOUtil();
                Login log = new Login();
                log.UserName = txtUsername.Text;
                log.Password = txtPassword.Text;
                log.Save = ckbLuuThongTin.Checked;
                iou.LuuFile(log, filelogin);
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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
