Public Class Login
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub login(sender As Object, e As EventArgs)
        Dim usr As String = Me.usrTextBox.Text
        Dim pass As String = Me.passTextBox.Text
        Dim usuario As New BE.UsuarioBE
        usuario = BLL.UsuarioBLL.login(pass, usr)
        If usuario Is Nothing Then
            Me.loginFailed.Text = "Usuario/contraseña equivocada"
        Else
            Session("Usuario") = usuario
            Response.Redirect("Main.aspx")
            Session("Idioma") = usuario.idioma.id
        End If

    End Sub

    Protected Sub recuperarPass_Click(sender As Object, e As EventArgs)
        Response.Redirect("RecuperarContrasena.aspx")
    End Sub

    Protected Sub registroButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("Registro.aspx")
    End Sub
End Class