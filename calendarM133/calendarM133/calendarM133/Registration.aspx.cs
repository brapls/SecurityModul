using calendarM133BusinessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calendarM133
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butRegistration_Click(object sender, EventArgs e)
        {
            String error = "";
            if(String.IsNullOrEmpty(tbUsername.Text))
            {
                error += "Please Fill in your username. \n ";
            }
            if (String.IsNullOrEmpty(tbPassword.Text))
            {
                error += "Please Fill in your password. \n ";
            }
            if(tbPassword.Text != tbPassword2.Text)
            {
                error += "Your password don't match. \n ";
            }
            if(error == "")
            {
                UserBusiness.CreateLoggin(tbUsername.Text, tbPassword.Text);
                Response.Redirect("~/Login.aspx", true);
            }
            lblErrors.Text = error;
        }

        protected void butLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", true);
        }
    }
}