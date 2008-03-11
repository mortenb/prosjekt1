using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.IBLL;
using myApp.Model;

namespace myApp.BLL
{
    public class OrdrelinjeBLL : myApp.IBLL.IOrdrelinjeBLL
    {
        #region IOrdrelinjeBLL Members

        private IOrdrelinjeDAL ordrelinjeDAL = DALLoader.getOrdrelinjeDAL();

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
