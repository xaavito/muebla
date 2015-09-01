Public Class ExtendedPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        logMessage("")
    End Sub

    Public Sub logMessage(ByVal message As String)
        Dim messageLogger As Label = CType(Me.Master.FindControl("messageLogger"), Label)
        messageLogger.Text = message
    End Sub
End Class
