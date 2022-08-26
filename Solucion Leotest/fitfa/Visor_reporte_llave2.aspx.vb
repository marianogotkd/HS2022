Public Class Visor_reporte_llave2
    Inherits System.Web.UI.Page
    Dim DAllave As New Capa_de_datos.Llave
    Dim categoria_id As Integer = 0
    Dim evento_id As Integer = 0
    Dim llave_id As Integer = 0
    Dim DS_reporte_llaves As New DS_reporte_llaves  'lo uso para crear los datatable necesarios para mandar al rpt de crystal que corresponda
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            categoria_id = Session("categoria_id")
            evento_id = Session("evento_id")
            llave_id = Session("llave_id")
            llenar_encabezados(evento_id, categoria_id, llave_id)
        End If
    End Sub


    Private Sub llenar_encabezados(ByVal evento_id As Integer, ByVal categoria_id As Integer, ByVal llave_id As Integer)
        Dim ds_categorias As DataSet = DAllave.LLave_obtener_llavegenerada_etc_2(llave_id)
        'Lb_evento.Text = ds_categorias.Tables(0).Rows(0).Item("evento_descripcion")
        'Lb_fecha.Text = ds_categorias.Tables(0).Rows(0).Item("evento_fecha")
        'Lb_fecha_cierre.Text = ds_categorias.Tables(0).Rows(0).Item("evento_fechacierre")



        Dim row_evento As DataRow = DS_reporte_llaves.Tables("Evento").NewRow()
        row_evento("evento") = ds_categorias.Tables(0).Rows(0).Item("evento_descripcion")
        row_evento("fecha_evento") = ds_categorias.Tables(0).Rows(0).Item("evento_fecha")
        row_evento("llave_id") = llave_id
        row_evento("llave_cantidad") = ds_categorias.Tables(0).Rows(0).Item("inscriptos")
        row_evento("evento_id") = evento_id
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
            row_evento("Categoria") = categoria
        End If
        DS_reporte_llaves.Tables("Evento").Rows.Add(row_evento)



        'aqui cargo el label lb_categoria
        'Dim ds_categorias As DataSet = DAllave.LLave_obtener_inscriptos(evento_id)

        If ds_categorias.Tables(0).Rows.Count <> 0 Then
            Dim B1, B2, B3 As String
            B1 = ""
            B2 = ""
            B3 = ""

            'ahora pongo en visible solo los botones dependiendo de los inscriptos
            Dim i As Integer = 0
            While i < ds_categorias.Tables(2).Rows.Count
                Dim item_nro As Integer = CInt(ds_categorias.Tables(2).Rows(i).Item("Llave_item_Numero"))
                Dim Llave_item_usuario_id As Integer = CInt(ds_categorias.Tables(2).Rows(i).Item("Llave_item_usuario_id"))

                Dim tooltext As String = ""
                Dim idtext As String = ""
                Select Case item_nro
                    Case 1
                        colocar_tooltrip(ds_categorias, item_nro, tooltext, idtext)
                        If tooltext <> "" Then
                            B1 = "(" + idtext + ")" + tooltext
                        End If
                    Case 2
                        colocar_tooltrip(ds_categorias, item_nro, tooltext, idtext)
                        If tooltext <> "" Then
                            B2 = "(" + idtext + ")" + tooltext
                        End If
                    Case 3
                        colocar_tooltrip(ds_categorias, item_nro, tooltext, idtext)
                        If tooltext <> "" Then
                            B3 = "(" + idtext + ")" + tooltext
                        End If
                End Select
                i = i + 1
            End While
            'aqui agrego B1, B2 Y B3 al dataset
            Dim row_llave As DataRow = DS_reporte_llaves.Tables("llave_2").NewRow()
            row_llave("B1") = B1
            row_llave("B2") = B2
            row_llave("B3") = B3
            row_llave("evento_id") = evento_id
            DS_reporte_llaves.Tables("llave_2").Rows.Add(row_llave)


            'CrystalReportSource1.ReportDocument.SetDataSource(DS_reporte_llaves)


            'CrystalReportSource1.ReportDocument.SetDataSource(DS_reporte_llaves.Tables("llave_2"))


            'CrystalReportViewer1.DataBind()


        End If
    End Sub

    Private Sub colocar_tooltrip(ByVal ds As DataSet, ByVal item_nro As Integer, ByRef tooltext As String, ByRef idtext As String)
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

End Class