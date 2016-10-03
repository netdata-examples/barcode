<%@ Page Language="C#" AutoEventWireup="true" CodeFile="urunekle.aspx.cs" Inherits="Yonetici_urunekle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server">
    <div class="container">
        <div class="col-md-5">
    <table class="table">
        <tr>
            <td>Barkod Numarası</td>
            <td><asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Ürün Adı</td>
            <td><asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Ürün Bilgisi</td>
            <td><asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Ürünü Ekle" OnClick="Button1_Click" /></td>
        </tr>
    </table>
    </div>
    <div class="col-md-7">
        <h3>Lütfen hazır şablonu indirip şablona göre dosya yükleyiniz.</h3>
            <table class="table">
                <tr>
                    <td><h4>Hazır şablon</h4></td>
                    <td><a href="../img/Urun.xls" class="btn btn-default" target="_blank"> Hazır Şablon Urun.xls</a></td>
                </tr>
                <tr>
                    <td><h4>Yüklenecek Dosya</h4></td>
                    <td><asp:FileUpload ID="FileUpload1" CssClass="btn btn-default" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="Button2" CssClass="btn btn-default" runat="server" Text="Yükle" OnClick="Button2_Click" /><br /><asp:Label runat="server" Text="" ID="excellabel"></asp:Label></td>
                </tr>
            </table>
    </div>
        </div>
    </form>
    
</body>
</html>
