using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using Prosjekt2.Modell;
using Prosjekt2.IBLL;

    public partial class nyheter : System.Web.UI.Page
    {
        //private INyhetBLL nyhetBLL = BLLLoader.GetNyhetBLL();
        private IAnmeldelseBLL anmeldelseBLL = BLLLoader.GetAnmeldeseBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //DataList1.DataSource = nyhetBLL.getNyheter();
               // DataList1.DataBind();

            }
        }
    }

