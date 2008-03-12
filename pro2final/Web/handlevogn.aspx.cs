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

        oppdaterSumFelt();


    }


    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        oppdaterSumFelt();
    }

    protected void GridView1_UpdateCommand(object sender, EventArgs e)
    {
        oppdaterSumFelt();
    }


    protected void LinkButtonSlettHandlekurv_Click(object sender, EventArgs e)
    {
        this.Profile.HANDLEKURV.slettHandleliste();
        oppdaterSumFelt();
        this.GridView1.DataBind();
    }

    protected void oppdaterSumFelt()
    {
        this.lblSum.Text = Profile.HANDLEKURV.beregnTotalSum().ToString();
        Response.Cookies.Clear(); //Fjerne kaker, slik at systemet ikke husker gammelt rask.
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        oppdaterSumFelt();
        
    }

    

    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        //Response.Write(e.Keys[0].ToString());
        int varenummer = Int32.Parse(e.Keys[0].ToString());
        this.Profile.HANDLEKURV.slettVareFraHandlevogn(varenummer);
        oppdaterSumFelt();
        Profile.Save();
        
        
        //Response.Write(e.Values[1].ToString());
        
    }

    protected void LinkButtonKasse_Click(object sender, EventArgs e)
    {
        Response.Redirect("kasse.aspx");
        
    }
    protected void GridView1_RowDelete(object sender, GridViewDeleteEventArgs e)
    {
        //Response.Write(e.Keys[0].ToString());
        int varenummer = Int32.Parse(e.Keys[0].ToString());
        this.Profile.HANDLEKURV.slettVareFraHandlevogn(varenummer);
        oppdaterSumFelt();
        Profile.Save();
    }
}
