Public Class PagosCobrosReclamos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_opcion.Focus()
        End If
    End Sub

    Private Sub btn_retroceder_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retroceder.ServerClick
        Response.Redirect("~/Inicio.aspx")
    End Sub

    Private Sub BOTON_GRABAR_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOTON_GRABAR.ServerClick
        Select Case txt_opcion.Text.ToUpper
            Case "1"
                Response.Redirect("~/WC_Pagos Cobros Reclamos/Reclamo.aspx")
            Case "2"
                Response.Redirect("~/WC_Pagos Cobros Reclamos/Cobro.aspx")
            Case "3"
                Response.Redirect("~/WC_Pagos Cobros Reclamos/Pago.aspx")
            Case "4"
                Response.Redirect("~/WC_Pagos Cobros Reclamos/PagosCobrosReclamos_resumen.aspx")
            Case Else
                ''aqui va mensaje de error.
                'no existe
                ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
        End Select
    End Sub

    Private Sub btn_close_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_close_error.ServerClick
        txt_opcion.Focus()
    End Sub

    Private Sub btn_ok_error_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ok_error.ServerClick
        txt_opcion.Focus()
    End Sub

    'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
    Private Sub txt_opcion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_opcion.Init
        txt_opcion.Attributes.Add("onfocus", "seleccionarTexto(this);")
    End Sub

    Private Sub LinkButton_reclamo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_reclamo.Click
        Response.Redirect("~/WC_Pagos Cobros Reclamos/Reclamo.aspx")
    End Sub

    Private Sub LinkButton_cobro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_cobro.Click
        Response.Redirect("~/WC_Pagos Cobros Reclamos/Cobro.aspx")
    End Sub

    Private Sub LinkButton_pago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_pago.Click
        Response.Redirect("~/WC_Pagos Cobros Reclamos/Pago.aspx")
    End Sub

    Private Sub LinkButton_resumen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_resumen.Click
        Response.Redirect("~/WC_Pagos Cobros Reclamos/PagosCobrosReclamos_resumen.aspx")
    End Sub
End Class