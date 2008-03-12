using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.IBLL;
using myApp.Model;

namespace myApp.BLL
{
    public class ProduktBLL : IProduktBLL
    {
        #region IProduktBLL Members

        private IProduktDAL produktDAL = DALLoader.getProduktDAL();
        private IOrdreDAL ordreDAL = DALLoader.getOrdreDAL();
        private IOrdrelinjeDAL ordrelinjeDAL = DALLoader.getOrdrelinjeDAL();

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

            List<Produkt> lstKjoepteProdukter = produktDAL.getKjoepteProdukter(brukernavn);

            foreach (Produkt listeProdukt in lstKjoepteProdukter)
            {
                
            }
            Produkt prod = produktDAL.getNyesteProduktAvKategori(brukernavn);


            return prod;

            //Hente produkt fra produktDAL
        }

        public List<Produkt> getKjoepteProdukter(string brukernavn)
        {
            List<Produkt> lstKjoepteProdukter = produktDAL.getKjoepteProdukter(brukernavn);

            return lstKjoepteProdukter;
        }

        #endregion
    }
}
