Public Class CambioCategoriaenInscripcion
    Inherits System.Web.UI.Page

#Region "DEFINICIONES"
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DAmantHamer As New Capa_de_datos.MantenimientoHamer
#End Region

#Region "EVENTOS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtener_eventos_disponibles()
            Session("popup") = "si"
            'popup = "no"
            'choco.Visible = False

        End If
    End Sub

    Private Sub Btn_SelecEvento_Click(sender As Object, e As EventArgs) Handles Btn_SelecEvento.Click


        Dim ds_inscripciones As DataSet = DAmantHamer.Mantenimiento_ObtenerInscriptos_todo(DropDownList_eventos.SelectedValue)


        'Dim ds_inscripciones As DataSet = DAmantHamer.Mantenimiento_ObtenerInscriptos_AmbosSexosLucha(DropDownList_eventos.SelectedValue)

        If ds_inscripciones.Tables(0).Rows.Count <> 0 Then
            GridView_INSCRIPCIONES.DataSource = ds_inscripciones.Tables(0)
            GridView_INSCRIPCIONES.DataBind()


            'Completar_tabla_resultado_AmbosSexos()

            Completar_tabla_resultado_hombremujer()


        End If

    End Sub


#End Region


#Region "METODOS"
    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_Seleccionar_Curso()
        If ds_eventos.Tables(0).Rows.Count <> 0 Then
            DropDownList_eventos.DataSource = ds_eventos.Tables(0)
            DropDownList_eventos.DataValueField = "evento_id"
            DropDownList_eventos.DataTextField = "evento_descripcion"
            DropDownList_eventos.DataBind()
        End If
    End Sub

    Private Sub Completar_tabla_resultado_hombremujer()
        Dim MantHamer_ds As New MantHamer_ds
        Dim i As Integer = 0
        While i < GridView_INSCRIPCIONES.Rows.Count
            Dim categoria_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(2).Text)
            Dim categoria_sexo As String = GridView_INSCRIPCIONES.Rows(i).Cells(3).Text
            Dim categoria_gradinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(4).Text
            Dim categoria_gradfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(5).Text
            Dim categoria_edadinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(6).Text
            Dim categoria_edadfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(7).Text

            '----------MUJERES

            If categoria_sexo = "Mujer" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 6
            End If


            If categoria_sexo = "Mujer" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 92
            End If

            If categoria_sexo = "Mujer" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 178
            End If

            If categoria_sexo = "Mujer" And categoria_gradinicial = "12" And categoria_gradfinal = "20" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 263
            End If

            '-----HOMBRES

            If categoria_sexo = "Hombre" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 7
            End If

            If categoria_sexo = "Hombre" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 93
            End If

            If categoria_sexo = "Hombre" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 179
            End If

            If categoria_sexo = "Hombre" And categoria_gradinicial = "12" And categoria_gradfinal = "20" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 264
            End If


            Dim fila As DataRow = MantHamer_ds.Tables("TABLA1").NewRow
            fila("evento_id") = GridView_INSCRIPCIONES.Rows(i).Cells(0).Text
            fila("inscripcion_id") = GridView_INSCRIPCIONES.Rows(i).Cells(1).Text
            fila("categoria_id") = categoria_id

            MantHamer_ds.Tables("TABLA1").Rows.Add(fila)

            i = i + 1
        End While

        GridView_RESULTADOS.DataSource = MantHamer_ds.Tables("TABLA1")
        GridView_RESULTADOS.DataBind()

    End Sub



    Private Sub Completar_tabla_resultado_AmbosSexos()
        Dim MantHamer_ds As New MantHamer_ds
        Dim i As Integer = 0
        While i < GridView_INSCRIPCIONES.Rows.Count
            Dim categoria_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(2).Text)
            Dim categoria_sexo As String = GridView_INSCRIPCIONES.Rows(i).Cells(3).Text
            Dim categoria_gradinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(4).Text
            Dim categoria_gradfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(5).Text
            Dim categoria_edadinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(6).Text
            Dim categoria_edadfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(7).Text

            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "0" And categoria_edadfinal = "5" Then
                categoria_id = 2
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "6" And categoria_edadfinal = "7" Then
                categoria_id = 3
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "8" And categoria_edadfinal = "9" Then
                categoria_id = 4
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 5
            End If


            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "0" And categoria_edadfinal = "5" Then
                categoria_id = 88
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "6" And categoria_edadfinal = "7" Then
                categoria_id = 89
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "8" And categoria_edadfinal = "9" Then
                categoria_id = 90
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 91
            End If


            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "0" And categoria_edadfinal = "5" Then
                categoria_id = 174
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "6" And categoria_edadfinal = "7" Then
                categoria_id = 175
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "8" And categoria_edadfinal = "9" Then
                categoria_id = 176
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 177
            End If


            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "12" And categoria_gradfinal = "20" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 262
            End If

            Dim fila As DataRow = MantHamer_ds.Tables("TABLA1").NewRow
            fila("evento_id") = GridView_INSCRIPCIONES.Rows(i).Cells(0).Text
            fila("inscripcion_id") = GridView_INSCRIPCIONES.Rows(i).Cells(1).Text
            fila("categoria_id") = categoria_id

            MantHamer_ds.Tables("TABLA1").Rows.Add(fila)

            i = i + 1
        End While

        GridView_RESULTADOS.DataSource = MantHamer_ds.Tables("TABLA1")
        GridView_RESULTADOS.DataBind()

    End Sub

    Private Sub BTN_ejecutar_Click(sender As Object, e As EventArgs) Handles BTN_ejecutar.Click
        Dim MantHamer_ds As New MantHamer_ds
        Dim i As Integer = 0
        While i < GridView_INSCRIPCIONES.Rows.Count
            Dim categoria_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(2).Text)
            Dim categoria_sexo As String = GridView_INSCRIPCIONES.Rows(i).Cells(3).Text
            Dim categoria_gradinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(4).Text
            Dim categoria_gradfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(5).Text
            Dim categoria_edadinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(6).Text
            Dim categoria_edadfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(7).Text

            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "0" And categoria_edadfinal = "5" Then
                categoria_id = 2
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "6" And categoria_edadfinal = "7" Then
                categoria_id = 3
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "8" And categoria_edadfinal = "9" Then
                categoria_id = 4
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 5
            End If


            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "0" And categoria_edadfinal = "5" Then
                categoria_id = 88
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "6" And categoria_edadfinal = "7" Then
                categoria_id = 89
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "8" And categoria_edadfinal = "9" Then
                categoria_id = 90
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 91
            End If


            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "0" And categoria_edadfinal = "5" Then
                categoria_id = 174
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "6" And categoria_edadfinal = "7" Then
                categoria_id = 175
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "8" And categoria_edadfinal = "9" Then
                categoria_id = 176
            End If
            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 177
            End If


            If categoria_sexo = "AMBOS SEXOS" And categoria_gradinicial = "12" And categoria_gradfinal = "20" And categoria_edadinicial = "10" And categoria_edadfinal = "11" Then
                categoria_id = 262
            End If

            'AQUI GUARDO EN BD
            Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
            DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)

            'Dim fila As DataRow = MantHamer_ds.Tables("TABLA1").NewRow
            'fila("evento_id") = GridView_INSCRIPCIONES.Rows(i).Cells(0).Text
            'fila("inscripcion_id") = GridView_INSCRIPCIONES.Rows(i).Cells(1).Text
            'fila("categoria_id") = categoria_id

            'MantHamer_ds.Tables("TABLA1").Rows.Add(fila)

            i = i + 1
        End While

    End Sub

    Private Sub BTN_ejecutar2_Click(sender As Object, e As EventArgs) Handles BTN_ejecutar2.Click
        Dim MantHamer_ds As New MantHamer_ds
        Dim i As Integer = 0
        While i < GridView_INSCRIPCIONES.Rows.Count
            Dim categoria_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(2).Text)
            Dim categoria_sexo As String = GridView_INSCRIPCIONES.Rows(i).Cells(3).Text
            Dim categoria_gradinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(4).Text
            Dim categoria_gradfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(5).Text
            Dim categoria_edadinicial As String = GridView_INSCRIPCIONES.Rows(i).Cells(6).Text
            Dim categoria_edadfinal As String = GridView_INSCRIPCIONES.Rows(i).Cells(7).Text


            '-------------------MUJERES

            If categoria_sexo = "Mujer" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 6
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If


            If categoria_sexo = "Mujer" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 92
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If

            If categoria_sexo = "Mujer" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 178
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If

            If categoria_sexo = "Mujer" And categoria_gradinicial = "12" And categoria_gradfinal = "20" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 263
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If

            '-------------------HOMBRES

            If categoria_sexo = "Hombre" And categoria_gradinicial = "2" And categoria_gradfinal = "3" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 7
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If

            If categoria_sexo = "Hombre" And categoria_gradinicial = "4" And categoria_gradfinal = "7" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 93
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If

            If categoria_sexo = "Hombre" And categoria_gradinicial = "8" And categoria_gradfinal = "11" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 179
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If

            If categoria_sexo = "Hombre" And categoria_gradinicial = "12" And categoria_gradfinal = "20" And categoria_edadinicial = "12" And categoria_edadfinal = "13" Then
                categoria_id = 264
                'AQUI GUARDO EN BD
                Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
                DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)
            End If


            ''AQUI GUARDO EN BD
            'Dim torneo_id As Integer = CInt(GridView_INSCRIPCIONES.Rows(i).Cells(12).Text)
            'DAmantHamer.Mantenimiento_actualizar_inscripcion(torneo_id, categoria_id)

            'Dim fila As DataRow = MantHamer_ds.Tables("TABLA1").NewRow
            'fila("evento_id") = GridView_INSCRIPCIONES.Rows(i).Cells(0).Text
            'fila("inscripcion_id") = GridView_INSCRIPCIONES.Rows(i).Cells(1).Text
            'fila("categoria_id") = categoria_id

            'MantHamer_ds.Tables("TABLA1").Rows.Add(fila)

            i = i + 1
        End While

    End Sub


#End Region

End Class