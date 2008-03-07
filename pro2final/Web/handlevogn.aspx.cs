using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using myApp.Model;
using myApp.IBLL;

public partial class handlevogn : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       
            IProduktBLL prodBLL = BLLLoader.GetProduktBLL();
            Ordrelinje ol = new Ordrelinje();
            ol.Antall = 2;
            ol.ProduktID = 1;

            Ordrelinje ol2 = new Ordrelinje();
            ol2.Antall = 3;
            ol2.ProduktID = 2;

            Profile.HANDLEKURV.leggTilVareIHandlevogn(ol);
            Profile.HANDLEKURV.leggTilVareIHandlevogn(ol2);
            int antallVarer = Profile.HANDLEKURV.antallVarer();
            Trace.Warn("Antall VARER I HANDLEKURV: " + antallVarer);
            
        

        //GridView1_slettLinje();
        
    }

    private void GridView1_slettLinje()
    {
        //this.GridView1.FindControl
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Profile.HANDLEKURV.slettHandleliste();

    }
    
}
