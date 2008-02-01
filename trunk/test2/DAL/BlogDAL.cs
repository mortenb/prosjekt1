using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using DOTNETPROSJEKT1.Model;
using System.Configuration;

namespace DOTNETPROSJEKT1.DAL
{
    public static class BlogDAL
    {
        //Metode for å hente alle blogger
        //Returnerer en liste List av Blog
        public static List<Blog> getBlogger()
        {
           //Gjør klar SQL-query
            string query = @"
                                SELECT *
                                FROM blogg
                            ";

            //Instansiere 'blogger' som skal bli retunert til BLL
            List<Blog> blogger = new List<Blog>();

            //Setter opp en SQLConnection, bruker "ConnectionString" som connectionstring
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                //Åpner connection til DB
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection)) //Her gjør den klar sqlkommando, men eksekverer den ikke
                {
                    //Eksekverer kommandoen og legger det i en SQLDataReader som vi leser fra
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            //Leser rad for rad, og slenger verdiene til BloggFraSqlReader
                            blogger.Add(BloggFraSqlReader(ref reader));
                        }
                    }
                    //Som Nils har påpekt, skal vi her ikke ha noen catch-blokk, for det er i øvre lag exceptions skal håndteres
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); //Ferdig med readeren, lukker
                        }
                    }
                }
            }

            return blogger;
        }

        public static Blog getBloggAvEier(string eier)
        {
            //Metode for å hente blog ved hjelp av eier
            //Oppretter Model.Blog som skal returneres
            Blog blogg = new Blog();

            //Gjør klar sql-streng
            string query = @"
                                SELECT *
                                FROM blogg
                                WHERE blogg.eier = @eier
                            ";

            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdi i sql-strengen
                    myCommand.Parameters.AddWithValue("@eier", eier);
                    //Eksekverer sql-streng og legger dette i en reader
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            //Legger raden med verdier i bloggen som skal returneres
                            blogg = BloggFraSqlReader(ref reader);
                        }
                    }
                    //Som Nils har påpekt, skal vi her ikke ha noen catch-blokk, for det er i øvre lag exceptions skal håndteres
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); //Lukker connection
                        }
                    }
                }
            }

            return blogg;
        } //Kommentert

        public static Blog getBlog(int id)
        {
            //Oppretter Blog i Model som vi skal returnere til øvre lag
            Blog blogg = new Blog();

            //Gjør klar sql-streng
            string query = @"
                                SELECT *
                                FROM blogg
                                WHERE blogg.id = @id
                            ";
            //Gjør klar sqlconnection med connectionstring
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                //Åpner sql-sconnection
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til bloggidverdi i sql-streng
                    myCommand.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = myCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read()) //Leser rad for rad
                        {
                            //Sender readeren til BloggFraSqlReader som lagrer verdiene i et blogg objekt
                            blogg = BloggFraSqlReader(ref reader);
                        }
                    }
                    //Som Nils har påpekt, skal vi her ikke ha noen catch-blokk, for det er i øvre lag exceptions skal håndteres
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close(); //Lukk connection
                        }
                    }
                }
            }

            return blogg;
        } //Kommentert

        public static void nyBlog(Blog blogg)
        {
            //Gjør klar sql-query
            string query = @"
                                INSERT INTO blogg (id, eier, tittel) VALUES (@id, @eier, @tittel)
                            ";

            //Gjør klar sqlconnection med connectionstring
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                //Åpner sqlconnection
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    //Legger til verdier i sql-strengen
                    myCommand.Parameters.AddWithValue("@id", blogg.BlogID);
                    myCommand.Parameters.AddWithValue("@eier", blogg.Eier);
                    myCommand.Parameters.AddWithValue("@tittel", blogg.Tittel);
                    int result = myCommand.ExecuteNonQuery();
                    //ExecuteNonQuery returnerer antall rader som er ordnet på
                    //I dette tilfellet skal dette tallet være en, og vi setter
                    //da bloggID'en
                    if (result == 1)
                    {
                        myCommand.CommandText = "SELECT @@IDENTITY";
                        blogg.BlogID = Convert.ToInt32(myCommand.ExecuteScalar());
                    }
                    else
                    {
                        throw new ApplicationException("Tryna når jeg prøvde å lage ny bruker.. Beklager");
                    }
                }
            }
        } //Kommenter

        private static Blog BloggFraSqlReader(ref SqlDataReader reader) // Kommentert
        {
            Blog blog = new Blog();

            if (reader["id"] != DBNull.Value)
            {
                blog.BlogID = (int)reader["id"];
            }

            if (reader["eier"] != DBNull.Value)
            {
                blog.Eier = (string)reader["eier"];
            }

            if (reader["tittel"] != DBNull.Value)
            {
                blog.Tittel = (string)reader["tittel"];
            }
            return blog;
        }



    }
}
