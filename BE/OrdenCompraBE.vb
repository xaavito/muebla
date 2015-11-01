Public Class OrdenCompraBE
    Private _id As Integer
    Private _fecha As Date
    Private _proveedor As ProveedorBE
    Private _numeroComprobante As Integer
    Private _entregada As Integer
    Private _detalles As List(Of OrdenCompraDetalleBE)
    

    Public Property detalle() As List(Of OrdenCompraDetalleBE)
        Get
            Return _detalles
        End Get
        Set(ByVal value As List(Of OrdenCompraDetalleBE))
            _detalles = value
        End Set
    End Property

    Public Property entregada() As Integer
        Get
            Return _entregada
        End Get
        Set(ByVal value As Integer)
            _entregada = value
        End Set
    End Property

    Public Property nro() As Integer
        Get
            Return _numeroComprobante
        End Get
        Set(ByVal value As Integer)
            _numeroComprobante = value
        End Set
    End Property

    Public Property proveedor() As ProveedorBE
        Get
            Return _proveedor
        End Get
        Set(ByVal value As ProveedorBE)
            _proveedor = value
        End Set
    End Property

    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Function getTotal()
        Dim tot As Decimal = 0
        For Each det As BE.OrdenCompraDetalleBE In detalle
            tot = tot * det.precioUnitario * det.cantidad
        Next
        Return tot
    End Function
End Class
