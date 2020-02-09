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
    public partial class Kartochka : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID = string.Empty;
        public Kartochka()
        {
            InitializeComponent();
        }

        public Kartochka(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Otdely_ComboBox, comboBox1);
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Othody_ComboBox, comboBox2);
        }

        private void Proverka_Ostatka()
        {
            string output = string.Empty;
            MySqlOperations.Select_Text(MySqlQueries.Select_Kartochka_Ostatok, ref output, ID);
            if (decimal.Parse(output) == decimal.Parse("0,00"))
            {
                if (MessageBox.Show("Необходимое количество отходов уже собрано." + '\n' + "Желаете отправить собранные отходы на утилизацию?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Ubytiya ubytiya = new Ubytiya(MySqlQueries, MySqlOperations, ID);
                    ubytiya.button1.Visible = true;
                    ubytiya.button3.Visible = false;
                    ubytiya.dateTimePicker1.MinDate = DateTime.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value.ToString());
                    ubytiya.dateTimePicker1.MaxDate = dateTimePicker2.Value;
                    ubytiya.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Ubytiya_Kartochki, dataGridView2, ID);
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                string date1 = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
                string date2 = dateTimePicker2.Value.Year.ToString() + '-' + dateTimePicker2.Value.Month.ToString() + '-' + dateTimePicker2.Value.Day.ToString();
                MySqlOperations.Insert_Update(MySqlQueries.Insert_Kartochka, null, MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_ID_Otdela, comboBox1.Text), MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_ID_Othoda, comboBox2.Text), date1, date2, textBox1.Text);
                button1.Visible = false;
                button3.Visible = false;
                button8.Visible = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                MySqlOperations.Select_Text(MySqlQueries.Last_Insert_ID, ref ID);
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
            }
            else
                MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                string date1 = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
                string date2 = dateTimePicker2.Value.Year.ToString() + '-' + dateTimePicker2.Value.Month.ToString() + '-' + dateTimePicker2.Value.Day.ToString();
                MySqlOperations.Insert_Update(MySqlQueries.Update_Kartochka, ID, MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_ID_Otdela, comboBox1.Text), MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_ID_Othoda, comboBox2.Text), date1, date2, textBox1.Text);
                button1.Visible = false;
                button3.Visible = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                button8.Visible = true;
            }
            else
                MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pribytiya pribytiya = new Pribytiya(MySqlQueries,MySqlOperations,ID);
            pribytiya.button1.Visible = true;
            pribytiya.button3.Visible = false;
            pribytiya.dateTimePicker1.MinDate = dateTimePicker1.Value;
            pribytiya.dateTimePicker1.MaxDate = dateTimePicker2.Value;
            pribytiya.ShowDialog();
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Pribytiya_Kartochki, dataGridView1, ID);
            Proverka_Ostatka();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ubytiya ubytiya = new Ubytiya(MySqlQueries, MySqlOperations, ID);
            ubytiya.button1.Visible = true;
            ubytiya.button3.Visible = false;
            ubytiya.dateTimePicker1.MinDate = DateTime.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value.ToString());
            ubytiya.dateTimePicker1.MaxDate = dateTimePicker2.Value;
            ubytiya.ShowDialog();
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Ubytiya_Kartochki, dataGridView2, ID);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button3.Visible = true;
            button1.Visible = false;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                MySqlOperations.Delete(MySqlQueries.Delete_Pribytiya, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Pribytiya_Kartochki, dataGridView1, ID);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                MySqlOperations.Delete(MySqlQueries.Delete_Ubytiya, dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Ubytiya_Kartochki, dataGridView2, ID);
            }
        }

        private void Kartochka_Load(object sender, EventArgs e)
        {
            //Proverka_Ostatka();
        }

        private void Kartochka_Shown(object sender, EventArgs e)
        {
            string output = string.Empty;
            MySqlOperations.Select_Text(MySqlQueries.Select_Kartochka_Identify, ref output, ID);
            if (output != "1" && ID != null)
                Proverka_Ostatka();
        }
    }
}
