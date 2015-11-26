Public Class AltaProveedor
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Try
            buscarProductosMateriaPrima()
            Me.productosPropiosListBox.DataTextField = "descripcion"
            Me.productosPropiosListBox.DataValueField = "id"

            Me.provinciaDropDownList.DataSource = BLL.UsuarioBLL.getProvincias()
            Me.provinciaDropDownList.DataTextField = "descripcion"
            Me.provinciaDropDownList.DataValueField = "id"
            Me.provinciaDropDownList.DataBind()

            provinciaDropDownList_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarAltaProveedorButton_Click(sender As Object, e As EventArgs)
        
        Try
            Dim prov As New BE.ProveedorBE
            prov.cuit = Me.cuitTextBox.Text
            prov.mail = Me.emailTextBox.Text
            prov.razonSocial = Me.nombreTextBox.Text
            prov.contacto = Me.contactoTextBox.Text

            Dim reg As New BE.DomicilioBE
            reg.calle = Me.calleTextBox.Text
            reg.numero = Me.nroCalleTextBox.Text
            reg.piso = Me.pisoTextBox.Text
            reg.dpto = Me.dptoTextBox.Text
            Dim loc As New BE.LocalidadBE
            loc.id = Integer.Parse(Me.localidadDropDownList.SelectedValue)
            Dim provi As New BE.ProvinciaBE
            provi.id = Integer.Parse(Me.provinciaDropDownList.SelectedValue)
            loc.provincia = provi
            reg.localidad = loc
            prov.dom = reg

            Dim tel As New BE.TelefonoBE
            tel.numero = Me.telefonoTextBox.Text
            tel.interno = IIf(Me.internoTextBox.Text = Nothing, 0, Me.internoTextBox.Text)
            tel.prefijo = IIf(Me.prefijoTextBox.Text = Nothing, 0, Me.prefijoTextBox.Text)
            prov.tel = tel

            prov.productos = Session("productosPropios")

            BLL.ProveedorBLL.altaProveedor(prov)
            Throw New Util.CreacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Private Sub buscarProductosMateriaPrima()
        Try
            Session("productosMateriaPrima") = BLL.ProductoBLL.buscarProductos(2, "")
            Me.allProductosListBox.DataSource = Session("productosMateriaPrima")
            Me.allProductosListBox.DataTextField = "descripcion"
            Me.allProductosListBox.DataValueField = "id"
            Me.allProductosListBox.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub removerProductoButton_Click(sender As Object, e As ImageClickEventArgs)
        If Not productosPropiosListBox.SelectedItem Is Nothing Then
            productosPropiosListBox.Items.RemoveAt(productosPropiosListBox.SelectedIndex)
        End If
    End Sub

    Protected Sub agregarProductoButton_Click(sender As Object, e As ImageClickEventArgs)
        lnkValor_ModalPopupExtender.Show()
    End Sub

    Protected Sub ButtonOkay_Click(sender As Object, e As EventArgs)
        Try
            If Not allProductosListBox.SelectedItem Is Nothing Then
                Dim idToAdd As Integer = allProductosListBox.SelectedValue
                Dim found As Boolean = False
                If Session("productosPropios") Is Nothing Then
                    found = False
                Else
                    For Each prod As BE.ProductoBE In Session("productosPropios")
                        If prod.id = idToAdd Then
                            found = True
                        End If
                    Next
                End If

                If found = False Then
                    Dim ps As List(Of BE.ProductoBE) = Session("productosPropios")
                    If ps Is Nothing Then
                        ps = New List(Of BE.ProductoBE)
                    End If
                    Dim prods As List(Of BE.ProductoBE) = Session("productosMateriaPrima")
                    For Each p As BE.ProductoBE In prods
                        If p.id = idToAdd Then
                            p.precio = Decimal.Parse(Me.valorProductoTextBox.Text)
                            ps.Add(p)
                        End If
                    Next
                    productosPropiosListBox.DataSource = ps
                    productosPropiosListBox.DataBind()
                    Session("productosPropios") = ps
                End If
            End If
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

    Protected Sub altaProductoButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("AltaProducto.aspx", False)
    End Sub
End Class