Public Class Enumeradores
    Enum Excepeciones
        'TODO todo lo que no tiene numero hay que agregarlo
        'BD
        ConexionBDFallida = 1
        'Genericas
        BusquedaSinResultados = 2
        FalloAlEliminar = 3
        FalloAlCrear = 4
        FalloAlModificar = 5
        ExitoAlEliminar = 6
        ExitoAlCrear = 7
        ExitoAlModificar = 8
        'Alta Registro
        ExitoAlCrearUsuario = 9
        'Login Fallido
        UsuarioYOPassIncorrecto = 10
        'Genericos, en este caso Restaurar BD.
        RestauracionExitosa = 11
        'Recuperar Pass
        MailEnviandose = 12
        ErrorBizarro = 13
        BusquedaConMuchosResultados = 14
        MailFallo = 15
        TienePedidosEnProceso = 16
        NoSePuedeCancelarPedidoEstado = 17
        CuitExistente = 18
        ProveedorProductosEnVenta = 19
        ProveedorProductosEnStock = 20
        MailYaEstaUtilizado = 21
        UsuarioYaEstaUtilizado = 22
        MasDeUnaSeleccion = 23
        PedidoPersonalizado = 24
        ProveedorInactivo = 25
        ProveedorDeudor = 26
        PedidoNoFacturado = 27
        PedidoNoFinalizado = 28
        PedidoFacturado = 29
        PedidoEnviado = 30
        MasDeUnPedido = 31
        FechaHastaMenorIgualDesde = 32
        PedidosEnProceso = 33
        ProductoBaja = 34
        UsuarioInactivo = 35
        UsuarioAdmin = 36
    End Enum

    Enum Bitacora
        LogueoExitoso = 1
        LogoutExitoso = 2
        ModificacionUsuario = 3
        PedidoRealizado = 4
        PedidoCancelado = 5
        FacturaRealizada = 6
        NCRealizada = 7
        OCRealizada = 8
        PedidoPersonalizado = 9
        VentaAnulada = 10
        RegistroExistoso = 11
    End Enum

    Enum ImportanciaEvento
        Err = 1
        Exito = 2
        Warning = 3
        Info = 4
    End Enum

    Enum EstadoPedido
        ProcesoDePago = 1
        Produccion = 2
        Enviando = 3
        Enviado = 4
        Devuelto = 5
        Cancelado = 6
        Construido = 7
        Finalizado = 8
    End Enum

    Enum CodigoMensaje
        ConfirmarAsistShow = 1
        MensajeConfirmarAsist = 2
        CambioHorario = 3
        Info = 4
        Factura = 5
        FacturaMensaje = 6
        Pedido = 7
        PedidoMensaje = 8
        PedidoCancelado = 9
        PedidoCanceladoMensaje = 10
        RemitoMensaje = 11
        Remito = 12
        HojaRuta = 13
        HojaRutaMensaje = 14
        NC = 15
        NCMensaje = 16
        OC = 17
        OCMensaje = 18
        PedidoPersonalizado = 19
        PedidoPersonalizadoMensaje = 20
        PedidoComentario = 21
        PedidoComentarioMensaje = 22
        AnulacionVentaMensaje = 23
        AnulacionVenta = 24
    End Enum
End Class
