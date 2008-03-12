using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using myApp.Model;
using myApp.IBLL;

public partial class kasse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Trace.Write(Profile.UserName);
        
    }
    protected void Button_kjop_Click(object sender, EventArgs e)
    {
        List<minOrdre> moLst = Profile.HANDLEKURV.lagOrdreliste();
        IOrdreBLL ordreBLL = BLLLoader.GetOrdreBLL();
        IOrdrelinjeBLL olBLL = BLLLoader.GetOrdrelinjeBLL();

        try
        {
            Ordre o = new Ordre(); //Opprett en ny ordre med brukernavn og dato
            o.Brukernavn = Profile.UserName.ToString();
            o.OrdreDato = System.DateTime.Now;
            int ordreID = ordreBLL.nyOrdre(o); //legg ordre inn i databasen
            foreach (minOrdre mo in moLst) //legg så inn ordrelinjer med tilhørene ordreID
            {
                Ordrelinje ol = new Ordrelinje();
                ol.Antall = mo.Antall;
                ol.OrdreID = ordreID;
                ol.ProduktID = mo.ProduktID;

                olBLL.nyOrdrelinje(ol);  //putt inn i databasen
            }

        }
        catch (Exception ex)
        {
            
            this.LabelFeil.Text = "Kunne ikke gjennomføre transaksjon. Vennligst prøv igjen senere";
        }

        Profile.HANDLEKURV.slettHandleliste();
        this.LabelFeil.Text = "Kjøpet er gjennomført. Du vil straks motta en bekreftelse på mail ";
        Profile.Save();
    }
}
