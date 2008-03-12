using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using myApp.Model;
using myApp.IBLL;



/// <summary>
/// Summary description for Handlevogn
/// </summary>
public class Handlevogn
{
        private List<Ordrelinje> _handleliste;
        private IProduktBLL prodBLL = BLLLoader.GetProduktBLL();

        //private List<minOrdre> lstMo;

        public Handlevogn() { _handleliste = new List<Ordrelinje>(); }

        

        public List<Ordrelinje> Handleliste
        {
            get { return _handleliste; }
            set { this._handleliste = value; }
        }

        public void slettHandleliste()
        {
            _handleliste.Clear();
            
        }

    private bool finnes(int produktID)
    {
        foreach (Ordrelinje ordre in this._handleliste)
        {
            if (ordre.ProduktID == produktID)
            {
                return true;
            }
        }
        return false;
    }

        public void leggTilVareIHandlevogn(Ordrelinje ol)
        {
            if (!finnes(ol.ProduktID)) //Sjekk om produktet ligger i handlevognen
            {
                _handleliste.Add(ol);
            }
        }

    public void endreAntall(int nyttAntall, int produktID)
    {
        if(finnes(produktID))
        {
            if (nyttAntall > 0)
            {
                foreach (Ordrelinje ordre in this._handleliste)
                {
                    if (ordre.ProduktID == produktID)
                    {
                        ordre.Antall = nyttAntall;
                    }
                }
            }
        }
    }

        public void slettVareFraHandlevogn(int produktID)
        {
            
            Ordrelinje ol = new Ordrelinje(); 
            foreach( Ordrelinje ordre in this.Handleliste )
            {
                
                if (ordre.ProduktID == produktID)
                {
                    ol = ordre;
                    break;
                   // _handleliste.RemoveAt(teller);
                   // _handleliste.Remove(ordre);
                   
                }
            }
            _handleliste.Remove(ol);
        }

    public int beregnTotalSum()
    {
        int total = 0;
        foreach (minOrdre ordre in lagOrdreliste())
        {
            total += ordre.Sum;
        }
        return total;
    }

        

    public int antallVarer()
    {
        
        return _handleliste.Count; //Må dele på 2 i tillegg, fordi ordrelinje har 2 elementer?? :S
    }

    public List<minOrdre> lagOrdreliste()
    {
        List<minOrdre> lstMo = new List<minOrdre>();
        foreach (Ordrelinje ol in this._handleliste)
        {
            //ol : produktID, antall
            //produkt: varenavn, pris.
            //generere sum, total
            minOrdre temp = new minOrdre();
            temp.ProduktID = ol.ProduktID;
            temp.Antall = ol.Antall;
            Produkt p = prodBLL.getProdukt(temp.ProduktID);
            temp.Varenavn = p.Tittel;
            temp.Pris = p.Pris;
            temp.Sum = temp.Pris * temp.Antall;
            lstMo.Add(temp);
        }
        return lstMo;
    }

    /*public List<minOrdre> visProdukter(List<Ordrelinje> lol)
    {
        List<Produkt> produkter = new List<Produkt>();
        foreach (Ordrelinje ol in _handleliste)
        {
           Produkt p = prodBLL.getProdukt(ol.ProduktID);
           if (p != null)
            {
                
               produkter.Add(p);
           }

        }
        List<minOrdre> mineOrdre = new List<minOrdre>();
        foreach (Produkt p in produkter)
        {
            minOrdre temp = new minOrdre();
            temp.Varenavn = p.Tittel;
            //temp.Antall = lol.
        }
        
    }
    */
    
     
    
} //end handlevogn

//Denne gjør at vi kan sette handlekurv deklarativt i web-siden
//Stjålet fra http://www.pluralsight.com/blogs/fritz/archive/2005/10/24/15874.aspx

public static class ProfileBinder
{
    public static List<minOrdre> lagOrdreliste()
    {
        return ((ProfileCommon)HttpContext.Current.Profile).HANDLEKURV.lagOrdreliste();
    }

    public static void slettVareFraHandlevogn(int produktID)
    {
        ((ProfileCommon)HttpContext.Current.Profile).HANDLEKURV.slettVareFraHandlevogn(produktID);
    }

    public static void endreAntall(int Antall, int produktID)
    {
        ((ProfileCommon)HttpContext.Current.Profile).HANDLEKURV.endreAntall(Antall, produktID);
    }

}

public class minOrdre
{
    //Denne klassen brukes til å koble informasjon fra flere objekter
    //For at GUI skal få pene visninger 
    //using myApp.Model;
    // using myApp.IBLL;


    private string varenavn;
    private int antall;
    private int sum;
    private int pris;
    private int produktID;

    //private IProduktBLL prodBLL = BLLLoader.GetProduktBLL();
    public minOrdre() { }

    public string Varenavn
    {
        get { return varenavn; }
        set { varenavn = value; }
    }

    public int Antall
    {
        get { return antall; }
        set { antall = value; }
    }

    public int ProduktID
    {
        get { return produktID; }
        set { produktID = value; }
    }

    public int Sum
    {
        get { return sum; }
        set { sum = value; }
    }

    public int Pris
    {
        get { return pris; }
        set { pris = value; }
    }

    /*public List<minOrdre> getOrdre( List<Ordrelinje> listOL )
    {
        List<minOrdre> mineOrdre = new List<minOrdre>();

        foreach (Ordrelinje ol in listOL)
        {
            minOrdre ordre = new minOrdre();
            

            //Produkt temp = prodBLL.getProdukt(ol.ProduktID);
            if (temp != null)
            {
                ordre.antall = ol.Antall;
                ordre.varenavn = temp.Tittel;
                ordre.sum = temp.Pris * ordre.antall;
                //ordre.prodBLL = null;
            }
            mineOrdre.Add(ordre);
        }
        return mineOrdre;


    }*/


}


