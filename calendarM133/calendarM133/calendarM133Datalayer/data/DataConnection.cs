using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace calendarM133BusinessAndData
{
    public class DataConnection
    {
        private static MySqlConnection mySqlConnection = new MySqlConnection();
        private static DataTable DoConnection(string query)
        {
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbschule;port=3306;logging=True;allowuservariables=True";
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            cmd.CommandText = query;
            mySqlConnection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            DataTable dataTable = new DataTable();
            ds.Tables.Add(dataTable);
            ds.EnforceConstraints = false;
            dataTable.Load(reader);
            reader.Close();
            return dataTable;
        }
        public static DataTable SelectAllPersons()
        {

            return DoConnection("Select * from tbAdresse");
        }
        public MySqlConnection MySqlConnection { get => mySqlConnection; set => mySqlConnection = value; }

        public void CloseConnection()
        {
            try
            {
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                mySqlConnection = null;
            }

        }
    }
}
