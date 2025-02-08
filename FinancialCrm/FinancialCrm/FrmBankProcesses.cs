using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinancialCrm
{
    public partial class FrmBankProcesses : Form
    {
        public FrmBankProcesses()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            var banks = db.Banks
                     .Select(b => new { b.BankId, b.BankTitle })
            .ToList();

            cmbBankProcesses.DataSource = banks;
            cmbBankProcesses.DisplayMember = "BankTitle";
            cmbBankProcesses.ValueMember = "BankId";
        }

        private void cmbBankProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cmbBankProcesses.SelectedValue != null)
            {
                int selectedBankId = Convert.ToInt32(cmbBankProcesses.SelectedValue);

                var bankProcesses = db.BankProcesses
                                          .Where(bp => bp.BankId == selectedBankId)
                                          .Select(bp => new
                                          {
                                              bp.Description,
                                              bp.ProcessDate,
                                              bp.ProcessType,
                                              bp.Amount
                                          })
                                          .ToList();

                dataGridView1.DataSource = bankProcesses;

            }
            else
            {
                MessageBox.Show("Lütfen bir banka seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)    /*GERİ DÖN*/
        {
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories ctg = new FrmCategories();
            ctg.ShowDialog();
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
            FrmSpendings spd = new FrmSpendings();
            spd.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling bill = new FrmBilling();
            bill.Show();
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
