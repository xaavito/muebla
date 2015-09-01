Public Class Backup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.GestorResguardoBLL.realizarBackup(Me.backupTextBox.Text)
        Catch ex As Util.ExceptionManager
            Dim messageLogger As Label = CType(Me.Master.FindControl("messageLogger"), Label)
            messageLogger.Text = ex.mensaje
        End Try

    End Sub
End Class