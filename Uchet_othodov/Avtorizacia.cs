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
    public partial class Avtorizacia : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        public string ID = string.Empty;

        public Avtorizacia()
        {
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations =new MySqlOperations(MySqlQueries);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
            MySqlOperations.Select_Text(MySqlQueries.Select_Avtorizacia, ref ID, null, textBox2.Text, textBox1.Text);
            if (ID == "0")
            {
                MySqlOperations.Select_Text(MySqlQueries.Select_SignIn, ref ID, null, textBox1.Text);
                if (ID == "0")
                    this.DialogResult = DialogResult.Yes;
                else
                    this.DialogResult = DialogResult.No;
            }
            else
                MessageBox.Show("Неверный пароль или логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MySqlOperations.CloseConnection();
            this.Close();
        }
    }
}
