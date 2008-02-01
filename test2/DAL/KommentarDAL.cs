using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.Model;
using System.Data.SqlClient;
using System.Configuration;

namespace DOTNETPROSJEKT1.DAL
{
    public static class KommentarDAL
    {
        public static bool nyKommentar(Kommentar kommentar)
        {
            string query = @"
                                INSERT INTO kommentar (id, innleggID, tittel, dato, tekst, forfatter) VALUES (@id, @innleggID, @tittel, @dato, @tekst, @forfatter)
                            ";

            bool ok = false;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", kommentar.ForeldreID);
                    myCommand.Parameters.AddWithValue("@innleggID", kommentar.InnleggID);
                    myCommand.Parameters.AddWithValue("@tittel", kommentar.Tittel);
                    myCommand.Parameters.AddWithValue("@dato", kommentar.Dato);
                    myCommand.Parameters.AddWithValue("@tekst", kommentar.Tekst);
                    myCommand.Parameters.AddWithValue("@forfatter", kommentar.Forfatter);
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        ok = true;
                    }
                    else
                    {
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bommentar.. Beklager");
                    }
                }
            }

            return ok;
        }

        public static bool slettKommentar(int kommentarID)
        {
            string query = @"
                                DELETE
                                FROM kommentar
                                WHERE kommentar.id = @kommentarID
                            ";

            bool ok = false;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@kommentarID", kommentarID);
                    int result = myCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        ok = true;
                    }
                }
            }

            return ok;
        }

        public static bool redigerKommentar(int kommentarID, string tekst)
        {
            string query = @"
                                UPDATE kommentar 
                                SET tekst = @tekst
                                WHERE id = @kommentarID
                            ";

            bool ok = false;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", kommentarID);
                    myCommand.Parameters.AddWithValue("@tekst", tekst);
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        ok = true;
                    }
                    else
                    {
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bommentar.. Beklager");
                    }
                }
            }

            return ok;
        }

        public static List<Kommentar> getKommentarListe(int innleggID)
        {
            string query = @"
                                SELECT kommentar.*
                                FROM kommentar,innlegg
                                WHERE kommentar.innleggID = @innleggID
                            ";

            List<Kommentar> kommentarer = new List<Kommentar>();

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@innleggID", innleggID);
                    // Note we can not use "using" on the reader because of the call to GetUserFromSqlReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            kommentarer.Add(KommentarFraSqlReader(ref reader));
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

            return kommentarer;
        }

    private static Kommentar KommentarFraSqlReader(ref SqlDataReader reader) // Ref to avoid large copys in memory.
        {
            Kommentar kommentar = new Kommentar();

            if (reader["id"] != DBNull.Value)
            {
                kommentar.ID = (int)reader["id"];
            }

            if (reader["innleggID"] != DBNull.Value)
            {
                kommentar.InnleggID = (int)reader["innleggID"];
            }

            if (reader["tittel"] != DBNull.Value)
            {
                kommentar.Tittel = (string)reader["tittel"];
            }

            if (reader["dato"] != DBNull.Value)
            {
                kommentar.Dato = (DateTime)reader["dato"];
            }

            if (reader["tekst"] != DBNull.Value)
            {
                kommentar.Tekst = (string)reader["tekst"];
            }

            if (reader["forfatter"] != DBNull.Value)
            {
                kommentar.Forfatter = (string)reader["forfatter"];
            }

            return kommentar;
        }

    }

}
