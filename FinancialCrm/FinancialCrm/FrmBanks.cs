using FinancialCrm.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmBanks_Load(object sender, EventArgs e)
        {

            //Banka Bakiyeleri

            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var isBankasiBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var qnbFinansbankBalance = db.Banks.Where(x => x.BankTitle == "QNB Finansbank").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + "₺";
            lblisBankBalance.Text = isBankasiBalance.ToString() + "₺";
            lblQnbFinansbankBalance.Text = qnbFinansbankBalance.ToString() + "₺";

            //Banka Hareketleri
            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = $"📅 Tarih: {bankProcess1.ProcessDate.Value.ToString("dd.MM.yyyy")}  🔄 İşlem Tipi: {bankProcess1.ProcessType}  📝 Açıklama: {bankProcess1.Description}  💵 Tutar: {bankProcess1.Amount:N2} ₺";

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = $"📅 Tarih: {bankProcess2.ProcessDate.Value.ToString("dd.MM.yyyy")}  🔄 İşlem Tipi: {bankProcess2.ProcessType}  📝 Açıklama: {bankProcess2.Description}  💵 Tutar: {bankProcess2.Amount:N2} ₺";

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = $"📅 Tarih: {bankProcess3.ProcessDate.Value.ToString("dd.MM.yyyy")}  🔄 İşlem Tipi: {bankProcess3.ProcessType}  📝 Açıklama: {bankProcess3.Description}  💵 Tutar: {bankProcess3.Amount:N2} ₺";

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = $"📅 Tarih: {bankProcess4.ProcessDate.Value.ToString("dd.MM.yyyy")}  🔄 İşlem Tipi: {bankProcess4.ProcessType}  📝 Açıklama: {bankProcess4.Description}  💵 Tutar: {bankProcess4.Amount:N2} ₺";

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = $"📅 Tarih: {bankProcess5.ProcessDate.Value.ToString("dd.MM.yyyy")}  🔄 İşlem Tipi: {bankProcess5.ProcessType}  📝 Açıklama: {bankProcess5.Description}  💵 Tutar: {bankProcess5.Amount:N2} ₺";
        }

        private void lblQnbFinansbankBalance_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)   /*FATURALAR*/
        {
            FrmSpendings spd = new FrmSpendings();
            spd.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories ctg = new FrmCategories();
            ctg.ShowDialog();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmSpendings spd = new FrmSpendings();
            spd.Show();
            this.Hide();
        }

        private void btnBillForm_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankProcesses fbp = new FrmBankProcesses();
            fbp.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings stg = new FrmSettings();
            stg.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
