using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_giris : System.Web.UI.Page
{
    private string dogrulama;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        KullaniciReference.WSSoapClient client = new KullaniciReference.WSSoapClient();
        DataSet veriCek = client.GetData("/*kendi api keyiniz*/", "dc_YoneticiAdi", TextBox1.Text);

        dogrulama = veriCek.Tables[0].Rows[0][0].ToString();
        if (dogrulama == "Hiç kayıt bulunamadı")
        {
            Label3.Text = "Hatalı Giriş";
        }
        else
        {
            if (TextBox2.Text == veriCek.Tables[0].Rows[0]["dc_YoneticiSifre"].ToString())
            {
                Session["yoneticigiris"] = true;
                Session["yoneticiid"] = Convert.ToInt32(veriCek.Tables[0].Rows[0]["ID"]);
                Session["yoneticiadi"] = veriCek.Tables[0].Rows[0]["dc_YoneticiAdi"].ToString();
                Response.Redirect("~/Yonetici/Default.aspx");
            }
            else
            {
                Label3.Text = "Hatalı Giriş";
            }
        }
    }
}