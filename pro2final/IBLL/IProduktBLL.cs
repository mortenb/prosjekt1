using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IBLL
{
    public interface IProduktBLL
    {

        List<Produkt> getProdukter(int produktkategoriID);

        List<Produkt> getProduktTilbud();

        void nyttProdukt(Produkt p);

        void endreProdukt(Produkt p);

        Produkt getProdukt(int produktID);

        List<Produkt> getKjoepteProdukter(string brukernavn);

        Produkt getNyesteProduktAvKategori(int pkID);
    }
}
