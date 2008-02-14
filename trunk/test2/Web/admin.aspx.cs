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
using DOTNETPROSJEKT1.BLL;
using DOTNETPROSJEKT1.Model;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.IsInRole("Admin"))
            Response.Redirect("index.aspx");
        GridView1.DataSource = DOTNETPROSJEKT1.BLL.BlogBLL.getBlogger();
        GridView1.DataBind();
    }

    protected void CreateUserWizard1_CreatedUser1(object sender, EventArgs e)
    {
        string eier = CreateUserWizard1.UserName.ToString();
        Roles.AddUserToRole(eier, "blogger");
        string tittel = eier + " sin blogg";
        //Response.Write(tittel);
        Blog b = new Blog();
        b.Eier = eier;
        b.Tittel = tittel;
        if (DOTNETPROSJEKT1.BLL.BlogBLL.nyBlog(b) == -1)
        {
            Response.Write("Crap!");
        }
    }

    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        string eier = CreateUserWizard1.UserName.ToString();
        string tittel = eier + " sin blogg";
        Response.Write(tittel + "<br/>");
        Page.Response.Redirect(Page.Request.Url.AbsoluteUri);
        Page.Response.End();
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
