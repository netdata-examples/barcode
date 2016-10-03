<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Yonetici_Default" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, System.EventArgs e) {
        if (Convert.ToBoolean(Session["yoneticigiris"]) == false)
        {
            Response.Redirect("~/Yonetici/giris.aspx");
        }
        else
        {
            
        }
        Label1.Text = "Hoşgeldiniz Sayın   " + Session["yoneticiadi"] + "   İşlem Seçiniz";
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <div class="container">
    <div class="text-center">
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            <h3><asp:Label ID="Label1"  runat="server"></asp:Label></h3>
            <br />
            <div class="btn-group btn-group-vertical">
            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-default" runat="server" NavigateUrl="~/Yonetici/onaybekleyenyorum.aspx">Yorum Onaylama</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" CssClass="btn btn-default" runat="server" NavigateUrl="~/Yonetici/urunekle.aspx">Ürün Ekle</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" CssClass="btn btn-default" runat="server" NavigateUrl="~/Yonetici/resimekle.aspx">Resim Ekle</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" CssClass="btn btn-default" runat="server" NavigateUrl="~/Yonetici/cikis.aspx">Çıkış</asp:HyperLink>
            </div>
        </asp:Panel>
    
    </div>
    </form>
    </div>
    </div>
</body>
</html>
