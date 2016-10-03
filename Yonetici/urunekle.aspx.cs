using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_urunekle : System.Web.UI.Page
{
    private int basarilikayit = 0;
    private int basarisizkayit = 0;
    private int barkodsuzkayit = 0;
    private int adsizkayit = 0;
    private int bilgisizkayit = 0;
    private int urunkodsuzkayit = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yoneticigiris"] == null)
        {
            Response.Redirect("~/Yonetici/giris.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Result = "";
        string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<InsertRecord xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <InsertList>
					<AccPoKeyValuePair>
					  <Key>dc_BarkodNO</Key>
					  <Value>[0]</Value>
					</AccPoKeyValuePair>
					<AccPoKeyValuePair>
					  <Key>dc_UrunAdi</Key>
					  <Value>[1]</Value>
					</AccPoKeyValuePair>
				  <AccPoKeyValuePair>
					  <Key>dc_UrunBilgisi</Key>
					  <Value>[2]</Value>
					</AccPoKeyValuePair><AccPoKeyValuePair>
					  <Key>dc_ImgSrc</Key>
					  <Value>http://localhost:28972/img/Resim_yok.gif</Value>
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
        sw.Write(Content.Replace("[0]", TextBox1.Text).Replace("[1]", TextBox2.Text).Replace("[2]",TextBox3.Text));
        sw.Close();

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream strResponse = resp.GetResponseStream();
        StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
        Result = sr.ReadToEnd();
        sr.Close();


        Response.Write(Result);
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            HttpPostedFile postedfile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedfile.FileName);
            string extesion = Path.GetExtension(filename);
            int filesize = postedfile.ContentLength;

            if (extesion.ToLower() == ".xls" || extesion.ToLower() == ".xlsx")
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("..") + "//Temp//" + str);
                string path = "~/Temp/" + str.ToString();

                OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Server.MapPath(path) + ";Extended Properties=\"Excel 12.0;HDR=YES;\"");
                if (Server.MapPath(path) != "")
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("Select BarkodNO,UrunAdi,UrunBilgisi,ImgSrc,UrunKodu from [Urun$]", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                       excelUrunEkle(row["BarkodNo"].ToString(), row["UrunAdi"].ToString(), row["UrunBilgisi"].ToString(),row["ImgSrc"].ToString(),row["UrunKodu"].ToString());
                    }
                    excellabel.Text = basarilikayit + " Başarılı " + basarisizkayit + " Başarısız Kayıt."+"<br />"+ "Başarısızlardan "+ "<br />" + adsizkayit + " tanesinin adi" + "<br />" +  barkodsuzkayit + " tanesinin barkodu" + "<br />" + urunkodsuzkayit + " tanesinin ürün kodu" + "<br />" + bilgisizkayit + " tanesinin ürün bilgisi bulunmamaktadır. Lütfen dosyanızı kotrol ediniz.";
                }

                
                System.IO.File.Delete(Server.MapPath(path));
            }
            else
            {
                excellabel.Text = "Excel Dosyası Seçmediniz. Desteklenen uzantılar .xls ve .xlsx'dir";
            }
        }
        else
        {
            excellabel.Text = "Dosya Seçmediniz.";
        }
    }

    private void excelUrunEkle(string barkod,string ad,string bilgi,string imgsrc, string urunkodu)
    {
        string adkisa = ad;
        adkisa = adkisaltma(adkisa);

        if (imgsrc == null || imgsrc == "")
        {
            imgsrc = "http:///*kendi sunucu adresiniz*//img/Resim_yok.gif";
        }
        if (barkod != null && barkod != "" && ad != null && ad != "" && bilgi != null && bilgi != "" && urunkodu != null && urunkodu != "")
        {
            string Result = "";
            string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<InsertRecord xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <InsertList>
					<AccPoKeyValuePair>
					  <Key>dc_BarkodNO</Key>
					  <Value>[0]</Value>
					</AccPoKeyValuePair>
					<AccPoKeyValuePair>
					  <Key>dc_UrunAdi</Key>
					  <Value>[1]</Value>
					</AccPoKeyValuePair>
				  <AccPoKeyValuePair>
					  <Key>dc_UrunBilgisi</Key>
					  <Value>[2]</Value>
					</AccPoKeyValuePair>
                    <AccPoKeyValuePair>
					  <Key>dc_ImgSrc</Key>
					  <Value>[3]</Value>
					</AccPoKeyValuePair>
                    <AccPoKeyValuePair>
					  <Key>dc_UrunAdikisa</Key>
					  <Value>[4]</Value>
					</AccPoKeyValuePair>
                    <AccPoKeyValuePair>
					  <Key>dc_UrunKodu</Key>
					  <Value>[5]</Value>
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
            sw.Write(Content.Replace("[0]", barkod).Replace("[1]", ad).Replace("[2]", bilgi).Replace("[3]",imgsrc).Replace("[4]",adkisa).Replace("[5]",urunkodu));
            sw.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream strResponse = resp.GetResponseStream();
            StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
            Result = sr.ReadToEnd();
            sr.Close();

            basarilikayit += 1;

        }
        else
        {
            basarisizkayit += 1;
            if (barkod == null || barkod == "")
            {
                barkodsuzkayit += 1;
            }
            else if (ad == null || ad == "")
            {
                adsizkayit += 1;
            }
            else if (bilgi == null || bilgi == "")
            {
                bilgisizkayit += 1;
            }
            else if(urunkodu == null || urunkodu == "")
            {
                urunkodsuzkayit += 1;
            }
        }
    }

    private string adkisaltma(string adkisa)
    {
        adkisa = adkisa.ToLower();
        adkisa = adkisa.Replace(" ", "-");
        adkisa = adkisa.Replace("ü", "u");
        adkisa = adkisa.Replace("ö", "o");
        adkisa = adkisa.Replace("ğ", "g");
        adkisa = adkisa.Replace("ş", "s");
        adkisa = adkisa.Replace("ç", "c");
        adkisa = adkisa.Replace("ı", "i");

        return adkisa;
    }
}