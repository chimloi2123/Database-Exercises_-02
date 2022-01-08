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

namespace Khoa
{
    public partial class MH_QuanLy : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-TTF1SC1\\SQLEXPRESS; Initial Catalog = HoaYeuThuong; Integrated Security = True;");
        public MH_QuanLy()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MH_ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            string sql = "Select * from CUAHANG";
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(sql, con);
            adpt.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenCH";
            comboBox1.ValueMember = "MaCH";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec DOANHTHU_CH N'" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            dataGridView1.Columns["DOANHTHU"].Width = 180;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec sp_XemSanPhamBanChay N'" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec sp_XemSanPhamBanCham N'" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            con.Close();
        }
         
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec SOSANHDOANHTHU_CH N'" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox4.Text + "','" + comboBox3.Text + "','" + comboBox5.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec sp_XemTongSoLuongHang ", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            con.Close();
        }
    }
}
