Imports BE
Imports Util

Public Class GestorShowroomDAL
    Public Shared Function getPedidos() As List(Of AsistenciaShowroomBE)
        Dim table As DataTable
        Dim lista As New List(Of BE.AsistenciaShowroomBE)
        Dim repository As New AccesoSQLServer
        Try
            'TODO NO IMPLEMENTADO BUSCAR_PEDIDOS_ASISTENCIA_SP
            repository.crearComando("BUSCAR_PEDIDOS_ASISTENCIA_SP")
            table = New DataTable
            table = repository.executeSearchWithAdapter()
            If (table.Rows.Count = 0) Then
                Throw New BusquedaSinResultadosException
            End If
            For Each row As DataRow In table.Rows
                Dim objeto As New AsistenciaShowroomBE
                objeto.id = row.Item(0)
                Dim usr As New UsuarioBE
                usr.id = row.Item(1)
                usr.usuario = row.Item(2)
                objeto.usuario = usr
                objeto.fecha = row.Item(3)
                objeto.cumplido = row.Item(4)
                objeto.confirmado = row.Item(5)
                lista.Add(objeto)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function

    Shared Sub agregarPedido(fecha As Date, usuario As UsuarioBE)
        Dim id As Int16

        Dim repository As New AccesoSQLServer
        Try
            'TODO FALTA IMPLEMENTAR ALTA_PEDIDO_SHOWROOM_SP
            repository.crearComando("ALTA_PEDIDO_SHOWROOM_SP")
            repository.addParam("@id", usuario.id)
            repository.addParam("@fecha", fecha)
            id = repository.executeWithReturnValue
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub modificarPedido(pedido As AsistenciaShowroomBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            'TODO FALTA IMPLEMENTAR MODIFICAR_PEDIDO_SHOWROOM_SP
            repository.crearComando("MODIFICAR_PEDIDO_SHOWROOM_SP")
            repository.addParam("@id", pedido.id)
            repository.addParam("@fecha", pedido.fecha)
            repository.addParam("@cum", pedido.cumplido)
            id = repository.executeSearchWithStatus
            confirmarPedido(pedido)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub confirmarPedido(pedido As AsistenciaShowroomBE)
        Dim id As Integer
        Dim repository As New AccesoSQLServer
        Try
            'TODO FALTA IMPLEMENTAR CONFIRMAR_PEDIDO_SHOWROOM_SP
            repository.crearComando("CONFIRMAR_PEDIDO_SHOWROOM_SP")
            repository.addParam("@id", pedido.id)
            id = repository.executeSearchWithStatus
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class ' GestorShowroomDAL

