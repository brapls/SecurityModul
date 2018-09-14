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
    public partial class AddPersonToTermin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set Termin-DropDownvalue start
                List<Termin> allTermin = Termin.AllTerminOfCurrentUserAsList();
                List<ListItem> allTerminListItem = new List<ListItem>();
                foreach (Termin termin in allTermin)
                {
                    ListItem listItem = new ListItem(termin.subject, termin.id.ToString());
                    ddlTerminSelection.Items.Add(listItem);
                }
                //ddlTerminSelection.DataSource = allTerminListItem;
                //ddlTerminSelection.DataBind();
                //Set Termin-DropDownvalue end

                //Set User-DropDownvalue start
                DataTable allUser = UserBusiness.GetAllUserIdAndUsername();
                List<ListItem> allUserListItem = new List<ListItem>();
                foreach (DataRow dr in allUser.Rows) {                   
                    ListItem listItem = new ListItem(dr["username"].ToString(), dr["userId"].ToString());
                    ddlPerson.Items.Add(listItem);
                }
                //ddlPerson.DataSource = allUserListItem;
                //ddlPerson.DataBind();
                //Set DropDownvalue end
            }
        }

        protected void btnTermin_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            if (ddlTerminSelection.SelectedValue == null)
                errorMessage += "Wählen Sie einen Termin aus \n";
            if (ddlPerson.SelectedValue == null)
                errorMessage += "Wählen Sie eine andere Person aus \n";
            if (errorMessage != "")
            {
                lblError.Text = errorMessage;
            }
            else
            {
                Termin.AddUserToTermin(int.Parse(ddlPerson.SelectedItem.Value), int.Parse(ddlTerminSelection.SelectedItem.Value));
                Response.Redirect("~/default.aspx");
            }
        }
    }
}