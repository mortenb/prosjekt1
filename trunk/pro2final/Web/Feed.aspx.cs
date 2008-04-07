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
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using myApp.Model;
using myApp.IBLL;
using System.Collections.Generic;


public partial class Feed : System.Web.UI.Page
{
    private IProduktBLL produktBLL = BLLLoader.GetProduktBLL();
    private IProduktkategoriBLL pkBLL = BLLLoader.GetProduktkategoriBLL();

    private string[] queryStrings;
    private int pkID;
    private List<Produkt> produkter;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 0)
        {
            Response.Write("Du trenger å fylle inn en kategoriID");

        }
        else
        {
            // Opprett liste over produkter fra valgt produktkategori
            // Henter liste ut fra pkID i queryString
            queryStrings = Request.QueryString.GetValues(0);
            //try
            //{
                pkID = Convert.ToInt32(queryStrings[0]);
                produkter = produktBLL.getProdukter(pkID);

                Response.Clear();

                Response.ContentType = "text/xml";

                XmlTextWriter xtwFeed = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

                xtwFeed.WriteStartDocument();

                xtwFeed.WriteStartElement("rss");

                xtwFeed.WriteAttributeString("version", "2.0");
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteStartElement("channel");
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteElementString("title", "Komplett Dot No");
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteElementString("link", "Default.aspx");
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteElementString("description", "De siste produktene fra valgt produktkategori.");
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteElementString("language", "no");
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteElementString("copyright", "Copyright 2008 Gruppe 01. Alle rettigheter reservert.");
                xtwFeed.WriteWhitespace(Environment.NewLine);
                foreach (Produkt listeProdukt in produkter)
                {
                    xtwFeed.WriteStartElement("item");
                    xtwFeed.WriteWhitespace(Environment.NewLine);
                    xtwFeed.WriteElementString("title", listeProdukt.Tittel);
                    xtwFeed.WriteWhitespace(Environment.NewLine);
                    xtwFeed.WriteElementString("description", listeProdukt.Beskrivelse);
                    xtwFeed.WriteWhitespace(Environment.NewLine);
                    xtwFeed.WriteElementString("link", "Default.aspx?kat=" + pkID);
                    xtwFeed.WriteWhitespace(Environment.NewLine);
                    xtwFeed.WriteEndElement();
                    xtwFeed.WriteWhitespace(Environment.NewLine);
                }



                // Lukk alle tagger

                xtwFeed.WriteEndElement();
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteEndElement();
                xtwFeed.WriteWhitespace(Environment.NewLine);
                xtwFeed.WriteEndDocument();

                xtwFeed.Flush();

                xtwFeed.Close();

                Response.End();
            //}
            //catch (Exception ex)
            //{
              //  Response.Write("Det er noe galt med queryString");
            //}
           
            

            
        }

    }
}
