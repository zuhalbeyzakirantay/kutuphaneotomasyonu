using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using kutuphaneotomasyonu.DAL;

namespace kutuphaneotomasyonu.Service
{
    public class ReportService
    {
        ReportDAL reportDAL = new ReportDAL();

        public DataTable GetAllBorrows()
        {
            return reportDAL.GetAllBorrows();
        }

        public DataTable GetNotReturnedBorrows()
        {
            return reportDAL.GetNotReturnedBorrows();
        }

        public DataTable GetMostReadBooks()
        {
            return reportDAL.GetMostReadBooks();
        }
    }
}
