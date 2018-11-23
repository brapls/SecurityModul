using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace calendarM133BusinessData
{
    internal class DataConnection
    {

        /// <summary>
        /// Gets userid by Username and Password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static int GetIdByUsernamePW(string username, string password)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbTermin;port=3306;logging=True;allowuservariables=True";
            /*MySqlCommand cmd = mySqlConnection.CreateCommand();
            cmd.CommandText = "Select userId from tbUser where username=@username && password=@password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);*/
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            cmd.CommandText = "spgetidbyusernamepw";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usernameParameter", username);
            cmd.Parameters["usernameParameter"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("passwordParameter", password);
            cmd.Parameters["passwordParameter"].Direction = ParameterDirection.Input;

            mySqlConnection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            DataTable dataTable = new DataTable();
            ds.Tables.Add(dataTable);
            ds.EnforceConstraints = false;
            dataTable.Load(reader);
            if (dataTable.Rows.Count < 1)
                return 0;
            int i = int.Parse(dataTable.Rows[0][0].ToString());
            mySqlConnection.Close();
            reader.Close();
            return i;
        }

        internal static void CreateLogging(string username, string password)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbTermin;port=3306;logging=True;allowuservariables=True";
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO tbuser (userId, username, password) VALUES (NULL, @username, @password)";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
        }

        internal static void InsertTermin(string subject, DateTime startdate, DateTime endDate, string creatorId)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbTermin;port=3306;logging=True;allowuservariables=True";
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            //cmd.CommandText = "INSERT INTO tbtermin (`terminId`, `terminSubject`, `StartDate`, `EndDate`) VALUES (NULL, " + subject + "," + startdate +"," + endDate +")";
            cmd.CommandText = "INSERT INTO tbtermin (`terminId`, `terminSubject`, `StartDate`, `EndDate`) VALUES (NULL, @subject, @startDate, @EndDate)";
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@startDate", startdate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
            string terminId = cmd.LastInsertedId.ToString();
            mySqlConnection.Close();
            AddUserToTermin(int.Parse(creatorId), int.Parse(terminId), 1);
        }
        /// <summary>
        /// Invite User to termin
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="terminId"></param>
        /// <param name="status">0=User did not accept 1=User created the termin our accepted</param>
        internal static void AddUserToTermin(int userId, int terminId, int status)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbTermin;port=3306;logging=True;allowuservariables=True";
            MySqlCommand cmd2 = mySqlConnection.CreateCommand();
            cmd2.CommandText = "INSERT INTO tbusertermin (`userId`, `terminId`, `isAccepted`) VALUES ( @userId, @terminId, @status);";
            cmd2.Parameters.AddWithValue("@userId", userId);
            cmd2.Parameters.AddWithValue("@terminId", terminId);
            cmd2.Parameters.AddWithValue("@status", status);
            mySqlConnection.Open();
            cmd2.ExecuteNonQuery();
        }
        /// <summary>
        /// gets all termin of the user logged in
        /// </summary>
        /// <returns></returns>
        internal static List<Termin> AllTerminOfCurrentUserAsList()
        {
            if (HttpContext.Current.Session["id"] == null)
            {
                return new List<Termin>();
            }
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost; user id=root; persistsecurityinfo=True; database=dbTermin; port=3306; logging=True; allowuservariables=True";
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            cmd.CommandText = "Select terminId from tbusertermin where userId = @userId";
            cmd.Parameters.AddWithValue("@userId", HttpContext.Current.Session["id"]);
            mySqlConnection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            DataTable dataTable = new DataTable();
            ds.Tables.Add(dataTable);
            ds.EnforceConstraints = false;
            dataTable.Load(reader);
            mySqlConnection.Close();
            if (dataTable.Rows.Count == 0)
                return new List<Termin>();
            String s = "Select * From tbTermin where ";
            foreach (DataRow dr in dataTable.Rows)
            {
                s += "terminId = " + dr["terminId"] + " || ";
            }
            s = s.Remove(s.ToCharArray().Length - 4);
            MySqlCommand cmdTerminSelection = mySqlConnection.CreateCommand();
            cmdTerminSelection.CommandText = s;
            mySqlConnection.Open();
            DataTable dataTable2 = new DataTable();
            MySqlDataReader reader2 = cmdTerminSelection.ExecuteReader();
            DataSet ds2 = new DataSet();
            ds2.Tables.Add(dataTable2);
            ds2.EnforceConstraints = false;
            dataTable2.Load(reader2);
            mySqlConnection.Close();
            //SELECT * FROM tbtermin where terminId = 1 || terminId = 2
            List<Termin> allTermin = new List<Termin>();
            foreach (DataRow dr in dataTable2.Rows)
            {
                //try {
                Termin t = new Termin();
                t.id = int.Parse(dr["terminId"].ToString());
                t.subject = dr["terminSubject"].ToString();
                t.starTime = DateTime.Parse(dr["StartDate"].ToString());
                t.endTime = DateTime.Parse(dr["EndDate"].ToString());
                allTermin.Add(t);
                //}
                //catch(Exception ex){
                //    //todo: add errorhandler            
                //}
            }

            return allTermin;
        }

        internal static List<Termin> AllInvitedTerminOfCurrentUserAsList()
        {
            if (HttpContext.Current.Session["id"] == null)
            {
                return new List<Termin>();
            }
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost; user id=root; persistsecurityinfo=True; database=dbTermin; port=3306; logging=True; allowuservariables=True";
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            cmd.CommandText = "Select terminId from tbusertermin where userId = @userId && isAccepted = 0";
            cmd.Parameters.AddWithValue("@userId", HttpContext.Current.Session["id"]);
            mySqlConnection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            DataTable dataTable = new DataTable();
            ds.Tables.Add(dataTable);
            ds.EnforceConstraints = false;
            dataTable.Load(reader);
            mySqlConnection.Close();
            if (dataTable.Rows.Count == 0)
                return new List<Termin>();
            String s = "Select * From tbTermin where ";
            foreach (DataRow dr in dataTable.Rows)
            {
                s += "terminId = " + dr["terminId"] + " || ";
            }
            s = s.Remove(s.ToCharArray().Length - 4);
            MySqlCommand cmdTerminSelection = mySqlConnection.CreateCommand();
            cmdTerminSelection.CommandText = s;
            mySqlConnection.Open();
            DataTable dataTable2 = new DataTable();
            MySqlDataReader reader2 = cmdTerminSelection.ExecuteReader();
            DataSet ds2 = new DataSet();
            ds2.Tables.Add(dataTable2);
            ds2.EnforceConstraints = false;
            dataTable2.Load(reader2);
            mySqlConnection.Close();
            //SELECT * FROM tbtermin where terminId = 1 || terminId = 2
            List<Termin> allTermin = new List<Termin>();
            foreach (DataRow dr in dataTable2.Rows)
            {
                //try {
                Termin t = new Termin();
                t.id = int.Parse(dr["terminId"].ToString());
                t.subject = dr["terminSubject"].ToString();
                t.starTime = DateTime.Parse(dr["StartDate"].ToString());
                t.endTime = DateTime.Parse(dr["EndDate"].ToString());
                allTermin.Add(t);
                //}
                //catch(Exception ex){
                //    //todo: add errorhandler            
                //}
            }

            return allTermin;
        }

        internal static DataTable GetAllUserIdAndUsername()
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbTermin;port=3306;logging=True;allowuservariables=True";
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            cmd.CommandText = "Select userId, username from tbUser";
            mySqlConnection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            DataTable dataTable = new DataTable();
            ds.Tables.Add(dataTable);
            ds.EnforceConstraints = false;
            dataTable.Load(reader);
            mySqlConnection.Close();
            reader.Close();
            return dataTable;
            //Dictionary<int, string> dictionary = new Dictionary<int, string>();
            //foreach(DataRow dr in dataTable.Rows)
            //{
            //    dictionary.Add(int.Parse(dr["userId"].ToString()), dr["username"].ToString());
            //}

            //return dictionary;
        }
        internal static void DeleteTerminFromMiddleTable(int terminId, int userId)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbTermin;port=3306;logging=True;allowuservariables=True";
            MySqlCommand cmd2 = mySqlConnection.CreateCommand();
            cmd2.CommandText = "DELETE FROM `tbusertermin` WHERE userId=@userid && terminId=@terminId";
            cmd2.Parameters.AddWithValue("@userId", userId);
            cmd2.Parameters.AddWithValue("@terminId", terminId);
            mySqlConnection.Open();
            cmd2.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        internal static void AcceptTermin(int terminId, int userId)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=dbTermin;port=3306;logging=True;allowuservariables=True";
            MySqlCommand cmd2 = mySqlConnection.CreateCommand();
            cmd2.CommandText = "UPDATE `tbusertermin` SET isAccepted=1 WHERE userId=@userId && terminId=@terminId";
            cmd2.Parameters.AddWithValue("@userId", userId);
            cmd2.Parameters.AddWithValue("@terminId", terminId);
            mySqlConnection.Open();
            cmd2.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}
