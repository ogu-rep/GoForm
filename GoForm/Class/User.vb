Imports System.Data                         ' Dataオブジェクト
Imports Oracle.ManagedDataAccess.Client     ' DB接続

Public Class User
    ' ユーザープロパティ（外部からGet可能）
    ''' <summary>
    ''' ユーザーID
    ''' </summary>
    ''' <returns></returns>
    Public Property UserID As String
    ''' <summary>
    ''' パスワード
    ''' </summary>
    ''' <returns></returns>
    Public Property Password As String
    ''' <summary>
    ''' ユーザー名
    ''' </summary>
    ''' <returns></returns>
    Public Property UserName As String
    ''' <summary>
    ''' メール
    ''' </summary>
    ''' <returns></returns>
    Public Property EMail As String

    ''' <summary>
    ''' コンストラクタ（USER_IDとPASSWORDで検索して、データ取得）
    ''' </summary>
    Public Sub SelectUser(userID As String, password As String)
        Dim dtUser As New DataTable()
        Dim sql As New StringBuilder()

        Using db As New DbHelper()
            With sql
                .Clear()
                .AppendLine("SELECT ")
                .AppendLine("    USER_ID AS ユーザーID, ")
                .AppendLine("    PASSWORD AS パスワード, ")
                .AppendLine("    USER_NAME AS ユーザー名, ")
                .AppendLine("    EMAIL AS メール ")
                .AppendLine("FROM ")
                .AppendLine("    USERS ")
                .AppendLine("WHERE ")
                .AppendLine("    USER_ID = :USER_ID ")
                .AppendLine("AND ")
                .AppendLine("    PASSWORD = :PASSWORD ")
            End With

            Dim params As New List(Of OracleParameter) From {
                New OracleParameter(":USER_ID", userID),
                New OracleParameter(":PASSWORD", Utility.HashSHA256(password))
            }

            dtUser = db.ExecuteQuery(sql, params)

            ' データがあればプロパティにセット
            If dtUser.Rows.Count > 0 Then
                Dim row As DataRow = dtUser.Rows(0)

                Me.UserID = row("ユーザーID").ToString()
                Me.Password = row("パスワード").ToString()
                Me.UserName = row("ユーザー名").ToString()
                Me.EMail = row("メール").ToString()
            End If
        End Using
    End Sub

    ''' <summary>
    ''' ユーザー登録
    ''' </summary>
    Public Sub Create(strUserID As String, strPassword As String, strUserName As String, strEmail As String, strEremarks As String, flgAgreement As String)
        Dim sql As New StringBuilder()

        Using db As New DbHelper()
            Try
                db.BeginTransaction()

                With sql
                    .Clear()
                    .AppendLine("INSERT INTO USERS ( ")
                    .AppendLine("   USER_ID, ")
                    .AppendLine("   PASSWORD, ")
                    .AppendLine("   USER_NAME, ")
                    .AppendLine("   EMAIL, ")
                    .AppendLine("   REMARKS, ")
                    .AppendLine("   AGREEMENT_FLG, ")
                    .AppendLine("   STATUS ")
                    .AppendLine(") ")
                    .AppendLine("VALUES (")
                    .AppendLine("   :USER_ID, ")
                    .AppendLine("   :PASSWORD, ")
                    .AppendLine("   :USER_NAME, ")
                    .AppendLine("   :EMAIL, ")
                    .AppendLine("   :REMARKS, ")
                    .AppendLine("   :AGREEMENT_FLG, ")
                    .AppendLine("   'P' ")
                    .AppendLine(") ")
                End With

                Dim params As New List(Of OracleParameter) From {
                    New OracleParameter(":USER_ID", strUserID),
                    New OracleParameter(":PASSWORD", Utility.HashSHA256(strPassword)),
                    New OracleParameter(":USER_NAME", strUserName),
                    New OracleParameter(":EMAIL", strEmail),
                    New OracleParameter(":REMARKS", strEremarks),
                    New OracleParameter(":AGREEMENT_FLG", flgAgreement)
                }

                db.ExecuteNonQuery(sql, params)

                db.Commit()

            Catch ex As Exception
                db.Rollback()
                Throw ex
            End Try
        End Using
    End Sub
End Class
