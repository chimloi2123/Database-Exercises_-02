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
    public partial class LichSu : Form
    {
        SqlConnection con = new SqlConnection(new PATH().getPath());
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter adpt;
        DataTable dt;

        int ma;
        DateTime tu;
        DateTime den;

        public LichSu()
        {
            InitializeComponent();
            display();
        }

        private void readInput()
        {
            ma = int.Parse(tbMa.Text);
            tu = dtTu.Value;
            den = dtDen.Value;
        }

        private void display()
        {
            try
            {
                dt = new DataTable();
                adpt = new SqlDataAdapter();
                con.Open();
                cmd = new SqlCommand("sp_DanhSachSanPham", con);
                cmd.CommandType = CommandType.StoredProcedure;
                adpt.SelectCommand = cmd;
                adpt.Fill(dt);
                dataGridView.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            readInput();
            if (ma == null)
            {
                MessageBox.Show("Hãy nhập mã sản phẩm");
            }
            else
            {
                try
                {
                    dt = new DataTable();
                    adpt = new SqlDataAdapter();
                    con.Open();
                    cmd = new SqlCommand("sp_LichSuNhap", con);
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    cmd.Parameters.AddWithValue("@Tu", tu);
                    cmd.Parameters.AddWithValue("@Den", den);
                    cmd.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand = cmd;
                    adpt.Fill(dt);
                    dataGridView.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            readInput();
            if (ma == null)
            {
                MessageBox.Show("Hãy nhập mã sản phẩm");
            }
            else
            {
                try
                {
                    dt = new DataTable();
                    adpt = new SqlDataAdapter();
                    con.Open();
                    cmd = new SqlCommand("sp_LichSuXuat", con);
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    cmd.Parameters.AddWithValue("@Tu", tu);
                    cmd.Parameters.AddWithValue("@Den", den);
                    cmd.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand = cmd;
                    adpt.Fill(dt);
                    dataGridView.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
