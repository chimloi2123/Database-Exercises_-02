using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLyDatHang
{
    public partial class MH_XemDSDH : Form
    {
        
        public MH_XemDSDH()
        {
            InitializeComponent();
        }
        public MH_XemDSDH(string username,string password)
        {
            InitializeComponent();
            //kh.email = username;
            // kh.pass = password;
        }

        private void MH_XemDSDH_Load(object sender, EventArgs e)
        {
            MH_Load();
        }
        private void MH_Load()
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
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
           // MH_Load();
        }
    }
}
