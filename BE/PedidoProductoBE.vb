Public Class PedidoProductoBE
    Private _id As Integer
    Private _pedido As BE.PedidoBE
    Private _producto As BE.ListaPrecioDetalleBE
    Private _cantidad As Integer

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property pedido() As BE.PedidoBE
        Get
            Return _pedido
        End Get
        Set(ByVal value As BE.PedidoBE)
            _pedido = value
        End Set
    End Property

    Public Property producto() As BE.ListaPrecioDetalleBE
        Get
            Return _producto
        End Get
        Set(ByVal value As BE.ListaPrecioDetalleBE)
            _producto = value
        End Set
    End Property

    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Function getPrecio() As String
        Return String.Format("{0:C}", cantidad * producto.precio)
    End Function
End Class
