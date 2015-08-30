Public Class Registro
    Inherits System.Web.UI.Page

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
    End Sub

    Protected Sub provinciaDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.localidadDropDownList.DataSource = BLL.UsuarioBLL.getTiposLocalidades(Me.provinciaDropDownList.SelectedIndex)
        Me.localidadDropDownList.DataTextField = "descripcion"
        Me.localidadDropDownList.DataValueField = "id"
        Me.localidadDropDownList.DataBind()
    End Sub

    Protected Sub registrarseButton_Click(sender As Object, e As EventArgs)
        Dim usr As New BE.UsuarioBE
        usr.apellido = Me.apellidoTextBox.Text
        usr.nombre = Me.nombreTextBox.Text
        usr.password = Me.passTextBox.Text
        usr.mail = Me.mailTextBox.Text
        usr.usuario = Me.usuarioTextBox.Text
        usr.dni = Me.documentoTextBox.Text
        usr.cuil = Me.cuilTextBox.Text
        Dim reg As New BE.DomicilioBE
        reg.calle = Me.calleTextBox.Text
        reg.numero = Me.nroTextBox.Text
        reg.piso = Me.pisoTextBox.Text
        reg.dpto = Me.dptoTextBox.Text
        Dim loc As New BE.LocalidadBE
        loc.id = Me.localidadDropDownList.SelectedIndex
        Dim prov As New BE.ProvinciaBE
        prov.id = Me.provinciaDropDownList.SelectedIndex
        loc.m_ProvinciaBE = prov
        reg.m_LocalidadBE = loc
        usr.domicilio = reg
        Dim tel As New BE.TelefonoBE
        tel.numero = Me.telefonoTextBox.Text
        tel.interno = Me.internoTextBox.Text
        tel.prefijo = Me.prefijoTextBox.Text
        usr.telefono = tel

        BLL.UsuarioBLL.altaCliente(usr)
    End Sub
End Class