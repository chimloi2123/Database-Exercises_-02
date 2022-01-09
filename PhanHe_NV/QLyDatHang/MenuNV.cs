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
    
    public partial class MenuNV : Form
    {
        public MenuNV()
        {
            InitializeComponent();
        }
        ConnectData c = new ConnectData();
        NHANVIEN Form1 = new NHANVIEN();
        NV_GiaoHang Form2 = new NV_GiaoHang();
        TT_NhanVien Form3 = new TT_NhanVien();
        Xem_DSNhanVien Form4 = new Xem_DSNhanVien();

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2.Show();
        }

        private void MenuNV_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4.Show();
        }
    }
}
