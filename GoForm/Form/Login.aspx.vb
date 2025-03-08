Imports System.Security.Cryptography    ' 
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    ''' <summary>
    ''' ログインボタン　押下時
    ''' </summary>
    Protected Sub BtnLogin_Click() Handles btnLogin.Click
        Dim userID As String = txtUserID.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim user As New User

        Try
            ' ユーザーIDまたはpasswordが未入力
            If userID = "" Then
                lblMsg.Text = MessageMaster.GetMessage("USER_ID_EMPTY")

                Return
            ElseIf password = "" Then
                lblMsg.Text = MessageMaster.GetMessage("PASSWORD_EMPTY")

                Return
            End If

            User.SelectUser(userID, password)

            ' UserIDまたはpasswordが一致しない
            If IsNothing(User.UserID) Then
                lblMsg.Text = MessageMaster.GetMessage("LOGIN_FAILED")
                Return
            Else
                ' ログイン成功
                Session("USER_ID") = User.UserID
                Session("USER_NAME") = User.UserName
                Session("EMAIL") = User.EMail

                Response.Redirect("EaseForm.aspx")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class