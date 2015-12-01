Imports BE

Public Class GestorShowroomBLL
    Public Shared Sub confirmarPedido(ByVal pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.confirmarPedido(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usuario)
        Util.Mailer.enviarMail(pedido.usuario.mail, GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.ConfirmarAsistShow), GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.MensajeConfirmarAsist) + " " + pedido.fecha.ToString)
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usuario, Util.Enumeradores.Bitacora.ConfirmarPedidoAsistencia)
    End Sub

    Public Shared Function getPedidos() As List(Of AsistenciaShowroomBE)
        Return DAL.GestorShowroomDAL.getPedidos()
    End Function

    Shared Sub agregarPedido(fecha As Date, usuario As UsuarioBE)
        DAL.GestorShowroomDAL.agregarPedido(fecha, usuario)
        BLL.GestorBitacoraBLL.registrarEvento(usuario, Util.Enumeradores.Bitacora.PedidoAsistenciaShowroom)
    End Sub

    Shared Sub modificarFechaPedido(pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.modificarPedido(pedido)
        BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usuario)
        Util.Mailer.enviarMail(pedido.usuario.mail, GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.CambioHorario), GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.MensajeConfirmarAsist) + " " + pedido.fecha.ToString)
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usuario, Util.Enumeradores.Bitacora.ModificacionAsistenciaShowroom)
    End Sub

    Shared Sub modificarPedido(pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.modificarPedido(pedido)
        BLL.GestorBitacoraBLL.registrarEvento(pedido.usuario, Util.Enumeradores.Bitacora.ModificacionAsistenciaShowroom)
    End Sub
End Class ' GestorShowroomBLL
