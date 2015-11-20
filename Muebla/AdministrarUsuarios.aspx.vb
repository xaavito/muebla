Public Class AdministrarUsuarios
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Me.editDataDiv.Visible = False
    End Sub

    Protected Sub buscarUsuariosButton_Click(sender As Object, e As EventArgs)
        buscar()
    End Sub

    Protected Sub usuariosResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(usuariosResultadosDataGrid)
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        'TODO LO PASAMOS AL AJAXCONTROLTOOLKIT?
        Session("idUsuario") = getItemId(sender, Me.usuariosResultadosDataGrid)
        Dim listaUsuarios As List(Of BE.UsuarioBE) = Session("listaUsuarios")
        For Each usr As BE.UsuarioBE In listaUsuarios
            If usr.id = Session("idUsuario") Then
                Debug.WriteLine(usr.nombre)
                Me.userTextBox.Text = usr.usuario
                Me.estadoUsuarioCheck.Checked = usr.activo
                If usr.roles Is Nothing Then
                    Try
                        usr.roles = BLL.GestorRolesBLL.getRoles(usr)
                    Catch ex As Exception
                        logMessage(ex)
                    End Try

                End If
                Try
                    Session("MyRoles") = usr.roles
                    Me.permisosPropiosListBox.DataSource = Session("MyRoles")
                    Me.permisosPropiosListBox.DataTextField = "descripcion"
                    Me.permisosPropiosListBox.DataValueField = "id"
                    Me.permisosPropiosListBox.DataBind()
                Catch ex As Exception
                    logMessage(ex)
                End Try

                Try
                    Session("AllRoles") = BLL.GestorRolesBLL.buscarRoles
                    Me.allPermisosListBox.DataSource = Session("AllRoles")
                    Me.allPermisosListBox.DataTextField = "descripcion"
                    Me.allPermisosListBox.DataValueField = "id"
                    Me.allPermisosListBox.DataBind()
                Catch ex As Exception
                    logMessage(ex)
                End Try

            End If
        Next
        Me.editDataDiv.Visible = True
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        For Each u As BE.UsuarioBE In Session("listaUsuarios")
            If u.id = getItemId(sender, Me.usuariosResultadosDataGrid) Then
                BLL.UsuarioBLL.eliminarUsuario(u)
            End If
        Next
    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)
        Try
            For Each u As BE.UsuarioBE In Session("listaUsuarios")
                If u.id = getItemId(sender, Me.usuariosResultadosDataGrid) Then
                    Me.detailsPedidos.DataSource = BLL.GestorRolesBLL.getRoles(u)
                    Me.detailsPedidos.DataBind()
                    detailPopup.Show()
                    Exit For
                End If
            Next
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Me.editDataDiv.Visible = False
        Try
            BLL.UsuarioBLL.modificarUsuario(Session("idUsuario"), Session("MyRoles"), estadoUsuarioCheck.Checked)
            buscar()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub cancelarButton_Click(sender As Object, e As EventArgs)
        Me.editDataDiv.Visible = False
    End Sub

    Private Sub buscar()
        Try
            Session("listaUsuarios") = BLL.UsuarioBLL.buscarUsuarios(Me.usrTextBox.Text, Me.mailTextBox.Text)

            usuariosResultadosDataGrid.DataSource = Session("listaUsuarios")
            usuariosResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
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
        Try
            If Not permisosPropiosListBox.SelectedItem Is Nothing Then
                BLL.UsuarioBLL.checkAdminPermiso(permisosPropiosListBox.SelectedValue)
                permisosPropiosListBox.Items.RemoveAt(permisosPropiosListBox.SelectedIndex)
            End If
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub usuariosResultadosDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.usuariosResultadosDataGrid.PageIndex = e.NewPageIndex
        buscar()
    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        BLL.UsuarioBLL.cifrar()
    End Sub
End Class