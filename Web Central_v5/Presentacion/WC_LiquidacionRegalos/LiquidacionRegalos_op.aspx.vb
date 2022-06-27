Public Class LiquidacionRegalos_op
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
        Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalosDiario.aspx")
      Case "2"
        Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalosSemanal.aspx")
      Case "3"
        Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalosMensual.aspx")
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

  'AQUI agrego el atributo onfocus y asocio a la rutina js seleccionartexto para que cuando se ponga el foco en un textbox se seleccione todo el contenido
  Private Sub txt_opcion_Init(sender As Object, e As EventArgs) Handles txt_opcion.Init
    txt_opcion.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub LinkButton_diario_Click(sender As Object, e As EventArgs) Handles LinkButton_diario.Click
    Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalosDiario.aspx")
  End Sub

  Private Sub LinkButton_semanal_Click(sender As Object, e As EventArgs) Handles LinkButton_semanal.Click
    Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalosSemanal.aspx")
  End Sub

  Private Sub LinkButton_mensual_Click(sender As Object, e As EventArgs) Handles LinkButton_mensual.Click
    Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalosMensual.aspx")
  End Sub
End Class
