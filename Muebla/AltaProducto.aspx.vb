Public Class AltaProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tipoProductoDropDown.DataSource = BLL.ProveedorBLL.getTipoProductos
        Me.tipoProductoDropDown.DataTextField = "descripcion"
        Me.tipoProductoDropDown.DataValueField = "id"
        Me.tipoProductoDropDown.DataBind()

        Me.proveedorDropDown.DataSource = BLL.ProveedorBLL.listarProveedores
        Me.proveedorDropDown.DataTextField = "razonSocial"
        Me.proveedorDropDown.DataValueField = "id"
        Me.proveedorDropDown.DataBind()
    End Sub

    Protected Sub confirmarAltaProductoButton_Click(sender As Object, e As EventArgs)
        Dim prod As New BE.ProductoBE
        prod.descripcion = Me.descripcionTextBox.Text
        'prod.
    End Sub

    Protected Sub cancelarAltaProductoButton_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub addProveedorButton_Click(sender As Object, e As EventArgs)
    End Sub
End Class