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
    public partial class Main : Form
    {
        public MySqlQueries MySqlQueries = null;
        public MySqlOperations MySqlOperations = null;
        public string identify = null;
        public Main()
        {
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySqlOperations.CloseConnection();
            Application.Exit();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Search(toolStripTextBox1, dataGridView1);
        }

        private void карточкиОтходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka, dataGridView1);
            identify = "kartochka";
        }

        private void прибытияОтходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Pribytiya, dataGridView1);
            identify = "pribytiya";
        }

        private void убытияОтходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Ubytiya, dataGridView1);
            identify = "ubytiya";
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki, dataGridView1);
            identify = "sotrudniki";
        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Otdely, dataGridView1);
            identify = "otdely";
        }

        private void организацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);
            identify = "organizacii";
        }

        private void отходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Othody, dataGridView1);
            identify = "othody";
        }

        private void Insert_String()
        {
            if (identify == "othody")
            {

                Othody othody = new Othody(MySqlOperations, MySqlQueries, null);
                othody.button1.Visible = true;
                othody.button3.Visible = false;
                othody.AcceptButton = othody.button1;
                othody.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Othody, dataGridView1);
            }
            else if (identify == "sotrudniki")
            {
                Sotrudniki sotrudniki = new Sotrudniki(MySqlOperations, MySqlQueries, null);
                sotrudniki.button1.Visible = true;
                sotrudniki.button3.Visible = false;
                sotrudniki.AcceptButton = sotrudniki.button1;
                sotrudniki.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki, dataGridView1);
            }
            else if (identify == "otdely")
            {
                Otdely otdely = new Otdely(MySqlOperations, MySqlQueries, null);
                otdely.button1.Visible = true;
                otdely.button3.Visible = false;
                otdely.AcceptButton = otdely.button1;
                otdely.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Otdely, dataGridView1);
            }
            else if (identify == "organizacii")
            {
                Organizacii organizacii = new Organizacii(MySqlOperations, MySqlQueries, null);
                organizacii.button1.Visible = true;
                organizacii.button3.Visible = false;
                organizacii.AcceptButton = organizacii.button1;
                organizacii.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);
            }
        }

        private void Update_String()
        {
            if (identify == "othody")
            {
                Othody othody = new Othody(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                othody.button3.Visible = true;
                othody.button1.Visible = false;
                othody.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), othody.comboBox2);
                MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), othody.comboBox1);
                othody.AcceptButton = othody.button3;
                othody.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Othody, dataGridView1);
            }
            else if (identify == "sotrudniki")
            {
                Sotrudniki sotrudniki = new Sotrudniki(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                sotrudniki.button3.Visible = true;
                sotrudniki.button1.Visible = false;
                sotrudniki.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Split(' ')[0];
                sotrudniki.textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Split(' ')[1];
                sotrudniki.textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Split(' ')[2];
                MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), sotrudniki.comboBox1);
                sotrudniki.textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                sotrudniki.AcceptButton = sotrudniki.button3;
                sotrudniki.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki, dataGridView1);
            }
            else if (identify == "otdely")
            {
                Otdely otdely = new Otdely(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                otdely.button3.Visible = true;
                otdely.button1.Visible = false;
                otdely.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                otdely.AcceptButton = otdely.button3;
                otdely.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Otdely, dataGridView1);
            }
            else if (identify == "organizacii")
            {
                Organizacii organizacii = new Organizacii(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                organizacii.button3.Visible = true;
                organizacii.button1.Visible = false;
                organizacii.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                organizacii.AcceptButton = organizacii.button3;
                organizacii.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);
            }
        }

        private void Delete_String()
        {
            if (identify == "othody")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Delete(MySqlQueries.Delete_Othody, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Othody, dataGridView1);
            }
            else if (identify == "sotrudniki")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Delete(MySqlQueries.Delete_Sotrudniki, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki, dataGridView1);
            }
            else if (identify == "otdely")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Delete(MySqlQueries.Delete_Otdely, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Otdely, dataGridView1);
            }
            else if (identify == "organizacii")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Delete(MySqlQueries.Delete_Organizacii, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);
            }
            else if (identify == "kartochka")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Delete(MySqlQueries.Delete_Kartochka, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka, dataGridView1);
            }
            else if (identify == "ubytiya")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Delete(MySqlQueries.Delete_Ubytiya, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka, dataGridView1);
            }
            else if (identify == "pribytiya")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Delete(MySqlQueries.Delete_Pribytiya, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Kartochka, dataGridView1);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Insert_String();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
                Update_String();
            else
                MessageBox.Show("Невозможно отредактировать сразу несколько записей." + '\n' + "Пожалуйста выберите одну запись.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись(-и)?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Delete_String();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (identify != "kartochka" && identify != "pribytiya" && identify != "ubytiya")
                if (MessageBox.Show("Хотите отредактировать запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Update_String();
        }
    }
}
