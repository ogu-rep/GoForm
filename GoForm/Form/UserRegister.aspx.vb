Imports System.Data                         ' Dataオブジェクト
Imports Oracle.ManagedDataAccess.Client     ' DB接続
Imports System.Text                         ' StringBuilder
Imports System.Security.Cryptography        ' 暗号化
Imports System.Net.Mail                     ' メール
Imports System.Net

Public Class UserRegister
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' 登録ボタン　押下時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim strUserID As String = txtUserId.Text.Trim()
        Dim strPassword As String = txtPassword.Text.Trim()
        Dim strUserName As String = txtUserName.Text.Trim()
        Dim strEmail As String = txtEmail.Text.Trim()
        Dim strEremarks As String = txtRemarks.Text.Trim()
        Dim flgAgreement As String = If(chkAgreementFlg.Checked, "Y", "N")
        Dim user As New User()

        Try
            ' 仮登録テーブルに登録
            UserTemp.CreateUserTemp(strUserID)
            ' ユーザーテーブルに登録（仮： STATUS = 'P'）
            user.Create(strUserID, strPassword, strUserName, strEmail, strEremarks, flgAgreement)

            With lblMsg
                .ForeColor = Drawing.Color.Green
                .Text = "仮登録が完了しました。<br>メールを確認してください。"
            End With

            SendMail()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' メール送信
    ''' 
    ''' </summary>
    Public Sub SendMail()
        ' メールメッセージ作成
        Using msg As New MailMessage()
            msg.From = New MailAddress("admin@gmail.com")       ' 送信元
            msg.To.Add("shunogu1109@gmail.com")                 ' 宛先（複数追加可能）
            msg.Subject = "テストメール"
            msg.Body = "これはVB.NETから送信したメールです。"
            msg.IsBodyHtml = False                              ' HTMLメールならTrue

            ' SMTPクライアント設定
            Using smtp As New SmtpClient("shunogu1109@gmail.com")
                'smtp.EnableSsl = True                            ' SSLを使用

                ' メール送信
                smtp.Send(msg)
            End Using
        End Using
    End Sub
End Class