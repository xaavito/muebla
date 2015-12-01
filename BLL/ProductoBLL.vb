Imports BE
Imports System.IO
Imports System.Web.Configuration

Public Class ProductoBLL

    Private Shared _prods As List(Of BE.ListaPrecioDetalleBE)

    Public Shared Sub altaProducto(ByVal usr As BE.UsuarioBE, ByVal producto As ProductoBE)
        DAL.ProductoDAL.altaProducto(producto)
        If producto.tipoProducto.id = 1 Then
            DAL.ProductoDAL.altaProductoCompuesto(producto)
        End If
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.AltaProducto)
    End Sub

    Public Shared Function bajaProducto(ByVal usr As BE.UsuarioBE, ByVal producto As BE.ProductoBE) As Integer
        BLL.ProductoBLL.checkEstadoActivo(producto)
        BLL.ProductoBLL.checkProductosEnPedidos(producto)
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.BajaProducto)
        Return DAL.ProductoDAL.bajaProducto(producto)
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

    Public Shared Sub modificarProducto(ByVal usr As BE.UsuarioBE, ByVal producto As ProductoBE)
        BLL.ProductoBLL.checkEstadoActivo(producto)
        BLL.ProductoBLL.checkProductosEnPedidos(producto)
        DAL.ProductoDAL.modificarProducto(producto)
        DAL.ProductoDAL.eliminarProductoCompuesto(producto)
        DAL.ProductoDAL.altaProductoCompuesto(producto)
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.ModificacionProducto)
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

    Shared Function generarOrdenCompra(ByVal usr As BE.UsuarioBE, oc As OrdenCompraBE) As MemoryStream
        'CHECK ACTIVO
        If oc.proveedor.activo = False Then
            Throw New Util.ProveedorInactivo
        End If
        'CHECK OC NO ENTREGADA PARA EL PROVEEDOR
        DAL.ProductoDAL.checkProveedorAlDia(oc.proveedor)
        oc.id = DAL.ProductoDAL.generarOrdenCompra(oc)
        DAL.ProductoDAL.generarOrdenCompraDetalles(oc)
        Dim ms As MemoryStream = Util.PDFGenerator.OrdenCompraPDF(oc)
        Dim ms2 As New MemoryStream(ms.ToArray())
        Dim ms3 As New MemoryStream(ms.ToArray())
        'PARA PROVEEDOR
        Util.Mailer.enviarMailConAdjunto(oc.proveedor.mail, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OC), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OCMensaje), ms3)
        'PARA NOSOTROS
        Util.Mailer.enviarMailConAdjunto(WebConfigurationManager.AppSettings("mailCompras").ToString, BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OC), BLL.GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.OCMensaje), ms2)
        ms.Position = 0
        BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.GeneracionOrdenCompra)
        Return ms
    End Function

    Shared Sub limpiarProds()
        _prods = Nothing
    End Sub

    Private Shared Sub checkProductosEnPedidos(ByVal producto As BE.ProductoBE)
        DAL.ProductoDAL.checkProductoEnPedidos(producto)
    End Sub

    Private Shared Sub checkEstadoActivo(producto As ProductoBE)
        If producto.baja = True Then
            Throw New Util.ProductoBaja
        End If
    End Sub

    Shared Function getDetalleProducto(idProducto As Integer) As DataTable
        Return DAL.ProductoDAL.getDetalleProducto(idProducto)
    End Function

End Class ' ProductoBLL

