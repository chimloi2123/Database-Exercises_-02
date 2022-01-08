using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Windows.Forms;
namespace DAO
{
    public class DB_LOGIN
    {
        public static DataTable connect(string acc, string pass)
        {
            string t = "SELECT * FROM NHANVIEN WHERE MANV= '" + acc + "' AND MATKHAU= '" + pass + "'";
            return DataProvider.Instance.ExecuteQuery(t);
        }
    }
}
