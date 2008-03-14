using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using myApp.Model;
using myApp.IBLL;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    private string[] queryStrings;
    private int pkID;
    private List<Produkt> pk;

    IProduktkategoriBLL pkBLL = BLLLoader.GetProduktkategoriBLL();
    IProduktBLL produktBLL = BLLLoader.GetProduktBLL();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!Profile.IsAnonymous)
        {
            Page.Theme = Profile.Theme; //sett theme
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Trenger en variabel som holder querystringen - den vil være en int

        if (Request.QueryString.Count == 0)
       {
            Page_VisTilbud();
            
        }

        else
        {
            Page_VisVarerFraKategori();
            
        }

        
               
    }


    protected void Page_VisVarerFraKategori()
    { //Denne metoden skal vise varer i tilhørende kategori
        

        queryStrings = Request.QueryString.GetValues(0);
        try
        {
            pkID = Convert.ToInt32(queryStrings[0]);
            pk = produktBLL.getProdukter(pkID);

            lblProduktID.Text = pkID.ToString();
            //List<Anmeldelse> anmListe;

            foreach (Produkt listeProdukt in pk)
            {
                produkt uc1 = (produkt)Page.LoadControl("produkt.ascx");
                int ID = listeProdukt.ProduktID;
                uc1.ProduktID = ID;
                uc1.ID = "produkt" + ID;
                PlaceHolder1.Controls.Add(uc1);
            }

        }
        catch (Exception ex)
        {
            Trace.Warn("Klarte ikke hente produkter fra database");
            Trace.Warn(ex.Message);
        }
    }

    protected void Page_VisTilbud()
    { //Denne metoden skal vise tilbud med en gang siden åpnes

    }

    
}
