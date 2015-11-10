Public Class AltaListaPrecio
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If

        ' TODO DEBERIA CARGAR LA FECHA DEL DIA MAYOR A UNO DE LA ULTIMA LISTA DE PRECIO NO??? ES MEJOR ME PA
        loadListaPrecio()
    End Sub

    Protected Sub confirmarButton_Click(sender As Object, e As EventArgs)
        Try
            Dim lp As New BE.ListaPrecioBE
            lp.fechaDesde = Util.Util.getDate(fechaDesdeTextBox.Text)
            lp.descripcion = descripcionTextBox.Text
            Dim lista As New List(Of BE.ListaPrecioDetalleBE)
            Dim ob As BE.ListaPrecioDetalleBE = Nothing
            Dim prod As BE.ProductoBE
            For Each gvr As GridViewRow In Me.detalleListaPrecioResultGrid.Rows
                ob = New BE.ListaPrecioDetalleBE
                prod = New BE.ProductoBE
                prod.id = Long.Parse(CType(Me.detalleListaPrecioResultGrid.Rows(gvr.RowIndex).Cells(0).FindControl("itemProductoID"), Label).Text)
                ob.producto = prod
                ob.precio = Decimal.Parse(CType(Me.detalleListaPrecioResultGrid.Rows(gvr.RowIndex).Cells(0).FindControl("itemPrecioSinFormato"), Label).Text)
                lista.Add(ob)
            Next
            lp.detalles = lista
            BLL.ListaPrecioBLL.altaListaPrecio(lp)
            Throw New Util.CreacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub detalleListaPrecioResultGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.detalleListaPrecioResultGrid)
    End Sub

    Protected Sub detalleListaPrecioResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.detalleListaPrecioResultGrid.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub itemPrecio_TextChanged(sender As Object, e As EventArgs)
        getItemId(sender, Me.detalleListaPrecioResultGrid)
    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Session("idListaPrecioDetalle") = getItemId(sender, Me.detalleListaPrecioResultGrid)
        For Each a As BE.ListaPrecioDetalleBE In Session("altaListaPrecio")
            If a.id = Session("idListaPrecioDetalle") Then
                Me.valorTextBox.Text = a.precio
            End If
        Next
        Me.lnkEditDetail_ModalPopupExtender.Show()
    End Sub

    Protected Sub ButtonEditDetailOkay_Click(sender As Object, e As EventArgs)
        Dim lista As List(Of BE.ListaPrecioDetalleBE) = Session("altaListaPrecio")
        For Each a As BE.ListaPrecioDetalleBE In lista
            If a.id = Session("idListaPrecioDetalle") Then
                a.precio = Me.valorTextBox.Text
                Exit For
            End If
        Next
        Session("altaListaPrecio") = lista
        loadListaPrecio()
    End Sub

    Protected Sub ButtonEditDetailCancel_Click(sender As Object, e As EventArgs)
        ' NO SE HACE NADA
    End Sub

    Private Sub loadListaPrecio()
        Try
            If Session("altaListaPrecio") Is Nothing Then
                Session("altaListaPrecio") = BLL.ListaPrecioBLL.getListaPrecioParaAlta()
            End If
            Me.detalleListaPrecioResultGrid.DataSource = Session("altaListaPrecio")
            Me.detalleListaPrecioResultGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

End Class