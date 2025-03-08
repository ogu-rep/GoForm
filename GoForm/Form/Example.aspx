<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Example.aspx.vb" Inherits="GoForm.Example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<!-- Bootstrap CSS（必要に応じて追加） -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
<!-- Bootstrap Datepicker CSS -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css" />
<!-- Materialize CSS -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css" />
<!-- Material Icons (アイコン用) -->
<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
</head>
<body class="p-5">
    <table class="table table-bordered border-dark">
        <thead>
            <tr>
                <th>ヘッダー1</th>
                <th>ヘッダー2</th>
                <th>ヘッダー3</th>
                <th>ヘッダー4</th>
                <th>ヘッダー5</th>
                <th>ヘッダー6</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td></td>
                <td>ヘッダー2</td>
                <td>ヘッダー3</td>
                <td>ヘッダー4</td>
                <td>ヘッダー5</td>
                <td>ヘッダー6</td>
            </tr>
        </tbody>
    </table>
    
    <img src="../uploads/image_00001.jpg" class="card-img-top" alt="サンプル画像" />
    
    <div class="card mt-5 border-0" style="width: 100%;">
        <div class="card-body">
            <button type="button" class="btn btn-dark btn-lg w-100">検索</button>
        </div>
        <table class="table table-borderless">
            <tbody>
                <tr>
                    <td>
                        <div class="form-floating">
                            <input type="text" id="text-f-1" class="form-control" placeholder="テキストフォーム１" />
                            <label for="text-f-1">テキストフォーム１</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating">
                            <input type="text" id="text-f-2" class="form-control" placeholder="テキストフォーム２" />
                            <label for="text-f-2">テキストフォーム２</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating">
                            <input type="text" id="text-f-3" class="form-control" placeholder="テキストフォーム３" />
                            <label for="text-f-3">テキストフォーム３</label>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <div class="form-floating">
                            <input type="text" id="text-f-4" class="form-control" placeholder="テキストフォーム４" />
                            <label for="text-f-1">テキストフォーム４</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating">
                            <input type="text" id="text-f-5" class="form-control" placeholder="テキストフォーム５" />
                            <label for="text-f-2">テキストフォーム５</label>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>

        <form runat="server">
            <table class="table table-borderless">
                <tbody>
                    <tr>
                        <td colspan="2" style="width: 50%;">
                            <div class="form-floating">
                                <asp:TextBox ID="txtFORM1" runat="server" CssClass="form-control" placeholder="テキストフォーム" oninput="transFrom1()"></asp:TextBox>
                                <label for="txtFORM1">テキストフォーム</label>
                            </div>
                        </td>

                        <td colspan="2"" style="width: 50%;">
                            <div>
                                <asp:Label ID="LABEL1" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="width: 50%;">
                            <div class="form-floating">
                                <asp:TextBox ID="txtFORM2" runat="server" CssClass="form-control" placeholder="テキストフォーム" oninput="transFrom2()"></asp:TextBox>
                                <label for="txtFORM2">テキストフォーム</label>
                            </div>
                        </td>

                        <td colspan="2"" style="width: 50%;">
                            <div>
                                <asp:Label ID="LABEL2" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="width: 50%;">
                            <asp:TextBox ID="txtFORM3" runat="server" CssClass="form-control" placeholder="テキストフォーム" oninput="transFrom3()"></asp:TextBox>
                        </td>

                        <td>
                            <div class="dropdown">
                                <button type="button" class="btn btn-dark dropdown-toggle" id="dropDownMenuButton"
                                    data-bs-toggle="dropdown" aria-expanded="false">選択</button>
                                <ul class="dropdown-menu"　aria-labelledby="dropDownMenuButton">
                                    <li><a class="dropdown-item" href="#">選択肢１</a></li>
                                    <li><a class="dropdown-item" href="#">選択肢２</a></li>
                                    <li><a class="dropdown-item" href="#">選択肢３</a></li>
                                </ul>
                            </div>
                        </td>

                        <td colspan="2"" style="width: 50%;">
                            <div>
                                <asp:Label ID="LABEL3" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </form>
    </div>
</body>
    <!-- jQuery（必要） -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- Bootstrap JS（必要） -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Bootstrap Datepicker JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>
    <!-- Materialize JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
    <script>
        function transFrom1() {

            document.getElementById("LABEL1").innerHTML = document.getElementById("txtFORM1").value
        };

        function transFrom2() {

            document.getElementById("LABEL2").innerHTML = document.getElementById("txtFORM2").value
        };

        $(document).ready(function () {
            $(".datepicker").datepicker({
                format: "yyyy-mm-dd",
                autoclose: true,
                todayHighlight: true,
            });
        });

    </script>
</html>
