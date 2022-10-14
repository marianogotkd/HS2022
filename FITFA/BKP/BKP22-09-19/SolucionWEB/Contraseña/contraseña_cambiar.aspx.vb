Public Class contraseña_cambiar
    Inherits System.Web.UI.Page

    Dim DAusuario As New Capa_de_datos.usuario


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.ServerClick

        div_registro_guardado.Visible = False
        label_error_pass_actual.Text = "error!"
        label_contraseña1_error_.Text = "error!"
        label_contraseña2_error.Text = "error!"
        div_pass_actual_error.Visible = False
        div_contraseña1_error.Visible = False
        div_contraseña2_error.Visible = False

        Dim valido As String = "si"
        If txt_contraseña_actual.Text = "" Then
            valido = "no"
            div_pass_actual_error.Visible = True
        End If

        If txt_contraseñanueva1.Text = "" Then
            valido = "no"
            div_contraseña1_error.Visible = True
        End If
        If txt_contraseñanueva2.Text = "" Then
            valido = "no"
            div_contraseña2_error.Visible = True
        End If
        If txt_contraseñanueva1.Text <> txt_contraseñanueva2.Text Then
            valido = "no"
            div_contraseña1_error.Visible = True
            label_contraseña1_error_.Text = "error! la contraseña debe ser igual"
            div_contraseña2_error.Visible = True
            label_contraseña2_error.Text = "error! la contraseña debe ser igual"
        End If
        If valido = "si" Then
            'aqui valido que la contraseña actual sea correcta.
            Dim usuario_id As Integer = Session("Us_id")
            Dim ds_pass As DataSet = DAusuario.Usuario_validar_contraseña(usuario_id, txt_contraseña_actual.Text)
            If ds_pass.Tables(0).Rows.Count <> 0 Then
                'aqui actualizo.
                DAusuario.Usuario_actualizar_contraseña(Session("Us_id"), txt_contraseñanueva1.Text)
                div_registro_guardado.Visible = True
            Else
                'no son iguales las contraseñas
                div_pass_actual_error.Visible = True
                label_error_pass_actual.Text = "error! la contraseña actual es incorrecta"
            End If
        End If
    End Sub
End Class