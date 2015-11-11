Public Class RecuperarContrasena
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub recuperarPassButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.UsuarioBLL.solicitarContraseña(Me.mailTextBox.Text, Me.usrTextBox.Text)
            Throw New Util.MailEnviadoseException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub loginButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("Login.aspx", False)
    End Sub
End Class