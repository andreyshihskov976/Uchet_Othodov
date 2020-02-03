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

        private void Insert()
        {
            if (identify == "othody")
            {

            }
            else if (identify == "sotrudniki")
            {

            }
            else if (identify == "otdely")
            {

            }
            else if (identify == "organizacii")
            {

            }
            else if (identify == "kartochka")
            {

            }
        }

        private void Update()
        {
            if (identify == "othody")
            {

            }
            else if (identify == "sotrudniki")
            {

            }
            else if (identify == "otdely")
            {

            }
            else if (identify == "organizacii")
            {

            }
            else if (identify == "kartochka")
            {

            }
        }

        private void Delete()
        {
            if (identify == "othody")
            {

            }
            else if (identify == "sotrudniki")
            {

            }
            else if (identify == "otdely")
            {

            }
            else if (identify == "organizacii")
            {

            }
            else if (identify == "kartochka")
            {

            }
        }
    }
}
