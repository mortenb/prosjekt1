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
        Label produktIDLabel = (Label)FormView1.FindControl("ProduktIDLabel");
        int produktID = Convert.ToInt32(produktIDLabel.Text);
        TextBox tbAntall = (TextBox)FormView1.FindControl("tbAntall");
        int antall = Convert.ToInt32(tbAntall.Text);

        Ordrelinje ol = new Ordrelinje();
        ol.Antall = antall;
        ol.ProduktID = produktID;

        Profile.HANDLEKURV.leggTilVareIHandlevogn(ol);
    }
}
