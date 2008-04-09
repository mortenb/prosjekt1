using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.Model;

namespace myApp.ClientDAL
{
    class ProduktkategoriDAL : IProduktkategoriDAL
    {

        private WSProduktkategoriDAL.ProduktkategoriDAL pkDAL = new WSProduktkategoriDAL.ProduktkategoriDAL();

        public void nyProduktkategori(Produktkategori pk)
        {
            pkDAL.nyProduktkategori(pk);
            //throw new Exception("The method or operation is not implemented.");
        }

        public void endreProduktkategori(Produktkategori pk)
        {
            pkDAL.endreProduktkategori(pk);
            //throw new Exception("The method or operation is not implemented.");
        }

        public List<Produktkategori> getProduktkategorier()
        {
            List<Produktkategori> produktkategorier = pkDAL.getProduktkategorier();
            return produktkategorier;
            //throw new Exception("The methord or operation is not implemented.");
        }

    }
}
