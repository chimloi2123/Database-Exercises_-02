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
    public partial class Xem_DSNhanVien : Form
    {
        public Xem_DSNhanVien()
        {
            InitializeComponent();
        }
        ConnectData c = new ConnectData();
        private void Xem_DSNhanVien_Load(object sender, EventArgs e)
        {
            c.connect();
            DataSet data = new DataSet();
            String query = "Select * From NHANVIEN WHERE LOAINV like 'Nhân viên bán hàng%'";
            SqlDataAdapter adp = new SqlDataAdapter(query, c.conn);
            adp.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.connect();
            DataSet data = new DataSet();
            String query = " declare @error varchar(500) "
                            + " exec TinhDoanhSo @maNV = 18 ,@error = @error out";
            SqlDataAdapter adp = new SqlDataAdapter(query, c.conn);
            adp.Fill(data);
            dataGridView2.DataSource = data.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
