using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DBCourseWork
{
    public static class Utilities
    {
        public static string ConnectionStringBuilder(string userId, string password)
        {
            var connStr = new SqlConnectionStringBuilder
            {
                ApplicationName = "DBCourseWork",
                Password = password,
                UserID = userId,
                MultipleActiveResultSets = true,
                DataSource = "ANDREW-ON-FIRE",
                InitialCatalog = "BookStoreDb",
                IntegratedSecurity = true
            };
            return connStr.ConnectionString;
        }

        public static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextBox;
                var comboBox = c as ComboBox;

                textBox?.Clear();

                if (comboBox != null)
                    comboBox.SelectedIndex = -1;

                if (c.HasChildren)
                    ClearSpace(c);
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;
            var r = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            return r.IsMatch(phone);
        }
    }
}