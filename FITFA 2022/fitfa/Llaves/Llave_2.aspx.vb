Public Class Llave_2
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
                            'Dim apenom As String = ""
                            'recuper_nombre_participante(ds_categorias, apenom, Llave_item_usuario_id)
                            'B1.Text = apenom

                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B1.ToolTip = usuario_id 'ojo este lo uso para actualizar en la bd.
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

    Private Sub cargar_resultados_competencia()

        If B3.Text <> "" Then
            lb_1st.Text = B3.Text
            Winners(B3.Text, "1st")

            'veo cual es el segundo
            If B3.Text = B1.Text Then
                'el segundo es b2
                lb_2nd.Text = B2.Text
                Winners(B2.Text, "2nd")
            Else
                lb_2nd.Text = B1.Text
                Winners(B1.Text, "2nd")
            End If
        End If
        'no hay 3ros, porque es una llave de 2
    End Sub

    Private Sub B1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B1.Click
        actualizar_llave(B1, B3, B2, 3)
        If B3.Visible = True Then
            LB_WINNER.Visible = True
            lb_1st.Text = B3.Text
            lb_2nd.Text = B2.Text
            'aqui veo quien es el tercero
            'NO HAY 3 LUGAR
            Winners(B3.Text, "1st")
            Winners(B2.Text, "2nd")

        End If
    End Sub

    Private Sub B2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B2.Click
        actualizar_llave(B2, B3, B1, 3)
        If B3.Visible = True Then
            LB_WINNER.Visible = True
            lb_1st.Text = B3.Text
            lb_2nd.Text = B1.Text
            'aqui veo quien es el tercero
            'NO HAY 3 LUGAR
            Winners(B3.Text, "1st")
            Winners(B1.Text, "2nd")
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


        Llaves_ds.Tables("LLAVE_2").Rows.Clear()

        Dim fila3 As DataRow = Llaves_ds.Tables("LLAVE_2").NewRow
        fila3("B1") = B1.Text
        fila3("B2") = B2.Text
        fila3("B3") = B3.Text
        fila3("ID") = 1
        Llaves_ds.Tables("LLAVE_2").Rows.Add(fila3)

        Llaves_ds.Tables("Competidores").Rows.Clear()
        Dim i As Integer = 0
        While i < GridView_COMPETIDORES.Rows.Count
            Dim fila4 As DataRow = Llaves_ds.Tables("Competidores").NewRow
            fila4("Competidor") = GridView_COMPETIDORES.Rows(i).Cells(0).Text
            fila4("Instructor") = GridView_COMPETIDORES.Rows(i).Cells(1).Text
            Llaves_ds.Tables("Competidores").Rows.Add(fila4)
            i = i + 1
        End While


        Session("op_llave") = "llave 2"
        Session("datatable_LLAVE_DATOS") = Llaves_ds.Tables("LLAVE_DATOS")
        Session("datatable_LLAVE_RESULTADOS") = Llaves_ds.Tables("LLAVE_RESULTADOS")
        Session("datatable_LLAVE_2") = Llaves_ds.Tables("LLAVE_2")
        'Session("datatable_Competidores") = Llaves_ds.Tables("Competidores")

        Response.Redirect("RPTcompetidores_02.aspx")

        'Llaves_reporte_DS.Tables("Llave8").Rows.Clear()

        'Dim row_competidores As DataRow = Llaves_reporte_DS.Tables("Llave2").NewRow
        'row_competidores("B1") = B1.Text
        'row_competidores("B2") = B2.Text
        'row_competidores("B3") = B3.Text
        'row_competidores("1st") = lb_1st.Text
        'row_competidores("2nd") = lb_2nd.Text
        'row_competidores("3rd_a") = lb_3rd_a.Text
        'row_competidores("3rd_b") = lb_3rd_b.Text
        'row_competidores("evento") = Lb_evento.Text
        'row_competidores("fecha_evento") = Lb_fecha.Text
        'row_competidores("categoria") = Lb_categoria.Text
        'Session("llave") = 2
        'Llaves_reporte_DS.Tables("Llave2").Rows.Add(row_competidores)
        'Session("dataset_competidores") = Llaves_reporte_DS.Tables("Llave2")
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

#End Region

End Class