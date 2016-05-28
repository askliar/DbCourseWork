using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.OperatorForms
{
    public partial class SellerMenuForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;

        public SellerMenuForm(ApplicationDbContext context, UserRole user)
        {
            _context = context;
            _userRole = user;
            InitializeComponent();
        }

        private void cardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddActionForm(_context, _userRole);
            Hide();
            form.ShowDialog();
            this.Show();
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}