using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.AdminForms
{
    public partial class AddItemForm : Form
    {
        private readonly ApplicationDbContext _context;

        public AddItemForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
            otherRadio.Checked = true;
            authorTxt.Enabled = bookRadio.Checked;
            nameTxt.Enabled = bookRadio.Checked;
            publishTxt.Enabled = bookRadio.Checked;
            isbnTxt.Enabled = bookRadio.Checked;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bookRadio_CheckedChanged(object sender, EventArgs e)
        {
            otherRadio.Checked = !bookRadio.Checked;
            authorTxt.Enabled = bookRadio.Checked;
            nameTxt.Enabled = bookRadio.Checked;
            publishTxt.Enabled = bookRadio.Checked;
            isbnTxt.Enabled = bookRadio.Checked;
        }

        private void otherRadio_CheckedChanged(object sender, EventArgs e)
        {
            bookRadio.Checked = !otherRadio.Checked;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double price;
                int term;
                if (!double.TryParse(priceTxt.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out price) || !int.TryParse(termTxt.Text, out term))
                {
                    throw new Exception();
                }
                var good = new Good
                {
                    GoodName = itemNameTxt.Text,
                    Price = price,
                    Term = term
                };
                if (bookRadio.Checked)
                {
                    int year;
                    if (!int.TryParse(publishTxt.Text, out year))
                    {
                        throw new Exception();
                    }
                    var book = new Book
                    {
                        Good = good,
                        Author = authorTxt.Text,
                        ISBN = isbnTxt.Text,
                        Name = nameTxt.Text,
                        Year = year
                    };
                    _context.Books.Add(book);
                    _context.SaveChanges();
                    MessageBox.Show(@"Changes saved succesfully!");
                    Utilities.ClearSpace(this);
                }
                else if (otherRadio.Checked)
                {
                    _context.Goods.Add(good);
                    _context.SaveChanges();
                    MessageBox.Show(@"Changes saved succesfully!");
                    Utilities.ClearSpace(this);
                }
                else
                {
                    MessageBox.Show(@"Choose the type of item!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Check the entered information!");
                throw;
            }
        }
    }
}
