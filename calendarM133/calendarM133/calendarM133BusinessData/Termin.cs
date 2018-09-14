using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace calendarM133BusinessData
{
    public class Termin
    {
        public int id { get; set; }
        public DateTime starTime { get; set; }
        public DateTime endTime { get; set; }
        public string subject{ get; set; }
        public Termin() { }
        public Termin(int i, DateTime startTime, DateTime endTime, string sub)
        {
            this.id = i;
            this.starTime = startTime;
            this.endTime = endTime;
            this.subject = sub;
        }
        public static List<Termin> AllTerminOfCurrentUserAsList()
        {
            return DataConnection.AllTerminOfCurrentUserAsList();
        }

        public static List<Termin> GetInvitedTermin()
        {
            return DataConnection.AllInvitedTerminOfCurrentUserAsList();
        }

        public static void AddUserToTermin(int userId, int terminId)
        {
            DataConnection.AddUserToTermin(userId, terminId, 0);
        }

        public static void InsertTermin(string subject, DateTime starDate, DateTime endDate)
        {
            DataConnection.InsertTermin(subject, starDate, endDate, HttpContext.Current.Session["id"].ToString());
        }
        public static void DeletTerminInvitation(int terminId, int userId)
        {
            DataConnection.DeleteTerminFromMiddleTable(terminId, userId);
        }
        public static void AcceptterminInvitation(int terminId, int userId)
        {
            DataConnection.AcceptTermin(terminId, userId);
        }
        static void Main(string[] args)
        {
        }
    }
}
