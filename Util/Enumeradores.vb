Public Class Enumeradores
    Enum Excepeciones
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

        FechaMenorAUltimaVigencia = 37

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
        SolicitudContrasena = 12
        'TODO FALTAN CARGARLOS A LA BD!
        AltaIdioma = 13
        ModificacionIdioma = 14
        HojaRutaGenerada = 15
        NotaCreditoGenerada = 16
        ComentarioGenerado = 17
        RemitoGenerado = 18
        BackupRestaurado = 19
        PedidoAsistenciaShowroom = 20
        ModificacionAsistenciaShowroom = 21
        AltaListaPrecio = 22
        AltaPromocion = 23
        AltaProducto = 24
        BajaProducto = 25
        ModificacionProducto = 26
        GeneracionOrdenCompra = 27
        AltaProveedor = 28
        ModificarProveedor = 29
        EliminacionProveedor = 30
        EliminacionUsuario = 31
        ConfirmarPedidoAsistencia = 32
        ModificacionListaPrecio = 33
        BackupGenerado = 34

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

        NuevaPromoMensaje = 25

        NuevaPromo = 26

        RecuperarContrasena = 27

        ModificacionDatos = 28

        RecuperarContrasenaMensaje = 29

        ModificacionDatosMensaje = 30

        RegistroExitosoMensaje = 31

        RegistroExitoso = 32

    End Enum
End Class
