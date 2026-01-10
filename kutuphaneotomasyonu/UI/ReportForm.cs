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

namespace kutuphaneotomasyonu.UI
{
    public partial class ReportForm : Form
    {
        ReportService reportService = new ReportService();
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Add("Tüm Ödünçler");
            cmbReportType.Items.Add("İade Edilmemiş Kitaplar");
            cmbReportType.Items.Add("En Çok Okunan Kitaplar");

            cmbReportType.SelectedIndex = 0;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string selectedReport = cmbReportType.SelectedItem.ToString();

            if (selectedReport == "Tüm Ödünçler")
                dataGridViewReport.DataSource = reportService.GetAllBorrows();
            else if (selectedReport == "İade Edilmemiş Kitaplar")
                dataGridViewReport.DataSource = reportService.GetNotReturnedBorrows();
            else if (selectedReport == "En Çok Okunan Kitaplar")
                dataGridViewReport.DataSource = reportService.GetMostReadBooks();
        }
    }
}
