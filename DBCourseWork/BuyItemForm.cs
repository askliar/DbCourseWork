using System.Windows.Forms;

namespace DBCourseWork
{
    public partial class BuyItemForm : Form
    {
        private readonly ApplicationDbContext _context;

        public BuyItemForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}