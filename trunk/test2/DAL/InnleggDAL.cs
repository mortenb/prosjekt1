using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace DOTNETPROSJEKT1.DAL
{
    public static class InnleggDAL
    {
        public static bool slettInnlegg(int innleggID)
        {
            //Metode for � slette innlegg fra innleggtabellen
            string query = @"
                                DELETE
                                FROM innlegg
                                WHERE innlegg.id = @innleggID
                            ";

            bool ok = false;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@innleggID", innleggID);
                    int result = myCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        ok = true;
                    }
                }
            }

            return ok;
        }

        public static void nyttInnlegg(Innlegg innlegg)
        {
            string query = @"
                                INSERT INTO innlegg (id, bloggID, tittel, dato, tekst) VALUES (@id, @bloggID, @tittel, @dato, @tekst)
                            ";


            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", innlegg.ID);
                    myCommand.Parameters.AddWithValue("@bloggID", innlegg.BloggID);
                    myCommand.Parameters.AddWithValue("@tittel", innlegg.Tittel);
                    myCommand.Parameters.AddWithValue("@dato", innlegg.Dato);
                    myCommand.Parameters.AddWithValue("@tekst", innlegg.Tekst);
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        innlegg.ID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Tryna n�r jeg pr�vde � lage ny bruker.. Beklager");
                    }
                }
            }
        }

        public static Innlegg getInnlegg(int innleggID)
        {
            Innlegg innlegg = new Innlegg();

            string query = @"
                                SELECT *
                                FROM innlegg
                                WHERE innlegg.id = @innleggID
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    myCommand.Parameters.AddWithValue("@innleggID", innleggID);
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            innlegg = InnleggFraSqlReader(ref reader);
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

            return innlegg;
        }

        public static bool endreTekst(int innleggID, string tekst)
        {
            string query = @"
                                UPDATE innlegg 
                                SET tekst = @tekst
                                WHERE id = @innleggID
                            ";

            bool ok = false;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", innleggID);
                    myCommand.Parameters.AddWithValue("@tekst", tekst);
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        ok = true;
                    }
                    else
                    {
                        throw new ApplicationException("Tryna n�r jeg pr�vde � lage ny innlegg.. Beklager");
                    }
                }
            }

            return ok;
        }

        public static List<Innlegg> getInnleggsListe(Blog blog)
        {
            string query = @"
                                SELECT innlegg.*
                                FROM innlegg
                                WHERE bloggID = @bloggID
                            ";

            List<Innlegg> innlegg = new List<Innlegg>();

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@bloggID", blog.BlogID); 
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            innlegg.Add(InnleggFraSqlReader(ref reader));
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

            return innlegg;
        }

        private static Innlegg InnleggFraSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            Innlegg innlegg = new Innlegg();

            if (reader["id"] != DBNull.Value)
            {
                innlegg.ID = (int)reader["id"];
            }

            if (reader["bloggID"] != DBNull.Value)
            {
                innlegg.BloggID = (int)reader["bloggID"];
            }

            if (reader["tittel"] != DBNull.Value)
            {
                innlegg.Tittel = (string)reader["tittel"];
            }

            if (reader["dato"] != DBNull.Value)
            {
                innlegg.Dato = (DateTime)reader["dato"];
            }

            if (reader["tekst"] != DBNull.Value)
            {
                innlegg.Tekst = (string)reader["tekst"];
            }

            return innlegg;
        }

    }
}
