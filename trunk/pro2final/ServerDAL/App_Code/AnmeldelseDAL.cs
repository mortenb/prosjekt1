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
    /// Summary description for AnmeldelseDAL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class AnmeldelseDAL : System.Web.Services.WebService
    {
        myApp.DAL.AnmeldelseDAL anmeldelseDAL = new myApp.DAL.AnmeldelseDAL();

        [WebMethod]
        public List<Anmeldelse> getAnmeldelser(int produktID)
        {
            List<Anmeldelse> anmeldelser = anmeldelseDAL.getAnmeldelser(produktID);

            //throw new Exception("The method or operation is not implemented.");
            return anmeldelser;

        }

        [WebMethod]
        public Anmeldelse getAnmeldelse(int anmID)
        {
            Anmeldelse anm = anmeldelseDAL.getAnmeldelse(anmID);

            return anm;
        }

        [WebMethod]
        public void nyAnmeldelse(Anmeldelse anm)
        {
            anmeldelseDAL.nyAnmeldelse(anm);
        }
    }
}
