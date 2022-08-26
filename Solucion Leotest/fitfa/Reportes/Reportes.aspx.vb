Public Class Reportes
    Inherits System.Web.UI.Page
    Dim DAreporte As New Capa_de_datos.Reportes
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim Ds_Reporte_inscripciones As New Ds_Reporte_inscripciones 'lo uso para crear los datatable necesarios para mandar al rpt de crystal que corresponda
    Dim DAinstructor As New Capa_de_datos.Instructor
    Dim DAusuario As New Capa_de_datos.usuario
    Dim ds_alumnos As DataSet
    Dim ds_instructores As New DataSet_miembros
    Dim ds_a As New DataSet_miembros 'este conjunto de datos lo creo en la solucion. en la carpeta miembros
    Dim ds_instructor_id As DataSet
    Dim instructor_id
    Dim usu_id

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       



        If Not IsPostBack Then
            obterner_Instructores()
            obtener_eventos_disponibles()
        End If




    End Sub

    Private Sub obterner_Instructores()
        Session("Us_recursivo") = Session("Us_id")
        Dim usuario_id As Integer = Session("Us_id")
        ds_alumnos = DAinstructor.Instructor_obtener_alumnos(usuario_id)
        If ds_alumnos.Tables(0).Rows.Count <> 0 Then
            ds_a.Tabla_alumnos.Merge(ds_alumnos.Tables(0))

            'GridView1.DataSource = ds_a.Tabla_alumnos
            'GridView1.DataBind()



            'cargar_fotos_miembros_ultimos(ds_alumnos) 'la rutina la comente, x q no tengo el diseño html...buscar en txt
            'aqui deberia llamar a la rutina que me cargue todos los instructores, que son alumnos DIRECTOS e INDIRECTOS del instructor logueado
            '1) primero cargo al instructor logueado.
            Dim row As DataRow = ds_instructores.Tables("Instructores").NewRow()
            row("usuario_id") = usuario_id
            row("Apenom") = ds_alumnos.Tables(1).Rows(0).Item("ApellidoyNombre")
            ds_instructores.Tables("Instructores").Rows.Add(row)
            Traer_instructores(usuario_id)
            Dim ds_ordenado As DataView = New DataView(ds_instructores.Tables("Instructores"))
            ds_ordenado.Sort = "Apenom"
            DropDown_instructor.DataSource = ds_ordenado
            DropDown_instructor.DataTextField = "Apenom"
            DropDown_instructor.DataValueField = "usuario_id"
            DropDown_instructor.DataBind()
            'selecciono primero, el usuario logueado
            DropDown_instructor.SelectedValue = usuario_id
        Else
            'ds_a.Tabla_alumnos.Rows.Add()
            'ds_a.Tabla_alumnos.Rows.Add()
            'ds_a.Tabla_alumnos.Rows.Add()
            'GridView1.DataSource = ds_a.Tabla_alumnos
            'GridView1.DataBind()
        End If
    End Sub

    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_ObetenerEventos()
        If ds_eventos.Tables(0).Rows.Count <> 0 Then
            DropDown_Evento.DataSource = ds_eventos.Tables(0)
            DropDown_Evento.DataValueField = "evento_id"
            DropDown_Evento.DataTextField = "evento_descripcion"
            DropDown_Evento.DataBind()
        End If
    End Sub

    Private Sub Traer_instructores(ByVal usuario_id As Integer)
        'esta rutina trae todos los instructores q son alumnos del instructor logueado, para ello deben estar activo, usuario tipo=instructor,
        'se traen TODOS, directos e indirectos x igual.
        '1) primero cargamos al usuario
        Dim ds_inst As DataSet = DAinstructor.Instructor_obtener_instructores(usuario_id)
        If ds_inst.Tables(0).Rows.Count <> 0 Then
            ds_instructores.Tables("Instructores").Merge(ds_inst.Tables(0))
            Dim i As Integer = 0
            While i < ds_inst.Tables(0).Rows.Count
                Traer_instructores(ds_inst.Tables(0).Rows(i).Item("usuario_id")) 'se llama asi mismo...recursivo
                i = i + 1
            End While
        End If
    End Sub



    Private Sub btn_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.Click

        ds_instructor_id = DAinstructor.Instructor_Obtener_Mi_ID_de_Instructor(DropDown_instructor.SelectedValue)
        instructor_id = ds_instructor_id.Tables(0).Rows(0).Item("instructor_id")



        Dim ds_inscripciones As DataSet = DAreporte.Reporte_obtener_Inscriptos_Toreno_Instructor(DropDown_Evento.SelectedValue, instructor_id)
        ''credenciales_ds.Tables("Credenciales").Merge(ds_inscripciones.Tables(0))
        If ds_inscripciones.Tables(0).Rows.Count <> 0 Then
            GridView1.DataSource = ds_inscripciones.Tables(0)
            GridView1.DataBind()

            Label_cant.Text = (ds_inscripciones.Tables(0).Rows.Count)
            label_torneo.Visible = True
            Label17.Visible = True
            label1.Visible = True
            Label_cant.Visible = True
            div_grid.Visible = True
            lbl_err.Visible = False
        Else
            div_grid.Visible = False
            lbl_err.Visible = True

        End If


        ''PARA HACER DESPUES''''''''

        'Dim ds_busqueda As DataSet = DAreporte.Reporte_listado_inscriptos(CInt(DropDown_instructor.SelectedValue), CInt(DropDown_Evento.SelectedValue))

        ''aqui empiezo a cargar los datos en los dataset q tengo creado en el diseñador
        'If ds_busqueda.Tables(2).Rows.Count <> 0 Then 'la tabla 2 trae datos del instructor
        '    Dim row_instructor As DataRow = Ds_Reporte_inscripciones.Tables("Instructor").NewRow()
        '    row_instructor("Instructor_apenom") = ds_busqueda.Tables(2).Rows(0).Item("Instructor_apenom")
        '    row_instructor("usuario_doc") = ds_busqueda.Tables(2).Rows(0).Item("usuario_doc")
        '    row_instructor("graduacion_desc") = ds_busqueda.Tables(2).Rows(0).Item("graduacion_desc")
        '    Ds_Reporte_inscripciones.Tables("Instructor").Rows.Add(row_instructor)

        '    'cargo en el gridview los inscriptos
        '    'hay q concatenar en una variable la "Categoria"
        '    If ds_busqueda.Tables(0).Rows.Count <> 0 Then
        '        Dim i As Integer = 0
        '        Dim j As Integer = 0
        '        Dim Cat = ""




        '        While i < ds_busqueda.Tables(0).Rows.Count

        '            'busco graduacion desde
        '            Dim graduacion As String = ""
        '            Dim k As Integer = 0
        '            While k < ds_busqueda.Tables(1).Rows.Count
        '                If (ds_busqueda.Tables(1).Rows(k).Item("graduacion_id") = ds_busqueda.Tables(0).Rows(i).Item("graduacion_id")) Then
        '                    graduacion = ds_busqueda.Tables(1).Rows(k).Item("graduacion_desc")
        '                    k = ds_busqueda.Tables(1).Rows.Count
        '                End If
        '                k = k + 1
        '            End While

        '            If Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").Rows.Count = 0 Then







        '                Dim row_insc As DataRow = Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").NewRow()
        '                row_insc("usuario_id") = ds_busqueda.Tables(0).Rows(i).Item("usuario_id")
        '                row_insc("ApellidoyNombre") = ds_busqueda.Tables(0).Rows(i).Item("ApellidoyNombre")
        '                row_insc("Edad") = ds_busqueda.Tables(0).Rows(i).Item("Edad")
        '                row_insc("categoria_sexo") = ds_busqueda.Tables(0).Rows(i).Item("categoria_sexo")
        '                row_insc("graduacion") = graduacion
        '                row_insc("Categoria") = ds_busqueda.Tables(0).Rows(i).Item("categoria_tipo")



        '                'aqui obtengo la categoria
        '                Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").Rows.Add(row_insc)



        '            Else
        '                Dim var = "Agregar"
        '                j = 0

        '                While j < Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").Rows.Count

        '                    If Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").Rows(j).Item("usuario_id") = ds_busqueda.Tables(0).Rows(i).Item("usuario_id") Then
        '                        'Actualizo
        '                        var = "No Agrego"
        '                        Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").Rows(j).Item("categoria") = "Lucha/Forma"
        '                        j = Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").Rows.Count
        '                    Else
        '                        Cat = ""
        '                    End If
        '                    j = j + 1
        '                End While
        '                If var = "Agregar" Then
        '                    Dim row_insc As DataRow = Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").NewRow()
        '                     row_insc("usuario_id") = ds_busqueda.Tables(0).Rows(i).Item("usuario_id")
        '                    row_insc("ApellidoyNombre") = ds_busqueda.Tables(0).Rows(i).Item("ApellidoyNombre")
        '                    row_insc("Edad") = ds_busqueda.Tables(0).Rows(i).Item("Edad")
        '                    row_insc("categoria_sexo") = ds_busqueda.Tables(0).Rows(i).Item("categoria_sexo")
        '                    row_insc("graduacion") = graduacion
        '                    row_insc("Categoria") = ds_busqueda.Tables(0).Rows(i).Item("categoria_tipo")



        '                    'aqui obtengo la categoria
        '                    Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos").Rows.Add(row_insc)

        '                End If

        '            End If

        '            i = i + 1


        '        End While



        '        GridView2.DataSource = Ds_Reporte_inscripciones.Tables("Instructor_Inscriptos")
        '        GridView2.DataBind()




        '    End If



        '    'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    '' Asigno el reporte
        '    'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        '    'CrReport.Load("/../Reportes/Inscripciones/Instructor_alum_inscriptos.rpt")

        '    'CrReport.Database.Tables("Instructor").SetDataSource(Ds_Reporte_inscripciones.Tables("Instructor"))

        '    'CrystalReportViewer1.ReportSource = CrReport




        '    'ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        '    'ReportViewer1.LocalReport.ReportEmbeddedResource = "..\Inscripciones\Instructor_alum_inscriptos.rpt"
        '    ''ReportViewer1.LocalReport.DataSources.Clear()
        '    'Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource("Instructor", Ds_Reporte_inscripciones.Tables("Instructor"))
        '    'ReportViewer1.LocalReport.DataSources.Add(rds)





        '    'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        '    '' Asigno el reporte
        '    'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        '    'CrReport.Load("\..\Reportes\Inscripciones\Instructor_alum_inscriptos.rpt")

        '    'CrReport.Database.Tables("Instructor").SetDataSource(Ds_Reporte_inscripciones.Tables("Instructor"))


        '    'ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local

        '    'ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local

        '    'ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "..\Inscripciones\Instructor_alum_inscriptos.rpt"

        '    'ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Instructor", Ds_Reporte_inscripciones.Tables("Instructor")))
        '    'ReportViewer1.LocalReport.ReportEmbeddedResource = "Instructor_alum_inscriptos.rpt"



        '    'ReportViewer1.LocalReport.DataSources.Clear()
        '    'ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("PruebaDs_PruebaDT", Ds.Tables(0)))

        '    'ReportViewer1.DocumentMapCollapsed = True





        '    'ReportViewer1.LocalReport.DataSources.Clear()
        '    'ReportViewer1.LocalReport.DataSources.Add()
        '    'Reporte.CrystalReportViewer1.ReportSource = CrReport




        'End If



    End Sub

    Private Sub DropDown_Evento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_Evento.SelectedIndexChanged
        label_torneo.Text = DropDown_Evento.SelectedItem.ToString

    End Sub

    Private Sub DropDown_instructor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_instructor.SelectedIndexChanged
        usu_id = DropDown_instructor.SelectedValue
    End Sub
End Class