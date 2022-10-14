Public Class Credenciales_generar
    Inherits System.Web.UI.Page
    Dim DAllave As New Capa_de_datos.Llave
    Dim DAinscripciones As New Capa_de_datos.Inscripciones
    Dim key_insc_ds As New Llaves_ds
    Dim credenciales_ds As New Credenciales_ds
    Dim DAinstructor As New Capa_de_datos.Instructor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Lb_evento.Text = Session("evento_desc")
            Dim evento_id = Session("evento_id")
            HF_evento_id.Value = Session("evento_id") 'esto lo uso x el prolongado tiempo de una sesion
            Lb_fecha.Text = Session("fecha")
            Lb_fecha_cierre.Text = Session("fecha_cierre")
            obtener_inscriptos_para_credenciales()
            'obtener_categorias(HF_evento_id.Value)
            'obtener_llaves_generadas_info()
            'div_modalllaveOK.Visible = False
            'div_modalllaveError.Visible = False
            'categorias_ObtenerInscriptos(evento_id)
            'div_Modal_err.Visible = False
            'div_Modal_error_generacion.Visible = False

            'busqueda() 'va a recuperar un listado de los inscriptos segun los combos seleccionados
        End If
    End Sub

    Private Sub obtener_inscriptos_para_credenciales()
        Dim ds_inscripciones As DataSet = DAinscripciones.Inscripciones_credenciales_obtener(Session("evento_id"))
        'credenciales_ds.Tables("Credenciales").Merge(ds_inscripciones.Tables(0))
        GridView1.DataSource = ds_inscripciones.Tables(1)
        GridView1.DataBind()

    End Sub



    'Private Sub obtener_categorias(ByVal evento_id As Integer)
    '    key_insc_ds.Tables("Categorias_inscriptos").Rows.Clear()
    '    DropDown_categoria.DataSource = ""
    '    GridView1.DataSource = ""
    '    GridView1.DataBind()

    '    Dim ds_categorias As DataSet = DAllave.LLave_obtener_inscriptos_filtrados(evento_id, DropDown_modalidad.SelectedValue)
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
    '            Dim peso_inicial As String = ds_categorias.Tables(0).Rows(i).Item("categoria_peso_inical")
    '            Dim peso_final As String = ds_categorias.Tables(0).Rows(i).Item("categoria_peso_Final")
    '            Dim sexo As String = ds_categorias.Tables(0).Rows(i).Item("categoria_sexo")
    '            'ahora junto todas las variables para mostrar en categoria
    '            Dim categoria As String = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
    '            If tipo = "Lucha" Then
    '                categoria = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)" + " de " + peso_inicial + " a " + peso_final + " Kilos"
    '            End If
    '            Dim row_insc As DataRow = key_insc_ds.Tables("Categorias_inscriptos").NewRow()
    '            Dim Estado = "Pendiente"
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
    '            Dim ds_Estado As DataSet = DAllave.Llave_Verificar_existencia(categoria_id, Session("evento_id"))
    '            If ds_Estado.Tables(0).Rows.Count <> 0 Then
    '                Estado = "Generado"
    '            End If

    '            row_insc("Estado") = Estado
    '            key_insc_ds.Tables("Categorias_inscriptos").Rows.Add(row_insc)
    '        End While




    '        'GridView1.DataSource = key_insc_ds.Tables("Categorias_inscriptos")
    '        'GridView1.DataBind()

    '        'colorear_pendientes()
    '    End If

    '    'If key_insc_ds.Tables("Categorias_inscriptos").Rows.Count <> 0 Then
    '    DropDown_categoria.DataSource = key_insc_ds.Tables("Categorias_inscriptos")
    '    DropDown_categoria.DataValueField = "id"
    '    DropDown_categoria.DataTextField = "Categoria"
    '    DropDown_categoria.DataBind()
    '    'GridView3.DataSource = key_insc_ds.Tables("Categorias_inscriptos")

    '    'End If



    'End Sub

    'Private Sub busqueda()
    '    GridView1.DataSource = Nothing
    '    GridView1.DataBind()
    '    'realiza la busqueda de los inscriptos dependiendo de los combos seleccionados
    '    If DropDown_categoria.Items.Count <> 0 Then
    '        Dim ds As DataSet = DAllave.LLave_obtener_inscriptos_sin_llave(HF_evento_id.Value, DropDown_categoria.SelectedValue)
    '        GridView1.DataSource = ds.Tables(0)
    '        GridView1.DataBind()
    '        label_catseleccionada.Text = DropDown_categoria.SelectedItem.Text
    '    Else
    '        label_catseleccionada.Text = ""
    '    End If
    'End Sub


  


    Private Sub Button_addkey_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_addkey.ServerClick
        generar_credenciales2()

        'credenciales_ds.Tables("Credenciales").Rows.Clear()

        'Dim seleccionado As CheckBox

        'Dim j As Integer = 0
        'Dim ds_inscripciones As DataSet = DAinscripciones.Inscripciones_credenciales_obtener(Session("evento_id"))
        'While j < GridView1.Rows.Count
        '    seleccionado = CType(GridView1.Rows(j).FindControl("CheckBox_item"), CheckBox)
        '    If seleccionado.Checked = True Then
        '        'ahora lo busco en el data set
        '        Dim id As Integer = CInt(GridView1.Rows(j).Cells(1).Text)
        '        Dim i As Integer = 0
        '        While i < ds_inscripciones.Tables(0).Rows.Count
        '            If id = ds_inscripciones.Tables(0).Rows(i).Item("usuario_id") Then
        '                'ahora lo agrego a un dataset nuevo
        '                Dim row_insc As DataRow = credenciales_ds.Tables("Credenciales").NewRow
        '                row_insc("evento_id") = ds_inscripciones.Tables(0).Rows(i).Item("evento_id")
        '                row_insc("evento_descripcion") = ds_inscripciones.Tables(0).Rows(i).Item("evento_descripcion")
        '                row_insc("evento_foto") = ds_inscripciones.Tables(0).Rows(i).Item("evento_foto")
        '                row_insc("evento_fecha") = ds_inscripciones.Tables(0).Rows(i).Item("evento_fecha")
        '                row_insc("usuario_doc") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_doc")
        '                row_insc("usuario_apellido") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_apellido")
        '                row_insc("usuario_nombre") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_nombre")
        '                row_insc("graduacion") = ds_inscripciones.Tables(0).Rows(i).Item("graduacion")
        '                row_insc("usuario_telefono") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_telefono")
        '                'busco el instructor en su tabla para obtener el apellido y nombre
        '                Dim instructor_id As Integer = ds_inscripciones.Tables(0).Rows(i).Item("instructor_id")
        '                Dim ds_busqueda As DataSet = DAinstructor.Instructor_obtener_INFO(instructor_id)
        '                row_insc("instructor") = ds_busqueda.Tables(0).Rows(0).Item("ApellidoyNombre")
        '                row_insc("usuario_foto") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_foto")
        '                credenciales_ds.Tables("Credenciales").Rows.Add(row_insc)
        '            End If
        '            i = i + 1
        '        End While
        '    End If

        '    j = j + 1
        'End While
        'If credenciales_ds.Tables("Credenciales").Rows.Count <> 0 Then
        '    Session("dataset_cred_seleccionadas") = credenciales_ds.Tables("Credenciales")
        '    Session("evento_id") = HF_evento_id.Value
        '    Response.Redirect("Credenciales_visor.aspx")
        'End If
    End Sub

    Private Sub generar_credenciales2()
        credenciales_ds.Tables("Credenciales_2").Rows.Clear()

        Dim seleccionado As CheckBox

        Dim j As Integer = 0
        Dim ds_inscripciones As DataSet = DAinscripciones.Inscripciones_credenciales_obtener(Session("evento_id"))


        Dim row_creado As String = "si"
        Dim row_insc As DataRow = credenciales_ds.Tables("Credenciales_2").NewRow
        Dim row_crea_otro As String = "no"

        While j < GridView1.Rows.Count
            seleccionado = CType(GridView1.Rows(j).FindControl("CheckBox_item"), CheckBox)

            If seleccionado.Checked = True Then
                'ahora lo busco en el data set
                Dim id As Integer = CInt(GridView1.Rows(j).Cells(1).Text)
                Dim i As Integer = 0

                While i < ds_inscripciones.Tables(0).Rows.Count
                    If id = ds_inscripciones.Tables(0).Rows(i).Item("usuario_id") Then
                        'ahora lo agrego a un dataset nuevo
                        If row_creado = "si" Then
                            If row_crea_otro = "si" Then
                                row_insc = credenciales_ds.Tables("Credenciales_2").NewRow
                                row_crea_otro = "no"
                            End If
                            row_insc("evento_id") = ds_inscripciones.Tables(0).Rows(i).Item("evento_id")
                            row_insc("evento_descripcion") = ds_inscripciones.Tables(0).Rows(i).Item("evento_descripcion")
                            row_insc("evento_foto") = ds_inscripciones.Tables(0).Rows(i).Item("evento_foto")
                            row_insc("evento_fecha") = ds_inscripciones.Tables(0).Rows(i).Item("evento_fecha")
                            row_insc("usuario_doc") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_doc")
                            row_insc("usuario_apellido") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_apellido").ToString.ToUpper
                            row_insc("usuario_nombre") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_nombre").ToString.ToUpper
                            row_insc("graduacion") = ds_inscripciones.Tables(0).Rows(i).Item("graduacion")
                            ' row_insc("usuario_telefono") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_telefono")
                            row_insc("usuario_telefono") = ""
                            'busco el instructor en su tabla para obtener el apellido y nombre
                            Dim instructor_id As Integer = ds_inscripciones.Tables(0).Rows(i).Item("instructor_id")
                            Dim ds_busqueda As DataSet = DAinstructor.Instructor_obtener_INFO(instructor_id)
                            row_insc("instructor") = ds_busqueda.Tables(0).Rows(0).Item("ApellidoyNombre")
                            row_insc("usuario_foto") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_foto")
                            row_insc("inscripcion_id") = ds_inscripciones.Tables(0).Rows(i).Item("inscripcion_id")

                            '////////////////aqui va en blanco el segundo registro///////////////////////
                            'van vacios los datos
                            credenciales_ds.Tables("Credenciales_2").Rows.Add(row_insc)
                            row_creado = "no"
                        Else
                            'aqui se carga el segundo, en el mismo registro creado previamente.
                            Dim a As Integer = credenciales_ds.Tables("Credenciales_2").Rows.Count - 1 'este es el indice del ultimo agregado
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("evento_descripcion2") = ds_inscripciones.Tables(0).Rows(i).Item("evento_descripcion")
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("evento_foto2") = ds_inscripciones.Tables(0).Rows(i).Item("evento_foto")
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("evento_fecha2") = ds_inscripciones.Tables(0).Rows(i).Item("evento_fecha")
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("usuario_doc2") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_doc")
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("usuario_apellido2") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_apellido").ToString.ToUpper
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("usuario_nombre2") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_nombre").ToString.ToUpper
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("graduacion_2") = ds_inscripciones.Tables(0).Rows(i).Item("graduacion")
                            'credenciales_ds.Tables("Credenciales_2").Rows(a).Item("usuario_telefono2") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_telefono")
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("usuario_telefono2") = ""
                            'busco el instructor en su tabla para obtener el apellido y nombre
                            Dim instructor_id As Integer = ds_inscripciones.Tables(0).Rows(i).Item("instructor_id")
                            Dim ds_busqueda As DataSet = DAinstructor.Instructor_obtener_INFO(instructor_id)
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("instructor_2") = ds_busqueda.Tables(0).Rows(0).Item("ApellidoyNombre")
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("usuario_foto2") = ds_inscripciones.Tables(0).Rows(i).Item("usuario_foto")
                            credenciales_ds.Tables("Credenciales_2").Rows(a).Item("inscripcion_id2") = ds_inscripciones.Tables(0).Rows(i).Item("inscripcion_id")
                            row_creado = "si"
                            row_crea_otro = "si"
                        End If
                        i = ds_inscripciones.Tables(0).Rows.Count
                    End If
                    i = i + 1
                End While
            End If

            j = j + 1
        End While
        If credenciales_ds.Tables("Credenciales_2").Rows.Count <> 0 Then
            Session("dataset_cred_seleccionadas") = credenciales_ds.Tables("Credenciales_2")
            Session("evento_id") = HF_evento_id.Value
            Response.Redirect("Credenciales_visor.aspx")
        End If


    End Sub
End Class