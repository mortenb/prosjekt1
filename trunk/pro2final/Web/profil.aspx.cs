using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using myApp.Model;
using myApp.IBLL;

public partial class profil : System.Web.UI.Page
{
    IAnmeldelseBLL anmBLL = (IAnmeldelseBLL)BLLLoader.GetAnmeldelseBLL();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Profile.IsAnonymous)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!Profile.IsAnonymous)
        {
            Page.Theme = Profile.Theme;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Profile.UserName);
        Profile.HANDLEKURV = new Handlevogn();
        List<Ordrelinje> ordre = Profile.HANDLEKURV.Handleliste;
    }

    protected void Set_Theme(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.Text == "Matrix")
        {
            Profile.Theme = "Matrix";
        }
        else if (btn.Text == "Green")
        {
            Profile.Theme = "Green";
        }
        else if (btn.Text == "Nice")
        {
            Profile.Theme = "Nice";
        }
        Response.Redirect("~/profil.aspx");
    }




    protected void lbAnmeldLeggTil_Click(object sender, EventArgs e)
    {
        Anmeldelse anm = new Anmeldelse();
        anm.ProduktID = Convert.ToInt32(lblAnmeldProduktID.Text);
        anm.Tittel = tbAnmeldTittel.Text;
        anm.Tekst = tbAnmeldTekst.Text;
        anm.Karakter = Convert.ToInt32(ddlAnmeldKarakter.SelectedValue);

        anmBLL.nyAnmeldelse(anm);

        lblAnmeldOppdatert.Text = "Anmeldelsen er lagret!";
       


    }
    protected void tbAnmeldTekst_TextChanged(object sender, EventArgs e)
    {

    }
}
