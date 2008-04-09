using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using myApp.Model;

namespace ServerDAL
{
    /// <summary>
    /// Summary description for OrdrelinjeDAL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class OrdrelinjeServerDAL : System.Web.Services.WebService
    {
        private myApp.DAL.OrdrelinjeDAL ordrelinjeDAL = new myApp.DAL.OrdrelinjeDAL();

        [SoapDocumentMethod(Binding = "OverloadedGetOrdrelinjer")]
        [WebMethod]
        public List<Ordrelinje> getOrdrelinjer(int ordreID)
        {
            List<Ordrelinje> ordrelinjer = ordrelinjeDAL.getOrdrelinjer(ordreID);
            return ordrelinjer;
        }
        
        [WebMethod]
        public Ordrelinje getOrdrelinje(int ordrelinjeID)
        {
            Ordrelinje ordrelinje = ordrelinjeDAL.getOrdrelinje(ordrelinjeID);
            return ordrelinje;
        }

        [WebMethod]
        public void nyOrdrelinje(Ordrelinje ol)
        {
            ordrelinjeDAL.nyOrdrelinje(ol);
        }

        [WebMethod]
        public void slettOrdrelinje(int ordrelinjeID)
        {
            ordrelinjeDAL.slettOrdrelinje(ordrelinjeID);
        }

        [WebMethod]
        public List<Ordrelinje> getOrdrelinjerFraBrukernavn(string brukernavn)
        {
            return ordrelinjeDAL.getOrdrelinjerFraBrukernavn(brukernavn);
        }
    }
}
