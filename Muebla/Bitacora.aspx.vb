Imports Util

Public Class Bitacora
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Debug.WriteLine("PostBack de: " + getPostBackCaller())
            If getPostBackCaller().Equals("idiomasList") Then
                buscarTipoEventos()
            Else
                Return
            End If
        Else
            buscarTipoEventos()
        End If
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
    End Sub

    Protected Sub tipoEventoDropDown_SelectedIndexChanged(sender As Object, e As EventArgs)
        Debug.WriteLine("Cambio el tipo log: " + Me.tipoEventoDropDown.SelectedValue)
    End Sub

    Private Sub buscarTipoEventos()
        Dim lista As List(Of BE.TipoEventoBE) = Nothing
        Try
            lista = BLL.GestorBitacoraBLL.getTipoEventos(getSelectedIdioma())
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

End Class