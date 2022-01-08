using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLyDatHang
{
    public partial class MH_QLyTonKho : Form
    {
        DataTable DS_DT = new DataTable();
        public MH_QLyTonKho()
        {
            InitializeComponent();
        }

        public MH_QLyTonKho(string username, string password)
        {
            InitializeComponent();
           

        }
   

        private void MH_QtriND_Load(object sender, EventArgs e)
        {
            MH_Load();
        }
        private void MH_Load()
        {
            DataTable dt = new DataTable();
            dt = DAO.DB_SANPHAM.getAllDSTonKho();
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không có sản phẩm yêu cầu!");
            lstSP.DataSource = dt;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MH_DangNhap mhDN = new MH_DangNhap();
            mhDN.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MH_XemLSGiaSP mhDN = new MH_XemLSGiaSP();
            mhDN.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MH_Load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtmaSP.Text.Trim() != "")
            {
                int masp = Int32.Parse(txtmaSP.Text.Trim());
                DataTable dt = new DataTable();
                dt = DAO.DB_SANPHAM.getAllDSTonMaSP(masp);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không có sản phẩm yêu cầu!");
                lstSP.DataSource = dt;
            }
            else if (tensp.Text.Trim() != "")
            {
                string tenSP = tensp.Text.Trim();
                DataTable dt = new DataTable();
                dt = DAO.DB_SANPHAM.getAllDSTonTenSP(tenSP);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không có sản phẩm yêu cầu!");
                lstSP.DataSource = dt;
            }
            else if (txtMaCH.Text.Trim() != "")
            { int maCH = Int32.Parse(txtMaCH.Text.Trim());
                DataTable dt = new DataTable();
                dt = DAO.DB_SANPHAM.getAllDSTonMaCH( maCH);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không có sản phẩm yêu cầu!");
                lstSP.DataSource = dt;
            }
        }
    }
}
