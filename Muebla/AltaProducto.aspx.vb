Public Class AltaProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Me.tipoProductoDropDown.DataSource = BLL.ProveedorBLL.getTipoProductos
        Me.tipoProductoDropDown.DataTextField = "descripcion"
        Me.tipoProductoDropDown.DataValueField = "id"
        Me.tipoProductoDropDown.DataBind()

        Me.proveedorDropDown.DataSource = BLL.ProveedorBLL.listarProveedores
        Me.proveedorDropDown.DataTextField = "razonSocial"
        Me.proveedorDropDown.DataValueField = "id"
        Me.proveedorDropDown.DataBind()

        Session("productosMateriaPrima") = BLL.ProductoBLL.buscarProductos(2, "")
        Me.allProductosListBox.DataSource = Session("productosMateriaPrima")
        Me.allProductosListBox.DataTextField = "descripcion"
        Me.allProductosListBox.DataValueField = "id"
        Me.allProductosListBox.DataBind()

        Me.productosPropiosListBox.DataTextField = "descripcion"
        Me.productosPropiosListBox.DataValueField = "id"
    End Sub

    Protected Sub confirmarAltaProductoButton_Click(sender As Object, e As EventArgs)
        Dim prod As New BE.ProductoBE
        prod.descripcion = Me.descripcionTextBox.Text
        Dim tipo As New BE.TipoProductoBE
        tipo.id = Me.tipoProductoDropDown.SelectedValue
        prod.tipoProducto = tipo
        prod.productos = Me.productosPropiosListBox.DataSource
        Dim prov As New BE.ProveedorBE
        prov.id = Me.proveedorDropDown.SelectedValue
        prod.proveedor = prov
        prod.image1 = Me.fileUpload.FileBytes
        prod.stock = Integer.Parse(Me.stockTextBox.Text)
        prod.stockMin = Integer.Parse(Me.stockMinimoTextBox.Text)
        BLL.ProductoBLL.altaProducto(prod)
    End Sub

    Protected Sub cancelarAltaProductoButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub addProveedorButton_Click(sender As Object, e As EventArgs)

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
            End If
        End If
    End Sub
End Class