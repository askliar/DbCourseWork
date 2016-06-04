using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.ReDesign
{
    public partial class BuyItemForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;
        private readonly dynamic _books;
        private readonly dynamic _goods;
        private readonly EntityContr _entityContr;
        private readonly IndividContr _individContr;

        public BuyItemForm(ApplicationDbContext context, UserRole user, EntityContr entity = null, IndividContr individContr = null)
        {
            _userRole = user;
            _context = context;
            _books = _context.Books.Select(book => new { book.Name, book.Author, book.Year, ISBN = book.Isbn }).ToList();
            _goods = _context.Goods.Select(good => new { good.GoodName, good.Term, good.Price }).Where(arg => arg.GoodName != "Book").ToList();
            _entityContr = entity;
            _individContr = individContr;
            InitializeComponent();
            otherRadio.Checked = true;
            dataGridView1.DataSource = _goods;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                var dataGridViewColumn = dataGridView1.Columns[column.Name];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GoodsMove goodsMove;
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                int quantity;
                var result = int.TryParse(quantityTxt.Text, out quantity);
                if (!result)
                {
                    throw new Exception("Перевірте правильність введеної кількості!");
                }
                if (quantity <= 0)
                {
                    throw new Exception("Перевірте правильність введеної кількості!");
                }
                var selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow == null)
                {
                    throw new Exception("Оберіть товар!");
                }
                if (bookRadio.Checked)
                {
                    var bookName = selectedRow.Cells[0].Value.ToString();
                    var author = selectedRow.Cells[1].Value.ToString();
                    var year = int.Parse(selectedRow.Cells[2].Value.ToString());
                    var isbn = selectedRow.Cells[3].Value.ToString();
                    var book =
                        _context.Books.FirstOrDefault(
                            book1 =>
                                book1.Name == bookName && book1.Author == author && book1.Isbn == isbn &&
                                book1.Year == year);
                    var good = _context.Goods.FirstOrDefault(good1 => good1.Books.Contains(book));
                    if (book != null)
                    {
                        goodsMove = new GoodsMove
                        {
                            Good = good,
                            MoveType = "Buy",
                            Quantity = quantity
                        };
                    }
                    else
                    {
                        throw new Exception("Такого товару не існує! Спочатку додайте його в систему!");
                    }
                }
                else
                {
                    var goodName = selectedRow.Cells[0].Value.ToString();
                    var goodTerm = int.Parse(selectedRow.Cells[1].Value.ToString());
                    var goodPrice = double.Parse(selectedRow.Cells[2].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
                    var good =
                        _context.Goods.FirstOrDefault(
                            good1 => good1.GoodName == goodName && good1.Term == goodTerm && Math.Abs(good1.Price - goodPrice) < 0.000001);
                    if (good != null)
                    {
                        goodsMove = new GoodsMove
                        {
                            Good = good,
                            MoveType = "Buy",
                            Quantity = quantity
                        };
                    }
                    else
                    {
                        throw new Exception("Такого товару не існує! Спочатку додайте його в систему!");
                    }
                }
                if (_individContr != null)
                {
                    var documentation = new Documentation
                    {
                        Contractor = _individContr.Contractor,
                        Stuff = stuff,
                        GoodsMoves = new List<GoodsMove> { goodsMove },
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "Buy")
                    };
                    _context.Documentations.Add(documentation);
                    goodsMove.Documentation = documentation;
                    _context.GoodsMoves.Add(goodsMove);
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else if (_entityContr != null)
                {
                    var documentation = new Documentation
                    {
                        Contractor = _entityContr.Contractor,
                        Stuff = stuff,
                        GoodsMoves = new List<GoodsMove> { goodsMove },
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "Buy")
                    };
                    _context.Documentations.Add(documentation);
                    goodsMove.Documentation = documentation;
                    _context.GoodsMoves.Add(goodsMove);
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else
                {
                    throw new Exception("Такого контрагента не існує!");
                }
            }
            catch (Exception ex)
            {
                Utilities.ClearSpace(this);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bookRadio_CheckedChanged_1(object sender, EventArgs e)
        {
            otherRadio.Checked = !bookRadio.Checked;
        }

        private void otherRadio_CheckedChanged_1(object sender, EventArgs e)
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
    }
}
