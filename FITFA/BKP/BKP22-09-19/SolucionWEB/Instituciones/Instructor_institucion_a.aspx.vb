Public Class Instructor_institucion_a
    Inherits System.Web.UI.Page
    Dim DAinstitucion As New Capa_de_datos.Instituciones
    Dim ds_a As New DS_instituciones  'este conjunto de datos lo creo en la solucion. en la carpeta instituciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ds_institucion As DataSet = DAinstitucion.institucion_instructores_obtenertodos
            GridView1.DataSource = ds_institucion.Tables(0)
            GridView1.DataBind()
        End If
    End Sub

    Private Sub continuar()
        'verifico si hay algun instructor seleccionado
        Dim SELECCIONADO As CheckBox
        Dim i As Integer = 0
        Dim tildado As String = "no"
        While i < GridView1.Rows.Count
            SELECCIONADO = CType(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox)
            If SELECCIONADO.Checked = True Then
                'como esta seleccionado procedo a pasar los parametros al proximo form q se va a abrir
                Dim instructor_id As Integer = CInt(GridView1.Rows(i).Cells(1).Text)
                Session("instructor_id") = instructor_id
                Response.Redirect("~/Instituciones/Instructor_institucion_b.aspx")

                i = GridView1.Rows.Count
                tildado = "si"
            End If
            i = i + 1
        End While
        If tildado = "no" Then
            'aqui mensaje, debe seleccionar instructor del listado
        End If

    End Sub



    Private Sub Continuar_a_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Continuar_a.ServerClick
        continuar()
    End Sub

    Private Sub Continuar_b_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Continuar_b.ServerClick
        continuar()
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        'Dim SELECCIONADO As CheckBox = CType(GridView1.Rows(0).FindControl("CheckBox1"), CheckBox)
        'SELECCIONADO.Checked = True
        'CType(GridView1.Rows(0).FindControl("CheckBox1"), CheckBox).Checked = True

    End Sub

    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
        If txt_buscar.Text <> "" Then
            'aqui hago la busqueda por dni o bien concatenado apellido y nombre
            Dim valido As String = "no"
            ds_a.Tables("Instructores").Rows.Clear()
            busqueda_cargar_grilla(valido)
            'If Session("Us_recursivo") Is Nothing Then
            '    ds_a.Tables("Tabla_alumnos").Rows.Clear()
            '    busqueda_cargar_grilla(Session("Us_id"), valido)
            'Else
            '    If Session("Us_recursivo") <> Session("Us_id") Then
            '        ds_a.Tables("Tabla_alumnos").Rows.Clear()
            '        busqueda_cargar_grilla(Session("Us_recursivo"), valido)
            '    Else
            '        ds_a.Tables("Tabla_alumnos").Rows.Clear()
            '        busqueda_cargar_grilla(Session("Us_id"), valido)
            '    End If
            'End If

            GridView1.DataSource = ds_a.Tables("Instructores")
            GridView1.DataBind()

            If GridView1.Rows.Count = 0 Then
                'msj_busqueda_error.Visible = True
                'Lb_busqueda_error.Visible = True
            Else
                'Lb_busqueda_error.Visible = False
            End If
        Else
            Dim ds_institucion As DataSet = DAinstitucion.institucion_instructores_obtenertodos
            GridView1.DataSource = ds_institucion.Tables(0)
            GridView1.DataBind()

        End If
    End Sub

    Private Function busqueda_cargar_grilla(ByRef valido As String)
        '-----RECUERDA QUE HAY Q VALIDAR 2 BUSQUEDAS, X APELLIDO Y NOMBRE CON EL "LIKE" Y DOC..EXACTO, ADEMAS Q SEA UNA BUSQUEDA RECURSIVA...SINO ENCUENTRA AL ALUMNO EN DICHA ESCUELA, NO SE LO MUESTRA
        Dim ds_alumn As DataSet = DAinstitucion.institucion_instructores_obtenertodos
        'Dim usuario_id As Integer = Session("Us_id")
        If ds_alumn.Tables(0).Rows.Count <> 0 Then


            Dim i As Integer = 0
            While i < ds_alumn.Tables(0).Rows.Count
                Dim buscaraqui As String = CStr(ds_alumn.Tables(0).Rows(i).Item("Apellido_y_Nombre")).ToUpper
                Dim buscaresto As String = CStr(txt_buscar.Text).ToUpper
                Dim primer_caracter_encontrado As Integer = buscaraqui.IndexOf(buscaresto)

                Dim buscaraqui2 As String = CStr(ds_alumn.Tables(0).Rows(i).Item("provincia_desc")).ToUpper
                Dim buscaresto2 As String = CStr(txt_buscar.Text).ToUpper
                Dim primer_caracter_encontrado2 As Integer = buscaraqui2.IndexOf(buscaresto2)

                If CStr(ds_alumn.Tables(0).Rows(i).Item("usuario_doc")) = CStr(txt_buscar.Text) Or primer_caracter_encontrado <> -1 Or primer_caracter_encontrado2 <> -1 Then
                    'si lo encuentro lo agrego

                    Dim row As DataRow = ds_a.Tables("Instructores").NewRow()
                    row("instructor_id") = ds_alumn.Tables(0).Rows(i).Item("instructor_id")
                    row("Apellido_y_Nombre") = ds_alumn.Tables(0).Rows(i).Item("Apellido_y_Nombre")
                    row("usuario_doc") = ds_alumn.Tables(0).Rows(i).Item("usuario_doc")
                    row("provincia_desc") = ds_alumn.Tables(0).Rows(i).Item("provincia_desc")
                    ds_a.Tables("Instructores").Rows.Add(row)
                    valido = "si"
                End If
                i = i + 1
            End While
        Else
            valido = "no"

        End If


        Return valido
    End Function
End Class