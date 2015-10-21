Imports Util

Public Class AdministrarProductos
    Inherits ExtendedPage

    Dim selected As BE.ProductoBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Debug.WriteLine(getPostBackCaller)
            Return
        End If
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
            Me.productosPropiosListBox.DataTextField = "descripcion"
            Me.productosPropiosListBox.DataValueField = "id"
            Me.productosPropiosListBox.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try

        Try
            Session("productosMateriaPrima") = BLL.ProductoBLL.buscarProductos(2, "")
            Me.allProductosListBox.DataSource = Session("productosMateriaPrima")
            Me.allProductosListBox.DataTextField = "descripcion"
            Me.allProductosListBox.DataValueField = "id"
            Me.allProductosListBox.DataBind()
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
        Me.lnkEdit_ModalPopupExtender.Show()
        If Not productosPropiosListBox.SelectedItem Is Nothing Then
            productosPropiosListBox.Items.RemoveAt(productosPropiosListBox.SelectedIndex)
        End If
    End Sub

    Protected Sub agregarProductoButton_Click(sender As Object, e As ImageClickEventArgs)
        Me.lnkEdit_ModalPopupExtender.Show()
        If Not allProductosListBox.SelectedItem Is Nothing Then
            Dim idToAdd As Integer = allProductosListBox.SelectedValue
            Dim found As Boolean = False
            If productosPropiosListBox.DataSource Is Nothing Then
                found = False
            Else
                For Each prod As BE.ProductoBE In productosPropiosListBox.DataSource
                    If prod.id = idToAdd Then
                        found = True
                    End If
                Next
            End If

            If found = False Then
                Dim ps As List(Of BE.ProductoBE) = productosPropiosListBox.DataSource
                If ps Is Nothing Then
                    ps = New List(Of BE.ProductoBE)
                End If
                Dim prods As List(Of BE.ProductoBE) = Session("productosMateriaPrima")
                For Each p As BE.ProductoBE In prods
                    If p.id = idToAdd Then
                        ps.Add(p)
                    End If
                Next
                productosPropiosListBox.DataSource = ps
                productosPropiosListBox.DataBind()
                Session("productosPropios") = ps
            End If
        End If
    End Sub

    Protected Sub allProductosListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.lnkEdit_ModalPopupExtender.Show()
    End Sub

    Protected Sub productosPropiosListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.lnkEdit_ModalPopupExtender.Show()
    End Sub
End Class