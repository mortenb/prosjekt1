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
using System.Net.Mail;
using myApp.Model;
using myApp.IBLL;

public partial class kasse : System.Web.UI.Page
{
    
    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Trace.Write(Profile.UserName);
      
        
    }
    protected void Button_kjop_Click(object sender, EventArgs e)
    {
        
        List<minOrdre> moLst = Profile.HANDLEKURV.lagOrdreliste();
        IOrdreBLL ordreBLL = BLLLoader.GetOrdreBLL();
        IOrdrelinjeBLL olBLL = BLLLoader.GetOrdrelinjeBLL();
        IProduktBLL produktBLL = BLLLoader.GetProduktBLL();
        
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

                Produkt p = produktBLL.getProdukt(ol.ProduktID); //oppdater antall på lager
                p.AntallPaaLager = p.AntallPaaLager - ol.Antall;
                if (p.AntallPaaLager < 0)
                {
                    p.AntallPaaLager = 0;
                }
                try
                {
                    produktBLL.endreProdukt(p);
                }
                catch (Exception produktException)
                {
                    this.LabelFeil.Text = "Kunne ikke oppdatere basen";
                    Response.Write("OOPS");
                }
                
                this.LabelFeil.Text = "Kjøpet er gjennomført. Du vil straks motta en bekreftelse på mail ";
               

                
                Profile.HANDLEKURV.slettHandleliste();
                Profile.Save();
                sendBekreftelseMail(ordreID);
                Response.Cookies.Clear();
            }

        }
        catch (Exception ex)
        {
            
            this.LabelFeil.Text = "Kunne ikke gjennomføre transaksjon. Vennligst prøv igjen senere";
        }

        

    }

    private void sendBekreftelseMail(int ordreID)
    {
        MailAddress from = new MailAddress("webpro2gr1@gmail.com");
        MailAddress recipient = new MailAddress("webpro2gr1@gmail.com");
        MailMessage m = new MailMessage(from, recipient);
        m.Body = "Din bestilling er registrert!\n\n " +
            "Ditt ordrenummer er: " + ordreID + "\n" +
            "\n\nMed hilsen Webshopteamet.";
        m.Subject = "Ordrebekreftelse: Ordrenummer:" + ordreID;

        SmtpClient smc = new SmtpClient();
        smc.EnableSsl = true;
        smc.Send(m);
    }
}
