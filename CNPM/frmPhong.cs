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
        }

        private void DgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
