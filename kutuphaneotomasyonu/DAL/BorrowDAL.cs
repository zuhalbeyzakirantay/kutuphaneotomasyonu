using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using kutuphaneotomasyonu.Domain;

namespace kutuphaneotomasyonu.DAL
{
    public class BorrowDAL
    {
        DbConnection db = new DbConnection();

        public void Add(Borrow borrow)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO borrows
               (MemberId, BookId, BorrowDate, ReturnDate, IsReturned)
               VALUES (@MemberId, @BookId, @BorrowDate, @ReturnDate, 0)";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberId", borrow.MemberId);
                cmd.Parameters.AddWithValue("@BookId", borrow.BookId);
                cmd.Parameters.AddWithValue("@BorrowDate", borrow.BorrowDate);
                cmd.Parameters.AddWithValue("@ReturnDate", borrow.ReturnDate);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"
        SELECT 
            b.BorrowId,
            b.BookId,
            m.Name AS MemberName,
            bk.Name AS BookName,
            b.BorrowDate,
            b.ReturnDate,
            b.IsReturned
        FROM borrows b
        INNER JOIN members m ON b.MemberId = m.MemberId
        INNER JOIN books bk ON b.BookId = bk.BookId
        ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;

        }

        public void ReturnBook(int borrowId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE borrows SET
                                 IsReturned = 1,
                                 ReturnDate = NOW()
                                 WHERE BorrowId = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", borrowId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
