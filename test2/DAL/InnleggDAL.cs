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

        public static bool nyKommentar(int innleggID, string tekst)
        {
            return false;
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
            return false;
        }

        public static bool slettKommentar(int innleggID)
        {
            return false;
        }

        public static bool redigerKommentar(int kommentarID, string tekst)
        {
            return false;
        }

        public static List<Innlegg> getInnleggsListe(Blog blogg)
        {
            string query = @"
                                SELECT innlegg.*
                                FROM innlegg,blogg
                                WHERE bloggID = @bloggID
                            ";

            List<Innlegg> innlegg = new List<Innlegg>();

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@bloggID", blogg.BlogID); 
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
                innlegg.Dato = (Calendar)reader["dato"];
            }

            if (reader["tekst"] != DBNull.Value)
            {
                innlegg.Tekst = (string)reader["tekst"];
            }

            return innlegg;
        }

    }
}
