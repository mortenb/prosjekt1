using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IDAL
{
    interface IProduktDAL
    {

        List<Produkt> getProdukter();

        List<Produkt> getProduktTilbud();

        void nyttProdukt(Produkt p);

        void endreProdukt(Produkt p);
    }
}
