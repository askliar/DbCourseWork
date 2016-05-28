using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.AdminForms
{
    public partial class AddItemForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;

        public AddItemForm(ApplicationDbContext context, UserRole user)
        {
            _userRole = user;
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
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                if (!double.TryParse(priceTxt.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out price) || !int.TryParse(termTxt.Text, out term))
                {
                    throw new Exception("Перевірте правильність введених ціни та строку придатності!");
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
                    _context.Documentations.Add(new Documentation
                    {
                        Stuff = stuff,
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterItem")
                        
                    });
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else if (otherRadio.Checked)
                {
                    _context.Goods.Add(good);
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else
                {
                   throw new Exception("Оберіть тип товару!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
