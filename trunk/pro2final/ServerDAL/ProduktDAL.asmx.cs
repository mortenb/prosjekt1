using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using myApp.Model;

namespace ServerDAL
{
    /// <summary>
    /// Summary description for ProduktDAL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class ProduktDAL : System.Web.Services.WebService
    {
        private myApp.DAL.ProduktDAL produktDAL = new myApp.DAL.ProduktDAL();
        
        [WebMethod]
        public List<Produkt> getProdukter(int produktkategoriID)
        {
            List<Produkt> produkter = produktDAL.getProdukter(produktkategoriID);
            return produkter;
            //throw new Exception("The method or operation is not implemented.");
        }

        [WebMethod]
        public Produkt getProdukt(int produktID)
        {
            return produktDAL.getProdukt(produktID);
        }

        [WebMethod]
        public List<Produkt> getProduktTilbud()
        {
            List<Produkt> tilbudsprodukter = produktDAL.getProduktTilbud();
            return tilbudsprodukter;
            //throw new Exception("The method or operation is not implemented.");
        }

        [WebMethod]
        public void nyttProdukt(Produkt p)
        {
            produktDAL.nyttProdukt(p);
            //throw new Exception("The method or operation is not implemented.");
        }

        [WebMethod]
        public void endreProdukt(Produkt p)
        {
            produktDAL.endreProdukt(p);
            //throw new Exception("The method or operation is not implemented.");
        }

        [WebMethod]
        public Produkt getNyesteProduktFraPK(string brukernavn)
        {
            //Hente produktkategoriID ved hjelp av brukernavn
            //Dette må hentes fra ordre

            //List<Produkt> lstKjoepteProdukter = produktDAL.getKjoepteProdukter(brukernavn);

            //foreach (Produkt listeProdukt in lstKjoepteProdukter)
            //{
                
            //}
            //Produkt prod;

            //try
            //{
            //    prod = produktDAL.getNyesteProduktAvKategori(brukernavn);
            //}
            //catch (Exception ex)
            //{
                
            //    return null;
            //}


            //return prod;

            //Hente produkt fra produktDAL

            return null;
        }

        [WebMethod]
        public List<Produkt> getKjoepteProdukter(string brukernavn)
        {
            List<Produkt> lstKjoepteProdukter = produktDAL.getKjoepteProdukter(brukernavn);

            return lstKjoepteProdukter;
        }

        [WebMethod]
        public Produkt getNyesteProduktAvKategori(int pkID)
        {
            return produktDAL.getNyesteProduktAvKategori(pkID);
        }
    }
}
