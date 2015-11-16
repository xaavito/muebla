Public Class AsistenciaShowroomBE

    Private _cumplido As Boolean
    Private _fecha As DateTime
    Private _id As Long
    Private _usuario As UsuarioBE
    Private _vendedor As UsuarioBE
    Private _confirmado As Boolean

    Public Property confirmado() As Boolean
        Get
            Return _confirmado
        End Get
        Set(ByVal value As Boolean)
            _confirmado = value
        End Set
    End Property


    Public Property cumplido() As Boolean
        Get
            Return _cumplido
        End Get
        Set(ByVal Value As Boolean)
            _cumplido = Value
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


    Public Property usuario() As UsuarioBE
        Get
            Return _usuario
        End Get
        Set(ByVal Value As UsuarioBE)
            _usuario = Value
        End Set
    End Property

    Public Property vendedor() As UsuarioBE
        Get
            Return _vendedor
        End Get
        Set(ByVal Value As UsuarioBE)
            _vendedor = Value
        End Set
    End Property

    Public Function getCumplido()
        If cumplido Then
            Return "Si"
        Else
            Return "No"
        End If
    End Function

    Public Function getConfirmado()
        If confirmado Then
            Return "Si"
        Else
            Return "No"
        End If
    End Function
End Class ' AsistenciaShowroomBE
