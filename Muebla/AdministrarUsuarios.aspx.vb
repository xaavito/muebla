Public Class AdministrarUsuarios
    Inherits System.Web.UI.Page
    Dim detalle As ImageButton

    Protected Sub Page_init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tipoUsuarioDropDownList.DataSource = BLL.UsuarioBLL.getTiposUsuarios()
        Me.tipoUsuarioDropDownList.DataTextField = "descripcion"
        Me.tipoUsuarioDropDownList.DataValueField = "id"
        Me.tipoUsuarioDropDownList.DataBind()
    End Sub

    Protected Sub buscarUsuariosButton_Click(sender As Object, e As EventArgs)
        Dim listaUsrs As List(Of BE.UsuarioBE)
        Dim row As TableRow
        Dim cell As TableCell
        Dim label As Label

        listaUsrs = BLL.UsuarioBLL.buscarUsuarios(Me.usrTextBox.Text, Int16.Parse(tipoUsuarioDropDownList.SelectedValue), Me.mailTextBox.Text)
        For Each usr As BE.UsuarioBE In listaUsrs
            row = New TableRow
            cell = New TableCell
            label = New Label
            'usuario
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
            'detalle
            cell = New TableCell
            detalle = New ImageButton
            detalle.ImageUrl = "/images/addImage.png"
            detalle.ImageAlign = ImageAlign.Middle
            detalle.ID = "detailUsr" + usr.id.ToString
            ' esto es iiiiiincreible, que alguien me explique esta sintaxis que no tiene nada que ver con nada
            'AddHandler detalle.Click, AddressOf btn_Click
            ' fin de la magia
            cell.Controls.Add(detalle)
            row.Cells.Add(cell)

            Me.tablaAdministrarUsuariosResultados.Rows.Add(row)
        Next
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs)
        Debug.WriteLine("llegue")
    End Sub
End Class