Public Class Llave_generar
    Inherits System.Web.UI.Page
    Dim DAarea As New Capa_de_datos.Area
    Dim DAllave As New Capa_de_datos.Llave
    Dim DAinscrip As New Capa_de_datos.Inscripciones
    Dim key_insc_ds As New Llaves_ds
    Dim DAevento As New Capa_de_datos.Eventos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'popupMsjError.Visible = False
            'popupMsjGuardado.Visible = False
            'obtener_usuario()

            'Dim ds_evento As DataSet = DAinscripciones.Inscripcion_consultar_evento(Session("evento_id"))
            'Dim tipo_evento As String = ds_evento.Tables(0).Rows(0).Item("tipo_evento")
            'If tipo_evento <> "Torneo" Then
            '    'no muestro la seccion de "Datos de competencia"
            '    seccion_competencia.Visible = False
            '    Label1.Text = ""
            '    DropDownList_graduacion.Enabled = False

            'End If
            If Session("Area") = "" Then
                Lb_evento.Text = Session("evento_desc")
                Dim evento_id = Session("evento_id")
                HF_evento_id.Value = Session("evento_id") 'esto lo uso x el prolongado tiempo de una sesion
                Lb_fecha.Text = Session("fecha")
                Lb_fecha_cierre.Text = Session("fecha_cierre")
                obtener_categorias(HF_evento_id.Value)
                obtener_llaves_generadas_info()
                div_modalllaveOK.Visible = False
                div_modalllaveError.Visible = False
                'categorias_ObtenerInscriptos(evento_id)
                'div_Modal_err.Visible = False
                'div_Modal_error_generacion.Visible = False
                Recuperar_areas_de_evento()
                busqueda() 'va a recuperar un listado de los inscriptos segun los combos seleccionados
            Else
                'si la variable session("Area") tiene un valor estoy accediendo desde el usuario torneo
                'solamente voy a listar en el combo el area disponible que se seleccionó
                Dim evento_id = Session("evento_id")
                HF_evento_id.Value = Session("evento_id") 'esto lo uso x el prolongado tiempo de una sesion
                Dim ds_evento As DataSet = DAevento.Evento_ObetenerEvento_ID(evento_id)
                Lb_evento.Text = ds_evento.Tables(0).Rows(0).Item("evento_descripcion") 'esto lo busco en sql
                Lb_fecha.Text = ds_evento.Tables(0).Rows(0).Item("evento_fecha")
                Lb_fecha_cierre.Text = ds_evento.Tables(0).Rows(0).Item("fechacierre")
                obtener_categorias(HF_evento_id.Value)
                obtener_llaves_generadas_info() 'no me importa tanto, porque esta oculto
                div_modalllaveOK.Visible = False
                div_modalllaveError.Visible = False
                'categorias_ObtenerInscriptos(evento_id)
                'div_Modal_err.Visible = False
                'div_Modal_error_generacion.Visible = False
                HF_area_id.Value = Session("Area") 'esta variable de session tiene la area seleccionada al logear como usuario Torneo. 
                Recuperar_areas_de_evento()
                busqueda() 'va a recuperar un listado de los inscriptos segun los combos seleccionados

            End If

            
        End If
    End Sub

    Private Sub Recuperar_areas_de_evento()
        If HF_area_id.Value = "" Then
            HF_area_id.Value = 0
        End If
        Dim ds_area As DataSet = DAarea.area_obtener_asignadas(HF_evento_id.Value, HF_area_id.Value)
        If Session("Area") = "" Then
            If ds_area.Tables(0).Rows.Count <> 0 Then
                DropDownList_areas.DataSource = ds_area.Tables(0)
                DropDownList_areas.DataValueField = "id"
                DropDownList_areas.DataTextField = "Area"
                DropDownList_areas.DataBind()
            End If
        Else
            If ds_area.Tables(1).Rows.Count <> 0 Then
                DropDownList_areas.DataSource = ds_area.Tables(1)
                DropDownList_areas.DataValueField = "id"
                DropDownList_areas.DataTextField = "Area"
                DropDownList_areas.DataBind()
            End If
        End If
    End Sub

    Private Sub obtener_categorias(ByVal evento_id As Integer)
        key_insc_ds.Tables("Categorias_inscriptos").Rows.Clear()
        DropDown_categoria.DataSource = ""
        GridView1.DataSource = ""
        GridView1.DataBind()

        Dim ds_categorias As DataSet = DAllave.LLave_obtener_inscriptos_filtrados(evento_id, DropDown_modalidad.SelectedValue)
        If ds_categorias.Tables(0).Rows.Count <> 0 Then
            'si tengo inscriptos, tengo q agruparlos x categoria.

            Dim i As Integer = 0
            Dim item_nuevo As String = "no"
            While i < ds_categorias.Tables(0).Rows.Count

                'aqui lo agrego al primero.
                'la categoria va concatenada en una var string
                Dim tipo As String = ds_categorias.Tables(0).Rows(i).Item("categoria_tipo")
                'busco graduacion desde
                Dim graduacion_desde As String = ""
                Dim k As Integer = 0
                While k < ds_categorias.Tables(1).Rows.Count
                    If (ds_categorias.Tables(1).Rows(k).Item("graduacion_id") = ds_categorias.Tables(0).Rows(i).Item("categoria_gradinicial")) Then
                        graduacion_desde = ds_categorias.Tables(1).Rows(k).Item("graduacion_desc")
                        k = ds_categorias.Tables(1).Rows.Count
                    End If
                    k = k + 1
                End While
                'busco graduacion hasta
                Dim graduacion_hasta As String = ""
                k = 0
                While k < ds_categorias.Tables(1).Rows.Count
                    If ds_categorias.Tables(1).Rows(k).Item("graduacion_id") = ds_categorias.Tables(0).Rows(i).Item("categoria_gradfinal") Then
                        graduacion_hasta = ds_categorias.Tables(1).Rows(k).Item("graduacion_desc")
                        k = ds_categorias.Tables(1).Rows.Count
                    End If
                    k = k + 1
                End While
                Dim edad_desde As String = ds_categorias.Tables(0).Rows(i).Item("categoria_edadinicial")
                Dim edad_hasta As String = ds_categorias.Tables(0).Rows(i).Item("categoria_edadfinal")
                Dim peso_inicial As String = ds_categorias.Tables(0).Rows(i).Item("categoria_peso_inical")
                Dim peso_final As String = ds_categorias.Tables(0).Rows(i).Item("categoria_peso_Final")
                Dim sexo As String = ds_categorias.Tables(0).Rows(i).Item("categoria_sexo")
                'ahora junto todas las variables para mostrar en categoria
                Dim categoria As String = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
                If tipo = "Lucha" Then
                    categoria = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)" + " de " + peso_inicial + " a " + peso_final + " Kilos"
                End If
                Dim row_insc As DataRow = key_insc_ds.Tables("Categorias_inscriptos").NewRow()
                Dim Estado = "Pendiente"
                row_insc("id") = ds_categorias.Tables(0).Rows(i).Item("categoria_id")
                row_insc("Categoria") = categoria
                'ahora los cuento a los inscriptos
                Dim categoria_id As Integer = ds_categorias.Tables(0).Rows(i).Item("categoria_id")
                k = i
                Dim contador As Integer = 0
                While k < ds_categorias.Tables(0).Rows.Count
                    If categoria_id = ds_categorias.Tables(0).Rows(k).Item("categoria_id") Then
                        contador = contador + 1
                        i = k + 1
                        k = k + 1

                    Else
                        k = ds_categorias.Tables(0).Rows.Count
                    End If
                End While
                row_insc("Inscriptos") = contador
                Dim ds_Estado As DataSet = DAllave.Llave_Verificar_existencia(categoria_id, Session("evento_id"))
                If ds_Estado.Tables(0).Rows.Count <> 0 Then
                    Estado = "Generado"
                End If

                row_insc("Estado") = Estado
                key_insc_ds.Tables("Categorias_inscriptos").Rows.Add(row_insc)
            End While

            


            'GridView1.DataSource = key_insc_ds.Tables("Categorias_inscriptos")
            'GridView1.DataBind()

            'colorear_pendientes()
        End If

        'If key_insc_ds.Tables("Categorias_inscriptos").Rows.Count <> 0 Then
        DropDown_categoria.DataSource = key_insc_ds.Tables("Categorias_inscriptos")
        DropDown_categoria.DataValueField = "id"
        DropDown_categoria.DataTextField = "Categoria"
        DropDown_categoria.DataBind()
        'GridView3.DataSource = key_insc_ds.Tables("Categorias_inscriptos")

        'End If



    End Sub

    Private Sub DropDown_modalidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_modalidad.SelectedIndexChanged
        obtener_categorias(HF_evento_id.Value)
        busqueda() 'va a recuperar un listado de los inscriptos segun los combos seleccionados
    End Sub


    Private Sub generar_grilla_vacia()

    End Sub
    Dim llaves_ds1 As New Llaves_ds
    Dim DAinstructor As New Capa_de_datos.Instructor
    Private Sub busqueda()
        llaves_ds1.Tables("inscriptos_sin_llave").Rows.Clear()
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        'realiza la busqueda de los inscriptos dependiendo de los combos seleccionados
        If DropDown_categoria.Items.Count <> 0 Then
            Dim ds As DataSet = DAllave.LLave_obtener_inscriptos_sin_llave(HF_evento_id.Value, DropDown_categoria.SelectedValue)

            'tengo que ir cargando en un dataset, ya que no tengo los datos del instructor, para ello tengo q recuperarlos con otro procedimiento
            Dim i As Integer = 0
            While i < ds.Tables(0).Rows.Count
                Dim row As DataRow = llaves_ds1.Tables("inscriptos_sin_llave").NewRow()
                row("ID") = ds.Tables(0).Rows(i).Item("ID")
                row("dni") = ds.Tables(0).Rows(i).Item("dni")
                row("ApellidoyNombre") = ds.Tables(0).Rows(i).Item("ApellidoyNombre")
                row("Institucion_abreviatura") = ds.Tables(0).Rows(i).Item("Institucion_abreviatura")
                row("Institucion") = ds.Tables(0).Rows(i).Item("Institucion")
                row("Provincia") = ds.Tables(0).Rows(i).Item("Provincia")
                row("instructor_id") = ds.Tables(0).Rows(i).Item("instructor_id")
                Dim instructor_id As Integer = ds.Tables(0).Rows(i).Item("instructor_id")
                Dim ds_instr As DataSet = DAinstructor.Instructor_obtener_INFO(instructor_id)
                row("instructor") = ds_instr.Tables(0).Rows(0).Item("ApellidoyNombre")
                row("Peso") = ds.Tables(0).Rows(i).Item("Peso")
                row("Inscripcion_id") = ds.Tables(0).Rows(i).Item("Inscripcion_id")
                llaves_ds1.Tables("inscriptos_sin_llave").Rows.Add(row)
                i = i + 1
            End While
            GridView1.DataSource = llaves_ds1.Tables("inscriptos_sin_llave")
            'GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
            label_catseleccionada.Text = DropDown_categoria.SelectedItem.Text
            LB_INSCRIPTOS.Text = GridView1.Rows.Count

        Else
            label_catseleccionada.Text = ""
        End If
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        busqueda()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        'cuento la cantidad de inscriptos que haya seleccionado de la grilla 1
        Dim SELECCIONADO As CheckBox
        Dim i As Integer = 0
        Dim cantidad_inscriptos As Integer = 0
        While i < GridView1.Rows.Count
            SELECCIONADO = CType(GridView1.Rows(i).FindControl("CheckBox_item"), CheckBox)
            If SELECCIONADO.Checked = True Then
                cantidad_inscriptos = cantidad_inscriptos + 1
            End If
            i = i + 1
        End While
        If cantidad_inscriptos > 1 Then
            Dim c_inscri As Integer = cantidad_inscriptos
            'primero voy a borrar las llave q se haya creado si es necesario
            'DAllave.llave_eliminar(CInt(HF_evento_id.Value), DropDown_categoria.SelectedValue)
            'aqui voy a poner la rutina para generar la llave.
            generar_llave(cantidad_inscriptos, 0)

            'esto me servia para q una vez generada la llave, vaya directamente a mostrarla en los form q corresponda
            'If (c_inscri = 2) Then
            '    Response.Redirect("Llave_2.aspx")
            'End If
            'If (c_inscri > 2) And (c_inscri <= 4) Then
            '    Response.Redirect("Llave_4.aspx")
            'End If
            'If (c_inscri > 4) And (c_inscri <= 8) Then
            '    Response.Redirect("Llave_8.aspx")
            'End If
            'If (c_inscri > 8) And (c_inscri <= 16) Then
            '    Response.Redirect("Llave_16.aspx")
            'End If
            'If (c_inscri > 16) And (c_inscri <= 32) Then
            '    Response.Redirect("Llave_32.aspx")
            'End If
            'vuelvo a llamar estas rutinas porque al generar una llave, puede q ya no este disponible la categoria x falta de inscriptos
            obtener_categorias(HF_evento_id.Value)
            obtener_llaves_generadas_info()

            '++++++++++++++Esto hago para que se haga visible el cartel de "llave generada correctamente"++++++++++++++
            div_modalllaveOK.Visible = True
            Modal_llaveOK.Show()
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        End If
    End Sub
    Private Sub generar_llave(ByVal inscriptos As Integer, ByRef llave_id_generada As Integer)
        Dim inscriptos_posta As Integer = inscriptos
        'primero alta de la categoria en la tabla llave.
        Dim ds_llave As DataSet = DAllave.Llave_alta(CInt(HF_evento_id.Value), DropDown_categoria.SelectedValue, inscriptos, DropDownList_areas.SelectedValue)
        'inscriptos = 3
        Dim llave_id As Integer = ds_llave.Tables(0).Rows(0).Item("Llave_id")
        llave_id_generada = ds_llave.Tables(0).Rows(0).Item("Llave_id")

        Dim nivel = 0 '2 'x q 2^2 = 4 q es el maximo
        Select Case inscriptos
            Case 2
                nivel = 1

            Case 3 To 4
                nivel = 2

            Case 5 To 8
                nivel = 3

            Case 9 To 16
                nivel = 4

            Case 17 To 32
                nivel = 5

        End Select


        Dim padre As Decimal = 0
        If inscriptos < 2 Or inscriptos <= 4 Then 'ojo aqui hay q forzar a que sean minimo 2
            'aqui probamos, obligo q si no son 2, q sean si o si 4

            If inscriptos = 3 Then
                inscriptos = 4
            End If

            Dim A As Integer = inscriptos - (2 ^ (nivel - 1))
            A = A * 2 'ya q es una pareja la q se agrega
            Dim i As Integer = 0
            While i < A
                'cargo registro en bd
                DAllave.Llave_item_alta(0, 0, 0, nivel, i + 1, "", llave_id)
                padre = padre + 0.5
                inscriptos = inscriptos - 1

                i = i + 1
            End While




        Else
            Select Case inscriptos
                Case 5 To 8
                    nivel = 3
                    inscriptos = 8 'se generan llaves vacias con el maximo x nivel
                Case 9 To 16
                    nivel = 4
                    inscriptos = 16 'se generan llaves vacias con el maximo x nivel
                Case 17 To 32
                    nivel = 5
                    inscriptos = 32 'se generan llaves vacias con el maximo x nivel
            End Select


            '-----------LLAVE ---------------
            'If inscriptos > 4 And inscriptos <= 8 Then
            'nivel = 3
            Dim A As Integer = inscriptos - (2 ^ (nivel - 1))
            A = A * 2 'ya q es una pareja la q se agrega
            Dim i As Integer = 0
            While i < A
                'cargo registro en bd
                DAllave.Llave_item_alta(0, 0, 0, nivel, i + 1, "", llave_id)
                padre = padre + 0.5
                inscriptos = inscriptos - 1

                i = i + 1
            End While
            'End If
        End If
        rutina(padre, nivel, inscriptos, llave_id)

        'AHORA VIENE LA PARTE DE CARGA DE LOS ESTUDIANTES INSCRIPTOS
        'Dim inscriptos_posta As Integer = 3  ahora lo igualo al principio de la rutina
        Select Case inscriptos_posta
            Case 2
                nivel = 1
                rutina_depurada(inscriptos_posta, nivel, llave_id)
            Case 3 To 4
                nivel = 2
                rutina_depurada(inscriptos_posta, nivel, llave_id)
            Case 5 To 8
                nivel = 3
                rutina_depurada(inscriptos_posta, nivel, llave_id)
            Case 9 To 16
                nivel = 4
                inscriptos = 16
                rutina_depurada(inscriptos_posta, nivel, llave_id)
            Case 17 To 32
                nivel = 5
                inscriptos = 32
                rutina_depurada(inscriptos_posta, nivel, llave_id)
        End Select

    End Sub


    Private Sub rutina(ByRef raiz As Integer, ByRef nivel As Integer, ByRef inscriptos As Integer, ByVal llave_id As Integer)
        Dim ds_llaves As DataSet = DAllave.Llave_item_consulta(llave_id)
        nivel = nivel - 1
        If nivel > 0 Then
            Dim A As Integer = (inscriptos + raiz) - (2 ^ (nivel - 1))
            A = A * 2
            Dim i As Integer = 0
            Dim padre As Decimal = 0
            While i < A
                If raiz > 0 Then
                    'consulto reg nivel anterior y tomo par para generar reg nuevo
                    Dim Pizq As Integer = 0
                    Dim Pderech As Integer = 0
                    Dim j As Integer = 0
                    While j < ds_llaves.Tables(0).Rows.Count
                        Dim estado As String = ds_llaves.Tables(0).Rows(j).Item("Llave_item_enlazado")
                        If Pizq = 0 Then
                            Dim nivel_selec As Integer = ds_llaves.Tables(0).Rows(j).Item("Llave_item_nivel")
                            If (nivel_selec = (nivel + 1)) And (estado <> "enlazado") Then
                                Pizq = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                            End If
                            '---original
                            'If (nivel_selec = (nivel + 1)) And (ds_llaves.Tables(0).Rows(j).Item("Llave_item_PIzq") = 0) And (ds_llaves.Tables(0).Rows(j).Item("Llave_item_PDerecho") = 0) And (estado <> "enlazado") Then
                            '    Pizq = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                            'End If
                        Else
                            'busco puntero derecho
                            If Pderech = 0 Then
                                If (ds_llaves.Tables(0).Rows(j).Item("Llave_item_nivel") = (nivel + 1)) And estado <> "enlazado" Then
                                    Pderech = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                                End If
                                '---original
                                'If ds_llaves.Tables(0).Rows(j).Item("Llave_item_nivel") = nivel + 1 And ds_llaves.Tables(0).Rows(j).Item("Llave_item_PDerecho") = 0 And ds_llaves.Tables(0).Rows(j).Item("Llave_item_PIzq") = 0 And estado <> "enlazado" Then
                                '    Pderech = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                                'End If
                            End If
                        End If
                        If Pizq <> 0 And Pderech <> 0 Then
                            'como tengo ambos punteros, a continuacion valido si no hay un registro en el nivel actual que apunte a esos pizq y derecho
                            Dim k As Integer = 0
                            Dim valido As Boolean = True
                            While k < ds_llaves.Tables(0).Rows.Count
                                If ds_llaves.Tables(0).Rows(k).Item("Llave_item_nivel") = nivel And ds_llaves.Tables(0).Rows(k).Item("Llave_item_PIzq") = Pizq And ds_llaves.Tables(0).Rows(k).Item("Llave_item_PDerecho") = Pderech Then
                                    valido = False
                                    k = ds_llaves.Tables(0).Rows.Count
                                End If
                                k = k + 1
                            End While
                            If valido = True Then
                                'actualizar los hijos, poner estado en enlazado
                                '-----------------------------
                                '-----------------------------
                                DAllave.Llave_item_actualizar(Pizq)
                                DAllave.Llave_item_actualizar(Pderech)
                                '-----------------------------
                                '-----------------------------
                                'ahora guardo.
                                Dim nro As Integer = ds_llaves.Tables(0).Rows(ds_llaves.Tables(0).Rows.Count - 1).Item("Llave_item_Numero") + 1
                                DAllave.Llave_item_alta(0, Pizq, Pderech, nivel, nro, "", llave_id)
                                j = ds_llaves.Tables(0).Rows.Count
                            End If
                        End If
                        j = j + 1
                    End While
                    padre = padre + 0.5
                    raiz = raiz - 1
                Else
                    'cargo registro
                    Dim nro As Integer = ds_llaves.Tables(0).Rows(ds_llaves.Tables(0).Rows.Count - 1).Item("Llave_item_Numero") + 1
                    DAllave.Llave_item_alta(0, 0, 0, nivel, nro, "", llave_id)
                    inscriptos = inscriptos - 1
                    padre = padre + 0.5
                End If
                '-----vuelvo a recuperar datos actualizados-----
                ds_llaves = DAllave.Llave_item_consulta(llave_id)
                '-----------------------------------------------
                '-----------------------------------------------
                i = i + 1
            End While
            rutina(padre, nivel, inscriptos, llave_id)
        Else
            '--aqui cargo la raiz o sea el winner
            'consulto reg nivel anterior y tomo par para generar reg nuevo
            Dim Pizq As Integer = 0
            Dim Pderech As Integer = 0
            Dim j As Integer = 0
            While j < ds_llaves.Tables(0).Rows.Count
                Dim estado As String = ds_llaves.Tables(0).Rows(j).Item("Llave_item_enlazado")
                If Pizq = 0 Then
                    Dim nivel_selec As Integer = ds_llaves.Tables(0).Rows(j).Item("Llave_item_nivel")
                    If (nivel_selec = 1) And (estado <> "enlazado") Then
                        Pizq = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                    End If
                    '----original
                    'If (nivel_selec = 1) And (ds_llaves.Tables(0).Rows(j).Item("Llave_item_PIzq") = 0) And (ds_llaves.Tables(0).Rows(j).Item("Llave_item_PDerecho") = 0) And (estado <> "enlazado") Then
                    '    Pizq = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                    'End If
                Else
                    'busco puntero derecho
                    If Pderech = 0 Then
                        If ds_llaves.Tables(0).Rows(j).Item("Llave_item_nivel") = 1 And estado <> "enlazado" Then
                            Pderech = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                        End If
                        '----original
                        'If ds_llaves.Tables(0).Rows(j).Item("Llave_item_nivel") = 1 And ds_llaves.Tables(0).Rows(j).Item("Llave_item_PDerecho") = 0 And ds_llaves.Tables(0).Rows(j).Item("Llave_item_PIzq") = 0 And estado <> "enlazado" Then
                        '    Pderech = ds_llaves.Tables(0).Rows(j).Item("LLave_item_id")
                        'End If
                    End If
                End If
                If Pizq <> 0 And Pderech <> 0 Then
                    'como tengo ambos punteros, a continuacion valido si no hay un registro en el nivel actual que apunte a esos pizq y derecho
                    Dim k As Integer = 0
                    Dim valido As Boolean = True
                    While k < ds_llaves.Tables(0).Rows.Count
                        If ds_llaves.Tables(0).Rows(k).Item("Llave_item_nivel") = nivel And ds_llaves.Tables(0).Rows(k).Item("Llave_item_PIzq") = Pizq And ds_llaves.Tables(0).Rows(k).Item("Llave_item_PDerecho") = Pderech Then
                            valido = False
                            k = ds_llaves.Tables(0).Rows.Count
                        End If
                        k = k + 1
                    End While
                    If valido = True Then
                        'actualizar los hijos, poner estado en enlazado
                        '-----------------------------
                        '-----------------------------
                        DAllave.Llave_item_actualizar(Pizq)
                        DAllave.Llave_item_actualizar(Pderech)
                        '-----------------------------
                        '-----------------------------
                        'ahora guardo.
                        Dim nro As Integer = ds_llaves.Tables(0).Rows(ds_llaves.Tables(0).Rows.Count - 1).Item("Llave_item_Numero") + 1
                        DAllave.Llave_item_alta(0, Pizq, Pderech, nivel, nro, "", llave_id)
                        j = ds_llaves.Tables(0).Rows.Count
                    End If
                End If
                j = j + 1
            End While
        End If
    End Sub

    Private Sub rutina_depurada(ByRef inscriptos As Integer, ByRef nivel As Integer, ByVal llave_id As Integer)
        Dim A As Integer = inscriptos - (2 ^ (nivel - 1))
        A = A * 2 'ya q es una pareja la q se agrega
        Dim i As Integer = 0
        Dim cant_nodos As Integer = 2 ^ (nivel) 'determino la cant de nodos hojas
        Dim n_anterior As Integer = inscriptos - (2 ^ (nivel - 1))
        'While i < A 'aqui veo cuantos se van a agregar en el nivel
        If nivel = 3 Or nivel = 2 Or nivel = 1 Then
            Dim ds_llaves As DataSet = DAllave.Llave_item_consulta_nivel((nivel - 1), llave_id)
            'VEO EL NIVEL ANTERIOR Y SEPARO EN 2 GRUPOS, 9 Y 11, 10 Y 12
            Dim ii As Integer = 0
            Dim LLave_item_id As Integer = 0
            Dim indice_i As Integer = 0
            Dim indice_j As Integer = 2 '(A / 2)
            Dim jj As Integer = (A / 2) + 1
            Dim llave_id_raiz As Integer = 0
            While ii < A
                llave_id_raiz = ds_llaves.Tables(0).Rows(indice_i).Item("LLave_item_id")
                LLave_item_id = ds_llaves.Tables(0).Rows(indice_i).Item("Llave_item_PIzq")
                'aqui actualizo el registro---o sea cargo el participante.------------------------
                Dim usuario_id As Integer = 0
                obtener_inscriptos_categoria(usuario_id)
                DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                '--------------------------------------------------------------------------------
                '--------------------------------------------------------------------------------
                inscriptos = inscriptos - 1
                LLave_item_id = ds_llaves.Tables(0).Rows(indice_i).Item("Llave_item_PDerecho")
                'aqui actualizo el registro---o sea cargo el participante.
                obtener_inscriptos_categoria(usuario_id)
                DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                '-------------------------------------------------------------------------------
                '-------------------------------------------------------------------------------
                inscriptos = inscriptos - 1
                'aqui actualizo la raiz, pongo enlazado listo
                DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                LLave_item_id = 0
                indice_i = indice_i + 1
                ii = ii + 2
                If jj < A Then
                    If nivel = 2 Then
                        indice_j = indice_j - 1
                    End If
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_j).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_j).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_j).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_j = indice_j + 1
                End If
            End While
            'falta hacer que cargue en el nivel de arriba...para ello deberia validar lo q ya estan enlazados de alguna forma.
            ds_llaves = DAllave.Llave_item_consulta_nivel((nivel - 1), llave_id)
            Dim e As Integer = 0
            While e < ds_llaves.Tables(0).Rows.Count
                If ds_llaves.Tables(0).Rows(e).Item("Llave_item_enlazado") = "enlazado" Then 'los "enlazado listo" no los toco, ya estan con hojas en el nivel de abajo
                    llave_id_raiz = ds_llaves.Tables(0).Rows(e).Item("LLave_item_id")
                    Dim usuario_id As Integer = 0
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(llave_id_raiz, usuario_id) 'aqui lo agrego en el nivel anterior a los inscriptos q falten
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz) 'aqui cambio de estado a "enlazado listo"
                    DAllave.Llave_item_quitar_enlace(llave_id_raiz)
                    Dim llave_id_borrar As Integer = ds_llaves.Tables(0).Rows(e).Item("Llave_item_PIzq")
                    'borrar
                    DAllave.Llave_item_borrar_hoja(llave_id_borrar)
                    llave_id_borrar = ds_llaves.Tables(0).Rows(e).Item("Llave_item_PDerecho")
                    'borrar
                    DAllave.Llave_item_borrar_hoja(llave_id_borrar)
                End If
                e = e + 1
            End While
        End If




        If nivel = 4 Then
            Dim ds_llaves As DataSet = DAllave.Llave_item_consulta_nivel((nivel - 1), llave_id)
            'VEO EL NIVEL ANTERIOR Y SEPARO EN 2 GRUPOS, 9 Y 11, 10 Y 12
            Dim ii As Integer = 0
            Dim LLave_item_id As Integer = 0
            Dim indice_i As Integer = 0
            Dim indice_j As Integer = 4 '(A / 2)
            Dim indice_k As Integer = 2
            Dim indice_l As Integer = 6
            Dim jj As Integer = (A / 2) + 1
            Dim llave_id_raiz As Integer = 0
            While ii < A
                llave_id_raiz = ds_llaves.Tables(0).Rows(indice_i).Item("LLave_item_id")
                LLave_item_id = ds_llaves.Tables(0).Rows(indice_i).Item("Llave_item_PIzq")
                'aqui actualizo el registro---o sea cargo el participante.------------------------
                Dim usuario_id As Integer = 0
                obtener_inscriptos_categoria(usuario_id)
                DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                '--------------------------------------------------------------------------------
                '--------------------------------------------------------------------------------
                inscriptos = inscriptos - 1
                LLave_item_id = ds_llaves.Tables(0).Rows(indice_i).Item("Llave_item_PDerecho")
                'aqui actualizo el registro---o sea cargo el participante.
                obtener_inscriptos_categoria(usuario_id)
                DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                '-------------------------------------------------------------------------------
                '-------------------------------------------------------------------------------
                inscriptos = inscriptos - 1
                'aqui actualizo la raiz, pongo enlazado listo
                DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                LLave_item_id = 0
                indice_i = indice_i + 1
                ii = ii + 2
                If ii < A Then ' era jj
                    If nivel = 2 Then
                        indice_j = indice_j - 1
                    End If
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_j).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_j).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_j).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_j = indice_j + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_k).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_k).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_k).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_k = indice_k + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_l).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_l).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_l).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_l = indice_l + 1
                End If
            End While
            'falta hacer que cargue en el nivel de arriba...para ello deberia validar lo q ya estan enlazados de alguna forma.
            ds_llaves = DAllave.Llave_item_consulta_nivel((nivel - 1), llave_id)
            Dim e As Integer = 0
            While e < ds_llaves.Tables(0).Rows.Count
                If ds_llaves.Tables(0).Rows(e).Item("Llave_item_enlazado") = "enlazado" Then 'los "enlazado listo" no los toco, ya estan con hojas en el nivel de abajo
                    llave_id_raiz = ds_llaves.Tables(0).Rows(e).Item("LLave_item_id")
                    Dim usuario_id As Integer = 0
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(llave_id_raiz, usuario_id) 'aqui lo agrego en el nivel anterior a los inscriptos q falten
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz) 'aqui cambio de estado a "enlazado listo"
                    DAllave.Llave_item_quitar_enlace(llave_id_raiz)
                    Dim llave_id_borrar As Integer = ds_llaves.Tables(0).Rows(e).Item("Llave_item_PIzq")
                    'borrar
                    DAllave.Llave_item_borrar_hoja(llave_id_borrar)
                    llave_id_borrar = ds_llaves.Tables(0).Rows(e).Item("Llave_item_PDerecho")
                    'borrar
                    DAllave.Llave_item_borrar_hoja(llave_id_borrar)
                End If
                e = e + 1
            End While
        End If




        If nivel = 5 Then
            Dim ds_llaves As DataSet = DAllave.Llave_item_consulta_nivel((nivel - 1), llave_id)
            'VEO EL NIVEL ANTERIOR Y SEPARO EN 2 GRUPOS, 9 Y 11, 10 Y 12
            Dim ii As Integer = 0
            Dim LLave_item_id As Integer = 0
            Dim indice_i As Integer = 0
            Dim indice_j As Integer = 8 '(A / 2)
            Dim indice_k As Integer = 2
            Dim indice_l As Integer = 10
            Dim indice_m As Integer = 4
            Dim indice_n As Integer = 12
            Dim indice_o As Integer = 6
            Dim indice_p As Integer = 14
            Dim jj As Integer = (A / 2) + 1
            Dim llave_id_raiz As Integer = 0
            While ii < A
                llave_id_raiz = ds_llaves.Tables(0).Rows(indice_i).Item("LLave_item_id")
                LLave_item_id = ds_llaves.Tables(0).Rows(indice_i).Item("Llave_item_PIzq")
                'aqui actualizo el registro---o sea cargo el participante.------------------------
                Dim usuario_id As Integer = 0
                obtener_inscriptos_categoria(usuario_id)
                DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                '--------------------------------------------------------------------------------
                '--------------------------------------------------------------------------------
                inscriptos = inscriptos - 1
                LLave_item_id = ds_llaves.Tables(0).Rows(indice_i).Item("Llave_item_PDerecho")
                'aqui actualizo el registro---o sea cargo el participante.
                obtener_inscriptos_categoria(usuario_id)
                DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                '-------------------------------------------------------------------------------
                '-------------------------------------------------------------------------------
                inscriptos = inscriptos - 1
                'aqui actualizo la raiz, pongo enlazado listo
                DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                LLave_item_id = 0
                indice_i = indice_i + 1
                ii = ii + 2
                If ii < A Then ' era jj
                    If nivel = 2 Then
                        indice_j = indice_j - 1
                    End If
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_j).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_j).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_j).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_j = indice_j + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_k).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_k).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_k).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_k = indice_k + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_l).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_l).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_l).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_l = indice_l + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_m).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_m).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_m).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_m = indice_m + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_n).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_n).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_n).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_n = indice_n + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_o).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_o).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_o).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_o = indice_o + 1
                End If
                If ii < A Then
                    llave_id_raiz = ds_llaves.Tables(0).Rows(indice_p).Item("LLave_item_id")
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_p).Item("Llave_item_PIzq")
                    'aqui actualizo el registro---o sea cargo el participante.
                    'Dim usuario_id As Integer = 0
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    LLave_item_id = ds_llaves.Tables(0).Rows(indice_p).Item("Llave_item_PDerecho")
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(LLave_item_id, usuario_id)
                    '-------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------
                    inscriptos = inscriptos - 1
                    'aqui actualizo el registro---o sea cargo el participante.
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz)
                    LLave_item_id = 0
                    jj = jj + 2
                    ii = ii + 2
                    indice_p = indice_p + 1
                End If
            End While
            'falta hacer que cargue en el nivel de arriba...para ello deberia validar lo q ya estan enlazados de alguna forma.
            ds_llaves = DAllave.Llave_item_consulta_nivel((nivel - 1), llave_id)
            Dim e As Integer = 0
            While e < ds_llaves.Tables(0).Rows.Count
                If ds_llaves.Tables(0).Rows(e).Item("Llave_item_enlazado") = "enlazado" Then 'los "enlazado listo" no los toco, ya estan con hojas en el nivel de abajo
                    llave_id_raiz = ds_llaves.Tables(0).Rows(e).Item("LLave_item_id")
                    Dim usuario_id As Integer = 0
                    'aqui actualizo el registro---o sea cargo el participante.
                    obtener_inscriptos_categoria(usuario_id)
                    DAllave.Llave_item_actualizar_usuario(llave_id_raiz, usuario_id) 'aqui lo agrego en el nivel anterior a los inscriptos q falten
                    DAllave.Llave_item_actualizar_raiz(llave_id_raiz) 'aqui cambio de estado a "enlazado listo"
                    DAllave.Llave_item_quitar_enlace(llave_id_raiz)
                    Dim llave_id_borrar As Integer = ds_llaves.Tables(0).Rows(e).Item("Llave_item_PIzq")
                    'borrar
                    DAllave.Llave_item_borrar_hoja(llave_id_borrar)
                    llave_id_borrar = ds_llaves.Tables(0).Rows(e).Item("Llave_item_PDerecho")
                    'borrar
                    DAllave.Llave_item_borrar_hoja(llave_id_borrar)
                End If
                e = e + 1
            End While
        End If




        '----ESTO LLAVE 8
        'If n_anterior <= 4 And n_anterior > 2 Then 'busco en nivel 2
        'End If
        ''
        'If n_anterior <= 2 And n_anterior > 0 Then 'busco en nivel 1
        'End If
        'cargo registro en bd
        'actualizar nodo.. para ello debo recuperar el id del
        'DAusuario.Llave_item_alta(0, 0, 0, nivel, i + 1, "")
        'padre = padre + 0.5
        'inscriptos = inscriptos - 1
        'i = i + 1
        'End While
    End Sub

    Dim inscriptos_aux_cargada As String = "no" 'esto me indica si la tabla ha sido cargada o no
    Dim inscriptos_aux2_cargada As String = "no" 'esto me indica si la tabla esta cargada o no, la uso para el random
    Dim inscriptos_aux2 As New DataTable
    Dim ordenar_instructorID As String="" 'esta en vacio indicando que puedo cargar cualquier alumno, cambiara de valor cuando se ingrese un alumno y valido asi no pongo 2 juntos en la primera pelea
    Private Function obtener_inscriptos_categoria(ByRef usuario_id As Integer)
        'a los inscriptos que tengo tildados los voy agregando en un dataset auxiliar, donde el estado va a ser agregado="no"
        Dim SELECCIONADO As CheckBox
        If inscriptos_aux_cargada = "no" Then
            Dim j As Integer = 0
            While j < GridView1.Rows.Count
                SELECCIONADO = CType(GridView1.Rows(j).FindControl("CheckBox_item"), CheckBox)
                If SELECCIONADO.Checked = True Then
                    Dim row As DataRow = key_insc_ds.Tables("inscriptos_aux").NewRow()
                    row("usuario_id") = GridView1.Rows(j).Cells(1).Text ' la celda 1 es el ID en teoría
                    row("agregado") = "no"
                    row("instructor_id") = GridView1.Rows(j).Cells(7).Text 'la celda 7 es el id de instructor es en teoria
                    key_insc_ds.Tables("inscriptos_aux").Rows.Add(row)
                End If
                j = j + 1
            End While
            inscriptos_aux_cargada = "si"
        End If
        If inscriptos_aux2_cargada = "no" Then
            'ahora que tengo los inscriptos checkeados en la tabla inscriptos_aux, voy a ver que prioridad le asigne en el combo (aletatorio, profesor, provincia).
            If DropDownList1.SelectedValue = "Random" Then
                'si es aleatorio "random", los voy a ir cargando en otra tabla aleatorioamente
                'Dim inscriptos_aux2 As New DataTable ---la pongo afuera de la funcion
                inscriptos_aux2 = key_insc_ds.Tables("inscriptos_aux").Clone 'clona la estructura, no su contenido, para eso esta copy
                'inscriptos_aux2.Rows.Clear() 'borro el contenido de la tabla, en primer lugar
                Dim k As Integer = 0
                Dim cont_inscriptos As Integer = key_insc_ds.Tables("inscriptos_aux").Rows.Count
                While k < cont_inscriptos
                    Dim intervalo_max As Integer = key_insc_ds.Tables("inscriptos_aux").Rows.Count - 1 'menos 1 por el indice en las tablas
                    Dim intervalo_minimo As Integer = 0 'es cero x q aqui empieza la tabla
                    'Dim indice_random As Integer = CInt(Int((intervalo_max * Rnd()) + intervalo_minimo))
                    Dim indice_random As Integer = CInt(Math.Ceiling(Rnd() * intervalo_max)) + intervalo_minimo
                    Dim h As Integer = 0
                    Dim add As String = "no"
                    While h < inscriptos_aux2.Rows.Count
                        If key_insc_ds.Tables("inscriptos_aux").Rows(indice_random).Item("usuario_id") = inscriptos_aux2.Rows(h).Item("usuario_id") Then
                            'indice_random = CInt(Int((intervalo_max * Rnd()) + intervalo_minimo))
                            indice_random = CInt(Math.Ceiling(Rnd() * intervalo_max)) + intervalo_minimo
                            h = 0 'vuelvo a cero x q el nro random generado ya estaba cargado en la tabla
                        Else
                            h = h + 1
                        End If
                    End While
                    Dim row As DataRow = inscriptos_aux2.NewRow()
                    row("usuario_id") = key_insc_ds.Tables("inscriptos_aux").Rows(indice_random).Item("usuario_id") ' la celda 1 es el ID en teoría
                    row("agregado") = "no"
                    'key_insc_ds.Tables("inscriptos_aux").Rows.Add(row)
                    inscriptos_aux2.Rows.Add(row)
                    'quito un row de la tabla inscriptos_aux para reducir la carga del random
                    key_insc_ds.Tables("inscriptos_aux").Rows.RemoveAt(indice_random)
                    k = k + 1 'voy sumando hasta llegar a la cantidad de inscriptos necesaria en la tabla random
                End While
                inscriptos_aux2_cargada = "si"
            End If
            If DropDownList1.SelectedValue = "Instructor" Then
                key_insc_ds.Tables("inscriptos_aux").DefaultView.Sort = "instructor_id ASC"
                inscriptos_aux2 = key_insc_ds.Tables("inscriptos_aux").DefaultView.ToTable
                Dim contador As Integer = inscriptos_aux2.Rows.Count
                inscriptos_aux2_cargada = "si"
            End If
            'Dim cont_aux2 As Integer = inscriptos_aux2.Rows.Count
        End If

        'ahora recupero en un ciclo, los inscriptos de a uno en uno.
        '////////////////////ESTE CODIGO SIRVE PARA CARGARLOS EN ORDEN DE LA GRILLA///////////////////
        'Dim i As Integer = 0
        'While i < key_insc_ds.Tables("inscriptos_aux").Rows.Count
        '    If key_insc_ds.Tables("inscriptos_aux").Rows(i).Item("agregado") <> "si" Then
        '        usuario_id = key_insc_ds.Tables("inscriptos_aux").Rows(i).Item("usuario_id")
        '        key_insc_ds.Tables("inscriptos_aux").Rows(i).Item("agregado") = "si"
        '        i = key_insc_ds.Tables("inscriptos_aux").Rows.Count
        '    Else
        '        i = i + 1
        '    End If
        'End While
        '//////////////////////////////////////////////////////////////////////////////////////////

        'esto es con la funcion de random aplicada
        If DropDownList1.SelectedValue = "Random" Then
            Dim i As Integer = 0
            While i < inscriptos_aux2.Rows.Count
                If inscriptos_aux2.Rows(i).Item("agregado") <> "si" Then
                    usuario_id = inscriptos_aux2.Rows(i).Item("usuario_id")
                    inscriptos_aux2.Rows(i).Item("agregado") = "si"
                    i = inscriptos_aux2.Rows.Count
                Else
                    i = i + 1
                End If
            End While
        End If
        'esto es con la funcion de ordenar x instructor, te separa los alumnos de un instructor lo mas que pueda
        If DropDownList1.SelectedValue = "Instructor" Then
            Dim i As Integer = 0
            While i < inscriptos_aux2.Rows.Count
                If inscriptos_aux2.Rows(i).Item("agregado") <> "si" Then
                    If ordenar_instructorID = "" Then
                        usuario_id = inscriptos_aux2.Rows(i).Item("usuario_id")
                        inscriptos_aux2.Rows(i).Item("agregado") = "si"
                        ordenar_instructorID = inscriptos_aux2.Rows(i).Item("instructor_id")
                        'inscriptos_aux2.Rows.RemoveAt(i)
                        i = inscriptos_aux2.Rows.Count
                    Else
                        If ordenar_instructorID <> inscriptos_aux2.Rows(i).Item("instructor_id") Then
                            Dim distintos As String = "si" 'si es alguno de los instructores anteriores no lo agrego.
                            Dim j As Integer = i
                            'While j < inscriptos_aux2.Rows.Count
                            If (ordenar_instructorID = inscriptos_aux2.Rows(j).Item("instructor_id")) And inscriptos_aux2.Rows(j).Item("agregado") = "si" Then

                                distintos = "no"
                            End If
                            j = j + 1
                            'End While
                            If distintos = "si" Then
                                usuario_id = inscriptos_aux2.Rows(i).Item("usuario_id")
                                inscriptos_aux2.Rows(i).Item("agregado") = "si"
                                ordenar_instructorID = inscriptos_aux2.Rows(i).Item("instructor_id")
                                'inscriptos_aux2.Rows.RemoveAt(i)
                                i = inscriptos_aux2.Rows.Count
                            End If
                            i = i + 1
                        Else
                            If i = (inscriptos_aux2.Rows.Count - 1) Then
                                ordenar_instructorID = ""
                                i = 0
                            Else
                                i = i + 1
                            End If
                        End If
                    End If
                Else
                    i = i + 1
                End If
            End While
        End If


        'falta codigo para provincia e institucion, dos opciones mas en el dropdown de prioridad., el codigo es similar al de "instructor".


        Return usuario_id
    End Function

    
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
                key_insc_ds.Tables("Llaves_generadas").Rows.Add(row_insc)
                i = i + 1
            End While
            GridView2.DataSource = key_insc_ds.Tables("Llaves_generadas")
            GridView2.DataBind()

        End If

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
            obtener_categorias(HF_evento_id.Value)
            obtener_llaves_generadas_info()
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
                'Response.Redirect("Llave_2.aspx") 'este si va es IMPORTANTE
                'Response.Redirect("~/Visor_reporte_llave2.aspx") 'ESTE LO USO PARA VER EN CRISTAL
                Response.Redirect("~/Reportes/Llaves/Visor_ejemplo.aspx")

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

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "CheckBox_all") Then
            Dim a As Integer = 0
            a = a + 1

        End If
    End Sub

    Private Sub Eliminar_llave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Eliminar_llave.ServerClick
        eliminar_llave_seleccionada()
    End Sub

    Private Sub Eliminar_inscripto_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Eliminar_inscripto.ServerClick

        rutina_eliminar_inscripto()

    End Sub

    Private Sub rutina_eliminar_inscripto()
        Dim borrado As String = "no"
        'primero recorro la grilla 1 para ver si se selecciono algo
        Dim SELECCIONADO As CheckBox
        Dim i As Integer = 0
        While i < GridView1.Rows.Count
            SELECCIONADO = CType(GridView1.Rows(i).FindControl("CheckBox_item"), CheckBox)
            If SELECCIONADO.Checked = True Then
                'como esta seleccionado procedo a borrar:
                Dim usuario_id As Integer = CInt(GridView1.Rows(i).Cells(1).Text)
                DAinscrip.Inscripcion_borrar_alumno(usuario_id, HF_evento_id.Value)
                borrado = "si"
            End If
            i = i + 1
        End While
        If borrado = "si" Then
            obtener_categorias(HF_evento_id.Value)
            obtener_llaves_generadas_info()
        End If

    End Sub

    Private Sub DropDown_categoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_categoria.SelectedIndexChanged
        busqueda() 'va a recuperar un listado de los inscriptos segun los combos seleccionados
    End Sub

    Private Sub Gen_llave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Gen_llave.ServerClick


    End Sub

    '-------------------------------------------------------------------------------------------------------
    'modificacion: 2022-08-31

    Private Sub REORDENAR_LLAVE_PRIORIDAD_PROFES(ByVal llave_id As Integer)
        Dim ds_llave As DataSet = DAllave.Llave_para_reordenar(llave_id)
        If ds_llave.Tables(0).Rows.Count <> 0 Then
            'aqui me fijo primero cuales son pareja y los voy a meter en un dataset, donde 1 columna me dice que son pareja o single.
            'si tienen el mismo numero en la columna son pareja, si esta 1 sola vez es single.

            'Llaves_ds2.tables("Llave_pareja_single").
            Dim Llaves_ds2 As New Llaves_ds


            Dim pareja As String = "pareja2"
            Dim i As Integer = 0
            While i < ds_llave.Tables(0).Rows.Count
                Dim usuario_id As Integer = CInt(ds_llave.Tables(0).Rows(i).Item("Llave_item_usuario_id"))
                If usuario_id <> 0 Then
                    'es competidor
                    Dim Llave_item_id As Integer = CInt(ds_llave.Tables(0).Rows(i).Item("Llave_item_id"))
                    'busco la llave_item_id en otro registro, en el puntero derecho o izquierdo.
                    Dim j As Integer = 0
                    While j < ds_llave.Tables(1).Rows.Count
                        Dim Llave_item_PIzqp As Integer = CInt(ds_llave.Tables(1).Rows(j).Item("Llave_item_PIzq"))
                        Dim Llave_item_PDerecho As Integer = CInt(ds_llave.Tables(1).Rows(j).Item("Llave_item_PDerecho"))
                        If Llave_item_id = Llave_item_PIzqp Then
                            'me fijo que ocurre con el derecho. si no esta en table(0) es un competidor "single" o Libre
                            Dim k As Integer = 0
                            Dim existe = "no"
                            While k < ds_llave.Tables(0).Rows.Count
                                If Llave_item_PDerecho = ds_llave.Tables(0).Rows(k).Item("Llave_item_id") Then
                                    existe = "si"
                                    Exit While
                                End If
                                k = k + 1
                            End While

                            Dim fila As DataRow = Llaves_ds2.Tables("Llave_pareja_single").NewRow
                            fila("Llave_item_id") = Llave_item_id
                            fila("Llave_item_usuario_id") = usuario_id
                            fila("USUARIO") = ds_llave.Tables(0).Rows(i).Item("USUARIO")
                            fila("instructor_id") = ds_llave.Tables(0).Rows(i).Item("instructor_id")
                            If existe = "si" Then
                                If pareja = "pareja1" Then
                                    pareja = "pareja2"
                                Else
                                    pareja = "pareja1"
                                End If

                                'lo ingreso como pareja
                                fila("tipo") = pareja
                            Else
                                fila("tipo") = "single"
                            End If
                            Llaves_ds2.Tables("Llave_pareja_single").Rows.Add(fila)
                        Else
                            If Llave_item_id = Llave_item_PDerecho Then
                                'me fijo que ocurre con el izquierdo. si no esta en table(0) es un competidor "single" o Libre
                                Dim k As Integer = 0
                                Dim existe = "no"
                                While k < ds_llave.Tables(0).Rows.Count
                                    If Llave_item_PIzqp = ds_llave.Tables(0).Rows(k).Item("Llave_item_id") Then
                                        existe = "si"
                                        Exit While
                                    End If
                                    k = k + 1
                                End While

                                Dim fila As DataRow = Llaves_ds2.Tables("Llave_pareja_single").NewRow
                                fila("Llave_item_id") = Llave_item_id
                                fila("Llave_item_usuario_id") = usuario_id
                                fila("USUARIO") = ds_llave.Tables(0).Rows(i).Item("USUARIO")
                                fila("instructor_id") = ds_llave.Tables(0).Rows(i).Item("instructor_id")
                                If existe = "si" Then
                                    If pareja = "pareja1" Then
                                        pareja = "pareja2"
                                    Else
                                        pareja = "pareja1"
                                    End If
                                    'lo ingreso como pareja
                                    fila("tipo") = pareja
                                Else
                                    fila("tipo") = "single"
                                End If
                                Llaves_ds2.Tables("Llave_pareja_single").Rows.Add(fila)
                            End If
                        End If

                        j = j + 1
                    End While

                End If

                i = i + 1
            End While

            If Llaves_ds2.Tables("Llave_pareja_single").Rows.Count <> 0 Then
                'aqui comienza la reorganización
                '1) voy a contar la cant de registros por instructor
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////
                i = 0
                While i < Llaves_ds2.Tables("Llave_pareja_single").Rows.Count
                    Dim instructor_id As Integer = CInt(Llaves_ds2.Tables("Llave_pareja_single").Rows(i).Item("instructor_id"))
                    Dim j As Integer = 0
                    Dim existe = "no"
                    While j < Llaves_ds2.Tables("Inscriptos_x_instructor").Rows.Count
                        If instructor_id = Llaves_ds2.Tables("Inscriptos_x_instructor").Rows(j).Item("instructor_id") Then
                            Llaves_ds2.Tables("Inscriptos_x_instructor").Rows(j).Item("cantidad") = CInt(Llaves_ds2.Tables("Inscriptos_x_instructor").Rows(j).Item("cantidad")) + 1
                            existe = "si"
                            Exit While
                        End If
                        j = j + 1
                    End While
                    If existe = "no" Then
                        Dim fila As DataRow = Llaves_ds2.Tables("Inscriptos_x_instructor").NewRow
                        fila("instructor_id") = instructor_id
                        fila("cantidad") = 1
                        Llaves_ds2.Tables("Inscriptos_x_instructor").Rows.Add(fila)
                    End If
                    i = i + 1
                End While
                'ordeno la tabla Inscriptos_x_instructor  por la columna cantidad.
                Dim dtV As DataView = Llaves_ds2.Tables("Inscriptos_x_instructor").DefaultView
                dtV.Sort = "cantidad DESC"
                Dim dt_list As DataTable = dtV.ToTable
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////
                If dt_list.Rows.Count Then
                    Llaves_ds2.Tables("Llave_pareja_single1").Merge(Llaves_ds2.Tables("Llave_pareja_single"))
                    'o) voy a quitar de estos registros el usuario, instructor_id, llave_item_usuario_id
                    i = 0
                    While i < Llaves_ds2.Tables("Llave_pareja_single1").Rows.Count
                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(i).Item("Llave_item_usuario_id") = 0
                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(i).Item("USUARIO") = ""
                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(i).Item("instructor_id") = 0
                        i = i + 1
                    End While

                    'este dt_list tiene el conteo de registros de todos los instructores: ejemplo instructor 45, cant 3. instructor 10, cant 2. instructor 60, cant 1.
                    i = 0
                    'primero determino cuantos inscriptos son...x que voy a ir metiendo 1 arriba y otro abajo.
                    Dim cant_insc As Integer = Llaves_ds2.Tables("Llave_pareja_single").Rows.Count
                    Dim inicio As Integer = 0
                    Dim medio As Integer = 0
                    If cant_insc Mod (2) = 0 Then
                        'es par
                        medio = cant_insc / 2
                    Else
                        medio = CInt(cant_insc / 2) + 1
                    End If

                    Dim mov_inicio As Integer = inicio
                    Dim mov_medio As Integer = medio
                    Dim donde_poner As String = "arriba"
                    Dim ingreso_secuenal As String = ""
                    While i < dt_list.Rows.Count
                        Dim instructor_id = CInt(dt_list.Rows(i).Item(0))

                        Dim j As Integer = 0
                        While j < Llaves_ds2.Tables("Llave_pareja_single").Rows.Count
                            If instructor_id = Llaves_ds2.Tables("Llave_pareja_single").Rows(j).Item("instructor_id") Then
                                Dim usuario_id As Integer = Llaves_ds2.Tables("Llave_pareja_single").Rows(j).Item("Llave_item_usuario_id")
                                Dim USUARIO As String = Llaves_ds2.Tables("Llave_pareja_single").Rows(j).Item("USUARIO")
                                If ingreso_secuenal = "si" Then

                                    Dim h As Integer = 0
                                    While h < Llaves_ds2.Tables("Llave_pareja_single1").Rows.Count
                                        If Llaves_ds2.Tables("Llave_pareja_single1").Rows(h).Item("instructor_id") = 0 Then
                                            Llaves_ds2.Tables("Llave_pareja_single1").Rows(h).Item("Llave_item_usuario_id") = usuario_id
                                            Llaves_ds2.Tables("Llave_pareja_single1").Rows(h).Item("USUARIO") = USUARIO
                                            Llaves_ds2.Tables("Llave_pareja_single1").Rows(h).Item("instructor_id") = instructor_id
                                            Exit While
                                        End If
                                        h = h + 1
                                    End While

                                Else
                                    If donde_poner = "arriba" Then

                                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_inicio).Item("Llave_item_usuario_id") = usuario_id
                                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_inicio).Item("USUARIO") = USUARIO
                                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_inicio).Item("instructor_id") = instructor_id
                                        If Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_inicio).Item("tipo") = "pareja1" Then
                                            mov_inicio = mov_inicio + 2
                                            donde_poner = "abajo"
                                        Else
                                            mov_inicio = mov_inicio + 1
                                            donde_poner = "abajo"
                                        End If


                                    Else
                                        'poner abajo
                                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_medio).Item("Llave_item_usuario_id") = usuario_id
                                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_medio).Item("USUARIO") = USUARIO
                                        Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_medio).Item("instructor_id") = instructor_id
                                        If Llaves_ds2.Tables("Llave_pareja_single1").Rows(mov_medio).Item("tipo") = "pareja1" Then
                                            mov_medio = mov_medio + 2
                                            donde_poner = "arriba"
                                        Else
                                            mov_medio = mov_medio + 1
                                            donde_poner = "arriba"
                                        End If

                                    End If

                                    If donde_poner = "abajo" Then
                                        'verifico si no estoy al final
                                        If (mov_medio = medio + 1) Or (mov_medio > medio + 1) Then
                                            'verifico si no estoy al final de parte de arriba
                                            If (mov_inicio = medio) Or (mov_inicio > medio) Then
                                                ingreso_secuenal = "si"
                                            End If
                                            ''ya no puedo ingresar mas...entonces voy colocando secuencial
                                            'ingreso_secuenal = "si"
                                        End If
                                    Else
                                        If donde_poner = "arriba" Then
                                            'verifico si no estoy al final de parte de arriba
                                            If (mov_inicio = medio) Or (mov_inicio > medio) Then
                                                'ya no puedo ingresar mas aqui...
                                                If (mov_medio = medio + 1) Or (mov_medio > medio + 1) Then
                                                    'ya no puedo ingresar mas...entonces voy colocando secuencial.
                                                    ingreso_secuenal = "si"
                                                Else
                                                    donde_poner = "abajo"
                                                End If
                                            End If
                                        End If
                                    End If
                                End If

                            End If
                            j = j + 1
                        End While

                        i = i + 1
                    End While


                End If
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////


                If Llaves_ds2.Tables("Llave_pareja_single1").Rows.Count <> 0 Then

                    'aqui guardo las actualizaciones en la bd.

                    Dim k As Integer = 0
                    While k < Llaves_ds2.Tables("Llave_pareja_single1").Rows.Count

                        Dim LLave_item_id As Integer = CInt(Llaves_ds2.Tables("Llave_pareja_single1").Rows(k).Item("Llave_item_id"))
                        Dim Llave_item_usuario_id As Integer = CInt(Llaves_ds2.Tables("Llave_pareja_single1").Rows(k).Item("Llave_item_usuario_id"))
                        DAllave.Llave_item_actualizar_orden(LLave_item_id, Llave_item_usuario_id)

                        k = k + 1
                    End While



                End If


            End If


        End If



    End Sub


    '-------------------------------------------------------------------------------------------------------

    Private Sub add_key_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles add_key.ServerClick
        'valido que solo se generen llaves si previamente el evento tiene areas asignadas, el combo debe tener algun area disponible.
        If DropDownList_areas.Items.Count <> 0 Then
            'cuento la cantidad de inscriptos que haya seleccionado de la grilla 1
            Dim SELECCIONADO As CheckBox
            Dim i As Integer = 0
            Dim cantidad_inscriptos As Integer = 0
            While i < GridView1.Rows.Count
                SELECCIONADO = CType(GridView1.Rows(i).FindControl("CheckBox_item"), CheckBox)
                If SELECCIONADO.Checked = True Then
                    cantidad_inscriptos = cantidad_inscriptos + 1
                End If
                i = i + 1
            End While
            If cantidad_inscriptos > 1 Then
                Dim c_inscri As Integer = cantidad_inscriptos
                'primero voy a borrar las llave q se haya creado si es necesario
                'DAllave.llave_eliminar(CInt(HF_evento_id.Value), DropDown_categoria.SelectedValue)
                'aqui voy a poner la rutina para generar la llave.
                Dim llave_id_generada As Integer = 0

                generar_llave(cantidad_inscriptos, llave_id_generada)
                Try
                    If llave_id_generada <> 0 Then
                        'aqui estoy forzando un reordenamiento de la llave, para evitar en lo posible parejas del mismo instructor
                        REORDENAR_LLAVE_PRIORIDAD_PROFES(llave_id_generada)


                    End If
                Catch ex As Exception

                End Try


                'esto me servia para q una vez generada la llave, vaya directamente a mostrarla en los form q corresponda
                'If (c_inscri = 2) Then
                '    Response.Redirect("Llave_2.aspx")
                'End If
                'If (c_inscri > 2) And (c_inscri <= 4) Then
                '    Response.Redirect("Llave_4.aspx")
                'End If
                'If (c_inscri > 4) And (c_inscri <= 8) Then
                '    Response.Redirect("Llave_8.aspx")
                'End If
                'If (c_inscri > 8) And (c_inscri <= 16) Then
                '    Response.Redirect("Llave_16.aspx")
                'End If
                'If (c_inscri > 16) And (c_inscri <= 32) Then
                '    Response.Redirect("Llave_32.aspx")
                'End If
                'vuelvo a llamar estas rutinas porque al generar una llave, puede q ya no este disponible la categoria x falta de inscriptos
                obtener_categorias(HF_evento_id.Value)
                obtener_llaves_generadas_info()

                '++++++++++++++Esto hago para que se haga visible el cartel de "llave generada correctamente"++++++++++++++
                div_modalllaveOK.Visible = True
                Modal_llaveOK.Show()

                'ademas muestro en el gridview 1 los inscriptos que aun faltan agregar a una llave.
                busqueda()
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Else
                Modal_llaveError.Show()
                div_modalllaveError.Visible = True
            End If
        Else
            'aqui va un cartel que diga que no existen areas en el evento seleccionado
        End If
    End Sub
End Class