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
using DOTNETPROSJEKT1.BLL;
using DOTNETPROSJEKT1.Model;

public partial class kommentar : System.Web.UI.UserControl
{

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
        set { _foreldreID = value; } 
    }

    private int _nivaa;
    public int Nivaa
    {
        get { return _nivaa; }
        set {
            _nivaa = value;
            //_nivaa = value +1;
            this.lblNivaa.Text = _nivaa.ToString();
        } //øker med en i forhold til foreldre-nivået.
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Kommentar finnes = KommentarBLL.getKommentar(_kommentarID);
        
        if (finnes.ID != 0)
        {
            this.inputForfatter.Text = finnes.Forfatter.ToString();
            this.inputTekst.Text = finnes.Tekst.ToString();
            this.inputTittel.Text = finnes.Tittel.ToString();
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
        
        minKommentar.Tekst = this.inputTekst.Text.ToString();
        minKommentar.Tittel = this.inputTittel.Text.ToString();
        minKommentar.Forfatter = this.inputForfatter.Text.ToString();
        minKommentar.InnleggID = int.Parse(this.lblID.Text.ToString());
        minKommentar.ForeldreID = minKommentar.InnleggID;
        minKommentar.Nivaa = int.Parse(this.lblNivaa.Text.ToString());
        minKommentar.ID = int.Parse(this.lblKommentarID.Text.ToString());

        if (minKommentar.ID != 0)
        {
            KommentarBLL.redigerKommentar(minKommentar.ID, minKommentar.Tekst);
        }
        else
        {
            DOTNETPROSJEKT1.BLL.KommentarBLL.nyKommentar(minKommentar);
        }
        
        this.Visible = false;
        Parent.Page.Response.Redirect(Page.Request.Url.AbsoluteUri);
        Parent.Page.Response.End();
        
    }
}
