using MySqlConnector;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Labrory
{
    public partial class Form1 : Form
    {
        string connStr = "Server=localhost;Database=Labrory;User=root;Password=193166Nikita1987;";

        public void LoadTable(string sql, string table, DataGridView DG)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlDataAdapter DA = new MySqlDataAdapter(sql, conn);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet, table);
                DG.DataSource = dataSet.Tables[0];
                conn.Close();
            }
        }
       
        public void LoadAuthors()
        {
            string sql = @"SELECT 
                            ID_Author AS `ID автора`, 
                            First_name AS `Имя`,
                            Last_name AS `Фамилия`,
                            Birth_year AS `Год рождения`,
                            Country AS `Страна` 
                            FROM Authors";

            LoadTable(sql, "Authors", dataGridView1);
        }

        public void LoadBooks()
        {
            string sql = @"SELECT 
                            Books.ID_Books AS `ID Книги`,
                            Books.Title AS `Название`,
                            Books.ISBN AS `ISBN`,
                            Books.Publication_year AS `Год публикации`,
                            Books.Price AS `Цена`,
                            Authors.First_name AS `Имя автора`,
                            Authors.Last_name AS `Фамилия автора`
                            FROM Books
                            INNER JOIN Authors ON Books.ID_Author = Authors.ID_Author";

            LoadTable(sql, "Books", dataGridView1);
        }

        public void LoadReaders()
        {
            string sql = @"SELECT 
                            ID_Reader AS `ID читателя`, 
                            First_name AS `Имя`,
                            Last_name AS `Фамилия`,
                            Email AS `Электронная почта`,
                            Phone AS `Телефон`,
                            Registration_date AS `Дата регистрации`,
                            Adress AS `Адрес`
                            FROM Readers";

            LoadTable(sql, "Readers", dataGridView1);
        }

        public void LoadBookLoans()
        {
            string sql = @"SELECT 
                            BookLoans.ID_BookLoans AS `ID Брони`,
                            Books.Title AS `Название книги`,
                            Readers.First_name AS `Имя читателя`,
                            Readers.Last_name AS `Фамилия читателя`,
                            BookLoans.Loan_date AS `Дата брони`,
                            BookLoans.Due_date AS `Срок сдачи`,
                            BookLoans.Return_date AS `Дата сдачи`,
                            BookLoans.Loan_status AS `Статус брони`,
                            BookLoans.Fine_amount AS `Штраф просрочки` 
                            FROM BookLoans
                            INNER JOIN Readers ON BookLoans.ID_Reader = Readers.Id_Reader
                            INNER JOIN Books ON BookLoans.ID_Books = Books.Id_Books";

            LoadTable(sql, "BookLoans", dataGridView1);
        }



        public Form1()
        {
            InitializeComponent();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Книги":
                    LoadBooks();
                    break;

                case "Авторы":
                    LoadAuthors();
                    break;

                case "Читатели":
                    LoadReaders();
                    break;

                case "Брони":
                    LoadBookLoans();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                string ID = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                DialogResult DR = MessageBox.Show($"Вы уверены, что хотите удалить запись {ID}?","Сообщение",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (DR == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string sql = "";
                        if (comboBox1.Text == "Книги")
                            sql = $@"delete from `Books` where `ID_Books` = '{ID}'";
                        if (comboBox1.Text == "Авторы")
                            sql = $@"delete from `Authors` where `ID_Author` = '{ID}'";
                        if (comboBox1.Text == "Читатели")
                            sql = $@"delete from `Readers` where `ID_Reader` = '{ID}'";
                        if (comboBox1.Text == "Брони")
                            sql = $@"delete from `BookLoans` where `ID_BookLoans` = '{ID}'";
                        if (string.IsNullOrWhiteSpace(sql))
                        {
                            MessageBox.Show("Не выбран тип записи для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        if (comboBox1.Text == "Книги")
                            LoadBooks();
                        if (comboBox1.Text == "Авторы")
                            LoadAuthors();
                        if (comboBox1.Text == "Читатели")
                            LoadReaders();
                        if (comboBox1.Text == "Брони")
                            LoadBookLoans();
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);


                if (comboBox1.Text == "Книги")
                {
                    CrudBooks F2 =
                    new CrudBooks(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadBooks();
                }

                if (comboBox1.Text == "Авторы")
                {
                    CrudAuthor F2 =
                    new CrudAuthor(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadAuthors();
                }


                if (comboBox1.Text == "Читатели")
                {
                    CrudReaders F2 =
                    new CrudReaders(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadReaders();
                }


                if (comboBox1.Text == "Брони")
                {
                    CrudBookLoans F2 =
                    new CrudBookLoans(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadBookLoans();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = "";

                if (comboBox1.Text == "Книги")
                {
                    CrudBooks F2 =
                    new CrudBooks(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadBooks();
                }

                if (comboBox1.Text == "Авторы")
                {
                    CrudAuthor F2 =
                    new CrudAuthor(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadAuthors();
                }

                if (comboBox1.Text == "Читатели")
                {
                    CrudReaders F2 =
                    new CrudReaders(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadReaders();
                }

                if (comboBox1.Text == "Брони")
                {
                    CrudBookLoans F2 =
                    new CrudBookLoans(id);

                    if (F2.ShowDialog() ==
                    DialogResult.OK)

                        LoadBookLoans();
                }
            }
        }
    }
}