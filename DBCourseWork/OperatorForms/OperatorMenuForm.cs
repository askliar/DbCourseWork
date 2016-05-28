using System;
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
            Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            Close();
        }

        private void sellLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new SellingPageForm(_context, _userRole);
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}