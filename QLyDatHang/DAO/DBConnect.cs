using System;
using System.Collections.Generic;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DAO
{
    public class DBConnect
    {
        public SqlConnection creatsqlconnection()
        {
            string sqlIndex = @"Data Source=THAOTRUONG\SQL;Initial Catalog=HoaYeuThuong;Integrated Security=True";
            string sqlNoIndex = @"Data Source=THAOTRUONG\SQL;Initial Catalog=HoaYeuThuongNoIndex;Integrated Security=True";
            var conn1 = new SqlConnection(sqlIndex);
            try
            {
                conn1.Open();
                // conn1.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Timed Out");
                return new SqlConnection();
            }
            return conn1;
        }

    }
}
