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
    string[] _bloggeier;
    List<Innlegg> listeoverinnlegg;
    Blog bloggen;
    string bloggeier;
    string user;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        user = User.Identity.Name;

        _bloggeier = Request.QueryString.GetValues(0);
        //bloggeier ligger nå i _bloggeier[0]
        //Lage liste over innlegg
        try
        {
            bloggeier = _bloggeier[0];
            bloggen = DOTNETPROSJEKT1.BLL.BlogBLL.getBloggAvEier(bloggeier);
            
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

    //Metode for å hente ut verdier i bloggen
    protected void PrintInnlegg(List<Innlegg> innlegg)
    {
        GridView1.DataSource = innlegg;
        GridView1.DataBind();

        int knappTeller = 1;

        foreach (Innlegg inn in innlegg)
        {
            HtmlTableRow tr = new HtmlTableRow();

            HtmlTableCell tcTittel = new HtmlTableCell();
            HtmlTableCell tcTekst = new HtmlTableCell();
            HtmlTableCell tcRediger = new HtmlTableCell();
            

            HtmlTableRow tr1 = new HtmlTableRow();
            HtmlTableRow tr2 = new HtmlTableRow();
            tcTittel.Controls.Add(new LiteralControl(inn.Tittel));
            tr1.Controls.Add(tcTittel);
            Table1.Rows.Add(tr1);
            tcTekst.Controls.Add(new LiteralControl(inn.Tekst));
            if (user.Equals(bloggeier) || User.IsInRole("admin"))
            {
                Button redigerKnapp = new Button();
                redigerKnapp.Text = "Rediger";
                redigerKnapp.ID = "redigerKnapp" + knappTeller;
                redigerKnapp.Click += new EventHandler(RedigerKnapp_onclick);
                tcRediger.Controls.Add(redigerKnapp);
            }
            
            tr2.Controls.Add(tcTekst);
            tr2.Controls.Add(tcRediger);
            Table1.Rows.Add(tr2);
            

            knappTeller++;
        }
    }

    protected void RedigerKnapp_onclick(object sender, EventArgs e)
    {
        
        Response.Write("Knappen ble trykket");
    }

    protected void test(int i)
    {
        Response.Write("jula jula" + i);
    }
}
