Imports System.Data
Imports Oracle.ManagedDataAccess.Client

Public Class EaseForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Label1.Text = Session("USER_ID")
            Label2.Text = Session("USER_NAME")
            Label3.Text = Session("EMAIL")
        End If
    End Sub
End Class