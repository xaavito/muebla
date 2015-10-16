Imports BE

Public Class GestorShowroomBLL


    Public Shared Sub confirmarPedido(ByVal pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.confirmarPedido(pedido)
        'VER DE SACAR EL HARDCODEO DE LOS TEXTOS
        Util.Mailer.sendMail(pedido.usuario.mail, "Confirmacion Asistencia Showroom", "Asistencia al showroom autorizada para " + pedido.fecha.ToString)
    End Sub

    Public Shared Function getPedidos() As List(Of AsistenciaShowroomBE)
        Return DAL.GestorShowroomDAL.getPedidos()
    End Function

    Shared Sub agregarPedido(fecha As Date, usuario As UsuarioBE)
        DAL.GestorShowroomDAL.agregarPedido(fecha, usuario)
    End Sub

    Shared Sub modificarFechaPedido(pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.modificarPedido(pedido)
        'VER DE SACAR EL HARDCODEO DE LOS TEXTOS
        Util.Mailer.sendMail(pedido.usuario.mail, "Confirmacion y cambio horario", "Asistencia al showroom autorizada para " + pedido.fecha.ToString)
    End Sub

    Shared Sub modificarPedido(pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.modificarPedido(pedido)
    End Sub


End Class ' GestorShowroomBLL
