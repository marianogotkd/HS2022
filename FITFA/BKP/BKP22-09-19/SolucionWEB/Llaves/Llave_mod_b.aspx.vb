Public Class Llave_mod_b
    Inherits System.Web.UI.Page
    Dim DAllave As New Capa_de_datos.Llave
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'guardar en variable el id del evento y la id de la categoria para recuperar inscriptos en la llave
        If Not IsPostBack Then
            Dim categoria_id As Integer = Session("categoria_id")
            Dim evento_id As Integer = Session("evento_id")
            llenar_encabezados(evento_id, categoria_id)
            seccion_competencia.Visible = False
        End If



    End Sub

    Private Sub llenar_encabezados(ByVal evento_id As Integer, ByVal categoria_id As Integer)
        Dim ds_categorias As DataSet = DAllave.LLave_obtener_llavegenerada_etc(evento_id, categoria_id)
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
            'ahora junto todas las variables para mostrar en categoria
            Dim categoria As String = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
            Lb_categoria.Text = "Categoria: " + categoria

            'ahora pongo en visible solo los botones dependiendo de los inscriptos
            Dim i As Integer = 0
            While i < ds_categorias.Tables(2).Rows.Count
                Dim item_nro As Integer = CInt(ds_categorias.Tables(2).Rows(i).Item("Llave_item_Numero"))
                Dim Llave_item_usuario_id As Integer = CInt(ds_categorias.Tables(2).Rows(i).Item("Llave_item_usuario_id"))

                Dim tooltext As String = ""
                Dim idtext As String = "0000"
                Select Case item_nro
                    Case 1
                        If Llave_item_usuario_id <> 0 Then
                            B1.Visible = True
                            'Dim apenom As String = ""
                            'recuper_nombre_participante(ds_categorias, apenom, Llave_item_usuario_id)
                            'B1.Text = apenom

                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B1.ToolTip = idtext
                        B1.Text = tooltext
                    Case 2
                        If Llave_item_usuario_id <> 0 Then
                            B2.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B2.ToolTip = idtext
                        B2.Text = tooltext
                    Case 3
                        If Llave_item_usuario_id <> 0 Then
                            B3.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B3.ToolTip = idtext
                        B3.Text = tooltext
                    Case 4
                        If Llave_item_usuario_id <> 0 Then
                            B4.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B4.ToolTip = idtext
                        B4.Text = tooltext
                    Case 5
                        If Llave_item_usuario_id <> 0 Then
                            B5.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B5.ToolTip = idtext
                        B5.Text = tooltext
                    Case 6
                        If Llave_item_usuario_id <> 0 Then
                            B6.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B6.ToolTip = idtext
                        B6.Text = tooltext
                    Case 7
                        If Llave_item_usuario_id <> 0 Then
                            B7.Visible = True
                        End If

                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B7.ToolTip = idtext
                        B7.Text = tooltext
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

    Private Sub colocar_tooltrip(ByVal Boton As Button, ByVal ds As DataSet, ByVal item_nro As Integer, ByRef tooltext As String, ByRef idtext As String)
        Dim i As Integer = 0
        While i < ds.Tables(3).Rows.Count
            If ds.Tables(3).Rows(i).Item("Llave_item_Numero") = item_nro Then
                tooltext = ds.Tables(3).Rows(i).Item("apenom")
                idtext = CStr(ds.Tables(3).Rows(i).Item("usuario_id"))
                i = ds.Tables(3).Rows.Count
            End If
            i = i + 1
        End While

    End Sub

    'Private Sub categorias_ObtenerInscriptos(ByVal evento_id As Integer)
    '    Dim ds_categorias As DataSet = DAllave.LLave_obtener_inscriptos(evento_id)
    '    If ds_categorias.Tables(0).Rows.Count <> 0 Then
    '        'si tengo inscriptos, tengo q agruparlos x categoria.

    '        Dim i As Integer = 0
    '        Dim item_nuevo As String = "no"
    '        While i < ds_categorias.Tables(0).Rows.Count

    '            'aqui lo agrego al primero.
    '            'la categoria va concatenada en una var string
    '            Dim tipo As String = ds_categorias.Tables(0).Rows(i).Item("categoria_tipo")
    '            'busco graduacion desde
    '            Dim graduacion_desde As String = ""
    '            Dim k As Integer = 0
    '            While k < ds_categorias.Tables(1).Rows.Count
    '                If (ds_categorias.Tables(1).Rows(k).Item("graduacion_id") = ds_categorias.Tables(0).Rows(i).Item("categoria_gradinicial")) Then
    '                    graduacion_desde = ds_categorias.Tables(1).Rows(k).Item("graduacion_desc")
    '                    k = ds_categorias.Tables(1).Rows.Count
    '                End If
    '                k = k + 1
    '            End While
    '            'busco graduacion hasta
    '            Dim graduacion_hasta As String = ""
    '            k = 0
    '            While k < ds_categorias.Tables(1).Rows.Count
    '                If ds_categorias.Tables(1).Rows(k).Item("graduacion_id") = ds_categorias.Tables(0).Rows(i).Item("categoria_gradfinal") Then
    '                    graduacion_hasta = ds_categorias.Tables(1).Rows(k).Item("graduacion_desc")
    '                    k = ds_categorias.Tables(1).Rows.Count
    '                End If
    '                k = k + 1
    '            End While
    '            Dim edad_desde As String = ds_categorias.Tables(0).Rows(i).Item("categoria_edadinicial")
    '            Dim edad_hasta As String = ds_categorias.Tables(0).Rows(i).Item("categoria_edadfinal")
    '            Dim sexo As String = ds_categorias.Tables(0).Rows(i).Item("categoria_sexo")
    '            'ahora junto todas las variables para mostrar en categoria
    '            Dim categoria As String = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
    '            Dim row_insc As DataRow = key_insc_ds.Tables("Categorias_inscriptos").NewRow()
    '            row_insc("id") = ds_categorias.Tables(0).Rows(i).Item("categoria_id")
    '            row_insc("Categoria") = categoria
    '            'ahora los cuento a los inscriptos
    '            Dim categoria_id As Integer = ds_categorias.Tables(0).Rows(i).Item("categoria_id")
    '            k = i
    '            Dim contador As Integer = 0
    '            While k < ds_categorias.Tables(0).Rows.Count
    '                If categoria_id = ds_categorias.Tables(0).Rows(k).Item("categoria_id") Then
    '                    contador = contador + 1
    '                    i = k + 1
    '                    k = k + 1

    '                Else
    '                    k = ds_categorias.Tables(0).Rows.Count
    '                End If
    '            End While
    '            row_insc("Inscriptos") = contador
    '            key_insc_ds.Tables("Categorias_inscriptos").Rows.Add(row_insc)
    '        End While
    '        GridView1.DataSource = key_insc_ds.Tables("Categorias_inscriptos")
    '        GridView1.DataBind()

    '    End If
    'End Sub


    Private Sub B1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B1.Click
        'B5.Visible = True
        'B5.Text = B1.Text
        'B5.ToolTip = B1.ToolTip
        actualizar_llave(B1, B5, B2)
    End Sub

    Private Sub B2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B2.Click
        'B5.Visible = True
        'B5.Text = B2.Text
        'B5.ToolTip = B2.ToolTip
        actualizar_llave(B2, B5, B1)
    End Sub



    Private Sub actualizar_llave(ByRef boton_desde As Button, ByRef boton_hasta As Button, ByRef boton_versus As Button)

        If boton_versus.Visible = True Then
            boton_hasta.Visible = True
            boton_hasta.Text = boton_desde.Text
            boton_hasta.ToolTip = boton_desde.ToolTip
        End If
        
    End Sub

    Private Sub B3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B3.Click
        actualizar_llave(B3, B6, B4)
    End Sub

    Private Sub B4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B4.Click
        actualizar_llave(B4, B6, B3)
    End Sub


    Private Sub B5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B5.Click
        actualizar_llave(B5, B7, B6)
        If B7.Visible = True Then
            LB_WINNER.Visible = True
        End If
    End Sub

    Private Sub B6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B6.Click
        actualizar_llave(B6, B7, B5)
        If B7.Visible = True Then
            LB_WINNER.Visible = True
        End If
    End Sub
End Class