using System;
using System.Collections.Generic;
using System.Text;

using Prosjekt2.Modell;
using Prosjekt2.IDAL;

namespace Prosjekt2.DAL
{
    public class OrdrelinjeDAL : IOrdrelinjeDAL
    {
        public Ordrelinje getOrdrelinje(int ordrelinjeID)
        {
            return new Ordrelinje();
        }

        public List<Ordrelinje> getOrdrelinjer(int ordreID)
        {
            return new List<Ordrelinje>();
        }

        public void slettOrdrelinje(int ordrelinjeID)
        {

        }

        public void nyOrdrelinje(Ordrelinje ol)
        {

        }
    }
}
