using calendarM133BusinessData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace calendarM133BusinessData
{
    public class UserBusiness
    {
        public static bool UserLoggin(string username, string password)
        {
            HttpContext.Current.Session["id"] = DataConnection.GetIdByUsernamePW(username, password);
            if ((int)HttpContext.Current.Session["id"] != 0){
                HttpContext.Current.Session["isLogged"] = true;
                HttpContext.Current.Session["username"] = username;
                return true;
            }
            return false;
        }
        public static void CreateLoggin(string username, string password)
        {
            DataConnection.CreateLogging(username, password);
        }

        public static DataTable GetAllUserIdAndUsername() {
            return DataConnection.GetAllUserIdAndUsername();
        }
    }
}
