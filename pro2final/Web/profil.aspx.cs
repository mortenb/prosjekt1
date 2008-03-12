using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using myApp.Model;

public partial class profil : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Profile.IsAnonymous)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!Profile.IsAnonymous)
        {
            Page.Theme = Profile.Theme;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Profile.UserName);
        Profile.HANDLEKURV = new Handlevogn();
        List<Ordrelinje> ordre = Profile.HANDLEKURV.Handleliste;
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
     
    }

    protected void Set_Theme(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.Text == "Matrix")
        {
            Profile.Theme = "Matrix";
        }
        else if (btn.Text == "Green")
        {
            Profile.Theme = "Green";
        }
        else if (btn.Text == "Nice")
        {
            Profile.Theme = "Nice";
        }
        Response.Redirect("~/profil.aspx");
    }

    private string _brukernavn;

    public string Brukernavn
    {
        get { return _brukernavn; }
        set 
        { 
            this._brukernavn = value;
            lblBrukernavn.Text = value;
        }
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
}
