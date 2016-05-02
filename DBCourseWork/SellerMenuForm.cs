using System.Linq;
using System.Windows.Forms;

namespace DBCourseWork
{
    public partial class SellerMenuForm : Form
    {
        private readonly ApplicationDbContext _context;

        public SellerMenuForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}