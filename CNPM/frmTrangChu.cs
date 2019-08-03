using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM
{
    public partial class frmTrangChu : Form
    {
        
        private void CallToChildForm(object childForm)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form fr = childForm as Form;
            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fr);
            this.panel1.Tag = fr;
            fr.Show();
            
        }
        public frmTrangChu()
        {
            InitializeComponent();
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thoát ?", "Hỏi thoát", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes) Application.Exit();
        }

        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThoat.PerformClick();
        }

        private void BtnPhong_Click(object sender, EventArgs e)
        {
            CallToChildForm(new frmPhong());
        }

        private void BtnNguoiThue_Click(object sender, EventArgs e)
        {
            CallToChildForm(new frmNguoiThue());
        }

        private void BtnDichVu_Click(object sender, EventArgs e)
        {
            CallToChildForm(new frmDichVu());
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            CallToChildForm(new frmHoaDon());
        }
    }
}
