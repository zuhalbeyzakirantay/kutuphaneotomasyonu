using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kutuphaneotomasyonu.Service;
using kutuphaneotomasyonu.Domain;
using kutuphaneotomasyonu.UI;

namespace kutuphaneotomasyonu.UI
{
    public partial class BorrowForm : Form
    {
        BorrowService borrowService = new BorrowService();
        MemberService memberService = new MemberService();
        BookService bookService = new BookService();

        int selectedBorrowId = 0;
        int selectedBookId = 0;

        public BorrowForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void BorrowForm_Load(object sender, EventArgs e)
        {
            cmbMembers.DataSource = memberService.GetAllMembers();
            cmbMembers.DisplayMember = "Name";
            cmbMembers.ValueMember = "MemberId";

            cmbBooks.DataSource = bookService.GetAllBooks();
            cmbBooks.DisplayMember = "Name";
            cmbBooks.ValueMember = "BookId";

            dtBorrowDate.Value = DateTime.Now;
            dtReturnDate.Value = DateTime.Now.AddDays(14);


            dataGridViewBorrow.AutoGenerateColumns = true;
            dataGridViewBorrow.DataSource = borrowService.GetAll();
            
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            Borrow borrow = new Borrow
            {
                MemberId = Convert.ToInt32(cmbMembers.SelectedValue),
                BookId = Convert.ToInt32(cmbBooks.SelectedValue),
                BorrowDate = dtBorrowDate.Value,
                ReturnDate = dtReturnDate.Value,
                IsReturned = false
            };

            borrowService.BorrowBook(borrow);

            MessageBox.Show("Kitap ödünç verildi");

            dataGridViewBorrow.DataSource = null;
            dataGridViewBorrow.DataSource = borrowService.GetAll();
        }

        private void dataGridViewBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewBorrow.Rows[e.RowIndex];

                selectedBorrowId = Convert.ToInt32(row.Cells["BorrowId"].Value);
                selectedBookId = Convert.ToInt32(row.Cells["BookId"].Value);
            }


        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedBorrowId == 0)
            {
                MessageBox.Show("Lütfen iade edilecek kitabı seçin");
                return;
            }

            borrowService.ReturnBook(selectedBorrowId, selectedBookId);

            MessageBox.Show("Kitap başarıyla iade alındı");

            dataGridViewBorrow.DataSource = borrowService.GetAll();

            selectedBorrowId = 0;
            selectedBookId = 0;
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
            this.Hide();
        }
    }
}
