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

public partial class profil : System.Web.UI.Page
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
        Profile.HANDLEKURV = new Handlevogn();
        List<Ordrelinje> ordre = Profile.HANDLEKURV.Handleliste;
        if (!IsPostBack)
        {
            if (Profile.UserName != null && Profile.IsAnonymous == false)
            {
                this.TextBoxFornavn.Text = Profile.fornavn;
                this.TextBoxEtternavn.Text = Profile.etternavn;
                this.TextBoxAdresse.Text = Profile.gateadresse;
                this.TextBoxPoststed.Text = Profile.poststed;
                this.TextBoxPostnummer.Text = Profile.postnummer;
                this.TextBoxTlf.Text = Profile.telefon;
                
                if ( ordre != null)
                {
                    //NameValueConfigurationCollection ne = new NameValueConfigurationCollection();

                    foreach (Ordrelinje ol in ordre)
                    {
                        Trace.Write("Varenummer: " + ol.ProduktID + "Antall: " + ol.Antall + "<br />");
                    }
                }
                else
                {
                    Trace.Write("Handlekurven er tom");
                }
            }
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
     
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Profile.IsAnonymous == false)
        {
            Profile.fornavn = this.TextBoxFornavn.Text;
            Profile.etternavn = this.TextBoxEtternavn.Text;
            Profile.gateadresse = this.TextBoxAdresse.Text;
            Profile.poststed = this.TextBoxPoststed.Text;
            Profile.postnummer = this.TextBoxPostnummer.Text;
            Profile.telefon = this.TextBoxTlf.Text;
            this.LabelOppdatert.Text = "Din profil er oppdatert!";
            

            //List<Ordrelinje> handleliste = new List<Ordrelinje>();
            Ordrelinje testOL = new Ordrelinje();
            testOL.Antall = 2;
            testOL.ProduktID = 12;
            Profile.HANDLEKURV.leggTilVareIHandlevogn(testOL);
            
            //Profile.HANDLEKURV;
            //Profile.HANDLEKURV.Handleliste = handleliste;
            

        }
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
}
