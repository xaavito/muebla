Imports BE
Imports System.IO
Imports System.Web.Configuration

Public Class ProductoBLL

    Private Shared _prods As List(Of BE.ListaPrecioDetalleBE)

    Public Shared Sub actualizaCantProducto(ByVal prod As ProductoBE, ByVal cant As Integer)
        'TODO NO SE SI VAMOS A HACER ESTO.. NO ESTA NI EN LOS CU
    End Sub

    Public Shared Sub altaProducto(ByVal producto As ProductoBE)
        DAL.ProductoDAL.altaProducto(producto)
        DAL.ProductoDAL.altaProductoCompuesto(producto)
    End Sub

    Public Shared Function bajaProducto(ByVal id As Integer) As Integer
        ' TODO VER QUE NO FORME PARTE DE UN PRODUCTO EN VENTA EN EL MOMENTO
        Return DAL.ProductoDAL.bajaProducto(id)
    End Function

    Public Shared Function buscarProducto(ByVal id As Integer) As BE.ProductoBE
        Return DAL.ProductoDAL.buscarProducto(id)
    End Function

    Public Shared Function buscarProductos(ByVal tipo As Integer, ByVal nombre As String) As List(Of ProductoBE)
        Return DAL.ProductoDAL.buscarProductos(tipo, nombre)
    End Function

    Public Shared Function listarProductos() As List(Of ListaPrecioDetalleBE)
        If _prods Is Nothing Then
            _prods = DAL.ProductoDAL.listarProductos()
        End If

        Return _prods
    End Function

    Public Shared Sub modificarProducto(ByVal producto As ProductoBE)
        DAL.ProductoDAL.modificarProducto(producto)
        DAL.ProductoDAL.eliminarProductoCompuesto(producto)
        DAL.ProductoDAL.altaProductoCompuesto(producto)
    End Sub

    Shared Function getImagenProducto(idInt As Integer) As Byte()
        Return DAL.ProductoDAL.getImagenProducto(idInt)
    End Function

    Shared Function buscarProductoCompuesto(id As Integer) As List(Of ProductoBE)
        Return DAL.ProductoDAL.buscarProductoCompuesto(id)
    End Function

    Shared Function listarPromos() As List(Of ListaPrecioDetalleBE)
        Return DAL.ProductoDAL.listarPromos()
    End Function

    Shared Function getComparacion(p1 As Integer) As List(Of ComparacionProductos)
        Return DAL.ProductoDAL.getComparacion(p1)
    End Function

    Shared Function generarOrdenCompra(oc As OrdenCompraBE) As MemoryStream
        oc.id = DAL.ProductoDAL.generarOrdenCompra(oc)
        DAL.ProductoDAL.generarOrdenCompraDetalles(oc)
        Dim ms As MemoryStream = Util.PDFGenerator.OrdenCompraPDF(oc)
        'proveedor
        Util.Mailer.enviarMailConAdjunto(oc.proveedor.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OC), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OCMensaje), ms)
        'nosotros
        ms = Util.PDFGenerator.OrdenCompraPDF(oc)
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailCompras").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OC), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OCMensaje), ms)
        ms.Position = 0
        Return ms
    End Function

    Shared Sub limpiarProds()
        _prods = Nothing
    End Sub
End Class ' ProductoBLL

