Public Class DatosPersonales
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Return
        End If

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

            Me.passTextBox.Text = getUsuario().password
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
                Me.localidadDropDownList.SelectedValue = getUsuario().domicilio.m_LocalidadBE.id
                Me.provinciaDropDownList.SelectedValue = getUsuario().domicilio.m_LocalidadBE.m_ProvinciaBE.id
            End If
            If Not getUsuario().telefono Is Nothing Then
                Me.telefonoTextBox.Text = getUsuario().telefono.numero
                Me.internoTextBox.Text = getUsuario().telefono.interno
                Me.prefijoTextBox.Text = getUsuario().telefono.prefijo
            End If
            Me.DataBind()
        End If
    End Sub

    Protected Sub provinciaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.localidadDropDownList.DataSource = BLL.UsuarioBLL.getTiposLocalidades(Integer.Parse(Me.provinciaDropDownList.SelectedValue))
        Me.localidadDropDownList.DataTextField = "descripcion"
        Me.localidadDropDownList.DataValueField = "id"
        Me.localidadDropDownList.DataBind()
    End Sub
End Class