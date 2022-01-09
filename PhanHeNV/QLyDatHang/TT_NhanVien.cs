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
    public partial class TT_NhanVien : Form
    {
        public TT_NhanVien()
        {
            InitializeComponent();
        }
        ConnectData c = new ConnectData();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TT_NhanVien_Load(object sender, EventArgs e)
        {
            c.connect();
            DataSet data = new DataSet();
            String query = "Select * From TT_NHANVIEN";
            SqlDataAdapter adp = new SqlDataAdapter(query, c.conn);
            adp.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            //textBox3.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            string gt = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            if(gt == "0")
            {
                textBox3.Text = "Nữ";
            } else
            {
                textBox3.Text = "Nam";
            }


            textBox4.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
