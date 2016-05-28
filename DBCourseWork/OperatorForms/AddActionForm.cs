using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;
using Action = DBCourseWork.Entities.Action;

namespace DBCourseWork.OperatorForms
{
    public partial class AddActionForm : Form
    {
        private readonly UserRole _userRole;
        private readonly ApplicationDbContext _context;

        public AddActionForm(ApplicationDbContext context, UserRole user)
        {
            _userRole = user;
            _context = context;
            InitializeComponent();
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
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addActionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var stuff = _context.Stuffs.FirstOrDefault(stuff1 => stuff1.Person.IdPerson == _userRole.Person.IdPerson);
                double percent;
                if (!double.TryParse(discountTxt.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out percent))
                {
                    throw new Exception("Перевірте введену знижку!");
                }
                var startDate = startDatePicker.Value;
                var endDate = endDatePicker.Value;
                if (startDate > DateTime.Now || startDate < DateTime.Parse("01.01.1900") || endDate <= DateTime.Now ||
                    endDate >= DateTime.Now.AddYears(5) || percent > 100)
                {
                    throw new Exception("Перевірте правильність введеної дати!");
                }
                var card = new Card();
                var action = new Action
                {
                    DayStart = startDate,
                    DayStop = endDate,
                    Percents = percent
                };
                action.Cards.Add(card);
                var contractorData = contrCombobox.SelectedItem as String;
                if (contractorData == null)
                {
                    throw new Exception("Оберіть контрагента!");
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
                        individContr.Contractor.Card = card;
                        _context.IndividContrs.Add(individContr);
                        _context.Actions.Add(action);
                        _context.Cards.Add(card);
                        _context.Documentations.Add(new Documentation
                        {
                            Contractor = individContr.Contractor,
                            Stuff = stuff,
                            DocDate = DateTime.Now,
                            DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterCard")
                        });
                        _context.SaveChanges();
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
                        entityContr.Contractor.Card = card;
                        _context.EntityContrs.Add(entityContr);
                        _context.Actions.Add(action);
                        _context.Cards.Add(card);
                        _context.Documentations.Add(new Documentation
                        {
                            Contractor = entityContr.Contractor,
                            Stuff = stuff,
                            DocDate = DateTime.Now,
                            DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterCard")
                        });
                        _context.SaveChanges();
                        MessageBox.Show(@"Дані були успішно збережені!");
                        Utilities.ClearSpace(this);
                    }
                    else
                    {
                        throw new Exception("Такого не контрагента не існує!");
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
