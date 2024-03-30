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

namespace Variant_1_Zhuk_ve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "data source=stud-mssql.sttec.yar.ru, 38325; initial catalog=user230_db;persist security info=True;user id=user230_db;password=user230;MultipleActiveResultSets=";
            string comm = "SELECT Login,Password FROM Polzovatel WHERE Login='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
            string log = "";
            string pass = "";
            SqlConnection sqlconnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand(comm, sqlconnection);
            sqlconnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            while (sqlDataReader.Read())
            {
                log = sqlDataReader.GetString(0);
                pass = sqlDataReader.GetString(1);
            }
            if ((log == textBox1.Text) && (pass == textBox2.Text))
            {
                Form2 form2 = new Form2(sqlconnection);
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы не авторизовались!");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.Orange;
        }
    }
}
