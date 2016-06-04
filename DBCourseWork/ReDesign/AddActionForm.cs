using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DBCourseWork.Entities;
using Action = DBCourseWork.Entities.Action;

namespace DBCourseWork.ReDesign
{
    public partial class AddActionForm : Form
    {
        private readonly UserRole _userRole;
        private readonly ApplicationDbContext _context;
        private readonly EntityContr _entityContr;
        private readonly IndividContr _individContr;


        public AddActionForm(ApplicationDbContext context, UserRole user, EntityContr entity = null, IndividContr individContr = null)
        {
            _userRole = user;
            _context = context;
            InitializeComponent();
            _entityContr = entity;
            _individContr = individContr;
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
                var act =
                    _context.Actions.FirstOrDefault(
                        action1 =>
                            action1.DayStart == startDate && action1.DayStop == endDate && action1.Percents == percent);
                if (act != null)
                {
                    act.Cards.Add(card);
                    _context.Actions.Attach(act);
                    _context.Entry(act).State = EntityState.Modified;
                }
                else
                {
                    var action = new Action
                    {
                        DayStart = startDate,
                        DayStop = endDate,
                        Percents = percent
                    };
                    action.Cards.Add(card);
                    _context.Actions.Add(action);
                    _context.Cards.Add(card);
                }
                if (_entityContr != null)
                {
                    _entityContr.Contractor.Card = card;
                    _context.EntityContrs.Attach(_entityContr);
                    _context.Entry(_entityContr).State = EntityState.Modified;
                    _context.Documentations.Add(new Documentation
                    {
                        Contractor = _entityContr.Contractor,
                        Stuff = stuff,
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterCard")
                    });
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
                }
                else if (_individContr != null)
                {
                    _individContr.Contractor.Card = card;
                    _context.IndividContrs.Attach(_individContr);
                    _context.Entry(_individContr).State = EntityState.Modified;
                    _context.Documentations.Add(new Documentation
                    {
                        Contractor = _individContr.Contractor,
                        Stuff = stuff,
                        DocDate = DateTime.Now,
                        DocType = _context.DocTypes.First(type => type.Doctype1 == "RegisterCard")
                    });
                    _context.SaveChanges();
                    MessageBox.Show(@"Дані були успішно збережені!");
                    Utilities.ClearSpace(this);
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
