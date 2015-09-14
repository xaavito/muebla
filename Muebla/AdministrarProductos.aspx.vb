Imports Util

Public Class AdministrarProductos
    Inherits ExtendedPage

    Dim listaProductos As New List(Of BE.ProductoBE)
    Dim selected As BE.ProductoBE


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tipoProductoDropDownList.DataSource = BLL.ProveedorBLL.getTipoProductos
        Me.tipoProductoDropDownList.DataTextField = "descripcion"
        Me.tipoProductoDropDownList.DataValueField = "id"
        Me.tipoProductoDropDownList.DataBind()
        Me.editDataDiv.Visible = False
    End Sub

    Protected Sub buscarProductosButton_Click(sender As Object, e As EventArgs)
        listaProductos = BLL.ProductoBLL.buscarProductos(Int16.Parse(tipoProductoDropDownList.SelectedValue), Me.nombreProductoTextBox.Text)
        Session("listaProductos") = listaProductos
    
        Me.productosResultadosDataGrid.DataSource = listaProductos
        Me.productosResultadosDataGrid.DataBind()
    End Sub

    Protected Sub verDetalleButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub generarOrdenCompraButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("OrdenCompra.aspx")
    End Sub

    Protected Sub compararCostoButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)

        Me.editDataDiv.Visible = True
        Me.tipoProductoDropDown.DataSource = BLL.ProveedorBLL.getTipoProductos
        Me.tipoProductoDropDown.DataTextField = "descripcion"
        Me.tipoProductoDropDown.DataValueField = "id"
        Me.tipoProductoDropDown.DataBind()

        Me.proveedorDropDown.DataSource = BLL.ProveedorBLL.listarProveedores
        Me.proveedorDropDown.DataTextField = "razonSocial"
        Me.proveedorDropDown.DataValueField = "id"
        Me.proveedorDropDown.DataBind()

        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.productosResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)

        listaProductos = Session("listaProductos")
        For Each prod As BE.ProductoBE In listaProductos
            If prod.id = id Then
                selected = prod
                Me.descripcionTextBox.Text = selected.descripcion
            End If
        Next
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.productosResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        Try
            BLL.ProductoBLL.bajaProducto(id)
            gvRow.Visible = False
            logMessage(New EliminacionExitosaException)
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub addProveedorButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub cancelarEditProductoButton_Click(sender As Object, e As EventArgs)
        Me.editDataDiv.Visible = False
    End Sub

    Protected Sub confirmarEditProductoButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub productosResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(productosResultadosDataGrid)
    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)

    End Sub
End Class