using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.OperatorForms
{
    public partial class SellingPageForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;

        public SellingPageForm(ApplicationDbContext context, UserRole user)
        {
            InitializeComponent();
            _context = context;
            _userRole = user;
            quantityTxt.Text = 1.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int itemId;
                int quant;
                if (!int.TryParse(itemstxt.Text, out itemId))
                {
                    throw new Exception("Перевірте введений код товару!");
                }
                if (!int.TryParse(quantityTxt.Text, out quant))
                {
                    throw new Exception("Перевірте введену кількість товару!");
                }

                var availableItem =
                    _context.GoodInfoes.FirstOrDefault(info => info.IdGoods == itemId && info.Quantity >= quant);
                if (availableItem == null)
                {
                    throw new Exception(
                        "Перевірте введений код товару! Такого товару або не існує в системі, або ж немає такої кількості товару.");
                }
                dataGridView1.Rows.Add(itemId, availableItem.Price, availableItem.Isbn != null
                    ? $"{availableItem.Name} :-: {availableItem.Author} :-: {availableItem.Year} :-: {availableItem.Isbn}"
                    : $"{availableItem.GoodName}", quant);
                Utilities.ClearSpace(this);
                quantityTxt.Text = 1.ToString();
            }
            catch (Exception ex)
            {
                Utilities.ClearSpace(this);
                quantityTxt.Text = 1.ToString();
                MessageBox.Show(ex.Message);
            }

        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int cardId;
                Card card = null;
                var price = 0.0;
                Contractor contractor = null;
                if (actiontxt.Text != String.Empty && !int.TryParse(actiontxt.Text, out cardId))
                {
                    throw new Exception("Перевірте введений код картки!");
                }
                if (actiontxt.Text != string.Empty)
                {
                    if (!int.TryParse(actiontxt.Text, out cardId))
                    {
                        throw new Exception("Перевірте введений код картки!");
                    }
                    card = _context.Cards.FirstOrDefault(x => x.IdCard == cardId);
                    if (card == null || card.Action.DayStop < DateTime.Now)
                    {
                        throw new Exception(
                            "Перевірте введений код картки! Такої картки або не існує, або строк її дії закінчився!");
                    }
                    contractor = _context.Contractors.First(contractor1 => contractor1.Card == card);

                }
                var listGoodsMoves = new List<GoodsMove>();
                Documentation documentation = null;
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    documentation = new Documentation
                    {
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(x => x.Doctype1 == "Sell"),
                        Contractor = contractor,
                        Stuff = stuff
                    };
                    var id = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    var quant = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    listGoodsMoves.Add(new GoodsMove
                    {
                        Quantity = -quant,
                        Documentation = documentation,
                        MoveType = "Sell",
                        Good = _context.Goods.First(x => x.IdGoods == id)
                    });
                    price += double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), NumberStyles.Any,
                        CultureInfo.InvariantCulture) * int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                if (documentation != null)
                {
                    _context.Documentations.Add(documentation);
                }
                _context.GoodsMoves.AddRange(listGoodsMoves);
                _context.SaveChanges();
                if (card?.Action.Percents != null) price = price * (double)card.Action.Percents;
                totalPrice_lbl.Text = $"Загальна Ціна: {price} грн.";
                MessageBox.Show(@"Дані були успішно збережені!");
                Utilities.ClearSpace(this);
                quantityTxt.Text = 1.ToString();
            }
            catch (Exception ex)
            {
                Utilities.ClearSpace(this);
                quantityTxt.Text = 1.ToString();
                MessageBox.Show(ex.Message);
            }
        }
    }
}