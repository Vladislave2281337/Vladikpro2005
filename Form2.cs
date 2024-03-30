using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Variant_1_Zhuk_ve
{
    public partial class Form2 : Form
    {
        public Form2(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public SqlConnection con;


        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source = stud-mssql.sttec.yar.ru,38325; initial catalog = user230_db; user id = user230_db; password = user230; MultipleActiveResultSets = True; App = EntityFramework";

            string imya = textBox1.Text;
            string familiya = textBox2.Text;
            string otchestvo = textBox3.Text;
            string data_rojdeniya = textBox4.Text;
            string data_rojdeniya2 = textBox5.Text;
            string data_rojdeniya3 = textBox6.Text;


            // Проверка наличия данных во всех полях
            if (string.IsNullOrEmpty(imya) || string.IsNullOrEmpty(familiya) || string.IsNullOrEmpty(otchestvo) || string.IsNullOrEmpty(data_rojdeniya) || string.IsNullOrEmpty(data_rojdeniya2) || string.IsNullOrEmpty(data_rojdeniya3))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Создание подключения к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Получение id_zavedeniya из таблицы zavedeniya


                    string query = "INSERT INTO Abiturient (Registr_nomer, Familia, Imya, Otchestvo, Data_rogdenia, Adres) VALUES (@Registr_nomer, @Familia, @Imya, @Otchestvo, @Data_rogdenia, @Adres)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Registr_nomer", imya);
                        command.Parameters.AddWithValue("@Familia", familiya);
                        command.Parameters.AddWithValue("@Imya", otchestvo);
                        command.Parameters.AddWithValue("@Otchestvo", data_rojdeniya);
                        command.Parameters.AddWithValue("@Data_rogdenia", data_rojdeniya2);
                        command.Parameters.AddWithValue("@Adres", data_rojdeniya3);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Данные успешно добавлены в базу данных.");
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    textBox4.Text = " ";
                    textBox5.Text = " ";
                    textBox6.Text = " ";
                    textBox7.Text = " ";
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при добавлении данных в базу данных: " + ex.Message);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "data source = stud-mssql.sttec.yar.ru,38325; initial catalog = user230_db; user id = user230_db; password = user230; MultipleActiveResultSets = True; App = EntityFramework";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    int idToDelete = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["Id_abiturient"].Value); // Замените "id" на имя вашего столбца с идентификатором

                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Abiturient WHERE Id_abiturient = @Id_abiturient"; // Замените "id" на имя вашего столбца с идентификатором
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Id_abiturient", idToDelete);
                        command.ExecuteNonQuery();

                        // Обновление dataGridView1 после удаления
                        dataGridView1.Rows.RemoveAt(selectedIndex);

                        MessageBox.Show("Данные успешно удалены из базы данных.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления данных: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите строку для удаления.");
                }
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            string connectionString = "data source = stud-mssql.sttec.yar.ru,38325; initial catalog = user230_db; user id = user230_db; password = user230; MultipleActiveResultSets = True; App = EntityFramework";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Отображение значения поля "nazvanie" в текстовом поле
                    textBox1.Text = selectedRow.Cells["Registr_nomer"].Value.ToString();
                    textBox2.Text = selectedRow.Cells["Familia"].Value.ToString();
                    textBox3.Text = selectedRow.Cells["Imya"].Value.ToString();
                    textBox4.Text = selectedRow.Cells["Otchestvo"].Value.ToString();
                    textBox5.Text = selectedRow.Cells["Data_rogdenia"].Value.ToString();
                    textBox6.Text = selectedRow.Cells["Adres"].Value.ToString();

                    // Изменение логики кнопки для сохранения изменений
                    button4.Text = "Сохранить изменения";
                    button4.Click -= button4_Click;
                    button4.Click += UpdateData2;
                }
            }
        }

        private void UpdateData2(object sender, EventArgs e)
        {
            string connectionString = "data source = stud-mssql.sttec.yar.ru,38325; initial catalog = user230_db; user id = user230_db; password = user230; MultipleActiveResultSets = True; App = EntityFramework";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Получение id записи для обновления
                int id_privivki = Convert.ToInt32(selectedRow.Cells["id_abiturient"].Value);

                // Обновление данных в базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "UPDATE Abiturient SET Registr_nomer=@Registr_nomer, Familia=@Familia, Imya=@Imya, Otchestvo= @Otchestvo, Data_rogdenia = @Data_rogdenia, Adres = @Adres where id_abiturient = @id_abiturient";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Registr_nomer", textBox1.Text);
                            command.Parameters.AddWithValue("@Familia", textBox2.Text);
                            command.Parameters.AddWithValue("@Imya", textBox3.Text);
                            command.Parameters.AddWithValue("@Otchestvo", textBox4.Text);
                            command.Parameters.AddWithValue("@Data_rogdenia", textBox5.Text);
                            command.Parameters.AddWithValue("@Adres", textBox6.Text);
                            command.Parameters.AddWithValue("@id_abiturient", id_privivki);

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Данные успешно обновлены в базе данных.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка при обновлении данных в базе данных: " + ex.Message);
                    }
                }

                // Сброс состояния кнопки
                button4.Text = "Редактировать";
                button4.Click -= UpdateData2;
                button4.Click += button4_Click;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
                {
                    DialogResult = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        String quesrtString = @"insert into Abiturient (Registr_nomer, Familia, Imya, Otchestvo, Data_rogdenia, Adres) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Convert.ToDateTime(textBox5.Text) + "','" + textBox6.Text + "');";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        dataGridView1.Rows.Clear();
                        quesrtString = @"select * from Abiturient;";
                        con.Open();
                        SqlCommand table = new SqlCommand(quesrtString, con);
                        SqlDataReader reader = table.ExecuteReader();
                        int i = 0;
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows.Add();
                            dataGridView1[0, i].Value = reader[0];
                            dataGridView1[1, i].Value = reader[1];
                            dataGridView1[2, i].Value = reader[2];
                            dataGridView1[3, i].Value = reader[3];
                            dataGridView1[4, i].Value = reader[4];
                            dataGridView1[5, i].Value = reader[5];
                            dataGridView1[6, i].Value = reader[6];
                                           
                            i++;
                        }
                        reader.Close();
                        con.Close();
                    }
                    else
                    {
                        dataGridView1[1, dataGridView1.RowCount].Value = "";
                        textBox9.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Не введено какое-то значение!");
                }
                checkBox1.Checked = false;
            }
            if (checkBox2.Checked == true)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (textBox9.Text != "")
                    {
                        String quesrtString = @"update Abiturient set Registr_nomer ='" + textBox1.Text + "'where Id_abiturient ='" + textBox9.Text + "'";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        textBox1.Text = "";
                    }
                    if (textBox2.Text != "")
                    {
                        String quesrtString = @"update Abiturient set Familia ='" + textBox2.Text + "'where Id_abiturient ='" + textBox9.Text + "'";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        textBox2.Text = "";
                    }
                    if (textBox3.Text != "")
                    {
                        String quesrtString = @"update Abiturient set Imya ='" + textBox3.Text + "'where Id_abiturient ='" + textBox9.Text + "'";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        textBox3.Text = "";
                    }
                    if (textBox4.Text != "")
                    {
                        String quesrtString = @"update Abiturient set Otchestvo ='" + textBox4.Text + "'where Id_abiturient ='" + textBox9.Text + "'";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        textBox4.Text = "";
                    }
                    if (textBox5.Text != "")
                    {
                        String quesrtString = @"update Abiturient set Data_rogdenia ='" + textBox5.Text + "'where Id_abiturient ='" + textBox9.Text + "'";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        textBox5.Text = "";
                    }
                   
                    if (textBox6.Text != "")
                    {
                        String quesrtString = @"update Abiturient set Adres ='" + textBox6.Text + "'where Id_abiturient ='" + textBox9.Text + "'";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        textBox6.Text = "";
                    }
                    if (textBox7.Text != "")
                    {
                        String quesrtString = @"update Abiturient set adres_avtora ='" + textBox7.Text + "'where Id_abiturient ='" + textBox9.Text + "'";
                        SqlCommand insert = new SqlCommand(quesrtString, con);
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();
                        textBox7.Text = "";
                    }
                   
                    dataGridView1.Rows.Clear();
                    con.Open();
                    String quertString1 = @"select * from Abiturient;";
                    SqlCommand table = new SqlCommand(quertString1, con);
                    SqlDataReader reader = table.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, i].Value = reader[0];
                        dataGridView1[1, i].Value = reader[1];
                        dataGridView1[2, i].Value = reader[2];
                        dataGridView1[3, i].Value = reader[3];
                        dataGridView1[4, i].Value = reader[4];
                        dataGridView1[5, i].Value = reader[5];
                        dataGridView1[6, i].Value = reader[6];
                        dataGridView1[9, i].Value = reader[9];
                        i++;
                    }
                    reader.Close();
                    con.Close();
                    textBox9.Text = "";
                }
                else
                {
                    MessageBox.Show("Не введено значение категории!");
                }
                checkBox2.Checked = false;
                textBox9.Text = "";
            }
            if (checkBox3.Checked == true)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения в БД?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    String quesrtString = @"delete from Abiturient where Id_abiturient='" + textBox9.Text + "'";
                    SqlCommand insert = new SqlCommand(quesrtString, con);
                    con.Open();
                    insert.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Rows.Clear();
                    quesrtString = @"select * from Abiturient;";
                    con.Open();
                    SqlCommand table = new SqlCommand(quesrtString, con);
                    SqlDataReader reader = table.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows.Add();
                        dataGridView1[0, i].Value = reader[0];
                        dataGridView1[1, i].Value = reader[1];
                        dataGridView1[2, i].Value = reader[2];
                        dataGridView1[3, i].Value = reader[3];
                        dataGridView1[4, i].Value = reader[4];
                        dataGridView1[5, i].Value = reader[5];
                        dataGridView1[6, i].Value = reader[6];
                        dataGridView1[7, i].Value = reader[7];
                        dataGridView1[8, i].Value = reader[8];
                        dataGridView1[9, i].Value = reader[9];
                        i++;
                    }
                    reader.Close();
                    con.Close();
                    textBox9.Text = "";
                }
                if (result == DialogResult.No)
                {
                    dataGridView1.Rows.Clear();
                    con.Open();
                    String quertString = @"select * from Abiturient;";
                    SqlCommand table = new SqlCommand(quertString, con);
                    SqlDataReader reader = table.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, i].Value = reader[0];
                        dataGridView1[1, i].Value = reader[1];
                        dataGridView1[2, i].Value = reader[2];
                        dataGridView1[3, i].Value = reader[3];
                        dataGridView1[4, i].Value = reader[4];
                        dataGridView1[5, i].Value = reader[5];
                        dataGridView1[6, i].Value = reader[6];
                        dataGridView1[9, i].Value = reader[9];
                        i++;
                    }
                    reader.Close();
                    con.Close();
                    textBox9.Text = "";
                }
                checkBox3.Checked = false;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "data source = stud-mssql.sttec.yar.ru,38325; initial catalog = user230_db; user id = user230_db; password = user230; MultipleActiveResultSets = True; App = EntityFramework";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id_abiturient, Registr_nomer, Familia, Imya, Otchestvo, Data_rogdenia, Adres FROM Abiturient";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}




