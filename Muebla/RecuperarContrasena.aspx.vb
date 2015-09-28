Public Class RecuperarContrasena
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub recuperarPassButton_Click(sender As Object, e As EventArgs)
        Try
            Dim pass As String = BLL.UsuarioBLL.solicitarContraseña(Me.mailTextBox.Text, Me.usrTextBox.Text)
            If Not pass Is Nothing Then
                Throw New Util.MailEnviadoseException
                'Me.mailEnviandose.Text = "Su contraseña sera enviada a la brevedad al mail"
            Else
                Throw New Util.UsuarioNoEncontradoException
                'Me.mailEnviandose.Text = "Usuario no existente!"
            End If
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub loginButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("Login.aspx", False)
    End Sub
End Class