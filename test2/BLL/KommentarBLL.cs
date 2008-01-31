using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.DAL;
using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.BLL
{
    public static class KommentarBLL
    {
        public static bool nyKommentar(int foreldreID, string tittel, string tekst)
        {
            return KommentarDAL.nyKommentar(foreldreID, tittel, tekst);
        }

        public static bool slettKommentar(int kommentarID)
        {
            return KommentarDAL.slettKommentar(kommentarID);
        }

        public static bool redigerKommentar(int kommentarID, string tekst)
        {
            return KommentarDAL.redigerKommentar(kommentarID, tekst);
        }

        public static List<Kommentar> getKommentarListe()
        {
            List<Kommentar> kommentarliste = KommentarDAL.getKommentarListe();

            return kommentarliste;
        }
    }
}
