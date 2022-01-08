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
    public class DB_SANPHAM
    {
        public static DataTable getdsSP(string username, string pass)
        {
            DBConnect _dbContext = new DBConnect();
         
                SqlConnection _dbConnection = _dbContext.creatsqlconnection();
                SqlCommand command = new SqlCommand("select * from sanpham", _dbConnection);
                DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            { 
                dt.Columns["MASP"].ColumnName = "Mã SP";
                dt.Columns["TENSP"].ColumnName = "Tên SP";
                dt.Columns["TONGSL"].ColumnName = "Tổng SL";
                dt.Columns["LOAIHANG"].ColumnName = "Loại hàng";
                dt.Columns["SLDT"].ColumnName = "SL Đối Tác";
            }
            return dt;
        }
        public static void UpdateTenSP(string username, string pass,int masp, string tensp)
        {
            DBConnect _dbContext = new DBConnect();
            try
            {
                SqlConnection _dbConnection = _dbContext.creatsqlconnection();
                SqlCommand command = new SqlCommand("exec sp_UpdateTenSP " + masp + ",'" + tensp + "'", _dbConnection);
                command.ExecuteNonQuery();
                //MessageBox.Show("Đã thay đổi thông tin sản phẩm");
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR" + ex.Message);
            }
        }

        public static DataTable getLsGiaMaSP(int masp,string date)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "set statistics io on SELECT SP.MASP, SP.TENSP, CTDH.DONGIA,DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT)) as NGAY FROM SANPHAM SP,  CT_DONDATHANG CTDH, DONDATHANG DH " +
         " WHERE    SP.MASP = CTDH.MASP AND DH.MADH = CTDH.MADH AND dh.NGAYDAT > '" + date + "' and sp.masp= " + masp  +
         " GROUP BY SP.MASP,SP.TENSP,ctdh.dongia, DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT))   ORDER BY  DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT)) DESC, SP.MASP ASC ";
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MASP"].ColumnName = "Mã SP";
                dt.Columns["TENSP"].ColumnName = "Tên SP";
                dt.Columns["DONGIA"].ColumnName = "Giá ";
                dt.Columns["NGAY"].ColumnName = "Ngày";
               
            }
            return dt;
        }
        public static DataTable getLsGiaTenSP(string tensp,string date)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "set statistics io on " +
       "SELECT SP.MASP, SP.TENSP, CTDH.DONGIA,DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT)) as NGAY " +
        "FROM SANPHAM SP,  CT_DONDATHANG CTDH, DONDATHANG DH " +
    " WHERE  SP.MASP = CTDH.MASP AND DH.MADH = CTDH.MADH AND dh.NGAYDAT > '"+date+"' and SP.TENSP like '%" + tensp+"%' " +
      " GROUP BY SP.MASP,SP.TENSP,ctdh.dongia, DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT))   ORDER BY  DATEADD(dd, 0, DATEDIFF(dd, 0, DH.NGAYDAT)) DESC, SP.MASP ASC";
         
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MASP"].ColumnName = "Mã SP";
                dt.Columns["TENSP"].ColumnName = "Tên SP";
                dt.Columns["DONGIA"].ColumnName = "Giá ";
                dt.Columns["NGAY"].ColumnName = "Ngày";

            }
            return dt;
        }

        public static DataTable getAllDSTonKho()
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "  SELECT CH.MACH,  CH.TENCH ,SPCH.MASP ,SP.TENSP, SPCH.SLTON " +
        "FROM CUAHANG CH, SANPHAM_CUAHANG SPCH, SANPHAM SP "+
        "WHERE CH.MACH = SPCH.MACH  and SPCH.MASP = SP.MASP "+
        "GROUP BY CH.MACH,CH.TENCH, SPCH.MASP, SP.TENSP,SPCH.SLTON "+
        "order by CH.MACH  ";
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MACH"].ColumnName = "Mã Cửa hàng";
                dt.Columns["TENCH"].ColumnName = "Tên Cửa hàng";
                dt.Columns["MASP"].ColumnName = "Mã SP ";
                dt.Columns["TENSP"].ColumnName = "Tên SP ";
                dt.Columns["SLTON"].ColumnName = "Tồn";

            }
            return dt;
        }
        public static DataTable getAllDSTonMaSP(int masp)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "  SELECT CH.MACH,  CH.TENCH ,SPCH.MASP ,SP.TENSP, SPCH.SLTON " +
        "FROM CUAHANG CH, SANPHAM_CUAHANG SPCH, SANPHAM SP " +
        "WHERE CH.MACH = SPCH.MACH  and SPCH.MASP = SP.MASP AND SP.MASP= "+masp +
        " GROUP BY CH.MACH,CH.TENCH, SPCH.MASP, SP.TENSP,SPCH.SLTON " +
        "order by CH.MACH  ";
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MACH"].ColumnName = "Mã Cửa hàng";
                dt.Columns["TENCH"].ColumnName = "Tên Cửa hàng";
                dt.Columns["MASP"].ColumnName = "Mã SP ";
                dt.Columns["TENSP"].ColumnName = "Tên SP ";
                dt.Columns["SLTON"].ColumnName = "Tồn";

            }
            return dt;
        }
        public static DataTable getAllDSTonTenSP(string tensp)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "  SELECT CH.MACH,  CH.TENCH,SPCH.MASP ,SP.TENSP, SPCH.SLTON " +
        "FROM CUAHANG CH, SANPHAM_CUAHANG SPCH, SANPHAM SP " +
        "WHERE CH.MACH = SPCH.MACH  and SPCH.MASP = SP.MASP AND SP.TENSP LIKE '%" + tensp +
        "%' GROUP BY CH.MACH,CH.TENCH, SPCH.MASP, SP.TENSP,SPCH.SLTON " +
        "order by CH.MACH  ";
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MACH"].ColumnName = "Mã Cửa hàng";
                dt.Columns["TENCH"].ColumnName = "Tên Cửa hàng";
                dt.Columns["MASP"].ColumnName = "Mã SP ";
                dt.Columns["TENSP"].ColumnName = "Tên SP ";
                dt.Columns["SLTON"].ColumnName = "Tồn";

            }
            return dt;
        }

        public static DataTable getAllDSTonMaCH(int mach)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = "  SELECT CH.MACH,  CH.TENCH ,SPCH.MASP, SP.TENSP, SPCH.SLTON " +
        "FROM CUAHANG CH, SANPHAM_CUAHANG SPCH, SANPHAM SP " +
        "WHERE CH.MACH = SPCH.MACH  and SPCH.MASP = SP.MASP AND CH.MACH = " + mach +
        " GROUP BY CH.MACH,CH.TENCH, SPCH.MASP, SP.TENSP,SPCH.SLTON " +
        "order by CH.MACH  ";
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MACH"].ColumnName = "Mã Cửa hàng";
                dt.Columns["TENCH"].ColumnName = "Tên Cửa hàng";
                dt.Columns["MASP"].ColumnName = "Mã SP ";
                dt.Columns["TENSP"].ColumnName = "Tên SP ";
                dt.Columns["SLTON"].ColumnName = "Tồn";

            }
            return dt;
        }

        public static DataTable getDoanhThuAll(string timebegin, string timeEnd)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = " SET STATISTICS IO ON" +
                " SELECT  CH.MACH, CH.TENCH,MONTH(DH.NGAYDAT) THANG,YEAR(DH.NGAYDAT) NAM, SUM(TONGTIENTHUC) AS DOANHTHU " +
                "  FROM DONDATHANG DH, CUAHANG CH, SANPHAM_CUAHANG SPCH, CT_DONDATHANG CTDH, SANPHAM SP" +
                "  WHERE SPCH.MACH = CH.MACH and SPCH.MASP = SP.MASP and CTDH.MASP = SP.MASP and DH.MADH = CTDH.MADH AND DH.NGAYDAT BETWEEN '"+timebegin+"' AND '"+timeEnd+
                "'  GROUP BY MONTH(DH.NGAYDAT), YEAR(DH.NGAYDAT), CH.MACH, CH.TENCH" +
                " ORDER BY YEAR(DH.NGAYDAT)DESC, MONTH(DH.NGAYDAT)DESC, CH.MACH ,  SUM(TONGTIENTHUC) DESC";
         
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MACH"].ColumnName = "Mã Cửa hàng";
                dt.Columns["TENCH"].ColumnName = "Tên CH";
                dt.Columns["THANG"].ColumnName = "Tháng";
                dt.Columns["NAM"].ColumnName = "Năm";
                dt.Columns["DOANHTHU"].ColumnName = "Doanh thu";
            }
            return dt;
        }

        public static DataTable getDoanhThuMaCH(int mach, string timebegin, string timeEnd)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = " SET STATISTICS IO ON" +
                " SELECT  CH.MACH, CH.TENCH,MONTH(DH.NGAYDAT) THANG,YEAR(DH.NGAYDAT) NAM, SUM(TONGTIENTHUC) AS DOANHTHU " +
                "  FROM DONDATHANG DH, CUAHANG CH, SANPHAM_CUAHANG SPCH, CT_DONDATHANG CTDH, SANPHAM SP" +
                "  WHERE SPCH.MACH = CH.MACH and SPCH.MASP = SP.MASP and CTDH.MASP = SP.MASP and DH.MADH = CTDH.MADH AND CH.MACH= "+mach + " AND DH.NGAYDAT BETWEEN '" + timebegin + "' AND '" + timeEnd +
                "' GROUP BY MONTH(DH.NGAYDAT), YEAR(DH.NGAYDAT), CH.MACH, CH.TENCH" +
                " ORDER BY YEAR(DH.NGAYDAT)DESC, MONTH(DH.NGAYDAT)DESC, CH.MACH ,  SUM(TONGTIENTHUC) DESC";
          

            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MACH"].ColumnName = "Mã Cửa hàng";
                dt.Columns["TENCH"].ColumnName = "Tên CH";
                dt.Columns["THANG"].ColumnName = "Tháng";
                dt.Columns["NAM"].ColumnName = "Năm";
                dt.Columns["DOANHTHU"].ColumnName = "Doanh thu";
            }
            return dt;
        }
        public static DataTable getDoanhThuTenCH(string tench, string timebegin, string timeEnd)
        {
            DBConnect _dbContext = new DBConnect();

            SqlConnection _dbConnection = _dbContext.creatsqlconnection();
            string sqlString = " SET STATISTICS IO ON" +
                " SELECT  CH.MACH, CH.TENCH,MONTH(DH.NGAYDAT) THANG,YEAR(DH.NGAYDAT) NAM, SUM(TONGTIENTHUC) AS DOANHTHU " +
                "  FROM DONDATHANG DH, CUAHANG CH, SANPHAM_CUAHANG SPCH, CT_DONDATHANG CTDH, SANPHAM SP" +
                "  WHERE SPCH.MACH = CH.MACH and SPCH.MASP = SP.MASP and CTDH.MASP = SP.MASP and DH.MADH = CTDH.MADH AND CH.TENCH LIKE '%" + tench + "%'  AND DH.NGAYDAT BETWEEN '" + timebegin + "' AND '" + timeEnd +
                "' GROUP BY MONTH(DH.NGAYDAT), YEAR(DH.NGAYDAT), CH.MACH, CH.TENCH" +
                " ORDER BY YEAR(DH.NGAYDAT)DESC, MONTH(DH.NGAYDAT)DESC, CH.MACH ,  SUM(TONGTIENTHUC) DESC";
         
            SqlCommand command = new SqlCommand(sqlString, _dbConnection);
            DataTable dt = new DataTable();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            if (dt.Columns.Count != 0)
            {
                dt.Columns["MACH"].ColumnName = "Mã Cửa hàng";
                dt.Columns["TENCH"].ColumnName = "Tên CH";
                dt.Columns["THANG"].ColumnName = "Tháng";
                dt.Columns["NAM"].ColumnName = "Năm";
                dt.Columns["DOANHTHU"].ColumnName = "Doanh thu";
            }
            return dt;
        }



       

    }
}
