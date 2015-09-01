Public Class ExtendedPage
    Inherits System.Web.UI.Page

    Public Sub logMessage(ByVal message As String)
        Dim messageLogger As Label = CType(Me.Master.FindControl("messageLogger"), Label)
        messageLogger.Text = message
    End Sub
End Class
