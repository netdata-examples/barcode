<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resimekle.aspx.cs" Inherits="Yonetici_resimekle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <table class="table">
            <tr>
                <td>Barkod Numarası</td>
                <td><asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" ></asp:TextBox></td>
                <td><asp:Button ID="Button4" CssClass="btn btn-default" runat="server" Text="Barkod Doğrulama" OnClick="Button4_Click" />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Button ID="Button2" CssClass="btn btn-default" runat="server" Text="Bilgisayardan" OnClick="Button2_Click" />
                <asp:Button ID="Button3" CssClass="btn btn-default" runat="server" Text="URL ile" OnClick="Button3_Click" />
                </td>
                <td>
                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                <asp:FileUpload ID="FileUpload1" CssClass="btn btn-default" runat="server"  Visible="false"/>
                </td>
             </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Button1" Visible="false" CssClass="btn btn-default" runat="server" Text="Resim Ekle" OnClick="Button1_Click" />
                </td>
                <td></td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
