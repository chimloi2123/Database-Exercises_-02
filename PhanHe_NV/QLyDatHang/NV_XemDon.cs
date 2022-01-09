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

namespace QLyDatHang
{
    public partial class NHANVIEN : Form
    {
        public NHANVIEN()
        {
            InitializeComponent();
        }
        ConnectData c = new ConnectData();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.connect();
            DataSet data = new DataSet();
            String query = "declare @error varchar(500) " + 
                            " exec TinhDonNVBanHang @maNV = " + MANV.Text + " ,@error = @error out";
            SqlDataAdapter adp = new SqlDataAdapter(query, c.conn);
            adp.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.connect();
            DataSet data = new DataSet();
            String query = "declare @error varchar(500) " +
                            " exec TinhDonNVThuKho @maNV = " + MANV.Text + " ,@error = @error out";
            SqlDataAdapter adp = new SqlDataAdapter(query, c.conn);
            adp.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }
    }
}
