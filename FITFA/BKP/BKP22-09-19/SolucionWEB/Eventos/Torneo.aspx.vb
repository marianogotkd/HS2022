Public Class Torneo
    Inherits System.Web.UI.Page
    Dim DA_evento As New Capa_de_datos.Eventos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Carga_inicial_LOAD()

            'div_msj_error_eliminar.Visible = False



        End If
    End Sub

    Dim Torneo_ds As New Torneo_ds
    Dim Torneo_ds_2 As New Torneo_ds 'lo uso para cargar los categorias donde solo hay 1 inscripto

    Public resumen As New Torneo_ds.Torneo_resumenDataTable
    Private Sub Carga_inicial_LOAD()
        HD_evento_id.Value = Session("evento_id")
        Dim evento_id As Integer = CInt(Session("evento_id"))
        Dim ds_info As DataSet = DA_evento.Torneo_recuperar_inscriptos(evento_id)

        If ds_info.Tables(1).Rows.Count <> 0 Then
            Dim i As Integer = 0
            While i < ds_info.Tables(1).Rows.Count
                Dim fila As DataRow = Torneo_ds.Torneo_resumen.NewRow
                fila("Modalidad") = ds_info.Tables(1).Rows(i).Item("categoria_tipo")
                Dim categoria_id As Integer = ds_info.Tables(1).Rows(i).Item("categoria_id")

                '------------------armado de cadena--------------------------
                Dim tipo As String = ds_info.Tables(1).Rows(i).Item("categoria_tipo")
                Dim sexo As String = ds_info.Tables(1).Rows(i).Item("categoria_sexo")
                Dim graduacion_desde As String = ""
                Dim k As Integer = 0
                While k < ds_info.Tables(2).Rows.Count 'esta tabla tiene las graduaciones
                    If (ds_info.Tables(2).Rows(k).Item("graduacion_id") = ds_info.Tables(1).Rows(i).Item("categoria_gradinicial")) Then
                        graduacion_desde = ds_info.Tables(2).Rows(k).Item("graduacion_desc")
                        Exit While
                    End If
                    k = k + 1
                End While
                'busco graduacion hasta
                Dim graduacion_hasta As String = ""
                k = 0
                While k < ds_info.Tables(2).Rows.Count
                    If ds_info.Tables(2).Rows(k).Item("graduacion_id") = ds_info.Tables(1).Rows(i).Item("categoria_gradfinal") Then
                        graduacion_hasta = ds_info.Tables(2).Rows(k).Item("graduacion_desc")
                        Exit While
                    End If
                    k = k + 1
                End While
                Dim edad_desde As String = ds_info.Tables(1).Rows(i).Item("categoria_edadinicial")
                Dim edad_hasta As String = ds_info.Tables(1).Rows(i).Item("categoria_edadfinal")
                Dim peso_inicial As String = ds_info.Tables(1).Rows(i).Item("categoria_peso_inical")
                Dim peso_final As String = ds_info.Tables(1).Rows(i).Item("categoria_peso_Final")
                '------------------------------------------------------------

                Dim categoria As String = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)"
                If tipo = "Lucha" Then
                    categoria = tipo + " " + sexo + ", " + graduacion_desde + "-" + graduacion_hasta + "(" + edad_desde + " a " + edad_hasta + " años)" + " de " + peso_inicial + " a " + peso_final + " Kilos"
                End If
                fila("Categoria") = categoria
                fila("categoria_id") = categoria_id
                fila("Cantidad") = 1

                Dim j As Integer = 0
                Dim encontrado = "no"
                While j < Torneo_ds.Torneo_resumen.Rows.Count
                    If Torneo_ds.Torneo_resumen.Rows(j).Item("categoria_id") = categoria_id Then
                        Torneo_ds.Torneo_resumen.Rows(j).Item("Cantidad") = CInt(Torneo_ds.Torneo_resumen.Rows(j).Item("Cantidad")) + 1
                        encontrado = "si"
                        Exit While
                    End If
                    j = j + 1
                End While
                If encontrado = "no" Then
                    'agrego
                    Torneo_ds.Torneo_resumen.Rows.Add(fila)
                End If
                i = i + 1
            End While


        Else
            Div1_grilla.Visible = False
            Div1_grilla_solouno.Visible = False
        End If
        resumen.Merge(Torneo_ds.Torneo_resumen)



        Label_evento_b.Text = "Evento: " + CStr(ds_info.Tables(0).Rows(0).Item("evento_descripcion"))
        Label_evento_direccion_b.Text = "Direccion: " + CStr(ds_info.Tables(0).Rows(0).Item("evento_direccion"))
        Label_evento_fecha_b.Text = "Fecha: " + CStr(ds_info.Tables(0).Rows(0).Item("evento_fecha"))
        Dim cant_inscriptos As Integer = 0
        Dim ii As Integer = 0
        'While ii < Torneo_ds.Torneo_resumen.Rows.Count
        '    cant_inscriptos = cant_inscriptos + CInt(Torneo_ds.Torneo_resumen.Rows(ii).Item("Cantidad"))
        '    ii = ii + 1
        'End While
        Label_evento_cant_inscriptos_b.Text = "Cantidad de inscriptos: " + CStr(ds_info.Tables(3).Rows.Count)


        ii = 0
        While ii < Torneo_ds.Torneo_resumen.Rows.Count
            If Torneo_ds.Torneo_resumen.Rows(ii).Item("Cantidad") = 1 Then
                Dim fila As DataRow = Torneo_ds_2.Torneo_resumen.NewRow
                fila("Modalidad") = Torneo_ds.Torneo_resumen.Rows(ii).Item("Modalidad")
                fila("Categoria") = Torneo_ds.Torneo_resumen.Rows(ii).Item("Categoria")
                fila("Cantidad") = Torneo_ds.Torneo_resumen.Rows(ii).Item("Cantidad")
                fila("categoria_id") = Torneo_ds.Torneo_resumen.Rows(ii).Item("categoria_id")
                Torneo_ds_2.Torneo_resumen.Rows.Add(fila)
                Torneo_ds.Torneo_resumen.Rows.RemoveAt(ii)
                ii = 0 'reinicio
            Else
                ii = ii + 1
            End If
        End While


        If Torneo_ds.Torneo_resumen.Rows.Count <> 0 Then
            GridView1.DataSource = Torneo_ds.Torneo_resumen
            GridView1.DataBind()
        Else
            Div1_grilla.Visible = False
        End If

        If Torneo_ds_2.Torneo_resumen.Rows.Count <> 0 Then
            GridView2.DataSource = Torneo_ds_2.Torneo_resumen
            GridView2.DataBind()
        Else
            Div1_grilla_solouno.Visible = False
        End If
    End Sub


    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            Session("categoria_id") = CInt(id)
            Session("evento_id") = CInt(HD_evento_id.Value)
            Session("evento_descripcion") = Label_evento_b.Text
            Session("evento_fecha") = Label_evento_fecha_b.Text

            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)


            Session("evento_categoria") = CType(row.Cells(2), DataControlFieldCell).Text

            Response.Redirect("Torneo_insc.aspx")
        End If
    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If (e.CommandName = "ID") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            Session("categoria_id") = CInt(id)
            Session("evento_id") = CInt(HD_evento_id.Value)
            Session("evento_descripcion") = Label_evento_b.Text
            Session("evento_fecha") = Label_evento_fecha_b.Text

            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)


            Session("evento_categoria") = CType(row.Cells(2), DataControlFieldCell).Text

            Response.Redirect("Torneo_insc.aspx")
        End If
    End Sub

End Class