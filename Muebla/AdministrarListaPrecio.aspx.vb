﻿Public Class ModificarListaPrecio
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'todo mandar a traducir esto del combo
            Me.estadoListBox.DataSource = Util.Util.getEstadoCombo
            Me.estadoListBox.DataValueField = "id"
            Me.estadoListBox.DataTextField = "descripcion"
            Me.estadoListBox.DataBind()
            Me.detailsData.Visible = True
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub

    Protected Sub buscarButton_Click(sender As Object, e As EventArgs)
        Try
            Me.listaPrecioResultadosDataGrid.DataSource = BLL.ListaPrecioBLL.buscarListas(Me.estadoListBox.SelectedValue, Me.descripcionTextBox.Text)
            Me.listaPrecioResultadosDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ibtnDetails_Click(sender As Object, e As ImageClickEventArgs)
        Session("idListaPrecio") = getItemId(sender, Me.listaPrecioResultadosDataGrid)
        buscarDetalles()
    End Sub

    Protected Sub listaPrecioResultadosDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.listaPrecioResultadosDataGrid)
    End Sub

    Protected Sub listaPrecioResultadosDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.listaPrecioResultadosDataGrid.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub detalleListaPrecioResultGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.detalleListaPrecioResultGrid)
    End Sub

    Protected Sub detalleListaPrecioResultGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.detalleListaPrecioResultGrid.PageIndex = e.NewPageIndex
        buscarDetalles()
    End Sub

    Protected Sub ibtnEditDetail_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Session("idListaPrecioDetalle") = getItemId(sender, Me.detalleListaPrecioResultGrid)
            For Each a As BE.ListaPrecioDetalleBE In Session("detallesListaPrecio")
                If a.id = Session("idListaPrecioDetalle") Then
                    Me.valorTextBox.Text = a.precio
                End If
            Next
            Me.lnkEditDetail_ModalPopupExtender.Show()
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub

    Private Sub buscarDetalles()
        Try
            Session("detallesListaPrecio") = BLL.ListaPrecioBLL.getDetalleListaPrecio(Session("idListaPrecio"))
            Me.detalleListaPrecioResultGrid.DataSource = Session("detallesListaPrecio")
            Me.detalleListaPrecioResultGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub confirmarEdicionButton_Click(sender As Object, e As EventArgs)
        Try
            BLL.ListaPrecioBLL.modificarListaPrecioDetalle(getUsuario, Session("idListaPrecioDetalle"), Me.valorTextBox.Text)
            buscarDetalles()
            Throw New Util.ModificacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ButtonEditDetailCancel_Click(sender As Object, e As EventArgs)
        ' NO HAGO NADA ACA
    End Sub
End Class