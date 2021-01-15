using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace accounting
{
    public partial class Form1 : Form
    {
        public DataStorage family;

        private AddPerson addPersonForm;
        private AddTransaction addTransactionForm;
        private RemoveTransaction removeTransactionForm;
        private Chart chartForm;
        private XmlSerializer formatter;

        public Form1()
        {
            InitializeComponent();
            family = new DataStorage();
            formatter = new XmlSerializer(typeof(DataStorage));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Income:";
            label2.Text = "Expenses:";
            label3.Text = "";
            label4.Text = "";
            button8.Text = "Delete family member";
            button2.Text = "General chart";
            using(FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                family = (DataStorage)formatter.Deserialize(fs);
            }
            foreach (Person i in family.persons)
            {
                listBox1.Items.Add(i.name);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addPersonForm = new AddPerson(this, family);
            addPersonForm.ShowDialog();
            listBox1.Items.Clear();
            foreach (Person i in family.persons)
            {
                listBox1.Items.Add(i.name);
            }
        }   //add person

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker1.Value.Date;
            int a = listBox1.SelectedIndex;
            if (a >= 0)
            {
                addTransactionForm = new AddTransaction(this, family, d, a);
                addTransactionForm.ShowDialog();
                showIncomeCosts();
            }
        }   //add transaction

        private void button8_Click(object sender, EventArgs e)
        {
            int a = listBox1.SelectedIndex;
            if (a >= 0)
            {
                family.persons.RemoveAt(a);
                listBox1.Items.Clear();
                foreach (Person i in family.persons)
                {
                    listBox1.Items.Add(i.name);
                }
            }
        }   //remove person

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showIncomeCosts();
        }   //select person

        private void showIncomeCosts()
        {
            DateTime d = dateTimePicker1.Value.Date;
            int a = listBox1.SelectedIndex;
            if (a >= 0)
            {
                if (family.persons[a].dates.Count > 0)
                {
                    bool datePresence = false;
                    foreach (Date i in family.persons[a].dates)
                    {
                        if (i.date == d)
                        {
                            if (i.incomePerDay.Count > 0)
                            {
                                int sum = 0;
                                foreach (int k in i.incomePerDay)
                                {
                                    sum += k;
                                }
                                label3.Text = sum.ToString();
                            }
                            else
                            {
                                label3.Text = "";
                            }
                            if (i.costsPerDay.Count > 0)
                            {
                                int sum = 0;
                                foreach (int k in i.costsPerDay)
                                {
                                    sum += k;
                                }
                                label4.Text = sum.ToString();

                            }
                            else
                            {
                                label4.Text = "";
                            }


                            datePresence = true;
                        }
                    }
                    if (!datePresence)
                    {
                        label3.Text = "";
                        label4.Text = "";
                    }
                }
                else
                {
                    label3.Text = "";
                    label4.Text = "";
                }

            }
            else
            {
                label3.Text = "";
                label4.Text = "";
            }

        }   //income, cost outputs per day

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            showIncomeCosts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker1.Value.Date;
            int a = listBox1.SelectedIndex;
            if (a >= 0)
            {
                removeTransactionForm = new RemoveTransaction(this, family, d, a);
                removeTransactionForm.ShowDialog();
                showIncomeCosts();
            }
        }   //remove transaction

        private void button7_Click(object sender, EventArgs e)
        {
            int a = listBox1.SelectedIndex;
            if (a >= 0)
            {
                chartForm = new Chart(this, family, a);
                chartForm.ShowDialog();
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, family);

                MessageBox.Show("Changes saved");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            All all = new All(this);
            all.ShowDialog();
        }

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
