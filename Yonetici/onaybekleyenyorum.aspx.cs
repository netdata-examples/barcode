using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_yorumonay : System.Web.UI.Page
{
    private string dogrulama;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["yoneticigiris"] == null)
        {
            Response.Redirect("~/Yonetici/giris.aspx");
        }

        KullaniciReference.WSSoapClient client = new KullaniciReference.WSSoapClient();
        DataSet yorum = client.GetData("/*kendi api keyiniz*/", "dc_YorumDurumu", "1");

        dogrulama = yorum.Tables[0].Rows[0][0].ToString();
        if (dogrulama == "Hiç kayıt bulunamadı")
        {
            Label1.Text = "Onay Bekleyen Yorum Yok. ";
        }
        else
        {
            Repeater1.DataSource = yorum;
            Repeater1.DataBind();
        }
    }

    
}