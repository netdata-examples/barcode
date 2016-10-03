using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cikis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["giris"] = false;
        if (Request.Params["Redirect"] == null)
        {
            Response.Redirect("default.aspx");
        }
        else
        {
            Response.Redirect(Request.Params["Redirect"].ToString());
        }
        
    }
}