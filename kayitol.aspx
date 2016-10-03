<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kayitol.aspx.cs" Inherits="kayitol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        <div class="col-md-4"></div>
    <div class="col-md-4">
        <br />
        <br />
                   <label for="TextBox1">Kullanıcı Adı:</label>
                   <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                   <label for="TextBox2">Şifre:</label>
                   <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox><br />
                   <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Kayıt Ol" OnClick="Button1_Click" Width="123px" /><br />
                   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
      </div>
        <div class="col-md-4"></div>
    </form>
   </div>
</body>
</html>
