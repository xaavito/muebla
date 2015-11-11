Public Class DomicilioBE


    Private _calle As String
    Private _dpto As String
    Private _id As Long
    Private _localidad As LocalidadBE
    Private _numero As Long
    Private _piso As String

    Public Property calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal Value As String)
            _calle = Value
        End Set
    End Property

    Public Property localidad() As BE.LocalidadBE
        Get
            If _localidad Is Nothing Then
                _localidad = New BE.LocalidadBE
            End If
            Return _localidad
        End Get
        Set(ByVal Value As BE.LocalidadBE)
            _localidad = Value
        End Set
    End Property

    Public Property dpto() As String
        Get
            Return _dpto
        End Get
        Set(ByVal Value As String)
            _dpto = Value
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


    Public Property numero() As Long
        Get
            Return _numero
        End Get
        Set(ByVal Value As Long)
            _numero = Value
        End Set
    End Property

    Public Property piso() As String
        Get
            Return _piso
        End Get
        Set(ByVal Value As String)
            _piso = Value
        End Set
    End Property

    Public Function formatedLine()
        Return calle + " " + numero.ToString + " " + piso.ToString + " " + dpto.ToString + " " + localidad.descripcion.ToString
    End Function
End Class ' DomicilioBE
