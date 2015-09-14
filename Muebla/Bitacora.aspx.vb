Imports Util

Public Class Bitacora
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Session("Idioma")
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
        Dim id As Integer = Session("Idioma")
        Try
            Me.bitacoraResultadosDataGrid.DataSource = BLL.GestorBitacoraBLL.buscarBitacoras(Util.Util.getDate(Me.fechaHastaDate.Text), Util.Util.getDate(Me.fechaDesdeDate.Text), Me.tipoEventoDropDown.SelectedValue, Me.usuarioTextBox.Text, id)
            Me.bitacoraResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try

    End Sub

    Protected Sub bitacoraResultadosDataGrid_RowDataBound(sender As Object, e As GridViewRowEventArgs)

    End Sub

    Protected Sub bitacoraResultadosDataGrid_PreRender(sender As Object, e As EventArgs)

    End Sub
End Class