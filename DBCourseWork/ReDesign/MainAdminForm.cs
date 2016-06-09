using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;
using FastReport;

namespace DBCourseWork.ReDesign
{
    public partial class MainAdminForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;
        private dynamic _individContrs;
        private dynamic _entityContrs;

        public MainAdminForm(ApplicationDbContext context, UserRole user)
        {
            _userRole = user;
            _context = context;
            InitializeComponent();
            entityRadio.Checked = true;
            birthDatePicker.Enabled = false;
            quantityTxt.Text = 1.ToString();
            _individContrs =
                _context.IndividContrs.Select(
                    contr =>
                        new
                        {
                            contr.Contractor.ContrName,
                            contr.Contractor.Address,
                            contr.Contractor.Phone,
                            contr.Birthday
                        }).ToList();
            _entityContrs =
                _context.EntityContrs.Select(
                    contr =>
                        new
                        {
                            contr.Contractor.ContrName,
                            contr.Contractor.Address,
                            contr.Contractor.Phone,
                            contr.StateNumber
                        }).ToList();
            dataGridView1.DataSource = _entityContrs;
            var availableGoods =
                _context.GoodInfoes
                    .Select(infos => new
                    {
                        infos.GoodName,
                        infos.Quantity,
                        infos.Price,
                        infos.Name,
                        infos.Year,
                        infos.Author,
                        ISBN = infos.Isbn,
                        infos.ContrName,
                        infos.Address,
                        infos.Phone
                    })
                    .Where(arg => arg.Quantity > 0)
                    .ToList();
            dataGridView3.DataSource = availableGoods;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                var dataGridViewColumn = dataGridView1.Columns[column.Name];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                var dataGridViewColumn = dataGridView1.Columns[column.Name];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                var dataGridViewColumn = dataGridView1.Columns[column.Name];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }


