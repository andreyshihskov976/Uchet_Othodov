using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace Uchet_othodov
{
    public class MySqlOperations
    {
        public MySqlConnection mySqlConnection = new MySqlConnection("server=localhost; user=root; database=uchet_othodov; port=3306; password=; charset=utf8;");

        public MySqlQueries MySqlQueries = null;

        MySqlDataReader sqlDataReader = null;

        MySqlDataAdapter dataAdapter = null;

        DataSet dataSet = null;

        MySqlCommand sqlCommand = null;

        public MySqlOperations(MySqlQueries sqlQueries)
        {
            this.MySqlQueries = sqlQueries;
        }
        //Подключение (Закрытие подключения) к Базе Данных
        public void OpenConnection()
        {
            mySqlConnection.Open();
        }
        public void CloseConnection()
        {
            mySqlConnection.Close();
        }
        //Подключение (Закрытие подключения) к Базе Данных

        //Универсальные методы
        public void Select_DataGridView(string query, DataGridView dataGridView, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null)
        {
            try
            {
                dataGridView.DataSource = null;
                dataSet = new DataSet();
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                dataAdapter = new MySqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataSet);
                dataGridView.DataSource = dataSet.Tables[0].DefaultView;
                dataGridView.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Select_ComboBox(string query, ComboBox comboBox)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox.Items.Add(Convert.ToString(sqlDataReader[0]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                if (comboBox.Items.Count != 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }
        
        public void Search_In_ComboBox(string In, ComboBox comboBox)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString() == In)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        public void Search_In_ComboBox_Identify(string Identify, ComboBox comboBox)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString().Contains(Identify))
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        public string Select_ID_From_ComboBox(string query, string Value1)
        {
            string ID = null;
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ID = Convert.ToString(sqlDataReader[0]);
                    break;
                }
                return ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();

            }

        }

        public void Delete(string query, string ID)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно удалить запись(-и)." + '\n' + "Возможно она(-и) используются в других записях.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Select_Text(string query, ref string output, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null, string Value4 = null, string Value5 = null, string Value6 = null, string Value7 = null, string Value8 = null)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                sqlCommand.Parameters.AddWithValue("Value4", Value4);
                sqlCommand.Parameters.AddWithValue("Value5", Value5);
                sqlCommand.Parameters.AddWithValue("Value6", Value6);
                sqlCommand.Parameters.AddWithValue("Value7", Value7);
                sqlCommand.Parameters.AddWithValue("Value8", Value8);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    output = Convert.ToString(sqlDataReader[0]);
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
            }
        }

        public void Insert_Update(string query, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null, string Value4 = null, string Value5 = null, string Value6 = null, string Value7 = null, string Value8 = null)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                sqlCommand.Parameters.AddWithValue("Value4", Value4);
                sqlCommand.Parameters.AddWithValue("Value5", Value5);
                sqlCommand.Parameters.AddWithValue("Value6", Value6);
                sqlCommand.Parameters.AddWithValue("Value7", Value7);
                sqlCommand.Parameters.AddWithValue("Value8", Value8);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Операция выполнена успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Search(ToolStripTextBox textBox, DataGridView dataGridView)
        {
            if (textBox.Text != "")
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    dataGridView.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                            if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox.Text))
                            {
                                dataGridView.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            else dataGridView.ClearSelection();
        }

        //Универсальные методы


        //Методы печати

        public void Print_Passport(MySqlQueries mySqlQueries, SaveFileDialog saveFileDialog, string ID = null)
        {
            ExcelApplication ExcelApp = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            string output = null;
            string fileName = null;
            Select_Text(mySqlQueries.Select_Kartochka_Passport, ref output, ID);
            saveFileDialog.Title = "Сохранить сопроводительный паспорт как";
            saveFileDialog.FileName = "Сопроводительный паспорт за " + output.Split(';')[0] + " (" + output.Split(';')[1] + ')';
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Отчеты\\";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                try
                {
                    ExcelApp = new ExcelApplication();
                    workbooks = ExcelApp.Workbooks;
                    workbook = workbooks.Open(Application.StartupPath + "\\Blanks\\Passport.xlsx");
                    ExcelApp.Cells[15, 4] = ID;
                    ExcelApp.Cells[15, 6] = output.Split(';')[0];
                    ExcelApp.Cells[21, 10] = output.Split(';')[2];
                    ExcelApp.Cells[24, 6] = output.Split(';')[3];
                    workbook.SaveAs(fileName);
                    ExcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(ExcelApp);
                }
            }
        }

        public void Print_Vedomost(MySqlQueries mySqlQueries, SaveFileDialog saveFileDialog, DataGridView dataGridView, string ID = null)
        {
            ExcelApplication ExcelApp = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            string output = null;
            string fileName = null;
            Select_DataGridView(mySqlQueries.Select_Kartochka_Vedomost, dataGridView, ID);
            Select_Text(mySqlQueries.Select_Otdely_ComboBox_by_ID, ref output, ID);
            saveFileDialog.Title = "Сохранить ведомость как";
            saveFileDialog.FileName = "Ведомость отходов " + output;
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Отчеты\\";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                try
                {
                    ExcelApp = new ExcelApplication();
                    workbooks = ExcelApp.Workbooks;
                    workbook = workbooks.Open(Application.StartupPath + "\\Blanks\\Vedomost.xlsx");
                    int ExCol = 1;
                    int ExRow = 9;
                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            ExcelApp.Cells[ExRow, ExCol] = dataGridView.Rows[i].Cells[j].Value.ToString();
                            ExCol++;
                        }
                        ExCol = 1;
                        ExRow++;
                    }
                    workbook.SaveAs(fileName);
                    ExcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(ExcelApp);
                }
            }
        }

        //Методы печати
    }
}
