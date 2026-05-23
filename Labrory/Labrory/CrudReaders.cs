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

namespace Labrory
{
    public partial class CrudReaders : Form
    {
        public string ConnectionString = "Server=localhost;Database=Labrory;User=root;Password=193166Nikita1987;";
        public string ID;

        public CrudReaders(string id)
        {
            InitializeComponent();
            ID = id;

            if (ID != "")
                LoadData();
        }

        void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                $"SELECT * FROM Readers WHERE ID_Reader = {ID}", conn);

                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    textBox1.Text = r["First_name"].ToString();
                    textBox2.Text = r["Last_name"].ToString();
                    textBox3.Text = r["Email"].ToString();
                    textBox4.Text = r["Phone"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(r["Registration_date"]);
                    textBox5.Text = r["Adress"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string sql;

                if (ID == "")
                    sql = $@"INSERT INTO Readers(First_name,Last_name,Email,Phone,Registration_date,Adress)
                    VALUES(N'{textBox1.Text}',N'{textBox2.Text}',N'{textBox3.Text}',N'{textBox4.Text}','{dateTimePicker1.Value:yyyy-MM-dd}',N'{textBox5.Text}')";
                else
                    sql = $@"UPDATE Readers SET
                        First_name=N'{textBox1.Text}',
                        Last_name=N'{textBox2.Text}',
                        Email=N'{textBox3.Text}',
                        Phone=N'{textBox4.Text}',
                        Registration_date = '{dateTimePicker1.Value:yyyy-MM-dd}',
                        Adress=N'{textBox5.Text}'
                        WHERE ID_Reader={ID}";

                new MySqlCommand(sql, conn).ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
