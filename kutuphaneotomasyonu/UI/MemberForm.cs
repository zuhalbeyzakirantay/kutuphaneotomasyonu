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
    public partial class MemberForm : Form
    {
        MemberService memberService = new MemberService();
        int selectedMemberId = 0;

        public MemberForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = memberService.GetAllMembers();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Member member = new Member
                {
                    Name = txtAd.Text,
                    Surname = txtSoyad.Text,
                    Phone = txtTelefon.Text,
                    Email = txtEmail.Text
                };

                memberService.AddMember(member);

                MessageBox.Show("Üye eklendi ✅");

                dataGridView1.DataSource = memberService.GetAllMembers();
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

                selectedMemberId = Convert.ToInt32(row.Cells["MemberId"].Value);

                txtAd.Text = row.Cells["Name"].Value.ToString();
                txtSoyad.Text = row.Cells["Surname"].Value.ToString();
                txtTelefon.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Lütfen silinecek üyeyi seçin");
                return;
            }

            memberService.DeleteMember(selectedMemberId);

            MessageBox.Show("Üye silindi");

            dataGridView1.DataSource = memberService.GetAllMembers();
        }

        private void btnUyeYonetimi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Butona tıklandı");

            MemberForm memberForm = new MemberForm();
            memberForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BorrowForm borrowForm = new BorrowForm();
            borrowForm.Show();
            this.Hide();
        }
    }
}
