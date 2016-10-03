using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ara : System.Web.UI.Page
{
    private string dogrulamabarkod;
    private string dogrulamaisim;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["q"] == null)
        {
            hatalabel.Text = "Lütfen Barkod veya ürün adı giriniz.";
        }
        else if (Request.QueryString["q"] == "")
        {
            hatalabel.Text = "Lütfen Barkod veya ürün adı giriniz.";
        }
        else
        {

            string aramaistek = Request.QueryString["q"];
            if (aramaistek.Length >= 8)
            {
                DataSet aramabarkod = new DataSet();
                aramabarkod.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=ID,dc_BarkodNO,dc_ImgSrc,dc_UrunAdikisa,dc_UrunKodu,dc_UrunAdi,dc_UrunBilgisi&$contains=dc_BarkodNO%5Blike%5D" + aramaistek);
                dogrulamabarkod = aramabarkod.Tables[0].Rows[0][0].ToString();

                if (dogrulamabarkod == "Hiç kayıt bulunamadı")
                {
                    DataSet aramaisim = new DataSet();
                    aramaisim.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=ID,dc_BarkodNO,dc_ImgSrc,dc_UrunAdikisa,dc_UrunKodu,dc_UrunAdi,dc_UrunBilgisi&$contains=dc_UrunAdi%5Blike%5D" + aramaistek);
                    dogrulamaisim = aramaisim.Tables[0].Rows[0][0].ToString();
                    if (dogrulamaisim == "Hiç kayıt bulunamadı")
                    {
                        hatalabel.Text = "Aramanızla eşlesen bir kayıt bulunamadı.";
                    }
                    else
                    {
                        Repeater1.DataSource = aramaisim;
                        Repeater1.DataBind();
                    }
                }
                else
                {
                    Repeater1.DataSource = aramabarkod;
                    Repeater1.DataBind();
                }
            }
            else
            {
                DataSet aramaisim = new DataSet();
                aramaisim.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=ID,dc_BarkodNO,dc_UrunAdi,dc_ImgSrc,dc_UrunAdikisa,dc_UrunKodu,dc_UrunBilgisi&$contains=dc_UrunAdi%5Blike%5D" + aramaistek);
                dogrulamaisim = aramaisim.Tables[0].Rows[0][0].ToString();
                if (dogrulamaisim == "Hiç kayıt bulunamadı")
                {
                    hatalabel.Text = "Aramanızla eşlesen bir kayıt bulunamadı.";
                }
                else
                {
                    Repeater1.DataSource = aramaisim;
                    Repeater1.DataBind();
                }
            }


        } 
    }
}