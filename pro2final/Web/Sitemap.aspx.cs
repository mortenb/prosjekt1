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

public partial class Sitemap : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!Profile.IsAnonymous)
        {
            Page.Theme = Profile.Theme;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
        this.TreeView1.DataSource = Page.Master.FindControl("SiteMapDataSource1");
        this.TreeView1.DataBind();
    }
}
