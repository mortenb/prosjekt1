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

using DOTNETPROSJEKT1.Model;
using DOTNETPROSJEKT1.BLL;
using System.Collections.Generic;
using System.Text;

public partial class innlegg : System.Web.UI.Page
{
    int innleggID;

    Innlegg inn;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!User.Identity.IsAuthenticated)
            Page.Response.Redirect("~/index.aspx");

        try
        {
            innleggID = Convert.ToInt32(Request.QueryString.GetValues(0)[0]);
        }
        catch (Exception ex)
        {
            innleggID = 0;
        }

        if (innleggID > 0)
        {
            inn = DOTNETPROSJEKT1.BLL.InnleggBLL.getInnlegg(innleggID);
            Tittelfelt.Text = inn.Tittel;
            Innleggstekst.Text = inn.Tekst;
            Datofelt.Text = inn.Dato.ToString();
            string eier = BlogBLL.getBlog(inn.ForeldreID).Eier.Trim();
            string bruker = User.Identity.Name.Trim();
            if (  !bruker.Equals(eier) || User.IsInRole("Admin") )
                Response.Redirect("~/blogg.aspx?=" + eier);
        }
        else
        {
            Tittelfelt.Text = "";
            Innleggstekst.Text = "";
            Datofelt.Text = DateTime.Now.ToString();
            inn = new Innlegg();
        }

        //PrintInnlegg();
    }

    protected void PrintInnlegg()
    {
        List<Innlegg> innleggsliste = new List<Innlegg>();
        innleggsliste.Add(inn);

        HtmlTableRow tr = new HtmlTableRow();

        HtmlTableCell tcId = new HtmlTableCell();
        tcId.Controls.Add(new LiteralControl("ID"));
        HtmlTableCell tcbloggID = new HtmlTableCell();
        tcbloggID.Controls.Add(new LiteralControl("BloggID"));
        HtmlTableCell tcTittel = new HtmlTableCell();
        tcTittel.Controls.Add(new LiteralControl("Tittel"));
        HtmlTableCell tcDato = new HtmlTableCell();
        tcDato.Controls.Add(new LiteralControl("Dato"));
        HtmlTableCell tcTekst = new HtmlTableCell();
        tcTekst.Controls.Add(new LiteralControl("Tekst"));

        HtmlTableRow tr1 = new HtmlTableRow();
        tr1.Controls.Add(tcId);
        tr1.Controls.Add(tcbloggID);
        tr1.Controls.Add(tcTittel);
        tr1.Controls.Add(tcDato);
        tr1.Controls.Add(tcTekst);
        Table1.Rows.Add(tr1);

        HtmlTableCell tcIdVerdi = new HtmlTableCell();
        HtmlTableCell tcBloggIDVerdi = new HtmlTableCell();
        if (innleggID > 0)
        {
            tcIdVerdi.Controls.Add(new LiteralControl(Convert.ToString(inn.ID)));
            tcBloggIDVerdi.Controls.Add(new LiteralControl(Convert.ToString(inn.ForeldreID)));
        }
        else
        {
            tcIdVerdi.Controls.Add(new LiteralControl("nytt"));
            tcBloggIDVerdi.Controls.Add(new LiteralControl(Convert.ToString(BlogBLL.getBloggAvEier(User.Identity.Name).BlogID)));
        }
        HtmlTableCell tcTittelVerdi = new HtmlTableCell();
        TextBox tittel = new TextBox();
        tittel.ID = "tittel";

        tcTittelVerdi.Controls.Add(tittel);
        HtmlTableCell tcDatoVerdi = new HtmlTableCell();
        TextBox dato = new TextBox();
        dato.ID = "dato";
        tcDatoVerdi.Controls.Add(dato);
        HtmlTableCell tcTekstVerdi = new HtmlTableCell();
        TextBox tekst = new TextBox();
        tekst.TextMode = TextBoxMode.MultiLine;
        tekst.ID = "tekst";

        tcTekstVerdi.Controls.Add(tekst);
        if (innleggID > 0)
        {
            tittel.Text = inn.Tittel;
            dato.Text = Convert.ToString(inn.Dato);
            tekst.Text = inn.Tekst;
        }
        else
        {
            tittel.Text = "";
            dato.Text = DateTime.Now.ToString();
            tekst.Text = "";
        }
        HtmlTableRow tr2 = new HtmlTableRow();
        tr2.Controls.Add(tcIdVerdi);
        tr2.Controls.Add(tcBloggIDVerdi);
        tr2.Controls.Add(tcTittelVerdi);
        tr2.Controls.Add(tcDatoVerdi);
        tr2.Controls.Add(tcTekstVerdi);
        Table1.Rows.Add(tr2);


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Innlegg innleggNy = new Innlegg();

        if (innleggID > 0)
        {
            innleggNy.ID = inn.ID;
            innleggNy.ForeldreID = inn.ForeldreID;
        }
        else
        {
            innleggNy.ForeldreID = BlogBLL.getBloggAvEier(User.Identity.Name).BlogID;
        }
        innleggNy.Tittel = this.Tittelfelt.Text.ToString();
        innleggNy.Tekst = this.Innleggstekst.Text.ToString();
        innleggNy.Dato = Convert.ToDateTime(this.Datofelt.Text);
        /*
        TextBox tbTittel = (TextBox)Table1.FindControl("tittel");
        TextBox tbDato = (TextBox)Table1.FindControl("dato");
        TextBox tbTekst = (TextBox)Table1.FindControl("tekst");
        innleggNy.Tittel = tbTittel.Text;
        innleggNy.Dato = Convert.ToDateTime(tbDato.Text);
        innleggNy.Tekst = tbTekst.Text;
        */
        try
        {
            if (innleggID > 0)
            {
                DOTNETPROSJEKT1.BLL.InnleggBLL.redigerInnlegg(innleggNy);
            }
            else
            {
                InnleggBLL.nyttInnlegg(innleggNy);
                Response.Write("Lager nytt innlegg)");
            }

        }
        catch (Exception ex)
        {
            Trace.Warn(ex.Message);
        }

        Response.Redirect("~/blogg.aspx?=" + BlogBLL.getBlog(innleggNy.ForeldreID).Eier);
    }

    protected void Innleggstekst_TextChanged(object sender, EventArgs e)
    {

    }
}
