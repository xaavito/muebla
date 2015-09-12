Public Class Login
    Inherits ExtendedPage

    Protected Sub login(sender As Object, e As EventArgs)
        Try
            Dim usr As String = Me.usrTextBox.Text
            Dim pass As String = Me.passTextBox.Text
            usuario = BLL.UsuarioBLL.login(pass, usr)
            If usuario Is Nothing Then
                Me.loginFailed.Text = "Usuario/contraseña equivocada"
            Else
                Session("Usuario") = usuario
                Response.Redirect("Main.aspx", False)
                Session("Idioma") = usuario.idioma.id
            End If
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub recuperarPass_Click(sender As Object, e As EventArgs)
        Response.Redirect("RecuperarContrasena.aspx", False)
    End Sub

    Protected Sub registroButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("Registro.aspx", False)
    End Sub
End Class