using System;
using System.Collections.Generic;
using System.Text;
using Modell;
namespace IBLL
{
    interface IProduktKategoriBLL
    {
        void nyProduktkategori(ProduktKategori pk);
        void endreProduktkategori(ProduktKategori pk);
    }
}
