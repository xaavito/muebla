Imports BE


Public Class GestorShowroomDAL


    ''' 
    ''' <param name="usr"></param>
    Public Sub agregarPedido(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="pedido"></param>
    ''' <param name="fecha"></param>
    ''' <param name="vend"></param>
    Public Sub confirmarPedido(ByVal pedido As AsistenciaShowroomBE, ByVal fecha As DateTime, ByVal vend As UsuarioBE)

    End Sub

    Public Function getPedidos() As List(Of AsistenciaShowroomBE)
        getPedidos = Nothing
    End Function


End Class ' GestorShowroomDAL

