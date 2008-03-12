using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using myApp.Model;
using myApp.IDAL;

namespace myApp.DAL
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
                    //Legge til nyhetID i sp�rringen
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

        public int nyOrdre(Ordre o)
        {
            string query = @"Insert into Ordre (dato, brukernavn) values (@dato, @brukernavn)";
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legge til nyhetID i sp�rringen
                    myCommand.Parameters.AddWithValue("@dato", o.OrdreDato);
                    myCommand.Parameters.AddWithValue("@brukernavn", o.Brukernavn);
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    
                        int result = myCommand.ExecuteNonQuery();
                        if (result == 1)
                        {
                            myCommand.CommandText = "SELECT @@IDENTITY";
                            int id = Convert.ToInt32(myCommand.ExecuteScalar());
                            return id;
                        }
                        else
                        {
                            throw new ApplicationException("Klarte ikke opprette nyhet!");
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
                    //Legge til nyhetID i sp�rringen
                    myCommand.Parameters.AddWithValue("@id", ordreID);

                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    int result = myCommand.ExecuteNonQuery();

                   
                }
            }
        }

        

        public int getProduktkategoriIDFraOrdre(string brukernavn)
        {
            return -1;
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

            if (reader["brukernavn"] != DBNull.Value)
            {
                ord.Brukernavn = (string)reader["brukernavn"];
            }

            return ord;
        }

        #endregion
    }
}