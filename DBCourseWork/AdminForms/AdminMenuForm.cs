using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.AdminForms
{
    public partial class AdminMenuForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;

        public AdminMenuForm(ApplicationDbContext context, UserRole user)
        {
            _context = context;
            _userRole = user;
            InitializeComponent();
        }

        private void contrLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddContractorForm(_context, _userRole);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void itemLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddItemForm(_context, _userRole);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new DebitItemForm(_context, _userRole);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void goodsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new BuyItemForm(_context, _userRole);
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