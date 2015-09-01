Public Class RecuperarContrasena
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub recuperarPassButton_Click(sender As Object, e As EventArgs)
        Dim pass As String = BLL.UsuarioBLL.solicitarContraseña(Me.mailTextBox.Text, Me.usrTextBox.Text)
        If Not pass Is Nothing Then
            Me.mailEnviandose.Text = "Su contraseña sera enviada a la brevedad al mail"
        Else
            Me.mailEnviandose.Text = "Usuario no existente!"
        End If
    End Sub
End Class