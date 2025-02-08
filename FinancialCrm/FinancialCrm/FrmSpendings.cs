using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSpendingsPrint_Click(object sender, EventArgs e)
        {
            var values = db.Spendings.Select(sp => new
            {
                sp.SpendingId,
                sp.SpendingTitle,
                sp.SpendingAmount,
                sp.SpendingDate,
                sp.CategoryId
            }).ToList();

            dataGridView1.DataSource = values;
        }

 
        private void btnRemoveSpendings_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingsId.Text);
            var removeValue = db.Spendings.Find(id);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();

            MessageBox.Show("Fatura Başarılı Bir Şekilde Sistemden Silindi");

            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories ctg = new FrmCategories();
            ctg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks banks = new FrmBanks();
            banks.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
           
            FrmBilling bill = new FrmBilling();
            bill.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankProcesses fbp = new FrmBankProcesses();
            fbp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();
            this.Hide();
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
