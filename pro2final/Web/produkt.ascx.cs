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

using myApp.Model;
using myApp.IBLL;
using System.Collections.Generic;

public partial class produkt : System.Web.UI.UserControl
{

    private int _produktID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ProduktID == 0)
            this.Visible = false;
    }

    public int ProduktID
    {
        get { return _produktID; }
        set 
        { 
            _produktID = value;
            lblProduktID.Text = Convert.ToString(_produktID);
        }
    }

    protected void btnLeggIHandlekurv_Click(object sender, EventArgs e)
    {
        //Response.Write(sender.ToString() + " " + e.ToString());

        TextBox tbAntall = (TextBox)this.FormView1.FindControl("tbAntall");
        int antallTilBestilling = Convert.ToInt32(tbAntall.Text);      

        Ordrelinje ol = new Ordrelinje();
        ol.Antall = antallTilBestilling;
        ol.ProduktID = this.ProduktID;

        Profile.HANDLEKURV.leggTilVareIHandlevogn(ol);
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
}
