using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.ReDesign
{
    public partial class AddItemForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;
        private dynamic _books;
        private dynamic _goods;

        public AddItemForm(ApplicationDbContext context, UserRole user)
        {
            _userRole = user;
            _context = context;
            _books = _context.Books.Select(book => new { book.Name, book.Author, book.Year, ISBN = book.Isbn }).ToList();
            _goods = _context.Goods.Select(good => new { good.GoodName, good.Term, good.Price }).Where(arg => arg.GoodName != "Book").ToList();
            InitializeComponent();
            otherRadio.Checked = true;
            authorTxt.Enabled = bookRadio.Checked;
            nameTxt.Enabled = bookRadio.Checked;
            publishTxt.Enabled = bookRadio.Checked;
            isbnTxt.Enabled = bookRadio.Checked;
            dataGridView1.DataSource = _goods;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            if (bookRadio.Checked)
            {
                dataGridView1.DataSource = _books;
            }
            if (otherRadio.Checked)
            {
                dataGridView1.DataSource = _goods;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double price;
                int term;
                Book book = null;
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
                var matchingGood = _context.Goods.FirstOrDefault(x => x.GoodName == good.GoodName && Math.Abs(x.Price - good.Price) < 0.00000001 && x.Term == good.Term);
                if (matchingGood != null && !bookRadio.Checked)
                {
                    throw new Exception("Такий товар вже існує в системі!");
                }
                if (bookRadio.Checked)
                {
                    int year;
                    if (!int.TryParse(publishTxt.Text, out year))
                    {
                        throw new Exception("Перевірте правильність введенего року видання!");
                    }
                    if (matchingGood != null)
                    {
                        book = new Book
                        {
                            Good = matchingGood,
                            Author = authorTxt.Text,
                            Isbn = isbnTxt.Text,
                            Name = nameTxt.Text,
                            Year = year
                        };
                    }
                    else
                    {
                        book = new Book
                        {
                            Good = good,
                            Author = authorTxt.Text,
                            Isbn = isbnTxt.Text,
                            Name = nameTxt.Text,
                            Year = year
                        };
                    }
                }
                if (bookRadio.Checked)
                {
                    _context.Books.Add(book);
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else if (otherRadio.Checked)
                {
                    _context.Goods.Add(good);

                }
                else
                {
                    throw new Exception("Оберіть тип товару!");
                }
                _context.Documentations.Add(new Documentation
                {
                    Stuff = stuff,
                    DocDate = DateTime.Now,
                    DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterItem")
                });
                _context.SaveChanges();
                MessageBox.Show(@"Дані були успішно збережені!");
                Utilities.ClearSpace(this);
                _books = _context.Books.Select(book1 => new { book1.Name, book1.Author, book1.Year, ISBN = book1.Isbn }).ToList();
                _goods = _context.Goods.Select(good1 => new { good1.GoodName, good1.Term, good1.Price }).Where(arg => arg.GoodName != "Book").ToList();
                otherRadio_CheckedChanged(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
