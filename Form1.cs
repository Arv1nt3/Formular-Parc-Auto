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
    public partial class Form1 : Form
    {
        public string connetionString = @"Data Source=EN1210516;Initial Catalog=Parc_Auto;User ID=ENDAVA\aarvinte;;Integrated Security=SSPI";
        public Form1()
        {
            InitializeComponent();
        }

        double total = 1;
        double pret = 1;

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            double.TryParse(textBox7.Text, out double j);
            pret = j;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            checkBox1.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox11.Text, out double i);
            total = pret * i;
            textBox10.Text = total.ToString() + " LEI";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            connetionString = @"Data Source=EN1210516;Initial Catalog=Parc_Auto;User ID=ENDAVA\aarvinte;;Integrated Security=SSPI";
            SqlConnection cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = ("Insert  into Masini values (@Nume,@Cod,@Numar,@Marca,@Serie,@Kilometraj,@Combustibil,@An,@Poluare,@Data,@Statie,@Minim,@Maxim,@Total)");
            cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cod", textBox2.Text);
            cmd.Parameters.AddWithValue("@Numar", textBox3.Text);
            cmd.Parameters.AddWithValue("@Marca", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Serie", textBox4.Text);
            cmd.Parameters.AddWithValue("@Kilometraj", textBox5.Text);
            cmd.Parameters.AddWithValue("Combustibil", comboBox4.Text);
            cmd.Parameters.AddWithValue("@An", textBox8.Text);
            cmd.Parameters.AddWithValue("@Poluare", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Data", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Statie", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Minim", textBox6.Text);
            cmd.Parameters.AddWithValue("@Maxim", textBox9.Text);
            cmd.Parameters.AddWithValue("@Total", total.ToString());
            cnn.Open();
            cmd.ExecuteNonQuery();
            allRecords();
            MessageBox.Show("Adaugat!");
            Reset();
            cnn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            allRecords();
        }

        public void allRecords()
        {
            SqlConnection conn = new SqlConnection(connetionString);
            SqlCommand cmdDataBase = new SqlCommand("Select Nume, Cod, Numar, Marca, Serie, Kilometraj, Combustibil, An, Poluare, Data, Statie, Minim, Maxim, Total from Masini ;", conn);

            load_table(cmdDataBase);
        }
    }
}
