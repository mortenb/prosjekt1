using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using Prosjekt2.Modell;
using Prosjekt2.IDAL;

namespace Prosjekt2.DAL
{
    public class OrdreDAL : Prosjekt2.IDAL.IOrdreDAL
    {
        #region IOrdreDAL Members

        public void LeggTilOrdrelinje(Prosjekt2.Modell.OrdreLinje ol)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Prosjekt2.Modell.Ordre getOrdre()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void nyOrdre(Prosjekt2.Modell.Ordre o)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private Ordre GetOrdreFraSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            Ordre ord = new Ordre();

            if (reader["id"] != DBNull.Value)
            {
                ord.OrdreID = (int)reader["id"];
            }

            if (reader["dato"] != DBNull.Value)
            {
                ord.OrdreDato = (DateTime)reader["dato"];
            }

            return ord;
        }

        #endregion
    }
}
