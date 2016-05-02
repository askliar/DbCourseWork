using System.Windows.Forms;

namespace DBCourseWork
{
    public partial class DebitItemForm : Form
    {
        private readonly ApplicationDbContext _context;

        public DebitItemForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}