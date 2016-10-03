<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giris.aspx.cs" Inherits="giris" %>

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
       <div class="form-group">
           <label for="TextBox1">Kullanıcı Adı</label>
           <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox>
           <label for="TextBox2">Şifre</label>
           <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
           <asp:Image ID="imgCaptcha" CssClass="img-responsive text-center" ImageUrl="Captcha.ashx" runat="server" />
           <label for="TextBox3">Güvenlik Kodu</label>
           <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="Button1_Click" Text="Giriş Yap"  />
           <asp:Label ID="Label3" runat="server"></asp:Label>
       </div>
      </div>
      <div class="col-md-4"></div> 
   </form>
   </div>
</body>
</html>
