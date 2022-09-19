Public Class LiquidacionRegalosDiario
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro
#End Region

#Region "EVENTOS"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      'VALIDACION: Verificar en BD cual es el dia de la ultima liquidacion en tabla PARAMETRO, donde el campo Estado= "Inactivo"
      Dim ds_parametro As DataSet = DAparametro.Parametro_consultar_ultliq
      If ds_parametro.Tables(0).Rows.Count <> 0 Then
        HF_parametro_id.Value = ds_parametro.Tables(0).Rows(0).Item("Parametro_id")
        HF_fecha.Value = ds_parametro.Tables(0).Rows(0).Item("Fecha")
        Dim FECHA As Date = CDate(ds_parametro.Tables(0).Rows(0).Item("Fecha"))
        Label_fecha.Text = FECHA.ToString("dd-MM-yyyy")
        Txt_OP.Focus()
      Else
        'error, no hay liquidacion completada
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
      End If
    End If
  End Sub

  Private Sub btn_ok_error_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub btn_error_close_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub

  Private Sub Txt_OP_Init(sender As Object, e As EventArgs) Handles Txt_OP.Init
    Txt_OP.Attributes.Add("onfocus", "seleccionarTexto(this);")
  End Sub

  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalos_op.aspx")
  End Sub

  Private Sub btn_grabar_ServerClick(sender As Object, e As EventArgs) Handles btn_grabar.ServerClick
    If Txt_OP.Text.ToUpper = "OK" Then
      Response.Redirect("~/WC_LiquidacionRegalos/LiquidacionRegalosDiario_det.aspx")
    Else
      'error
      Txt_OP.Focus()
    End If
  End Sub
#End Region

#Region "METODOS"


#End Region





End Class
