using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using Prosjekt2.Modell;
using Prosjekt2.IDAL;

namespace Prosjekt2.DAL
{
    public class OrdrelinjeDAL : IOrdrelinjeDAL
    {
        public Ordrelinje getOrdrelinje(int ordrelinjeID)
        {
            //returnerer en ordrelinje.
            string query = @"Select * from OrdreLinje where id = @id";
            Ordrelinje ol = new Ordrelinje();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i spørringen
                    myCommand.Parameters.AddWithValue("@id", ordrelinjeID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            ol = getOrdrelinjeFraSqlReader(ref reader);
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
            
            return ol;
        }

        //Returnerer alle ordrelinjer tilhørende en ordre:::
        public List<Ordrelinje> getOrdrelinjer(int ordreID)
        {
            List<Ordrelinje> ordrelinjer = new List<Ordrelinje>();
            string query = @"Select * from ordrelinjer where FKOrdreID = @id";
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
                            ordrelinjer.Add(getOrdrelinjeFraSqlReader(ref reader));
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
            return ordrelinjer;
        }

        public void slettOrdrelinje(int ordrelinjeID)
        {
            string query = @"Delete * from OrdreLinje WHERE id = @id";
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i spørringen
                    myCommand.Parameters.AddWithValue("@id", ordrelinjeID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    int result = myCommand.ExecuteNonQuery();

                    //har ingen sjekk her. Kanskje gjøre noe med det.
                }
            }
        }

        public void nyOrdrelinje(Ordrelinje ol)
        {
            string query = @"
                                INSERT INTO OrdreLinje (antall, produktID, FKOrdreID) VALUES (@antall, @produktID, @ordreID)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@antall", ol.Antall);
                    myCommand.Parameters.AddWithValue("@produktID", ol.ProduktID);
                    myCommand.Parameters.AddWithValue("@ordreID", ol.OrdreID);

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        ol.OrdrelinjeID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Klarte ikke opprette ordrelinje!");
                    }
                }
            }
        }

        private Ordrelinje getOrdrelinjeFraSqlReader(ref SqlDataReader reader)
        { 
            Ordrelinje ol = new Ordrelinje();

            if (reader["id"] != DBNull.Value)
            {
                ol.OrdrelinjeID = (int)reader["id"];
            }

            if (reader["antall"] != DBNull.Value)
            {
                ol.Antall = (int) reader["antall"];
            }

            if (reader["produktID"] != DBNull.Value)
            {
                ol.ProduktID  = (int) reader["produktID"];
            }
            return ol;
        }
    }
}
