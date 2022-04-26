using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            runQuery(); // initalizing the query command
        }

        private void runQuery()
        {
            string query = richTextBox1.Text; 

            if (query == "")
            {
                MessageBox.Show("Invalid SQL query."); // catches invalid querys
                return;
            }

            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=testing;"; // connects to the local XAMPP Database (phpMyAdmin)

            MySqlConnection database = new MySqlConnection(MySQLConnectionString); // connects to database

            MySqlCommand command = new MySqlCommand(query, database); // commands the database
            command.CommandTimeout = 60;

            try
            {
                database.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Query results are available for use.");

                    while (reader.Read())
                    {                           //ID                       //first_name                 //last_name                    //address
                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3));
                    }
                }

                MessageBox.Show("Query execution was a success.");


            }catch(Exception e)
            {
                MessageBox.Show("Invalid query error."); // catches invalid querys as well
            }
        }
    }
}