using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using DOTNETPROSJEKT1.Model;


namespace DOTNETPROSJEKT1.DAL
{
    public static class BrukerDAL
    {
        public static List<Bruker> getBrukere()
        {
            string query = @"
                                SELECT *
                                FROM Brukere
                            ";
           
            List<Bruker> brukere = new List<Bruker>();

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            brukere.Add(BrukerFraSqlReader(ref reader));
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

            return brukere;
        }

        public static void login(string brukernavn, string pass)
        {

        }

        public static Bruker getBruker(string brukernavn)
        {
            Bruker b = new Bruker();

            return b;
        }

        public static Bruker nyBruker(Bruker bruker)
        {
            Console.WriteLine("BrukerDAL.nyBruker()");
            string query = @"
                                INSERT INTO brukere (id, brukernavn, fornavn) VALUES (@id, @brukernavn, @fornavn)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", bruker.Id);
                    myCommand.Parameters.AddWithValue("@brukernavn", bruker.Brukernavn);
                    myCommand.Parameters.AddWithValue("@fornavn", bruker.Fornavn);
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        bruker.Id = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bruker.. Beklager");
                    }
                }
            }

            return bruker;
        }


        private static Bruker BrukerFraSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            Bruker bruker = new Bruker();

            if (reader["id"] != DBNull.Value)
            {
                bruker.Id = (int)reader["id"];
            }

            if (reader["brukernavn"] != DBNull.Value)
            {
                bruker.Brukernavn = (string)reader["brukernavn"];
            }

            if (reader["fornavn"] != DBNull.Value)
            {
                bruker.Fornavn = (string)reader["fornavn"];
            }

            return bruker;
        }


    }
}
