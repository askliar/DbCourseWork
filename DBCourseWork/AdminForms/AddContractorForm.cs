using System;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.AdminForms
{
    public partial class AddContractorForm : Form
    {
        private readonly ApplicationDbContext _context;

        public AddContractorForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
            entityRadio.Checked = true;
            birthDatePicker.Enabled = false;
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void individRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            entityRadio.Checked = !individRadio.Checked;
            birthDatePicker.Enabled = individRadio.Checked;
            registrationNumTxt.Enabled = entityRadio.Checked;
        }

        private void entityRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            individRadio.Checked = !entityRadio.Checked;
            birthDatePicker.Enabled = individRadio.Checked;
            registrationNumTxt.Enabled = entityRadio.Checked;
        }

        private void addBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                var birthday = birthDatePicker.Value;
                var phone = phoneTxt.Text;
                if (birthday > DateTime.Now || birthday < DateTime.Parse("01.01.1900"))
                {
                    throw new Exception();
                }
                if (!Utilities.IsValidPhone(phone))
                {
                    throw new Exception();
                }
                var contractor = new Contractor
                {
                    Phone = phone,
                    Address = addressTxt.Text,
                    ContrName = nameTxt.Text,
                };
                if (entityRadio.Checked)
                {
                    var foundContr = _context.EntityContrs.FirstOrDefault(contr => contr.StateNumber == registrationNumTxt.Text);
                    if (foundContr != null)
                        throw new Exception();
                    var entityContractor = new EntityContr
                    {
                        Contractor = contractor,
                        StateNumber = registrationNumTxt.Text
                    };
                    _context.EntityContrs.Add(entityContractor);
                    _context.SaveChanges();
                    MessageBox.Show(@"Changes saved succesfully!");
                    Utilities.ClearSpace(this);
                }
                else if (individRadio.Checked)
                {
                    var individContr = new IndividContr
                    {
                        Birthday = birthday
                    };
                    _context.IndividContrs.Add(individContr);
                    _context.SaveChanges();
                    MessageBox.Show(@"Changes saved succesfully!");
                    Utilities.ClearSpace(this);
                }
                else
                {
                    MessageBox.Show(@"Choose the type of contractor!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Check the entered information!");
            }

        }
    }
}
