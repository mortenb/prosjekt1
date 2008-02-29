using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IDAL
{
    public interface IProduktkategoriDAL
    {
        void nyProduktkategori(Produktkategori pk);

        void endreProduktkategori(Produktkategori pk);
    }
}
