<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ara.aspx.cs" Inherits="ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-12">
        
        <div class="col-lg-3">
                  
        </div>
        <div class="col-lg-6" style="background-color:white">
            <asp:Label ID="hatalabel" runat="server" Text=""></asp:Label>
            <asp:Repeater ID="Repeater1" runat="server">
                
                 <ItemTemplate>
                      <table class="table">
                          <tr>
                             <td><a href="/*sunucu adresiniz*//<%#Eval("dc_UrunAdikisa") %>-yorum-<%#Eval("dc_UrunKodu") %>"><img src="<%#Eval("dc_ImgSrc") %>" width="64" height="64" /></a></td>
                             <td><a href="/*sunucu adresiniz*//<%#Eval("dc_UrunAdikisa") %>-yorum-<%#Eval("dc_UrunKodu") %>"><h4><b>Bulunan Ürün: </b><%#Eval("dc_UrunAdi") %></h4></a></td>
                          </tr>
                      </table>
                         
                         
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-lg-3">
                   
        </div>
    </div>
</asp:Content>

