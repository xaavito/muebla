Imports Util

Public Class Backup
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Try
            buscarBackups()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.GestorResguardoBLL.realizarBackup(Me.backupTextBox.Text)
            buscarBackups()
            Throw New Util.CreacionExitosaException
        Catch ex As Util.ExceptionManager
            logMessage(ex)
        End Try

    End Sub

    Protected Sub backupDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.backupDataGrid)
    End Sub

    Private Sub buscarBackups()
        Me.backupDataGrid.DataSource = BLL.GestorResguardoBLL.buscarBackups()
        Me.backupDataGrid.DataBind()
    End Sub

    Protected Sub ibtnRestore_Click(sender As Object, e As ImageClickEventArgs)
        ID = getItemId(sender, Me.backupDataGrid)
        Try
            BLL.GestorResguardoBLL.realizarRestore(id)
            buscarBackups()
            Throw New Util.RestauracionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub
End Class