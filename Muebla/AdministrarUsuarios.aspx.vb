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
        usuariosResultadosDataGrid.DataSource = listaUsrs
        usuariosResultadosDataGrid.DataBind()

    End Sub

    Protected Sub modificarUsuarioButton_Click(sender As Object, e As EventArgs)

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

    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)

    End Sub
End Class