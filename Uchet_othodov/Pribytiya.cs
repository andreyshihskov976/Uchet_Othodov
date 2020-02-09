using System;
using System.Windows.Forms;

namespace Uchet_othodov
{
    public partial class Pribytiya : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID = string.Empty;
        public Pribytiya()
        {
            InitializeComponent();
        }

        public Pribytiya(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string output = string.Empty;
                textBox1.Text = textBox1.Text.Replace('.', ',');
                MySqlOperations.Select_Text(MySqlQueries.Select_Kartochka_Ostatok, ref output, ID);
                if (output == "" || decimal.Parse(output) >= decimal.Parse(textBox1.Text))
                {
                    string date1 = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
                    MySqlOperations.Insert_Update(MySqlQueries.Insert_Pribytiya, ID, date1, textBox1.Text);
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Количество больше остатка." + '\n' + "Остаток: " + output, "Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Поле 'Количество' не заполнено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
