using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class editRoles : System.Web.UI.Page
{

    private MembershipUserCollection users;
    private string selectedUser;
    private string[] roles;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.IsInRole("admin"))
            Response.Redirect("index.aspx"); //kaster alle andre enn admin tilbake til index.
        if(! IsPostBack)
        {
            //første gang siden blir åpnet lista på siden bli oppdatert med alle brukerne til bloggers
            users = Membership.GetAllUsers();
            this.listUsers.DataSource = users;
            this.listUsers.DataBind();

        }
        

            

       
    }


    protected void oppdater(object sender, EventArgs e)
    {
        if (listUsers.SelectedItem != null)
        {
            //oppdaterer brukeren med rollen 'admin' til view
            selectedUser = this.listUsers.SelectedItem.Value;
            roles = Roles.GetRolesForUser(selectedUser);
            this.checkbox1.Checked = Roles.IsUserInRole(selectedUser, "admin");           
        }
    }

    protected void toggleAdmin(object sender, EventArgs e)
    {
        if (listUsers.SelectedItem != null)
        {
            //kjører denne metoden for å oppdatere brukeren med rollen 'admin' eller ei
            selectedUser = this.listUsers.SelectedItem.Value;
            roles = Roles.GetRolesForUser(selectedUser);
            //User selected = Membership.GetUser(selectedUser);
            if (this.checkbox1.Checked)
            {
                Roles.AddUserToRole(selectedUser, "admin");
                this.lblHendelse.Text = selectedUser + " lagt til i rollen admin";
            }
            else
            {
                Roles.RemoveUserFromRole(selectedUser, "admin");
                this.lblHendelse.Text = selectedUser + " fjernet fra rollen admin";
            }
        }
    }
}
