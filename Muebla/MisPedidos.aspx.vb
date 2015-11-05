Public Class MisPedidos
    Inherits ExtendedPage
    Dim selectedPedidos As New List(Of BE.PedidoBE)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        loadEstadosPedidos()
    End Sub

    Protected Sub cancelarVenta(sender As Object, e As EventArgs)
        Response.Redirect("Observaciones.aspx")
    End Sub

    Protected Sub hojaDeRuta(sender As Object, e As EventArgs)
        Response.Redirect("HojadeRuta.aspx")
    End Sub

    Protected Sub remito(sender As Object, e As EventArgs)
        Response.Redirect("Remito.aspx")
    End Sub

    Protected Sub notaCredito(sender As Object, e As EventArgs)
        Response.Redirect("NotaCredito.aspx")
    End Sub

    Protected Sub comentario(sender As Object, e As EventArgs)
        Response.Redirect("Observaciones.aspx")
    End Sub

    Protected Sub postVenta(sender As Object, e As EventArgs)
        Response.Redirect("PostVenta.aspx")
    End Sub

    Protected Sub detallePedidosResultGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.detallePedidosResultGrid)
    End Sub

    Protected Sub detallePedidosResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        'TODO VER ESTO DEL PAGINADO...
    End Sub

    Private Sub loadPedidos()
        Try
            Session("pedidos") = BLL.GestorPedidoBLL.buscarPedidos(getUsuario, Util.Util.getDate(Me.fechaDesdeTextBox.Text), Util.Util.getDate(Me.fechaHastaTextBox.Text), Me.estadoListBox.SelectedValue)
            Me.detallePedidosResultGrid.DataSource = Session("pedidos")
            Me.detallePedidosResultGrid.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub loadEstadosPedidos()
        Me.estadoListBox.DataSource = BLL.GestorPedidoBLL.getEstadosPedidos()
        Me.estadoListBox.DataTextField = "descripcion"
        Me.estadoListBox.DataValueField = "id"
        Me.estadoListBox.DataBind()
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)
        loadPedidos()
    End Sub

    Protected Sub ibtnCambiarEstado_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub ibtnCancelarPedido_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Dim usr As BE.UsuarioBE = Nothing
            Dim id As Integer = getItemId(sender, Me.detallePedidosResultGrid)
            For Each a As BE.PedidoBE In Session("pedidos")
                If a.id = id Then
                    BLL.GestorPedidoBLL.cancelarPedido(a)
                    usr = a.usr
                    Exit For
                End If
            Next
            BLL.GestorBitacoraBLL.registrarEvento(usr, Util.Enumeradores.Bitacora.PedidoCancelado)
            'TODO TRADUCIR
            Util.Mailer.enviarMail(usr.mail, "Pedido Cancelado", "Su pedido ha sido cancelado")
            Throw New Util.EliminacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ButtonCommentOkay_Click(sender As Object, e As EventArgs)
        Try
            BLL.GestorPedidoBLL.generarComentario(Session("idComentario"), Me.commentTextBox.Text)
            Throw New Util.CreacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try

    End Sub

    Protected Sub ibtnCommentarioButton_Click(sender As Object, e As ImageClickEventArgs)
        Session("idComentario") = getItemId(sender, Me.detallePedidosResultGrid)
        Me.lnkComment_ModalPopupExtender.Show()
    End Sub

    Protected Sub generarFacturaButton_Click(sender As Object, e As EventArgs)
        Dim id As Integer
        For Each gvr As GridViewRow In Me.detallePedidosResultGrid.Rows
            If CType(gvr.Cells(0).FindControl("itemSelected"), CheckBox).Checked Then
                id = Integer.Parse(CType(gvr.Cells(0).FindControl("itemID"), Label).Text)
                For Each p As BE.PedidoBE In Session("pedidos")
                    If p.id = id Then
                        selectedPedidos.Add(p)
                        Exit For
                    End If
                Next
            End If
        Next
        Debug.WriteLine("+++++++++++++Pedidos Seleccionados+++++++++++++++++++++")
        For Each pp As BE.PedidoBE In selectedPedidos
            Debug.WriteLine("ID " + pp.id.ToString)
        Next
    End Sub
End Class