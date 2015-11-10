Public Class ComprobanteBE


    Private _comprobantesDetalle As List(Of ComprobanteDetalleBE)
    Private fecha As DateTime
    Private _id As Long
    Private _nroComprobante As Long
    Private _tipoComprobante As TipoComprobanteBE
    Private _total As Double

    Public Property comprobantesDetalle() As List(Of ComprobanteDetalleBE)
        Get
            Return _comprobantesDetalle
        End Get
        Set(ByVal Value As List(Of ComprobanteDetalleBE))
            _comprobantesDetalle = Value
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

    Public Property nroComprobante() As Long
        Get
            Return _nroComprobante
        End Get
        Set(ByVal Value As Long)
            _nroComprobante = Value
        End Set
    End Property

    Public Property total() As Double
        Get
            Return _total
        End Get
        Set(ByVal Value As Double)
            _total = Value
        End Set
    End Property


End Class ' ComprobanteBE
