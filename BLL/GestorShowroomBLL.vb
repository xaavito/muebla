Imports BE

Public Class GestorShowroomBLL


    Public Shared Sub confirmarPedido(ByVal pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.confirmarPedido(pedido)
        'TODO VER DE SACAR EL HARDCODEO DE LOS TEXTOS mails
        Util.Mailer.enviarMail(pedido.usuario.mail, GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.ConfirmarAsistShow, pedido.usuario.idioma.id), GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.MensajeConfirmarAsist, pedido.usuario.idioma.id) + " " + pedido.fecha.ToString)
    End Sub

    Public Shared Function getPedidos() As List(Of AsistenciaShowroomBE)
        Return DAL.GestorShowroomDAL.getPedidos()
    End Function

    Shared Sub agregarPedido(fecha As Date, usuario As UsuarioBE)
        DAL.GestorShowroomDAL.agregarPedido(fecha, usuario)
    End Sub

    Shared Sub modificarFechaPedido(pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.modificarPedido(pedido)
        'TODO VER DE SACAR EL HARDCODEO DE LOS TEXTOS mails
        If pedido.usuario.mail Is Nothing Then
            BLL.UsuarioBLL.llenarDatosBlandosUsuario(pedido.usuario)
        End If
        Util.Mailer.enviarMail(pedido.usuario.mail, GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.CambioHorario, pedido.usuario.idioma.id), GestorIdiomaBLL.getMensajeTraduccion(Util.Enumeradores.CodigoMensaje.MensajeConfirmarAsist, pedido.usuario.idioma.id) + " " + pedido.fecha.ToString)
    End Sub

    Shared Sub modificarPedido(pedido As AsistenciaShowroomBE)
        DAL.GestorShowroomDAL.modificarPedido(pedido)
    End Sub


End Class ' GestorShowroomBLL
