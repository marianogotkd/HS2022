Public Class Visor_llaves_report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'este recupera todos los inscriptos y genera las credenciales, tengo que cambiarlos asi solo me genere los que selecciono en el form anterior.
        'uso una variable de session LLAVE para ver que formulario llamar


        Select Case Session("llave")
            Case 2
                Dim dasf As DataTable = Session("dataset_competidores")
                If dasf.Rows.Count <> 0 Then
                    Dim cant As Integer = dasf.Rows.Count
                    'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    'CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/CR_llave2.rpt"))
                    'CrReport.Database.Tables("Llave2").SetDataSource(dasf)
                    'CrystalReportViewer1.ReportSource = CrReport
                End If
            Case 4
                Dim dasf As DataTable = Session("dataset_competidores")
                If dasf.Rows.Count <> 0 Then
                    'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    'CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/CR_llave4.rpt"))
                    'CrReport.Database.Tables("Llave4").SetDataSource(dasf)
                    'CrystalReportViewer1.ReportSource = CrReport
                End If

            Case 8
                Dim dasf As DataTable = Session("dataset_competidores")
                If dasf.Rows.Count <> 0 Then
                    Dim cant As Integer = dasf.Rows.Count
                    'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    'CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/CR_llave8.rpt"))
                    'CrReport.Database.Tables("Llave8").SetDataSource(dasf)
                    'CrystalReportViewer1.ReportSource = CrReport
                Else
                    'Dim ds_inscripciones As DataSet = DAinscripciones.Inscripciones_credenciales_obtener(Session("evento_id"))
                    'credenciales_ds.Tables("Credenciales").Merge(ds_inscripciones.Tables(0))
                    'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    'CrReport.Load(Server.MapPath("~/Credenciales/reportes/Credenciales_1.rpt"))
                    'CrReport.Database.Tables("Credenciales").SetDataSource(credenciales_ds.Tables("Credenciales"))
                    'CrystalReportViewer1.ReportSource = CrReport
                End If
            Case 16
                Dim dasf As DataTable = Session("dataset_competidores")
                If dasf.Rows.Count <> 0 Then
                    'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    'CrReport.Load(Server.MapPath("~/Llaves/Reporte_llaves/CR_llave16.rpt"))
                    'CrReport.Database.Tables("Llave16").SetDataSource(dasf)
                    'CrystalReportViewer1.ReportSource = CrReport
                End If
        End Select
        
    End Sub

End Class