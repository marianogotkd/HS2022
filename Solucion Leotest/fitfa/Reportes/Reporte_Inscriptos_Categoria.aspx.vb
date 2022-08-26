Public Class Reporte_Inscriptos_Categoria
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DAllave As New Capa_de_datos.Llave
    Dim DAinscrip As New Capa_de_datos.Inscripciones
    Dim key_insc_ds As New Llaves_ds
    Dim evento_id

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obtener_eventos_disponibles()


        evento_id = DropDown_Evento.SelectedValue

      
        obtener_categorias(DropDown_Evento.SelectedValue)
       

    End Sub

    

    Private Sub busqueda()
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        'realiza la busqueda de los inscriptos dependiendo de los combos seleccionados
        If DropDown_categoria.Items.Count <> 0 Then
            Dim ds As DataSet = DAllave.LLave_obtener_inscriptos_sin_llave(evento_id, DropDown_categoria.SelectedValue)
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
            label_catseleccionada.Text = DropDown_categoria.SelectedItem.Text
        Else
            label_catseleccionada.Text = ""
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

    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_ObetenerEventos()
        If ds_eventos.Tables(1).Rows.Count <> 0 Then
            DropDown_Evento.DataSource = ds_eventos.Tables(1)
            DropDown_Evento.DataValueField = "id"
            DropDown_Evento.DataTextField = "desc"
            DropDown_Evento.DataBind()
        End If
    End Sub

    Protected Sub DropDown_modalidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDown_modalidad.SelectedIndexChanged
        obtener_categorias(evento_id)
        busqueda() 'va a recuperar un listado de los inscriptos segun los combos seleccionados
    End Sub
End Class