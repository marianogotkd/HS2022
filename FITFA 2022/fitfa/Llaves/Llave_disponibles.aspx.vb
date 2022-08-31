Public Class Llave_disponibles
    Inherits System.Web.UI.Page
    Dim DAllave As New Capa_de_datos.Llave
    Dim DAinscrip As New Capa_de_datos.Inscripciones
    Dim key_insc_ds As New Llaves_ds
    Dim DAevento As New Capa_de_datos.Eventos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Tipo") = "administrador" Then
                div_Grid.Visible = True
                div_Volver.Visible = False
                Label1.Visible = True
                Lb_evento.Text = Session("evento_desc")
                Dim evento_id = Session("evento_id")
                HF_evento_id.Value = Session("evento_id") 'esto lo uso x el prolongado tiempo de una sesion
                Lb_fecha.Text = Session("fecha")
                Lb_fecha_cierre.Text = Session("fecha_cierre")
                'obtener_categorias(HF_evento_id.Value)
                obtener_llaves_generadas_info()
                'div_modalllaveOK.Visible = False
                'categorias_ObtenerInscriptos(evento_id)
                'div_Modal_err.Visible = False
                'div_Modal_error_generacion.Visible = False

                'busqueda() 'va a recuperar un listado de los inscriptos segun los combos seleccionados
            Else
                If Session("Area") = "" Then
                    div_Grid.Visible = False
                    div_Volver.Visible = True
                    Label1.Visible = True
                Else

                    div_Grid.Visible = True
                    div_Volver.Visible = True
                    Label1.Visible = False
                    Dim evento_id = Session("evento_id")
                    Dim ds_evento As DataSet = DAevento.Evento_ObetenerEvento_ID(evento_id)
                    Lb_evento.Text = ds_evento.Tables(0).Rows(0).Item("evento_descripcion") 'esto lo busco en sql
                    Lb_fecha.Text = ds_evento.Tables(0).Rows(0).Item("evento_fecha")
                    Lb_fecha_cierre.Text = ds_evento.Tables(0).Rows(0).Item("fechacierre")
                    HF_evento_id.Value = Session("evento_id") 'esto lo uso x el prolongado tiempo de una sesion
                    HF_area_id.Value = Session("Area")
                    'obtener_categorias(HF_evento_id.Value)
                    obtener_llaves_generadas_infoArea(CInt(HF_area_id.Value))
                End If
            End If
        End If
    End Sub


    Private Sub obtener_llaves_generadas_infoArea(ByVal area_id As Integer)
        key_insc_ds.Tables("Llaves_generadas").Rows.Clear()
        GridView2.DataSource = ""
        GridView2.DataBind()




        'se consulta en la bd las llaves generadas y se muestra en la grilla 2
        Dim ds_llave As DataSet = DAllave.Llave_obtener_llaves_generadas_infoArea(HF_evento_id.Value, area_id)
        If ds_llave.Tables(0).Rows.Count <> 0 Then

            'aqui lo relleno
            'Llaves_generadas
            Dim i As Integer = 0
            Dim item_nuevo As String = "no"
            While i < ds_llave.Tables(0).Rows.Count

                'aqui lo agrego al primero.
                'la categoria va concatenada en una var string
                Dim tipo As String = ds_llave.Tables(0).Rows(i).Item("categoria_tipo")
                'busco graduacion desde
                Dim graduacion_desde As String = ""
                Dim k As Integer = 0
                While k < ds_llave.Tables(1).Rows.Count
                    If (ds_llave.Tables(1).Rows(k).Item("graduacion_id") = ds_llave.Tables(0).Rows(i).Item("categoria_gradinicial")) Then
                        graduacion_desde = ds_llave.Tables(1).Rows(k).Item("graduacion_desc")
                        k = ds_llave.Tables(1).Rows.Count
                    End If
                    k = k + 1
                End While
                'busco graduacion hasta
                Dim graduacion_hasta As String = ""
                k = 0
                While k < ds_llave.Tables(1).Rows.Count
                    If ds_llave.Tables(1).Rows(k).Item("graduacion_id") = ds_llave.Tables(0).Rows(i).Item("categoria_gradfinal") Then
                        graduacion_hasta = ds_llave.Tables(1).Rows(k).Item("graduacion_desc")
                        k = ds_llave.Tables(1).Rows.Count
                    End If
                    k = k + 1
                End While
                Dim edad_desde As String = ds_llave.Tables(0).Rows(i).Item("categoria_edadinicial")
                Dim edad_hasta As String = ds_llave.Tables(0).Rows(i).Item("categoria_edadfinal")
                Dim peso_inicial As String = ds_llave.Tables(0).Rows(i).Item("categoria_peso_inical")
                Dim peso_final As String = ds_llave.Tables(0).Rows(i).Item("categoria_peso_Final")
                Dim sexo As String = ds_llave.Tables(0).Rows(i).Item("categoria_sexo")
                'ahora junto todas las variables para mostrar en categoria
                Dim categoria As String = sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
                If tipo = "Lucha" Then
                    categoria = sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)" + " de " + peso_inicial + " a " + peso_final + " Kilos"
                End If
                Dim row_insc As DataRow = key_insc_ds.Tables("Llaves_generadas").NewRow()
                'Dim Estado = "Pendiente"
                row_insc("ID") = ds_llave.Tables(0).Rows(i).Item("ID")
                row_insc("modalidad") = tipo
                row_insc("categoria") = categoria
                row_insc("inscriptos") = ds_llave.Tables(0).Rows(i).Item("inscriptos")
                row_insc("Area") = ds_llave.Tables(0).Rows(i).Item("Area") 'choco: 19-07-2019 ahora recupera el area vinculada a la llave

                key_insc_ds.Tables("Llaves_generadas").Rows.Add(row_insc)
                i = i + 1
            End While
            GridView2.DataSource = key_insc_ds.Tables("Llaves_generadas")
            GridView2.DataBind()

        End If
        If GridView2.Rows.Count = 0 Then
            Lab_no_llaves.Visible = True
            btn_Examinar.Visible = False 'es el boton de eliminar llave

        Else
            Lab_no_llaves.Visible = False
            btn_Examinar.Visible = True 'es el boton de eliminar llave
        End If

    End Sub

    Private Sub obtener_llaves_generadas_info()
        key_insc_ds.Tables("Llaves_generadas").Rows.Clear()
        GridView2.DataSource = ""
        GridView2.DataBind()




        'se consulta en la bd las llaves generadas y se muestra en la grilla 2
        Dim ds_llave As DataSet = DAllave.Llave_obtener_llaves_generadas_info(HF_evento_id.Value)
        If ds_llave.Tables(0).Rows.Count <> 0 Then

            'aqui lo relleno
            'Llaves_generadas
            Dim i As Integer = 0
            Dim item_nuevo As String = "no"
            While i < ds_llave.Tables(0).Rows.Count

                'aqui lo agrego al primero.
                'la categoria va concatenada en una var string
                Dim tipo As String = ds_llave.Tables(0).Rows(i).Item("categoria_tipo")
                'busco graduacion desde
                Dim graduacion_desde As String = ""
                Dim k As Integer = 0
                While k < ds_llave.Tables(1).Rows.Count
                    If (ds_llave.Tables(1).Rows(k).Item("graduacion_id") = ds_llave.Tables(0).Rows(i).Item("categoria_gradinicial")) Then
                        graduacion_desde = ds_llave.Tables(1).Rows(k).Item("graduacion_desc")
                        k = ds_llave.Tables(1).Rows.Count
                    End If
                    k = k + 1
                End While
                'busco graduacion hasta
                Dim graduacion_hasta As String = ""
                k = 0
                While k < ds_llave.Tables(1).Rows.Count
                    If ds_llave.Tables(1).Rows(k).Item("graduacion_id") = ds_llave.Tables(0).Rows(i).Item("categoria_gradfinal") Then
                        graduacion_hasta = ds_llave.Tables(1).Rows(k).Item("graduacion_desc")
                        k = ds_llave.Tables(1).Rows.Count
                    End If
                    k = k + 1
                End While
                Dim edad_desde As String = ds_llave.Tables(0).Rows(i).Item("categoria_edadinicial")
                Dim edad_hasta As String = ds_llave.Tables(0).Rows(i).Item("categoria_edadfinal")
                Dim peso_inicial As String = ds_llave.Tables(0).Rows(i).Item("categoria_peso_inical")
                Dim peso_final As String = ds_llave.Tables(0).Rows(i).Item("categoria_peso_Final")
                Dim sexo As String = ds_llave.Tables(0).Rows(i).Item("categoria_sexo")
                'ahora junto todas las variables para mostrar en categoria
                Dim categoria As String = sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
                If tipo = "Lucha" Then
                    categoria = sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)" + " de " + peso_inicial + " a " + peso_final + " Kilos"
                End If
                Dim row_insc As DataRow = key_insc_ds.Tables("Llaves_generadas").NewRow()
                'Dim Estado = "Pendiente"
                row_insc("ID") = ds_llave.Tables(0).Rows(i).Item("ID")
                row_insc("modalidad") = tipo
                row_insc("categoria") = categoria
                row_insc("inscriptos") = ds_llave.Tables(0).Rows(i).Item("inscriptos")
                row_insc("Area") = ds_llave.Tables(0).Rows(i).Item("Area") 'choco: 19-07-2019 ahora recupera el area vinculada a la llave

                key_insc_ds.Tables("Llaves_generadas").Rows.Add(row_insc)
                i = i + 1
            End While
            GridView2.DataSource = key_insc_ds.Tables("Llaves_generadas")
            GridView2.DataBind()

        End If
        If GridView2.Rows.Count = 0 Then
            Lab_no_llaves.Visible = True
            btn_Examinar.Visible = False 'es el boton de eliminar llave

        Else
            Lab_no_llaves.Visible = False
            btn_Examinar.Visible = True 'es el boton de eliminar llave
        End If

    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")
            Session("categoria_id") = id
            Session("llave_id") = id
            'Session("evento_id")

            Dim i As Integer = 0
            Dim cantidad_inscriptos As Integer = 0
            While i < GridView2.Rows.Count
                Dim llave_id As Integer = CInt(GridView2.Rows(i).Cells(1).Text)
                If llave_id = id Then
                    cantidad_inscriptos = CInt(GridView2.Rows(i).Cells(4).Text) 'es la cantidad
                    'Session("evento_desc") = GridView1.Rows(i).Cells(1).Text
                    i = GridView2.Rows.Count
                Else
                    i = i + 1
                End If
            End While

            Dim c_inscri As Integer = cantidad_inscriptos



            'primero voy a borrar las llave q se haya creado si es necesario

            'DAllave.llave_eliminar(CInt(HF_evento_id.Value), id)
            'DAllave.llave_eliminar(Session("evento_id"), id) lo comento x q no quiero usar algo de sesion q se pueda perder si se prolonga el tiempo

            'aqui voy a poner la rutina para generar la llave.

            If (c_inscri = 2) Then
                Response.Redirect("Llave_2.aspx") 'este si va es IMPORTANTE
                'Response.Redirect("~/Visor_reporte_llave2.aspx") 'ESTE LO USO PARA VER EN CRISTAL
                'Response.Redirect("~/Reportes/Llaves/Visor_ejemplo.aspx")

            End If
            If (c_inscri > 2) And (c_inscri <= 4) Then
                Response.Redirect("Llave_4.aspx")
            End If

            If (c_inscri > 4) And (c_inscri <= 8) Then
                Response.Redirect("Llave_8.aspx")
            End If
            If (c_inscri > 8) And (c_inscri <= 16) Then
                Response.Redirect("Llave_16.aspx")
            End If
            If (c_inscri > 16) And (c_inscri <= 32) Then
                Response.Redirect("Llave_32.aspx")
            End If

            'Dim i As Integer = 0
            'While i < GridView1.Rows.Count
            '    Dim id_evento As Integer = CInt(GridView1.Rows(i).Cells(0).Text)
            '    If id_evento = index Then
            '        Session("evento_desc") = GridView1.Rows(i).Cells(1).Text
            '        i = GridView1.Rows.Count
            '        Response.Redirect("Llave_detalle_evento.aspx")
            '    Else
            '        i = i + 1
            '    End If
            'End While

            ''valido si el usuario no se ha inscripto ya.
            'Dim usuario_id As Integer = Session("Us_id")
            'Dim ds_inscripto As DataSet = DAinscripciones.Inscripcion_consultar_alumno_inscripto(id, usuario_id)

            'If ds_inscripto.Tables(0).Rows.Count = 0 Then
            '    Dim i As Integer = 0
            '    While i < GridView1.Rows.Count
            '        Dim id_evento As Integer = CInt(GridView1.Rows(i).Cells(1).Text)
            '        If id_evento = index Then
            '            Session("evento_desc") = GridView1.Rows(i).Cells(1).Text
            '            i = GridView1.Rows.Count
            '            Response.Redirect("Evento_datos.aspx")
            '        Else
            '            i = i + 1
            '        End If
            '    End While
            'Else
            '    'sino ya esta inscripto
            '    'div_Modal_error_inscripto.Visible = True
            '    'Modal_error_inscripto.Show()

            'End If
        End If
    End Sub

    Private Sub Eliminar_llave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Eliminar_llave.ServerClick
        eliminar_llave_seleccionada()
    End Sub
    Private Sub eliminar_llave_seleccionada()
        Dim borrado As String = "no"
        'primero recorro la grilla 2 para ver si se selecciono algo
        Dim SELECCIONADO As CheckBox
        Dim i As Integer = 0
        While i < GridView2.Rows.Count
            SELECCIONADO = CType(GridView2.Rows(i).FindControl("CheckBox_item1"), CheckBox)
            If SELECCIONADO.Checked = True Then
                'como esta seleccionado procedo a borrar:
                Dim ds As DataSet = DAllave.LLave_obtener_llavegenerada_etc_2(GridView2.Rows(i).Cells(1).Text)
                Dim j As Integer = 0
                While j < ds.Tables(2).Rows.Count
                    'actualizo el estado en la tabla "inscripciones_x_torneo" pongo el campo en_llave='no'
                    Dim evento_id As Integer = ds.Tables(0).Rows(0).Item("evento_id")
                    Dim categoria_id As Integer = ds.Tables(0).Rows(0).Item("categoria_id")
                    Dim usuario_id As Integer = ds.Tables(2).Rows(j).Item("Llave_item_usuario_id")
                    DAllave.Llave_deshacer_llave(usuario_id, evento_id, categoria_id)
                    j = j + 1
                End While

                'aqui borro la llave
                DAllave.llave_eliminar(GridView2.Rows(i).Cells(1).Text)
                borrado = "si"
            End If
            i = i + 1
        End While
        If borrado = "si" Then
            'obtener_categorias(HF_evento_id.Value) no lo uso
            If Session("Tipo") = "administrador" Then
                obtener_llaves_generadas_info()
            Else
                obtener_llaves_generadas_infoArea(CInt(HF_area_id.Value))
            End If

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("../Torneo/Seleccion_Area.aspx")
    End Sub
End Class