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
            Me.nombreTextBox.Text = getUsuario().nombre
            Me.apellidoTextBox.Text = getUsuario().apellido

            Me.passTextBox.Text = getUsuario().password
            Me.mailTextBox.Text = getUsuario().mail
            Me.usuarioTextBox.Text = getUsuario().usuario
            Me.documentoTextBox.Text = getUsuario().dni
            Me.cuilTextBox.Text = getUsuario().cuil
            Me.tipoDocDropDownList.SelectedValue = getUsuario().tipoDoc.id
            Me.calleTextBox.Text = getUsuario().domicilio.calle
            Me.nroTextBox.Text
            Me.pisoTextBox.Text
            Me.dptoTextBox.Text
            loc.m_ProvinciaBE = prov
            reg.m_LocalidadBE = loc
            usr.domicilio = reg
            Me.telefonoTextBox.Text
            Me.internoTextBox.Text
            Me.prefijoTextBox.Text

            Me.DataBind()

            'Me.nombreTextBox.Text = usuario.nombre
            'Me.nombreTextBox.Text = usuario.nombre
            'Me.nombreTextBox.Text = usuario.nombre
            'Me.nombreTextBox.Text = usuario.nombre
            'Me.nombreTextBox.Text = usuario.nombre
            'Me.nombreTextBox.Text = usuario.nombre
            'Me.nombreTextBox.Text = usuario.nombre
            'Me.nombreTextBox.Text = usuario.nombre
        End If
    End Sub

    Protected Sub provinciaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.localidadDropDownList.DataSource = BLL.UsuarioBLL.getTiposLocalidades(Integer.Parse(Me.provinciaDropDownList.SelectedValue))
        Me.localidadDropDownList.DataTextField = "descripcion"
        Me.localidadDropDownList.DataValueField = "id"
        Me.localidadDropDownList.DataBind()
    End Sub
End Class