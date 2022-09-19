Public Class Torneo_usuario_add
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DAusuario As New Capa_de_datos.usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            div_modalOK.Visible = False
            div_modal_error.Visible = False
            no_evento.Visible = False
            obtener_eventos_disponibles()
        End If
    End Sub
    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_obtener_torneos()
        If ds_eventos.Tables(0).Rows.Count <> 0 Then
            DropDownEvento.DataSource = ds_eventos.Tables(0)
            DropDownEvento.DataValueField = "id"
            DropDownEvento.DataTextField = "Descripción"
            DropDownEvento.DataBind()

            'con el primer evento seleccionado, voy a recuperar el usuario si existiera.
            Dim ds_usuario As DataSet = DAeventos.UsuarioEvento_obtener_evento(DropDownEvento.SelectedValue)
            If ds_usuario.Tables(0).Rows.Count <> 0 Then
                seccion_usuario_asignado.Visible = True
                GridView1.DataSource = ds_usuario.Tables(0)
                GridView1.DataBind()
            Else
                seccion_usuario_asignado.Visible = False
            End If
        Else
            seccion_evento.Visible = False
            Seccion_usuario.Visible = False
            btn_guardar.Visible = False
            seccion_usuario_asignado.Visible = False
            no_evento.Visible = True
            'choco.Visible = True
            '    Label12.Text = "choquito"
            'ModalPopupExtender1.Show()
        End If
    End Sub

    Private Sub recuperar_usuario()
        'con el primer evento seleccionado, voy a recuperar el usuario si existiera.
        Dim ds_usuario As DataSet = DAeventos.UsuarioEvento_obtener_evento(DropDownEvento.SelectedValue)
        If ds_usuario.Tables(0).Rows.Count <> 0 Then
            seccion_usuario_asignado.Visible = True
            GridView1.DataSource = ds_usuario.Tables(0)
            GridView1.DataBind()
        Else
            seccion_usuario_asignado.Visible = False
        End If
    End Sub

    Private Sub DropDownEvento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownEvento.SelectedIndexChanged
        recuperar_usuario()
    End Sub

    Private Sub btn_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.ServerClick
        If DropDownEvento.Items.Count <> 0 Then
            'valido que el nombre y contraseña sean correcta.
            If tb_nombre.Value <> "" And (tb_contraseña1.Value <> "") And tb_contraseña2.Value <> "" Then
                If tb_contraseña1.Value = tb_contraseña2.Value Then
                    'valido que el nombre de usuario ya no este en la tabla usuario.
                    Dim ds_reg As DataSet = DAusuario.Usuario_validar_registro(tb_nombre.Value, 0) 'el parametro no me interesa por eso mando 0, el script tiene 2 select
                    If ds_reg.Tables(0).Rows.Count = 0 Then
                        'como no existe lo agrego
                        Dim ds_usuario As DataSet = DAeventos.UsuarioEvento_obtener_evento(DropDownEvento.SelectedValue)
                        If ds_usuario.Tables(0).Rows.Count = 0 Then
                            'lo agrego
                            DAeventos.UsuarioEvento_alta(DropDownEvento.SelectedValue, tb_nombre.Value, tb_contraseña1.Value)
                            'aqui reflejo los cambios en la grilla 
                            recuperar_usuario()
                            'muestro un mensaje de operacion correcta.
                            div_modalOK.Visible = True
                            Modal_OK.Show()
                        Else
                            'aqui va un mensaje que diga si esta seguro de remplazar el usuario existente. o sea el que esta en la grilla que se muestra abajo en form.
                            Label_error.Text = "Error, el evento ya posee un usuario."
                            div_modal_error.Visible = True
                            Modal_error.Show()
                        End If
                    Else
                        'mensaje de que existe ese usuario y esta vinculado a un evento
                        Label_error.Text = "Error, el usuario ya se encuentra vinculado a un evento."
                        div_modal_error.Visible = True
                        Modal_error.Show()
                    End If
                Else
                    'poner un  label que diga que deben ser iguales las contraseñas
                    Label_error.Text = "Error, debe ingresar contraseñas válidas."
                    div_modal_error.Visible = True
                    Modal_error.Show()
                End If
            Else
                'poner un label que diga q debe completar la informacion.
                'Label_error.Text = "Error, debe completar la información solicitada."
                'div_modal_error.Visible = True
                'Modal_error.Show()
            End If
        End If
    End Sub

    Private Sub Btb_ok_usuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btb_ok_usuario.Click
        div_modalOK.Visible = False
        Modal_OK.Hide()
    End Sub
End Class