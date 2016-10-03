<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cikis.aspx.cs" Inherits="Yonetici_cikis" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["yoneticigiris"] = false;
        Response.Redirect("~/Yonetici/giris.aspx");
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
