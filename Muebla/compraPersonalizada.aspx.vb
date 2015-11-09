Public Class compraPersonalizada
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            Dim ped As New BE.PedidoPersonalizado
            ped.imagen = Me.fileUpload.FileBytes
            ped.descripcion = Me.descripcionTextBox.Text
            ped.usr = getUsuario()
            BLL.GestorPedidoBLL.generarPedidoPersonalizado(ped)
            Throw New Util.PedidoPersonalizadoExitosoException
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub
End Class