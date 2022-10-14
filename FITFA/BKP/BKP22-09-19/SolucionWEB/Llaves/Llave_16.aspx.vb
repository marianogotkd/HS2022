Public Class Llave_16
    Inherits System.Web.UI.Page
    Dim DAllave As New Capa_de_datos.Llave
    Dim categoria_id As Integer = 0
    Dim evento_id As Integer = 0
    Dim llave_id As Integer = 0
    Dim DAinscripcion As New Capa_de_datos.Inscripciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If B31.Text <> "" Then
            LB_WINNER.Visible = True
            lb_1st.Text = B31.Text
            If B31.Text = B29.Text Then
                lb_2nd.Text = B30.Text
            Else
                lb_2nd.Text = B29.Text
            End If
            'aqui veo quien es el tercero
            If B25.Text <> "" And B26.Text <> "" Then
                If B25.Text = B29.Text Then
                    lb_3rd_a.Text = B26.Text
                End If
                If B26.Text = B29.Text Then
                    lb_3rd_a.Text = B25.Text
                End If
            End If
            If B27.Text <> "" And B28.Text <> "" Then
                If B27.Text = B30.Text Then
                    lb_3rd_b.Text = B28.Text
                End If
                If B28.Text = B30.Text Then
                    lb_3rd_b.Text = B27.Text
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
                    Case 16
                        If Llave_item_usuario_id <> 0 Then
                            B16.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B16.ToolTip = usuario_id
                        B16.Text = tooltext + idtext
                    Case 17
                        If Llave_item_usuario_id <> 0 Then
                            B17.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B17.ToolTip = usuario_id
                        B17.Text = tooltext + idtext
                    Case 18
                        If Llave_item_usuario_id <> 0 Then
                            B18.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B18.ToolTip = usuario_id
                        B18.Text = tooltext + idtext
                    Case 19
                        If Llave_item_usuario_id <> 0 Then
                            B19.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B19.ToolTip = usuario_id
                        B19.Text = tooltext + idtext
                    Case 20
                        If Llave_item_usuario_id <> 0 Then
                            B20.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B20.ToolTip = usuario_id
                        B20.Text = tooltext + idtext
                    Case 21
                        If Llave_item_usuario_id <> 0 Then
                            B21.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B21.ToolTip = usuario_id
                        B21.Text = tooltext + idtext
                    Case 22
                        If Llave_item_usuario_id <> 0 Then
                            B22.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B22.ToolTip = usuario_id
                        B22.Text = tooltext + idtext
                    Case 23
                        If Llave_item_usuario_id <> 0 Then
                            B23.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B23.ToolTip = usuario_id
                        B23.Text = tooltext + idtext
                    Case 24
                        If Llave_item_usuario_id <> 0 Then
                            B24.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B24.ToolTip = usuario_id
                        B24.Text = tooltext + idtext
                    Case 25
                        If Llave_item_usuario_id <> 0 Then
                            B25.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B25.ToolTip = usuario_id
                        B25.Text = tooltext + idtext
                    Case 26
                        If Llave_item_usuario_id <> 0 Then
                            B26.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B26.ToolTip = usuario_id
                        B26.Text = tooltext + idtext
                    Case 27
                        If Llave_item_usuario_id <> 0 Then
                            B27.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B27.ToolTip = usuario_id
                        B27.Text = tooltext + idtext
                    Case 28
                        If Llave_item_usuario_id <> 0 Then
                            B28.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B28.ToolTip = usuario_id
                        B28.Text = tooltext + idtext
                    Case 29
                        If Llave_item_usuario_id <> 0 Then
                            B29.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B29.ToolTip = usuario_id
                        B29.Text = tooltext + idtext
                    Case 30
                        If Llave_item_usuario_id <> 0 Then
                            B30.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B30.ToolTip = usuario_id
                        B30.Text = tooltext + idtext
                    Case 31
                        If Llave_item_usuario_id <> 0 Then
                            B31.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B31.ToolTip = usuario_id
                        B31.Text = tooltext + idtext
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
        actualizar_llave(B1, B17, B2, 17)
    End Sub

    Private Sub B2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B2.Click
        actualizar_llave(B2, B17, B1, 17)
    End Sub

    Private Sub B3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B3.Click
        actualizar_llave(B3, B18, B4, 18)
    End Sub

    Private Sub B4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B4.Click
        actualizar_llave(B4, B18, B3, 18)
    End Sub

    Private Sub B5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B5.Click
        actualizar_llave(B5, B19, B6, 19)
    End Sub

    Private Sub B6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B6.Click
        actualizar_llave(B6, B19, B5, 19)
    End Sub

    Private Sub B7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B7.Click
        actualizar_llave(B7, B20, B8, 20)
    End Sub

    Private Sub B8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B8.Click
        actualizar_llave(B8, B20, B7, 20)
    End Sub

    Private Sub B9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B9.Click
        actualizar_llave(B9, B21, B10, 21)
    End Sub

    Private Sub B10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B10.Click
        actualizar_llave(B10, B21, B9, 21)
    End Sub

    Private Sub B11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B11.Click
        actualizar_llave(B11, B22, B12, 22)
    End Sub

    Private Sub B12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B12.Click
        actualizar_llave(B12, B22, B11, 22)
    End Sub

    Private Sub B13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B13.Click
        actualizar_llave(B13, B23, B14, 23)
    End Sub

    Private Sub B14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B14.Click
        actualizar_llave(B14, B23, B13, 23)
    End Sub

    Private Sub B15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B15.Click
        actualizar_llave(B15, B24, B16, 24)
    End Sub

    Private Sub B16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B16.Click
        actualizar_llave(B16, B24, B15, 24)
    End Sub

    Private Sub B17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B17.Click
        actualizar_llave(B17, B25, B18, 25)
    End Sub

    Private Sub B18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B18.Click
        actualizar_llave(B18, B25, B17, 25)
    End Sub

    Private Sub B19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B19.Click
        actualizar_llave(B19, B26, B20, 26)
    End Sub

    Private Sub B20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B20.Click
        actualizar_llave(B20, B26, B19, 26)
    End Sub

    Private Sub B21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B21.Click
        actualizar_llave(B21, B27, B22, 27)
    End Sub

    Private Sub B22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B22.Click
        actualizar_llave(B22, B27, B21, 27)
    End Sub

    Private Sub B23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B23.Click
        actualizar_llave(B23, B28, B24, 28)
    End Sub

    Private Sub B24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B24.Click
        actualizar_llave(B24, B28, B23, 28)
    End Sub

    Private Sub B25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B25.Click
        actualizar_llave(B25, B29, B26, 29)
    End Sub

    Private Sub B26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B26.Click
        actualizar_llave(B26, B29, B25, 29)
    End Sub

    Private Sub B27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B27.Click
        actualizar_llave(B27, B30, B28, 30)
    End Sub

    Private Sub B28_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B28.Click
        actualizar_llave(B28, B30, B27, 30)
    End Sub

    Private Sub B29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B29.Click
        actualizar_llave(B29, B31, B30, 31)
        If B31.Visible = True And (B29.Text <> "") And (B30.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B31.Text
            lb_2nd.Text = B30.Text
            'aqui veo quien es el tercero
            If B25.Text <> "" And B26.Text <> "" Then
                If B25.Text = B29.Text Then
                    lb_3rd_a.Text = B26.Text
                End If
                If B26.Text = B29.Text Then
                    lb_3rd_a.Text = B25.Text
                End If
            End If
            If B27.Text <> "" And B28.Text <> "" Then
                If B27.Text = B30.Text Then
                    lb_3rd_b.Text = B28.Text
                End If
                If B28.Text = B30.Text Then
                    lb_3rd_b.Text = B27.Text
                End If
            End If
        End If
    End Sub

    Private Sub B30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B30.Click
        actualizar_llave(B30, B31, B29, 31)
        If B31.Visible = True And (B29.Text <> "") And (B30.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B31.Text
            lb_2nd.Text = B29.Text
            'aqui veo quien es el tercero
            If B25.Text <> "" And B26.Text <> "" Then
                If B25.Text = B29.Text Then
                    lb_3rd_a.Text = B26.Text
                End If
                If B26.Text = B29.Text Then
                    lb_3rd_a.Text = B25.Text
                End If
            End If
            If B27.Text <> "" And B28.Text <> "" Then
                If B27.Text = B30.Text Then
                    lb_3rd_b.Text = B28.Text
                End If
                If B28.Text = B30.Text Then
                    lb_3rd_b.Text = B27.Text
                End If
            End If
        End If
    End Sub
    Dim Llaves_reporte_DS As New Llaves_reporte_DS
    Private Sub Btn_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_reporte.Click
        Llaves_reporte_DS.Tables("Llave16").Rows.Clear()
        Dim row_competidores As DataRow = Llaves_reporte_DS.Tables("Llave16").NewRow

        row_competidores("B1") = B1.Text
        row_competidores("B2") = B2.Text
        row_competidores("B3") = B3.Text
        row_competidores("B4") = B4.Text
        row_competidores("B5") = B5.Text
        row_competidores("B6") = B6.Text
        row_competidores("B7") = B7.Text
        row_competidores("B8") = B8.Text
        row_competidores("B9") = B9.Text
        row_competidores("B10") = B10.Text
        row_competidores("B11") = B11.Text
        row_competidores("B12") = B12.Text
        row_competidores("B13") = B13.Text
        row_competidores("B14") = B14.Text
        row_competidores("B15") = B15.Text
        row_competidores("B16") = B16.Text
        row_competidores("B17") = B17.Text
        row_competidores("B18") = B18.Text
        row_competidores("B19") = B19.Text
        row_competidores("B20") = B20.Text
        row_competidores("B21") = B21.Text
        row_competidores("B22") = B22.Text
        row_competidores("B23") = B23.Text
        row_competidores("B24") = B24.Text
        row_competidores("B25") = B25.Text
        row_competidores("B26") = B26.Text
        row_competidores("B27") = B27.Text
        row_competidores("B28") = B28.Text
        row_competidores("B29") = B29.Text
        row_competidores("B30") = B30.Text
        row_competidores("B31") = B31.Text
        row_competidores("1st") = lb_1st.Text
        row_competidores("2nd") = lb_2nd.Text
        row_competidores("3rd_a") = lb_3rd_a.Text
        row_competidores("3rd_b") = lb_3rd_b.Text
        row_competidores("evento") = Lb_evento.Text
        row_competidores("fecha_evento") = CDate(Lb_fecha.Text).ToShortDateString
        row_competidores("categoria") = Lb_categoria.Text
        Session("llave") = 16
        Llaves_reporte_DS.Tables("Llave16").Rows.Add(row_competidores)
        Session("dataset_competidores") = Llaves_reporte_DS.Tables("Llave16")
        Response.Redirect("~/Llaves/Reporte_llaves/Visor_llaves_report.aspx")
    End Sub
End Class