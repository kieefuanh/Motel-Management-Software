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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            ChiTietHoaDonBAL chiTietHoaDonBAL = new ChiTietHoaDonBAL();
            HopDongBAL hopDongBAL = new HopDongBAL();
            dgvHoaDon.DataSource = chiTietHoaDonBAL.DSChiTietHoaDon();
        }
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvHoaDon.Columns[0].HeaderText = "Mã hoá đơn";
            dgvHoaDon.Columns[1].HeaderText = "Mã phòng";
            dgvHoaDon.Columns[2].HeaderText = "CMND";
            dgvHoaDon.Columns[3].HeaderText = "Dich vụ";
            dgvHoaDon.Columns[4].HeaderText = "Số lượng";
            dgvHoaDon.Columns[5].HeaderText = "Tháng";
            dgvHoaDon.Columns[6].HeaderText = "Tổng tiền";
        }
    }
}
