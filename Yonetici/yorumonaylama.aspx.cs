using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_yorumonayevet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yoneticigiris"] == null) {
            Response.Redirect("~/Yonetici/giris.aspx");
        }

        if (Request.QueryString["YorumID"] == null)
        {
            Response.Redirect("~/Yonetici/onaybekleyenyorum.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                   VeriCek();
            }
            
        }

    }

    private void VeriCek()
    {
        KullaniciReference.WSSoapClient client = new KullaniciReference.WSSoapClient();
        DataSet yorum = client.GetData("/*kendi api keyiniz*/", "ID", Request.QueryString["YorumID"]);
        Label3.Text = yorum.Tables[0].Rows[0]["dc_YorumTarihi"].ToString();
        yorumtext.Value = yorum.Tables[0].Rows[0]["dc_Yorum"].ToString();
        DataSet urun = client.GetData("/*kendi api keyiniz*/", "ID", yorum.Tables[0].Rows[0]["dc_UrunID"].ToString());
       
        Label1.Text = urun.Tables[0].Rows[0]["dc_UrunAdi"].ToString();
        Label2.Text = yorum.Tables[0].Rows[0]["dc_KullaniciID"].ToString();
    }

    protected void DuzenleButon_Click(object sender, EventArgs e)
    {
        string Result = "";
        string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<CustomUpdate xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <UpdateFieldsList>
					<AccPoKeyValuePair>
					  <Key>dc_Yorum</Key>
					  <Value>[0]</Value>
					</AccPoKeyValuePair>
				  </UpdateFieldsList>
				<WhereConditionsList>
					<WhereList>
					  <Key>ID</Key>
					  <Operation>EQUAL</Operation>
					  <Value>[1]</Value>
					</WhereList>
				  </WhereConditionsList>
				</CustomUpdate>
			  </soap:Body>
			</soap:Envelope>";
        string url = "http://www.netdata.com/AccPo.asmx";
        string contentType = "text/xml; charset=utf-8";
        string method = "POST";
        string header = "SOAPAction: \"http://tempuri.org/CustomUpdate\"";

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = method;
        req.ContentType = contentType;
        req.Headers.Add(header);

        Stream strRequest = req.GetRequestStream();
        StreamWriter sw = new StreamWriter(strRequest);
        sw.Write(Content.Replace("[0]", yorumtext.Value).Replace("[1]", Request.QueryString["YorumID"]));
        sw.Close();

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream strResponse = resp.GetResponseStream();
        StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
        Result = sr.ReadToEnd();
        sr.Close();
        Label4.Text = Result;
        Response.Redirect(Request.RawUrl);
    }

    protected void OnaylaButon_Click(object sender, EventArgs e)
    {
        string Result = "";
        string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<CustomUpdate xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <UpdateFieldsList>
					<AccPoKeyValuePair>
					  <Key>dc_YorumDurumu</Key>
					  <Value>2</Value>
					</AccPoKeyValuePair>
				  </UpdateFieldsList>
				<WhereConditionsList>
					<WhereList>
					  <Key>ID</Key>
					  <Operation>EQUAL</Operation>
					  <Value>[0]</Value>
					</WhereList>
				  </WhereConditionsList>
				</CustomUpdate>
			  </soap:Body>
			</soap:Envelope>";
        string url = "http://www.netdata.com/AccPo.asmx";
        string contentType = "text/xml; charset=utf-8";
        string method = "POST";
        string header = "SOAPAction: \"http://tempuri.org/CustomUpdate\"";

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = method;
        req.ContentType = contentType;
        req.Headers.Add(header);

        Stream strRequest = req.GetRequestStream();
        StreamWriter sw = new StreamWriter(strRequest);
        sw.Write(Content.Replace("[0]", Request.QueryString["YorumID"]));
        sw.Close();

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream strResponse = resp.GetResponseStream();
        StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
        Result = sr.ReadToEnd();
        sr.Close();
        Label4.Text = Result;
        Response.Redirect("~/Yonetici/onaybekleyenyorum.aspx");

    }

    protected void ReddetButon_Click(object sender, EventArgs e)
    {
        string Result = "";
        string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<CustomUpdate xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <UpdateFieldsList>
					<AccPoKeyValuePair>
					  <Key>dc_YorumDurumu</Key>
					  <Value>3</Value>
					</AccPoKeyValuePair>
				  </UpdateFieldsList>
				<WhereConditionsList>
					<WhereList>
					  <Key>ID</Key>
					  <Operation>EQUAL</Operation>
					  <Value>[0]</Value>
					</WhereList>
				  </WhereConditionsList>
				</CustomUpdate>
			  </soap:Body>
			</soap:Envelope>";
        string url = "http://www.netdata.com/AccPo.asmx";
        string contentType = "text/xml; charset=utf-8";
        string method = "POST";
        string header = "SOAPAction: \"http://tempuri.org/CustomUpdate\"";

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = method;
        req.ContentType = contentType;
        req.Headers.Add(header);

        Stream strRequest = req.GetRequestStream();
        StreamWriter sw = new StreamWriter(strRequest);
        sw.Write(Content.Replace("[0]", Request.QueryString["YorumID"]));
        sw.Close();

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream strResponse = resp.GetResponseStream();
        StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
        Result = sr.ReadToEnd();
        sr.Close();
        Label4.Text = Result;
        Response.Redirect("~/Yonetici/onaybekleyenyorum.aspx");
    }
}