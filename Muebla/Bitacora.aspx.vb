Imports Util

Public Class Bitacora
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = getSelectedIdioma()
        Dim lista As List(Of BE.TipoEventoBE)
        Try
            lista = BLL.GestorBitacoraBLL.getTipoEventos(id)
        Catch ex As Exception
            logMessage(ex)
        End Try

        Dim todos As New BE.TipoEventoBE
        todos.codigo = 0
        todos.texto = ""
        lista.Add(todos)
        Me.tipoEventoDropDown.DataSource = lista
        Me.tipoEventoDropDown.DataTextField = "texto"
        Me.tipoEventoDropDown.DataValueField = "codigo"
        Me.tipoEventoDropDown.DataBind()


    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)
        Dim id As Integer = getSelectedIdioma()
        Try
            Me.bitacoraResultadosDataGrid.DataSource = BLL.GestorBitacoraBLL.buscarBitacoras(Util.Util.getDate(Me.fechaHastaDate.Text), Util.Util.getDate(Me.fechaDesdeDate.Text), Me.tipoEventoDropDown.SelectedValue, Me.usuarioTextBox.Text, id)
            Me.bitacoraResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try

    End Sub

    Protected Sub bitacoraResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.bitacoraResultadosDataGrid)

        'Dim id As Integer = getSelectedIdioma()

        'If Not Me.bitacoraResultadosDataGrid.HeaderRow Is Nothing Then
        '    For index = 0 To Me.bitacoraResultadosDataGrid.HeaderRow.Cells.Count - 1
        '        Dim traduccion As String = BLL.GestorIdiomaBLL.getTranslation(Me.bitacoraResultadosDataGrid.HeaderRow.Cells(index).Text, id)
        '        If (Not traduccion Is Nothing) Then
        '            Me.bitacoraResultadosDataGrid.HeaderRow.Cells(index).Text = traduccion
        '        End If
        '    Next
        'End If
    End Sub
End Class