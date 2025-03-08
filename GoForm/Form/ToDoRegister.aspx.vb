Imports System.IO
Imports Oracle.ManagedDataAccess.Client

Public Class ToDoRegister
    Inherits System.Web.UI.Page

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        If Not ValidateInput() Then
            Exit Sub
        End If

        Using db As New DbHelper()
            Try
                db.BeginTransaction()

                ' ToDoメモ登録
                Dim todoId = InsertToDoMemo(db)

                ' ファイルアップロード＆登録
                SaveUploadedFiles(db, todoId)

                db.Commit()
                lblMessage.ForeColor = Drawing.Color.Green
                lblMessage.Text = "登録が完了しました。"

            Catch ex As Exception
                db.Rollback()
                lblMessage.ForeColor = Drawing.Color.Red
                lblMessage.Text = "登録に失敗しました。" & ex.Message
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' ToDoメモ登録
    ''' </summary>
    ''' <param name="db"></param>
    ''' <returns>登録したTODO_ID</returns>
    Private Function InsertToDoMemo(db As DbHelper) As Integer
        Dim sql As New StringBuilder()

        With sql
            .Clear()
            .AppendLine("INSERT INTO TODO_MEMO (")
            .AppendLine("  TODO_ID, ")
            .AppendLine("  TITLE, ")
            .AppendLine("  MEMO, ")
            .AppendLine("  PRIORITY, ")
            .AppendLine("  STATUS, ")
            .AppendLine("  DUE_DATE, ")
            .AppendLine("  CREATED_AT, ")
            .AppendLine("  UPDATED_AT ")
            .AppendLine(") ")
            .AppendLine("VALUES (")
            .AppendLine("  TODO_MEMO_SEQ.NEXTVAL, ")
            .AppendLine("  :title, ")
            .AppendLine("  :memo, ")
            .AppendLine("  :priority, ")
            .AppendLine("  :status, ")
            .AppendLine("  TO_DATE(:dueDate, 'YYYY/MM/DD'), ")
            .AppendLine("  SYSDATE, ")
            .AppendLine("  SYSDATE ")
            .AppendLine(") ")
            .AppendLine("RETURNING TODO_ID INTO :todoId")
        End With

        Dim parameters As New List(Of OracleParameter) From {
            New OracleParameter("title", txtTitle.Text),
            New OracleParameter("memo", txtMemo.Text),
            New OracleParameter("priority", ddlPriority.SelectedValue),
            New OracleParameter("status", ddlStatus.SelectedValue),
            New OracleParameter("dueDate", txtDueDate.Text),
            New OracleParameter("todoId", OracleDbType.Int32, ParameterDirection.Output)
        }

        db.ExecuteNonQuery(sql, parameters)

        Return Convert.ToInt32(parameters.Find(Function(p) p.ParameterName = "todoId").Value.ToInt32())
    End Function

    ''' <summary>
    ''' アップロードファイル保存＆DB登録
    ''' </summary>
    ''' <param name="db"></param>
    ''' <param name="todoId"></param>
    Private Sub SaveUploadedFiles(db As DbHelper, todoId As Integer)
        If Not fileUpload.HasFiles Then Return

        Dim saveDir = Server.MapPath("~/uploads/")
        If Not Directory.Exists(saveDir) Then
            Directory.CreateDirectory(saveDir)
        End If

        For Each file As HttpPostedFile In fileUpload.PostedFiles
            Dim fileName = Path.GetFileName(file.FileName)
            Dim savePath = Path.Combine(saveDir, $"{todoId}_{fileName}")
            file.SaveAs(savePath)

            Dim fileType = If(file.ContentType.StartsWith("image"), "画像", If(file.ContentType.StartsWith("video"), "動画", "その他"))

            Dim query As New StringBuilder()
            query.AppendLine("INSERT INTO TODO_FILES (")
            query.AppendLine("  FILE_ID, TODO_ID, FILE_NAME, FILE_PATH, FILE_TYPE, UPLOADED_AT")
            query.AppendLine(") VALUES (")
            query.AppendLine("  TODO_FILES_SEQ.NEXTVAL, :todoId, :fileName, :filePath, :fileType, SYSDATE")
            query.AppendLine(")")

            Dim parameters As New List(Of OracleParameter) From {
                New OracleParameter("todoId", todoId),
                New OracleParameter("fileName", fileName),
                New OracleParameter("filePath", "/uploads/" & $"{todoId}_{fileName}"),
                New OracleParameter("fileType", fileType)
            }

            db.ExecuteNonQuery(query, parameters)
        Next
    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtTitle.Text) Then
            lblMessage.Text = "タイトルを入力してください。"
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDueDate.Text) Then
            lblMessage.Text = "期限を入力してください。"
            Return False
        End If

        Return True
    End Function
End Class
