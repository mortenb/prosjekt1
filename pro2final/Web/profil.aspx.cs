using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using myApp.Model;
using myApp.IBLL;

public partial class profil : System.Web.UI.Page
{
    IAnmeldelseBLL anmBLL = (IAnmeldelseBLL)BLLLoader.GetAnmeldelseBLL();

    IProduktBLL prodBLL = (IProduktBLL)BLLLoader.GetProduktBLL();

    IProduktkategoriBLL pkBLL = (IProduktkategoriBLL)BLLLoader.GetProduktkategoriBLL();

    private int _nyesteProduktID;

    //int for å holde på produktkategoriid'en som brukeren har kjøpt flest kategorier i.
    private int pkFlest;

    //liste over alle kjøpte produkter til brukeren
    private List<Produkt> lstKjoepteProdukter;
    private List<Produktkategori> lstProduktKategorier;

    //hashtabell over produktkategorier og hvor mange produkter i hver av dem
    private Hashtable hshPKAntall;




    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Profile.IsAnonymous)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!Profile.IsAnonymous)
        {
            Page.Theme = Profile.Theme;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Profile.UserName);
        Profile.HANDLEKURV = new Handlevogn();
        List<Ordrelinje> ordre = Profile.HANDLEKURV.Handleliste;

        kalkulerNyesteProdukt();

        if (Request.QueryString.Count > 0)
        {
            pnlAnmeld.Visible = true;
            string prodID = Request.QueryString.GetValues(0)[0];
            lblAnmeldProduktTittel.Text = prodBLL.getProdukt(Convert.ToInt32(prodID)).Tittel;
            lblAnmeldProduktID.Text = prodID;
        }
    }


    private void kalkulerNyesteProdukt()
    {
        //Beregner nyeste produkt ut i fra tidligere kjøpte produkter
        //Denne metoden kan kanskje flyttes over til BLL?
        //Denne metoden tar ikke høyde for at man har kjøpt like mange produkter i to kategorier. 
        //Kjører bare ut den første han finner
        //Få alle kjøpte produkter
        lstKjoepteProdukter = prodBLL.getKjoepteProdukter(Profile.UserName);
        lstProduktKategorier = pkBLL.getProduktkategorier();
        //Opprett hashtabell
        hshPKAntall = new Hashtable();

        //integer som holder på hvor mange ganger en produktkategori har truffet
        int treff = 0;
        int temp = 0;
        int result = 0;

        Produktkategori produktK = new Produktkategori();

        foreach (Produktkategori listePK in lstProduktKategorier)
        {
            hshPKAntall.Add(listePK, 0);

            foreach (Produkt listeProdukt in lstKjoepteProdukter)
            {

                int pk = listeProdukt.ProduktkategoriID;

                if (listePK.ProduktkategoriID == pk)
                {
                    hshPKAntall[listePK] = ++treff;
                }

            }
            result = Convert.ToInt32(hshPKAntall[listePK]);
            if (result > temp)
            {
                temp = result;
                produktK = listePK;
            }
            treff = 0;
        }

        int pkID = produktK.ProduktkategoriID;



        Produkt prod = prodBLL.getNyesteProduktAvKategori(pkID);

        this.lblNyesteProduktID.Text = prod.ProduktID.ToString();

    }

    protected void Set_Theme(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.Text == "Matrix")
        {
            Profile.Theme = "Matrix";
        }
        else if (btn.Text == "Green")
        {
            Profile.Theme = "Green";
        }
        else if (btn.Text == "Nice")
        {
            Profile.Theme = "Nice";
        }
        Response.Redirect("~/profil.aspx");
    }

    protected void lbAnmeldLeggTil_Click(object sender, EventArgs e)
    {
        try
        {
            Anmeldelse anm = new Anmeldelse();
            anm.ProduktID = Convert.ToInt32(lblAnmeldProduktID.Text);
            anm.Tittel = tbAnmeldTittel.Text;
            anm.Tekst = tbAnmeldTekst.Text;
            anm.Karakter = Convert.ToInt32(ddlAnmeldKarakter.SelectedValue);

            anmBLL.nyAnmeldelse(anm);

            lblAnmeldOppdatert.Text = "Anmeldelsen er lagret!";
        }
        catch (Exception ex)
        {
            lblAnmeldOppdatert.Text = ex.Message;
        }
    }
    protected void tbAnmeldTekst_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_Select(object sender, EventArgs e)
    {
        
    }
    protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //GridView gw = (GridView)sender;
        //Response.Write("gw.SelectedRow: " + gw.SelectedRow + "<br>");
        
        //GridViewRow grw = gw.SelectedRow;
        //Response.Write("grw.Cells: " + grw.Cells + "<br>");
        //pnlAnmeld.Visible = true;
    }
    protected void tbAnmeldTittel_TextChanged(object sender, EventArgs e)
    {

    }
}
