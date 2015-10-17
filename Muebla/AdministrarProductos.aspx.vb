Imports Util

Public Class AdministrarProductos
    Inherits ExtendedPage

    Dim selected As BE.ProductoBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.tipoProductoDropDownList.DataSource = BLL.ProveedorBLL.getTipoProductos
            Me.tipoProductoDropDownList.DataTextField = "descripcion"
            Me.tipoProductoDropDownList.DataValueField = "id"
            Me.tipoProductoDropDownList.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try

        Me.editDataDiv.Visible = False
    End Sub

    Protected Sub buscarProductosButton_Click(sender As Object, e As EventArgs)
        buscar()
    End Sub

    Protected Sub verDetalleButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub generarOrdenCompraButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("OrdenCompra.aspx")
    End Sub

    Protected Sub compararCostoButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        'Me.editDataDiv.Visible = True
        Session("idProductoEdicion") = getItemId(sender, Me.productosResultadosDataGrid)
        Try
            Me.tipoProductoDropDown.DataSource = BLL.ProveedorBLL.getTipoProductos
            Me.tipoProductoDropDown.DataTextField = "descripcion"
            Me.tipoProductoDropDown.DataValueField = "id"
            Me.tipoProductoDropDown.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
        
        Try
            Me.productosPropiosListBox.DataSource = BLL.ProductoBLL.buscarProductoCompuesto(Session("idProductoEdicion"))
            Me.productosPropiosListBox.DataTextField = "razonSocial"
            Me.productosPropiosListBox.DataValueField = "id"
            Me.productosPropiosListBox.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try

        For Each prod As BE.ProductoBE In Session("listaProductos")
            If prod.id = Session("idProductoEdicion") Then
                selected = prod
                Me.descripcionTextBox.Text = selected.descripcion
                Me.descripcionBreveTextBox.Text = selected.breveDescripcion
                Me.stockMinimoTextBox.Text = selected.stockMin
                Me.stockTextBox.Text = selected.stock
                Me.tipoProductoDropDown.SelectedValue = selected.tipoProducto.id
            End If
        Next
        Me.lnkEdit_ModalPopupExtender.Show()
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Try
            BLL.ProductoBLL.bajaProducto(getItemId(sender, Me.productosResultadosDataGrid))
            buscar()
            Throw New EliminacionExitosaException
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

    Protected Sub productosResultadosDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.productosResultadosDataGrid.PageIndex = e.NewPageIndex
        buscar()
    End Sub

    Private Sub buscar()
        Try
            Session("listaProductos") = BLL.ProductoBLL.buscarProductos(Int16.Parse(tipoProductoDropDownList.SelectedValue), Me.nombreProductoTextBox.Text)

            Me.productosResultadosDataGrid.DataSource = Session("listaProductos")
            Me.productosResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ButtonEditOkay_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub removerProductoButton_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub agregarProductoButton_Click(sender As Object, e As ImageClickEventArgs)

    End Sub
End Class