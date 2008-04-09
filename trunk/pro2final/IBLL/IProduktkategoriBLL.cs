using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IBLL
{
    public interface IProduktkategoriBLL
    {
        void nyProduktkategori(Produktkategori pk);
        void endreProduktkategori(Produktkategori pk);

        List<Produktkategori> getProduktkategorier();
    }
}
