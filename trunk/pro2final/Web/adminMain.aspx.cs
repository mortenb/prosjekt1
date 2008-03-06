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
    IProduktkategoriBLL pkBLL = BLLLoader.GetProduktkategoriBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.IsInRole("admin"))
        {
            Response.Redirect("~/Default.aspx");
        }
        getKategorier();
    }

    public List<Produktkategori> testkilde()
    {
        return pkBLL.getProduktkategorier();
    }
    private void getKategorier()
    {
        KatListe.Items.Clear();
        try
        {
            List<Produktkategori> kategoriliste = pkBLL.getProduktkategorier();

            if (kategoriliste.Count > 0)
            {   
                foreach (Produktkategori pk in kategoriliste)
                    KatListe.Items.Add(new ListItem(pk.Navn, pk.ProduktkategoriID.ToString()));
            }
            else
                KatListe.Items.Add("ingen kategorier er opprettet.");
        }
        catch (Exception ex)
        {
            Trace.Warn("DB'en tryna - kategori.ascx.cs");
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

    protected void SlettKat_Click(object sender, EventArgs e)
    {

        
        Response.Write(sender.ToString() +" "+ e.ToString());
    }
    protected void KatListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write(sender.ToString() + " " + e.ToString());

 
    }
}
