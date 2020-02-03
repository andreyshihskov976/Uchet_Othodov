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
    public partial class Sotrudniki : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = string.Empty;

        public Sotrudniki()
        {
            InitializeComponent();
        }

        public Sotrudniki(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Otdely_ComboBox, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID_Otdela = MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_ID_Otdela, comboBox1.Text);
            MySqlOperations.Insert_Update(MySqlQueries.Insert_Sotrudniki, null, textBox1.Text, textBox2.Text, textBox3.Text, ID_Otdela, textBox4.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ID_Otdela = MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_ID_Otdela, comboBox1.Text);
            MySqlOperations.Insert_Update(MySqlQueries.Update_Sotrudniki, ID, textBox1.Text, textBox2.Text, textBox3.Text, ID_Otdela, textBox4.Text);
            this.Close();
        }
    }
}
