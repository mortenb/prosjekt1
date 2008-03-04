using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using myApp.Model;
using myApp.IBLL;
//testkommentar
public partial class _Default : System.Web.UI.Page
{
    private IUserBLL userBLL = BLLLoader.GetUserBLL();
    private INyhetBLL nyhetBLL = BLLLoader.GetNyhetBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView_users_DataBind();
        }
    }

    private void GridView_users_DataBind()
    {
        try
        {
            GridView_users.DataSource = nyhetBLL.getNyheter();
            GridView_users.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<h1>Remember datasource path</h1>");
            Trace.Warn("DATA ACCESS", "Get all users failed!", ex);
        }
    }

    /// <summary>
    /// The kode in the event handler shuld be as small as possible.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_Adduser_Click(object sender, EventArgs e)
    {
        string firstname = TextBox_Firstname.Text,
               lastname = TextBox_Lastname.Text,
               username = TextBox_Username.Text,
               password = TextBox_Password.Text;

        User user = new User();
        user.Firstname = firstname;
        user.Lastname = lastname;
        user.Username = username;
        user.Password = password;

        try
        {
            /*
             *  The web page does not need to know how this is done in the lover layers.
           
            userBLL.AddUser(user);
              */
            // Clear the boxes, if sucesess.
            TextBox_Firstname.Text = "";
            TextBox_Lastname.Text = "";
            TextBox_Username.Text = "";
            TextBox_Password.Text = "";
        }
        catch(Exception ex)
        {
            Trace.Warn("DATA ACCESS", "Adding user failed!", ex);
        }
        finally
        {
            // Rebind the grid with the new user
            GridView_users_DataBind();
        }
    }


}
