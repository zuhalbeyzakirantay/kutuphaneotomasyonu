using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace kutuphaneotomasyonu.DAL
{
    public class ReportDAL
    {
        DbConnection db = new DbConnection();

        public DataTable GetAllBorrows()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"
                SELECT 
                    m.Name AS MemberName,
                    bk.Name AS BookName,
                    b.BorrowDate,
                    b.ReturnDate,
                    b.IsReturned
                FROM borrows b
                JOIN members m ON b.MemberId = m.MemberId
                JOIN books bk ON b.BookId = bk.BookId";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetNotReturnedBorrows()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"
                SELECT 
                    m.Name AS MemberName,
                    bk.Name AS BookName,
                    b.BorrowDate
                FROM borrows b
                JOIN members m ON b.MemberId = m.MemberId
                JOIN books bk ON b.BookId = bk.BookId
                WHERE b.IsReturned = 0";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetMostReadBooks()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"
                SELECT 
                    bk.Name AS BookName,
                    COUNT(*) AS BorrowCount
                FROM borrows b
                JOIN books bk ON b.BookId = bk.BookId
                GROUP BY bk.Name
                ORDER BY BorrowCount DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
