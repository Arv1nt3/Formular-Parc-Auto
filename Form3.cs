using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Data.SqlClient;

namespace Formular_Parc_Auto
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M48L6A9;Initial Catalog=Parc_Auto;User ID=DESKTOP-M48L6A9\Arvinte Alexandru;;Integrated Security=SSPI"); // making connection 
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Users WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else
                MessageBox.Show("Invalid username or password", "Error!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
        }
