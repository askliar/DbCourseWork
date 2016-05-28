using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.AdminForms
{
    public partial class DebitItemForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;

        public DebitItemForm(ApplicationDbContext context, UserRole user)
        {
            _context = context;
            _userRole = user;
            InitializeComponent();
            var availableGoods = context.GoodInfoes.Where(x => x.Quantity > 0).ToList();
            foreach (var availableGood in availableGoods)
            {
                itemsCombobox.Items.Add(
                    availableGood.ISBN != null
                        ? $"{availableGood.Name} :-: {availableGood.Author} :-: {availableGood.Year} :-: {availableGood.ISBN}"
                        : $"{availableGood.GoodName}");
            }

            contrCombobox.Enabled = false;
            contrCombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            contrCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            itemsCombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            itemsCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GoodsMove goodsMove;
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                var quantity = int.Parse(quantityTxt.Text);
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
                        var quant = _context.GoodInfoes.First(x => x.IdGoods == item.IdGoods).Quantity;
                        if (quantity <= 0 || quantity > quant)
                        {
                            throw new Exception("Перевірте введену кількість! Можливо, такої кількості товару вже немає!");
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
                    var firstBookIndex = itemName.IndexOf(" :-: ", StringComparison.Ordinal);
                    var lastBookIndex = itemName.LastIndexOf(" :-: ", StringComparison.Ordinal);
                    var bookName = itemName.Substring(0, firstBookIndex);
                    var bookIsbn = itemName.Substring(lastBookIndex + 5);
                    var book = _context.Books.FirstOrDefault(book1 => book1.ISBN == bookIsbn && book1.Name == bookName);
                    var good = _context.Goods.FirstOrDefault(good1 => good1.Books.Contains(book));
                    if (book != null)
                    {
                        var quant = _context.GoodInfoes.First(x => x.IdGoods == book.IdGoods).Quantity;
                        if (quantity <= 0 || quantity <= quant)
                        {
                            throw new Exception("Перевірте введену кількість! Можливо, такої кількості товару вже немає!");
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
                            DocType = _context.DocTypes.First(type => type.Doctype1 == "Debit")
                        };
                        _context.Documentations.Add(documentation);
                        goodsMove.Documentation = documentation;
                        _context.GoodsMoves.Add(goodsMove);
                        MessageBox.Show(@"Changes saved succesfully!");
                        Utilities.ClearSpace(this);
                    }
                    else
                    {
                        throw new Exception("Такого контрагента не існує!");
                    }
                }
                else
                {
                    var entityContr =
                        _context.EntityContrs.FirstOrDefault(
                            contr => contr.Contractor.ContrName == contractorName && contr.Contractor.Address == contractorAddress && contr.StateNumber == contractorDetails);
                    if (entityContr != null)
                    {
                        var documentation = new Documentation
                        {
                            Contractor = entityContr.Contractor,
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

        private void itemsCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
                        contrCombobox.Enabled = true;
                        var correctRows =
                            _context.GoodInfoes.Where(info => info.GoodName == item.GoodName && info.Quantity > 0)
                                .ToList();
                        foreach (var correctRow in correctRows)
                        {
                            var entityContractors =
                                _context.EntityContrs.Where(
                                    ent =>
                                        ent.Contractor.ContrName == correctRow.ContrName &&
                                        ent.Contractor.Address == correctRow.Address &&
                                        ent.Contractor.Phone == correctRow.Phone).ToList();
                            var individContractors =
                                _context.IndividContrs.Where(
                                    ent =>
                                        ent.Contractor.ContrName == correctRow.ContrName &&
                                        ent.Contractor.Address == correctRow.Address &&
                                        ent.Contractor.Phone == correctRow.Phone).ToList();
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
                        }
                    }
                    else
                    {
                        throw new Exception("Такого товару не існує!");
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
                        contrCombobox.Enabled = true;
                        var correctRows =
                            _context.GoodInfoes.Where(
                                item =>
                                    item.Name == book.Name && item.Author == book.Author && item.ISBN == book.ISBN &&
                                    item.Year == book.Year).ToList();
                        foreach (var correctRow in correctRows)
                        {
                            var entityContractors =
                                _context.EntityContrs.Where(
                                    ent =>
                                        ent.Contractor.ContrName == correctRow.ContrName &&
                                        ent.Contractor.Address == correctRow.Address &&
                                        ent.Contractor.Phone == correctRow.Phone).ToList();
                            var individContractors =
                                _context.IndividContrs.Where(
                                    ent =>
                                        ent.Contractor.ContrName == correctRow.ContrName &&
                                        ent.Contractor.Address == correctRow.Address &&
                                        ent.Contractor.Phone == correctRow.Phone).ToList();
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
                        }
                    }
                    else
                    {
                        throw new Exception("Такої книги не існує!");
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