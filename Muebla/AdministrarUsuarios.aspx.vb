Public Class AdministrarUsuarios
    Inherits ExtendedPage

    Dim check As CheckBox
    Dim row As TableRow
    Dim cell As TableCell
    Dim label As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tipoUsuarioDropDownList.DataSource = BLL.UsuarioBLL.getTiposUsuarios()
        Me.tipoUsuarioDropDownList.DataTextField = "descripcion"
        Me.tipoUsuarioDropDownList.DataValueField = "id"
        Me.tipoUsuarioDropDownList.DataBind()
    End Sub

    Protected Sub buscarUsuariosButton_Click(sender As Object, e As EventArgs)
        Dim listaUsrs As List(Of BE.UsuarioBE)
       
        listaUsrs = BLL.UsuarioBLL.buscarUsuarios(Me.usrTextBox.Text, Int16.Parse(tipoUsuarioDropDownList.SelectedValue), Me.mailTextBox.Text)
        For Each usr As BE.UsuarioBE In listaUsrs
            row = New TableRow
            
            'seleccion
            cell = New TableCell
            check = New CheckBox
            cell.Controls.Add(check)
            row.Cells.Add(cell)
            'usuario
            cell = New TableCell
            label = New Label
            label.Text = usr.usuario
            cell.Controls.Add(label)
            row.Cells.Add(cell)
            'tipo Usuario
            cell = New TableCell
            label = New Label
            label.Text = usr.tipoUsuario.descripcion
            cell.Controls.Add(label)
            row.Cells.Add(cell)
            'mail
            cell = New TableCell
            label = New Label
            label.Text = usr.mail
            cell.Controls.Add(label)
            row.Cells.Add(cell)
            'estado
            cell = New TableCell
            label = New Label
            label.Text = usr.bloqueado
            cell.Controls.Add(label)
            row.Cells.Add(cell)

            Me.tablaAdministrarUsuariosResultados.Rows.Add(row)
        Next
    End Sub

    Protected Sub modificarUsuarioButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub verDetalleUsuarioButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub bajaUsuarioButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub desbloquearUsuarioButton_Click(sender As Object, e As EventArgs)

    End Sub
End Class