using System.Windows.Forms;

namespace DBCourseWork.OperatorForms
{
    public partial class SellerMenuForm : Form
    {
        private readonly ApplicationDbContext _context;

        public SellerMenuForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void cardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddActionForm(_context);
            Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}