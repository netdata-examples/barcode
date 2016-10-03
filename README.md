# barcode
barcode ürün yorumlaması yapılmasına olanak sağlayan bir web uygulamasıdır. Kullanıcılara hem isim hem de barkod ile arama imkanı sağlamaktadır. Ürünler hakkında yorumların gösterimi yapılarak diğer kişiler için bilgi kaynağı oluşturmayı amaçlamaktadır.

# Netdata
Netdata JSON, XML, WS, IFRAME kullanarak başka uygulamalar aracılığıyla veri alışverişi yapabilen bir bilgi merkezidir. Kullanıcılar isterlerse XML kullanarak veri çekebilmekte, veri güncelleyebilmekte ve veri sitebilmektedir. WS kullanılarak belirli veriyi barındıran satır getirilebilmektedir. Netdata üzerinden oluşturulan URL Sihirbazı ile çok az bilgi sahibi bile olunsa sql kullanıyormuş gibi sorgular oluşturulabilmektedir. AccPo ile erişim noktası oluşturularak farklı uygulamalardan veri işlemesi yapılabilmektedir. 
# WS ile belirli bilgiyi barındıran satırı getirme.
```
/*Eklendiğiniz web servisi*/.WSSoapClient client = new /*Eklendiğiniz web servisi*/.WSSoapClient();
DataSet veri = client.GetData("/*kendi api keyiniz*/", /*bilgi sütunu*/, /*bilgi değeri*/);
```
# AccPo ile veri ekleme (insert)
```
string Result = "";
        string Content = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
			 <soap:Body>
				<InsertRecord xmlns=""http://tempuri.org/"">
				  <APIKey>/*kendi api keyiniz*/</APIKey>
				  <InsertList>
					<AccPoKeyValuePair>
					  <Key>/*Ekleme yapılacak sutün adı*/</Key>
					  <Value>[0]</Value>
					</AccPoKeyValuePair>
					<AccPoKeyValuePair>
					  <Key>/*Ekleme yapılacak sutün adı*/</Key>
					  <Value>[1]</Value>
					</AccPoKeyValuePair>
				  <AccPoKeyValuePair>
					  <Key>/*Ekleme yapılacak sutün adı*/</Key>
					  <Value>[2]</Value>
					</AccPoKeyValuePair><AccPoKeyValuePair>
					  <Key>/*Ekleme yapılacak sutün adı*/</Key>
					  <Value>/*Sutüna insert edilecek değer*/</Value>
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
        sw.Write(Content.Replace("[0]", /*Sutüna insert edilecek değer*/).Replace("[1]", /*Sutüna insert edilecek değer*/).Replace("[2]",/*Sutüna insert edilecek değer*/));
        sw.Close();

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream strResponse = resp.GetResponseStream();
        StreamReader sr = new StreamReader(strResponse, System.Text.Encoding.ASCII);
        Result = sr.ReadToEnd();
        sr.Close();
        Response.Write(Result);
```
# URL Sihirbazı ile oluşturulan url'den veri okunması
```
DataSet veri = new DataSet();
veri.ReadXml("/*Sihirbaz ile oluşturduğunuz URL*/");
```
