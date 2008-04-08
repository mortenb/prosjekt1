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
    /// Summary description for NyhetDAL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class NyhetDAL : System.Web.Services.WebService
    {
        private myApp.DAL.NyhetDAL nyhetDAL = new myApp.DAL.NyhetDAL();
        
        [WebMethod]
        public List<Nyhet> getNyheter()
        {
            List<Nyhet> nyheter = nyhetDAL.getNyheter();
            //throw new Exception("The method or operation is not implemented.");
            return nyheter;
        }

        [WebMethod]
        public Nyhet getNyhet(int nyhetID)
        {
            Nyhet nyhet = nyhetDAL.getNyhet(nyhetID);
            //throw new Exception("The method or operation is not implemented.");
            return nyhet;
        }
        
        [WebMethod]
        public void nyNyhet(Nyhet n)
        {
            nyhetDAL.nyNyhet(n);
        }

        [WebMethod]
        public void endreNyhet(Nyhet n)
        {
            nyhetDAL.endreNyhet(n);
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
