Public Class Credenciales_visor
    Inherits System.Web.UI.Page
    Dim credenciales_ds As New Credenciales_ds
    Dim DAinscripciones As New Capa_de_datos.Inscripciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'este recupera todos los inscriptos y genera las credenciales, tengo que cambiarlos asi solo me genere los que selecciono en el form anterior.
        Dim dasf As DataTable = Session("dataset_cred_seleccionadas")
        If dasf.Rows.Count <> 0 Then
            'Dim cant As Integer = dasf.Rows.Count
            'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            'CrReport.Load(Server.MapPath("~/Credenciales/reportes/Credenciales_2.rpt"))
            'CrReport.Database.Tables("Credenciales_2").SetDataSource(dasf)
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


        
    End Sub

End Class