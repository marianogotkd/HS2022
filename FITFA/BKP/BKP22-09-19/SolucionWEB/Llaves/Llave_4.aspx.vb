Public Class Llave_4
    Inherits System.Web.UI.Page
    Dim DAllave As New Capa_de_datos.Llave
    Dim DAinscripcion As New Capa_de_datos.Inscripciones
    Dim categoria_id As Integer = 0
    Dim evento_id As Integer = 0
    Dim llave_id As Integer = 0
    Private Sub Llave_4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'guardar en variable el id del evento y la id de la categoria para recuperar inscriptos en la llave
        If Not IsPostBack Then
            categoria_id = Session("categoria_id")
            evento_id = Session("evento_id")
            llave_id = Session("llave_id")
            llenar_encabezados(evento_id, categoria_id, llave_id)
            seccion_competencia.Visible = False
            cargar_resultados_competencia()
        End If

    End Sub

    Private Sub cargar_resultados_competencia()
        'carga en la grilla
        If B7.Text <> "" Then
            LB_WINNER.Visible = True
            lb_1st.Text = B7.Text

            If B7.Text = B5.Text Then
                lb_2nd.Text = B6.Text
            Else
                lb_2nd.Text = B5.Text
            End If
            'aqui veo quien es el tercero
            If B1.Text <> "" And B2.Text <> "" Then
                If B1.Text = B5.Text Then
                    lb_3rd_a.Text = B2.Text
                End If
                If B2.Text = B5.Text Then
                    lb_3rd_a.Text = B1.Text
                End If
            End If
            If B3.Text <> "" And B4.Text <> "" Then
                If B3.Text = B6.Text Then
                    lb_3rd_b.Text = B4.Text
                End If
                If B4.Text = B6.Text Then
                    lb_3rd_b.Text = B3.Text
                End If
            End If
        End If
    End Sub

    Private Sub llenar_encabezados(ByVal evento_id As Integer, ByVal categoria_id As Integer, ByVal llave_id As Integer)
        Dim ds_categorias As DataSet = DAllave.LLave_obtener_llavegenerada_etc_2(llave_id)
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
                End Select
                i = i + 1
            End While


        End If
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
        actualizar_llave(B1, B5, B2, 5)
    End Sub

    Private Sub B2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B2.Click
        actualizar_llave(B2, B5, B1, 5)
    End Sub

    Private Sub B3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B3.Click
        actualizar_llave(B3, B6, B4, 6)
    End Sub

    Private Sub B4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B4.Click
        actualizar_llave(B4, B6, B3, 6)
    End Sub

    Private Sub B5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B5.Click
        actualizar_llave(B5, B7, B6, 7)
        If B7.Visible = True And (B5.Text <> "") And (B6.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B7.Text
            lb_2nd.Text = B6.Text
            'aqui veo quien es el tercero
            If B1.Text <> "" And B2.Text <> "" Then
                If B1.Text = B5.Text Then
                    lb_3rd_a.Text = B2.Text
                End If
                If B2.Text = B5.Text Then
                    lb_3rd_a.Text = B1.Text
                End If
            End If
            If B3.Text <> "" And B4.Text <> "" Then
                If B3.Text = B6.Text Then
                    lb_3rd_b.Text = B4.Text
                End If
                If B4.Text = B6.Text Then
                    lb_3rd_b.Text = B3.Text
                End If
            End If
        End If
    End Sub

    Private Sub B6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B6.Click
        actualizar_llave(B6, B7, B5, 7)
        If B7.Visible = True And (B5.Text <> "") And (B6.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B7.Text
            lb_2nd.Text = B5.Text
            'aqui veo quien es el tercero
            If B1.Text <> "" And B2.Text <> "" Then
                If B1.Text = B5.Text Then
                    lb_3rd_a.Text = B2.Text
                End If
                If B2.Text = B5.Text Then
                    lb_3rd_a.Text = B1.Text
                End If
            End If
            If B3.Text <> "" And B4.Text <> "" Then
                If B3.Text = B6.Text Then
                    lb_3rd_b.Text = B4.Text
                End If
                If B4.Text = B6.Text Then
                    lb_3rd_b.Text = B3.Text
                End If
            End If
        End If
    End Sub
    Dim Llaves_reporte_DS As New Llaves_reporte_DS
    Private Sub Btn_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_reporte.Click
        Llaves_reporte_DS.Tables("Llave4").Rows.Clear()

        Dim row_competidores As DataRow = Llaves_reporte_DS.Tables("Llave4").NewRow

        row_competidores("B1") = B1.Text
        row_competidores("B2") = B2.Text
        row_competidores("B3") = B3.Text
        row_competidores("B4") = B4.Text
        row_competidores("B5") = B5.Text
        row_competidores("B6") = B6.Text
        row_competidores("B7") = B7.Text
        row_competidores("1st") = lb_1st.Text
        row_competidores("2nd") = lb_2nd.Text
        row_competidores("3rd_a") = lb_3rd_a.Text
        row_competidores("3rd_b") = lb_3rd_b.Text
        row_competidores("evento") = Lb_evento.Text
        row_competidores("fecha_evento") = CDate(Lb_fecha.Text).ToShortDateString
        row_competidores("categoria") = Lb_categoria.Text
        Session("llave") = 4
        Llaves_reporte_DS.Tables("Llave4").Rows.Add(row_competidores)
        Session("dataset_competidores") = Llaves_reporte_DS.Tables("Llave4")
        Response.Redirect("~/Llaves/Reporte_llaves/Visor_llaves_report.aspx")


    End Sub
End Class