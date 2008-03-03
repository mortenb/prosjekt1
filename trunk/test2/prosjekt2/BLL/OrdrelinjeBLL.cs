using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.IDAL;
using Prosjekt2.IBLL;
using Prosjekt2.Modell;
using IBLL;

namespace BLL
{
    public class OrdrelinjeBLL : IOrdrelinjeBLL
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
        #endregion
    }
}
