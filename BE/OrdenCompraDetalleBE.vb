Public Class OrdenCompraDetalleBE
    Private _cabecera As OrdenCompraBE
    Private _producto As ProductoBE
    Private _cantidad As Integer
    Private _precioUnitario As Decimal

    Public Property precioUnitario() As Decimal
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As Decimal)
            _precioUnitario = value
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

    Public Property producto() As ProductoBE
        Get
            Return _producto
        End Get
        Set(ByVal value As ProductoBE)
            _producto = value
        End Set
    End Property

    Public Property cabecera() As OrdenCompraBE
        Get
            Return _cabecera
        End Get
        Set(ByVal value As OrdenCompraBE)
            _cabecera = value
        End Set
    End Property


End Class
