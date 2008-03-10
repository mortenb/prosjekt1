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

public partial class produktadmin : System.Web.UI.UserControl
{
    private IProduktkategoriBLL pkBLL = BLLLoader.GetProduktkategoriBLL();
    private IProduktBLL pBLL = BLLLoader.GetProduktBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getKategorier();
        }
    }

    private void getKategorier()
    {
        try
        {
            List<Produktkategori> kategoriliste = pkBLL.getProduktkategorier();

            if (kategoriliste.Count > 0)
            {
                PKListe.DataSource = kategoriliste;
                PKListe.DataBind();
            }
            else
                PKListe.Items.Add("ingen kategorier er opprettet.");
        }
        catch (Exception ex)
        {
            Trace.Warn("DB'en tryna - produktadmin.ascx.cs");
            Trace.Warn(ex.Message);
        }
    }

    private void getProdukter(int pkID)
    {
        Produktliste.Items.Clear();
        try
        {
            List<Produkt> produkter = pBLL.getProdukter((pkID));

            if (produkter.Count > 0)
            {
                Produktliste.DataSource = produkter;
                Produktliste.DataBind();
            }
            else
            {
                Produktliste.Items.Add(new ListItem("ingen produkter er opprettet.", "0"));
            }
        }
        catch (Exception ex)
        {
            Trace.Warn("DB'en tryna - produktadmin.ascx.cs");
            Trace.Warn(ex.Message);
        }
    }

    protected void PKListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        int pkID = Convert.ToInt32(PKListe.SelectedValue.ToString());
        reset();
        getProdukter(pkID);
        Send.Visible= true;
        Produkttabell.Visible = true;
        ProdValg.Visible = true;
    }

    protected void Produktliste_SelectedIndexChanged(object sender, EventArgs e)
    {
        Produkt p = new Produkt();
        int PID = Convert.ToInt32(Produktliste.SelectedValue.ToString());
        if (PID > 0)
        {
            p = pBLL.getProdukt(PID);
            this.Tittel.Text = p.Tittel;
            this.Beskrivelse.Text = p.Beskrivelse;
            this.Pris.Text = p.Pris.ToString();
            this.Lagerstatus.Text = p.AntallPaaLager.ToString();
        }
    }

    private void reset()
    {
        this.Tittel.Text = "";
        this.Beskrivelse.Text = "";
        this.Lagerstatus.Text = "";
        this.Pris.Text = "";
        Send.Visible = false;
        Produkttabell.Visible = false;
        ProdValg.Visible = false;
        Produktliste.Items.Clear();
        Produktliste.Items.Add(new ListItem("Velg kategori", "0", false));
    }

    protected void Send_Click(object sender, EventArgs e)
    {
        Produkt p = new Produkt();
        bool feil = false;
        int PKID = 0;
        int PID = -1;
        p.Tittel = Tittel.Text.ToString();
        p.Beskrivelse = Beskrivelse.Text.ToString();
        p.BildeURL = "";

        try
        {
            PKID = Convert.ToInt32(PKListe.SelectedValue.ToString());
            p.ProduktkategoriID = PKID;
        }
        catch (Exception exp)
        {
            feil = true;
            Trace.Warn("Klarte ikke hente produktID: produktadmin ascx.cs: " + exp.Message);
        }

        try
        {
            PID = Convert.ToInt32(Produktliste.SelectedValue.ToString());
        }
        catch (Exception exp)
        {
            Trace.Warn("Klarte ikke hente produktID: produktadmin ascx.cs: " + exp.Message);
        }

        try
        {
            int pPris = Convert.ToInt32(Pris.Text.ToString());
            p.Pris = pPris;
        }

        catch (Exception ex)
        {
            feil = true;
            Trace.Warn(ex.Message);
            PrisValidator.IsValid = false;
        }
        try
        {
            int antall = Convert.ToInt32(Lagerstatus.Text.ToString());
            p.AntallPaaLager = antall;
        }
        catch (Exception ex)
        {
            feil = true;
            Trace.Warn(ex.Message);
            AntallValidator.IsValid = false;
        }

        if (!feil)
        {
            if (PID > 0)
            {
                p.ProduktID = PID;
                pBLL.endreProdukt(p);
            }
            else
                pBLL.nyttProdukt(p);

            reset();
            PKListe.SelectedIndex = -1;
        }
    }
}
