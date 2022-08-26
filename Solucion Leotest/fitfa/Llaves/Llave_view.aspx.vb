Public Class Llave_view
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            Select Case Session("op_llave")
                Case "llave 2"
                    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/Competidores_02.rpt"))

                    '-----------------------------------------------------------------
                    Dim Llaves_ds As New Llaves_ds
                    Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
                    Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
                    Llaves_ds.Tables("LLAVE_2").Merge(Session("datatable_LLAVE_2"))
                    Llaves_ds.Tables("Competidores").Merge(Session("datatable_Competidores"))

                    '------------------------------------------------------------------
                    CrReport.Database.Tables("LLAVE_2").SetDataSource(Llaves_ds.Tables("LLAVE_2"))
                    CrReport.Database.Tables("LLAVE_DATOS").SetDataSource(Llaves_ds.Tables("LLAVE_DATOS"))
                    CrReport.Database.Tables("LLAVE_RESULTADOS").SetDataSource(Llaves_ds.Tables("LLAVE_RESULTADOS"))
                    'CrReport.Database.Tables("Competidores").SetDataSource(Llaves_ds.Tables("Competidores"))

                    'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
                    CrystalReportViewer1.ReportSource = CrReport

                Case "llave 4"
                    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/RPT_llave4.rpt"))

                    '-----------------------------------------------------------------
                    Dim Llaves_ds As New Llaves_ds
                    Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
                    Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
                    Llaves_ds.Tables("LLAVE_4").Merge(Session("datatable_LLAVE_4"))
                    'Llaves_ds.Tables("Competidores").Merge(Session("datatable_Competidores"))


                    '------------------------------------------------------------------
                    CrReport.Database.Tables("LLAVE_DATOS").SetDataSource(Llaves_ds.Tables("LLAVE_DATOS"))
                    CrReport.Database.Tables("LLAVE_4").SetDataSource(Llaves_ds.Tables("LLAVE_4"))
                    CrReport.Database.Tables("LLAVE_RESULTADOS").SetDataSource(Llaves_ds.Tables("LLAVE_RESULTADOS"))
                    'CrReport.Database.Tables("Competidores").SetDataSource(Llaves_ds.Tables("Competidores"))

                    CrystalReportViewer1.ReportSource = CrReport
                Case "llave 8"
                    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/RPT_llave8.rpt"))

                    '-----------------------------------------------------------------
                    Dim Llaves_ds As New Llaves_ds
                    Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
                    Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
                    Llaves_ds.Tables("LLAVE_8").Merge(Session("datatable_LLAVE_8"))
                    'Llaves_ds.Tables("Competidores").Merge(Session("datatable_Competidores"))


                    '------------------------------------------------------------------
                    CrReport.Database.Tables("LLAVE_DATOS").SetDataSource(Llaves_ds.Tables("LLAVE_DATOS"))
                    CrReport.Database.Tables("LLAVE_8").SetDataSource(Llaves_ds.Tables("LLAVE_8"))
                    CrReport.Database.Tables("LLAVE_RESULTADOS").SetDataSource(Llaves_ds.Tables("LLAVE_RESULTADOS"))
                    'CrReport.Database.Tables("Competidores").SetDataSource(Llaves_ds.Tables("Competidores"))
                    'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
                    CrystalReportViewer1.ReportSource = CrReport
                Case "llave 8 solo competidores"
                    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/RPT_Competidores.rpt"))

                    '-----------------------------------------------------------------
                    Dim Llaves_ds As New Llaves_ds
                    'Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
                    'Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
                    'Llaves_ds.Tables("LLAVE_8").Merge(Session("datatable_LLAVE_8"))
                    Llaves_ds.Tables("Competidores").Merge(Session("datatable_Competidores"))


                    '------------------------------------------------------------------
                    'CrReport.Database.Tables("LLAVE_DATOS").SetDataSource(Llaves_ds.Tables("LLAVE_DATOS"))
                    'CrReport.Database.Tables("LLAVE_8").SetDataSource(Llaves_ds.Tables("LLAVE_8"))
                    'CrReport.Database.Tables("LLAVE_RESULTADOS").SetDataSource(Llaves_ds.Tables("LLAVE_RESULTADOS"))
                    CrReport.Database.Tables("Competidores").SetDataSource(Llaves_ds.Tables("Competidores"))
                    'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
                    CrystalReportViewer1.ReportSource = CrReport
                Case "llave 16"
                    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/RPT_llave16.rpt"))

                    '-----------------------------------------------------------------
                    Dim Llaves_ds As New Llaves_ds
                    Llaves_ds.Tables("LLAVE_DATOS").Merge(Session("datatable_LLAVE_DATOS"))
                    Llaves_ds.Tables("LLAVE_RESULTADOS").Merge(Session("datatable_LLAVE_RESULTADOS"))
                    Llaves_ds.Tables("LLAVE_16").Merge(Session("datatable_LLAVE_16"))
                    Llaves_ds.Tables("Competidores").Merge(Session("datatable_Competidores"))


                    '------------------------------------------------------------------
                    CrReport.Database.Tables("LLAVE_DATOS").SetDataSource(Llaves_ds.Tables("LLAVE_DATOS"))
                    CrReport.Database.Tables("LLAVE_16").SetDataSource(Llaves_ds.Tables("LLAVE_16"))
                    CrReport.Database.Tables("LLAVE_RESULTADOS").SetDataSource(Llaves_ds.Tables("LLAVE_RESULTADOS"))
                    CrReport.Database.Tables("Competidores").SetDataSource(Llaves_ds.Tables("Competidores"))
                    'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
                    CrystalReportViewer1.ReportSource = CrReport
                Case "llave 32"
            End Select

        End If

    End Sub

End Class