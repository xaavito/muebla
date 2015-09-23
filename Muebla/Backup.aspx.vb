Imports Util

Public Class Backup
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.backupDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        Try
            BLL.ProductoBLL.bajaProducto(id)
            gvRow.Visible = False
            logMessage(New EliminacionExitosaException)
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub backupDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.backupDataGrid)
        'Dim id As Integer = getSelectedIdioma()

        'If Not Me.backupDataGrid.HeaderRow Is Nothing Then
        '    For index = 0 To Me.backupDataGrid.HeaderRow.Cells.Count - 1
        '        Dim traduccion As String = BLL.GestorIdiomaBLL.getTranslation(Me.backupDataGrid.HeaderRow.Cells(index).Text, id)
        '        If (Not traduccion Is Nothing) Then
        '            Me.backupDataGrid.HeaderRow.Cells(index).Text = traduccion
        '        End If
        '    Next
        'End If
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
            logMessage(New Util.RestauracionExitosaException)
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    

End Class