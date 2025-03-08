<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EaseForm.aspx.vb" Inherits="GoForm.EaseForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css"/>
    <title>Main</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h1 class="text-center">Main</h1>
                </div>
            </div>
        </div>
    </form>
    <script src="~/Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
