using System;
using System.Windows.Forms;

namespace accounting
{
    public partial class AddPerson : Form
    {
        private Form1 mainForm;
        private DataStorage data;

        public AddPerson()
        {
            InitializeComponent();
        }

        public AddPerson(Form1 mainForm, DataStorage data)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.data = data;
        }

        private void AddPerson_Load(object sender, EventArgs e)
        {
            button1.Text = "Add";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 is null)
            {
                this.Close();
            }
            else
            {
                Person person = new Person(textBox1.Text);
                data.persons.Add(person);
                this.Close();
            }
        }
    }
}
