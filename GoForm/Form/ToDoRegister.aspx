<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ToDoRegister.aspx.vb" Inherits="GoForm.ToDoRegister" %>

<!DOCTYPE html>
<html lang="ja">
<head runat="server">
    <title>ToDoメモ登録</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body { background-color: #f5f5f5; }
        .card { background-color: #fff; }
        .form-floating label { color: #6c757d; }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
<div class="container mt-4">
    <div class="card">
        <div class="card-header bg-dark text-white">ToDoメモ登録</div>
        <div class="card-body">
            <div class="form-floating mb-3">
                <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server" />
                <label for="txtTitle">タイトル</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox ID="txtMemo" TextMode="MultiLine" Row="5" CssClass="form-control" runat="server" />
                <label for="txtMemo">メモ内容</label>
            </div>

            <div class="form-floating mb-3">
                <asp:DropDownList ID="ddlPriority" CssClass="form-select" runat="server">
                    <asp:ListItem>高</asp:ListItem>
                    <asp:ListItem>中</asp:ListItem>
                    <asp:ListItem>低</asp:ListItem>
                </asp:DropDownList>
                <label for="ddlPriority">優先度</label>
            </div>

            <div class="form-floating mb-3">
                <asp:DropDownList ID="ddlStatus" CssClass="form-select" runat="server">
                    <asp:ListItem>未着手</asp:ListItem>
                    <asp:ListItem>進行中</asp:ListItem>
                    <asp:ListItem>完了</asp:ListItem>
                </asp:DropDownList>
                <label for="ddlStatus">進捗状況</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox ID="txtDueDate" CssClass="form-control" runat="server" placeholder="YYYY/MM/DD" />
                <label for="txtDueDate">期限</label>
            </div>

            <div class="mb-3">
                <label class="form-label">ファイルアップロード（画像・動画複数選択可）</label>
                <asp:FileUpload ID="fileUpload" AllowMultiple="true" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnRegister" Text="登録" CssClass="btn btn-dark" runat="server" />
            <asp:Label ID="lblMessage" CssClass="text-danger mt-3" runat="server" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
