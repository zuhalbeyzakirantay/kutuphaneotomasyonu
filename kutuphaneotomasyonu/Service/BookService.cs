using System;
using System.Data;
using kutuphaneotomasyonu.DAL;
using kutuphaneotomasyonu.Domain;

namespace kutuphaneotomasyonu.Service
{
    public class BookService
    {
        BookDAL bookDAL = new BookDAL();

        // 1️⃣ KİTAP EKLEME (İŞ KURALLARI VAR)
        public void AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Name))
            {
                throw new Exception("Kitap adı boş olamaz");
            }

            if (book.Stock < 0)
            {
                throw new Exception("Stok 0'dan küçük olamaz");
            }

            bookDAL.Add(book);
        }

       
        public DataTable GetAllBooks()
        {
            return bookDAL.GetAllBooks();
        }

        public void DeleteBook(int bookId)
        {
            bookDAL.Delete(bookId);
        }

        public void UpdateBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Name))
                throw new Exception("Kitap adı boş olamaz");

            if (book.Stock < 0)
                throw new Exception("Stok 0'dan küçük olamaz");

            bookDAL.Update(book);
        }
    }



}
