using System;
using System.Windows.Forms;

namespace accounting
{
    public partial class Chart : Form
    {
        private Form1 mainForm;
        private DataStorage data;
        private int personIndex;

        public Chart()
        {
            InitializeComponent();
        }

        public Chart(Form1 mainForm, DataStorage data, int personIndex)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.data = data;
            this.personIndex = personIndex;
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            button1.Text = "Add";
            button2.Text = "Delete";
        }

        int sumIncomePerDay(DateTime date)
        {
            int resultSum = 0;
            for (int i = 0; i < data.persons[personIndex].dates.Count; ++i)
            {
                if (data.persons[personIndex].dates[i].date == date)
                {
                    foreach (int k in data.persons[personIndex].dates[i].incomePerDay)
                    {
                        resultSum += k;
                    }
                }
            }
            return resultSum;
        }

        int sumCostsPerDay(DateTime date)
        {
            int resultSum = 0;
            for (int i = 0; i < data.persons[personIndex].dates.Count; ++i)
            {
                if (data.persons[personIndex].dates[i].date == date)
                {
                    foreach (int k in data.persons[personIndex].dates[i].costsPerDay)
                    {
                        resultSum += k;
                    }
                }
            }
            return resultSum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string d = dateTimePicker1.Value.Date.ToString();
            DateTime date = dateTimePicker1.Value.Date;
            bool overlap = false;
            for (int i = 0; i < listBox1.Items.Count; ++i)
            {
                if (d == listBox1.Items[i].ToString())
                {
                    overlap = true;
                }
            }
            if (!overlap)
            {
                listBox1.Items.Add(d);
                chart1.Series["Income"].Points.AddXY(d, sumIncomePerDay(date));
                chart1.Series["Costs"].Points.AddXY(d, sumCostsPerDay(date));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            chart1.Series.Clear();
            chart1.Series.Add("Income");
            chart1.Series.Add("Costs");
            for (int i = 0; i < listBox1.Items.Count; ++i)
            {
                foreach (Date k in data.persons[personIndex].dates)
                {
                    if (listBox1.Items[i].ToString() == k.date.ToString())
                    {
                        chart1.Series["Income"].Points.AddXY(k.date.ToString(), sumIncomePerDay(k.date));
                        chart1.Series["Costs"].Points.AddXY(k.date.ToString(), sumCostsPerDay(k.date));

                    }

                }
            }
        }
    }
}
