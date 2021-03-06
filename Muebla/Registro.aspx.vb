﻿Public Class Registro
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
        Catch ex As Exception
            logMessage(ex)
        End Try

    End Sub

    Protected Sub provinciaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.localidadDropDownList.DataSource = BLL.UsuarioBLL.getTiposLocalidades(Integer.Parse(Me.provinciaDropDownList.SelectedValue))
        Me.localidadDropDownList.DataTextField = "descripcion"
        Me.localidadDropDownList.DataValueField = "id"
        Me.localidadDropDownList.DataBind()
    End Sub

    Protected Sub registrarseButton_Click(sender As Object, e As EventArgs)

        Try
            Dim usr As New BE.UsuarioBE
            usr.apellido = Me.apellidoTextBox.Text
            usr.nombre = Me.nombreTextBox.Text
            usr.password = Me.passTextBox.Text
            usr.mail = Me.mailTextBox.Text
            usr.usuario = Me.usuarioTextBox.Text
            usr.dni = Me.documentoTextBox.Text
            usr.cuil = Me.cuilTextBox.Text
            Dim tipo As New BE.TipoDocumentoBE
            usr.tipoDoc = tipo
            usr.tipoDoc.id = Integer.Parse(Me.tipoDocDropDownList.SelectedValue)
            Dim reg As New BE.DomicilioBE
            reg.calle = Me.calleTextBox.Text
            reg.numero = Me.nroTextBox.Text
            reg.piso = Me.pisoTextBox.Text
            reg.dpto = Me.dptoTextBox.Text
            Dim loc As New BE.LocalidadBE
            loc.id = Integer.Parse(Me.localidadDropDownList.SelectedValue)
            Dim prov As New BE.ProvinciaBE
            prov.id = Integer.Parse(Me.provinciaDropDownList.SelectedValue)
            loc.provincia = prov
            reg.localidad = loc
            usr.domicilio = reg
            Dim tel As New BE.TelefonoBE
            tel.numero = Me.telefonoTextBox.Text
            tel.interno = IIf(Me.internoTextBox.Text.Equals(""), 0, Me.internoTextBox.Text)
            tel.prefijo = IIf(Me.prefijoTextBox.Text.Equals(""), 0, Me.prefijoTextBox.Text)
            usr.telefono = tel
            usr = BLL.UsuarioBLL.altaCliente(usr)
            Response.Redirect("registroCompleto.aspx", False)
        Catch ex As Exception
            logMessage(ex)
        End Try
    End Sub
End Class