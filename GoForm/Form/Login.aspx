<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="GoForm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" />
    <style>
        html {
            margin-top: 100px;
        }
    </style>
    <title>LOG IN</title>
</head>
<body class="container mt-5">
        <a href="https://localhost:44330/Form/UserRegister">USER REGISTER</a>
    <!-- ログイン　フォーム -->
    <form id="LoginForm" runat="server">
        <div class="row justify-content-center">
            <!-- ～575px（スマホ縦） 576px～（スマホ横）768px～（タブレット）992px～（ノートPC）1200px～（デスクトップ） -->
            <div class="card shadow p-4 login-card col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8">
                <h2 class="text-center mb-4">LOG IN</h2>
                <!-- メッセージ -->
                <div class="ms-1 mb-2">
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>

                <!-- ユーザーID -->
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" placeholder="USER ID"></asp:TextBox>
                    <label id="lblUserID" for="txtUserID">USER ID</label>
                </div>

                <!-- パスワード -->
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass=" form-control form-text" TextMode="Password" placeholder="PASSWORD"></asp:TextBox>
                    <label id="lblPassword" for="txtPassword">PASSWORD</label>
                </div>

                <!-- 入力記憶 -->
                <div class="form-check mb-3">
                    <asp:CheckBox ID="chkRememberMe" runat="server" />
                    <label class="form-check-label" for="chkRememberMe">REMENBER ME</label>
                </div>

                <!-- ログイン　ボタン -->
                <div class="d-grid gap-2">
                    <asp:Button ID="btnLogin" runat="server" Text="LOG IN" CssClass="btn btn-secondary btn-lg"/>
                </div>
            </div>
        </div>
    </form>

    <script src="~/Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>