Public Class AdministrarProveedores
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Try
            Me.editData.Visible = False

            Me.provinciaDropDownList.DataSource = BLL.UsuarioBLL.getProvincias()
            Me.provinciaDropDownList.DataTextField = "descripcion"
            Me.provinciaDropDownList.DataValueField = "id"
            Me.provinciaDropDownList.DataBind()

            provinciaDropDownList_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            logMessage(ex)
        End Try
        
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
        lnkValor_ModalPopupExtender.Show()
    End Sub

    Protected Sub removerProductoButton_Click(sender As Object, e As ImageClickEventArgs)
        Try
            If Not productosPropiosListBox.SelectedItem Is Nothing Then
                productosPropiosListBox.Items.RemoveAt(productosPropiosListBox.SelectedIndex)
            End If
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub

    Protected Sub modificarButton_Click(sender As Object, e As EventArgs)

        Try
            Dim prov As New BE.ProveedorBE
            prov.id = Session("idProveedor")
            prov.cuit = Me.cuitTextBox.Text
            prov.contacto = Me.contactoTextBox.Text
            prov.dom.calle = Me.direccionTextBox.Text
            prov.dom.numero = Me.nroCalleTextBox.Text
            prov.dom.piso = Me.pisoTextBox.Text
            prov.dom.dpto = Me.dptoTextBox.Text
            prov.dom.localidad.id = Me.localidadDropDownList.SelectedValue

            prov.mail = Me.emailTextBox.Text
            prov.razonSocial = Me.nombreTextBox.Text
            prov.tel.numero = Me.telefonoTextBox.Text
            prov.tel.interno = IIf(Me.internoTextBox.Text = Nothing, 0, Me.internoTextBox.Text)
            prov.tel.prefijo = IIf(Me.prefijoTextBox.Text = Nothing, 0, Me.prefijoTextBox.Text)
            prov.productos = Session("MyProductos")

            Session("prov") = prov
            ModalPopupExtender1.Show()
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
            BLL.ProveedorBLL.eliminarProveedor(Session("idProveedor"), Me.observacionesTextBox.Text, getUsuario)
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

    Protected Sub ibtnDetail_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Me.detallesProveedores.DataSource = BLL.ProveedorBLL.getObservaciones(getItemId(sender, Me.proveedoresResultadosDataGrid))
            Me.detallesProveedores.DataBind()
            detailsModalPopup.Show()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarEditarButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.ProveedorBLL.modificarProveedor(Session("prov"), obsEditTextBox.Text, getUsuario)
            Throw New Util.ModificacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        Try
            If Not allProductosListBox.SelectedItem Is Nothing Then
                Dim idToAdd As Integer = allProductosListBox.SelectedValue
                Dim found As Boolean = False
                If Session("MyProductos") Is Nothing Then
                    found = False
                Else
                    For Each prod As BE.ProductoBE In Session("MyProductos")
                        If prod.id = idToAdd Then
                            found = True
                        End If
                    Next
                End If

                If found = False Then
                    Dim ps As List(Of BE.ProductoBE) = Session("MyProductos")
                    If ps Is Nothing Then
                        ps = New List(Of BE.ProductoBE)
                    End If
                    Dim prods As List(Of BE.ProductoBE) = Session("AllProductos")
                    For Each p As BE.ProductoBE In prods
                        If p.id = idToAdd Then
                            p.precio = Decimal.Parse(Me.valorProductoTextBox.Text)
                            ps.Add(p)
                        End If
                    Next
                    productosPropiosListBox.DataSource = ps
                    productosPropiosListBox.DataBind()
                    Session("MyProductos") = ps
                End If
            End If
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub
End Class