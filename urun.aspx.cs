using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class urun : System.Web.UI.Page
{
    private string dogrulama;
    private string dogrulama2;
    private int uID;
    private string dogrulama3;
    private string barkodurl;
    private string gelenbarkod;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (RouteData.Values["UrunKodu"] == null) {
            Response.Redirect("~/default.aspx");
        }
        DataSet barkodtest = new DataSet();
        barkodtest.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=dc_UrunAdi,ID,dc_UrunAdikisa&$where=dc_UrunKodu=" + RouteData.Values["UrunKodu"].ToString());
        if (barkodtest.Tables[0].Rows[0][0].ToString() == "Hiç kayıt bulunamadı")
        {
            Response.Redirect("~/default.aspx");
        }
        else {
            gelenbarkod = barkodtest.Tables[0].Rows[0]["dc_UrunAdikisa"].ToString();
        }
        
        
        if (RouteData.Values["UrunAdikisa"] == null)
        {
            barkodurl = "null";
        }
        else
        {
            barkodurl= RouteData.Values["UrunAdikisa"].ToString();
            Session["Link1"] = gelenbarkod;
            Session["Link2"] = RouteData.Values["UrunKodu"].ToString();
        }

        if (barkodurl != gelenbarkod)
        {
            Response.Redirect("~/"+gelenbarkod+"-yorum-"+RouteData.Values["UrunKodu"].ToString());
        }

        

        if (Convert.ToBoolean(Session["giris"]) == true)
        { Panel2.Visible = true; }
        else {
            Panel2.Visible = false;
            Label2.Text = "Yorum Yapmak için Giriş Yapmalısınız.";
        }
        uID = Convert.ToInt32(barkodtest.Tables[0].Rows[0]["ID"]);
        KullaniciReference.WSSoapClient client = new KullaniciReference.WSSoapClient();
        DataSet veriCek = client.GetData("/*kendi api keyiniz*/", "ID", uID.ToString());
        
        dogrulama = veriCek.Tables[0].Rows[0][0].ToString();
        if (dogrulama == "Hiç kayıt bulunamadı")
        {
            Response.Write("Ürün Bulanamadı.");
        }
        else
        {
            
            Session["ImgSrc"] = veriCek.Tables[0].Rows[0]["dc_ImgSrc"];
            Session["UrunAdi"] = veriCek.Tables[0].Rows[0]["dc_UrunAdi"];
            Page.Title = Session["UrunAdi"].ToString()+" Hakkında Yapılan Yorumlar";
            Session["UrunBilgisi"] = veriCek.Tables[0].Rows[0]["dc_UrunBilgisi"].ToString();
            KullaniciReference.WSSoapClient client2 = new KullaniciReference.WSSoapClient();
            DataSet veriCek2 = client2.GetData("/*kendi api keyiniz*/", "dc_UrunID", uID.ToString());
            dogrulama2 = veriCek2.Tables[0].Rows[0][0].ToString();
            if (dogrulama2 == "Hiç kayıt bulunamadı")
            {
                Label1.Text = "Bu ürün hakkında daha önce yorum yapılmamış.";
                DropDownList2.Visible = false;
            }
            else
            {
                DataSet yorumlar = new DataSet();
                yorumlar.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=ID,dc_UrunID,dc_KullaniciID,dc_Yorum,dc_YorumDurumu,dc_YorumTarihi,dc_Rating&$where=dc_UrunID=" + uID+ "%5Band%5Ddc_YorumDurumu=2&$orderby=dc_YorumTarihi[desc]");
                dogrulama3 = yorumlar.Tables[0].Rows[0][0].ToString();
                if (dogrulama3 == "Hiç kayıt bulunamadı")
                {
                    DropDownList2.Visible = false;
                    Label1.Text = "Bu ürün hakkında daha önce yorum yapılmamış.";
                }
                else
                {
                    int urunpuani = 0;
                    foreach (DataRow yorumsatir in yorumlar.Tables[0].Rows)
                    {
                        urunpuani = urunpuani + Convert.ToInt32(yorumsatir["dc_Rating"]);
                    }
                    Session["urunpuani"] = (urunpuani / yorumlar.Tables[0].Rows.Count).ToString();
                    Repeater1.DataSource = yorumlar;
                    Repeater1.DataBind();
                    DropDownList2.Visible = true;
                }
            }

        }
        
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Result = "";
        string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<InsertRecord xmlns=""http://tempuri.org/"">
				  <APIKey>803f82a2</APIKey>
				  <InsertList>
					<AccPoKeyValuePair>
					  <Key>dc_UrunID</Key>
					  <Value>[0]</Value>
					</AccPoKeyValuePair>
					<AccPoKeyValuePair>
					  <Key>dc_KullaniciID</Key>
					  <Value>[1]</Value>
					</AccPoKeyValuePair>
                    <AccPoKeyValuePair>
					  <Key>dc_Yorum</Key>
					  <Value>[2]</Value>
					</AccPoKeyValuePair>
                    <AccPoKeyValuePair>
					  <Key>dc_YorumDurumu</Key>
					  <Value>1</Value>
					</AccPoKeyValuePair>
                    <AccPoKeyValuePair>
					  <Key>dc_YorumTarihi</Key>
					  <Value>[3]</Value>
					</AccPoKeyValuePair>
                    <AccPoKeyValuePair>
					  <Key>dc_Rating</Key>
					  <Value>[4]</Value>
					</AccPoKeyValuePair>
				  </InsertList>
				</InsertRecord>
			  </soap:Body>
			</soap:Envelope>";
        string url = "http://www.netdata.com/AccPo.asmx";
        string contentType = "text/xml; charset=utf-8";
        string method = "POST";
        string header = "SOAPAction: \"http://tempuri.org/InsertRecord\"";

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = method;

        req.ContentType = contentType;
        req.Headers.Add(header);

        Stream strRequest = req.GetRequestStream();
        StreamWriter sw = new StreamWriter(strRequest);
        sw.Write(Content.Replace("[0]", uID.ToString()).Replace("[1]", Session["uyeadi"].ToString()).Replace("[2]", TextBox1.Text).Replace("[3]",DateTime.Now.ToString()).Replace("[4]", DropDownList1.SelectedItem.Value));
        sw.Close();
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream strResponse = resp.GetResponseStream();
        StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
        Result = sr.ReadToEnd();
        sr.Close();


        Label3.Text ="Yorum Onay Sürecine "+ Result;
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet yorumlaryeni = new DataSet();
        if (DropDownList2.SelectedValue == "1")
        {
            yorumlaryeni.ReadXml("https://www.netdata.com/XML/4570ebae?$select=ID,dc_UrunID,dc_KullaniciID,dc_Yorum,dc_YorumDurumu,dc_YorumTarihi,dc_Rating&$where=dc_UrunID=" + uID + "%5Band%5Ddc_YorumDurumu=2&$orderby=dc_YorumTarihi[desc]");
            Repeater1.DataSource = yorumlaryeni;
            Repeater1.DataBind();
        }
        else if (DropDownList2.SelectedValue == "2")
        {
            yorumlaryeni.ReadXml("https://www.netdata.com/XML/4570ebae?$select=ID,dc_UrunID,dc_KullaniciID,dc_Yorum,dc_YorumDurumu,dc_YorumTarihi,dc_Rating&$where=dc_UrunID=" + uID + "%5Band%5Ddc_YorumDurumu=2&$orderby=dc_YorumTarihi[asc]");
            Repeater1.DataSource = yorumlaryeni;
            Repeater1.DataBind();
        }
        else if (DropDownList2.SelectedValue == "3")
        {
            yorumlaryeni.ReadXml("https://www.netdata.com/XML/4570ebae?$select=ID,dc_UrunID,dc_KullaniciID,dc_Yorum,dc_YorumDurumu,dc_YorumTarihi,dc_Rating&$where=dc_UrunID=" + uID + "%5Band%5Ddc_YorumDurumu=2&$orderby=dc_Rating[asc]");
            Repeater1.DataSource = yorumlaryeni;
            Repeater1.DataBind();
        }
        else if (DropDownList2.SelectedValue == "4")
        {
            yorumlaryeni.ReadXml("https://www.netdata.com/XML/4570ebae?$select=ID,dc_UrunID,dc_KullaniciID,dc_Yorum,dc_YorumDurumu,dc_YorumTarihi,dc_Rating&$where=dc_UrunID=" + uID + "%5Band%5Ddc_YorumDurumu=2&$orderby=dc_Rating[desc]");
            Repeater1.DataSource = yorumlaryeni;
            Repeater1.DataBind();
        }
        

    }

}