Imports BE

Public Class MasterPage

    Inherits System.Web.UI.MasterPage
    Dim usr As UsuarioBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        usr = Session("Usuario")
        Me.usrText.Text = usr.apellido + " " + usr.nombre
    End Sub

End Class