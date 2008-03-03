using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.IDAL;
using Prosjekt2.IBLL;
using Prosjekt2.Modell;

namespace BLL
{
    public class ProduktBLL : IProduktBLL
    {
        #region IProduktBLL Members

        private IProduktDAL produktDAL = DALLoader.getProduktDAL();

        public List<Produkt> getProdukter()
        {
            List<Produkt> produkter = produktDAL.getProdukter();
            return produkter;
            //throw new Exception("The method or operation is not implemented.");
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

        #endregion
    }
}
