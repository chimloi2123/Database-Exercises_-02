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
    public partial class MH_QLyHieuSuat : Form
    {
       
        
        public MH_QLyHieuSuat()
        {
            InitializeComponent();
        }
        private void MH_QLyHieuSuat_Load(object sender, EventArgs e)
        {

           Hienthi();
        }
        public void Hienthi()
        {

            DataTable dt = new DataTable();
           int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
            int month = Int32.Parse(timepicker.Value.ToString("MM"));
            dt = DAO.DB_NHANVIEN.getHieuSuatNVAll( year,month);
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy thông tin yêu cầu!");
             list.DataSource = dt;
        }

        private void list_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void suattsp_Click(object sender, EventArgs e)
        {
           
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MH_DangNhap mhDN = new MH_DangNhap();
            mhDN.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //Hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() != "")
            {
                int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
                int month = Int32.Parse(timepicker.Value.ToString("MM"));
                int manv = Int32.Parse(txtMaNV.Text);
                DataTable dt = new DataTable();
                dt = DAO.DB_NHANVIEN.getHieuSuatNV(manv,year,month );
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy thông tin nhân viên yêu cầu!");
                list.DataSource = dt;


            }
            else if (txtTenNV.Text.Trim() != "")
            {
                int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
                int month = Int32.Parse(timepicker.Value.ToString("MM"));
                string ten = txtTenNV.Text.Trim();
                DataTable dt = new DataTable();
                dt = DAO.DB_NHANVIEN.getHieuSuatNVtenNV(ten, year, month);
                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy thông tin nhân viên yêu cầu!");
                list.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int year = Int32.Parse(timepicker.Value.ToString("yyyy"));
            int month = Int32.Parse(timepicker.Value.ToString("MM"));
            dt = DAO.DB_NHANVIEN.getHieuSuatNVAll(year, month);
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy thông tin yêu cầu!");
            list.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MH_QLyDoanhThu mhDT = new MH_QLyDoanhThu();
            mhDT.Show();
            this.Hide();
        }
    }
    }
