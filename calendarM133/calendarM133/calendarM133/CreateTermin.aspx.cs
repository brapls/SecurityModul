using calendarM133BusinessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calendarM133
{
    public partial class CreateTermin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //calender gets set to unrealistic values, so the error check would get triggered in btnCreateTermin_Click if one of the calendars aren't re-set by the user
                calStartDate.SelectedDate = DateTime.Parse("12.12.3000");
                calEndDate.SelectedDate = DateTime.Parse("12.12.1000");
            }
        }
        /// <summary>
        /// Creates Termin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateTermin_Click(object sender, EventArgs e)
        {
            String errorMessage = "";
            if (String.IsNullOrEmpty(tbSubject.Text))
                errorMessage += "Geben Sie den Betreff ein. ";
            if (DateTime.Parse(calStartDate.SelectedDate.ToString()) > DateTime.Parse(calEndDate.SelectedDate.ToString()))
                errorMessage += "Bitte wählen Sie ein gültiges Startdatum und Enddatum aus.";
            if (errorMessage == "")//all values are valid
            {
                Termin.InsertTermin(tbSubject.Text, calStartDate.SelectedDate, calEndDate.SelectedDate);
                Response.Redirect("~/Default.aspx", true);
            }
            lblTerminCreateError.Text = errorMessage;
        }
    }
}