using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Convert.ToBoolean(Session["giris"]) == false)
        {
            HyperLink1.Visible = true;
            HyperLink2.Visible = true;
            HyperLink3.Visible = false;
            HyperLink4.Visible = false;
            HyperLink1.NavigateUrl = "~/giris.aspx?Redirect=" + Request.RawUrl.ToString();
        }
        else
        {
            HyperLink1.Visible = false;
            HyperLink2.Visible = false;
            HyperLink3.Visible = true;
            HyperLink4.Visible = true;
            HyperLink4.NavigateUrl = "~/cikis.aspx?Redirect=" + Request.RawUrl.ToString();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string aramaquery = aramatext.Value;
        Response.Redirect("~/ara.aspx?q="+aramaquery);
    }
}
