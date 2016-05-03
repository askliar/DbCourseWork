using System.Windows.Forms;

namespace DBCourseWork.AdminForms
{
    public partial class AdminMenuForm : Form
    {
        private readonly ApplicationDbContext _context;

        public AdminMenuForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void contrLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddContractorForm(_context);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void itemLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddItemForm(_context);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new DebitItemForm(_context);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void goodsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new BuyItemForm(_context);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            _context.Dispose();
            Close();
        }
    }
}