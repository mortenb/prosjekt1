using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IDAL
{
    public interface IProduktDAL
    {

        List<Produkt> getProdukter(int produktkategoriID);

        List<Produkt> getProduktTilbud();

        void nyttProdukt(Produkt p);

        void endreProdukt(Produkt p);

        Produkt getProdukt(int produktID);
    }
}
