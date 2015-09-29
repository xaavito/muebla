Imports BE

Public Class GestorShowroomBLL


    ''' 
    ''' <param name="usr"></param>
    Public Shared Sub agregarPedido(ByVal usr As UsuarioBE)

    End Sub

    ''' 
    ''' <param name="pedido"></param>
    ''' <param name="vend"></param>
    ''' <param name="fecha"></param>
    Public Shared Sub confirmarPedido(ByVal pedido As AsistenciaShowroomBE, ByVal vend As UsuarioBE, ByVal fecha As DateTime)

    End Sub

    Public Shared Function getPedidos() As List(Of AsistenciaShowroomBE)
        getPedidos = Nothing
    End Function


End Class ' GestorShowroomBLL
