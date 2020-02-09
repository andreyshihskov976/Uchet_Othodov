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
    public partial class User_Main : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID = string.Empty;
        string identify = string.Empty;

        public User_Main()
        {
            InitializeComponent();
        }

        public User_Main(string iD)
        {
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
            ID = iD;
        }

        private void карточкиОтходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka_Otdela, dataGridView1, ID);
            identify = "kartochka";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Insert_String();
        }

        private void Insert_String()
        {
            if (identify == "kartochka")
            {
                Kartochka kartochka = new Kartochka(MySqlQueries, MySqlOperations, null);
                string output = string.Empty;
                kartochka.button1.Visible = true;
                kartochka.button3.Visible = false;
                kartochka.button8.Visible = false;
                MySqlOperations.Select_Text(MySqlQueries.Select_Otdely_ComboBox_by_ID, ref output, ID);
                MySqlOperations.Search_In_ComboBox(output, kartochka.comboBox1);
                kartochka.comboBox1.DropDownStyle = ComboBoxStyle.Simple;
                kartochka.comboBox1.Enabled = false;
                kartochka.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka_Otdela, dataGridView1, ID);
            }
        }

        private void User_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySqlOperations.CloseConnection();
            Application.Exit();
        }

        private void User_Main_Load(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
                Update_String();
            else
                MessageBox.Show("Невозможно отредактировать сразу несколько записей." + '\n' + "Пожалуйста выберите одну запись.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Update_String()
        {
            string output = string.Empty;
            MySqlOperations.Select_Text(MySqlQueries.Select_Kartochka_Identify, ref output, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (output != "1")
            {
                if (identify == "kartochka")
                {
                    Kartochka kartochka = new Kartochka(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    output = string.Empty;
                    kartochka.button3.Visible = true;
                    kartochka.button1.Visible = false;
                    kartochka.button8.Visible = false;
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), kartochka.comboBox1);
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), kartochka.comboBox2);
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Pribytiya_Kartochki, kartochka.dataGridView1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Ubytiya_Kartochki, kartochka.dataGridView2, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    kartochka.dateTimePicker1.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                    kartochka.dateTimePicker2.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                    kartochka.textBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    kartochka.comboBox1.DropDownStyle = ComboBoxStyle.Simple;
                    kartochka.comboBox1.Enabled = false;
                    kartochka.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka_Otdela, dataGridView1, ID);
                }
            }
            else
            {
                Kartochka kartochka = new Kartochka(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Prosmotr(kartochka);
                kartochka.button4.Enabled = false;
                kartochka.button5.Enabled = false;
                kartochka.button6.Enabled = false;
                kartochka.button7.Enabled = false;
                kartochka.button8.Enabled = false;
                kartochka.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka_Otdela, dataGridView1, ID);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Хотите просмотреть карточку?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { string output = string.Empty;
                MySqlOperations.Select_Text(MySqlQueries.Select_Kartochka_Identify, ref output, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                if (output != "1")
                {
                    Kartochka kartochka = new Kartochka(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    Prosmotr(kartochka);
                    kartochka.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka_Otdela, dataGridView1, ID);
                }
                else
                {
                    Kartochka kartochka = new Kartochka(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    Prosmotr(kartochka);
                    kartochka.button4.Enabled = false;
                    kartochka.button5.Enabled = false;
                    kartochka.button6.Enabled = false;
                    kartochka.button7.Enabled = false;
                    kartochka.button8.Enabled = false;
                    kartochka.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka_Otdela, dataGridView1, ID);
                }
            }
        }

        private void Prosmotr(Kartochka kartochka)
        {
            string output = string.Empty;
            kartochka.button3.Visible = false;
            kartochka.button1.Visible = false;
            kartochka.button8.Visible = true;
            kartochka.comboBox2.Enabled = false;
            kartochka.dateTimePicker1.Enabled = false;
            kartochka.dateTimePicker2.Enabled = false;
            kartochka.textBox1.Enabled = false;
            MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), kartochka.comboBox1);
            MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), kartochka.comboBox2);
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Pribytiya_Kartochki, kartochka.dataGridView1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Ubytiya_Kartochki, kartochka.dataGridView2, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            kartochka.dateTimePicker1.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            kartochka.dateTimePicker2.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            kartochka.textBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            kartochka.comboBox1.DropDownStyle = ComboBoxStyle.Simple;
            kartochka.comboBox1.Enabled = false;
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Search(toolStripTextBox1,dataGridView1);
        }
    }
}
