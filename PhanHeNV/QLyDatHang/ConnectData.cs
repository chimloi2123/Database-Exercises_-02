using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLyDatHang
{
    internal class ConnectData
    {
        public SqlConnection conn;
        public void connect()
        {
            string strCon = new PATH().getPath();
            try
            {
                conn = new SqlConnection(strCon);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void disconnect()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }
        public Boolean exeSQL(string cmd)
        {
            try
            {
                SqlCommand sc = new SqlCommand(cmd, conn);
                sc.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
