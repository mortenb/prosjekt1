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
using System.Collections.Specialized;

using DOTNETPROSJEKT1.BLL;
using DOTNETPROSJEKT1.Model;
using System.Text;

public partial class kommentar : System.Web.UI.UserControl
{
    public static Innlegg innlegg = new Innlegg();

    private Kommentar finnes;
    
    private int _kommentarID = -1;
    public int KommentarID
    {
        get { return _kommentarID; }
        set 
        { 
            _kommentarID = value;
            this.lblKommentarID.Text = _kommentarID.ToString();   
        }
    }    

    private int _innleggID;
    public int InnleggID
    {
        get { return _innleggID; }
        set { 
            _innleggID = value;
            //av en eller annen grunn resettes denne når lagreknappen trykkes, 
            //derfor putter jeg verdien i en skjult label... veldig grisete og teit..
            this.lblID.Text = _innleggID.ToString(); 
        } 

    }

    private int _foreldreID;
    public int ForeldreID
    {
        get { return _foreldreID; }
        set {
            _foreldreID = value;
            this.lblForeldreID.Text = _foreldreID.ToString();
        } 
    }

    private string _eier;
    public string Eier
    {
        get { return _eier; }
        set { 
            _eier = value;
            this.lblEier.Text = _eier;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //sjekker om kommentar finnes fra før av, da skal den redigeres
        finnes = DOTNETPROSJEKT1.BLL.KommentarBLL.getKommentar(_kommentarID);
        
        if (finnes.ID != 0)
        {
            this.inputForfatter.Text = finnes.Forfatter.ToString();
            this.inputTekst.Text = finnes.Tekst.ToString();
            this.inputTittel.Text = "RE:" + finnes.Tittel.ToString();
        }
        else if (Page.User.Identity.IsAuthenticated)
        {

            this.inputForfatter.Text = Page.User.Identity.Name;
            this.inputForfatter.ReadOnly = true;
            this.inputTittel.Text = "RE: " + InnleggBLL.getInnlegg(_innleggID).Tittel;
        }
        else //brukeren er anonym
        {
            this.inputTittel.Text = "RE: " +InnleggBLL.getInnlegg(_innleggID).Tittel;
            this.inputForfatter.Text = "Anonym Feiging";
        }
        this.lblKommentarID.Text = finnes.ID.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnLagre_Click(object sender, EventArgs e)
    {
        Kommentar minKommentar = new Kommentar();
        minKommentar.Dato = DateTime.Now;

        //henter ut alle felter for ny kommentar
        minKommentar.Tekst = this.inputTekst.Text.ToString();
       
        minKommentar.Tittel = this.inputTittel.Text.ToString();
        minKommentar.Forfatter = this.inputForfatter.Text.ToString();
        minKommentar.InnleggID = int.Parse(this.lblID.Text.ToString());
        minKommentar.ForeldreID = minKommentar.InnleggID;
        minKommentar.ForeldreID = int.Parse(this.lblForeldreID.Text.ToString());
        minKommentar.ID = int.Parse(this.lblKommentarID.Text.ToString());

        if (minKommentar.ID != 0) //hvis den skal redigeres
        {
            string tempTekst = this.inputTekst.Text.ToString();
            string redigerer = minKommentar.Forfatter;
  
            if (Page.User.IsInRole("admin") && !(redigerer.Equals(lblEier.Text)))
            {
                redigerer = "admin";
            }
            
            tempTekst += @"

sist endret av " + redigerer + " " + DateTime.Now ;
            minKommentar.Tekst = tempTekst;
            KommentarBLL.redigerKommentar(minKommentar.ID, minKommentar.Tekst);
        }
        else
        {
            KommentarBLL.nyKommentar(minKommentar);
        }
        
        this.Visible = false;
        Parent.Page.Response.Redirect(Page.Request.Url.AbsoluteUri);
        Parent.Page.Response.End();
        
    }
    protected void Lukk_Click(object sender, EventArgs e)
    {
        this.Visible = false;       
    }
}
