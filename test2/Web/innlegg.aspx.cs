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
    private int innleggID;
    private string bloggeier, bruker;
    private Innlegg inn;

    protected void Page_PreRender(object sender, EventArgs e)
    {

        // Redirect av uinnloggede brukere.
        if (!User.Identity.IsAuthenticated)
            Page.Response.Redirect("~/index.aspx");
        bruker = User.Identity.Name.Trim();

        // Henter ut innleggsid fra request
        try
        {
            innleggID = Convert.ToInt32(Request.QueryString.GetValues(0)[0]);
        }
        catch (Exception ex)
        {
            Trace.Warn(ex.Message);
        }

        // Henter ut innlegg fra databasen og legger data i feltene på redigeringssiden
        // Må legge noen data i skjulte labeler for å beholde dem.
        if (innleggID > 0)
        {
            inn = DOTNETPROSJEKT1.BLL.InnleggBLL.getInnlegg(innleggID);
            //Sjekk om innlegget vi leter etter, finnes:
            if(int.Parse(inn.ID.ToString()) != 0 ) 
            {

                bloggeier = BlogBLL.getBlog(inn.ForeldreID).Eier.Trim();
                Tittelfelt.Text = inn.Tittel;
                Tittelfelt.ReadOnly = true;
                Innleggstekst.Text = inn.Tekst;
                lblEier.Text = bloggeier;
                LblInnleggID.Text = inn.ID.ToString();
                Datofelt.Text = inn.Dato.ToString();
            }
            else // ugyldig innleggID, redirect til forsiden.
            {
                Response.Redirect("index.aspx");
            }
            // Sjekker nå om gjeldende bruker er eieren av innlegget, eller admin.
            // Andre brukere som prøver å redigere innlegget blir sendt til bloggsiden.
            if (  !( bruker.Equals(bloggeier) || User.IsInRole("Admin") ) )
                Response.Redirect("~/blogg.aspx?=" + bloggeier);
        }
        else // Nytt innlegg som legges i den innloggede brukerens blogg
        {
            // Sejkker om det er adminbrukeren som prøver å lage et nytt innlegg, 
            // og sender admin over til administratorsiden isteden.
            if(User.Identity.Name.Equals("admin"))
                Response.Redirect("~/admin.aspx");

            Tittelfelt.Text = "";
            Innleggstekst.Text = "";
            lblEier.Text = bruker;
            Datofelt.Text = DateTime.Now.ToString();
            //inn = new Innlegg();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Henter ut dataene fra skjemaet på siden etter at brukeren har klikket på  send-knappen.
    protected void Button1_Click(object sender, EventArgs e)
    {
        Innlegg innleggNy = new Innlegg(); 

        // Henter ut igjen innelggID fra label hvis den har en verdi.
        if(LblInnleggID.Text.Length > 0)
            innleggID = Convert.ToInt32(LblInnleggID.Text);

        /* Vi har et innlegg som er redigert, henter ut det opprinnelige innlegget og
         * endrer tekst og/eller tittel. Legger samtidig på en tekst som sier at innlegget
         * er redigert, sammen med brukernavn og tidspunkt.                             */
        if (innleggID > 0)
        {
            string redigerer; //hjelpestring for hvem som redigerer innlegget 

            // Det er bloggeierne som redigerer:
            if (User.Identity.Name.Equals(lblEier.Text))
                redigerer = lblEier.Text;
            else // En bruker med adminrolle redigerer:
                redigerer = "admin";

            innleggNy = InnleggBLL.getInnlegg(innleggID);
            innleggNy.Tekst = this.Innleggstekst.Text.ToString();
            innleggNy.Tekst += @"

sist endret av " + redigerer + " " + DateTime.Now;
        }
        else // Nytt innlegg, fyller det tomme innleggsobjektet med data
        {    // innleggID trengs ikke, siden det genereres i DB.
            innleggNy.ForeldreID = BlogBLL.getBloggAvEier(lblEier.Text).BlogID;
            innleggNy.Tekst = this.Innleggstekst.Text.ToString();
            innleggNy.Dato = Convert.ToDateTime(this.Datofelt.Text);  
        }
        innleggNy.Tittel = this.Tittelfelt.Text.ToString();

        // legger opprettelsen/endringen innlegg i en try catch for å hindre 
        // appcrash ved ev. databasefeil.
        try
        {
            if (innleggID > 0)
            {
                DOTNETPROSJEKT1.BLL.InnleggBLL.redigerInnlegg(innleggNy);
            }
            else
            {
                InnleggBLL.nyttInnlegg(innleggNy);
            }

        }
        catch (Exception ex)
        {
            Trace.Warn(ex.Message);
        }

        // Sender brukeren tilbake til den bloggen innlegget tilhører.
        Response.Redirect("~/blogg.aspx?=" + lblEier.Text.ToString());
    }
}
