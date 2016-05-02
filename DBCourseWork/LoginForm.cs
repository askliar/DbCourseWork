using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DBCourseWork
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var login = logintxt.Text;
                var pass = passtxt.Text;
                using (var context = new ApplicationDbContext())
                {
                    var user = context.UserRoles.FirstOrDefault(roles => roles.Login == login && roles.Password == pass);
                    if (user == null)
                        throw new Exception("There is no such user!");
                    if (user.Role == "admin" || user.Role == "operator")
                    {
                        if (user.Role == "admin")
                        {
                            var form =
                                new AdminMenuForm(
                                    new ApplicationDbContext(Utilities.ConnectionStringBuilder("admin", "admin")));
                            Hide();
                            form.Closed += (s, args) => Close();
                            form.Show();
                        }
                        if (user.Role == "operator")
                        {
                            var form =
                                new SellerMenuForm(
                                    new ApplicationDbContext(Utilities.ConnectionStringBuilder("operator", "operator")));
                            Hide();
                            form.Closed += (s, args) => Close();
                            form.Show();
                        }
                    }
                    else
                    {
                        throw new Exception("The user role is wrong!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    @"Error ocurred during connection! Check your login and password or contact your administrator!");
                throw;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}