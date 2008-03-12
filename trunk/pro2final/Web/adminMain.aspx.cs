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

using myApp.IBLL;
using myApp.Model;
using System.Collections.Generic;

public partial class adminMain : System.Web.UI.Page
{
    INyhetBLL nBLL = BLLLoader.GetNyhetBLL();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!Profile.IsAnonymous)
        {
            Page.Theme = Profile.Theme;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.IsInRole("admin"))
        {
            Response.Redirect("~/Default.aspx");
        }

        if (!IsPostBack)
        {
            foreach (View v in Oppgaveview.Views)
            {
                Oppgavevelger.Items.Add(new ListItem(v.ID, Oppgaveview.Views.IndexOf(v).ToString()));
            }

        }
    }

    protected void Oppgavevelger_SelectedIndexChanged(object sender, EventArgs e)
    {
        Oppgaveview.ActiveViewIndex = Convert.ToInt32(Oppgavevelger.SelectedValue);
    }

    protected void Send_Click(object sender, EventArgs e)
    {
        Nyhet n = new Nyhet();
        n.Tittel = this.Overskrift.Text;
        n.Tekst = this.Tekst.Text;
        nBLL.nyNyhet(n);
        n.Tittel = "";
        n.Tekst = "";

    }
}
