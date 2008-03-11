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

public partial class profildata : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            }
        }
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
            

            Profile.Save();

            this.lblOppdatert.Text = "Din profil er oppdatert!";

            //Profile.HANDLEKURV;
            //Profile.HANDLEKURV.Handleliste = handleliste;


        }
    }
}
