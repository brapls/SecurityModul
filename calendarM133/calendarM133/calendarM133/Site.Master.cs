using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calendarM133
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //redirect handleing
            {
                if (!Request.Url.ToString().Contains("/Login") && !Request.Url.ToString().Contains("/Registration"))
                {
                    if (null == HttpContext.Current.Session["id"] || null == HttpContext.Current.Session["isLogged"])
                    {
                        Response.Redirect("~/Login.aspx", true);
                    }
                }
                else
                {
                    navigationMaster.Visible = false;
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx", true);
        }
    }
}