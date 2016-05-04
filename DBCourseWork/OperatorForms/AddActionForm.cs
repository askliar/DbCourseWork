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
using Action = DBCourseWork.Entities.Action;

namespace DBCourseWork.OperatorForms
{
    public partial class AddActionForm : Form
    {
        public readonly ApplicationDbContext _context;

        public AddActionForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
            var entityContractors = _context.EntityContrs.ToList();
            var individContractors = _context.IndividContrs.ToList();
            foreach (var individContractor in individContractors)
            {
                contrCombobox.Items.Add(
                    $"{individContractor.Contractor.ContrName} :-: {individContractor.Contractor.Address} :-: {individContractor.Birthday}");
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
                double percent;
                if (!double.TryParse(discountTxt.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out percent))
                {
                    throw new Exception("The entered discount value is wrong!");
                }
                var startDate = startDatePicker.Value;
                var endDate = startDatePicker.Value;
                if (startDate > DateTime.Now || startDate < DateTime.Parse("01.01.1900") || endDate <= DateTime.Now ||
                    endDate >= DateTime.Now.AddYears(5) || percent > 100)
                {
                    throw new Exception("The entered dates are wrong!");
                }
                var card = new Card();
                var action = new Action
                {
                    DayStart = startDate,
                    DayStop = endDate,
                    Percents = percent,
                };
                action.Cards.Add(card);
                var contractorData = contrCombobox.SelectedItem as String;
                if (contractorData == null)
                {
                    throw new Exception("Choose the contractor!");
                }
                //var contractorName = contractorData.Take();
                var firstIndex = contractorData.IndexOf(" :-: ", StringComparison.Ordinal);
                var lastIndex = contractorData.LastIndexOf(" :-: ", StringComparison.Ordinal);
                var contractorName = contractorData.Substring(0, firstIndex);
                var contractorAddress = contractorData.Substring(firstIndex + 5, lastIndex);
                var contractorDetails = contractorData.Substring(lastIndex + 5);
                DateTime date;
                if (DateTime.TryParse(contractorDetails, out date))
                {
                    var contractor =
                        _context.Contractors.FirstOrDefault(
                            contr =>
                                contr.ContrName == contractorName && contr.Address == contractorAddress);
                    var individContr = _context.IndividContrs.FirstOrDefault(contr => contr.Contractor == contractor && contr.Birthday == date);
                    if (individContr != null) individContr.Contractor.Card = card;
                    _context.IndividContrs.Add(individContr);
                    _context.SaveChanges();
                    MessageBox.Show(@"Changes saved succesfully!");
                    Utilities.ClearSpace(this);
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
                    if (entityContr != null) entityContr.Contractor.Card = card;
                    _context.EntityContrs.Add(entityContr);
                    _context.SaveChanges();
                    MessageBox.Show(@"Changes saved succesfully!");
                    Utilities.ClearSpace(this);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Check the entered information!");
            }

        }
    }
}
