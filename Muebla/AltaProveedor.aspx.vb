Public Class AltaProveedor1
    Inherits ExtendedPage

    Protected Sub cancelarAltaProveedorButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub confirmarAltaProveedorButton_Click(sender As Object, e As EventArgs)
        Dim prov As New BE.ProveedorBE
        prov.cuit = Me.cuitTextBox.Text
        prov.direccion = Me.direccionTextBox.Text
        prov.mail = Me.emailTextBox.Text
        prov.razonSocial = Me.nombreTextBox.Text
        prov.tel = Me.telefonoTextBox.Text
        prov.id = BLL.ProveedorBLL.altaProveedor(prov)
    End Sub
End Class