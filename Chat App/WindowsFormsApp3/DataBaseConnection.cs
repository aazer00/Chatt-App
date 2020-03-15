using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    class DataBaseConnection
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DataBaseConnection()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "whatsapp";
            uid = "root";
            password = "0506700680aa";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert(string query)
        {

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Update(string query)
        {
            //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public List<string>[] Select(string[] columns, string query)
        {


            List<string>[] list = new List<string>[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                list[i] = new List<string>();
            }



            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //MessageBox.Show("sd");
                    for (int i = 0; i < columns.Length; i++)
                    {
                        list[i].Add(dataReader[columns[i]] + "");
                    }

                }

                dataReader.Close();

                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        public int Count(string query)
        {
            //string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                Count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public int table_exist(string table_name)
        {
            int Count = -1;
            string query = @"SELECT count(table_name)
                            FROM information_schema.tables
                            WHERE table_schema = 'whatsapp'
                            AND table_name = '" + table_name + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                Count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
        public void create_table(string name)
        {
            string query = @"CREATE TABLE `"+name+@"` (
                             `id` int(11) NOT NULL AUTO_INCREMENT,
                             `message` varchar(30) DEFAULT NULL,
                             `yazan` varchar(20) DEFAULT NULL,
                             `status` int(11) DEFAULT NULL,
                             PRIMARY KEY (`id`)
                            ) ";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}
