Public Class NotaCreditoDetalleBE

    Private _iva As Decimal
    Private _nc As BE.NotaCreditoBE
    Private _valor As Decimal
    Private _texto As String

    Public Property texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal value As String)
            _texto = value
        End Set
    End Property

    Public Property valor() As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            _valor = value
        End Set
    End Property

    Public Property nc() As BE.NotaCreditoBE
        Get
            Return _nc
        End Get
        Set(ByVal value As BE.NotaCreditoBE)
            _nc = value
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

End Class
