Public Class AltaProveedor1
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        buscarProductosMateriaPrima()
    End Sub

    Protected Sub cancelarAltaProveedorButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub confirmarAltaProveedorButton_Click(sender As Object, e As EventArgs)
        Dim prov As New BE.ProveedorBE
        prov.cuit = Me.cuitTextBox.Text
        prov.direccion = Me.direccionTextBox.Text
        prov.mail = Me.emailTextBox.Text
        prov.razonSocial = Me.nombreTextBox.Text
        prov.tel = Me.telefonoTextBox.Text
        prov.productos = Session("productosPropios")
        Try
            prov.id = BLL.ProveedorBLL.altaProveedor(prov)
            Throw New Util.CreacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try

    End Sub

    Private Sub buscarProductosMateriaPrima()
        Session("productosMateriaPrima") = BLL.ProductoBLL.buscarProductos(2, "")
        Me.allProductosListBox.DataSource = Session("productosMateriaPrima")
        Me.allProductosListBox.DataTextField = "descripcion"
        Me.allProductosListBox.DataValueField = "id"
        Me.allProductosListBox.DataBind()
    End Sub

    Protected Sub removerProductoButton_Click(sender As Object, e As ImageClickEventArgs)
        If Not productosPropiosListBox.SelectedItem Is Nothing Then
            productosPropiosListBox.Items.RemoveAt(productosPropiosListBox.SelectedIndex)
        End If
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

End Class