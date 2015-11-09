Public Class PedidoBE
    Private _comprobantes As List(Of ComprobanteBE)
    Private _tipoEnvio As BE.TipoEnvioBE
    Private _fechaCreacion As DateTime
    Private _id As Long
    Private _medioPago As MedioPagoBE
    Private _pagado As Boolean
    Private _tipoVenta As TipoVentaBE
    Private _productos As List(Of BE.PedidoProductoBE)
    Private _estado As BE.EstadoPedidoBE
    Private _usr As UsuarioBE
    Private _total As Decimal

    Public Property total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property


    Public Property usr() As UsuarioBE
        Get
            Return _usr
        End Get
        Set(ByVal value As UsuarioBE)
            _usr = value
        End Set
    End Property


    Public Sub New()
        productos = New List(Of PedidoProductoBE)
        tipoEnvio = New TipoEnvioBE
        medioPago = New MedioPagoBE
        fechaCreacion = Date.Now
    End Sub

    Public Sub addProducto(ByVal lpd As ListaPrecioDetalleBE, ByVal cant As Integer)
        Dim p As New PedidoProductoBE
        p.cantidad = cant
        p.pedido = Me
        p.producto = lpd
        productos.Add(p)
    End Sub

    Public Property estado() As BE.EstadoPedidoBE
        Get
            Return _estado
        End Get
        Set(ByVal value As BE.EstadoPedidoBE)
            _estado = value
        End Set
    End Property


    Public Property productos() As List(Of BE.PedidoProductoBE)
        Get
            Return _productos
        End Get
        Set(ByVal value As List(Of BE.PedidoProductoBE))
            _productos = value
        End Set
    End Property


    Public Property comprobantes() As List(Of ComprobanteBE)
        Get
            Return _comprobantes
        End Get
        Set(ByVal Value As List(Of ComprobanteBE))
            _comprobantes = Value
        End Set
    End Property

    Public Property tipoEnvio() As BE.TipoEnvioBE
        Get
            Return _tipoEnvio
        End Get
        Set(ByVal Value As BE.TipoEnvioBE)
            _tipoEnvio = Value
        End Set
    End Property

    Public Property fechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal Value As DateTime)
            _fechaCreacion = Value
        End Set
    End Property

    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal Value As Long)
            _id = Value
        End Set
    End Property

    Public Property medioPago() As MedioPagoBE
        Get
            Return _medioPago
        End Get
        Set(ByVal Value As MedioPagoBE)
            _medioPago = Value
        End Set
    End Property


    Public Property pagado() As Boolean
        Get
            Return _pagado
        End Get
        Set(ByVal Value As Boolean)
            _pagado = Value
        End Set
    End Property

    Public Property tipoVenta() As TipoVentaBE
        Get
            Return _tipoVenta
        End Get
        Set(ByVal Value As TipoVentaBE)
            _tipoVenta = Value
        End Set
    End Property

    Public Function getTotalCalculado() As String
        Dim tot As Decimal = 0
        If total = 0 Then
            For Each p As PedidoProductoBE In Me.productos
                tot = tot + (p.cantidad * p.producto.precio)
            Next
        Else
            tot = total
        End If
        Return String.Format("{0:C}", tot)
    End Function

    Public Function getTotal() As String
        Return String.Format("{0:C}", total)
    End Function

End Class ' PedidoBE
