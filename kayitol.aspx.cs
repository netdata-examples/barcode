using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kayitol : System.Web.UI.Page
{
    private string dogrulama;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["giris"] = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        KullaniciReference.WSSoapClient client = new KullaniciReference.WSSoapClient();
        DataSet veriCek = client.GetData("/*kendi api keyiniz*/", "dc_KullaniciAdi", TextBox1.Text);

        dogrulama = veriCek.Tables[0].Rows[0][0].ToString();
        if (dogrulama == "Hiç kayıt bulunamadı" && TextBox1.Text != null && TextBox2.Text != null && TextBox1.Text.ToString() != "" && TextBox2.Text.ToString() != "")
        {
            string Result = "";
            string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<InsertRecord xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <InsertList>
					<AccPoKeyValuePair>
					  <Key>dc_KullaniciAdi</Key>
					  <Value>[0]</Value>
					</AccPoKeyValuePair>
					<AccPoKeyValuePair>
					  <Key>dc_KullaniciSifre</Key>
					  <Value>[1]</Value>
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
            sw.Write(Content.Replace("[0]", TextBox1.Text).Replace("[1]", TextBox2.Text));
            sw.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream strResponse = resp.GetResponseStream();
            StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
            Result = sr.ReadToEnd();
            sr.Close();


            Label1.Text = Result;
        }
        else if (TextBox1.Text == null || TextBox2.Text == null || TextBox1.Text.ToString() == "" || TextBox2.Text.ToString() == "")
        {
            Label1.Text = "Kullanıcı adı veya Şifre boş olamaz";
        }
        else
        {
            Label1.Text = "Böyle bir Kullanıcı Mevcut";
        }
    }
}