using System;
using calendarM133BusinessData;
using log4net;

namespace calendarM133
{
    public partial class Login : System.Web.UI.Page
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Login));

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Debug("Login Seite geladen");
        }

        protected void butLogin_Click(object sender, EventArgs e)
        {
            if (UserBusiness.UserLoggin(tbUsername.Text, tbPassword.Text))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblInvalidPassword.Visible = true;
                Logger.Error("Falsches Passwort für den Account mit dem Username:" + tbUsername.Text);
            }
        }

        protected void butRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
            Logger.Debug("Wechsle zur Registrationsseite");
        }
    }
}
