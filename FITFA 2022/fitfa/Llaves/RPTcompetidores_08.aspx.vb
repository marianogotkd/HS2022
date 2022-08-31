Public Class RPTcompetidores_08
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/Competidores_08.rpt"))

        '-----------------------------------------------------------------
        'Dim Llaves_ds As New Llaves_ds

        Dim dato1 As DataTable = Session("datatable_LLAVE_DATOS")
        Dim dato2 As DataTable = Session("datatable_LLAVE_RESULTADOS")
        Dim dato3 As DataTable = Session("datatable_LLAVE_8")
        'Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
        'Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
        'Llaves_ds.Tables("LLAVE_2").Merge(Session("datatable_LLAVE_2"))
        'Llaves_ds.Tables("Competidores").Merge(Session("datatable_Competidores"))

        'Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
        'Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
        'Llaves_ds.Tables("LLAVE_2").Merge(Session("datatable_LLAVE_2"))

        '------------------------------------------------------------------
        CrReport.Database.Tables("LLAVE_8").SetDataSource(dato3)
        CrReport.Database.Tables("LLAVE_DATOS").SetDataSource(dato1)
        CrReport.Database.Tables("LLAVE_RESULTADOS").SetDataSource(dato2)
        'CrReport.Database.Tables("Competidores").SetDataSource(Llaves_ds.Tables("Competidores"))

        'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
        CrystalReportViewer1.ReportSource = CrReport
    End Sub

End Class