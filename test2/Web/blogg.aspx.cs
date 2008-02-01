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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _bloggeier = Request.QueryString.GetValues(0);
            //bloggeier ligger nå i _bloggeier[0]
            //Lage liste over innlegg
            bloggen = DOTNETPROSJEKT1.BLL.BlogBLL.getBloggAvEier(_bloggeier[0]);
            listeoverinnlegg = DOTNETPROSJEKT1.BLL.InnleggBLL.getInnleggsListe(bloggen.BlogID);
            PrintInnlegg(listeoverinnlegg);

        }
    }

    //Metode for å hente ut verdier i bloggen
    protected void PrintInnlegg(List<Innlegg> innlegg)
    {

        foreach (Innlegg i in innlegg)
        {
            Response.Write("Tittel på innlegg: " + i.Tittel + "\n");
            Response.Write("Tekst: " + i.Tekst + "\n");
        }
    }
}
