Public Class Logger
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.logger.Text = Application("logger").ToString
        DataBind()
    End Sub

End Class