using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IDAL
{
    interface IProduktkategoriDAL
    {
        void nyProduktkategori(ProduktKategori pk);
        void endreProduktkategori(ProduktKategori pk);
    }
}
