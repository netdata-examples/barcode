<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yorumonaylama.aspx.cs" Inherits="Yonetici_yorumonayevet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
    <div>
    <table class="table">
        <tr>
            <td>Yorum Yapılan Ürün:</td>
            <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Yorum Yapan Kullanıcı </td>
            <td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Yorum</td>
            <td><textarea class="form-control" rows="3" id="yorumtext" runat="server" /></td>
        </tr>
        <tr>
            <td>Yorum Tarihi</td>
            <td><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
      
    <div class="text-center">
        <asp:Button ID="DuzenleButon" CssClass="btn btn-default" runat="server" Text="Düzenle" OnClick="DuzenleButon_Click" />&ensp;
        <asp:Button ID="OnaylaButon" CssClass="btn btn-default" runat="server" Text="Onayla" OnClick="OnaylaButon_Click" />&ensp;
        <asp:Button ID="ReddetButon" CssClass="btn btn-default" runat="server" Text="Reddet" OnClick="ReddetButon_Click" />
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
      
    </div>
    </div>
    </form>
    </div>
</body>
</html>
