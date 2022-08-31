Public Class Llave_detalle_evento
    Inherits System.Web.UI.Page

    Dim DAllave As New Capa_de_datos.Llave
    Dim key_insc_ds As New Llaves_ds
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
            Lb_evento.Text = Session("evento_desc")
            Dim evento_id = Session("evento_id")
            HF_evento_id.Value = Session("evento_id") 'esto lo uso x el prolongado tiempo de una sesion
            Lb_fecha.Text = Session("fecha")
            Lb_fecha_cierre.Text = Session("fecha_cierre")
            categorias_ObtenerInscriptos(evento_id)
            div_Modal_err.Visible = False
            div_Modal_error_generacion.Visible = False
        End If
    End Sub

    Private Sub categorias_ObtenerInscriptos(ByVal evento_id As Integer)
        Dim ds_categorias As DataSet = DAllave.LLave_obtener_inscriptos(evento_id)
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
            GridView1.DataSource = key_insc_ds.Tables("Categorias_inscriptos")
            GridView1.DataBind()

            colorear_pendientes()
        End If
    End Sub

    Private Sub colorear_pendientes()
        Dim i As Integer = 0
        While i < GridView1.Rows.Count
            If GridView1.Rows(i).Cells(3).Text = "Pendiente" Then
                GridView1.Rows(i).ForeColor = Drawing.Color.Red
                GridView1.Rows(i).BackColor = Drawing.Color.LightGray
            End If
            i = i + 1
        End While
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "Id_categoria") Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            Session("categoria_id") = id
            'verifico que la categoria tenga el estado en "generado"
            Dim i As Integer = 0
            Dim valido As String = "no"
            While i < GridView1.Rows.Count
                If GridView1.Rows(i).Cells(0).Text = id And GridView1.Rows(i).Cells(3).Text = "Generado" Then
                    valido = "si"
                    Dim c_inscri As Integer = CInt(GridView1.Rows(i).Cells(2).Text)
                    If (c_inscri = 2) Then
                        Response.Redirect("Llave_2.aspx")
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
                    If (c_inscri > 17) And (c_inscri <= 32) Then
                        Response.Redirect("Llave_32.aspx")
                    End If
                End If
                i = i + 1
            End While
            If valido = "no" Then
                div_Modal_err.Visible = True
                Modal_error.Show()
            End If

        End If



        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")
            Session("categoria_id") = id

            'Session("evento_id")

            Dim i As Integer = 0
            Dim cantidad_inscriptos As Integer = 0
            While i < GridView1.Rows.Count
                Dim id_categoria As Integer = CInt(GridView1.Rows(i).Cells(0).Text)
                If id_categoria = index Then
                    cantidad_inscriptos = CInt(GridView1.Rows(i).Cells(2).Text) 'es la cantidad
                    'Session("evento_desc") = GridView1.Rows(i).Cells(1).Text
                    i = GridView1.Rows.Count
                Else
                    i = i + 1
                End If
            End While

            Dim c_inscri As Integer = cantidad_inscriptos



            'primero voy a borrar las llave q se haya creado si es necesario

            'DAllave.llave_eliminar(CInt(HF_evento_id.Value), id)
            'DAllave.llave_eliminar(Session("evento_id"), id) lo comento x q no quiero usar algo de sesion q se pueda perder si se prolonga el tiempo

            'aqui voy a poner la rutina para generar la llave.
            generar_llave(cantidad_inscriptos)

            If (c_inscri = 2) Then
                Response.Redirect("Llave_2.aspx")
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

    Private Sub generar_llave(ByVal inscriptos As Integer)
        Dim inscriptos_posta As Integer = inscriptos
        'primero alta de la categoria en la tabla llave.
        Dim ds_llave As DataSet = DAllave.Llave_alta(CInt(HF_evento_id.Value), Session("categoria_id"), inscriptos, 0) 'lo edito x que falta el parametro de area_id
        'inscriptos = 3
        Dim llave_id As Integer = ds_llave.Tables(0).Rows(0).Item("Llave_id")


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

    Private Function obtener_inscriptos_categoria(ByRef usuario_id As Integer)
        Dim ds_insc As DataSet = DAllave.LLave_obtener_inscriptos_categoria(CInt(HF_evento_id.Value), Session("categoria_id"))
        'ahora lo combino con un ds creado en el diseñador.
        key_insc_ds.Tables("inscriptos_aux").Merge(ds_insc.Tables(0))
        'ahora recupero en un ciclo, los inscriptos de a uno en uno.
        Dim i As Integer = 0
        While i < key_insc_ds.Tables("inscriptos_aux").Rows.Count
            If key_insc_ds.Tables("inscriptos_aux").Rows(i).Item("agregado") <> "si" Then
                usuario_id = key_insc_ds.Tables("inscriptos_aux").Rows(i).Item("usuario_id")
                key_insc_ds.Tables("inscriptos_aux").Rows(i).Item("agregado") = "si"
                i = key_insc_ds.Tables("inscriptos_aux").Rows.Count
            Else
                i = i + 1
            End If
        End While
        Return usuario_id
    End Function


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub
End Class