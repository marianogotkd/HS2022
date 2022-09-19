Public Class Form_rptprueba
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/rptprueba.rpt"))

    CrReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, String.Concat(Server.MapPath("~"), "/WC_Reportes/asd.pdf"))
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


    '-----------------------------------------------------------------
    'Dim Llaves_ds As New Llaves_ds

    'Dim dato1 As DataTable = Session("datatable_LLAVE_DATOS")
    'Dim dato2 As DataTable = Session("datatable_LLAVE_RESULTADOS")
    'Dim dato3 As DataTable = Session("datatable_LLAVE_2")
    'Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
    'Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
    'Llaves_ds.Tables("LLAVE_2").Merge(Session("datatable_LLAVE_2"))
    'Llaves_ds.Tables("Competidores").Merge(Session("datatable_Competidores"))

    'Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
    'Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
    'Llaves_ds.Tables("LLAVE_2").Merge(Session("datatable_LLAVE_2"))

    '------------------------------------------------------------------
    'CrReport.Database.Tables("LLAVE_2").SetDataSource(dato3)
    'CrReport.Database.Tables("LLAVE_DATOS").SetDataSource(dato1)
    'CrReport.Database.Tables("LLAVE_RESULTADOS").SetDataSource(dato2)
    'CrReport.Database.Tables("Competidores").SetDataSource(Llaves_ds.Tables("Competidores"))

    'CrReport.Database.Tables("Llave2").SetDataSource(dasf)


    'CrystalReportViewer1.ReportSource = CrReport


  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    CrReport.Load(Server.MapPath("~/WC_Reportes/Rpt/rptprueba.rpt"))
    CrReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Context.Response, False, String.Empty)

  End Sub
End Class
