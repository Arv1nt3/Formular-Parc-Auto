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
        DataSet ds1;
        DataSet ds2;
        DataSet ds3;
        DataSet ds4;
        DataSet ds5;

        public string connetionString = @"Data Source=DESKTOP-M48L6A9;Initial Catalog=Parc_Auto;User ID=DESKTOP-M48L6A9\Arvinte Alexandru;;Integrated Security=SSPI";
        public Form1()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-M48L6A9;Initial Catalog=Parc_Auto;User ID=DESKTOP-M48L6A9\Arvinte Alexandru;;Integrated Security=SSPI";
            conn.Open();

            SqlDataAdapter daNumar = new SqlDataAdapter("SELECT Numar FROM Masini", conn);
            ds1 = new DataSet();
            daNumar.Fill(ds1, "daNumar");
            ListU.ValueMember = "Numar";
            ListU.DataSource = ds1.Tables["daNumar"];
            ListU.DropDownStyle = ComboBoxStyle.DropDownList;
            ListU.Enabled = true;
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
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
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
            connetionString = @"Data Source=DESKTOP-M48L6A9;Initial Catalog=Parc_Auto;User ID=DESKTOP-M48L6A9\Arvinte Alexandru;;Integrated Security=SSPI";
            SqlConnection cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = ("Insert  into Records values (@Nume,@Cod,@Numar,@Marca,@Serie,@Kilometraj,@Combustibil,@An,@Poluare,@Data,@Statie,@Minim,@Maxim,@Total)");
            cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cod", textBox2.Text);
            cmd.Parameters.AddWithValue("@Numar", ListU.Text);
            cmd.Parameters.AddWithValue("@Marca", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Serie", comboBox5.Text);
            cmd.Parameters.AddWithValue("@Kilometraj", textBox5.Text);
            cmd.Parameters.AddWithValue("Combustibil", comboBox4.Text);
            cmd.Parameters.AddWithValue("@An", comboBox6.Text);
            cmd.Parameters.AddWithValue("@Poluare", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Data", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Statie", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Minim", textBox6.Text);
            cmd.Parameters.AddWithValue("@Maxim", textBox9.Text);
            cmd.Parameters.AddWithValue("@Total", total);
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
            SqlCommand cmdDataBase = new SqlCommand("Select Nume, Cod, Numar, Marca, Serie, Kilometraj, Combustibil, An, Poluare, Data, Statie, Minim, Maxim, Total from Records ;", conn);

            load_table(cmdDataBase);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-M48L6A9;Initial Catalog=Parc_Auto;User ID=DESKTOP-M48L6A9\Arvinte Alexandru;;Integrated Security=SSPI";
            conn.Open();
            ds1 = new DataSet();

            SqlDataAdapter daMarca = new SqlDataAdapter("SELECT Marca FROM Masini WHERE Numar='" + ListU.Text + "'", conn);
            daMarca.Fill(ds1, "daMarca");
            comboBox1.ValueMember = "Marca";
            comboBox1.DataSource = ds1.Tables["daMarca"];
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = true;

            SqlDataAdapter daSerie = new SqlDataAdapter("SELECT Serie FROM Masini WHERE Numar='" + ListU.Text + "'", conn);
            daSerie.Fill(ds1, "daSerie");
            comboBox5.ValueMember = "Serie";
            comboBox5.DataSource = ds1.Tables["daSerie"];
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.Enabled = true;

            SqlDataAdapter daCombustibil = new SqlDataAdapter("SELECT Combustibil FROM Masini WHERE Numar='" + ListU.Text + "'", conn);
            daCombustibil.Fill(ds1, "daCombustibil");
            comboBox4.ValueMember = "Combustibil";
            comboBox4.DataSource = ds1.Tables["daCombustibil"];
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Enabled = true;

            SqlDataAdapter daPoluare = new SqlDataAdapter("SELECT Poluare FROM Masini WHERE Numar='" + ListU.Text + "'", conn);
            daPoluare.Fill(ds1, "daPoluare");
            comboBox2.ValueMember = "Poluare";
            comboBox2.DataSource = ds1.Tables["daPoluare"];
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Enabled = true;

            SqlDataAdapter daAn = new SqlDataAdapter("SELECT An FROM Masini WHERE Numar='" + ListU.Text + "'", conn);
            daAn.Fill(ds1, "daAn");
            comboBox6.ValueMember = "An";
            comboBox6.DataSource = ds1.Tables["daAn"];
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.Enabled = true;
        }
        }
    }