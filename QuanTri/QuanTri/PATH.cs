using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanTri
{
    class PATH
    {
        string path = @"Data Source=RAINBOWNICORN\SQL1;Initial Catalog=HoaYeuThuong;Integrated Security=True;";

        public PATH()
        {

        }

        public string getPath()
        {
            return path;
        }
    }
}
