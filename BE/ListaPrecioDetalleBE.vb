
Public Class ListaPrecioDetalleBE


    Private _id As Long
    Private _precio As Decimal
    Private _producto As ProductoBE
    Private _listaPrecio As ListaPrecioBE

    Public Property listaPrecio() As ListaPrecioBE
        Get
            Return _listaPrecio
        End Get
        Set(ByVal value As ListaPrecioBE)
            _listaPrecio = value
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


    Public Property precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal Value As Decimal)
            _precio = Value
        End Set
    End Property

    Public Property producto() As ProductoBE
        Get
            Return _producto
        End Get
        Set(ByVal Value As ProductoBE)
            _producto = Value
        End Set
    End Property

    Public Function getPrecio() As String
        Return String.Format("{0:C}", precio)
    End Function

    Public Function esPromo() As Boolean
        Return listaPrecio.promo
    End Function



End Class ' ListaPrecioDetalleBE

