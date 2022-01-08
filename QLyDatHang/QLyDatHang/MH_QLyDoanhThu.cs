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
    public partial class MH_QLyDoanhThu : Form
    {
        public MH_QLyDoanhThu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MH_QLyHieuSuat mhHS = new MH_QLyHieuSuat();
            mhHS.Show();
            this.Hide();
        }

        private void MH_QLyDoanhThu_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        private void HienThi()
        {
            string dateTu = timepicker.Value.ToString("yyyy-MM-dd");
            string dateDen = timepicker2.Value.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            //int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
            //int month = Int32.Parse(timepicker.Value.ToString("MM"));
            dt = DAO.DB_SANPHAM.getDoanhThuAll(dateTu, dateDen);
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy thông tin yêu cầu!");
            list.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMaCH.Text.Trim() != "")
            {
                string dateTu = timepicker.Value.ToString("yyyy-MM-dd");
                string dateDen = timepicker2.Value.ToString("yyyy-MM-dd");
                //int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
                //int month = Int32.Parse(timepicker.Value.ToString("MM"));
                int maCH = Int32.Parse(txtMaCH.Text);
                DataTable dt = new DataTable();
                dt = DAO.DB_SANPHAM.getDoanhThuMaCH(maCH, dateTu, dateDen);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy thông tin yêu cầu!");
                list.DataSource = dt;


            }
            else if (txtTenCH.Text.Trim() != "")
            {
                string dateTu = timepicker.Value.ToString("yyyy-MM-dd");
                string dateDen = timepicker2.Value.ToString("yyyy-MM-dd");
                //int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
                //int month = Int32.Parse(timepicker.Value.ToString("MM"));
                string ten = txtTenCH.Text.Trim();
                DataTable dt = new DataTable();
                dt = DAO.DB_SANPHAM.getDoanhThuTenCH(ten, dateTu, dateDen);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy thông tin yêu cầu!");
                list.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dateTu = timepicker.Value.ToString("yyyy-MM-dd");
            string dateDen = timepicker2.Value.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            //int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
            //int month = Int32.Parse(timepicker.Value.ToString("MM"));
            dt = DAO.DB_SANPHAM.getDoanhThuAll(dateTu,dateDen);
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy thông tin yêu cầu!");
            list.DataSource = dt;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MH_DangNhap mhDN = new MH_DangNhap();
            mhDN.Show();
            this.Hide();
        }
    }
    }

