using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web;
public partial class _Default : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Yorum Yap";
        DataSet urunler = new DataSet();
        urunler.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=dc_UrunAdi,dc_UrunAdikisa,dc_ImgSrc,dc_UrunKodu&$orderby=ID%5Bdesc%5D&$top=10");
        RepeaterUrun.DataSource = urunler;
        RepeaterUrun.DataBind();


        
        DataSet yorumlar = new DataSet();
        yorumlar.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=dc_UrunID&$orderby=ID%5Bdesc%5D&$top=10");
        DataSet yorumlarurun = new DataSet();
        DataTable yorumtable = new DataTable();
        yorumtable.Columns.Add(new DataColumn("ID", typeof(string)));
        yorumtable.Columns.Add(new DataColumn("AD", typeof(string)));
        yorumtable.Columns.Add(new DataColumn("IMGSRC", typeof(string)));
        yorumtable.Columns.Add(new DataColumn("UrunAdikisa", typeof(string)));
        yorumtable.Columns.Add(new DataColumn("UrunKodu", typeof(string)));


        foreach (DataRow yorumrow in yorumlar.Tables[0].Rows)
        {
            KullaniciReference.WSSoapClient yorumal = new KullaniciReference.WSSoapClient();
            DataSet vericek = yorumal.GetData("/*kendi api keyiniz*/", "ID", yorumrow["dc_UrunID"].ToString());
            DataRow dr = yorumtable.NewRow();
            dr["ID"] = Convert.ToInt32(yorumrow["dc_UrunID"]);
            dr["AD"] = vericek.Tables[0].Rows[0]["dc_UrunAdi"].ToString();
            dr["IMGSRC"] = vericek.Tables[0].Rows[0]["dc_ImgSrc"].ToString();
            dr["UrunAdikisa"] = vericek.Tables[0].Rows[0]["dc_UrunAdikisa"].ToString();
            dr["UrunKodu"] = vericek.Tables[0].Rows[0]["dc_UrunKodu"].ToString();
            yorumtable.Rows.Add(dr);
        }
        yorumlarurun.Tables.Add(yorumtable);
        RepeaterYorum.DataSource = yorumlarurun;
        RepeaterYorum.DataBind();

        DataSet yildiz5 = new DataSet();
        yildiz5.ReadXml("https://www.netdata.com/XML//*kendi api keyiniz*/?$select=dc_UrunID&$where=dc_Rating=5&$orderby=ID%5Bdesc%5D&$top=10");
        DataSet yorumlarurun5 = new DataSet();
        DataTable yorumtable5 = new DataTable();
        yorumtable5.Columns.Add(new DataColumn("ID", typeof(string)));
        yorumtable5.Columns.Add(new DataColumn("AD", typeof(string)));
        yorumtable5.Columns.Add(new DataColumn("IMGSRC", typeof(string)));
        yorumtable5.Columns.Add(new DataColumn("UrunAdikisa", typeof(string)));
        yorumtable5.Columns.Add(new DataColumn("UrunKodu", typeof(string)));

        foreach (DataRow yorumrow5 in yildiz5.Tables[0].Rows)
        {
            KullaniciReference.WSSoapClient yorumal5 = new KullaniciReference.WSSoapClient();
            DataSet vericek5 = yorumal5.GetData("/*kendi api keyiniz*/", "ID", yorumrow5["dc_UrunID"].ToString());
            DataRow dr5 = yorumtable5.NewRow();
            dr5["ID"] = Convert.ToInt32(yorumrow5["dc_UrunID"]);
            dr5["AD"] = vericek5.Tables[0].Rows[0]["dc_UrunAdi"].ToString();
            dr5["IMGSRC"] = vericek5.Tables[0].Rows[0]["dc_ImgSrc"].ToString();
            dr5["UrunAdikisa"] = vericek5.Tables[0].Rows[0]["dc_UrunAdikisa"].ToString();
            dr5["UrunKodu"] = vericek5.Tables[0].Rows[0]["dc_UrunKodu"].ToString();
            yorumtable5.Rows.Add(dr5);
        }
        yorumlarurun5.Tables.Add(yorumtable5);
        Repeater5Yildiz.DataSource = yorumlarurun5;
        Repeater5Yildiz.DataBind();
        
    }

   
}