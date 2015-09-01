Public Class Backup
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.backupDataGrid.DataSource = BLL.GestorResguardoBLL.buscarBackups()
        Me.backupDataGrid.DataBind()
    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.GestorResguardoBLL.realizarBackup(Me.backupTextBox.Text)
        Catch ex As Util.ExceptionManager
            Dim messageLogger As Label = CType(Me.Master.FindControl("messageLogger"), Label)
            messageLogger.Text = ex.mensaje
        End Try

    End Sub

    Protected Sub bitacoraDataGrid_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)

    End Sub
End Class