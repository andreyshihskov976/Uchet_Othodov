using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uchet_othodov
{
    public partial class Ubytiya : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID = string.Empty;

        public Ubytiya()
        {
            InitializeComponent();
        }

        public Ubytiya(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Organizacii_ComboBox, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                string date1 = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
                MySqlOperations.Insert_Update(MySqlQueries.Insert_Ubytiya, ID, date1, textBox1.Text, MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_ID_Organizacii, comboBox1.Text));
                MySqlOperations.Insert_Update(MySqlQueries.Update_Identify, ID);
                this.Close();
            }
            else
                MessageBox.Show("Поле количество не заполнено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
