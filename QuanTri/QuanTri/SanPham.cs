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
    public partial class SanPham : Form
    {
        SqlConnection con = new SqlConnection(new PATH().getPath());
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter adpt;
        DataTable dt;

        int ma;
        string ten;
        string chuDe;
        decimal gia;
        int loai;

        public SanPham()
        {
            InitializeComponent();
            display();
            btnUpdate.Enabled = false;
        }

        private void readInput()
        {
            ten = tbTen.Text;
            chuDe = tbChuDe.Text;
            gia = decimal.Parse(tbGiaBan.Text);
            loai = int.Parse(tbLoai.Text);
        }

        private void clearInput()
        {
            ma = int.MinValue;
            tbTen.Text = "";
            tbChuDe.Text = "";
            tbGiaBan.Text = "";
            tbLoai.Text = "";

            btnUpdate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            readInput();
            if (ten == "" || chuDe == "" || gia <= 0 || loai <= 0)
            {
                MessageBox.Show("Hãy điền dữ liệu hợp lý vào ô.");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("sp_ThemSanPham", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ten", ten);
                    cmd.Parameters.AddWithValue("@ChuDe", chuDe);
                    cmd.Parameters.AddWithValue("@GiaBan", gia);
                    cmd.Parameters.AddWithValue("@Loai", loai);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Thêm thành công.");

                    display();
                    clearInput();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
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

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ma = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;
                tbTen.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbChuDe.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbGiaBan.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                tbLoai.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();

                btnUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                readInput();
                con.Open();
                cmd = new SqlCommand("sp_CapNhatSanPham", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@ChuDe", chuDe);
                cmd.Parameters.AddWithValue("@GiaBan", gia);
                cmd.Parameters.AddWithValue("@Loai", loai);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Thêm thành công.");

                clearInput();
                display();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        private void tbTim_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from SANPHAM where TENSP like '%" + tbTim.Text + "%' ", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView.DataSource = dt;
            con.Close();
        }
    }
}
