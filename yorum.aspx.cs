using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yorum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            if (RouteData.Values["YorumID"] == null)
            {
                Response.Redirect("~/default.aspx");
            }

            DataSet yorumbilgisi = new DataSet();
            yorumbilgisi.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=dc_UrunID,dc_KullaniciID,dc_Yorum,dc_YorumDurumu,dc_YorumTarihi,dc_Rating&$where=ID=" + RouteData.Values["YorumID"].ToString());
            if (yorumbilgisi.Tables[0].Rows[0][0].ToString() == "Hiç kayıt bulunamadı" || yorumbilgisi.Tables[0].Rows[0][0].ToString().Substring(0, 1) == "C")
            {
                yorumdiv.Visible = false;
                Label1.Text = "Böyle bir yorum bulunamadı. URL'nizi kontrol ediniz.";
            }
            else
            {
                yorumdiv.Visible = true;
                Session["YorumYapan"] = yorumbilgisi.Tables[0].Rows[0]["dc_KullaniciID"].ToString();
                Session["YorumTarihi"] = yorumbilgisi.Tables[0].Rows[0]["dc_YorumTarihi"].ToString();
                Session["YorumRating"] = yorumbilgisi.Tables[0].Rows[0]["dc_Rating"].ToString();
                int uID = Convert.ToInt32(yorumbilgisi.Tables[0].Rows[0]["dc_UrunID"]);
                if (Convert.ToInt32(yorumbilgisi.Tables[0].Rows[0]["dc_YorumDurumu"]) != 2)
                {
                    Session["Yorum"] = "Bu yorum onaylanmadığı için görünüm engellenmiştir. Bir sorun olduğunu düşünüyorsanız iletişime geçiniz.";
                }
                else
                {
                    Session["Yorum"] = yorumbilgisi.Tables[0].Rows[0]["dc_Yorum"].ToString();
                }

                DataSet urunbilgisi = new DataSet();
                urunbilgisi.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=dc_UrunAdi,dc_ImgSrc,dc_UrunAdikisa,dc_UrunKodu&$where=ID=" + uID);
                Session["ImgSrc"] = urunbilgisi.Tables[0].Rows[0]["dc_ImgSrc"].ToString();
                Session["UrunAdi"] = urunbilgisi.Tables[0].Rows[0]["dc_UrunAdi"].ToString();
                Session["UrunAdikisa"] = urunbilgisi.Tables[0].Rows[0]["dc_UrunAdikisa"].ToString();
                Session["UrunKodu"] = urunbilgisi.Tables[0].Rows[0]["dc_UrunKodu"].ToString();
            }

        }
    }
}