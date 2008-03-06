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

        private IProduktkategoriDAL pkDAL = DALLoader.getProduktkategoriDAL();

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

        #endregion
    }
}
