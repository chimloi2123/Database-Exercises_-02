using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanTri
{
    public partial class QuanTri : Form
    {
        SqlConnection con = new SqlConnection(new PATH().getPath());
        SqlCommand cmd;
        SqlDataReader dr;

        public QuanTri()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new SanPham());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccMan_Click(object sender, EventArgs e)
        {
            openChildForm(new LichSu());
        }
    }
}