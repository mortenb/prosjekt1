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
        public static void slettInnlegg(int innleggID)
        {
            //Metode for å slette innlegg fra innleggtabellen
            //Gjør klar sql-streng
            string query = @"
                                DELETE
                                FROM innlegg
                                WHERE innlegg.id = @innleggID
                            ";

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
                        //Hvis result er en så har alt gått bra
                    }
                    else
                    {
                        throw new ApplicationException("Kunne ikke slette innlegg med id " + innleggID);
                    }
                }
            }
        }

        public static void nyttInnlegg(Innlegg innlegg)
        {
            //Får et innlegg fra øvre lag og legger det i databasen
            //Gjør klar sql-streng
            string query = @"
                                INSERT INTO innlegg ( bloggID, tittel, dato, tekst) VALUES ( @bloggID, @tittel, @dato, @tekst)
                            ";


            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-strengen
                    //myCommand.Parameters.AddWithValue("@id", innlegg.ID);
                    myCommand.Parameters.AddWithValue("@bloggID", innlegg.ForeldreID);
                    myCommand.Parameters.AddWithValue("@tittel", innlegg.Tittel);
                    myCommand.Parameters.AddWithValue("@dato", innlegg.Dato);
                    myCommand.Parameters.AddWithValue("@tekst", innlegg.Tekst);
                    //Eksekverer og legger antall rader forandret i result
                    int result = myCommand.ExecuteNonQuery();


                    if (result == 1)
                    {
                        //Hvis result er 1 så har alt gått bra,
                        //og innlegg får en ID
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        innlegg.ID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bruker.. Beklager");
                    }
                }
            }
        } //Kommentert

        public static void redigerInnlegg(Innlegg innlegg)
        {
            //Får et innlegg fra øvre lag og legger det i databasen
            //Gjør klar sql-streng
            string query = @"
                                UPDATE innlegg 
                                SET tittel=@tittel, dato=@dato, tekst=@tekst
                                WHERE id=@id
                            ";


            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-strengen
                    myCommand.Parameters.AddWithValue("@id", innlegg.ID);
                    myCommand.Parameters.AddWithValue("@bloggID", innlegg.ForeldreID);
                    myCommand.Parameters.AddWithValue("@tittel", innlegg.Tittel);
                    myCommand.Parameters.AddWithValue("@dato", innlegg.Dato);
                    myCommand.Parameters.AddWithValue("@tekst", innlegg.Tekst);
                    //Eksekverer og legger antall rader forandret i result
                    int result = myCommand.ExecuteNonQuery();


                    if (result == 1)
                    {
                        //Hvis result er 1 så har alt gått bra,
                        //og innlegg får en ID
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        innlegg.ID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bruker.. Beklager");
                    }
                }
            }
        } //Kommentert

        public static Innlegg getInnlegg(int innleggID)
        {
            //Hente innlegg ved hjelp av et innleggs ID
            //Deklarer innlegg som skal returneres
            Innlegg innlegg = new Innlegg();

            //Gjør klar sql-streng
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
                    //Som Nils har påpekt trenger vi ingen catch-blokk,
                    //for det er øvre lag som skal håndtere exceptions
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

        public static void endreTekst(int innleggID, string tekst)
        {
            //Metode for å redigere teksten på et innlegg
            //TODO: Bør også ha mulighet for å endre dato o.l. på ett innlegg
            //Gjør klar sql-streng
            string query = @"
                                UPDATE innlegg 
                                SET tekst = @tekst
                                WHERE id = @innleggID
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-streng
                    myCommand.Parameters.AddWithValue("@innleggID", innleggID);
                    myCommand.Parameters.AddWithValue("@tekst", tekst);
                    //Eksekverer sql-streng og legger antall rader forandet i result
                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        //Hvis result er 1, så har alt gått bra
                    }
                    else
                    {
                        throw new ApplicationException("Nytt innlegg kunne ikke opprettes");
                    }
                }
            }
        } //Kommentert

        public static List<Innlegg> getInnleggsListe(int bloggID)
        {
            //Metode for å hente hele innleggslista og returnere et List-objekt
            //Gjør klar sql-streng
            string query = @"
                                SELECT *
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
                    myCommand.Parameters.AddWithValue("@bloggID", bloggID); 
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
                    //Som Nils har påpekt er det øvre lag som skal håndtere exceptions
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
            //Hjelpemetode for å gjenbruke kode litt
            Innlegg innlegg = new Innlegg();

            if (reader["id"] != DBNull.Value)
            {
                innlegg.ID = (int)reader["id"];
            }

            if (reader["bloggID"] != DBNull.Value)
            {
                innlegg.ForeldreID = (int)reader["bloggID"];
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
