<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="yorum.aspx.cs" Inherits="yorum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" CssClass="text-center" Text=""></asp:Label>
    <div class="col-md-12" id="yorumdiv" runat="server">
        <div class="col-md-9">
                <div class="panel panel-primary">
                    <div class="panel-heading"><%:Session["UrunAdi"].ToString() %> Hakkında Yapılan Yorum</div>
                    <div class="panel-body"><%:Session["Yorum"].ToString() %></div>
                    <div class="panel-footer"><%:Session["YorumYapan"].ToString() %> tarafından <%:Session["YorumTarihi"].ToString() %> tarihinde 5 üzerinden <%:Session["YorumRating"].ToString() %> yıldız verildi.</div>
                </div>
        </div>
        <div class="col-md-3">
            <div class="panel panel-default">
                <div class="panel-heading">Ürüne Git</div>
                <div class="panel-body">
                    <table class="table-borderless text-center">
                        <tr>
                            <td><a href="../<%:Session["UrunAdikisa"].ToString() %>-yorum-<%:Session["UrunKodu"].ToString() %>"><img src="<%:Session["ImgSrc"].ToString() %>" class="img-responsive" alt="<%:Session["UrunAdi"].ToString() %>" /></a></td>
                        </tr>
                        <tr>
                            <td><br /><a href="../<%:Session["UrunAdikisa"].ToString() %>-yorum-<%:Session["UrunKodu"].ToString() %>"><%:Session["UrunAdi"].ToString() %></a></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

