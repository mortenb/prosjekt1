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

using DOTNETPROSJEKT1.Model;
using DOTNETPROSJEKT1.BLL;
using System.Collections.Generic;
using System.Text;

public partial class blogg : System.Web.UI.Page
{
    private string[] _bloggeier;
    private List<Innlegg> listeoverinnlegg;
    private Blog bloggen;
    private string bloggeier;
    private string user;
    private bool paaloggetBrukerErEierAvBloggen;
    private List<Kommentar> kommentarer;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        user = User.Identity.Name;
       
        if (Request.QueryString.Count > 0) //Sjekker om vi har et argument
        {
            _bloggeier = Request.QueryString.GetValues(0);
            //bloggeier ligger nå i _bloggeier[0]
            //Lage liste over innlegg
            try
            {
                bloggeier = _bloggeier[0];
                bloggen = DOTNETPROSJEKT1.BLL.BlogBLL.getBloggAvEier(bloggeier);
                if (user.ToString() == bloggeier.ToString())
                {
                    paaloggetBrukerErEierAvBloggen = true;
                }
            }
            catch (Exception ex)
            {
                Trace.Warn("Fant ikke blogg: " + ex.Message);
            }

            try
            {
                listeoverinnlegg = DOTNETPROSJEKT1.BLL.InnleggBLL.getInnleggsListe(bloggen.BlogID);
            }
            catch (Exception ex)
            {
                Trace.Warn("Kunne ikke opprette liste over innlegg: " + ex.Message);
            }

            PrintInnlegg(listeoverinnlegg);
        }
    }

    //Metode for å hente ut verdier i bloggen
    protected void PrintInnlegg(List<Innlegg> innlegg)
    {
        //henter alle innlegg i en blogg og lager tabell:

        foreach (Innlegg inn in innlegg)
        {   
            //celler for tittel, tekst, rediger, slett og kommenter
            HtmlTableCell tcTittel = new HtmlTableCell();
            HtmlTableCell tcDato = new HtmlTableCell();
            HtmlTableCell tcTekst = new HtmlTableCell();
            HtmlTableCell tcRediger = new HtmlTableCell();
            HtmlTableCell tcSlett = new HtmlTableCell();
            HtmlTableCell tcKommenter = new HtmlTableCell();
            //rader for ett innlegg:
            HtmlTableRow trTittel = new HtmlTableRow();
            HtmlTableRow trDato = new HtmlTableRow();
            HtmlTableRow tr2 = new HtmlTableRow();
            HtmlTableRow tr3 = new HtmlTableRow();
            //Få tittel og tekst fra ett innlegg inn i tabellen:
            tcTittel.Controls.Add(new LiteralControl(inn.Tittel));
            trTittel.Controls.Add(tcTittel);
            Table1.Rows.Add(trTittel);

            //Skrive ut dato på tittel
            Label lblDato = new Label();
            lblDato.Text = inn.Dato.ToString();
            tcDato.Controls.Add(lblDato);
            trDato.Controls.Add(tcDato);
            Table1.Rows.Add(trDato);

            TextBox tb = new TextBox();
            tb.Text = inn.Tekst;
            tb.ReadOnly = true;
            tb.TextMode = TextBoxMode.MultiLine;
            tb.CssClass = "x-innlegg-tekstboks";
            tb.Width = 350;
            tb.Height = 150;
            tcTekst.Controls.Add(tb);
            //hvis bruker har rettigheter, vis rediger og sletteknapp
            //knapp for å kommentere innlegg:
            LinkButton kommenterButton = new LinkButton();
            kommenterButton.ID = "kommenterInnlegg" + inn.ID;
            kommenterButton.Text = "kommenter dette innlegget";
            kommenterButton.CommandArgument = inn.ID.ToString();
            kommenterButton.Click += new EventHandler(kommenterButton_onclick);

            tcKommenter.Controls.Add(kommenterButton);
            if (user.Equals(bloggeier) || User.IsInRole("admin"))
            {
                LinkButton redigerKnapp = new LinkButton();
                redigerKnapp.Text = "Rediger";
                redigerKnapp.ID = "redigerKnapp" + inn.ID;
                redigerKnapp.PostBackUrl = "~/innlegg.aspx?ID=" + inn.ID;

                tcKommenter.Controls.Add(new LiteralControl("      "));
                tcKommenter.Controls.Add(redigerKnapp);
                LinkButton slettKnapp = new LinkButton();
                slettKnapp.Text = "Slett";
                slettKnapp.ID = "slettKnapp" + inn.ID;
                slettKnapp.CommandArgument = inn.ID.ToString();
                slettKnapp.Click += new EventHandler(slettKnapp_onclick);
                tcKommenter.Controls.Add(new LiteralControl("      "));
                tcKommenter.Controls.Add(slettKnapp);
            }
            
            tr2.Controls.Add(tcTekst);
            tr2.Controls.Add(tcRediger);
            tr2.Controls.Add(tcSlett);
            tr3.Controls.Add(tcKommenter);
            Table1.Rows.Add(tr2);
            Table1.Rows.Add(tr3);
            
            //hent så alle kommentarer for innlegget, løp gjennom og vis:
            kommentarer = KommentarBLL.getKommentarListe(inn.ID);
            foreach ( Kommentar k in kommentarer)
            {
                int nivaa = k.Nivaa;

                HtmlTableRow trKommentarOverskrift = new HtmlTableRow();
                HtmlTableRow trKommentarBody = new HtmlTableRow();
                HtmlTableRow trKommentarFooter = new HtmlTableRow();

                HtmlTableCell tcKommentarTittel = new HtmlTableCell(); //Tittel
                HtmlTableCell tcKommentarTekst = new HtmlTableCell(); //Tekst
                
                tcKommentarTittel.Controls.Add(new LiteralControl(k.Tittel + " skrevet av " + k.Forfatter));
                trKommentarOverskrift.Controls.Add(tcKommentarTittel);
                TextBox tbKommentarTekst = new TextBox();
                tbKommentarTekst.Width = 350;
                tbKommentarTekst.Height = 150;
                tbKommentarTekst.ReadOnly = true;
                tbKommentarTekst.TextMode = TextBoxMode.MultiLine;
                tbKommentarTekst.CssClass = "x-kommentar-tekstboks";
                tbKommentarTekst.Text = k.Tekst;
                tcKommentarTekst.Controls.Add(tbKommentarTekst);
                trKommentarBody.Controls.Add(tcKommentarTekst);
                
                Table1.Rows.Add(trKommentarOverskrift);
                Table1.Rows.Add(trKommentarBody);

                //sett inn kommenter-knapp på en kommentar:
                LinkButton kommenterButton2 = new LinkButton();
                kommenterButton2.ID = "kommenterKommentar" + k.ID;
                kommenterButton2.Text = "kommenter";
                kommenterButton2.CommandArgument = k.ID.ToString();
                kommenterButton2.Click += new EventHandler(kommenterKommentarButton_onclick);
                HtmlTableCell tcKommentarFoot = new HtmlTableCell();
                tcKommentarFoot.Controls.Add(kommenterButton2);
                
                

                //Hvis bruker har rettigheter, vis slett og rediger-knapper
                if (user.Equals(bloggeier) || User.IsInRole("admin"))
                {
                    
                    HtmlTableCell tcAdmin1 = new HtmlTableCell();
                    //HtmlTableCell tcAdmin2 = new HtmlTableCell();
                    LinkButton redigerButton = new LinkButton();
                    redigerButton.ID = "redigerKommentarButton"+k.ID;
                    redigerButton.CommandArgument = k.ID.ToString();
                    redigerButton.Text = "rediger";
                    redigerButton.Click += new EventHandler(RedigerKommentarKnapp_onclick);

                    LinkButton slettButton = new LinkButton();
                    slettButton.ID = "slettKommentarButton" + k.ID;
                    slettButton.CommandArgument = k.ID.ToString();
                    slettButton.Text = "slett";
                    slettButton.Click += new EventHandler(slettKommentarButton_onclick);

                    tcKommentarFoot.Controls.Add(new LiteralControl("   "));
                    tcKommentarFoot.Controls.Add(redigerButton);
                    tcKommentarFoot.Controls.Add(new LiteralControl("   ")); //whitespace mellom knappene
                    tcKommentarFoot.Controls.Add(slettButton);

                    //trKommentarFooter.Controls.Add(tcAdmin1);
                    
                }

                trKommentarFooter.Controls.Add(tcKommentarFoot);
                Table1.Rows.Add(trKommentarFooter);
                
                

            }
            
        }
    }
    protected void kommenterButton_onclick(object sender, EventArgs e)
    {
        try
        {
            LinkButton hvilken = (LinkButton) sender;
            int id = int.Parse(hvilken.CommandArgument);
            //nivaa = 0; //teller fra 0. Et innlegg har nivå 0
            this.nykommentar1.Nivaa = id; //førsøker dette istedet.. 
            this.nykommentar1.InnleggID = id;
           
            this.nykommentar1.ForeldreID = id;
            this.nykommentar1.Visible = true;


        }
        catch (Exception ex)
        {
            Trace.Warn(ex.Message);
        }
    }

    protected void kommenterKommentarButton_onclick(object sender, EventArgs e)
    {
        
        Trace.Write("Kommenter kommentar!");
        try
        {

            int nivaa;
            LinkButton hvilken = (LinkButton)sender;
            int id = int.Parse(hvilken.CommandArgument);
            Kommentar k = KommentarBLL.getKommentar(id);
            if (k != null)
            {
                nivaa = k.ID; 
                this.nykommentar1.Nivaa = nivaa;
                this.nykommentar1.InnleggID = k.InnleggID;

                this.nykommentar1.ForeldreID = id;
                this.nykommentar1.Visible = true;
            }


        }
        catch (Exception ex)
        {
            Trace.Warn(ex.Message);
        }
    }

    protected void RedigerKommentarKnapp_onclick(object sender, EventArgs e)
    {
        try
        {


            //int nivaa;
            LinkButton hvilken = (LinkButton)sender;
            int id = int.Parse(hvilken.CommandArgument);
            Kommentar k = KommentarBLL.getKommentar(id);
            
                int nivaa = k.Nivaa;
                this.nykommentar1.Nivaa = nivaa;
                this.nykommentar1.KommentarID = k.ID;
                this.nykommentar1.InnleggID = k.InnleggID;                
                this.nykommentar1.Visible = true;
            


        }
        catch (Exception ex)
        {
            Trace.Warn(ex.Message);
        }


        
    }

    protected void slettKnapp_onclick(object sender, EventArgs e)
    {
        try
        {
            LinkButton hvilken = (LinkButton)sender;
            int id = int.Parse(hvilken.CommandArgument);

            
                //Kaller slettInnlegg med boolean "er pålogget bruker lik bloggeier?")
                InnleggBLL.slettInnlegg(id, user.ToString() == bloggeier);
                //må her også slette tilhørende kommentarer..Eller gjøres dette av db?
                Trace.Write("slettet innlegg " + id);
                Page.Response.Redirect(Page.Request.Url.AbsoluteUri);
                Page.Response.End();
            
        }
        catch (Exception ex)
        {
            Trace.Write(ex.Message);

        }

    }

    protected void slettKommentarButton_onclick(object sender, EventArgs e)
    {
        try
        {
            LinkButton hvilken = (LinkButton)sender;
            int id = int.Parse(hvilken.CommandArgument);


            //Kaller slettInnlegg med boolean "er pålogget bruker lik bloggeier?")
            KommentarBLL.slettKommentar(id, paaloggetBrukerErEierAvBloggen);
            //må her også slette tilhørende kommentarer..Eller gjøres dette av db?
            Trace.Write("slettet kommentar " + id);
            Page.Response.Redirect(Page.Request.Url.AbsoluteUri);
            Page.Response.End();

        }
        catch (Exception ex)
        {
            Trace.Write(ex.Message);

        }
    }

}
