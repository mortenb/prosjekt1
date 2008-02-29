using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IBLL
{
    public interface IProduktBLL
    {

        List<Produkt> getProdukter();

        List<Produkt> getProduktTilbud();

        void nyttProdukt(Produkt p);

        void endreProdukt(Produkt p);
    }
}
