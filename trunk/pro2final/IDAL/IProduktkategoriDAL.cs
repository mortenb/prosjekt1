using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IDAL
{
    public interface IProduktkategoriDAL
    {
        void nyProduktkategori(Produktkategori pk);

        void endreProduktkategori(Produktkategori pk);

        List<Produktkategori> getProduktkategorier();

    }
}
