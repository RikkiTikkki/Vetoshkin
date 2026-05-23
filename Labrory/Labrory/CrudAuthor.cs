using MySqlConnector;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labrory
{
    public partial class CrudAuthor : Form
    {
        public string ConnectionString = "Server=localhost;Database=Labrory;User=root;Password=193166Nikita1987;";
        public string ID;

        public CrudAuthor(string id)
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
                $"select * FROM Authors where ID_Author = {ID}", conn);

                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    textBox1.Text = r["First_name"].ToString();
                    textBox2.Text = r["Last_name"].ToString();
                    textBox3.Text = r["Birth_year"].ToString();
                    textBox4.Text = r["Country"].ToString();
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
                    sql = $@"INSERT INTO Authors(First_name,Last_name,Birth_year,Country)
VALUES(N'{textBox1.Text}',N'{textBox2.Text}',{textBox3.Text},N'{textBox4.Text}')";
                else
                    sql = $@"UPDATE Authors SET
                        First_name=N'{textBox1.Text}',
                        Last_name=N'{textBox2.Text}',
                        Birth_year={textBox3.Text},
                        Country=N'{textBox4.Text}'
                        WHERE ID_Author={ID}";

                new MySqlCommand(sql, conn).ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
