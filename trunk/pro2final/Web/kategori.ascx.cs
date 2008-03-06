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

public partial class kategori : System.Web.UI.UserControl
{
    IProduktkategoriBLL pkBLL = BLLLoader.GetProduktkategoriBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //f�rste gang siden blir �pnet, skal gridview'et fylles med blogger.
            //GridView1_Databind();
        }

        GridView1_Databind();
    }

    protected void GridView1_Databind()
    {
        Trace.Write("Pr�ver � binde data til kilden");
        
        try
        {
            List<Produktkategori> GridView1_liste = pkBLL.getProduktkategorier();
            
            if (GridView1_liste.Count > 0)
            {
                GridView1.DataSource = pkBLL.getProduktkategorier();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("Lista er tom<br>Vennligst opprett noen nye kategorier<br>S� lenge du er admin da<br>Hehe");
            }

        }
        catch (Exception ex)
        {
            Trace.Warn("DB'en tryna - kategori.ascx.cs");
            Trace.Warn(ex.Message);
        }
    }
}

