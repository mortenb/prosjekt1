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

public partial class nyheter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(_synlig))
        {
            this.Visible = false;
        }
    }

    private bool _synlig;

    public bool Synlig
    {
        get { return _synlig; }
        set { _synlig = value; }
    }
}
