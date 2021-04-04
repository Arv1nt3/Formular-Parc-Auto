using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Formular_Parc_Auto
{
    public partial class Form2 : Form
    {
        public string connetionString = @"Data Source=DESKTOP-M48L6A9;Initial Catalog=Parc_Auto;User ID=DESKTOP-M48L6A9\Arvinte Alexandru;;Integrated Security=SSPI";
        public Form2()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sortRecords();
        }

        void load_table(SqlCommand cmdDataBase)
        {
            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmdDataBase;

            DataTable dbDataSet = new DataTable();
            sd.Fill(dbDataSet);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = dbDataSet;
            dataGridView1.DataSource = bSource;
            sd.Update(dbDataSet);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //set columns to readonly:
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataGridView1.Columns[column.Name].ReadOnly = true;
            }
        }

        public void sortRecords()
        {
            SqlConnection conn = new SqlConnection(connetionString);
            string sqlFormat = "yyyy-MM-dd HH:mm:ss.fff";
            //string query = "SELECT Nume, Cod, Numar, Marca, Serie, Kilometraj, Combustibil, An, Poluare, Data, Statie, Minim, Maxim, Total from Masini where Data between '" + dateTimePicker2.Value + "' AND'" + "'" + dateTimePicker3.Value + "'";
            String query = "SELECT Nume, Cod, Numar, Marca, Serie, Kilometraj, Combustibil, An, Poluare, Data, Statie, Minim, Maxim, Total from Masini where Data between '"
            + dateTimePicker2.Value.ToString(sqlFormat) + "' AND'"
            + dateTimePicker3.Value.ToString(sqlFormat) + "'";
            SqlCommand cmdDataBase = new SqlCommand(query, conn);



            load_table(cmdDataBase);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1(); //this is the change, code for redirect  
            f1.ShowDialog();
        }
    }
}
