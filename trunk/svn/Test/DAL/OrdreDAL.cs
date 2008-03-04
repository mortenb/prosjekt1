using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using Prosjekt2.Modell;
using Prosjekt2.IDAL;

namespace Prosjekt2.DAL
{
    public class OrdreDAL : IOrdreDAL
    {
        #region IOrdreDAL Members


        public Ordre getOrdre(int ordreID)
        {
            string query = @"Select * from Ordre where id = @id";
            Ordre o = new Ordre();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i spørringen
                    myCommand.Parameters.AddWithValue("@id", ordreID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            o = GetOrdreFraSqlReader(ref reader);
                        }
                    }
                    /*
                     * No catch block, let exceptions be handles in the higher layers.
                     */
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); /* No using on reader, we must close. */
                        }
                    }
                }
            }
            return o;
        }

        public void nyOrdre(Ordre o)
        {
            string query = @"Insert into Ordre (dato) values (@dato)";
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i spørringen
                    myCommand.Parameters.AddWithValue("@dato", o.OrdreDato);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    try
                    {
                        int result = myCommand.ExecuteNonQuery();
                    }
                    finally
                    {

                    }
                }
            }

        }

        public void slettOrdre(int ordreID)
        {
            string query = @"Delete * from Ordre WHERE id = @id";
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i spørringen
                    myCommand.Parameters.AddWithValue("@id", ordreID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    int result = myCommand.ExecuteNonQuery();

                   
                }
            }
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
