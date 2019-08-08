using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BAL;

namespace CNPM
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }

        private void TxtGiaPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
            
        }
        private void TaiDSPhongTro()
        {
            PhongTroBAL bal = new PhongTroBAL();
            dgvPhong.DataSource = bal.TaiDSPhongTro();
        }

        private void FrmPhong_Load(object sender, EventArgs e)
        {
            TaiDSPhongTro();
            txtNguoiThue.Enabled = false;
            txtCMND.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void DgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = dgvPhong.SelectedRows[0].Cells[0].Value.ToString();
            txtGiaPhong.Text = dgvPhong.SelectedRows[0].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvPhong.SelectedRows[0].Cells[3].Value.ToString();
            string tinhtrang = txtGiaPhong.Text = dgvPhong.SelectedRows[0].Cells[1].Value.ToString();
            if (string.Compare(tinhtrang,"Trống",true)==0)
            {
                rdbTrong.Checked = true;
            }
            else
            {
                rdbDaDuocThue.Checked = true;
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {

        }

        //Xóa các text box
        private void LamMoiTextBox()
        {
            txtMaPhong.Text = "";
            txtDiaChi.Text = "";
            txtGiaPhong.Text = "";
            txtNguoiThue.Text = "";
            txtCMND.Text = "";
           
        }
    }
}
