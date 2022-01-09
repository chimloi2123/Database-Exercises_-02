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
    public partial class NV_GiaoHang : Form
    {
        public NV_GiaoHang()
        {
            InitializeComponent();
        }

        ConnectData c = new ConnectData();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NV_GiaoHang_Load(object sender, EventArgs e)
        {
            c.connect();
            DataSet data = new DataSet();
            String query = "Select * From NVGIAOHANG";
            SqlDataAdapter adp = new SqlDataAdapter(query, c.conn);
            adp.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }

        private void NV_GiaoHang_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
        }
    }
}
