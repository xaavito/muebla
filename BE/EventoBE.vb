

Public Class EventoBE


    Private _descripcion As String
    Private _fecha As DateTime
    Private _id As Long
    Private _tipoEvento As TipoEventoBE
    Private _usr As UsuarioBE

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
        End Set
    End Property

    Public Property fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal Value As DateTime)
            _fecha = Value
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

		

    Public Property tipoEvento() As TipoEventoBE
        Get
            Return _tipoEvento
        End Get
        Set(ByVal Value As TipoEventoBE)
            _tipoEvento = Value
        End Set
    End Property

    Public Property usr() As UsuarioBE
        Get
            Return _usr
        End Get
        Set(ByVal Value As UsuarioBE)
            _usr = Value
        End Set
    End Property


End Class ' EventoBE
