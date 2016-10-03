<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giris.aspx.cs" Inherits="Yonetici_giris" %>

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
            <br /><h4>Kullanıcı Adı:</h4>
                        <asp:TextBox ID="TextBox1" CssClass="form-control"  runat="server"></asp:TextBox>
                        <h4>Şifre</h4>
                        <asp:TextBox ID="TextBox2" CssClass="form-control"  runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Button ID="Button1" CssClass="btn btn-default" runat="server"  OnClick="Button1_Click" Text="Giriş Yap" /><asp:Label ID="Label3" runat="server"></asp:Label>

        </div>
        <div class="col-md-4"></div>
    
            
                        
                   
        
    </form>
        </div>
</body>
</html>
