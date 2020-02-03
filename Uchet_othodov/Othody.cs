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
    public partial class Othody : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = string.Empty;
        public Othody()
        {
            InitializeComponent();
        }

        public Othody(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update(MySqlQueries.Insert_Othody, null, textBox1.Text, comboBox2.Text, comboBox1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update(MySqlQueries.Update_Othody, ID, textBox1.Text, comboBox2.Text, comboBox1.Text);
            this.Close();
        }
    }
}
