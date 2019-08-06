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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (String.Compare(txtMatKhauMoi.Text, txtXacNhan.Text, false) == 0)
            {
                TaiKhoanBAL bal = new TaiKhoanBAL();
                if (bal.SuaMatKhau(txtMatKhauMoi.Text))
                    MessageBox.Show("Đổi mật khẩu thành công ");
            }
        }

        private void BtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            TaiKhoanBAL bal = new TaiKhoanBAL();
            if (bal.KiemTraMatKhau(txtMatKhau.Text)) groupBox1.Enabled = true;
        }


    }
}
