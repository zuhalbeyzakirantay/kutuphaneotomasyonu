using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kutuphaneotomasyonu.DAL;
using kutuphaneotomasyonu.Domain;
using kutuphaneotomasyonu.Service;
namespace kutuphaneotomasyonu.UI
{
    public partial class BookForm : Form
    {


        BookService bookService = new BookService();
        int selectedBookId = 0;

        public BookForm()
        {
            InitializeComponent();
        }


        private void BookForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bookService.GetAllBooks();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtISBN.Text) ||
                    string.IsNullOrWhiteSpace(txtAd.Text) ||
                    string.IsNullOrWhiteSpace(txtYazar.Text) ||
                    string.IsNullOrWhiteSpace(txtYayinevi.Text) ||
                    string.IsNullOrWhiteSpace(txtBasim.Text) ||
                    string.IsNullOrWhiteSpace(txtStok.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!");
                    return;
                }

                Book book = new Book();

                book.ISBN = txtISBN.Text;
                book.Name = txtAd.Text;
                book.Author = txtYazar.Text;
                book.Publisher = txtYayinevi.Text;
                book.PublishYear = int.Parse(txtBasim.Text);
                book.Stock = int.Parse(txtStok.Text);

                bookService.AddBook(book);

                MessageBox.Show("Kitap başarıyla eklendi ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedBookId = Convert.ToInt32(row.Cells["BookId"].Value);

                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                txtAd.Text = row.Cells["Name"].Value.ToString();
                txtYazar.Text = row.Cells["Author"].Value.ToString();
                txtYayinevi.Text = row.Cells["Publisher"].Value.ToString();
                txtBasim.Text = row.Cells["PublishYear"].Value.ToString();
                txtStok.Text = row.Cells["Stock"].Value.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Lütfen silinecek kitabı seçin");
                return;
            }

            bookService.DeleteBook(selectedBookId);

            MessageBox.Show("Kitap silindi");

            dataGridView1.DataSource = bookService.GetAllBooks();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (selectedBookId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek kitabı seçin");
                return;
            }

            try
            {
                Book book = new Book
                {
                    BookId = selectedBookId,
                    ISBN = txtISBN.Text,
                    Name = txtAd.Text,
                    Author = txtYazar.Text,
                    Publisher = txtYayinevi.Text,
                    PublishYear = int.Parse(txtBasim.Text),
                    Stock = int.Parse(txtStok.Text)
                };

                bookService.UpdateBook(book);

                MessageBox.Show("Kitap güncellendi");

                dataGridView1.DataSource = bookService.GetAllBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm();
            memberForm.Show();
            this.Hide();
        }
    }
}
