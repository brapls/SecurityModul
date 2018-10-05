using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using calendarM133BusinessData;
namespace calendarM133
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarLogger.addLog("New login");
        }

        protected void butLogin_Click(object sender, EventArgs e)
        {
            if (UserBusiness.UserLoggin(tbUsername.Text, tbPassword.Text))
                Response.Redirect("~/Default.aspx");
            else
                lblInvalidPassword.Visible = true;
        }

        protected void butRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }
    }
}