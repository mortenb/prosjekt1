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

        if (!User.Identity.IsAuthenticated)
            Page.Response.Redirect("~/index.aspx");
        bruker = User.Identity.Name.Trim();

        try
        {
            innleggID = Convert.ToInt32(Request.QueryString.GetValues(0)[0]);
        }
        catch (Exception ex)
        {
            Trace.Warn(ex.Message);
        }


        if (innleggID > 0)
        {
            inn = DOTNETPROSJEKT1.BLL.InnleggBLL.getInnlegg(innleggID);
            //Sjekk om innlegget vi leter etter, finnes:
            if(int.Parse(inn.ID.ToString()) != 0 ) 
            {

                bloggeier = BlogBLL.getBlog(inn.ForeldreID).Eier.Trim();
                Tittelfelt.Text = Server.HtmlEncode(inn.Tittel);
                Innleggstekst.Text = Server.HtmlEncode(inn.Tekst);
                lblEier.Text = bloggeier;
                LblInnleggID.Text = inn.ID.ToString();
                Datofelt.Text = inn.Dato.ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
            if (  !( bruker.Equals(bloggeier) || User.IsInRole("Admin") ) )
                Response.Redirect("~/blogg.aspx?=" + bloggeier);
        }
        else
        {
            if(User.Identity.Name.Equals("admin"))
                Response.Redirect("~/admin.aspx");

            Tittelfelt.Text = "";
            Innleggstekst.Text = "";
            lblEier.Text = bruker;
            Datofelt.Text = DateTime.Now.ToString();
            inn = new Innlegg();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Innlegg innleggNy = new Innlegg();

        if(LblInnleggID.Text.Length > 0)
            innleggID = Convert.ToInt32(LblInnleggID.Text);


        if (innleggID > 0)
        {
            innleggNy = InnleggBLL.getInnlegg(innleggID);
            innleggNy.Tekst = this.Innleggstekst.Text.ToString();
            innleggNy.Tekst += @"

sist endret av " + Page.User.Identity.Name + " " + DateTime.Now;
        }
        else
        {
            innleggNy.ForeldreID = BlogBLL.getBloggAvEier(lblEier.Text).BlogID;
            innleggNy.Tekst = this.Innleggstekst.Text.ToString();
            innleggNy.Dato = Convert.ToDateTime(this.Datofelt.Text);  
        }
        innleggNy.Tittel = this.Tittelfelt.Text.ToString();
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

        Response.Redirect("~/blogg.aspx?=" + lblEier.Text.ToString());
    }
}
