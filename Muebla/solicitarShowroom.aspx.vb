Public Class solicitarShowroom
    Inherits ExtendedPage

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.GestorShowroomBLL.agregarPedido(Util.Util.getDate(Me.fechaSolicitadaTexBox.Text), getUsuario)
            Throw New Util.CreacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub
End Class