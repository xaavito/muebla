
Public Class TelefonoBE


    Private _id As Long
    Private _interno As Long
    Private _numero As Long
    Private _prefijo As Long

    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal Value As Long)
            _id = Value
        End Set
    End Property

    Public Property interno() As Long
        Get
            Return _interno
        End Get
        Set(ByVal Value As Long)
            _interno = Value
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

    Public Property prefijo() As Long
        Get
            Return _prefijo
        End Get
        Set(ByVal Value As Long)
            _prefijo = Value
        End Set
    End Property

    Public Function formatedLine()
        Return numero.ToString + " " + prefijo.ToString + " " + interno.ToString
    End Function

End Class ' TelefonoBE
