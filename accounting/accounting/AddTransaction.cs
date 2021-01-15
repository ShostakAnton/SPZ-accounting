using System;
using System.Windows.Forms;

namespace accounting
{
    public partial class AddTransaction : Form
    {
        private Form1 mainForm;
        private DataStorage data;
        private DateTime date;
        private int personIndex;

        public AddTransaction()
        {
            InitializeComponent();
        }

        public AddTransaction(Form1 mainForm, DataStorage data, DateTime date, int personIndex)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.data = data;
            this.date = date;
            this.personIndex = personIndex;
        }


        private void AddTransaction_Load(object sender, EventArgs e)
        {
            button1.Text = "Add income";
            button2.Text = "Add expense";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dateIndex = -1;
            for (int i = 0; i < data.persons[personIndex].dates.Count; ++i)
            {
                if (data.persons[personIndex].dates[i].date == date)
                {
                    dateIndex = i;
                }
            }
            if(dateIndex >=0)
            {
                data.persons[personIndex].dates[dateIndex].incomePerDay.Add((int)numericUpDown1.Value);
                MessageBox.Show("Income for" + date.ToString() + " + " + numericUpDown1.Value.ToString());
            }
            else
            {
                Date d = new Date(date);
                data.persons[personIndex].dates.Add(d);
                for (int i = 0; i < data.persons[personIndex].dates.Count; ++i)
                {
                    if (data.persons[personIndex].dates[i].date == date)
                    {
                        data.persons[personIndex].dates[i].incomePerDay.Add((int)numericUpDown1.Value);
                        MessageBox.Show("Income for " + date.ToString() + " + " + numericUpDown1.Value.ToString());
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dateIndex = -1;
            for (int i = 0; i < data.persons[personIndex].dates.Count; ++i)
            {
                if (data.persons[personIndex].dates[i].date == date)
                {
                    dateIndex = i;
                }
            }
            if (dateIndex >= 0)
            {
                data.persons[personIndex].dates[dateIndex].costsPerDay.Add((int)numericUpDown2.Value);
                MessageBox.Show("Expense for " + date.ToString() + " + " + numericUpDown2.Value.ToString());
            }
            else
            {
                Date d = new Date(date);
                data.persons[personIndex].dates.Add(d);
                for (int i = 0; i < data.persons[personIndex].dates.Count; ++i)
                {
                    if (data.persons[personIndex].dates[i].date == date)
                    {
                        data.persons[personIndex].dates[i].costsPerDay.Add((int)numericUpDown2.Value);
                        MessageBox.Show("Expense for " + date.ToString() + " + " + numericUpDown2.Value.ToString());
                    }
                }

            }
        }
    }
}
