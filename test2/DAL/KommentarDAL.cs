using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.DAL
{
    public static class KommentarDAL
    {
        public static bool nyKommentar(int foreldreID, string tittel, string tekst)
        {
            return false;
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
