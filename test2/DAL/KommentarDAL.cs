using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.DAL
{
    public static class KommentarDAL
    {
        public static void nyKommentar(Kommentar kommentar)
        {
            string query = @"
                                INSERT INTO kommentar (id, innleggID, tittel, dato, tekst, forfatter) VALUES (@id, @innleggID, @tittel, @dato, @tekst, @forfatter)
                            ";


            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@id", blogg.BlogID);
                    int result = myCommand.ExecuteNonQuery();

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
        }

        public static bool slettKommentar(int kommentarID)
        {
            return false;
        }

        public static bool redigerKommentar(int kommentarID, string tekst)
        {
            return false;
        }

        public static List<Kommentar> getKommentarListe()
        {
            List<Kommentar> kommentarliste = new List<Kommentar>();

            return kommentarliste;
        }
    }
}
