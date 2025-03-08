<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserRegister.aspx.vb" Inherits="GoForm.UserRegister" %>

<!DOCTYPE html>
<html lang="ja">
<head runat="server">
    <meta charset="utf-8" />
    <title>ユーザー登録</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="container mt-5">
    <a href="https://localhost:44330/Form/Login">LOG IN</a>
    <form id="UserRegisterForm" runat="server">
        <div class="row justify-content-center">
            <div class="card shadow p-4 login-card col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8">
                <h2 class="text-center mb-4">USER REGISTER</h2>
                <!-- メッセージ -->
                <div class="ms-1 mb-2">
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtUserId" CssClass="form-control" runat="server" placeholder="USER ID" />
                    <label class="form-label" fot="txtUserID">USER ID</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="PASSWORD" />
                    <label class="form-label" for="txtPassword">PASSWORD</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtPasswordConfirm" CssClass="form-control" TextMode="Password" runat="server" placeholder="PASSWORD Confirom" />
                    <label class="form-label" for="txtPasswordConfirm">PASSWORD CONFIOM</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" placeholder="USER NAME" />
                    <label class="form-label" for="txtUserName">USER　NAME</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="EMAIL" />
                    <label class="form-label" for="txtEmail">EMAIL</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtRemarks" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" placeholder="Remarks" />
                    <label class="form-label" for="txtRemarks">REMARKS</label>
                </div>

                <div class="form-check mb-3">
                    <asp:CheckBox ID="chkAgreementFlg" runat="server" />
                    <label class="form-check-label" for="chkAgreementFlg">AGREEMENT</label>
                </div>

                <div class="d-grid gap-2">
                    <asp:Button ID="btnRegister" Text="SUBMIT" CssClass="btn btn-secondary btn-lg" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
