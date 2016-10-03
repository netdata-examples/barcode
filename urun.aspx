<%@ Page Language="C#" AutoEventWireup="true" CodeFile="urun.aspx.cs" Inherits="urun" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <div class="col-md-8" >
                <asp:DropDownList ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                                            <asp:ListItem Value="1">Önce Yeni</asp:ListItem>
                                            <asp:ListItem Value="2">Önce Eski</asp:ListItem>
                                            <asp:ListItem Value="3">Puana göre Artan</asp:ListItem>
                                            <asp:ListItem Value="4">Puana göre Azalan</asp:ListItem>
                                            </asp:DropDownList>  
                <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                         </HeaderTemplate>
                       
                               <ItemTemplate>
                                  <h5> <div class="panel panel-default">
                           <div class="panel-body">
                       <div class="col-md-4">
                             <div class="panel panel-primary">
                            <div class="panel-body"><table class="table">
                                 <tr>
                                     <td>Kullanıcı</td>
                                     <td><%#Eval("dc_KullaniciID") %></td>
                                 </tr>
                                 <tr>
                                     <td>Puan</td>
                                     <td><img class="img-responsive" width="100" src="http:///*kendi sunucu adresiniz*//img/rating<%#Eval("dc_Rating") %>.png" /></td>
                                 </tr>
                                  <tr>
                                     <td>Tarih</td>
                                     <td><a href="../yorum/<%#Eval("ID") %>"><%#Eval("dc_YorumTarihi") %></a></td>
                                 </tr>
                                <tr>
                                    <td>Paylaş</td>
                                    <td><a href="http://twitter.com/share?url=http:///*kendi sunucu adresiniz*//yorum/<%#Eval("ID") %>&hashtags=yorumyap.us" target="_blank"><img src="img/twitter.png" /></a> <a href="https://www.facebook.com/sharer/sharer.php?u=localhost:28972/yorum/<%#Eval("ID") %>" target="_blank"><img src="img/facebook.png" /></a></td>
                                </tr>
                             </table>
                            </div>
                         </div> 
                         </div>
                        <div class="col-md-8">
                             <div class="panel panel-primary">
                                 <div class="panel-heading">Yorum</div>
                            <div class="panel-body">
                             <%#Eval("dc_Yorum") %>
                             </div>
                         </div> 
                         </div>
                                   </div> 
                    </div> 
                                      </h5>
                         </ItemTemplate>
                         
                   <FooterTemplate>
                      
                   </FooterTemplate>
                         </asp:Repeater>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
                        
           <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-body">
             <table class="table" >
                <tr>
                    <td>Ürün Adı: </td>
                    <td><%:Session["UrunAdi"].ToString() %></td>
                </tr>
                 <tr>
                    <td>Ürün Puanı </td>
                    <td><img class="img-responsive" width="100" src="http:///*kendi sunucu adresiniz*//img/rating<%:Session["urunpuani"] %>.png" /></td>
                </tr>
                <tr>
                    <td>Paylaş</td>
                    <td><a href="http://twitter.com/share?url=http:///*kendi sunucu adresiniz*//<%:Session["Link1"].ToString() %>-yorum-<%:Session["Link2"].ToString() %>&hashtags=yorumyap.us" target="_blank"><img src="img/twitter.png" /></a> <a href="https://www.facebook.com/sharer/sharer.php?u=http://localhost:28972/<%:Session["Link1"].ToString() %>-yorum-<%:Session["Link2"].ToString() %>" target="_blank"><img src="img/facebook.png" /></a></td>
                </tr>
                 <tr>
                    <td>Ürün Görseli: </td>
                    <td><a href="<%:Session["ImgSrc"].ToString() %>" target="_blank"><img class="img-responsive" width="125" height="125" alt="Büyük görsel için tıklayın."  src="<%:Session["ImgSrc"].ToString() %>" /></a></td>
                </tr>
                <tr>
                    <td>Urun Bilgisi: </td>
                    <td><%:Session["UrunBilgisi"].ToString() %></td>
                </tr>
               </table>
                        </div>
                    </div>
            <div class="panel panel-default">
                <div class="panel-body"><div class="col-md-12">
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:Panel ID="Panel2" runat="server">
             <h3><span class="label label-default">Yorum Yap</span></h3>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine" ></asp:TextBox>
            <br />
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" Width="150px" runat="server">
                <asp:ListItem Value="1">1 - Çok Kötü</asp:ListItem>
                <asp:ListItem Value="2">2 - Kötü</asp:ListItem>
                <asp:ListItem Value="3">3 - Orta</asp:ListItem>
                <asp:ListItem Value="4">4 - İyi</asp:ListItem>
                <asp:ListItem Value="5">5 - Çok İyi</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:ScriptManager runat="server" ID="button"></asp:ScriptManager>
                <asp:UpdatePanel runat="server"><ContentTemplate>
                    <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Yorum Yap" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
              </ContentTemplate></asp:UpdatePanel>
            
        </asp:Panel>
        </div>
                    </div> 
                </div> 
            </div>
                
            
     
    

    </asp:Content>
