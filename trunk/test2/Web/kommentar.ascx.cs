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
    private int _innleggID;

    public int InnleggID
    {
        get { return _innleggID; }
        set { _innleggID = value; } 

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
        set { _nivaa = value +1; } //øker med en i forhold til foreldre-nivået.
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
        minKommentar.InnleggID = _innleggID;
        minKommentar.ForeldreID = _foreldreID;
        minKommentar.Nivaa = _nivaa;

        DOTNETPROSJEKT1.BLL.KommentarBLL.nyKommentar(minKommentar);
    }
}
