Imports System.Data                         ' Dataオブジェクト
Imports Oracle.ManagedDataAccess.Client     ' DB接続

''' <summary>
''' データベースアクセスクラス
''' </summary>
Public Class DbHelper
    Implements IDisposable

    Private connection As OracleConnection
    Private transaction As OracleTransaction

    ''' <summary>
    ''' コンストラクタ（接続オープン）
    ''' </summary>
    Public Sub New()
        connection = New OracleConnection("User Id=admin;Password=admin;Data Source=localhost/XEPDB1")
        connection.Open()
    End Sub

    ''' <summary>
    ''' トランザクション開始
    ''' </summary>
    Public Sub BeginTransaction()
        transaction = connection.BeginTransaction()
    End Sub

    ''' <summary>
    ''' コミット
    ''' </summary>
    Public Sub Commit()
        transaction?.Commit()
        transaction = Nothing
    End Sub

    ''' <summary>
    ''' ロールバック
    ''' </summary>
    Public Sub Rollback()
        transaction?.Rollback()
        transaction = Nothing
    End Sub

    ''' <summary>
    ''' SQLを実行（SELECT用）
    ''' </summary>
    Public Function ExecuteQuery(query As StringBuilder, Optional parameters As List(Of OracleParameter) = Nothing) As DataTable
        Dim dt As New DataTable()

        Using cmd As New OracleCommand(query.ToString, connection)
            ' SQLserverと異なり、トランザクションを設定しないとエラーになる
            cmd.Transaction = transaction

            If parameters IsNot Nothing Then
                cmd.Parameters.AddRange(parameters.ToArray())
            End If

            Using adapter As New OracleDataAdapter(cmd)


                adapter.Fill(dt)

                Return dt
            End Using
        End Using
    End Function

    ''' <summary>
    ''' SQLを実行（INSERT/UPDATE/DELETE用）
    ''' </summary>
    Public Function ExecuteNonQuery(query As StringBuilder, Optional parameters As List(Of OracleParameter) = Nothing) As Integer
        Using cmd As New OracleCommand(query.ToString, connection)
            ' SQLserverと異なり、トランザクションを設定しないとエラーになる
            cmd.Transaction = transaction

            If parameters IsNot Nothing Then
                cmd.Parameters.AddRange(parameters.ToArray())
            End If

            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    ''' <summary>
    ''' リソース解放
    ''' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        transaction?.Dispose()
        connection?.Dispose()
    End Sub
End Class
