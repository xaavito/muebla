Public Class DatosPersonales
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If
        Try
            Me.tipoDocDropDownList.DataSource = BLL.UsuarioBLL.getTiposDocumentos()
            Me.tipoDocDropDownList.DataTextField = "descripcion"
            Me.tipoDocDropDownList.DataValueField = "id"
            Me.tipoDocDropDownList.DataBind()

            Me.provinciaDropDownList.DataSource = BLL.UsuarioBLL.getProvincias()
            Me.provinciaDropDownList.DataTextField = "descripcion"
            Me.provinciaDropDownList.DataValueField = "id"
            Me.provinciaDropDownList.DataBind()

            provinciaDropDownList_SelectedIndexChanged(sender, e)

            If Not getUsuario() Is Nothing Then
                BLL.UsuarioBLL.llenarDatosUsuario(getUsuario)
                Me.nombreTextBox.Text = getUsuario().nombre
                Me.apellidoTextBox.Text = getUsuario().apellido

                Me.passTextBox.Text = Util.Encrypter.DecryptPasswordMD5(getUsuario().password)
                Me.mailTextBox.Text = getUsuario().mail
                Me.usuarioTextBox.Text = getUsuario().usuario
                Me.documentoTextBox.Text = getUsuario().dni
                Me.cuilTextBox.Text = getUsuario().cuil
                If Not getUsuario.tipoDoc Is Nothing Then
                    Me.tipoDocDropDownList.SelectedValue = getUsuario().tipoDoc.id
                End If
                If Not getUsuario().domicilio Is Nothing Then
                    Me.calleTextBox.Text = getUsuario().domicilio.calle
                    Me.nroTextBox.Text = getUsuario.domicilio.numero
                    Me.pisoTextBox.Text = getUsuario().domicilio.piso
                    Me.dptoTextBox.Text = getUsuario().domicilio.dpto
                    Me.localidadDropDownList.SelectedValue = getUsuario().domicilio.localidad.id
                    Me.provinciaDropDownList.SelectedValue = getUsuario().domicilio.localidad.provincia.id
                End If
                If Not getUsuario().telefono Is Nothing Then
                    Me.telefonoTextBox.Text = getUsuario().telefono.numero
                    Me.internoTextBox.Text = getUsuario().telefono.interno
                    Me.prefijoTextBox.Text = getUsuario().telefono.prefijo
                End If
                Me.DataBind()
            End If
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub

    Protected Sub provinciaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Me.localidadDropDownList.DataSource = BLL.UsuarioBLL.getTiposLocalidades(Integer.Parse(Me.provinciaDropDownList.SelectedValue))
            Me.localidadDropDownList.DataTextField = "descripcion"
            Me.localidadDropDownList.DataValueField = "id"
            Me.localidadDropDownList.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
        
    End Sub

    Protected Sub editarButton_Click(sender As Object, e As EventArgs)
        Try
            Me.provinciaDropDownList1.DataSource = BLL.UsuarioBLL.getProvincias()
            Me.provinciaDropDownList1.DataTextField = "descripcion"
            Me.provinciaDropDownList1.DataValueField = "id"
            Me.provinciaDropDownList1.DataBind()

            provinciaDropDownList1_SelectedIndexChanged(sender, e)

            Me.passTextBox1.Text = Me.passTextBox.Text
            If Not getUsuario().domicilio Is Nothing Then
                Me.calleTextBox1.Text = Me.calleTextBox.Text
                Me.nroCalleTextBox.Text = Me.nroTextBox.Text
                Me.pisoTextBox1.Text = Me.pisoTextBox.Text
                Me.dptoTextBox1.Text = Me.dptoTextBox.Text
                Me.localidadDropDownList1.SelectedValue = Me.localidadDropDownList.SelectedValue
                Me.provinciaDropDownList1.SelectedValue = Me.provinciaDropDownList.SelectedValue
            End If
            If Not getUsuario().telefono Is Nothing Then
                Me.telefonoTextBox1.Text = Me.telefonoTextBox.Text
                Me.internoTextBox1.Text = Me.internoTextBox.Text
                Me.prefijoTextBox1.Text = Me.prefijoTextBox.Text
            End If
            Me.DataBind()
            Me.lnkEdit_ModalPopupExtender.Show()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub provinciaDropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Me.localidadDropDownList1.DataSource = BLL.UsuarioBLL.getTiposLocalidades(Integer.Parse(Me.provinciaDropDownList.SelectedValue))
            Me.localidadDropDownList1.DataTextField = "descripcion"
            Me.localidadDropDownList1.DataValueField = "id"
            Me.localidadDropDownList1.DataBind()
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub

    Protected Sub ButtonEditOkay_Click(sender As Object, e As EventArgs)
        Try
            BLL.UsuarioBLL.checkPreModificacion(getUsuario)
            getUsuario.domicilio.calle = Me.calleTextBox1.Text
            getUsuario.domicilio.numero = Me.nroCalleTextBox.Text
            getUsuario.domicilio.piso = Me.pisoTextBox1.Text
            getUsuario.domicilio.dpto = Me.dptoTextBox1.Text
            getUsuario.domicilio.localidad.id = Me.localidadDropDownList1.SelectedValue

            getUsuario.telefono.numero = Me.telefonoTextBox1.Text
            getUsuario.telefono.interno = Me.internoTextBox1.Text
            getUsuario.telefono.prefijo = Me.prefijoTextBox1.Text

            getUsuario.password = Util.Encrypter.EncryptPasswordMD5(Me.passTextBox1.Text)
            BLL.UsuarioBLL.modificarUsuario(getUsuario)
            Throw New Util.ModificacionExitosaException
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub
End Class