using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accounting
{
    public partial class All : Form
    {
        Form1 mainForm;

        public All()
        {
            InitializeComponent();
        }

        public All(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }


        private void All_Load(object sender, EventArgs e)
        {
            int income,
                costs;
             foreach(Person i in mainForm.family.persons)
            {
                income = 0;
                costs = 0;
                foreach(Date k in i.dates)
                {
                    foreach(int j in k.incomePerDay)
                    {
                        income += j;
                    }
                    foreach (int j in k.costsPerDay)
                    {
                        costs += j;
                    }
                }
                chart1.Series["Income"].Points.AddXY(i.name, income);
                chart1.Series["Costs"].Points.AddXY(i.name, costs);
            }
        }
    }
}
