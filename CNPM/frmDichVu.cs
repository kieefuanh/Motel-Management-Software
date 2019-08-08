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
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            DichVuBAL bal = new DichVuBAL();
            DichVu dv = new DichVu();
            dv.MaDichVu = txtMaDichVu.Text;
            dv.TenDichVu = txtTenDichVu.Text;
            dv.Gia = double.Parse(txtGia.Text);
            dv.DonGia = txtDonVi.Text;
            bool kq = bal.ThemDV(dv);
            if (kq)
            {
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Thêm thất bại !", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            DichVuBAL bal = new DichVuBAL();
            DichVu dv = new DichVu();
            dv.MaDichVu = txtMaDichVu.Text;
            dv.TenDichVu = txtTenDichVu.Text;
            dv.Gia = double.Parse(txtGia.Text);
            dv.DonGia = txtDonVi.Text;
            bool kq = bal.SuaDV(dv);
            if (kq)
            {
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Sửa thất bại !", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            DichVuBAL bal = new DichVuBAL();
            DichVu dv = new DichVu();
            bool kq = bal.XoaDV(txtMaDichVu.Text);
            if (kq)
            {
                MessageBox.Show("Xoá thành công !", "Thông báo", MessageBoxButtons.OK);
                dgvDichVu.DataSource = bal.DSDichVu();
            }
            else
            {
                MessageBox.Show("Xoá thất bại !", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            DichVuBAL bal = new DichVuBAL();
            List<DichVu> kq = bal.TimDVTheoTen(txtTimDichVu.Text);
            if (kq != null)
            {
                dgvDichVu.DataSource = kq;
            }
            else
            {
                MessageBox.Show("Xoá thất bại !", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void DgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            DichVuBAL bal = new DichVuBAL();
            dgvDichVu.DataSource = bal.DSDichVu();
        }
    }
}
