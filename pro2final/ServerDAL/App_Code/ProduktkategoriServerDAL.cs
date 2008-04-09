using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using myApp.Model;
using System.Collections.Generic;

namespace ServerDAL
{
    /// <summary>
    /// Summary description for ProduktkategoriDAL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class ProduktkategoriDAL : System.Web.Services.WebService
    {
        private myApp.DAL.ProduktkategoriDAL pkDAL = new myApp.DAL.ProduktkategoriDAL();



        [WebMethod]
        public void nyProduktkategori(Produktkategori pk)
        {
            pkDAL.nyProduktkategori(pk);
            //throw new Exception("The method or operation is not implemented.");
        }
        
        [WebMethod]
        public void endreProduktkategori(Produktkategori pk)
        {
            pkDAL.endreProduktkategori(pk);
            //throw new Exception("The method or operation is not implemented.");
        }

        [WebMethod]
        public List<Produktkategori> getProduktkategorier()
        {
            List<Produktkategori> produktkategorier = pkDAL.getProduktkategorier();
            return produktkategorier;
            //throw new Exception("The methord or operation is not implemented.");
        }
    }
}
