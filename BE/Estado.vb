Public Class Estado

    Public Sub New(ByVal i As Integer, ByVal desc As String)
        Me.id = i
        Me.descripcion = desc
    End Sub

    Private _descripcion As String
    Private _id As Integer

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
        End Set
    End Property

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property



End Class ' TipoVentaBE
