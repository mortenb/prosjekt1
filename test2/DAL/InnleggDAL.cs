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
            //Gj�r klar sql-streng
            string query = @"
                                DELETE
                                FROM innlegg
                                WHERE innlegg.id = @innleggID
                            ";

            //Lager en bool som skal returneres for � si i fra til h�yere lag om det gikk greit eller ikke
            //Dette trengs kanskje ikke, for BLL kan jo bare try'e hele metoden
            //Men da f�r vi kanskje ikke riktig feilmelding tilbake?
            bool ok = false;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdi i sql-strengen
                    myCommand.Parameters.AddWithValue("@innleggID", innleggID);
                    //Legger antall rader som er forandret i result
                    int result = myCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //Hvis result er en s� har alt g�tt bra
                        ok = true;
                    }
                }
            }

            return ok;
        } //Kommentert

        public static void nyttInnlegg(Innlegg innlegg)
        {
            //F�r et innlegg fra �vre lag og legger det i databasen
            //Gj�r klar sql-streng
            string query = @"
                                INSERT INTO innlegg (id, bloggID, tittel, dato, tekst) VALUES (@id, @bloggID, @tittel, @dato, @tekst)
                            ";


            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-strengen
                    myCommand.Parameters.AddWithValue("@id", innlegg.ID);
                    myCommand.Parameters.AddWithValue("@bloggID", innlegg.BloggID);
                    myCommand.Parameters.AddWithValue("@tittel", innlegg.Tittel);
                    myCommand.Parameters.AddWithValue("@dato", innlegg.Dato);
                    myCommand.Parameters.AddWithValue("@tekst", innlegg.Tekst);
                    //Eksekverer og legger antall rader forandret i result
                    int result = myCommand.ExecuteNonQuery();


                    if (result == 1)
                    {
                        //Hvis result er 1 s� har alt g�tt bra,
                        //og innlegg f�r en ID
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        innlegg.ID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Tryna n�r jeg pr�vde � lage ny bruker.. Beklager");
                    }
                }
            }
        } //Kommentert

        public static Innlegg getInnlegg(int innleggID)
        {
            //Hente innlegg ved hjelp av et innleggs ID
            //Deklarer innlegg som skal returneres
            Innlegg innlegg = new Innlegg();

            //Gj�r klar sql-streng
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
                    //Legger til verdier i sql-streng
                    myCommand.Parameters.AddWithValue("@innleggID", innleggID);
                    //Eksekverer kommandoen og legger dette i en SqlDataReader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            //Leser rad for rad, og legger verdiene
                            //i innlegg ved hjelpemetode
                            innlegg = InnleggFraSqlReader(ref reader);
                        }
                    }
                    //Som Nils har p�pekt trenger vi ingen catch-blokk,
                    //for det er �vre lag som skal h�ndtere exceptions
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); //Lukker connection
                        }
                    }
                }
            }

            return innlegg;
        } //Kommentert

        public static bool endreTekst(int innleggID, string tekst)
        {
            //Metode for � redigere teksten p� et innlegg
            //TODO: B�r ogs� ha mulighet for � endre dato o.l. p� ett innlegg
            //Gj�r klar sql-streng
            string query = @"
                                UPDATE innlegg 
                                SET tekst = @tekst
                                WHERE id = @innleggID
                            ";
            //Lager en bool som sier i fra om oppdateringen har g�tt bra eller ikke
            bool ok = false;

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-streng
                    myCommand.Parameters.AddWithValue("@id", innleggID);
                    myCommand.Parameters.AddWithValue("@tekst", tekst);
                    //Eksekverer sql-streng og legger antall rader forandet i result
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        //Hvis result er 1, s� har alt g�tt bra
                        ok = true;
                    }
                    else
                    {
                        throw new ApplicationException("Tryna n�r jeg pr�vde � lage ny innlegg.. Beklager");
                    }
                }
            }

            return ok;
        } //Kommentert

        public static List<Innlegg> getInnleggsListe(Blog blog)
        {
            //Metode for � hente hele innleggslista og returnere et List-objekt
            //Gj�r klar sql-streng
            string query = @"
                                SELECT innlegg.*
                                FROM innlegg
                                WHERE bloggID = @bloggID
                            ";

            //Opprettet liste som skal returneres
            List<Innlegg> innlegg = new List<Innlegg>();

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-streng
                    myCommand.Parameters.AddWithValue("@bloggID", blog.BlogID); 
                    //Eksekverer kommando og legger radene i reader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            //Leser rad for rad og legger verdiene i lista
                            //ved hjelpemetode
                            innlegg.Add(InnleggFraSqlReader(ref reader));
                        }
                    }
                    //Som Nils har p�pekt er det �vre lag som skal h�ndtere exceptions
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); //Lukker connection
                        }
                    }
                }
            }

            return innlegg;
        } //Kommentert

        private static Innlegg InnleggFraSqlReader(ref SqlDataReader reader)
        {
            //Hjelpemetode for � gjenbruke kode litt
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
