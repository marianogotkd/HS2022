Public Class EventoRPT_inscriptos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(Server.MapPath("~/Eventos/Reportes/Inscriptos.rpt"))

        '-----------------------------------------------------------------
        Dim Ds_rptEventos As New Ds_rptEventos
        Ds_rptEventos.Tables("Inscriptos").Merge(Session("table_inscriptos"))
        Ds_rptEventos.Tables("Evento").Merge(Session("table_Evento"))
        '------------------------------------------------------------------
        CrReport.Database.Tables("Inscriptos").SetDataSource(Ds_rptEventos.Tables("Inscriptos"))
        CrReport.Database.Tables("Evento").SetDataSource(Ds_rptEventos.Tables("Evento"))

        'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
        CrystalReportViewer1.ReportSource = CrReport
    End Sub

End Class