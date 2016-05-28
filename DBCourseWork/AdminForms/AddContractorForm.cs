using System;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;

namespace DBCourseWork.AdminForms
{
    public partial class AddContractorForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRole _userRole;

        public AddContractorForm(ApplicationDbContext context, UserRole user)
        {
            _userRole = user;
            _context = context;
            InitializeComponent();
            entityRadio.Checked = true;
            birthDatePicker.Enabled = false;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void individRadio_CheckedChanged(object sender, EventArgs e)
        {
            entityRadio.Checked = !individRadio.Checked;
            birthDatePicker.Enabled = individRadio.Checked;
            registrationNumTxt.Enabled = entityRadio.Checked;
        }

        private void entityRadio_CheckedChanged(object sender, EventArgs e)
        {
            individRadio.Checked = !entityRadio.Checked;
            birthDatePicker.Enabled = individRadio.Checked;
            registrationNumTxt.Enabled = entityRadio.Checked;
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
                var contractor = new Contractor
                {
                    Phone = phone,
                    Address = addressTxt.Text,
                    ContrName = nameTxt.Text
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
                    _context.Documentations.Add(new Documentation
                    {
                        Stuff = stuff,
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterContractor"),
                        Contractor = entityContractor.Contractor
                    });
                    _context.SaveChanges();
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
                        Contractor = contractor
                    });
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
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
    }
}
