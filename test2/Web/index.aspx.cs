using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DOTNETPROSJEKT1.Model;
using DOTNETPROSJEKT1.BLL;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView_blogger_Databind();
            GridView_blogg_Databind();
        }
    }

    protected void GridView_blogg_Databind()
    {
        try
        {
            GridView_blogg.DataSource = DOTNETPROSJEKT1.BLL.BlogBLL.getBlog(1);
            GridView_blogg.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("DB'en tryna");
            Response.Write(ex.Message);
        }
    }

    protected void GridView_blogger_Databind()
    {
        try
        {
            Trace.Write("Prøver å binde data til kilden");
            GridView_blogger.DataSource = DOTNETPROSJEKT1.BLL.BlogBLL.getBlogger();
            GridView_blogger.DataBind();

        }
        catch (Exception ex)
        {
            Trace.Warn("DB'en tryna");
            Trace.Warn(ex.Message);
        }
    }
    protected void Header1_Load(object sender, EventArgs e)
    {

    }
}