        public void RemoveText(object sender, EventArgs e)
        {
            if (phoneTxt.Text == @"Приклад: +38(067)2256943")
            {
                phoneTxt.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(phoneTxt.Text))
                phoneTxt.Text = @"Приклад: +38(067)2256943";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var birthday = birthDatePicker.Value;
                var phone = phoneTxt.Text;
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                if (birthday > DateTime.Now || birthday < DateTime.Parse("01.01.1900"))
                {
                    throw new Exception("Перевірте правильність введеного дня народження!");
                }
                if (!Utilities.IsValidPhone(phone))
                {
                    throw new Exception("Перевірте правильність введеного телефона!");
                }
                var contractor1 = new Contractor
                {
                    Phone = phone,
                    Address = addressTxt.Text,
                    ContrName = nameTxt.Text
                };
                if (entityRadio.Checked)
                {
                    var foundContr =
                        _context.EntityContrs.FirstOrDefault(contr => contr.StateNumber == registrationNumTxt.Text);
                    if (foundContr != null)
                        throw new Exception("Такий контрагент вже існує!");
                    var entityContractor = new EntityContr
                    {
                        Contractor = contractor1,
                        StateNumber = registrationNumTxt.Text
                    };
                    _context.EntityContrs.Add(entityContractor);
                    _context.Documentations.Add(new Documentation
                    {
                        Stuff = stuff,
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterContractor"),
                        Contractor = entityContractor.Contractor
                    });
                    _context.SaveChanges();
                    _individContrs =
                        _context.IndividContrs.Select(
                            contr =>
                                new
                                {
                                    contr.Contractor.ContrName,
                                    contr.Contractor.Address,
                                    contr.Contractor.Phone,
                                    contr.Birthday
                                }).ToList();
                    _entityContrs =
                        _context.EntityContrs.Select(
                            contr =>
                                new
                                {
                                    contr.Contractor.ContrName,
                                    contr.Contractor.Address,
                                    contr.Contractor.Phone,
                                    contr.StateNumber
                                }).ToList();
                    entityRadio_CheckedChanged(this, e);
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else if (individRadio.Checked)
                {
                    var individContr = new IndividContr
                    {
                        Birthday = birthday
                    };
                    _context.IndividContrs.Add(individContr);
                    _context.Documentations.Add(new Documentation
                    {
                        Stuff = stuff,
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterContractor"),
                        Contractor = contractor1
                    });
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                    _individContrs =
                        _context.IndividContrs.Select(
                            contr =>
                                new
                                {
                                    contr.Contractor.ContrName,
                                    contr.Contractor.Address,
                                    contr.Contractor.Phone,
                                    contr.Birthday
                                }).ToList();
                    _entityContrs =
                        _context.EntityContrs.Select(
                            contr =>
                                new
                                {
                                    contr.Contractor.ContrName,
                                    contr.Contractor.Address,
                                    contr.Contractor.Phone,
                                    contr.StateNumber
                                }).ToList();
                    entityRadio_CheckedChanged(this, e);
                }
                else
                {
                    throw new Exception("Оберіть тип контрагента!");
                }
            }
            catch (Exception ex)
            {
                Utilities.ClearSpace(this);
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0] == null)
                {
                    throw new Exception("Оберіть контрагента!");
                }
                var contrName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var address = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                var phone = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                if (entityRadio.Checked)
                {
                    var number = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    var entityContr =
                        _context.EntityContrs.FirstOrDefault(
                            contr =>
                                contr.StateNumber == number && contr.Contractor.ContrName == contrName &&
                                contr.Contractor.Address == address && contr.Contractor.Phone == phone);
                    var form = new AddActionForm(_context, _userRole, entityContr);
                    form.ShowDialog();
                }
                else if (individRadio.Checked)
                {
                    var birthday = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                    var individContr =
                        _context.IndividContrs.FirstOrDefault(
                            contr =>
                                contr.Birthday == birthday && contr.Contractor.ContrName == contrName &&
                                contr.Contractor.Address == address && contr.Contractor.Phone == phone);
                    var form = new AddActionForm(_context, _userRole, individContr: individContr);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitBtn_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void individRadio_CheckedChanged_1(object sender, EventArgs e)
        {
            entityRadio.Checked = !individRadio.Checked;
            birthDatePicker.Enabled = individRadio.Checked;
            registrationNumTxt.Enabled = entityRadio.Checked;
            dataGridView1.DataSource = entityRadio.Checked ? _entityContrs : _individContrs;
            dataGridView1.Refresh();
        }

        private void entityRadio_CheckedChanged(object sender, EventArgs e)
        {
            entityRadio.Checked = !individRadio.Checked;
            birthDatePicker.Enabled = individRadio.Checked;
            registrationNumTxt.Enabled = entityRadio.Checked;
            dataGridView1.DataSource = entityRadio.Checked ? _entityContrs : _individContrs;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0] == null)
                {
                    throw new Exception("Оберіть контрагента!");
                }
                var contrName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var address = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                var phone = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                if (entityRadio.Checked)
                {
                    var number = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    var entityContr =
                        _context.EntityContrs.FirstOrDefault(
                            contr =>
                                contr.StateNumber == number && contr.Contractor.ContrName == contrName &&
                                contr.Contractor.Address == address && contr.Contractor.Phone == phone);
                    var form = new DebitItemForm(_context, _userRole, entityContr);
                    form.ShowDialog();
                }
                else if (individRadio.Checked)
                {
                    var birthday = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                    var individContr =
                        _context.IndividContrs.FirstOrDefault(
                            contr =>
                                contr.Birthday == birthday && contr.Contractor.ContrName == contrName &&
                                contr.Contractor.Address == address && contr.Contractor.Phone == phone);
                    var form = new DebitItemForm(_context, _userRole, individContr: individContr);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new AddItemForm(_context, _userRole);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0] == null)
                {
                    throw new Exception("Оберіть контрагента!");
                }
                var contrName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var address = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                var phone = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                if (entityRadio.Checked)
                {
                    var number = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    var entityContr =
                        _context.EntityContrs.FirstOrDefault(
                            contr =>
                                contr.StateNumber == number && contr.Contractor.ContrName == contrName &&
                                contr.Contractor.Address == address && contr.Contractor.Phone == phone);
                    var form = new BuyItemForm(_context, _userRole, entityContr);
                    form.ShowDialog();
                }
                else if (individRadio.Checked)
                {
                    var birthday = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                    var individContr =
                        _context.IndividContrs.FirstOrDefault(
                            contr =>
                                contr.Birthday == birthday && contr.Contractor.ContrName == contrName &&
                                contr.Contractor.Address == address && contr.Contractor.Phone == phone);
                    var form = new BuyItemForm(_context, _userRole, individContr: individContr);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dataGridView3.SelectedRows[0];
                int quant;
                if (selectedRow == null)
                {
                    throw new Exception("Оберіть товар!");
                }
                if (!int.TryParse(quantityTxt.Text, out quant))
                {
                    throw new Exception("Перевірте введену кількість товару!");
                }
                var bookName = selectedRow.Cells[3].Value?.ToString();
                var goodName = selectedRow.Cells[0].Value?.ToString();
                var price = double.Parse(selectedRow.Cells[2].Value.ToString(), NumberStyles.Any,
                    CultureInfo.InvariantCulture);
                GoodInfo availableItem;
                if (bookName != null)
                {
                    var year = int.Parse(selectedRow.Cells[4].Value.ToString());
                    var author = selectedRow.Cells[5].Value.ToString();
                    var isbn = selectedRow.Cells[6].Value.ToString();
                    availableItem =
                        _context.GoodInfoes.FirstOrDefault(
                            info =>
                                info.Quantity >= quant && info.GoodName == goodName && info.Author == author &&
                                info.Name == bookName && info.Year == year && info.Isbn == isbn &&
                                Math.Abs(info.Price - price) < 0.00001);
                }
                else
                {
                    availableItem =
                        _context.GoodInfoes.FirstOrDefault(
                            info =>
                                info.Quantity >= quant && Math.Abs(info.Price - price) < 0.00001);
                }
                if (availableItem == null)
                {
                    throw new Exception(
                        "Перевірте введений код товару! Такого товару або не існує в системі, або ж немає такої кількості товару.");
                }
                dataGridView2.Rows.Add(availableItem.IdGoods, availableItem.Price, availableItem.Isbn != null
                    ? $"{availableItem.Name} :-: {availableItem.Author} :-: {availableItem.Year} :-: {availableItem.Isbn}"
                    : $"{availableItem.GoodName}", quant, availableItem.ContrName);
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
                }
                var listGoodsMoves = new List<GoodsMove>();
                Documentation documentation = null;
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    var contrName = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    var first = _context.Contractors.First(contractor1 => contractor1.ContrName == contrName);
                    documentation = new Documentation
                    {
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(x => x.Doctype1 == "Sell"),
                        Contractor = first,
                        Stuff = stuff
                    };
                    var id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    var quant = int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                    listGoodsMoves.Add(new GoodsMove
                    {
                        Quantity = -quant,
                        Documentation = documentation,
                        MoveType = "Sell",
                        Good = _context.Goods.First(x => x.IdGoods == id)
                    });
                    price += double.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Any,
                        CultureInfo.InvariantCulture) * int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                }
                if (documentation != null)
                {
                    _context.Documentations.Add(documentation);
                }
                _context.GoodsMoves.AddRange(listGoodsMoves);
                _context.SaveChanges();
                if (card?.Action.Percents != null) price = price * (double)card.Action.Percents;
                totalPrice_lbl.Text = $"Загальна Ціна: {price.ToString(CultureInfo.InvariantCulture)} грн.";
                MessageBox.Show(@"Дані були успішно збережені!");
                Utilities.ClearSpace(this);
                quantityTxt.Text = 1.ToString();
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                var availableGoods =
                _context.GoodInfoes
                    .Select(infos => new
                    {
                        infos.GoodName,
                        infos.Quantity,
                        infos.Price,
                        infos.Name,
                        infos.Year,
                        infos.Author,
                        ISBN = infos.Isbn,
                        infos.ContrName,
                        infos.Address,
                        infos.Phone
                    })
                    .Where(arg => arg.Quantity > 0)
                    .ToList();
                dataGridView3.DataSource = availableGoods;
                dataGridView3.Refresh();
                totalPrice_lbl.Text = @"Загальна Ціна: * грн.";
            }
            catch (Exception ex)
            {
                Utilities.ClearSpace(this);
                quantityTxt.Text = 1.ToString();
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var availableGoods =
                _context.GoodInfoes
                    .Select(infos => new
                    {
                        infos.GoodName,
                        infos.Quantity,
                        infos.Price,
                        infos.Name,
                        infos.Year,
                        infos.Author,
                        ISBN = infos.Isbn,
                        infos.ContrName,
                        infos.Address,
                        infos.Phone
                    })
                    .Where(arg => arg.Quantity > 0)
                    .ToList();
            dataGridView3.DataSource = availableGoods;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var ds = new DataSet();
                using (SqlConnection connection =
                    new SqlConnection(_context.Database.Connection.ConnectionString))
                {
                    var command = new SqlCommand("SELECT * FROM Sklyar_A.gettotalearnings()")
                    {
                        CommandType = CommandType.Text,
                        Connection = connection
                    };
                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
                    using (var report = new Report())
                    {
                        report.Load(@"D:\Documents\Институт\БД\DBCourseWork\DBCourseWork\EarningsReport.frx");
                        report.RegisterData(ds);
                        report.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }
    }
}
