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
    public partial class MH_ThanhToan : Form
    {  
        public MH_ThanhToan()
        {
            InitializeComponent();
        }
       

        private void MH_ThanhToan_Load(object sender, EventArgs e)
        {
            MH_Load();
        }
        private void MH_Load()
        {
           
        }
        private void tinhTongTien()
        {
           
        }

        private void DatHang_Click(object sender, EventArgs e)
        {
           // string dchigiao = dcgiao.Text;
           // DateTime ngaygiao = ngay.Value;
           // string ngaygiao2 = ngaygiao.Date.ToString();
          
           // string httt = hinhthuctt.Text;
           // string tinhtrang=" ";
           // if(httt== "Thanh toán tiền mặt")
           // {
           //     tinhtrang = "Đã thanh toán";
           // }
           // else if(httt == "Thanh toán bằng thẻ")
           // {
           //     tinhtrang = "Đã thanh toán";
           // }
           // else if(httt== "COD")
           // {
           //     tinhtrang = "Chưa thanh toán";
           // }
           //BUS.DONHANG.ThemDH(kh.email,kh.pass,ngaygiao, TongTB, dchigiao, httt, tinhtrang,lstSP_DTChon);
           // MH_XemDSDH xemdsdh = new MH_XemDSDH(kh.email,kh.pass);
           // xemdsdh.Show();
           // this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
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
