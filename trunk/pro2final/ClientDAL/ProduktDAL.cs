using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.Model;

namespace myApp.ClientDAL
{
    class ProduktDAL : IProduktDAL
    {
        #region IProduktBLL Members

        private WSProduktDAL.ProduktDAL produktDAL = new WSProduktDAL.ProduktDAL();
        private WSOrdreDAL.OrdreDAL ordreDAL = new WSOrdreDAL.OrdreDAL();
        private WSOrdrelinjeDAL.OrdrelinjeDAL ordrelinjeDAL = new WSOrdrelinjeDAL.OrdrelinjeDAL();

        public List<Produkt> getProdukter(int produktkategoriID)
        {
            List<Produkt> produkter = produktDAL.getProdukter(produktkategoriID);
            return produkter;
            //throw new Exception("The method or operation is not implemented.");
        }

        public Produkt getProdukt(int produktID)
        {
            return produktDAL.getProdukt(produktID);
        }

        public List<Produkt> getProduktTilbud()
        {
            List<Produkt> tilbudsprodukter = produktDAL.getProduktTilbud();
            return tilbudsprodukter;
            //throw new Exception("The method or operation is not implemented.");
        }

        public void nyttProdukt(Produkt p)
        {
            produktDAL.nyttProdukt(p);
            //throw new Exception("The method or operation is not implemented.");
        }

        public void endreProdukt(Produkt p)
        {
            produktDAL.endreProdukt(p);
            //throw new Exception("The method or operation is not implemented.");
        }

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

        public List<Produkt> getKjoepteProdukter(string brukernavn)
        {
            List<Produkt> lstKjoepteProdukter = produktDAL.getKjoepteProdukter(brukernavn);

            return lstKjoepteProdukter;
        }

        public Produkt getNyesteProduktAvKategori(int pkID)
        {
            return produktDAL.getNyesteProduktAvKategori(pkID);
        }

        #endregion
    }
}
