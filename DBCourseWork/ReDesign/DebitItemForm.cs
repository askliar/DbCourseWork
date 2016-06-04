using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.ReDesign
{
    public partial class DebitItemForm : Form
    {
        private readonly UserRole _userRole;
        private readonly ApplicationDbContext _context;
        private readonly EntityContr _entityContr;
        private readonly IndividContr _individContr;


        public DebitItemForm(ApplicationDbContext context, UserRole user, EntityContr entity = null, IndividContr individContr = null)
        {
            _userRole = user;
            _context = context;
            InitializeComponent();
            _entityContr = entity;
            _individContr = individContr;
            if (_entityContr != null)
            {
                var availableGoods =
                    _context.GoodInfoes.Where(
                        x =>
                            x.Quantity > 0 && x.ContrName == _entityContr.Contractor.ContrName &&
                            x.Address == _entityContr.Contractor.Address && x.Phone == _entityContr.Contractor.Phone)
                        .Select(info => new { info.GoodName, info.Quantity, info.Name, info.Author, ISBN = info.Isbn, info.Year })
                        .ToList();
                dataGridView1.DataSource = availableGoods;
            }
            else
            {
                var availableGoods =
                    _context.GoodInfoes.Where(
                        x =>
                            x.Quantity > 0 && x.ContrName == _individContr.Contractor.ContrName &&
                            x.Address == _individContr.Contractor.Address && x.Phone == _individContr.Contractor.Phone)
                        .Select(info => new { info.GoodName, info.Quantity, info.Name, info.Author, ISBN = info.Isbn, info.Year })
                        .ToList();
                dataGridView1.DataSource = availableGoods;
            }
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
                if (result == false)
                {
                    throw new Exception("Перевірте введену кількість! Можливо, ви ввели не число!");
                }
                var selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow == null)
                {
                    throw new Exception("Оберіть рядок з товаром!");
                }
                var bookNameValue = selectedRow.Cells[2].Value;
                if (bookNameValue == null)
                {
                    var itemName = selectedRow.Cells[0].Value.ToString();
                    var item = _context.Goods.FirstOrDefault(good => good.GoodName == itemName);
                    if (item != null)
                    {
                        var quant = _context.GoodInfoes.First(x => x.IdGoods == item.IdGoods).Quantity;
                        if (quantity <= 0 || quantity > quant)
                        {
                            throw new Exception(
                                "Перевірте введену кількість! Можливо, такої кількості товару вже немає!");
                        }
                        goodsMove = new GoodsMove
                        {
                            Good = item,
                            MoveType = "Debit",
                            Quantity = -quantity
                        };
                    }
                    else
                    {
                        throw new Exception("Такого товару не існує!");
                    }
                }
                else
                {
                    var bookName = bookNameValue.ToString();
                    var bookIsbn = selectedRow.Cells[4].Value.ToString();
                    var book = _context.Books.FirstOrDefault(book1 => book1.Isbn == bookIsbn && book1.Name == bookName);
                    var good = _context.Goods.FirstOrDefault(good1 => good1.Books.Contains(book));
                    if (book != null)
                    {
                        var quant = _context.GoodInfoes.First(x => x.IdGoods == book.IdGoods).Quantity;
                        if (quantity <= 0 || quantity <= quant)
                        {
                            throw new Exception(
                                "Перевірте введену кількість! Можливо, такої кількості товару вже немає!");
                        }
                        goodsMove = new GoodsMove
                        {
                            Good = good,
                            MoveType = "Debit",
                            Quantity = -quantity
                        };
                    }
                    else
                    {
                        throw new Exception("Такої книги не існує!");
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
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "Debit")
                    };
                    _context.Documentations.Add(documentation);
                    goodsMove.Documentation = documentation;
                    _context.GoodsMoves.Add(goodsMove);
                    var availableGoods =
                        _context.GoodInfoes.Where(
                            x =>
                                x.Quantity > 0 && x.ContrName == _individContr.Contractor.ContrName &&
                                x.Address == _individContr.Contractor.Address &&
                                x.Phone == _individContr.Contractor.Phone)
                            .Select(
                                info => new { info.GoodName, info.Quantity, info.Name, info.Author, ISBN = info.Isbn, info.Year })
                            .ToList();
                    dataGridView1.DataSource = availableGoods;
                    dataGridView1.Update();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else
                {
                    var documentation = new Documentation
                    {
                        Contractor = _entityContr.Contractor,
                        Stuff = stuff,
                        GoodsMoves = new List<GoodsMove> { goodsMove },
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "Debit")
                    };
                    goodsMove.Documentation = documentation;
                    _context.GoodsMoves.Add(goodsMove);
                    _context.Documentations.Add(documentation);
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                    var availableGoods =
                        _context.GoodInfoes.Where(
                            x =>
                                x.Quantity > 0 && x.ContrName == _entityContr.Contractor.ContrName &&
                                x.Address == _entityContr.Contractor.Address && x.Phone == _entityContr.Contractor.Phone)
                            .Select(
                                info => new { info.GoodName, info.Quantity, info.Name, info.Author, ISBN = info.Isbn, info.Year })
                            .ToList();
                    dataGridView1.DataSource = availableGoods;
                    dataGridView1.Update();
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
    }
}
