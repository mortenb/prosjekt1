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
        public static void nyKommentar(Kommentar kommentar)
        {
            //Metode for å legge til en kommentar
            //Gjør klar sql-streng
            string query = @"
                                INSERT INTO kommentar (innleggID, nivaa, tittel, dato, tekst, forfatter) 
                                VALUES ( @innleggID, @nivaa, @tittel, @dato, @tekst, @forfatter)
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-strengen
                 //   myCommand.Parameters.AddWithValue("@id", kommentar.ForeldreID);
                    myCommand.Parameters.AddWithValue("@innleggID", kommentar.InnleggID);
                    myCommand.Parameters.AddWithValue("@nivaa", kommentar.Nivaa);
                    myCommand.Parameters.AddWithValue("@tittel", kommentar.Tittel);
                    myCommand.Parameters.AddWithValue("@dato", kommentar.Dato);
                    myCommand.Parameters.AddWithValue("@tekst", kommentar.Tekst);
                    myCommand.Parameters.AddWithValue("@forfatter", kommentar.Forfatter);
                    //Eksekverer kommandoen og legger antall rader forandret i result
                    int result = myCommand.ExecuteNonQuery();

                    if (result != 1)
                    {
                        //Hvis result er 1 så har alt gått bra
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bommentar.. Beklager");
                    }
                }
            }
        } 

        public static void slettKommentar(int kommentarID)
        {
            //Metode for å slette kommentar
            //Gjør klar sql-streng
            string query = @"
                                DELETE
                                FROM kommentar
                                WHERE kommentar.id = @kommentarID
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger verdi i sql-strengen
                    myCommand.Parameters.AddWithValue("@kommentarID", kommentarID);
                    //Eksekverer sql-streng og legger antall rader forandret i result
                    int result = myCommand.ExecuteNonQuery();
                    if (result != 1)
                    {
                        //Hvis result er 1 så har alt gått bra
                        throw new ApplicationException("Kunne ikke slette kommentar");
                    }


                }
            }
        }

        public static void redigerKommentar(int kommentarID, string tekst)
        {
            //Metode får endre tekst på kommentar
            //Gjør klar sql-streng
            string query = @"
                                UPDATE kommentar 
                                SET tekst = @tekst
                                WHERE id = @kommentarID
                            ";

            //Lager en bool som returnerer om metoden er vellykket eller ikke

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-strengen
                    myCommand.Parameters.AddWithValue("@id", kommentarID);
                    myCommand.Parameters.AddWithValue("@tekst", tekst);
                    //Eksekverer kommandoen og legger antall rader forandret i result
                    int result = myCommand.ExecuteNonQuery();

                    if (result != 1)
                    {
                        //Hvis result er 1 så har alt gått bra
                        throw new ApplicationException("Kunne ikke redigere kommentar");
                    }
                }
            }
        } 

        public static List<Kommentar> getKommentarListe(int innleggID)
        {
            //Metode for å returnere hele kommentarlisten til ett innlegg som et List-objekt
            //Gjør klar sql-streng
            string query = @"
                                SELECT kommentar.*
                                FROM kommentar where kommentar.innleggID = @innleggID order by id, nivaa
                            ";
            

            //Oppretter liste som skal returneres
            List<Kommentar> kommentarer = new List<Kommentar>();

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdi i sql-streng
                    myCommand.Parameters.AddWithValue("@innleggID", innleggID);
                    //Eksekverer sql-streng og legger radene i en reader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            //Leser rad for rad og legger kommentarobjekter i kommentarlista ved hjelpemetode
                            kommentarer.Add(KommentarFraSqlReader(ref reader));
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
            
            return kommentarer;
        } //Kommentert



        

    private static Kommentar KommentarFraSqlReader(ref SqlDataReader reader) // Kommentert
        {
            //Hjelpemetode for å gjenbruke kode
            Kommentar kommentar = new Kommentar();

            if (reader["id"] != DBNull.Value)
            {
                kommentar.ID = (int)reader["id"];
            }

            if (reader["innleggID"] != DBNull.Value)
            {
                kommentar.InnleggID = (int)reader["innleggID"];
            }
            if (reader["nivaa"] != DBNull.Value)
            {
                kommentar.Nivaa = (int)reader["nivaa"];
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
