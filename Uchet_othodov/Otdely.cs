using System;
using System.Windows.Forms;

namespace Uchet_othodov
{
    public partial class Otdely : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = string.Empty;

        public Otdely()
        {
            InitializeComponent();
        }

        public Otdely(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update(MySqlQueries.Insert_Otdely, null, textBox1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            if (textBox1.Text != "" )
            {
                MySqlOperations.Insert_Update(MySqlQueries.Update_Otdely, ID, textBox1.Text);
                this.Close();
            }
            else MessageBox.Show("Присутствуют пустые поля!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
