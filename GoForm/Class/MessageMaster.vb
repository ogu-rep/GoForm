Imports System.Data                         ' Dataオブジェクト
Imports Oracle.ManagedDataAccess.Client     ' DB接続

Public Class MessageMaster
    ''' <summary>
    ''' メッセージコードから日本語メッセージを取得
    ''' </summary>
    ''' <param name="messageCode">メッセージコード</param>
    ''' <returns>日本語メッセージ本文</returns>
    Public Shared Function GetMessage(messageCode As String) As String
        Return GetMessageByLanguage(messageCode, "JP")
    End Function

    ''' <summary>
    ''' メッセージコードから言語別メッセージを取得
    ''' </summary>
    ''' <param name="messageCode">メッセージコード</param>
    ''' <param name="language">言語（JP/EN）</param>
    ''' <returns>メッセージ本文</returns>
    Public Shared Function GetMessageByLanguage(messageCode As String, language As String) As String
        Dim message As String = "未定義のメッセージコード: " & messageCode
        Dim sql As New StringBuilder

        With sql
            .Clear()
            .AppendLine("SELECT ")
            .AppendLine("    TEXT_JP, ")
            .AppendLine("    TEXT_EN ")
            .AppendLine("FROM ")
            .AppendLine("    MESSAGE_MASTER ")
            .AppendLine("WHERE ")
            .AppendLine("    CODE = :CODE ")
        End With

        Using db As New DbHelper()
            Dim parameters As New List(Of OracleParameter) From {
                New OracleParameter(":CODE", messageCode)
            }

            Dim dt As DataTable = db.ExecuteQuery(sql, parameters)

            If dt.Rows.Count > 0 Then
                If language.ToUpper() = "JP" Then
                    message = dt.Rows(0)("TEXT_JP").ToString()
                Else
                    message = dt.Rows(0)("TEXT_EN").ToString()
                End If
            End If
        End Using

        Return message
    End Function
End Class
