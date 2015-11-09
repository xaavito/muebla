Public Class FacturaDetalleBE

    Private _listaPrecioDetalle As BE.ListaPrecioDetalleBE
    Private _cantidad As Integer
    Private _iva As Decimal
    Private _factura As BE.FacturaBE

    Public Property factura() As BE.FacturaBE
        Get
            Return _factura
        End Get
        Set(ByVal value As BE.FacturaBE)
            _factura = value
        End Set
    End Property

    Public Property iva() As Decimal
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value
        End Set
    End Property

    Public Property cant() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property lpd() As BE.ListaPrecioDetalleBE
        Get
            Return _listaPrecioDetalle
        End Get
        Set(ByVal value As BE.ListaPrecioDetalleBE)
            _listaPrecioDetalle = value
        End Set
    End Property


End Class
