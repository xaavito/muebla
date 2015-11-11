Public Class AdministrarProveedores
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Me.editData.Visible = False
        'TODO PASAR A AJAX CONTROL TOOLKIT

        Me.provinciaDropDownList.DataSource = BLL.UsuarioBLL.getProvincias()
        Me.provinciaDropDownList.DataTextField = "descripcion"
        Me.provinciaDropDownList.DataValueField = "id"
        Me.provinciaDropDownList.DataBind()

        provinciaDropDownList_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)
        buscar()
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Session("idProveedor") = getItemId(sender, Me.proveedoresResultadosDataGrid)
            Dim listaProvs As List(Of BE.ProveedorBE) = Session("proveedores")
            For Each prov As BE.ProveedorBE In listaProvs
                If prov.id = Session("idProveedor") Then
                    Me.nombreTextBox.Text = prov.razonSocial
                    Me.contactoTextBox.Text = prov.contacto
                    Me.cuitTextBox.Text = prov.cuit
                    Me.telefonoTextBox.Text = prov.tel.numero
                    Me.prefijoTextBox.Text = prov.tel.prefijo
                    Me.internoTextBox.Text = prov.tel.interno
                    Me.direccionTextBox.Text = prov.dom.calle
                    Me.nroCalleTextBox.Text = prov.dom.numero
                    Me.pisoTextBox.Text = prov.dom.piso
                    Me.dptoTextBox.Text = prov.dom.dpto
                    Me.provinciaDropDownList.SelectedValue = prov.dom.localidad.provincia.id

                    provinciaDropDownList_SelectedIndexChanged(sender, e)

                    Me.localidadDropDownList.SelectedValue = prov.dom.localidad.id

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
        Catch ex As Exception
            logMessage(ex)
        End Try

    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Session("idProveedor") = getItemId(sender, Me.proveedoresResultadosDataGrid)
        lnkObservaciones_ModalPopupExtender.Show()
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

        Try
            Dim prov As New BE.ProveedorBE
            prov.id = Session("idProveedor")
            prov.cuit = Me.cuitTextBox.Text
            prov.dom.calle = Me.direccionTextBox.Text
            prov.dom.numero = Me.nroCalleTextBox.Text
            prov.dom.piso = Me.pisoTextBox.Text
            prov.dom.dpto = Me.dptoTextBox.Text
            prov.dom.localidad.id = Me.localidadDropDownList.SelectedValue

            prov.mail = Me.emailTextBox.Text
            prov.razonSocial = Me.nombreTextBox.Text
            prov.tel.numero = Me.telefonoTextBox.Text
            prov.tel.interno = Me.internoTextBox.Text
            prov.tel.prefijo = Me.prefijoTextBox.Text
            prov.productos = Session("productosPropios")

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

    Protected Sub ButtonOkay_Click(sender As Object, e As EventArgs)
        Try
            BLL.ProveedorBLL.eliminarProveedor(Session("idProveedor"), Me.observacionesTextBox.Text)
            Throw New Util.EliminacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub provinciaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Me.localidadDropDownList.DataSource = BLL.UsuarioBLL.getTiposLocalidades(Integer.Parse(Me.provinciaDropDownList.SelectedValue))
            Me.localidadDropDownList.DataTextField = "descripcion"
            Me.localidadDropDownList.DataValueField = "id"
            Me.localidadDropDownList.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub
End Class