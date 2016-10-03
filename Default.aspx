<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-4 text-center">
        <div class="panel panel-default">
            <div class="panel-body">
                Son Eklenen 10 ürün
                <asp:Repeater ID="RepeaterUrun" runat="server">
                    <ItemTemplate>
                        <table class="table">
                            <tr>
                                <td><a href="/*kendi sunucu adresiniz*//<%#Eval("dc_UrunAdikisa") %>-yorum-<%#Eval("dc_UrunKodu") %>"><img src="<%#Eval("dc_ImgSrc") %>" width="32" height="32" /></a></td>
                                <td><a href="/*kendi sunucu adresiniz*//<%#Eval("dc_UrunAdikisa") %>-yorum-<%#Eval("dc_UrunKodu") %>"><%#Eval("dc_UrunAdi") %></a></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="col-md-4 text-center">
        <div class="panel panel-default">
            <div class="panel-body">
                Son Yapılan 10 Yorum
                <asp:Repeater ID="RepeaterYorum" runat="server">
                    <ItemTemplate>
                        <table class="table">
                            <tr>
                              <td><a href="/*kendi sunucu adresiniz*//<%#Eval("UrunAdikisa") %>-yorum-<%#Eval("UrunKodu") %>"><img src="<%#Eval("IMGSRC") %>" width="32" height="32" /></a></td>
                              <td><a href="/*kendi sunucu adresiniz*//<%#Eval("UrunAdikisa") %>-yorum-<%#Eval("UrunKodu") %>"><%#Eval("AD") %></a></td>  
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="col-md-4 text-center">
        <div class="panel panel-default">
            <div class="panel-body">
                En son 5 yıldız alan 10 Ürün
                <asp:Repeater ID="Repeater5Yildiz" runat="server">
                    <ItemTemplate>
                        <table class="table">
                            <tr>
                                <td><a href="/*kendi sunucu adresiniz*//<%#Eval("UrunAdikisa") %>-yorum-<%#Eval("UrunKodu") %>"><img src="<%#Eval("IMGSRC") %>" width="32" height="32" /></a></td>
                                <td><a href="/*kendi sunucu adresiniz*//<%#Eval("UrunAdikisa") %>-yorum-<%#Eval("UrunKodu") %>"><%#Eval("AD") %></a></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>