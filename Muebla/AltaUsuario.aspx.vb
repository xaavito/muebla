Public Class AltaUsuario
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Try
            Session("AllRoles") = BLL.GestorRolesBLL.buscarRoles
            Me.allRolesListBox.DataSource = Session("AllRoles")
            Me.allRolesListBox.DataTextField = "descripcion"
            Me.allRolesListBox.DataValueField = "id"
            Me.allRolesListBox.DataBind()

            Me.rolesPropiosListBox.DataSource = Nothing
            Me.rolesPropiosListBox.DataTextField = "descripcion"
            Me.rolesPropiosListBox.DataValueField = "id"
            Me.rolesPropiosListBox.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarAltaUsuarioButton_Click(sender As Object, e As EventArgs)
        Try
            Dim usr As New BE.UsuarioBE
            usr.roles = Session("MyRoles")
            usr.usuario = Me.usrTextBox.Text
            usr.nombre = Me.nombreTextBox.Text
            usr.apellido = Me.apellidoTextBox.Text
            usr.password = Me.passTextBox.Text
            usr.mail = Me.mailTextBox.Text
            BLL.UsuarioBLL.altaUsuario(usr)
            Throw New Util.AltaUsuarioExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub agregarRolButton_Click(sender As Object, e As ImageClickEventArgs)
        If Not allRolesListBox.SelectedItem Is Nothing Then
            Dim idToAdd As Integer = allRolesListBox.SelectedValue
            Dim found As Boolean = False
            If Session("MyRoles") Is Nothing Then
                found = False
            Else
                For Each prod As BE.RolBE In Session("MyRoles")
                    If prod.id = idToAdd Then
                        found = True
                    End If
                Next
            End If

            If found = False Then
                Dim ps As List(Of BE.RolBE) = Session("MyRoles")
                If ps Is Nothing Then
                    ps = New List(Of BE.RolBE)
                End If
                Dim prods As List(Of BE.RolBE) = Session("AllRoles")
                For Each p As BE.RolBE In prods
                    If p.id = idToAdd Then
                        ps.Add(p)
                    End If
                Next
                rolesPropiosListBox.DataSource = ps
                rolesPropiosListBox.DataBind()
                Session("MyRoles") = ps
            End If
        End If
    End Sub

    Protected Sub removerRolButton_Click(sender As Object, e As ImageClickEventArgs)
        If Not rolesPropiosListBox.SelectedItem Is Nothing Then
            rolesPropiosListBox.Items.RemoveAt(rolesPropiosListBox.SelectedIndex)
        End If
    End Sub
End Class