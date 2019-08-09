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
            btnThem.DialogResult = DialogResult.Yes;
            btnSua.DialogResult = DialogResult.No;

            txtMaDichVu.ReadOnly = false;
            txtTenDichVu.ReadOnly = false;
            txtGia.ReadOnly = false;
            txtDonVi.ReadOnly = false;

            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtGia.Text = "";
            txtDonVi.Text = "";

        }
        private void Sua()
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
                MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại !", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void Them()
        {
            DichVuBAL bal = new DichVuBAL();
            DichVu dv = new DichVu();
            dv.MaDichVu = txtMaDichVu.Text;
            dv.TenDichVu = txtTenDichVu.Text;
            dv.Gia = double.Parse(txtGia.Text);
            dv.DonGia = txtDonVi.Text;

            bool kq = bal.ThemDichVu(dv);
            if (kq)
            {
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK);
                LoadData();
            }
            else
            {
                MessageBox.Show("Mã dịch vụ đã tồn tại !", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            btnThem.DialogResult = DialogResult.No;
            btnSua.DialogResult = DialogResult.Yes;

            txtMaDichVu.ReadOnly = false;
            txtTenDichVu.ReadOnly = false;
            txtGia.ReadOnly = false;
            txtDonVi.ReadOnly = false;

        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            DichVuBAL bal = new DichVuBAL();
            DichVu dv = new DichVu();
            bool kq = bal.XoaDV(txtMaDichVu.Text);
            if (kq)
            {
                MessageBox.Show("Xoá thành công !", "Thông báo", MessageBoxButtons.OK);
                LoadData();
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
            txtMaDichVu.Text = dgvDichVu.SelectedRows[0].Cells[0].Value.ToString();
            txtTenDichVu.Text = dgvDichVu.SelectedRows[0].Cells[1].Value.ToString();
            txtGia.Text = dgvDichVu.SelectedRows[0].Cells[2].Value.ToString();
            txtDonVi.Text = dgvDichVu.SelectedRows[0].Cells[3].Value.ToString();

            txtMaDichVu.ReadOnly = true;
            txtTenDichVu.ReadOnly = true;
            txtGia.ReadOnly = true;
            txtDonVi.ReadOnly = true;
        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvDichVu.Columns[0].HeaderText = "Mã dịch vụ";
            dgvDichVu.Columns[1].HeaderText = "Tên dịch vụ";
            dgvDichVu.Columns[2].HeaderText = "Giá";
            dgvDichVu.Columns[3].HeaderText = "Đơn vị";

            txtMaDichVu.ReadOnly = true;
            txtTenDichVu.ReadOnly = true;
            txtGia.ReadOnly = true;
            txtDonVi.ReadOnly = true;


        }
        private void LoadData()
        {
            DichVuBAL bal = new DichVuBAL();
            dgvDichVu.DataSource = bal.DSDichVu();
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDichVu.Text == "" || txtTenDichVu.Text == "" || txtGia.Text == ""|| txtDonVi.Text == "")
            {
                MessageBox.Show("Thông tin còn trống !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            if (btnThem.DialogResult == DialogResult.Yes)
            {
                Them();
            }
            else
            {
                Sua();
            }
        }
    }
}
