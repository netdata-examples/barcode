using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class giris : System.Web.UI.Page
{
    private string dogrulama;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetCaptchaText();
        }
            
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Captcha"].ToString() != TextBox3.Text.Trim())
        {
            Label3.Text = "Güvenlik Kodu Yanlış";
            SetCaptchaText();
        }
        else
        {
            KullaniciReference.WSSoapClient client = new KullaniciReference.WSSoapClient();
            DataSet veriCek = client.GetData("/*kendi api keyiniz*/", "dc_KullaniciAdi", TextBox1.Text);

            dogrulama = veriCek.Tables[0].Rows[0][0].ToString();
            if (dogrulama == "Hiç kayıt bulunamadı")
            {
                Label3.Text = "Hatalı Giriş";
                SetCaptchaText();
            }
            else
            {
                if (TextBox2.Text == veriCek.Tables[0].Rows[0]["dc_KullaniciSifre"].ToString())
                {
                    Session["giris"] = true;
                    Session["uyeid"] = Convert.ToInt32(veriCek.Tables[0].Rows[0]["ID"]);
                    Session["uyeadi"] = veriCek.Tables[0].Rows[0]["dc_KullaniciAdi"].ToString();
                    if (Request.Params["Redirect"] == null)
                    {
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        Response.Redirect(Request.Params["Redirect"].ToString());
                    }

                }
                else
                {
                    Label3.Text = "Hatalı Giriş";
                    SetCaptchaText();
                }
            }
        }
        
    }
    private void SetCaptchaText()
    {
        Random oRandom = new Random();
        int iNumber = oRandom.Next(100000, 999999);
        Session["Captcha"] = iNumber.ToString();
    }

}
