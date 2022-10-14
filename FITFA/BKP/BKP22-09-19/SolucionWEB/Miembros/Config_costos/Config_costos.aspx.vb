Public Class Config_costos
    Inherits System.Web.UI.Page
    Dim DAinstructor As New Capa_de_datos.Instructor
    Dim Dagraduacion As New Capa_de_datos.Graduacion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            div_modalOK.Visible = False

            'Session("Us_id") 'esta es la variable que me dice quien esta logueado.
            Dim usuario_id As Integer = Session("Us_id")
            graduaciones_obtener()
            instructores_recuperar(usuario_id)
        End If
    End Sub
    Private Sub graduaciones_obtener()
        Dim ds_grad As DataSet = Dagraduacion.Graduacion_obtener_todo
        Try
            DropDownList_graduacion.DataSource = ds_grad.Tables(0)
            DropDownList_graduacion.DataTextField = "graduacion_desc"
            DropDownList_graduacion.DataValueField = "graduacion_id"
            DropDownList_graduacion.DataBind()
            DropDownList_graduacion.SelectedValue = 12
        Catch ex As Exception

        End Try
    End Sub

    Private Sub graduaciones_recuperar()

        DropDownList_graduacion.DataTextField = "graduacion_desc"
        DropDownList_graduacion.DataValueField = "graduacion_id"
        DropDownList_graduacion.DataBind()
        'DropDownList_graduacion.SelectedValue = graduacion_id
    End Sub
    Dim DS_configcostos As New DS_configcostos
    Private Sub instructores_recuperar(ByVal usuario_id As Integer)
        DS_configcostos.Miembros.Rows.Clear()
        Dim ds_instructores As DataSet = DAinstructor.Instructor_obtener_solo_alumnos_INSTRUCTORES(usuario_id)
        DS_configcostos.Miembros.Merge(ds_instructores.Tables(0))


        Dim i As Integer = 0
        While i < ds_instructores.Tables(0).Rows.Count
            Dim id_usuario As Integer = CInt(ds_instructores.Tables(0).Rows(i).Item("usuario_id"))
            instructores_agregar_recursivo(id_usuario)
            i = i + 1
        End While


        Dim vistaordenada As System.Data.DataView
        vistaordenada = DS_configcostos.Miembros.DefaultView
        vistaordenada.Sort = DS_configcostos.Miembros.Columns(7).ColumnName + " Desc, " + DS_configcostos.Miembros.Columns(2).ColumnName + " Asc" 'ordenado x graduacion_id desc y apellido,nomb asc
        GridView_examenes.DataSource = vistaordenada
        'GridView_examenes.DataSource = ds_instructores.Tables(0)
        GridView_examenes.DataBind()

    End Sub

    Private Sub instructores_agregar_recursivo(ByVal id_usuario As Integer)
        Dim ds_instructores As DataSet = DAinstructor.Instructor_obtener_solo_alumnos_INSTRUCTORES(id_usuario)
        'los agrego a todos
        If ds_instructores.Tables(0).Rows.Count <> 0 Then
            DS_configcostos.Miembros.Merge(ds_instructores.Tables(0))
            'ahora ciclo recursivamente.
            Dim i As Integer = 0
            While i < ds_instructores.Tables(0).Rows.Count
                Dim id_usuario_a As Integer = CInt(ds_instructores.Tables(0).Rows(i).Item("usuario_id"))
                instructores_agregar_recursivo(id_usuario_a)
                i = i + 1
            End While
        End If
    End Sub


    Private Sub Rb_instructor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb_instructor.CheckedChanged
        If Rb_instructor.Checked = True Then
            Rb_graduacion.Checked = False
        Else
            Rb_graduacion.Checked = True
        End If
    End Sub

    Private Sub Rb_graduacion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb_graduacion.CheckedChanged
        If Rb_graduacion.Checked = True Then
            Rb_instructor.Checked = False
        Else
            Rb_instructor.Checked = True
        End If
    End Sub
    Dim chk_select As CheckBox
    Private Sub Btn_confirmar_porcentaje_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_confirmar_porcentaje.Click
        Try
            Dim porcentaje As Decimal = CDec(txt_montoexamen.Text)
            Dim cambios_efectuados As String = "no"
            Dim i As Integer = 0
            While i < GridView_examenes.Rows.Count
                If Rb_graduacion.Checked = True Then
                    Dim graduacion As String = Me.GridView_examenes.Rows(i).Cells(4).Text
                    If graduacion = DropDownList_graduacion.SelectedItem.Text Then
                        Dim instructor_id As Integer = CInt(Me.GridView_examenes.Rows(i).Cells(0).Text)
                        DAinstructor.instructor_modificar_porcentaje(instructor_id, porcentaje)
                        cambios_efectuados = "si"
                    End If
                Else
                    chk_select = CType(Me.GridView_examenes.Rows(i).FindControl("chk_select"), CheckBox)
                    If chk_select.Checked = True Then
                        Dim instructor_id As Integer = CInt(Me.GridView_examenes.Rows(i).Cells(0).Text)
                        DAinstructor.instructor_modificar_porcentaje(instructor_id, porcentaje)
                        cambios_efectuados = "si"
                    End If
                End If
                i = i + 1
            End While
            If cambios_efectuados = "si" Then
                'aqui va el  modal de OK, cambios efectuados.
                Dim usuario_id As Integer = Session("Us_id")
                instructores_recuperar(usuario_id)

                div_modalOK.Visible = True
                Modal_OK.Show()
            End If
            Label_error_monto1.Visible = False


        Catch ex As Exception
            'si falla es x que se tipeo mal el precio.
            'aqui llamo al modal del error, el cartel.
            Label_error_monto1.Visible = True
        End Try
    End Sub
End Class