Imports Oracle.ManagedDataAccess.Client     ' DB接続

Public Class UserTemp
    ''' <summary>
    ''' ユーザー仮登録
    ''' </summary>
    Public Shared Sub CreateUserTemp(strUserID As String)
        Dim sql As New StringBuilder()

        Using db As New DbHelper()
            Try
                db.BeginTransaction()

                With sql
                    .Clear()
                    .AppendLine("INSERT INTO USER_TEMP ( ")
                    .AppendLine("   USER_ID, ")
                    .AppendLine("   CREATED_AT, ")
                    .AppendLine("   EXPIRED_AT ")
                    .AppendLine(") ")
                    .AppendLine("VALUES (")
                    .AppendLine("   :USER_ID, ")
                    .AppendLine("   SYSDATE, ")
                    .AppendLine("   SYSDATE + 1 ")
                    .AppendLine(") ")
                End With

                Dim params As New List(Of OracleParameter) From {
                    New OracleParameter(":USER_ID", strUserID)
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
