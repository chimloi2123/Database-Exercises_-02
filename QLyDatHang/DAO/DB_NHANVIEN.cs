using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace DAO
{
    public class DB_NHANVIEN
    {
   
             public static DataTable getHieuSuatNV(int manv, int nam, int thang)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "select  nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01'))) as songaytrongthang" +
                " from nhanvien nv , luongthuong lt" +
                " where nv.MANV = lt.MANV" +
                "  AND nv.manv = " + manv + "and lt.thang= " + thang + " and lt.nam= " + nam +
                " group by nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01')))" +
                "	order by lt.nam desc, lt.thang desc";
        
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MANV"].ColumnName = "Mã NV";
                dt.Columns["HOTEN"].ColumnName = "Họ Tên";
                dt.Columns["thang"].ColumnName = "Tháng";
                dt.Columns["nam"].ColumnName = "Năm";
                dt.Columns["SONGAYLAM"].ColumnName = "Số ngày làm";
                dt.Columns["SONGAYTRONGTHANG"].ColumnName = "Số ngày trong tháng";

            }
            return dt;
        }

        public static DataTable getHieuSuatNVAll( int nam, int thang)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "select  nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01'))) as songaytrongthang" +
                " from nhanvien nv , luongthuong lt" +
                " where nv.MANV = lt.MANV" +
                 " and lt.thang= " + thang + " and lt.nam= " + nam +
                " group by nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01')))" +
                "	order by lt.nam desc, lt.thang desc";
         

            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MANV"].ColumnName = "Mã NV";
                dt.Columns["HOTEN"].ColumnName = "Họ Tên";
                dt.Columns["thang"].ColumnName = "Tháng";
                dt.Columns["nam"].ColumnName = "Năm";
                dt.Columns["SONGAYLAM"].ColumnName = "Số ngày làm";
                dt.Columns["SONGAYTRONGTHANG"].ColumnName = "Số ngày trong tháng";

            }
            return dt;
        }
        public static DataTable getHieuSuatNVtenNV(string tennv, int nam, int thang)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "select  nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01'))) as songaytrongthang" +
                " from nhanvien nv , luongthuong lt" +
                " where nv.MANV = lt.MANV" +
                "  AND nv.HOTEN LIKE  '%" + tennv + "%' and lt.thang= " + thang + " and lt.nam= " + nam +
                " group by nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01')))" +
                "	order by lt.nam desc, lt.thang desc";
           

            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MANV"].ColumnName = "Mã NV";
                dt.Columns["HOTEN"].ColumnName = "Họ Tên";
                dt.Columns["thang"].ColumnName = "Tháng";
                dt.Columns["nam"].ColumnName = "Năm";
                dt.Columns["SONGAYLAM"].ColumnName = "Số ngày làm";
                dt.Columns["SONGAYTRONGTHANG"].ColumnName = "Số ngày trong tháng";

            }
            return dt;
        }

        public static DataTable getHieuSuatNVKTG(int manv)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "select  nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01'))) as songaytrongthang" +
                " from nhanvien nv , luongthuong lt" +
                " where nv.MANV = lt.MANV" +
                "  AND nv.manv=" + manv + 
                " group by nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01')))" +
                "	order by lt.nam desc, lt.thang desc";
            

            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MANV"].ColumnName = "Mã NV";
                dt.Columns["HOTEN"].ColumnName = "Họ Tên";
                dt.Columns["thang"].ColumnName = "Tháng";
                dt.Columns["nam"].ColumnName = "Năm";
                dt.Columns["SONGAYLAM"].ColumnName = "Số ngày làm";
                dt.Columns["SONGAYTRONGTHANG"].ColumnName = "Số ngày trong tháng";

            }
            return dt;
        }

        public static DataTable getHieuSuatNVtenNVKTG(string tennv)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "select  nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01'))) as songaytrongthang" +
                " from nhanvien nv , luongthuong lt" +
                " where nv.MANV = lt.MANV" +
                "  AND nv.HOTen LIKE  '%" + tennv + "%' "+ 
                " group by nv.MANV,nv.HOTEN, lt.thang,lt.nam, lt.SONGAYLAM,day(eomonth(str(nam) + '-' + trim(str(thang) + '-01')))" +
                "	order by lt.nam desc, lt.thang desc";
          

            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MANV"].ColumnName = "Mã NV";
                dt.Columns["HOTEN"].ColumnName = "Họ Tên";
                dt.Columns["thang"].ColumnName = "Tháng";
                dt.Columns["nam"].ColumnName = "Năm";
                dt.Columns["SONGAYLAM"].ColumnName = "Số ngày làm";
                dt.Columns["SONGAYTRONGTHANG"].ColumnName = "Số ngày trong tháng";

            }
            return dt;
        }


    
    }
}
