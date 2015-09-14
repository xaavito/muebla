Public Class AdministrarUsuarios
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Me.tipoUsuarioDropDownList.DataSource = BLL.UsuarioBLL.getTiposUsuarios()
        Me.tipoUsuarioDropDownList.DataTextField = "descripcion"
        Me.tipoUsuarioDropDownList.DataValueField = "id"
        Me.tipoUsuarioDropDownList.DataBind()
        Me.editDataDiv.Visible = False
    End Sub

    Protected Sub buscarUsuariosButton_Click(sender As Object, e As EventArgs)
        buscarUsuarios()
    End Sub

    Protected Sub modificarUsuarioButton_Click(sender As Object, e As EventArgs)
        Me.editDataDiv.Visible = True

    End Sub

    Protected Sub verDetalleUsuarioButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub bajaUsuarioButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub desbloquearUsuarioButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub usuariosResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(usuariosResultadosDataGrid)
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.usuariosResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)

        Dim listaUsuarios As List(Of BE.UsuarioBE) = Session("listaUsuarios")
        For Each usr As BE.UsuarioBE In listaUsuarios
            If usr.id = id Then
                Debug.WriteLine(usr.nombre)
                Me.userTextBox.Text = usr.usuario
                'Me.estadoUsuarioDropDown.SelectedValue = 1
                If usr.roles Is Nothing Then
                    usr.roles = BLL.GestorRolesBLL.getRoles(usr)
                End If
                Session("MyRoles") = usr.roles
                Me.permisosPropiosListBox.DataSource = Session("MyRoles")
                Me.permisosPropiosListBox.DataTextField = "descripcion"
                Me.permisosPropiosListBox.DataValueField = "id"
                Me.permisosPropiosListBox.DataBind()
                Session("AllRoles") = BLL.GestorRolesBLL.buscarRoles
                Me.allPermisosListBox.DataSource = Session("AllRoles")
                Me.allPermisosListBox.DataTextField = "descripcion"
                Me.allPermisosListBox.DataValueField = "id"
                Me.allPermisosListBox.DataBind()

            End If
        Next
        Me.editDataDiv.Visible = True
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Me.editDataDiv.Visible = False
        buscarUsuarios()

    End Sub

    Protected Sub cancelarButton_Click(sender As Object, e As EventArgs)
        Me.editDataDiv.Visible = False
    End Sub

    Private Sub buscarUsuarios()
        Dim listaUsrs As List(Of BE.UsuarioBE)

        listaUsrs = BLL.UsuarioBLL.buscarUsuarios(Me.usrTextBox.Text, Int16.Parse(tipoUsuarioDropDownList.SelectedValue), Me.mailTextBox.Text)
        Session("listaUsuarios") = listaUsrs
        usuariosResultadosDataGrid.DataSource = listaUsrs
        usuariosResultadosDataGrid.DataBind()
    End Sub

    Protected Sub agregarPermisoButton_Click(sender As Object, e As ImageClickEventArgs)
        If Not allPermisosListBox.SelectedItem Is Nothing Then
            Dim idToAdd As Integer = allPermisosListBox.SelectedValue
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
                permisosPropiosListBox.DataSource = ps
                permisosPropiosListBox.DataBind()
                Session("MyRoles") = ps
            End If
        End If
    End Sub

    Protected Sub removerPermisoButton_Click(sender As Object, e As ImageClickEventArgs)
        If Not permisosPropiosListBox.SelectedItem Is Nothing Then
            permisosPropiosListBox.Items.RemoveAt(permisosPropiosListBox.SelectedIndex)
        End If
    End Sub
End Class