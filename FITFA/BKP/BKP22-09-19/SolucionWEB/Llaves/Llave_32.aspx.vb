Public Class Llave_32
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
        End If
    End Sub

    Private Sub cargar_resultados_competencia()
        If B63.Text <> "" Then
            LB_WINNER.Visible = True
            lb_1st.Text = B63.Text
            If B63.Text = B61.Text Then
                lb_2nd.Text = B62.Text
            Else
                lb_2nd.Text = B61.Text
            End If
            'aqui veo quien es el tercero
            If B57.Text <> "" And B58.Text <> "" Then
                If B57.Text = B61.Text Then
                    lb_3rd_a.Text = B58.Text
                End If
                If B58.Text = B61.Text Then
                    lb_3rd_a.Text = B57.Text
                End If
            End If
            If B59.Text <> "" And B60.Text <> "" Then
                If B59.Text = B62.Text Then
                    lb_3rd_b.Text = B60.Text
                End If
                If B60.Text = B62.Text Then
                    lb_3rd_b.Text = B59.Text
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
                    Case 32
                        If Llave_item_usuario_id <> 0 Then
                            B32.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B32.ToolTip = usuario_id
                        B32.Text = tooltext + idtext
                    Case 33
                        If Llave_item_usuario_id <> 0 Then
                            B33.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B33.ToolTip = usuario_id
                        B33.Text = tooltext + idtext
                    Case 34
                        If Llave_item_usuario_id <> 0 Then
                            B34.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B34.ToolTip = usuario_id
                        B34.Text = tooltext + idtext
                    Case 35
                        If Llave_item_usuario_id <> 0 Then
                            B35.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B35.ToolTip = usuario_id
                        B35.Text = tooltext + idtext
                    Case 36
                        If Llave_item_usuario_id <> 0 Then
                            B36.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B36.ToolTip = usuario_id
                        B36.Text = tooltext + idtext
                    Case 37
                        If Llave_item_usuario_id <> 0 Then
                            B37.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B37.ToolTip = usuario_id
                        B37.Text = tooltext + idtext
                    Case 38
                        If Llave_item_usuario_id <> 0 Then
                            B38.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B38.ToolTip = usuario_id
                        B38.Text = tooltext + idtext
                    Case 39
                        If Llave_item_usuario_id <> 0 Then
                            B39.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B39.ToolTip = usuario_id
                        B39.Text = tooltext + idtext
                    Case 40
                        If Llave_item_usuario_id <> 0 Then
                            B40.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B40.ToolTip = usuario_id
                        B40.Text = tooltext + idtext
                    Case 41
                        If Llave_item_usuario_id <> 0 Then
                            B41.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B41.ToolTip = usuario_id
                        B41.Text = tooltext + idtext
                    Case 42
                        If Llave_item_usuario_id <> 0 Then
                            B42.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B42.ToolTip = usuario_id
                        B42.Text = tooltext + idtext
                    Case 43
                        If Llave_item_usuario_id <> 0 Then
                            B43.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B43.ToolTip = usuario_id
                        B43.Text = tooltext + idtext
                    Case 44
                        If Llave_item_usuario_id <> 0 Then
                            B44.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B44.ToolTip = usuario_id
                        B44.Text = tooltext + idtext
                    Case 45
                        If Llave_item_usuario_id <> 0 Then
                            B45.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B45.ToolTip = usuario_id
                        B45.Text = tooltext + idtext
                    Case 46
                        If Llave_item_usuario_id <> 0 Then
                            B46.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B46.ToolTip = usuario_id
                        B46.Text = tooltext + idtext
                    Case 47
                        If Llave_item_usuario_id <> 0 Then
                            B47.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B47.ToolTip = usuario_id
                        B47.Text = tooltext + idtext
                    Case 48
                        If Llave_item_usuario_id <> 0 Then
                            B48.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B48.ToolTip = usuario_id
                        B48.Text = tooltext + idtext
                    Case 49
                        If Llave_item_usuario_id <> 0 Then
                            B49.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B49.ToolTip = usuario_id
                        B49.Text = tooltext + idtext
                    Case 50
                        If Llave_item_usuario_id <> 0 Then
                            B50.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B50.ToolTip = usuario_id
                        B50.Text = tooltext + idtext
                    Case 51
                        If Llave_item_usuario_id <> 0 Then
                            B51.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B51.ToolTip = usuario_id
                        B51.Text = tooltext + idtext
                    Case 52
                        If Llave_item_usuario_id <> 0 Then
                            B52.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B52.ToolTip = usuario_id
                        B52.Text = tooltext + idtext
                    Case 53
                        If Llave_item_usuario_id <> 0 Then
                            B53.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B53.ToolTip = usuario_id
                        B53.Text = tooltext + idtext
                    Case 54
                        If Llave_item_usuario_id <> 0 Then
                            B54.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B54.ToolTip = usuario_id
                        B54.Text = tooltext + idtext
                    Case 55
                        If Llave_item_usuario_id <> 0 Then
                            B55.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B55.ToolTip = usuario_id
                        B55.Text = tooltext + idtext
                    Case 56
                        If Llave_item_usuario_id <> 0 Then
                            B56.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B56.ToolTip = usuario_id
                        B56.Text = tooltext + idtext
                    Case 57
                        If Llave_item_usuario_id <> 0 Then
                            B57.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B57.ToolTip = usuario_id
                        B57.Text = tooltext + idtext
                    Case 58
                        If Llave_item_usuario_id <> 0 Then
                            B58.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B58.ToolTip = usuario_id
                        B58.Text = tooltext + idtext
                    Case 59
                        If Llave_item_usuario_id <> 0 Then
                            B59.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B59.ToolTip = usuario_id
                        B59.Text = tooltext + idtext
                    Case 60
                        If Llave_item_usuario_id <> 0 Then
                            B60.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B60.ToolTip = usuario_id
                        B60.Text = tooltext + idtext
                    Case 61
                        If Llave_item_usuario_id <> 0 Then
                            B61.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B61.ToolTip = usuario_id
                        B61.Text = tooltext + idtext
                    Case 62
                        If Llave_item_usuario_id <> 0 Then
                            B62.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B62.ToolTip = usuario_id
                        B62.Text = tooltext + idtext
                    Case 63
                        If Llave_item_usuario_id <> 0 Then
                            B63.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext, usuario_id)
                        B63.ToolTip = usuario_id
                        B63.Text = tooltext + idtext
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
        actualizar_llave(B1, B33, B2, 33)
    End Sub

    Private Sub B2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B2.Click
        actualizar_llave(B2, B33, B1, 33)
    End Sub

    Private Sub B3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B3.Click
        actualizar_llave(B3, B34, B4, 34)
    End Sub

    Private Sub B4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B4.Click
        actualizar_llave(B4, B34, B3, 34)
    End Sub

    Private Sub B5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B5.Click
        actualizar_llave(B5, B35, B6, 35)
    End Sub

    Private Sub B6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B6.Click
        actualizar_llave(B6, B35, B5, 35)
    End Sub

    Private Sub B7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B7.Click
        actualizar_llave(B7, B36, B8, 36)
    End Sub

    Private Sub B8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B8.Click
        actualizar_llave(B8, B36, B7, 36)
    End Sub

    Private Sub B9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B9.Click
        actualizar_llave(B9, B37, B10, 37)
    End Sub

    Private Sub B10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B10.Click
        actualizar_llave(B10, B37, B9, 37)
    End Sub

    Private Sub B11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B11.Click
        actualizar_llave(B11, B38, B12, 38)
    End Sub

    Private Sub B12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B12.Click
        actualizar_llave(B12, B38, B11, 38)
    End Sub

    Private Sub B13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B13.Click
        actualizar_llave(B13, B39, B14, 39)
    End Sub

    Private Sub B14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B14.Click
        actualizar_llave(B14, B39, B13, 39)
    End Sub

    Private Sub B15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B15.Click
        actualizar_llave(B15, B40, B16, 40)
    End Sub

    Private Sub B16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B16.Click
        actualizar_llave(B16, B40, B15, 40)
    End Sub

    Private Sub B17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B17.Click
        actualizar_llave(B17, B41, B18, 41)
    End Sub

    Private Sub B18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B18.Click
        actualizar_llave(B18, B41, B17, 41)
    End Sub

    Private Sub B19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B19.Click
        actualizar_llave(B19, B42, B20, 42)
    End Sub

    Private Sub B20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B20.Click
        actualizar_llave(B20, B42, B19, 42)
    End Sub

    Private Sub B21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B21.Click
        actualizar_llave(B21, B43, B22, 43)
    End Sub

    Private Sub B22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B22.Click
        actualizar_llave(B22, B43, B21, 43)
    End Sub

    Private Sub B23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B23.Click
        actualizar_llave(B23, B44, B24, 44)
    End Sub

    Private Sub B24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B24.Click
        actualizar_llave(B24, B44, B23, 44)
    End Sub

    Private Sub B25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B25.Click
        actualizar_llave(B25, B45, B26, 45)
    End Sub

    Private Sub B26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B26.Click
        actualizar_llave(B26, B45, B25, 45)
    End Sub

    Private Sub B27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B27.Click
        actualizar_llave(B27, B46, B28, 46)
    End Sub

    Private Sub B28_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B28.Click
        actualizar_llave(B28, B46, B27, 46)
    End Sub

    Private Sub B29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B29.Click
        actualizar_llave(B29, B47, B30, 47)
    End Sub

    Private Sub B30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B30.Click
        actualizar_llave(B30, B47, B29, 47)
    End Sub

    Private Sub B31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B31.Click
        actualizar_llave(B31, B48, B32, 48)
    End Sub

    Private Sub B32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B32.Click
        actualizar_llave(B32, B48, B31, 48)
    End Sub

    Private Sub B33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B33.Click
        actualizar_llave(B33, B49, B34, 49)
    End Sub

    Private Sub B34_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B34.Click
        actualizar_llave(B34, B49, B33, 49)
    End Sub

    Private Sub B35_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B35.Click
        actualizar_llave(B35, B50, B36, 50)
    End Sub

    Private Sub B36_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B36.Click
        actualizar_llave(B36, B50, B35, 50)
    End Sub

    Private Sub B37_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B37.Click
        actualizar_llave(B37, B51, B38, 51)
    End Sub

    Private Sub B38_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B38.Click
        actualizar_llave(B38, B51, B37, 51)
    End Sub

    Private Sub B39_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B39.Click
        actualizar_llave(B39, B52, B40, 52)
    End Sub

    Private Sub B40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B40.Click
        actualizar_llave(B40, B52, B39, 52)
    End Sub

    Private Sub B41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B41.Click
        actualizar_llave(B41, B53, B42, 53)
    End Sub

    Private Sub B42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B42.Click
        actualizar_llave(B42, B53, B41, 53)
    End Sub

    Private Sub B43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B43.Click
        actualizar_llave(B43, B54, B44, 54)
    End Sub

    Private Sub B44_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B44.Click
        actualizar_llave(B44, B54, B43, 54)
    End Sub

    Private Sub B45_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B45.Click
        actualizar_llave(B45, B55, B46, 55)
    End Sub

    Private Sub B46_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B46.Click
        actualizar_llave(B46, B55, B45, 55)
    End Sub

    Private Sub B47_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B47.Click
        actualizar_llave(B47, B56, B48, 56)
    End Sub

    Private Sub B48_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B48.Click
        actualizar_llave(B48, B56, B47, 56)
    End Sub

    Private Sub B49_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B49.Click
        actualizar_llave(B49, B57, B50, 57)
    End Sub

    Private Sub B50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B50.Click
        actualizar_llave(B50, B57, B49, 57)
    End Sub

    Private Sub B51_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B51.Click
        actualizar_llave(B51, B58, B52, 58)
    End Sub

    Private Sub B52_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B52.Click
        actualizar_llave(B52, B58, B51, 58)
    End Sub

    Private Sub B53_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B53.Click
        actualizar_llave(B53, B59, B54, 59)
    End Sub

    Private Sub B54_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B54.Click
        actualizar_llave(B54, B59, B53, 59)
    End Sub

    Private Sub B55_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B55.Click
        actualizar_llave(B55, B60, B56, 60)
    End Sub

    Private Sub B56_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B56.Click
        actualizar_llave(B56, B60, B55, 60)
    End Sub

    Private Sub B57_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B57.Click
        actualizar_llave(B57, B61, B58, 61)
    End Sub

    Private Sub B58_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B58.Click
        actualizar_llave(B58, B61, B57, 61)
    End Sub

    Private Sub B59_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B59.Click
        actualizar_llave(B59, B62, B60, 62)
    End Sub

    Private Sub B60_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B60.Click
        actualizar_llave(B60, B62, B59, 62)
    End Sub

    Private Sub B61_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B61.Click
        actualizar_llave(B61, B63, B62, 63)
        If B63.Visible = True And (B61.Text <> "") And (B62.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B63.Text
            lb_2nd.Text = B62.Text
            'aqui veo quien es el tercero
            If B57.Text <> "" And B58.Text <> "" Then
                If B57.Text = B61.Text Then
                    lb_3rd_a.Text = B58.Text
                End If
                If B58.Text = B61.Text Then
                    lb_3rd_a.Text = B57.Text
                End If
            End If
            If B59.Text <> "" And B60.Text <> "" Then
                If B59.Text = B62.Text Then
                    lb_3rd_b.Text = B60.Text
                End If
                If B60.Text = B62.Text Then
                    lb_3rd_b.Text = B59.Text
                End If
            End If
        End If
    End Sub

    Private Sub B62_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B62.Click
        actualizar_llave(B62, B63, B61, 63)
        If B63.Visible = True And (B61.Text <> "") And (B62.Text <> "") Then
            LB_WINNER.Visible = True
            lb_1st.Text = B63.Text
            lb_2nd.Text = B61.Text
            'aqui veo quien es el tercero
            If B59.Text <> "" And B60.Text <> "" Then
                If B59.Text = B62.Text Then
                    lb_3rd_a.Text = B60.Text
                End If
                If B60.Text = B62.Text Then
                    lb_3rd_a.Text = B59.Text
                End If
            End If
            If B57.Text <> "" And B58.Text <> "" Then
                If B57.Text = B61.Text Then
                    lb_3rd_b.Text = B58.Text
                End If
                If B58.Text = B61.Text Then
                    lb_3rd_b.Text = B57.Text
                End If
            End If
        End If
    End Sub
End Class