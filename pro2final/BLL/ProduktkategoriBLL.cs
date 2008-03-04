using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.IBLL;
using myApp.Model;

namespace myApp.BLL
{
    public class ProduktkategoriBLL : IProduktkategoriBLL
    {
        #region IProduktkategoriBLL Members

        private IProduktkategoriDAL produktkategoriDAL = DALLoader.getProduktKategoriDAL();

        public void nyProduktkategori(Produktkategori pk)
        {
            produktkategoriDAL.nyProduktkategori(pk);
            //throw new Exception("The method or operation is not implemented.");
        }

        public void endreProduktkategori(Produktkategori pk)
        {
            produktkategoriDAL.endreProduktkategori(pk);
            //throw new Exception("The method or operation is not implemented.");
        }

        public List<Produktkategori> getProduktkategorier()
        {
            List<Produktkategori> produktkategorier = produktkategoriDAL.getProduktkategorier();
            return produktkategorier;
            //throw new Exception("The methord or operation is not implemented.");
        }

        #endregion
    }
}
