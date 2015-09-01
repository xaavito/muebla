Public Class AdministrarProductos
    Inherits System.Web.UI.Page

    Dim check As CheckBox
    Dim row As TableRow
    Dim cell As TableCell
    Dim label As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tipoProductoDropDownList.DataSource = BLL.ProveedorBLL.getTipoProductos
        Me.tipoProductoDropDownList.DataTextField = "descripcion"
        Me.tipoProductoDropDownList.DataValueField = "id"
        Me.tipoProductoDropDownList.DataBind()
    End Sub

    Protected Sub buscarProductosButton_Click(sender As Object, e As EventArgs)
        Dim listaProductos As List(Of BE.ProductoBE)

        listaProductos = BLL.ProductoBLL.buscarProductos(Int16.Parse(tipoProductoDropDownList.SelectedValue), Me.nombreProductoTextBox.Text)

        Me.productosResultadosDataGrid.DataSource = listaProductos
        Me.productosResultadosDataGrid.DataBind()
    End Sub

    Protected Sub verDetalleButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub modificarButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub eliminarButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub generarOrdenCompraButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("OrdenCompra.aspx")
    End Sub

    Protected Sub compararCostoButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        'gvRow.
        'dim UserId as Integer = Convert.ToInt32(productosResultadosDataGrid.DataKeys[gvRow.RowIndex].Value)
        'UserEntity User = GetUserByID(UserId)
        ' Now set value to modal popup
        'hfUserID.Value = User.UserId.ToString()
        'txtUserName.Text = User.UserName
        'txtAddress.Text = User.Address
        'txtCity.Text = User.City
        'txtState.Text = User.State
        'mpeUser.Show()
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Control = Me.productosResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID")
        Dim str As String = gvRow.Controls.Item(0).ToString
        'Dim str As String = Me.productosResultadosDataGrid.SelectedRow.Cells(0).Text
        Dim prod As BE.ProductoBE = CType(gvRow.DataItem, BE.ProductoBE)
        'productosResultadosDataGrid.DataKeys(gvRow.RowIndex).Value
        'dim UserId as Integer = Convert.ToInt32(productosResultadosDataGrid.DataKeys[gvRow.i .RowIndex].Value)
        'delete and hide the row from grid view
        'If (DeleteUserByID(UserId)) Then
        'gvRow.Visible = False
        'End If

    End Sub
End Class