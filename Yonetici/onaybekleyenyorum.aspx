<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onaybekleyenyorum.aspx.cs" Inherits="Yonetici_yorumonay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
   <div class="container">
     <div class="text-center">
    <form id="form1" runat="server">
    
    
        <h4><asp:Label ID="Label1" runat="server"></asp:Label><a href="Default.aspx">Geri Dön.</a></h4>
        
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
               <table class="table">
           <thead>
               <tr>
                   <th>Yorum ID</th>
                   <th>Yorum</th>
                   <th>Yorum Seçiniz</th>
               </tr>
           </thead>
            </HeaderTemplate>
            <ItemTemplate>
               <tbody> <tr>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("dc_Yorum") %></td>
                    <td><a href="yorumonaylama.aspx?YorumID=<%#Eval("ID") %>" >Seç</a></td>
                </tr>
             </tbody>            
             </ItemTemplate>
            <FooterTemplate>
                </table> 
            </FooterTemplate>
        </asp:Repeater>
    
    
    </form>
    </div>
    </div>
</body>
</html>
