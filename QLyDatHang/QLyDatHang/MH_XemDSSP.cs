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
    public partial class MH_XemDSSP : Form
    {
      
        public MH_XemDSSP()
        {
            InitializeComponent();
        }
        public MH_XemDSSP(string username,string password)
        {
            InitializeComponent();
          
        }
       

        private void MH_XemDSSP_Load(object sender, EventArgs e)
        {

            MH_Load();
         
         
        }
        private void MH_Load()
        {

            

        }

        private void searchProduct_Click(object sender, EventArgs e)
        {
        }

        private void searchDT_Click(object sender, EventArgs e)
        {
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm!");
            else
            { string textSearch = txtSearch.Text.Trim();
                if (searchProduct.BackColor ==System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(186)))), ((int)(((byte)(0))))))
                {
                    
                    //Tim theo ten san pham
                    DataTable dt = new DataTable();
                    
                  
                }
                else if(searchDT.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(186)))), ((int)(((byte)(0))))))
                {
                 
                }
            }
        }

        private void XemSPTheoDT_Click(object sender, EventArgs e)
        {
           
        }
       
        private void add_product_Click(object sender, EventArgs e)
        {
            
           
        }

        private void thanhtoan_Click(object sender, EventArgs e)
        {
            MH_ThanhToan mhtt = new MH_ThanhToan();
            mhtt.Show();
        }

        private void DSDH_Click(object sender, EventArgs e)
        {
            
            MH_XemDSDH mhdsdh = new MH_XemDSDH();
            mhdsdh.Show();
            this.Hide();
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
