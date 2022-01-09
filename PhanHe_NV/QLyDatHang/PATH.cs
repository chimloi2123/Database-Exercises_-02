using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLyDatHang
{
    internal class PATH
    {
        string path = @"Data Source=WATERFOUR\SQLEXPRESS01;Initial Catalog=HoaYeuThuong;Integrated Security=True;";

        public PATH()
        {

        }

        public string getPath()
        {
            return path;
        }
    }
}
