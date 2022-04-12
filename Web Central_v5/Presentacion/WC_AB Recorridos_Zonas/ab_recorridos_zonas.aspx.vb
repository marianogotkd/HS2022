Public Class ab_recorridos_zonas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_dia.Focus()

        End If
    End Sub

    Private Sub BOTON_GRABAR_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABAR.ServerClick
        Try
            Dim opcion As Integer = CInt(txt_dia.Text)
            If opcion > 0 And opcion < 8 Then
                Session("dia_seleccionado") = opcion
                Response.Redirect("~/WC_AB Recorridos_Zonas/ab_recorridos_zonas_activacion.aspx")

            Else
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
            End If





        Catch ex As Exception
            'aqui mensaje de que la opcion es incorrecta.
            ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
        End Try
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        txt_dia.Focus()
    End Sub


    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub txt_dia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dia.Init
        txt_dia.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub LinkButton_domingo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_domingo.Click
        txt_dia.Text = 1
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_lunes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_lunes.Click
        txt_dia.Text = 2
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_martes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_martes.Click
        txt_dia.Text = 3
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_miercoles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_miercoles.Click
        txt_dia.Text = 4
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_Jueves_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_Jueves.Click
        txt_dia.Text = 5
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_viernes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_viernes.Click
        txt_dia.Text = 6
        txt_dia.Focus()
    End Sub

    Private Sub LinkButton_sabado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_sabado.Click
        txt_dia.Text = 7
        txt_dia.Focus()
    End Sub
End Class