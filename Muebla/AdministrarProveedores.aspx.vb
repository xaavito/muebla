Public Class AdministrarProveedores
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.editData.Visible = False
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)
        buscar()
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.proveedoresResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        Session("idProveedor") = id
        Dim listaProvs As List(Of BE.ProveedorBE) = Session("proveedores")
        For Each prov As BE.ProveedorBE In listaProvs
            If prov.id = id Then
                Me.nombreTextBox.Text = prov.razonSocial
                Me.contactoTextBox.Text = prov.contacto
                Me.cuitTextBox.Text = prov.cuit
                Me.telefonoTextBox.Text = prov.telefono
                Me.direccionTextBox.Text = prov.direccion
                Me.emailTextBox.Text = prov.mail

                If prov.productos Is Nothing Then
                    Try
                        prov.productos = BLL.ProveedorBLL.getProductos(prov)
                    Catch ex As Exception
                        logMessage(ex)
                    End Try

                End If
                Session("MyProductos") = prov.productos
                Me.productosPropiosListBox.DataSource = Session("MyProductos")
                Me.productosPropiosListBox.DataTextField = "descripcion"
                Me.productosPropiosListBox.DataValueField = "id"
                Me.productosPropiosListBox.DataBind()

                Session("AllProductos") = BLL.ProductoBLL.buscarProductos(2, "")
                Me.allProductosListBox.DataSource = Session("AllProductos")
                Me.allProductosListBox.DataTextField = "descripcion"
                Me.allProductosListBox.DataValueField = "id"
                Me.allProductosListBox.DataBind()
            End If
        Next
        Me.editData.Visible = True
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.proveedoresResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        Session("idProveedor") = id
        Try
            BLL.ProveedorBLL.eliminarProveedor(id)
            Throw New Util.EliminacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim con As Label = CType(Me.proveedoresResultadosDataGrid.Rows(gvRow.RowIndex).Cells(0).FindControl("itemID"), Label)
        Dim id As Integer = Integer.Parse(con.Text.ToString)
        Session("idProveedor") = id
    End Sub

    Protected Sub proveedoresResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.proveedoresResultadosDataGrid)
    End Sub

    Protected Sub proveedoresResultadosDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.proveedoresResultadosDataGrid.PageIndex = e.NewPageIndex
        buscar()
    End Sub

    Private Sub buscar()
        Try
            Session("proveedores") = BLL.ProveedorBLL.buscarProveedores(nombreProveedorTextBox.Text, contactoTextBox.Text)
            Me.proveedoresResultadosDataGrid.DataSource = Session("proveedores")
            Me.proveedoresResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub agregarProductoButton_Click(sender As Object, e As ImageClickEventArgs)
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

    Protected Sub removerProductoButton_Click(sender As Object, e As ImageClickEventArgs)
        If Not productosPropiosListBox.SelectedItem Is Nothing Then
            productosPropiosListBox.Items.RemoveAt(productosPropiosListBox.SelectedIndex)
        End If
    End Sub

    Protected Sub modificarButton_Click(sender As Object, e As EventArgs)
        Dim prov As New BE.ProveedorBE
        prov.id = Session("idProveedor")
        prov.cuit = Me.cuitTextBox.Text
        prov.direccion = Me.direccionTextBox.Text
        prov.mail = Me.emailTextBox.Text
        prov.razonSocial = Me.nombreTextBox.Text
        prov.telefono = Me.telefonoTextBox.Text
        prov.productos = Session("productosPropios")
        Try
            BLL.ProveedorBLL.modificarProveedor(prov)
            Throw New Util.ModificacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
        Me.editData.Visible = False
    End Sub

    Protected Sub cancelarButton_Click(sender As Object, e As EventArgs)
        Me.editData.Visible = False
    End Sub
End Class