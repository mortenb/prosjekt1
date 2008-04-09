using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;
using myApp.IDAL;

namespace myApp.ClientDAL
{
    class AnmeldelseDAL : IAnmeldelseDAL
    {
        #region IAnmeldelseBLL Members

        private WSAnmeldelseDAL.AnmeldelseDAL anmeldelseDAL = new WSAnmeldelseDAL.AnmeldelseDAL();

        public List<Anmeldelse> getAnmeldelser(int produktID)
        {
            List<Anmeldelse> anmeldelser = anmeldelseDAL.getAnmeldelser(produktID);
            //throw new Exception("The method or operation is not implemented.");
            return anmeldelser;

        }

        public Anmeldelse getAnmeldelse(int anmID)
        {
            Anmeldelse anm = anmeldelseDAL.getAnmeldelse(anmID);

            return anm;
        }

        public void nyAnmeldelse(Anmeldelse anm)
        {
            anmeldelseDAL.nyAnmeldelse(anm);
        }

        #endregion

    }
}
