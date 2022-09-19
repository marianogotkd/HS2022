Public Class TicketsClieRegenerar
  Inherits System.Web.UI.Page

#Region "DECLARACIONES"
  Dim DAparametro As New Capa_Datos.WC_parametro

#End Region

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

      Txt_fecha.Focus 

    End If
  End Sub


  Private Sub btn_retroceder_ServerClick(sender As Object, e As EventArgs) Handles btn_retroceder.ServerClick
    Response.Redirect("~/WC_TicketsClientes/TicketsClientes_op1.aspx")
  End Sub

  Private Sub BOTON_GRABA_ServerClick(sender As Object, e As EventArgs) Handles BOTON_GRABA.ServerClick
    Dim valido = "si"
    Try
      Txt_fecha.Text = CDate(Txt_fecha.Text)
      Dim fecha_base As Date = CDate("01/01/1900")
      If Txt_fecha.Text < fecha_base Then
        valido = "no"
      End If
    Catch ex As Exception
      valido = "no"
    End Try


    If valido = "si" Then
      Dim ds_liq As DataSet = DAparametro.Parametro_consultar_fecha(CDate(Txt_fecha.Text))
      If ds_liq.Tables(0).Rows.Count <> 0 Then
        'verifico que el registro recuperado tenga estado="Inactivo"
        Dim estado = ds_liq.Tables(0).Rows(0).Item("Estado")
        If estado = "Inactivo" Then
          'redirecciono al proximo formulario

          Session("Fecha_regenerar") = CDate(Txt_fecha.Text)
          Response.Redirect("~/WC_TicketsClientes/TicketsClieRegenerar_op.aspx")

        Else

          'no hay liquidacion para esa fecha.
          ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
        End If

      Else
        'no hay liquidacion para esa fecha.
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
      End If
    Else
      'error, ingrese fecha valida.
      ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error2", "$(document).ready(function () {$('#modal-ok_error2').modal();});", True)
    End If


  End Sub

  Private Sub btn_error_close_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close.ServerClick
    Txt_fecha.Focus()
  End Sub

  Private Sub btn_ok_error_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error.ServerClick
    Txt_fecha.Focus()
  End Sub

  Private Sub btn_error_close2_ServerClick(sender As Object, e As EventArgs) Handles btn_error_close2.ServerClick
    Txt_fecha.Focus()
  End Sub

  Private Sub btn_ok_error2_ServerClick(sender As Object, e As EventArgs) Handles btn_ok_error2.ServerClick
    Txt_fecha.Focus()
  End Sub
End Class
