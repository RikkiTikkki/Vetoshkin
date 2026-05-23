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
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Labrory
{
    public partial class CrudBooks : Form
    {
        public string ConnectionString ="Server=localhost;Database=Labrory;User=root;Password=193166Nikita1987;";
        public string ID;

        public CrudBooks(string id)
        {
            InitializeComponent();

            ID = id;

            LoadAuthors();

            if (ID != "")
                LoadData();
        }

        // Загрузка книги
        void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Books WHERE ID_Books = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    textBox1.Text = r["Title"].ToString();
                    textBox2.Text = r["ISBN"].ToString();
                    textBox3.Text = r["Publication_year"].ToString();
                    textBox4.Text = r["Price"].ToString();
                    comboBox1.SelectedValue = r["ID_Author"];
                }
            }
        }
        void LoadAuthors()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                MySqlDataAdapter da =new MySqlDataAdapter("SELECT * FROM Authors", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Last_name";
                comboBox1.ValueMember = "ID_Author";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                string sql;
                if (ID == "")
                {
                    sql = $@"INSERT INTO Books(Title, ISBN, Publication_year, Price, ID_Author)
                    VALUES
(Title, ISBN, Publication_year, Price, ID_Author)";
                }

                else
                {
                    sql = @"UPDATE Books SET
Title = @Title,
ISBN = @ISBN,
Publication_year = @Publication_year,
Price = @Price,
ID_Author = @ID_Author
WHERE ID_Books = @id";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Title", textBox1.Text);
                cmd.Parameters.AddWithValue("@ISBN", textBox2.Text);
                cmd.Parameters.AddWithValue("@Publication_year", textBox3.Text);
                cmd.Parameters.AddWithValue("@Price", textBox4.Text);
                cmd.Parameters.AddWithValue("@ID_Author", comboBox1.SelectedValue);

                if (ID != "")
                    cmd.Parameters.AddWithValue("@id", ID);

                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}