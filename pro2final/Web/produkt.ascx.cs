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
    private IProduktBLL produktBLL = BLLLoader.GetProduktBLL();

    private int _produktID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ProduktID == 0)
            this.Visible = false;
        else
        {
            
        }
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
        Label l = (Label)this.LabelLagtIHandlevogn;
        try
        {
            Profile.HANDLEKURV.leggTilVareIHandlevogn(ol);
            
            l.Text = "Lagt til i handlevognen";
        }
        catch(Exception ex)
        {
            l.Text = "En feil har oppstått. Vennligst prøv igjen senere";
        }

    }
    
    protected void tbAntall_DataBinding(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        tb.Text = "1";
    }
    
    
    protected void RegularExpressionValidator1_DataBinding(object sender, EventArgs e)
    {
        RegularExpressionValidator rev = (RegularExpressionValidator)sender;
        rev.ID = "revAntall" + ProduktID;
    }
    

    protected void btn_leggTil_DataBinding(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        b.ID = "btn_leggTil" + ProduktID;
    }

   


    
}
