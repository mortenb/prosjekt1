using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ProduktDAL : Prosjekt2.IDAL.IProduktDAL
    {
        #region IProduktDAL Members

        public List<Prosjekt2.Modell.Produkt> getProdukter()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<Prosjekt2.Modell.Produkt> getProduktTilbud()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void nyttProdukt(Prosjekt2.Modell.Produkt p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void endreProdukt(Prosjekt2.Modell.Produkt p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
