Public Class Listados_DeLosQueGanan
  Inherits System.Web.UI.Page
  Dim DApatrametro As New Capa_Datos.WC_parametro
  Dim DAListados As New Capa_Datos.Listados
  Dim DS_Listados As New DS_Listados

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      Dim ds_ultliq As DataSet = DApatrametro.Parametro_consultar_ultliq
      If ds_ultliq.Tables(0).Rows.Count <> 0 Then
        'hay ultima liquidacion
        Dim FECHA As Date = CDate(ds_ultliq.Tables(0).Rows(0).Item("Fecha"))
        HF_fecha.Value = FECHA

        LABEL_FECHA_actual.Text = Today.ToString("dd/MM/yyyy")
        LABEL_fecha_parametro.Text = FECHA.ToString("dd-MM-yyyy")
        HF_fecha_actual.Value = CDate(Now)

        Dim ds_ClieGanan As DataSet = DAListados.Listado_ClientesGanan(HF_fecha.Value)
        If ds_ClieGanan.Tables(0).Rows.Count <> 0 Then
          Generar_Reporte(ds_ClieGanan)


          btn_continuar.Focus()
        Else
          'error, no hay liquidacion completada
          ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)
        End If

      Else
        'mensaje
        'error, no hay liquidacion completada
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "modal-ok_error", "$(document).ready(function () {$('#modal-ok_error').modal();});", True)

      End If




    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub


  Private Sub Generar_Reporte(ByRef ds_ClieGanan As DataSet)
    'voy a agregar el corte con el total.

    DS_Listados.Tables("DeLosQueGanan").Merge(ds_ClieGanan.Tables(0))

    Dim Total As Decimal = 0
    Dim j As Integer = 0
    While j < ds_ClieGanan.Tables(0).Rows.Count
      Try
        Total = Total + ds_ClieGanan.Tables(0).Rows(j).Item("Gana")
      Catch ex As Exception

      End Try
      j = j + 1
    End While
    Dim fila As DataRow = DS_Listados.Tables("DeLosQueGanan").NewRow
    fila("Nombre") = "TOTAL GENERAL:"
    fila("Gana") = (Math.Round(Total, 2).ToString("N2"))
    DS_Listados.Tables("DeLosQueGanan").Rows.Add(fila)

    GridView1.DataSource = DS_Listados.Tables("DeLosQueGanan")
    GridView1.DataBind()

    'AQUI REPORTE..........
    Dim fila2 As DataRow = DS_Listados.Tables("DeLosQueGanan_info").NewRow
    fila2("Fecha") = CDate(HF_fecha_actual.Value)
    fila2("Fecha_liq") = CDate(HF_fecha.Value)
    DS_Listados.Tables("DeLosQueGanan_info").Rows.Add(fila2)
    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/ListadoDeLosQueGanan_informe01.rpt"))
    CrReport.Database.Tables("DeLosQueGanan_info").SetDataSource(DS_Listados.Tables("DeLosQueGanan_info"))
    CrReport.Database.Tables("DeLosQueGanan").SetDataSource(DS_Listados.Tables("DeLosQueGanan"))

    CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/ListadoDeLosQueGanan.pdf"))


  End Sub

End Class
