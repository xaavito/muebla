
Public Class ListaPrecioBE


    Private _detalles As ListaPrecioDetalleBE
    Private _fechaDesde As Date
    Private _fechaHasta As Date
    Private _id As Long
    Public m_ListaPrecioDetalleBE As ListaPrecioDetalleBE

    Public Property detalles() As ListaPrecioDetalleBE
        Get
            Return _detalles
        End Get
        Set(ByVal Value As ListaPrecioDetalleBE)
            _detalles = Value
        End Set
    End Property

    Public Property fechaDesde() As Date
        Get
            Return _fechaDesde
        End Get
        Set(ByVal Value As Date)
            _fechaDesde = Value
        End Set
    End Property

    Public Property fechaHasta() As Date
        Get
            Return _fechaHasta
        End Get
        Set(ByVal Value As Date)
            _fechaHasta = Value
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




End Class ' ListaPrecioBE
