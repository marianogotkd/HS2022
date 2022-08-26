Public Class Carga_Manual_Competidores
    Inherits System.Web.UI.Page
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim DSCategorias As New Categorias
    Dim DA_categoria As New Capa_de_datos.Cargar_Competidores
    Dim DT_Inscriptos As New Categorias
    Dim DAinscripciones As New Capa_de_datos.Inscripciones


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            obtener_eventos_disponibles()
            'Session("popup") = "si"
            ''popup = "no"
            'choco.Visible = False
            Obtener_Categorias()
            popupMsjGuardado.Visible = False

        End If
       

    End Sub


    Private Sub obtener_eventos_disponibles()
        Dim ds_eventos As DataSet = DAeventos.Evento_ObetenerEventos()
        If ds_eventos.Tables(1).Rows.Count <> 0 Then
            DropDownList_eventos.DataSource = ds_eventos.Tables(1)
            DropDownList_eventos.DataValueField = "id"
            DropDownList_eventos.DataTextField = "desc"
            DropDownList_eventos.DataBind()
        End If
    End Sub

    Private Sub Obtener_Categorias()
        Dim ds_categorias As DataSet = DA_categoria.Carga_Competidor_Obtener_Categorias(DropDownList_Sexo.SelectedValue, Drop_modalida.SelectedValue)

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
                Dim sexo As String = ds_categorias.Tables(0).Rows(i).Item("categoria_sexo")
                Dim Pesodesde As String = ds_categorias.Tables(0).Rows(i).Item("categoria_peso_inical")
                Dim Pesohasta As String = ds_categorias.Tables(0).Rows(i).Item("categoria_peso_Final")
                'ahora junto todas las variables para mostrar en categoria
                Dim categoria As String = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
                If Drop_modalida.SelectedValue = "Lucha" Then
                    categoria = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)" + " de " + Pesodesde + " a " + Pesohasta + " Kilos"
                End If

                Dim row As DataRow = DSCategorias.Tables("Categorias").NewRow()
                row("categoria_id") = ds_categorias.Tables(0).Rows(i).Item("categoria_id")
                row("Descripcion") = categoria
                DSCategorias.Tables("Categorias").Rows.Add(row)
               
                i = i + 1

            End While

            DropDownList4.DataSource = DSCategorias.Tables("Categorias")
            DropDownList4.DataValueField = "categoria_id"
            DropDownList4.DataTextField = "Descripcion"
            DropDownList4.DataBind()

        End If



    End Sub

    
    Protected Sub Drop_modalida_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Drop_modalida.SelectedIndexChanged
        Obtener_Categorias()
    End Sub

    Protected Sub DropDownList_Sexo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList_Sexo.SelectedIndexChanged
        Obtener_Categorias()
    End Sub

    Protected Sub Btn_Agregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Agregar.Click
       


        Dim cantidad As Integer = DT_Inscriptos.Tables("Inscriptos").Rows.Count
        Dim asad As Integer = GridView1.Rows.Count

        


        If GridView1.Rows.Count <> 0 Then
            'ciclo y cargo
            Dim i As Integer = 0
            While (i < GridView1.Rows.Count)
                Dim row As DataRow = DT_Inscriptos.Tables("Inscriptos").NewRow()
                row("Numero") = GridView1.Rows(i).Cells(0).Text
                row("Nombre") = GridView1.Rows(i).Cells(1).Text
                row("Apellido") = GridView1.Rows(i).Cells(2).Text
                DT_Inscriptos.Tables("Inscriptos").Rows.Add(row)
                i = i + 1
            End While
        End If


        Dim rows As DataRow = DT_Inscriptos.Tables("Inscriptos").NewRow()
        rows("Numero") = DT_Inscriptos.Tables("Inscriptos").Rows.Count + 1
        rows("Nombre") = tb_nombre.Text
        rows("Apellido") = tb_apellido.Text
        DT_Inscriptos.Tables("Inscriptos").Rows.Add(rows)

        GridView1.DataSource = DT_Inscriptos.Tables("Inscriptos")
        GridView1.DataBind()

    End Sub

    Protected Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        Dim indice As Integer = 0
        While (indice < GridView1.Rows.Count)


            Dim ds_Guardar_Inscriptos As DataSet = DA_categoria.Carga_Competidor_Guardar(GridView1.Rows(indice).Cells(2).Text, GridView1.Rows(indice).Cells(1).Text, 23, 0, DropDownList_eventos.SelectedValue, Today, 50, DropDownList4.SelectedValue)
            indice = indice + 1

        End While
        popupMsjGuardado.Visible = True
        ModalPopupExtender_guardado.Show()
    End Sub

    Protected Sub Btn_Agregar0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Agregar0.Click
        Dim fila As Integer = GridView1.Rows.Count - 1

        If GridView1.Rows.Count <> 0 Then
            'ciclo y cargo
            Dim i As Integer = 0
            While (i < GridView1.Rows.Count)
                Dim row As DataRow = DT_Inscriptos.Tables("Inscriptos").NewRow()
                row("Numero") = GridView1.Rows(i).Cells(0).Text
                row("Nombre") = GridView1.Rows(i).Cells(1).Text
                row("Apellido") = GridView1.Rows(i).Cells(2).Text
                DT_Inscriptos.Tables("Inscriptos").Rows.Add(row)
                i = i + 1
            End While

            DT_Inscriptos.Tables("Inscriptos").Rows(fila).Delete()
            GridView1.DataSource = DT_Inscriptos.Tables("Inscriptos")
            GridView1.DataBind()

        End If
    End Sub

    Private Sub Btb_ok_inscripcion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btb_ok_inscripcion.Click
        Response.Redirect("Carga_Manual_Competidores.aspx")
    End Sub
End Class