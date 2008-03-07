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

using myApp.IBLL;
using myApp.Model;
using System.Collections.Generic;

public partial class adminMain : System.Web.UI.Page
{
    //IProduktkategoriBLL pkBLL = BLLLoader.GetProduktkategoriBLL();
    IProduktBLL pBLL = BLLLoader.GetProduktBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.IsInRole("admin"))
        {
            Response.Redirect("~/Default.aspx");
        }
        
        if (!IsPostBack)
        {
            foreach (View v in Oppgaveview.Views)
            {
                Oppgavevelger.Items.Add(new ListItem(v.ID, Oppgaveview.Views.IndexOf(v).ToString()));
            }
    
        }    
    }

    private void getProdukter(int pkID)
    {
        List<Produkt> produktliste = pBLL.getProdukter(pkID);

        if (produktliste.Count > 0)
        {
            
        }
        else
        { 
        }
    }

 /*   private void getKategorier()
    {
        KatListe.Items.Clear();
        try
        {
            List<Produktkategori> kategoriliste = pkBLL.getProduktkategorier();

            if (kategoriliste.Count > 0)
            {
                KatListe.DataSource = kategoriliste;
                KatListe.DataBind();
                KatListe2.DataSource = kategoriliste;
                KatListe2.DataBind();
            }
            else
                KatListe.Items.Add("ingen kategorier er opprettet.");
        }
        catch (Exception ex)
        {
            Trace.Warn("DB'en tryna - adminMain.ascx.cs");
            Trace.Warn(ex.Message);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Produktkategori pkat = new Produktkategori();
        string s = KatNavn.Text.ToString();
        if (KatListe.Items.FindByText(s) == null)
        {


            pkat.Navn = s;

            if (!pkat.Navn.Equals(""))
                pkBLL.nyProduktkategori(pkat);

            KatNavn.Text = "";
            getKategorier();
        }
        else RequiredFieldValidator1.IsValid = false;
    }

    protected void KatListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write(sender.ToString() + " " + e.ToString());
        KatNavn.Text = KatListe.SelectedItem.Text;
 
    }
    protected void KatListe2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Slett_Click(object sender, EventArgs e)
    {

        //this.KatNavn.Text = this.KatListe.SelectedItem.Text;
        Response.Write(this.KatListe.SelectedValue.ToString());

    }
  * */
    protected void Oppgavevelger_SelectedIndexChanged(object sender, EventArgs e)
    {
        Oppgaveview.ActiveViewIndex = Convert.ToInt32(Oppgavevelger.SelectedValue);
    }
}
