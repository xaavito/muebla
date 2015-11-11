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
        Catch ex As Util.ExceptionManager
            logMessage(ex)
        End Try

    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub backupDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.backupDataGrid)
    End Sub

    Private Sub buscarBackups()
        Me.backupDataGrid.DataSource = BLL.GestorResguardoBLL.buscarBackups()
        Me.backupDataGrid.DataBind()
    End Sub

    Protected Sub ibtnRestore_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.backupDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        id = getItemId(sender, Me.backupDataGrid)
        Try
            BLL.GestorResguardoBLL.realizarRestore(id)
            buscarBackups()
            Throw New Util.RestauracionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    

End Class