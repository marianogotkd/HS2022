Public Class LiquidacionGrupos_det
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

      Dim DS_liqgrupos As New DS_liqgrupos
      DS_liqgrupos.Tables("LiqGrupos").Merge(Session("Tabla_LiqGrupos"))
      GridView1.DataSource = DS_liqgrupos.Tables("LiqGrupos")
      GridView1.DataBind()



      '----AQUI GENERO REPORTE-------


      DS_liqgrupos.Tables("LiqGrupos_rpt").Merge(Session("Tabla_LiqGrupos_rpt"))
      Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
      CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/LiquidacionGrupos_informe01.rpt"))
      CrReport.Database.Tables("LiqGrupos_rpt").SetDataSource(DS_liqgrupos.Tables("LiqGrupos_rpt"))
      CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/Rpt/LiqGrupos.pdf"))

      '------------------------------

      btn_continuar.Focus()
    End If
  End Sub

  Private Sub btn_continuar_ServerClick(sender As Object, e As EventArgs) Handles btn_continuar.ServerClick
    Response.Redirect("~/Inicio.aspx")
  End Sub
End Class
