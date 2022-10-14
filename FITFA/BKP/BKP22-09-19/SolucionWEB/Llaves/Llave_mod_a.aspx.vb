Public Class Llave_mod_a
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
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B1.ToolTip = tooltext
                        B1.Text = "(" + idtext + ")"
                    Case 2
                        If Llave_item_usuario_id <> 0 Then
                            B2.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B2.ToolTip = tooltext
                        B2.Text = "(" + idtext + ")"
                    Case 3
                        If Llave_item_usuario_id <> 0 Then
                            B3.Visible = True
                        End If
                        colocar_tooltrip(B1, ds_categorias, item_nro, tooltext, idtext)
                        B3.ToolTip = tooltext
                        B3.Text = "(" + idtext + ")"
                End Select
                i = i + 1
            End While
        End If
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

    Private Sub B1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B1.Click
        actualizar_llave(B1, B3, B2)
        If B3.Visible = True Then
            LB_WINNER.visible = True
        End If
    End Sub
    Private Sub actualizar_llave(ByRef boton_desde As Button, ByRef boton_hasta As Button, ByRef boton_versus As Button)

        If boton_versus.Visible = True Then
            boton_hasta.Visible = True
            boton_hasta.Text = boton_desde.Text
            boton_hasta.ToolTip = boton_desde.ToolTip
        End If

    End Sub

    Private Sub B2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B2.Click
        actualizar_llave(B2, B3, B1)
        If B3.Visible = True Then
            LB_WINNER.Visible = True
        End If
    End Sub
End Class