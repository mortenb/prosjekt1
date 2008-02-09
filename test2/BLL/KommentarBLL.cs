using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.DAL;
using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.BLL
{
    public static class KommentarBLL
    {
        public static void nyKommentar(Kommentar kommentar)
        {
            KommentarDAL.nyKommentar(kommentar);
        }

        public static void slettKommentar(int kommentarID)
        {
           KommentarDAL.slettKommentar(kommentarID);   
        }

        public static void redigerKommentar(int kommentarID, string tekst)
        {
            KommentarDAL.redigerKommentar(kommentarID, tekst);
        }
        public static Kommentar getKommentar(int kommentarID)
        {
            return DOTNETPROSJEKT1.DAL.KommentarDAL.getKommentar(kommentarID);
        }

        public static List<Kommentar> getKommentarListe(int innleggID)
        {
            List<Kommentar> kommentarliste = KommentarDAL.getKommentarListe(innleggID);
            
            return kommentarliste;
        }
    }
}
