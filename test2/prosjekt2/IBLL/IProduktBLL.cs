using System;
using System.Collections.Generic;
using System.Text;
using Modell;
namespace IBLL
{
    public interface IProduktBLL
    {

        List<Produkt> getProdukter();

        List<Produkt> getProduktTilbud();

        void nyttProdukt(Produkt p);

        void endreProdukt(Produkt p);
    }
}
