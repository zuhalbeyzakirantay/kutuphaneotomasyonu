using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using kutuphaneotomasyonu.DAL;
using kutuphaneotomasyonu.Domain;

namespace kutuphaneotomasyonu.Service
{
    public class BorrowService
    {
        BorrowDAL borrowDAL = new BorrowDAL();
        BookDAL bookDAL = new BookDAL();

        public void BorrowBook(Borrow borrow)
        {
            bookDAL.DecreaseStock(borrow.BookId);
            borrowDAL.Add(borrow);
        }

        public void ReturnBook(int borrowId, int bookId)
        {
            borrowDAL.ReturnBook(borrowId);
            bookDAL.IncreaseStock(bookId);
        }

        public DataTable GetAll()
        {
            return borrowDAL.GetAll();
        }
    }
}






