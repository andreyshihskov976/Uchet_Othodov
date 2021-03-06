﻿using System;
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
            MySqlOperations.Select_Text(MySqlQueries.Select_Avtorizacia, ref ID, null, textBox1.Text, textBox2.Text);
            if (ID == "1")
            {
                MySqlOperations.Select_Text(MySqlQueries.Select_SignIn, ref ID, null, textBox1.Text);
                if (ID == "0")
                    this.DialogResult = DialogResult.Yes;
                else
                    this.DialogResult = DialogResult.No;
                
                this.Close();
            }
            else
                MessageBox.Show("Неверный пароль или логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MySqlOperations.CloseConnection();
        }
    }
}
