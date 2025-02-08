using FinancialCrm.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;

            // Spendings sütununu gizle
            if (dataGridView1.Columns["Spendings"] != null)
            {
                dataGridView1.Columns["Spendings"].Visible = false;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;

            // Spendings sütununu tekrar gizle
            if (dataGridView1.Columns["Spendings"] != null)
            {
                dataGridView1.Columns["Spendings"].Visible = false;
            }
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            Categories ctg = new Categories();
            ctg.CategoryName = name;
            db.Categories.Add(ctg);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sisteme Eklendi");

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();

            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemden Silindi");

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);
            var values = db.Categories.Find(id);
            values.CategoryName = name;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemde Güncellendi");

            var values2 = db.Categories.ToList();
            dataGridView1.DataSource = values2;
        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankProcesses fbp = new FrmBankProcesses();
            fbp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.StartPosition = FormStartPosition.Manual;
            dashboard.Location = this.Location; // Formun aynı konumda açılmasını sağlar
            dashboard.Size = this.Size; // Aynı boyutta açılmasını sağlar
            dashboard.Show();
            this.Hide(); ;
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