using System.Windows.Forms;

namespace DBCourseWork.AdminForms
{
    public partial class BuyItemForm : Form
    {
        private readonly ApplicationDbContext _context;

        public BuyItemForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}