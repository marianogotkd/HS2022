Public Class Reporte_independiente
    Inherits System.Web.UI.Page
    Dim Ds_Reporte_inscripciones As New Ds_Reporte_inscripciones 'lo uso para crear los datatable necesarios para mandar al rpt de crystal que corresponda
    Dim DAreporte As New Capa_de_datos.Reportes
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds_busqueda As DataSet = DAreporte.Reporte_listado_inscriptos(23, 33)

        'aqui empiezo a cargar los datos en los dataset q tengo creado en el diseñador
        If ds_busqueda.Tables(2).Rows.Count <> 0 Then 'la tabla 2 trae datos del instructor
            Dim row_instructor As DataRow = Ds_Reporte_inscripciones.Tables("Instructor").NewRow()
            row_instructor("Instructor_apenom") = ds_busqueda.Tables(2).Rows(0).Item("Instructor_apenom")
            row_instructor("usuario_doc") = ds_busqueda.Tables(2).Rows(0).Item("usuario_doc")
            row_instructor("graduacion_desc") = ds_busqueda.Tables(2).Rows(0).Item("graduacion_desc")
            Ds_Reporte_inscripciones.Tables("Instructor").Rows.Add(row_instructor)

            'CrReport.Database.Tables("Instructor").SetDataSource(Ds_Reporte_inscripciones.Tables("Instructor"))



            'CrystalReportSource1.ReportDocument.SetDataSource(Ds_Reporte_inscripciones.Tables("Instructor"))
            'CrystalReportViewer1.DataBind()
        End If
    End Sub

End Class