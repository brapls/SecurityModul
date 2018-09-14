using calendarM133BusinessData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calendarM133
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Termin> invitedList = Termin.GetInvitedTermin();
                if(invitedList.Count == 0)
                {
                    invitedToSection.Visible = false;
                }
                foreach (Termin termin in invitedList) //fills drop down list inivited Termin with the subject as display name and the terminId as value
                {
                    ListItem listItem = new ListItem(termin.subject, termin.id.ToString());
                    ddlInvitedTermin.Items.Add(listItem);
                }
                gvInvited.DataSource = invitedList;
                gvInvited.DataBind();


                List<Termin> lisTermin = Termin.AllTerminOfCurrentUserAsList();
                lisTermin = lisTermin.OrderBy(o => o.starTime).ToList(); //order list by startdate
                lisTermin = lisTermin.Where(p => p.starTime >= DateTime.Today).ToList(); //Only display those termin, which weren't in the past
                gvCalendar.DataSource = lisTermin; // set lisTermin as source of the (gridview)-table
                gvCalendar.DataBind();
            }
        }
        /// <summary>
        /// let the user see all termin on a specific day, selected by calendar(calDayChoice)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void calDayChoice_SelectionChanged(object sender, EventArgs e)
        {
            DateTime date = calDayChoice.SelectedDate;
            List<Termin> lisTermin = Termin.AllTerminOfCurrentUserAsList();
            lisTermin = lisTermin.Where(p => p.starTime.Date == calDayChoice.SelectedDate).ToList();
            gvDailyCalendar.DataSource = lisTermin;
            gvDailyCalendar.DataBind();
        }
        /// <summary>
        /// invited termin accept
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            Termin.AcceptterminInvitation(int.Parse(ddlInvitedTermin.SelectedItem.Value), int.Parse(HttpContext.Current.Session["id"].ToString()));
            Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// invited termin rejected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReject_Click(object sender, EventArgs e)
        {
            Termin.DeletTerminInvitation(int.Parse(ddlInvitedTermin.SelectedItem.Value), int.Parse(HttpContext.Current.Session["id"].ToString()));
            Response.Redirect("~/Default.aspx");
        }
    }
}