Public Class IdiomaBE
    Private _descripcion As String
    Private _id As Long
    Private _componentes As List(Of ComponenteBE)
    Private _mensajes As List(Of MensajeBE)

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
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

    Public Property componentes() As List(Of ComponenteBE)
        Get
            Return _componentes
        End Get
        Set(ByVal Value As List(Of ComponenteBE))
            _componentes = Value
        End Set
    End Property

    Public Property mensajes() As List(Of MensajeBE)
        Get
            Return _mensajes
        End Get
        Set(ByVal Value As List(Of MensajeBE))
            _mensajes = Value
        End Set
    End Property

End Class ' IdiomaBE

' BE