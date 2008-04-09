using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.Model;

namespace myApp.ClientDAL
{
    class OrdrelinjeDAL : IOrdrelinjeDAL
    {
        #region IOrdrelinjeBLL Members

        private WSOrdrelinjeDAL.OrdrelinjeDAL ordrelinjeDAL = new WSOrdrelinjeDAL.OrdrelinjeDAL();

        public List<Ordrelinje> getOrdrelinjer(int ordreID)
        {
            List<Ordrelinje> ordrelinjer = ordrelinjeDAL.getOrdrelinjer(ordreID);
            return ordrelinjer;
        }

        public Ordrelinje getOrdrelinje(int ordrelinjeID)
        {
            Ordrelinje ordrelinje = ordrelinjeDAL.getOrdrelinje(ordrelinjeID);
            return ordrelinje;
        }

        public void nyOrdrelinje(Ordrelinje ol)
        {
            ordrelinjeDAL.nyOrdrelinje(ol);
        }

        public void slettOrdrelinje(int ordrelinjeID)
        {
            ordrelinjeDAL.slettOrdrelinje(ordrelinjeID);
        }

        public List<Ordrelinje> getOrdrelinjerFraBrukernavn(string brukernavn)
        {
            return ordrelinjeDAL.getOrdrelinjerFraBrukernavn(brukernavn);
        }
        #endregion
    }
}
