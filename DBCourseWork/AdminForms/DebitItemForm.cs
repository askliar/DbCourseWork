using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBCourseWork.AdminForms
{
    public partial class DebitItemForm : Form
    {
        private readonly ApplicationDbContext _context;

        public DebitItemForm(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
            foreach (var good in _context.Goods.ToList())
            {
                var contractor = good.GoodsMoves.FirstOrDefault(move => move.Good == good)?.Documentation.Contractor;
                if (contractor != null) itemsCombobox.Items.Add($"{good.GoodName} - {contractor.ContrName}");
            }
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void sellBtn_Click(object sender, System.EventArgs e)
        {
            int num;
            var result = int.TryParse(quantityTxt.Text, out num);
            var contains = itemsCombobox.Items.Contains(itemsCombobox.Text);
            if (contains && result && num > 0)
            {
                
            }
            else if (result && num > 0)
            {
                MessageBox.Show(@"There is no such item registered! First register item!");
            }
            else if (contains)
            {
                MessageBox.Show(@"Check the entered number!");
            }
            else
            {
                MessageBox.Show(@"Check the entered number and item!");
            }
        }
    }
}