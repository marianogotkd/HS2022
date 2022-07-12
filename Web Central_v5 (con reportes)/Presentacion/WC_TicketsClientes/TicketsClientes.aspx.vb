Public Class TicketsClientes
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      txt_opcion.Focus()
    End If
  End Sub

  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub BOTON_GRABAR_ServerClick(sender As Object, e As EventArgs) Handles BOTON_GRABAR.ServerClick
    Select Case txt_opcion.Text.ToUpper
      Case "1"
        Response.Redirect("~/WC_TicketsClientes/TicketsClientes_op1.aspx")
      Case "2"
        'Response.Redirect("~/WC_Pagos Cobros Reclamos/Cobro.aspx")

      Case Else
        ''aqui va mensaje de error.
        'no existe
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-sm_error", "$(document).ready(function () {$('#modal-sm_error').modal();});", True)
    End Select
  End Sub

  Private Sub btn_close_error_ServerClick(sender As Object, e As EventArgs) Handles btn_close_error.ServerClick
    txt_opcion.Focus()
  End Sub

  Private Sub btn_ok_error_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error.ServerClick
    txt_opcion.Focus()
  End Sub

  Private Sub txt_opcion_Init(sender As Object, e As EventArgs) Handles txt_opcion.Init
    txt_opcion.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub LinkButton_GenerarArchivos_Click(sender As Object, e As EventArgs) Handles LinkButton_GenerarArchivos.Click
    Response.Redirect("~/WC_TicketsClientes/TicketsClientes_op1.aspx")
  End Sub

  Private Sub LinkButton_Imprimir_Click(sender As Object, e As EventArgs) Handles LinkButton_Imprimir.Click
    'Response.Redirect("~/WC_Pagos Cobros Reclamos/Reclamo.aspx")
  End Sub
End Class
