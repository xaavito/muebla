Imports BE

Public Class ConfirmarShowroom
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        buscarPedidos()
    End Sub

    Protected Sub showroomDataGrid_PreRender(sender As Object, e As EventArgs)
        translateGrid(Me.showroomDataGrid)
    End Sub

    Protected Sub showroomDataGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

    End Sub

    Protected Sub ibtnEdit_Click(sender As Object, e As ImageClickEventArgs)
        Session("idEdicion") = getItemId(sender, Me.showroomDataGrid)
        Dim id As Integer = Session("idEdicion")
        For Each a As AsistenciaShowroomBE In Session("pedidos")
            If a.id = id Then
                Me.fechaSolicTextBox.Text = a.fecha
                Me.asitioCheckBox.Checked = a.cumplido
                Exit For
            End If
        Next
        Me.lnkEdit_ModalPopupExtender.Show()
    End Sub

    Protected Sub ibtnConfirm_Click(sender As Object, e As ImageClickEventArgs)
        'TODO REVISAR UN TOQUE EL TEMA DE LA EDICION Y EL CHECKED QUE NO ME GUSTA NADA...
        Dim id As Integer = getItemId(sender, Me.showroomDataGrid)
        For Each a As AsistenciaShowroomBE In Session("pedidos")
            If a.id = id Then
                a.fecha = Util.Util.getDate(Me.fechaSolicTextBox.Text)
                Try
                    If a.cumplido = Me.asitioCheckBox.Checked Then
                        BLL.GestorShowroomBLL.modificarFechaPedido(a)
                    Else
                        BLL.GestorShowroomBLL.modificarPedido(a)
                    End If
                Catch ex As Exception
                    logMessage(ex)
                End Try
                Exit For
            End If
        Next
        buscarPedidos()
    End Sub

    Protected Sub buttonDeleteOK_Click(sender As Object, e As EventArgs)
        Dim id As Integer = Session("idEdicion")
        For Each a As AsistenciaShowroomBE In Session("pedidos")
            If a.id = id Then
                a.fecha = Util.Util.getDate(Me.fechaSolicTextBox.Text)
                Try
                    If a.cumplido = Me.asitioCheckBox.Checked Then
                        BLL.GestorShowroomBLL.modificarFechaPedido(a)
                    Else
                        BLL.GestorShowroomBLL.modificarPedido(a)
                    End If
                Catch ex As Exception
                    logMessage(ex)
                End Try
                Exit For
            End If
        Next
        buscarPedidos()
    End Sub

    Private Sub buscarPedidos()
        Try
            Session("pedidos") = BLL.GestorShowroomBLL.getPedidos()
            Me.showroomDataGrid.DataSource = Session("pedidos")
            Me.showroomDataGrid.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

End Class