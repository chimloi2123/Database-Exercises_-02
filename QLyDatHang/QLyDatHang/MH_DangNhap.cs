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
    public partial class MH_DangNhap : Form
    {
        public MH_DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            
            DataTable t = DAO.DB_LOGIN.connect(txbUserName.Text.ToString().Trim(), txbPassword.Text.ToString().Trim());
            // MessageBox.Show(t.Rows.Count + " ");
            // user: 1, matkhau: 12345: Quan tri
            //user: 2; matkhau: 12345 : Quan ly
            //user :3; mat khau: 12345 : Nhan su
            //user: 4; matkhau: 12345 : Khachhang
            if (t.Rows.Count == 0)
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu sai, vui lòng thử lại!");

            }
            else if (txbUserName.Text.ToString() == "1")
            {

                MH_XemLSGiaSP xemdssp = new MH_XemLSGiaSP(txbUserName.Text.ToString(), txbPassword.Text.ToString());
                //txbusername.text.tostring()
                xemdssp.Show();
                this.Hide();
            }
            else if (txbUserName.Text.ToString() == "2")
            {

                MH_QLyHieuSuat xemdssp = new MH_QLyHieuSuat();
                ////txbusername.text.tostring()
                xemdssp.Show();
                this.Hide();
            }
            //else if (txbUserName.Text.ToString().IndexOf("NV") != -1)
            //{
            //    if(t.Rows[0][8].ToString()== "Quản trị viên")
            //    {

            //        MH_QLySanPhamQTV MHQLYSP = new MH_QLySanPhamQTV(txbUserName.Text.ToString(), txbPassword.Text.ToString());
            //        MHQLYSP.Show();
            //        this.Hide();
            //    }
            //    //mh_xemdssp xemdssp = new mh_xemdssp();
            //    ////txbusername.text.tostring()
            //    //xemdssp.show();
            //    //this.hide();
            //}
            //else if (txbUserName.Text.ToString().IndexOf("DT") != -1)
            //{
            //    MH_QlySP_DT qlySP = new MH_QlySP_DT(txbUserName.Text.ToString(), txbPassword.Text.ToString());

            //    qlySP.Show();
            //    this.Hide();
            //}



            //Application.Run(new MH_QLySanPhamQTV());
        }
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    MH_QtriND qlnv= new MH_QtriND();
        //    qlnv.Show();
        //    this.Hide();

        //}
    }
}
