using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace QLyDatHang
{
    public partial class MH_XemLSGiaSP : Form
    {

        public MH_XemLSGiaSP()
        {
            InitializeComponent();
        }
        public MH_XemLSGiaSP(string username, string password)
        {
            InitializeComponent();
          
        }
  

        private void MH_QLySanPhamQTV_Load(object sender, EventArgs e)
        {
            MH_Load();
        }
        private void MH_Load()
        {
            DataTable dt = new DataTable();
            string date = timepicker.Value.ToString("yyyy-MM-dd");
            dt = DAO.DB_SANPHAM.getLsGiaMaSP(1,date);
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy sản phẩm yêu cầu!");
            lstSP.DataSource = dt;
        }


        private void QTND_Click(object sender, EventArgs e)
        {
            MH_QLyTonKho QTND = new MH_QLyTonKho();
            QTND.Show();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MH_DangNhap mhDN = new MH_DangNhap();
            mhDN.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            MH_Load();
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            if (txtmaSP.Text.Trim() != "")
            { string date = timepicker.Value.ToString("yyyy-MM-dd");
                int masp = Int32.Parse(txtmaSP.Text);
                DataTable dt = new DataTable();
                dt = DAO.DB_SANPHAM.getLsGiaMaSP(masp,date);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy sản phẩm yêu cầu!");
                lstSP.DataSource = dt;
                

            }
            else if (tensp.Text.Trim() != "")
                {
                string date = timepicker.Value.ToString("yyyy-MM-dd");
                string ten = tensp.Text.Trim();
                DataTable dt = new DataTable();
                dt = DAO.DB_SANPHAM.getLsGiaTenSP(ten,date);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy sản phẩm yêu cầu!");
                lstSP.DataSource = dt;
            }
        }

     
    }
}
