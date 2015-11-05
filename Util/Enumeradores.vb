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

        ErrorBizarro = 13 ' falta
        BusquedaConMuchosResultados = 14 ' falta

        MailFallo = 15 ' falta

        TienePedidosEnProceso

        NoSePuedeCancelarPedidoEstado

        CuitExistente

        ProveedorProductosEnVenta

        ProveedorProductosEnStock

        MailYaEstaUtilizado

        UsuarioYaEstaUtilizado

    End Enum

    Enum Bitacora
        LogueoExitoso = 1
        LogoutExitoso = 2
        ModificacionUsuario = 3
        ' DESDE ACA FALTAN
        PedidoRealizado = 4

        PedidoCancelado

    End Enum

    Enum ImportanciaEvento
        Err = 1
        Exito = 2
        Warning = 3
        Info = 4
    End Enum

    Enum CodigoMensaje
        ConfirmarAsistShow = 1
        MensajeConfirmarAsist = 2
        CambioHorario = 3
        Info = 4
    End Enum
End Class
