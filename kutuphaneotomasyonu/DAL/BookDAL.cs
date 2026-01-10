using MySql.Data.MySqlClient;
using kutuphaneotomasyonu.Domain;
using System.Data;

namespace kutuphaneotomasyonu.DAL
{
    public class BookDAL
    {
        DbConnection db = new DbConnection();

        // 1️⃣ KİTAP EKLEME
        public void Add(Book book)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO books
                (ISBN, Name, Author, Publisher, PublishYear, Stock)
                VALUES (@ISBN, @Name, @Author, @Publisher, @PublishYear, @Stock)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@Name", book.Name);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@PublishYear", book.PublishYear);
                cmd.Parameters.AddWithValue("@Stock", book.Stock);

                cmd.ExecuteNonQuery();
            }
        }


        public DataTable GetAllBooks()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM books";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        public void Delete(int bookId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM books WHERE BookId = @BookId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookId", bookId);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Book book)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE books SET
            ISBN = @ISBN,
            Name = @Name,
            Author = @Author,
            Publisher = @Publisher,
            PublishYear = @PublishYear,
            Stock = @Stock
            WHERE BookId = @BookId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@Name", book.Name);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@PublishYear", book.PublishYear);
                cmd.Parameters.AddWithValue("@Stock", book.Stock);
                cmd.Parameters.AddWithValue("@BookId", book.BookId);

                cmd.ExecuteNonQuery();
            }
        }
        public void DecreaseStock(int bookId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE books 
                         SET Stock = Stock - 1 
                         WHERE BookId = @bookId AND Stock > 0";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookId", bookId);
                cmd.ExecuteNonQuery();
            }
        }
        public void IncreaseStock(int bookId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE books 
                         SET Stock = Stock + 1 
                         WHERE BookId = @bookId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookId", bookId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}