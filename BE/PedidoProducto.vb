Public Class PedidoProducto
    Private _id As Int32
    Public Property id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property

    Private _pedido As BE.PedidoBE
    Public Property pedido() As BE.PedidoBE
        Get
            Return _pedido
        End Get
        Set(ByVal value As BE.PedidoBE)
            _pedido = value
        End Set
    End Property

    Private _producto As BE.ListaPrecioDetalleBE
    Public Property producto() As BE.ListaPrecioDetalleBE
        Get
            Return _producto
        End Get
        Set(ByVal value As BE.ListaPrecioDetalleBE)
            _producto = value
        End Set
    End Property

    Private _cantidad As Int32
    Public Property cantidad() As Int32
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Int32)
            _cantidad = value
        End Set
    End Property





End Class
