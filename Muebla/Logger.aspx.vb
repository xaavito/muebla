Public Class Logger
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Application("logger") Is Nothing Then
            Me.logger.Text = Application("logger").ToString
            DataBind()
        End If
    End Sub
End Class