


Public Class ComprobanteDetalleBE


    Private _cantidad As Integer
    Private _destino As String
    Private _id As Integer
    Private _listaDetalle As ListaPrecioDetalleBE

    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal Value As Integer)
            _cantidad = Value
        End Set
    End Property

    Public Property destino() As String
        Get
            Return _destino
        End Get
        Set(ByVal Value As String)
            _destino = Value
        End Set
    End Property

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property

    Public Property listaDetalle() As ListaPrecioDetalleBE
        Get
            Return _listaDetalle
        End Get
        Set(ByVal Value As ListaPrecioDetalleBE)
            _listaDetalle = Value
        End Set
    End Property

		

End Class ' ComprobanteDetalleBE
