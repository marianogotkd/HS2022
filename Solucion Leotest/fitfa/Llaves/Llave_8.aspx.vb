﻿Public Class Llave_8
    Inherits System.Web.UI.Page
    Dim DAllave As New Capa_de_datos.Llave
    Dim DAinscripcion As New Capa_de_datos.Inscripciones
    Dim categoria_id As Integer = 0
    Dim evento_id As Integer = 0
    Dim llave_id As Integer = 0
    Dim Llaves_ds As New Llaves_ds
    Dim DAinstructor As New Capa_de_datos.Instructor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            categoria_id = Session("categoria_id")
            evento_id = Session("evento_id")
            llave_id = Session("llave_id")
            llenar_encabezados(evento_id, categoria_id, llave_id)
            seccion_competencia.Visible = True
            'primero genero la tabla resultados con 4 registros.
            crear_tabla_resultados()

            cargar_resultados_competencia()
        End If
    End Sub

    Private Sub crear_tabla_resultados()
        Dim fila1 As DataRow = Llaves_ds.Tables("RESULTADOS").NewRow
        fila1("Puesto") = "1st"
        fila1("Competidor") = "..."

        Llaves_ds.Tables("RESULTADOS").Rows.Add(fila1)

        Dim fila2 As DataRow = Llaves_ds.Tables("RESULTADOS").NewRow
        fila2("Puesto") = "2nd"
        fila2("Competidor") = "..."

        Llaves_ds.Tables("RESULTADOS").Rows.Add(fila2)

        Dim fila3 As DataRow = Llaves_ds.Tables("RESULTADOS").NewRow
        fila3("Puesto") = "3rd"
        fila3("Competidor") = "..."

        Llaves_ds.Tables("RESULTADOS").Rows.Add(fila3)

        Dim fila4 As DataRow = Llaves_ds.Tables("RESULTADOS").NewRow
        fila4("Puesto") = "3rd"
        fila4("Competidor") = "..."

        Llaves_ds.Tables("RESULTADOS").Rows.Add(fila4)

        GridView_RESULTADOS.DataSource = Llaves_ds.Tables("RESULTADOS")
        GridView_RESULTADOS.DataBind()
    End Sub

    Private Sub cargar_resultados_competencia()
        If B15.Text <> "" Then
            LB_WINNER.Visible = True
            lb_1st.Text = B15.Text
            Winners(B15.Text, "1st")
            If B15.Text = B13.Text Then
                lb_2nd.Text = B14.Text
                Winners(B14.Text, "2nd")
            Else
                lb_2nd.Text = B13.Text
                Winners(B13.Text, "2nd")
            End If
            'aqui veo quien es el tercero
            If B9.Text <> "" And B10.Text <> "" Then
                If B9.Text = B13.Text Then
                    lb_3rd_a.Text = B10.Text
                    Winners(B10.Text, "3rd")
                End If
                If B10.Text = B13.Text Then
                    lb_3rd_a.Text = B9.Text
                    Winners(B9.Text, "3rd")
                End If
            End If
            If B11.Text <> "" And B12.Text <> "" Then
                If B11.Text = B14.Text Then
                    lb_3rd_b.Text = B12.Text
                    Winners(B12.Text, "4th")
                End If
                If B12.Text = B14.Text Then
                    lb_3rd_b.Text = B11.Text
                    Winners(B11.Text, "4th")
                End If
            End If
        End If

    End Sub

    Private Sub llenar_encabezados(ByVal evento_id As Integer, ByVal categoria_id As Integer, ByVal llave_id As Integer)
        Dim ds_categorias As DataSet = DAllave.LLave_obtener_llavegenerada_etc_2(llave_id)

        Cargar_ListadoCompetidores(ds_categorias)

        Lb_evento.Text = ds_categorias.Tables(0).Rows(0).Item("evento_descripcion")
        Lb_fecha.Text = ds_categorias.Tables(0).Rows(0).Item("evento_fecha")
        Lb_fecha_cierre.Text = ds_categorias.Tables(0).Rows(0).Item("evento_fechacierre")
        'aqui cargo el label lb_categoria
        'Dim ds_categorias As DataSet = DAllave.LLave_obtener_inscriptos(evento_id)
        If ds_categorias.Tables(0).Rows.Count <> 0 Then
            Dim tipo As String = ds_categorias.Tables(0).Rows(0).Item("categoria_tipo")
            Dim graduacion_desde As String = ""
            Dim k As Integer = 0
            While k < ds_categorias.Tables(1).Rows.Count 'tabla q tiene las graduaciones
                If (ds_categorias.Tables(1).Rows(k).Item("graduacion_id") = ds_categorias.Tables(0).Rows(0).Item("categoria_gradinicial")) Then
                    graduacion_desde = ds_categorias.Tables(1).Rows(k).Item("graduacion_desc")
                    k = ds_categorias.Tables(1).Rows.Count
                End If
                k = k + 1
            End While
            Dim graduacion_hasta As String = ""
            k = 0
            While k < ds_categorias.Tables(1).Rows.Count 'tabla que tiene las graduaciones
                If ds_categorias.Tables(1).Rows(k).Item("graduacion_id") = ds_categorias.Tables(0).Rows(0).Item("categoria_gradfinal") Then
                    graduacion_hasta = ds_categorias.Tables(1).Rows(k).Item("graduacion_desc")
                    k = ds_categorias.Tables(1).Rows.Count
                End If
                k = k + 1
            End While
            Dim edad_desde As String = ds_categorias.Tables(0).Rows(0).Item("categoria_edadinicial")
            Dim edad_hasta As String = ds_categorias.Tables(0).Rows(0).Item("categoria_edadfinal")
            Dim sexo As String = ds_categorias.Tables(0).Rows(0).Item("categoria_sexo")
            Dim peso_inicial As String = ds_categorias.Tables(0).Rows(0).Item("categoria_peso_inical")
            Dim peso_final As String = ds_categorias.Tables(0).Rows(0).Item("categoria_peso_Final")
            'ahora junto todas las variables para mostrar en categoria
            Dim categoria As String = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
            If tipo = "Lucha" Then
                categoria = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)" + " de " + peso_inicial + " a " + peso_final + " Kilos"
            End If
            Lb_categoria.Text = "Categoria: " + categoria

            'ahora pongo en visible solo los botones dependiendo de los inscriptos
            Dim i As Integer = 0
            While i < ds_categorias.Tables(2).Rows.Count
                Dim item_nro As Integer = CInt(ds_categorias.Tables(2).Rows(i).Item("Llave_item_Numero"))
                Dim Llave_item_usuario_id As Integer = CInt(ds_categorias.Tables(2).Rows(i).Item("Llave_item_usuario_id"))

                Dim usuario_id As Integer = 0 'esta variable se va actualizando en la rutina: colocar_tooltrip
                Dim tooltext As String = ""
                Dim idtext As String = ""
                Select Case item_nro
                    Case 1
                        If Llave_item_usuario_id <> 0 Then
                            B1.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B1.ToolTip = usuario_id
                        B1.Text = tooltext + idtext
                    Case 2
                        If Llave_item_usuario_id <> 0 Then
                            B2.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B2.ToolTip = usuario_id
                        B2.Text = tooltext + idtext
                    Case 3
                        If Llave_item_usuario_id <> 0 Then
                            B3.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B3.ToolTip = usuario_id
                        B3.Text = tooltext + idtext
                    Case 4
                        If Llave_item_usuario_id <> 0 Then
                            B4.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B4.ToolTip = usuario_id
                        B4.Text = tooltext + idtext
                    Case 5
                        If Llave_item_usuario_id <> 0 Then
                            B5.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B5.ToolTip = usuario_id
                        B5.Text = tooltext + idtext
                    Case 6
                        If Llave_item_usuario_id <> 0 Then
                            B6.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B6.ToolTip = usuario_id
                        B6.Text = tooltext + idtext
                    Case 7
                        If Llave_item_usuario_id <> 0 Then
                            B7.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B7.ToolTip = usuario_id
                        B7.Text = tooltext + idtext
                    Case 8
                        If Llave_item_usuario_id <> 0 Then
                            B8.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B8.ToolTip = usuario_id
                        B8.Text = tooltext + idtext
                    Case 9
                        If Llave_item_usuario_id <> 0 Then
                            B9.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B9.ToolTip = usuario_id
                        B9.Text = tooltext + idtext
                    Case 10
                        If Llave_item_usuario_id <> 0 Then
                            B10.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B10.ToolTip = usuario_id
                        B10.Text = tooltext + idtext
                    Case 11
                        If Llave_item_usuario_id <> 0 Then
                            B11.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B11.ToolTip = usuario_id
                        B11.Text = tooltext + idtext
                    Case 12
                        If Llave_item_usuario_id <> 0 Then
                            B12.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B12.ToolTip = usuario_id
                        B12.Text = tooltext + idtext
                    Case 13
                        If Llave_item_usuario_id <> 0 Then
                            B13.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B13.ToolTip = usuario_id
                        B13.Text = tooltext + idtext
                    Case 14
                        If Llave_item_usuario_id <> 0 Then
                            B14.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B14.ToolTip = usuario_id
                        B14.Text = tooltext + idtext
                    Case 15
                        If Llave_item_usuario_id <> 0 Then
                            B15.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B15.ToolTip = usuario_id
                        B15.Text = tooltext + idtext
                End Select
                i = i + 1
            End While

        End If
    End Sub

    Private Sub Cargar_ListadoCompetidores(ByVal ds_categorias As DataSet)

        Dim i As Integer = 0
        While i < ds_categorias.Tables(3).Rows.Count

            Dim ds_inscripcion As DataSet = DAinscripcion.inscripcion_recuperar_ID(ds_categorias.Tables(3).Rows(i).Item("usuario_id"))
            Dim idtext As String = "(" + CStr(ds_inscripcion.Tables(0).Rows(0).Item("inscripcion_id")) + ")"
            Dim Competidor As String = ds_categorias.Tables(3).Rows(i).Item("apenom") + idtext


            Dim instructor_id As Integer = ds_categorias.Tables(3).Rows(i).Item("instructor_id")
            Dim ds_instr As DataSet = DAinstructor.Instructor_obtener_INFO(instructor_id)
            Dim Datos_Instructor As String = ds_instr.Tables(0).Rows(0).Item("ApellidoyNombre") + " (Dni:" + CStr(ds_instr.Tables(0).Rows(0).Item("usuario_doc")) + ")"

            'veo si ya existen en el table("Competidores")
            Dim j As Integer = 0
            Dim existe = "no"
            While j < Llaves_ds.Tables("Competidores").Rows.Count
                If Competidor = Llaves_ds.Tables("Competidores").Rows(j).Item("Competidor") Then
                    existe = "si"
                    Exit While
                End If
                j = j + 1
            End While
            If existe = "no" Then
                'agrego
                Dim fila As DataRow = Llaves_ds.Tables("Competidores").NewRow
                fila("Competidor") = Competidor
                fila("Instructor") = Datos_Instructor
                Llaves_ds.Tables("Competidores").Rows.Add(fila)
            End If

            i = i + 1
        End While
        GridView_COMPETIDORES.DataSource = Llaves_ds.Tables("Competidores")
        GridView_COMPETIDORES.DataBind()

    End Sub

    Private Sub recuper_nombre_participante(ByVal ds_categorias As DataSet, ByRef apenom As String, ByVal Llave_item_usuario_id As Integer)

        Dim i As Integer = 0
        While i < ds_categorias.Tables(2).Rows.Count
            If CInt(ds_categorias.Tables(2).Rows(i).Item("Llave_item_usuario_id")) = Llave_item_usuario_id Then
                apenom = ds_categorias.Tables(2).Rows(i).Item("apenom")
                i = ds_categorias.Tables(2).Rows.Count
            End If
            i = i + 1
        End While
    End Sub

    Private Sub colocar_tooltrip(ByVal Boton As Button, ByVal ds As DataSet, ByVal item_nro As Integer, ByRef tooltext As String, ByRef idtext As String, ByRef usuario_id As Integer)
        Dim i As Integer = 0
        While i < ds.Tables(3).Rows.Count
            If ds.Tables(3).Rows(i).Item("Llave_item_Numero") = item_nro Then
                tooltext = ds.Tables(3).Rows(i).Item("apenom")
                Dim ds_inscripcion As DataSet = DAinscripcion.inscripcion_recuperar_ID(ds.Tables(3).Rows(i).Item("usuario_id"))
                idtext = "(" + CStr(ds_inscripcion.Tables(0).Rows(0).Item("inscripcion_id")) + ")"
                usuario_id = ds.Tables(3).Rows(i).Item("usuario_id")
                i = ds.Tables(3).Rows.Count
            End If
            i = i + 1
        End While

    End Sub

    Private Sub actualizar_llave(ByRef boton_desde As Button, ByRef boton_hasta As Button, ByRef boton_versus As Button, ByVal nro As Integer)

        If boton_desde.Text <> "" And boton_versus.Text <> "" Then
            If boton_versus.Visible = True Then
                boton_hasta.Visible = True
                boton_hasta.Text = boton_desde.Text
                boton_hasta.ToolTip = boton_desde.ToolTip
                'actualizo en la bd, el tooltip me da el id del usuario.
                'nro es el numero de nodo
                Dim ds_categorias As DataSet = DAllave.LLave_obtener_llavegenerada_etc_2(Session("llave_id"))
                Dim i As Integer = 0
                While i < ds_categorias.Tables(2).Rows.Count
                    If ds_categorias.Tables(2).Rows(i).Item("Llave_item_Numero") = nro Then
                        'aqui actualizo en bd
                        Dim llave_item_id As Integer = ds_categorias.Tables(2).Rows(i).Item("Llave_item_id")
                        DAllave.Llave_item_actualizar_progreso(llave_item_id, CInt(boton_desde.ToolTip))
                        i = ds_categorias.Tables(2).Rows.Count
                    End If
                    i = i + 1
                End While
            End If
        End If


    End Sub





    Private Sub B1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B1.Click
        actualizar_llave(B1, B9, B2, 9)
    End Sub

    Private Sub B2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B2.Click
        actualizar_llave(B2, B9, B1, 9)
    End Sub

    Private Sub B3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B3.Click
        actualizar_llave(B3, B10, B4, 10)
    End Sub

    Private Sub B4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B4.Click
        actualizar_llave(B4, B10, B3, 10)
    End Sub

    Private Sub B5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B5.Click
        actualizar_llave(B5, B11, B6, 11)
    End Sub

    Private Sub B6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B6.Click
        actualizar_llave(B6, B11, B5, 11)
    End Sub

    Private Sub B7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B7.Click
        actualizar_llave(B7, B12, B8, 12)
    End Sub

    Private Sub B8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B8.Click
        actualizar_llave(B8, B12, B7, 12)
    End Sub

    Private Sub B9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B9.Click
        actualizar_llave(B9, B13, B10, 13)
    End Sub

    Private Sub B10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B10.Click
        actualizar_llave(B10, B13, B9, 13)
    End Sub

    Private Sub B11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B11.Click
        actualizar_llave(B11, B14, B12, 14)
    End Sub

    Private Sub B12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B12.Click
        actualizar_llave(B12, B14, B11, 14)
    End Sub

    Private Sub B13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B13.Click
        actualizar_llave(B13, B15, B14, 15)
        If (B15.Visible = True) And (B13.Text <> "") And (B14.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B15.Text
            Winners(B15.Text, "1st")
            lb_2nd.Text = B14.Text
            Winners(B14.Text, "2nd")
            'aqui veo quien es el tercero
            If B9.Text <> "" And B10.Text <> "" Then
                If B9.Text = B13.Text Then
                    lb_3rd_a.Text = B10.Text
                    Winners(B10.Text, "3rd")
                End If
                If B10.Text = B13.Text Then
                    lb_3rd_a.Text = B9.Text
                    Winners(B9.Text, "3rd")
                End If
            End If
            If B11.Text <> "" And B12.Text <> "" Then
                If B11.Text = B14.Text Then
                    lb_3rd_b.Text = B12.Text
                    Winners(B12.Text, "4th")
                End If
                If B12.Text = B14.Text Then
                    lb_3rd_b.Text = B11.Text
                    Winners(B11.Text, "4th")
                End If
            End If
        End If


    End Sub

    Private Sub B14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B14.Click
        actualizar_llave(B14, B15, B13, 15)
        If B15.Visible = True And (B13.Text <> "") And (B14.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B15.Text
            Winners(B15.Text, "1st")
            lb_2nd.Text = B13.Text
            Winners(B13.Text, "2nd")
            'aqui veo quien es el tercero
            If B9.Text <> "" And B10.Text <> "" Then
                If B9.Text = B13.Text Then
                    lb_3rd_a.Text = B10.Text
                    Winners(B10.Text, "3rd")
                End If
                If B10.Text = B13.Text Then
                    lb_3rd_a.Text = B9.Text
                    Winners(B9.Text, "3rd")
                End If
            End If
            If B11.Text <> "" And B12.Text <> "" Then
                If B11.Text = B14.Text Then
                    lb_3rd_b.Text = B12.Text
                    Winners(B12.Text, "4th")
                End If
                If B12.Text = B14.Text Then
                    lb_3rd_b.Text = B11.Text
                    Winners(B11.Text, "4th")
                End If
            End If

        End If
    End Sub
    Dim Llaves_reporte_DS As New Llaves_reporte_DS
    Private Sub Btn_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_reporte.Click
        Llaves_ds.Tables("LLAVE_DATOS").Rows.Clear()
        Dim fila1 As DataRow = Llaves_ds.Tables("LLAVE_DATOS").NewRow
        fila1("Evento") = Lb_evento.Text
        fila1("Fecha") = CDate(Lb_fecha.Text)
        fila1("Categoria") = Lb_categoria.Text
        fila1("Cant_Inscriptos") = GridView_COMPETIDORES.Rows.Count
        fila1("ID") = 1
        Llaves_ds.Tables("LLAVE_DATOS").Rows.Add(fila1)

        Llaves_ds.Tables("LLAVE_RESULTADOS").Rows.Clear()
        Dim fila2 As DataRow = Llaves_ds.Tables("LLAVE_RESULTADOS").NewRow
        fila2("1st") = GridView_RESULTADOS.Rows(0).Cells(1).Text
        fila2("2nd") = GridView_RESULTADOS.Rows(1).Cells(1).Text
        fila2("3rd_a") = GridView_RESULTADOS.Rows(2).Cells(1).Text
        fila2("3rd_b") = GridView_RESULTADOS.Rows(3).Cells(1).Text
        fila2("ID") = 1
        Llaves_ds.Tables("LLAVE_RESULTADOS").Rows.Add(fila2)


        Llaves_ds.Tables("LLAVE_8").Rows.Clear()

        Dim fila3 As DataRow = Llaves_ds.Tables("LLAVE_8").NewRow
        fila3("B1") = B1.Text
        fila3("B2") = B2.Text
        fila3("B3") = B3.Text
        fila3("B4") = B4.Text
        fila3("B5") = B5.Text
        fila3("B6") = B6.Text
        fila3("B7") = B7.Text
        fila3("B8") = B8.Text
        fila3("B9") = B9.Text
        fila3("B10") = B10.Text
        fila3("B11") = B11.Text
        fila3("B12") = B12.Text
        fila3("B13") = B13.Text
        fila3("B14") = B14.Text
        fila3("B15") = B15.Text
        fila3("ID") = 1
        Llaves_ds.Tables("LLAVE_8").Rows.Add(fila3)

        Llaves_ds.Tables("Competidores").Rows.Clear()
        Dim i As Integer = 0
        While i < GridView_COMPETIDORES.Rows.Count
            Dim fila4 As DataRow = Llaves_ds.Tables("Competidores").NewRow
            fila4("Competidor") = GridView_COMPETIDORES.Rows(i).Cells(0).Text
            fila4("Instructor") = GridView_COMPETIDORES.Rows(i).Cells(1).Text
            Llaves_ds.Tables("Competidores").Rows.Add(fila4)
            i = i + 1
        End While


        Session("op_llave") = "llave 8"
        Session("datatable_LLAVE_DATOS") = Llaves_ds.Tables("LLAVE_DATOS")
        Session("datatable_LLAVE_RESULTADOS") = Llaves_ds.Tables("LLAVE_RESULTADOS")
        Session("datatable_LLAVE_8") = Llaves_ds.Tables("LLAVE_8")
        'Session("datatable_Competidores") = Llaves_ds.Tables("Competidores")

        Response.Redirect("RPTcompetidores_08.aspx")


        'Llaves_reporte_DS.Tables("Llave8").Rows.Clear()


        'Dim row_competidores As DataRow = Llaves_reporte_DS.Tables("Llave8").NewRow

        'row_competidores("B1") = B1.Text
        'row_competidores("B2") = B2.Text
        'row_competidores("B3") = B3.Text
        'row_competidores("B4") = B4.Text
        'row_competidores("B5") = B5.Text
        'row_competidores("B6") = B6.Text
        'row_competidores("B7") = B7.Text
        'row_competidores("B8") = B8.Text
        'row_competidores("B9") = B9.Text
        'row_competidores("B10") = B10.Text
        'row_competidores("B11") = B11.Text
        'row_competidores("B12") = B12.Text
        'row_competidores("B13") = B13.Text
        'row_competidores("B14") = B14.Text
        'row_competidores("B15") = B15.Text
        'row_competidores("1st") = lb_1st.Text
        'row_competidores("2nd") = lb_2nd.Text
        'row_competidores("3rd_a") = lb_3rd_a.Text
        'row_competidores("3rd_b") = lb_3rd_b.Text
        'row_competidores("evento") = Lb_evento.Text
        'row_competidores("fecha_evento") = CDate(Lb_fecha.Text).ToShortDateString
        'row_competidores("categoria") = Lb_categoria.Text
        'Session("llave") = 8
        'Llaves_reporte_DS.Tables("Llave8").Rows.Add(row_competidores)
        'Session("dataset_competidores") = Llaves_reporte_DS.Tables("Llave8")
        'Response.Redirect("~/Llaves/Reporte_llaves/Visor_llaves_report.aspx")

    End Sub

#Region "WINNER"

    Private Sub Winners(ByVal competidor As String, ByVal puesto As String)
        Select Case puesto
            Case "1st"
                GridView_RESULTADOS.Rows(0).Cells(1).Text = competidor

            Case "2nd"
                GridView_RESULTADOS.Rows(1).Cells(1).Text = competidor


            Case "3rd"
                GridView_RESULTADOS.Rows(2).Cells(1).Text = competidor

            Case "4th"
                GridView_RESULTADOS.Rows(3).Cells(1).Text = competidor

        End Select
        'NOTA: CUANDO QUIERO AGREGAR LA INFO DEL INSTRUCTOR, ESO SE RECUPERA DE LA TABLA COMPETIDORES...Y NOTE QUE CUANDO EL NOMBRE TIENE ALGUN ACENTO SE MUESTRAN CARACTERES RAROS, X ESTA MISMA RAZON CUANDO COMPARO CON LA TABLA COMPETIDORES, NO LO ENCUENTRO NUNCA AL COMPETIDOR...DECIDI QUITAR DE LA TABLA RESULTADOS LA COLUMNA INSTRUCTOR


    End Sub

    Private Sub Button_rptCompetidores_Click(sender As Object, e As EventArgs) Handles Button_rptCompetidores.Click
        Llaves_ds.Tables("Competidores").Rows.Clear()
        Dim i As Integer = 0
        While i < GridView_COMPETIDORES.Rows.Count
            Dim fila4 As DataRow = Llaves_ds.Tables("Competidores").NewRow
            fila4("Competidor") = GridView_COMPETIDORES.Rows(i).Cells(0).Text
            fila4("Instructor") = GridView_COMPETIDORES.Rows(i).Cells(1).Text
            Llaves_ds.Tables("Competidores").Rows.Add(fila4)
            i = i + 1
        End While


        Session("op_llave") = "llave 8 solo competidores"
        'Session("datatable_LLAVE_DATOS") = Llaves_ds.Tables("LLAVE_DATOS")
        'Session("datatable_LLAVE_RESULTADOS") = Llaves_ds.Tables("LLAVE_RESULTADOS")
        'Session("datatable_LLAVE_8") = Llaves_ds.Tables("LLAVE_8")
        Session("datatable_Competidores") = Llaves_ds.Tables("Competidores")

        Response.Redirect("Llave_view.aspx")
    End Sub

#End Region

End Class