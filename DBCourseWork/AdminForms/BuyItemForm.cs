using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.AdminForms
{
    public partial class BuyItemForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;

        public BuyItemForm(ApplicationDbContext context, UserRole user)
        {
            _context = context;
            _userRole = user;
            InitializeComponent();
            var goods = _context.Goods.ToList();
            var books = _context.Books.ToList();
            foreach (var good in goods)
            {
                itemsCombobox.Items.Add(
                     $"{good.GoodName}");
            }
            foreach (var book in books)
            {
                itemsCombobox.Items.Add(
                    $"{book.Name} :-: {book.Author} :-: {book.Year} :-: {book.ISBN}");
            }
            var entityContractors = _context.EntityContrs.ToList();
            var individContractors = _context.IndividContrs.ToList();
            foreach (var individContractor in individContractors)
            {
                contrCombobox.Items.Add(
                    $"{individContractor.Contractor.ContrName} :-: {individContractor.Contractor.Address} :-: {individContractor.Birthday.ToString("dd/MM/yyyy")}");
            }
            foreach (var entityContractor in entityContractors)
            {
                contrCombobox.Items.Add(
                    $"{entityContractor.Contractor.ContrName} :-: {entityContractor.Contractor.Address} :-: {entityContractor.StateNumber}");
            }
            contrCombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            contrCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            itemsCombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            itemsCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GoodsMove goodsMove;
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                var quantity = int.Parse(qunatityTxt.Text);
                if (quantity <= 0)
                {
                    throw new Exception("Перевірте правильність введеної кількості!");
                }
                var contractorData = contrCombobox.SelectedItem as string;
                if (contractorData == null)
                {
                    throw new Exception("Оберіть контрагента!");
                }
                var itemName = itemsCombobox.SelectedItem as string;
                if (itemName == null)
                {
                    throw new Exception("Оберіть товар!");
                }
                var firstItemIndex = itemName.IndexOf(" :-: ", StringComparison.Ordinal);
                if (firstItemIndex == -1)
                {
                    var item = _context.Goods.FirstOrDefault(good => good.GoodName == itemName);
                    if (item != null)
                    {
                        goodsMove = new GoodsMove
                        {
                            Good = item,
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
                    var firstBookIndex = itemName.IndexOf(" :-: ", StringComparison.Ordinal);
                    var lastBookIndex = itemName.LastIndexOf(" :-: ", StringComparison.Ordinal);
                    var bookName = itemName.Substring(0, firstBookIndex);
                    var bookIsbn = itemName.Substring(lastBookIndex + 5);
                    var book = _context.Books.FirstOrDefault(book1 => book1.ISBN == bookIsbn && book1.Name == bookName);
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
                        throw new Exception("Такої книги не існує!");
                    }
                }
                var firstIndex = contractorData.IndexOf(" :-: ", StringComparison.Ordinal);
                var lastIndex = contractorData.LastIndexOf(" :-: ", StringComparison.Ordinal);
                var contractorName = contractorData.Substring(0, firstIndex);
                var contractorAddress = contractorData.Substring(firstIndex + 5, lastIndex - firstIndex - 5);
                var contractorDetails = contractorData.Substring(lastIndex + 5);
                DateTime date;
                if (DateTime.TryParse(contractorDetails, out date))
                {
                    var individContr =
                        _context.IndividContrs.FirstOrDefault(
                            contr =>
                                contr.Contractor.ContrName == contractorName &&
                                contr.Contractor.Address == contractorAddress && contr.Birthday == date);
                    if (individContr != null)
                    {
                        var documentation = new Documentation
                        {
                            Contractor = individContr.Contractor,
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
                    else
                    {
                        throw new Exception("Такого контрагента не існує!");
                    }
                }
                else
                {
                    var contractor =
                        _context.Contractors.FirstOrDefault(
                            contr =>
                                contr.ContrName == contractorName && contr.Address == contractorAddress);
                    var entityContr =
                        _context.EntityContrs.FirstOrDefault(
                            contr => contr.Contractor == contractor && contr.StateNumber == contractorDetails);
                    if (entityContr != null)
                    {
                        var documentation = new Documentation
                        {
                            Contractor = entityContr.Contractor,
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
            }
            catch (Exception ex)
            {
                Utilities.ClearSpace(this);
                MessageBox.Show(ex.Message);
            }
        }
    }
}