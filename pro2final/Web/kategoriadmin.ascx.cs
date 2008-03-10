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

public partial class kategoriadmin : System.Web.UI.UserControl
{
    private IProduktkategoriBLL pkBLL = BLLLoader.GetProduktkategoriBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            getKategorier();
    }

    private void getKategorier()
    {
        KatListe.Items.Clear();
        try
        {
            List<Produktkategori> kategoriliste = pkBLL.getProduktkategorier();

            if (kategoriliste.Count > 0)
            {
                KatListe.DataSource = kategoriliste;
                KatListe.DataBind();
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

        if (KatListe.Items.FindByText(s) == null && !s.Equals(""))
        {        
            pkat.Navn = s;
            if (PkIDlabel.Text.Equals(""))
                pkBLL.nyProduktkategori(pkat);
            else
            {
                pkat.ProduktkategoriID = Convert.ToInt32(PkIDlabel.Text);
                Response.Write("ID: " + pkat.ProduktkategoriID.ToString());
                pkBLL.endreProduktkategori(pkat);
                //PkIDlabel.Text="";
                //PkIDlabel.Visible=false;
            }
            KatNavn.Text = "";
            RedigerKategori.Text = "Legg til kategori";
            getKategorier();
        }
        else RequiredFieldValidator1.IsValid = false;
    }

    protected void KatListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        KatNavn.Text = KatListe.SelectedItem.Text;
        RedigerKategori.Text = "Endre kategori";
        PkIDlabel.Visible = true;
        PkTxt.Visible = true;
        PkIDlabel.Text = KatListe.SelectedValue.ToString();
    }

    protected void KatNavn_TextChanged(object sender, EventArgs e)
    {
        this.RedigerKategori.Enabled = true;
    }
}
