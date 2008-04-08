using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using myApp.Model;

namespace ServerDAL
{
    /// <summary>
    /// Summary description for OrdreDAL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class OrdreDAL : System.Web.Services.WebService
    {
        private myApp.DAL.OrdreDAL ordreDAL = new myApp.DAL.OrdreDAL();

        [WebMethod]
        public Ordre getOrdre(int ordreID)
        {
            Ordre ordre = ordreDAL.getOrdre(ordreID);
            return ordre;
            //throw new Exception("The method or operation is not implemented.");
        }

        [WebMethod]
        public int nyOrdre(Ordre o)
        {
            return ordreDAL.nyOrdre(o);

        }

        [WebMethod]
        public void slettOrdre(int ordreID)
        {
            ordreDAL.slettOrdre(ordreID);
        }
    }
}
