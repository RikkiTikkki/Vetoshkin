using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Labrory
{
    public partial class CrudBookLoans : Form
    {
        public string ConnectionString =
        "Server=localhost;Database=Labrory;User=root;Password=193166Nikita1987;";

        public string ID;

        public CrudBookLoans(string id)
        {
            InitializeComponent();

            ID = id;

            dateTimePicker2.ShowCheckBox = true;
            dateTimePicker2.Checked = false;

            LoadBooks();
            LoadReaders();

            if (ID != "")
            {
                LoadData();
            }
        }

        void LoadBooks()
        {
            using (MySqlConnection conn =
            new MySqlConnection(ConnectionString))
            {
                conn.Open();

                MySqlDataAdapter da =
                new MySqlDataAdapter(
                "SELECT * FROM Books", conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Title";
                comboBox1.ValueMember = "ID_Books";
            }
        }

        void LoadReaders()
        {
            using (MySqlConnection conn =
            new MySqlConnection(ConnectionString))
            {
                conn.Open();

                MySqlDataAdapter da =
                new MySqlDataAdapter(
                "SELECT * FROM Readers", conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Last_name";
                comboBox2.ValueMember = "ID_Reader";
            }
        }

        void LoadData()
        {
            using (MySqlConnection conn =
            new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string sql =
                $"SELECT * FROM BookLoans WHERE ID_BookLoans = {ID}";

                MySqlCommand cmd =
                new MySqlCommand(sql, conn);

                MySqlDataReader r =cmd.ExecuteReader();

                if (r.Read())
                {
                    comboBox1.SelectedValue =r["ID_Books"];
                    comboBox2.SelectedValue =r["ID_Reader"];
                    dateTimePicker1.Value =Convert.ToDateTime(r["Due_date"]);
                    if (r["Return_date"] != DBNull.Value)
                    {
                        dateTimePicker2.Value =Convert.ToDateTime(r["Return_date"]);
                        dateTimePicker2.Checked = true;
                    }
                    else
                    {
                        dateTimePicker2.Checked = false;
                    }
                    comboBox3.Text =r["Loan_status"].ToString();
                    textBox1.Text =r["Fine_amount"].ToString();
                }
            }
        }

        private void button1_Click
        (object sender, EventArgs e)
        {
            using (MySqlConnection conn =
            new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string returnDate;

                if (dateTimePicker2.Checked)
                {
                    returnDate =
                    $"'{dateTimePicker2.Value:yyyy-MM-dd}'";
                }
                else
                {
                    returnDate = "NULL";
                }

                string sql;


                if (ID == "")
                {
                    sql = $@"INSERT INTO BookLoans(ID_Books,ID_Reader,Loan_date,Due_date,Return_date,Loan_status,Fine_amount)
                    VALUES({comboBox1.SelectedValue},{comboBox2.SelectedValue},'{DateTime.Now:yyyy-MM-dd}','{dateTimePicker1.Value:yyyy-MM-dd}',{returnDate},'{comboBox3.Text}',{textBox1.Text})";
                }
                else
                {
                    sql = $@"UPDATE BookLoans SET ID_Books = {comboBox1.SelectedValue},ID_Reader ={comboBox2.SelectedValue},Due_date ='{dateTimePicker1.Value:yyyy-MM-dd}',

Return_date ={returnDate},

Loan_status ='{comboBox3.Text}',

Fine_amount ={textBox1.Text}

WHERE ID_BookLoans = {ID}";
                }

                MySqlCommand cmd =
                new MySqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}