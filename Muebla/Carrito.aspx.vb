Imports System.IO

Public Class Carrito
    Inherits ExtendedPage

    Dim carrito As List(Of BE.ListaPrecioDetalleBE)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        loadPedido()
        handleSteps()
        loadTipoEnvios()
        loadModoPago()
    End Sub

    Protected Sub comprar_Click(sender As Object, e As EventArgs)
        Try
            Dim ms As MemoryStream
            ms = BLL.GestorPedidoBLL.generarPedido(Session("carrito"))
            DownloadPDF(ms)
            Throw New Util.CreacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ibtnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Session("idEliminar") = getItemId(sender, Me.detalleCarritoResultGrid)
        Me.lnkDelete_ModalPopupExtender.Show()
    End Sub

    Protected Sub detalleCarritoResultGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.detalleCarritoResultGrid)
    End Sub

    Protected Sub pasoConfirmarButton_Click(sender As Object, e As EventArgs)
        handleSteps()
        Dim pedido As BE.PedidoBE = DirectCast(Session("carrito"), BE.PedidoBE)

        pedido.medioPago.id = Me.modoPago.SelectedValue()
        Session("carrito") = pedido
    End Sub

    Protected Sub pasoPagoButton_Click(sender As Object, e As EventArgs)
        handleSteps()
        Dim pedido As BE.PedidoBE = DirectCast(Session("carrito"), BE.PedidoBE)

        pedido.tipoEnvio.id = Me.tipoEnvio.SelectedValue()
        Session("carrito") = pedido
    End Sub

    Protected Sub confirmarCarritoButton_Click(sender As Object, e As EventArgs)
        handleSteps()
    End Sub

    Protected Sub ButtonDeleleOkay_Click(sender As Object, e As EventArgs)
        Dim pedido As BE.PedidoBE = DirectCast(Session("carrito"), BE.PedidoBE)
        For Each p As BE.PedidoProductoBE In pedido.productos
            If p.producto.id = Session("idEliminar") Then
                pedido.productos.Remove(p)
                Exit For
            End If
        Next
        Session("carrito") = pedido
        loadPedido()
    End Sub

    Protected Sub detalleCarritoResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        ' todo pagex index
    End Sub

    Private Sub loadPedido()
        Dim pedido As BE.PedidoBE = DirectCast(Session("carrito"), BE.PedidoBE)
        If Not pedido Is Nothing Then
            Me.detalleCarritoResultGrid.DataSource = pedido.productos
            Me.detalleCarritoResultGrid.DataBind()

            Dim t As Decimal
            For Each p As BE.PedidoProductoBE In pedido.productos
                t += p.getPrecio
            Next
            Me.totalMontoLabel.Text = String.Format("{0:C}", t)
        End If
    End Sub

    Private Sub handleSteps()
        If Me.pasoLabel.Text = "" Then
            Me.confirmarStepOne.Visible = True
            Me.pasoLabel.Text = "Paso 1"
            Me.pasoEnvio.Visible = False
            Me.pasoPago.Visible = False
            Me.pasoConfirmacion.Visible = False
            Return
        End If
        If Me.pasoLabel.Text = "Paso 1" Then
            Me.pasoLabel.Text = "Paso 2"
            Me.confirmarStepOne.Visible = False
            Me.pasoEnvio.Visible = True
            Me.pasoPago.Visible = False
            Me.pasoConfirmacion.Visible = False
            Return
        End If
        If Me.pasoLabel.Text = "Paso 2" Then
            Me.pasoLabel.Text = "Paso 3"
            Me.confirmarStepOne.Visible = False
            Me.pasoEnvio.Visible = False
            Me.pasoPago.Visible = True
            Me.pasoConfirmacion.Visible = False
            Return
        End If
        If Me.pasoLabel.Text = "Paso 3" Then
            Me.pasoLabel.Text = "Paso 4"
            Me.confirmarStepOne.Visible = False
            Me.pasoEnvio.Visible = False
            Me.pasoPago.Visible = False
            Me.pasoConfirmacion.Visible = True
            Return
        End If
    End Sub

    Private Sub loadTipoEnvios()
        Try
            Dim listaTipoEnvios As List(Of BE.TipoEnvioBE) = BLL.GestorPedidoBLL.buscarTiposEnvios(getSelectedIdioma)
            Me.tipoEnvio.DataSource = listaTipoEnvios
            Me.tipoEnvio.DataTextField = "texto"
            Me.tipoEnvio.DataValueField = "id"
            Me.tipoEnvio.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Private Sub loadModoPago()
        Try
            Dim listaModoPago As List(Of BE.MedioPagoBE) = BLL.GestorPedidoBLL.buscarMediosPago()
            Me.modoPago.DataSource = listaModoPago
            Me.modoPago.DataTextField = "descripcion"
            Me.modoPago.DataValueField = "id"
            Me.modoPago.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

End Class