
Public Class TipoUsuarioBE


    Private _descripcion As String
    Private _id As Int32

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
        End Set
    End Property

    Public Property id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal Value As Int32)
            _id = Value
        End Set
    End Property



End Class ' TipoUsuarioBE
