using System.Linq;
using System.Windows.Forms;

namespace DBCourseWork
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
            //var form = new Register
            //Hide();
            //form.Closed += (s, args) => Close();
            //form.Show();
        }

        private void itemLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new DebitItemForm(_context);
            Hide();
            form.Closed += (s, args) => Close();
            form.Show();
        }

        private void goodsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new BuyItemForm(_context);
            Hide();
            form.Closed += (s, args) => Close();
            form.Show();
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}