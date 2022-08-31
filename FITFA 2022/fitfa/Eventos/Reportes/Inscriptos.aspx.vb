Public Class Inscriptos1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(Server.MapPath("~/Eventos/Reportes/Inscriptos.rpt"))
        'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
        CrystalReportViewer1.ReportSource = CrReport
    End Sub

End Class