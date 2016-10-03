using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetici_resimekle : System.Web.UI.Page
{
    private string dogrulama;

    protected void Page_Load(object sender, EventArgs e)
    {

        
        
    }

    

    protected void Button2_Click(object sender, EventArgs e)
    {
        Button3.Visible = true;
        Button2.Visible = false;
        TextBox2.Visible = false;
        FileUpload1.Visible = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Button2.Visible = true;
        Button3.Visible = false;
        TextBox2.Visible = true;
        FileUpload1.Visible = false;
        FileUpload1 = null;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            HttpPostedFile postedfile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedfile.FileName);
            string extesion = Path.GetExtension(filename);
            int filesize = postedfile.ContentLength;

            if (extesion.ToLower() == ".jpg" || extesion.ToLower() == ".gif" || extesion.ToLower() == ".png" || extesion.ToLower() == ".bmp")
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("..") + "//img//" + str);
                string path = "http:///*kendi sunucu adresiniz*//img/" + str.ToString();

                resimEkletoNetdata(path);
            }
            else
            {
                Label1.Text = "Resim dosyası seçmediniz. Lütfen .jpg .png .gif uzantılı dosya seçiniz.";
            }
        }
        else
        {
            resimEkletoNetdata(TextBox2.Text);
        }
    }

    private void resimEkletoNetdata(string path)
    {
        string Result = "";
        string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<CustomUpdate xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <UpdateFieldsList>
					<AccPoKeyValuePair>
					  <Key>dc_ImgSrc</Key>
					  <Value>[1]</Value>
					</AccPoKeyValuePair>
				  </UpdateFieldsList>
				<WhereConditionsList>
					<WhereList>
					  <Key>dc_BarkodNO</Key>
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
        sw.Write(Content.Replace("[0]", TextBox1.Text).Replace("[1]", path));
        sw.Close();

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream strResponse = resp.GetResponseStream();
        StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
        Result = sr.ReadToEnd();
        sr.Close();
        Response.Redirect("~/Yonetici/default.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Label2.Text = "";
        KullaniciReference.WSSoapClient client = new KullaniciReference.WSSoapClient();
        DataSet veriCek = client.GetData("/*kendi api keyiniz*/", "dc_BarkodNO",  TextBox1.Text);

        dogrulama = veriCek.Tables[0].Rows[0][0].ToString();
        if (dogrulama == "Hiç kayıt bulunamadı" )
        {
            Label2.Text = "Belirtilen barkod numarasına kayıtlı ürün bulunamadı.";
        }
        else
        {
            Label2.Text = "Ürün Dogrulandı. " + veriCek.Tables[0].Rows[0][2].ToString();
            Button1.Visible = true;
        }
    }

    
}