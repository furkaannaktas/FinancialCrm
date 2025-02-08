using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " ₺ ";

            var lastBankProcessAmount = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + " ₺ ";

            //chart1 kodları
            var bankData = db.Banks.Select(x => new
            {
               x.BankTitle,
               x.BankBalance,
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Bankalar");
            foreach(var item in bankData)
            {
              series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //chart2 kodları
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount,
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void txtTotalBalance_Click(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 5 == 1)
            {
               var elektrikFaturasi = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = elektrikFaturasi.ToString() + " ₺ ";
            }
            if (count % 5 == 2)
            {
                var dogalgazFaturasi = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = dogalgazFaturasi.ToString() + " ₺ ";
            }
            if (count % 5 == 3)
            {
                var suFaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = suFaturasi.ToString() + " ₺ ";
            }
            if (count % 5 == 4)
            {
                var internetFaturasi = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = internetFaturasi.ToString() + " ₺ ";
            }
            if (count % 5 == 0)
            {
                var telefonFaturasi = db.Bills.Where(x => x.BillTitle == "Telefon Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Telefon Faturası";
                lblBillAmount.Text = telefonFaturasi.ToString() + " ₺ ";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)  /*KATEGORİLER*/
        {
            FrmCategories ctg = new FrmCategories();
            ctg.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) /* BANKALAR*/
        {
           FrmBanks banks = new FrmBanks();
            banks.ShowDialog();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?",
                                          "Çıkış Onayı",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void button7_Click(object sender, EventArgs e)  /*AYARLAR*/
        {
            FrmSettings stg = new FrmSettings();
            stg.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)  /*FATURALAR*/
        {
            FrmSpendings spd = new FrmSpendings();
            spd.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankProcesses fbp = new FrmBankProcesses();
            fbp.Show();
            this.Hide();
        }
    }
}
