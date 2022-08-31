Public Class Miembros
    Inherits System.Web.UI.Page
    Dim ds_a As New DataSet_miembros 'este conjunto de datos lo creo en la solucion. en la carpeta miembros
    Dim DAinstructor As New Capa_de_datos.Instructor
    Dim DAusuario As New Capa_de_datos.usuario
    Dim ds_alumnos As DataSet
    Dim ds_instructores As New DataSet_miembros

    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
        If txt_buscar.Text <> "" Then
            'aqui hago la busqueda por dni o bien concatenado apellido y nombre
            Dim valido As String = "no"
            ds_a.Tables("Tabla_alumnos").Rows.Clear()
            busqueda_cargar_grilla(Session("Us_id"), valido)
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

            GridView1.DataSource = ds_a.Tables("Tabla_alumnos")
            GridView1.DataBind()

            If GridView1.Rows.Count = 0 Then
                'msj_busqueda_error.Visible = True
                Lb_busqueda_error.Visible = True
            Else
                Lb_busqueda_error.Visible = False
            End If
        End If
    End Sub

    Private Function busqueda_cargar_grilla(ByVal id As Integer, ByRef valido As String)
        '-----RECUERDA QUE HAY Q VALIDAR 2 BUSQUEDAS, X APELLIDO Y NOMBRE CON EL "LIKE" Y DOC..EXACTO, ADEMAS Q SEA UNA BUSQUEDA RECURSIVA...SINO ENCUENTRA AL ALUMNO EN DICHA ESCUELA, NO SE LO MUESTRA
        Dim ds_alumn As DataSet = DAinstructor.Instructor_buscar_alumno_recursivo(id)
        'Dim usuario_id As Integer = Session("Us_id")
        If ds_alumn.Tables(0).Rows.Count <> 0 Then


            Dim i As Integer = 0
            While i < ds_alumn.Tables(0).Rows.Count
                Dim buscaraqui As String = CStr(ds_alumn.Tables(0).Rows(i).Item("Apellido y Nombre")).ToUpper
                Dim buscaresto As String = CStr(txt_buscar.Text).ToUpper
                Dim primer_caracter_encontrado As Integer = buscaraqui.IndexOf(buscaresto)
                If CStr(ds_alumn.Tables(0).Rows(i).Item("Documento")) = CStr(txt_buscar.Text) Or primer_caracter_encontrado <> -1 Then
                    'si lo encuentro lo agrego

                    Dim row As DataRow = ds_a.Tables("Tabla_alumnos").NewRow()
                    row("ID") = ds_alumn.Tables(0).Rows(i).Item("ID")
                    row("Documento") = ds_alumn.Tables(0).Rows(i).Item("Documento")
                    row("Apellido y Nombre") = ds_alumn.Tables(0).Rows(i).Item("Apellido y Nombre")
                    row("Edad") = ds_alumn.Tables(0).Rows(i).Item("Edad")
                    row("Teléfono") = ds_alumn.Tables(0).Rows(i).Item("Teléfono")
                    row("Graduación") = ds_alumn.Tables(0).Rows(i).Item("Graduación")
                    row("Tipo") = ds_alumn.Tables(0).Rows(i).Item("Tipo")
                    row("Instructor") = ds_alumn.Tables(0).Rows(i).Item("Instructor")
                    row("NroLibreta") = ds_alumn.Tables(0).Rows(i).Item("NroLibreta")
                    ds_a.Tables("Tabla_alumnos").Rows.Add(row)
                    valido = "si"
                End If
                If ds_alumn.Tables(0).Rows(i).Item("Tipo") = "instructor" Then
                    busqueda_cargar_grilla(ds_alumn.Tables(0).Rows(i).Item("ID"), "si")
                End If

                i = i + 1
            End While


            'Label_alumnosde.Text = ds_alumn.Tables(1).Rows(0).Item("ApellidoyNombre")
        Else
            valido = "no"

        End If
        'poner texto en rojo los usuarios q estan inactivos

        Return valido
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("procedencia") = "choco" Then
        End If
        If Not IsPostBack Then
            popupdatospersonales.Visible = False
            popupmsj.Visible = False
            Session("Us_recursivo") = Session("Us_id")
            chk_true.Visible = False
            Dim usuario_id As Integer = Session("Us_id")
            ds_alumnos = DAinstructor.Instructor_obtener_alumnos(usuario_id)
            If ds_alumnos.Tables(0).Rows.Count <> 0 Then
                Label_alumnosde.Text = ds_alumnos.Tables(1).Rows(0).Item("ApellidoyNombre")
                ds_a.Tabla_alumnos.Merge(ds_alumnos.Tables(0))
                GridView1.DataSource = ds_a.Tabla_alumnos
                GridView1.DataBind()

                '----------------------seccion: contar miembros y alumnos directos------------------------------
                '-----------------------------------------------------------------------------------------------
                lb_cant_alumnos.Text = ds_a.Tabla_alumnos.Rows.Count
                Dim contador As Integer = 0
                contar_cant_miembros(usuario_id, contador)
                lb_cant_miembros.Text = contador
                '-----------------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------------

                'cargar_fotos_miembros_ultimos(ds_alumnos) 'la rutina la comente, x q no tengo el diseño html...buscar en txt
                'aqui deberia llamar a la rutina que me cargue todos los instructores, que son alumnos DIRECTOS e INDIRECTOS del instructor logueado
                '1) primero cargo al instructor logueado.
                Dim row As DataRow = ds_instructores.Tables("Instructores").NewRow()
                row("usuario_id") = usuario_id
                row("Apenom") = ds_alumnos.Tables(1).Rows(0).Item("ApellidoyNombre")
                ds_instructores.Tables("Instructores").Rows.Add(row)
                Traer_instructores(usuario_id)
                Dim ds_ordenado As DataView = New DataView(ds_instructores.Tables("Instructores"))
                ds_ordenado.Sort = "Apenom"
                DropDownList_instructores.DataSource = ds_ordenado
                DropDownList_instructores.DataTextField = "Apenom"
                DropDownList_instructores.DataValueField = "usuario_id"
                DropDownList_instructores.DataBind()
                'selecciono primero, el usuario logueado
                DropDownList_instructores.SelectedValue = usuario_id
            Else
                'ds_a.Tabla_alumnos.Rows.Add()
                'ds_a.Tabla_alumnos.Rows.Add()
                'ds_a.Tabla_alumnos.Rows.Add()
                'GridView1.DataSource = ds_a.Tabla_alumnos
                'GridView1.DataBind()
            End If
        End If
    End Sub



    Private Sub contar_cant_miembros(ByVal usuario_id As Integer, ByRef contador As Integer)
        Dim ds_alumnos As DataSet = DAinstructor.Instructor_obtener_alumnos(usuario_id)

        Dim i As Integer = 0
        While i < ds_alumnos.Tables(0).Rows.Count
            contador = contador + 1
            If ds_alumnos.Tables(0).Rows(i).Item("Tipo") = "instructor" Then
                Dim usu_id As Integer = ds_alumnos.Tables(0).Rows(i).Item("ID")

                contar_cant_miembros(usu_id, contador)
            End If
            i = i + 1
        End While
    End Sub



    Private Sub Traer_instructores(ByVal usuario_id As Integer)
        'esta rutina trae todos los instructores q son alumnos del instructor logueado, para ello deben estar activo, usuario tipo=instructor,
        'se traen TODOS, directos e indirectos x igual.
        '1) primero cargamos al usuario
        Dim ds_inst As DataSet = DAinstructor.Instructor_obtener_instructores(usuario_id)
        If ds_inst.Tables(0).Rows.Count <> 0 Then
            ds_instructores.Tables("Instructores").Merge(ds_inst.Tables(0))
            Dim i As Integer = 0
            While i < ds_inst.Tables(0).Rows.Count
                Traer_instructores(ds_inst.Tables(0).Rows(i).Item("usuario_id")) 'se llama asi mismo...recursivo
                i = i + 1
            End While
        End If
    End Sub


    Private Sub obtener_datos_alumno(ByVal usuario_id As Integer)
        Dim ds_alumno As DataSet = DAusuario.Miembros_obtener_datos_personales(usuario_id)
        'ahora cargo en los label del panel popup pane_datospersonales
        Lb_apenom.Text = ds_alumno.Tables(0).Rows(0).Item("apellido y nombre")
        Lb_dni.Text = ds_alumno.Tables(0).Rows(0).Item("dni")
        Lb_fechanac.Text = ds_alumno.Tables(0).Rows(0).Item("fecha de nacimiento")
        Lb_telefono.Text = ds_alumno.Tables(0).Rows(0).Item("telefono")
        Lb_correo.Text = ds_alumno.Tables(0).Rows(0).Item("correo")
        Lb_direccion.Text = ds_alumno.Tables(0).Rows(0).Item("direccion")
        Lb_provincia.Text = ds_alumno.Tables(0).Rows(0).Item("provincia")
        Lb_ciudad.Text = ds_alumno.Tables(0).Rows(0).Item("ciudad")
        Lb_nacionalidad.Text = ds_alumno.Tables(0).Rows(0).Item("nacionalidad")
        Lb_estadocivil.Text = ds_alumno.Tables(0).Rows(0).Item("estado civil")
        Lb_profesion.Text = ds_alumno.Tables(0).Rows(0).Item("profesion")
        Lb_tipousuario.Text = ds_alumno.Tables(0).Rows(0).Item("usuario_tipo")
        'aqui los datos institucionales
        Lb_dainstitucionales_graduacion.Text = ds_alumno.Tables(0).Rows(0).Item("graduacion")
        Lb_dainstitucionales_provincia.Text = ds_alumno.Tables(1).Rows(0).Item("provincia")
        Lb_dainstitucionales_institucion.Text = ds_alumno.Tables(1).Rows(0).Item("institucion") + "()" + ds_alumno.Tables(1).Rows(0).Item("abreviacion") + ")"
        Lb_dainstitucionales_instructor.Text = ds_alumno.Tables(1).Rows(0).Item("instructor")
        Lb_dainstitucionales_estado.Text = ds_alumno.Tables(0).Rows(0).Item("estado")
        Lb_dainstitucionales_estado.Font.Bold = True
        If Lb_dainstitucionales_estado.Text = "activo" Then
            Lb_dainstitucionales_estado.ForeColor = Drawing.Color.Green
        End If
        If Lb_dainstitucionales_estado.Text = "inactivo" Then
            Lb_dainstitucionales_estado.ForeColor = Drawing.Color.Red
        End If
        Dim ImagenBD As Byte() = ds_alumno.Tables(0).Rows(0).Item("foto")
        Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD)
        Image1.ImageUrl = ImagenDataURL64
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "ID") Then 'es mostrar info de alumnos
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")
            obtener_datos_alumno(id)
            popupdatospersonales.Visible = True
            ModalPopupExtender_DApersonales.Show()
        End If
        If (e.CommandName = "Id_instructor") Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")
            Dim usuario_id As Integer = Session("Us_id")
            Dim ds_alumnos As DataSet = DAinstructor.Instructor_obtener_alumnos(id)
            Session("Us_recursivo") = id
            Dim val As String = "si"
            cargar_grilla(id, val)
            If val = "no" Then
                popupmsj.Visible = True
                ModalPopupExtender_msj_no_alumnos.Show()
            End If
        End If
        If (e.CommandName = "ID_b") Then 'es mostrar info de alumnos
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
            'me voy al formulario con los datos del alumno.
            Session("Alumno_Us_id") = id
            Response.Redirect("Miembros_editar_datospersonales.aspx")

            'Session("usuario_id") = id
            'Response.Redirect("Mensaje_Datos_Personales.aspx")
            'obtener_datos_alumno(id)
            'popupdatospersonales.Visible = True
            'ModalPopupExtender_DApersonales.Show()
        End If

        'If (e.CommandName = "ID") Then
        ' Retrieve the row index stored in the CommandArgument property.
        'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        'Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
        'Session("alumno_id") = id
        'Response.Redirect("/Contraseña/contraseña_cambiar.aspx")
        'End If
    End Sub

    Private Function cargar_grilla(ByVal id As Integer, ByRef valido As String)
        Dim ds_alumn = DAinstructor.Instructor_obtener_alumnos(id)
        If chk_true.Visible = True Then
            'muestro todos, incluidos los inactivos
            'Dim usuario_id As Integer = Session("Us_id")
            If ds_alumn.Tables(2).Rows.Count <> 0 Then
                ds_a.Tabla_alumnos.Rows.Clear()
                Label_alumnosde.Text = ds_alumn.Tables(1).Rows(0).Item("ApellidoyNombre")
                DropDownList_instructores.SelectedValue = id
                ds_a.Tabla_alumnos.Merge(ds_alumn.Tables(2))
                GridView1.DataSource = ds_a.Tabla_alumnos
                GridView1.DataBind()
                lb_cant_alumnos.Text = ds_a.Tabla_alumnos.Rows.Count
                'pongo en rojo los usuarios inactivos
                Dim i As Integer = 0
                While i < ds_a.Tabla_alumnos.Rows.Count
                    If ds_a.Tabla_alumnos.Rows(i).Item("Estado") = "inactivo" Then
                        GridView1.Rows(i).ForeColor = Drawing.Color.Red
                    End If
                    i = i + 1
                End While
                Lb_busqueda_error.Visible = False
            Else
                valido = "no"


            End If
            'poner texto en rojo los usuarios q estan inactivos
        Else
            If ds_alumn.Tables(0).Rows.Count <> 0 Then
                ds_a.Tabla_alumnos.Rows.Clear()
                Label_alumnosde.Text = ds_alumn.Tables(1).Rows(0).Item("ApellidoyNombre")
                DropDownList_instructores.SelectedValue = id
                ds_a.Tabla_alumnos.Merge(ds_alumn.Tables(0))
                GridView1.DataSource = ds_a.Tabla_alumnos
                GridView1.DataBind()
                lb_cant_alumnos.Text = ds_a.Tabla_alumnos.Rows.Count
                'cargar_fotos_miembros_ultimos(ds_alumn) 'comente x q no tengo el html...buscar en txt
                Lb_busqueda_error.Visible = False
            Else
                valido = "no"

            End If
            'muestro solo los activos
        End If
        Return valido
    End Function

    Private Sub Actualizar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Actualizar.ServerClick
        Lb_busqueda_error.Visible = False
        If Session("Us_recursivo") Is Nothing Then
            cargar_grilla(Session("Us_id"), "si")
        Else
            If Session("Us_recursivo") <> Session("Us_id") Then
                cargar_grilla(Session("Us_recursivo"), "si")
            Else
                cargar_grilla(Session("Us_id"), "si")
            End If
        End If
    End Sub

    Private Sub chk_false_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_false.ServerClick
        chk_false.Visible = False
        chk_true.Visible = True
        If Session("Us_recursivo") Is Nothing Then
            cargar_grilla(Session("Us_id"), "si")
        Else
            If Session("Us_recursivo") <> Session("Us_id") Then
                cargar_grilla(Session("Us_recursivo"), "si")
            Else
                cargar_grilla(Session("Us_id"), "si")
            End If
        End If
    End Sub

    Private Sub chk_true_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_true.ServerClick
        chk_true.Visible = False
        chk_false.Visible = True
        If Session("Us_recursivo") Is Nothing Then
            cargar_grilla(Session("Us_id"), "si")
        Else
            If Session("Us_recursivo") <> Session("Us_id") Then
                cargar_grilla(Session("Us_recursivo"), "si")
            Else
                cargar_grilla(Session("Us_id"), "si")
            End If
        End If
    End Sub

    Private Sub AceptarArr_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AceptarArr.ServerClick
        'cargar de nuevo form
        Response.Redirect("/Miembros/Miembros.aspx")
    End Sub

#Region "carga de fotos"
    'Private Sub cargar_fotos_miembros_ultimos(ByVal ds_fotos As DataSet)
    '    Dim i As Integer = 0
    '    While i < ds_fotos.Tables(0).Rows.Count
    '        If i = 0 Then
    '            Dim ImagenBD As Byte() = ds_fotos.Tables(0).Rows(0).Item("foto")
    '            Dim ImagenDataURL64 As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD)
    '            Img_a.ImageUrl = ImagenDataURL64
    '            Lb_miembro_a.Text = ds_fotos.Tables(0).Rows(0).Item("Apellido y Nombre")
    '            Lb_miembro_a.ToolTip = ds_fotos.Tables(0).Rows(0).Item("Apellido y Nombre")
    '        End If
    '        If i = 1 Then
    '            Dim ImagenBD_b As Byte() = ds_fotos.Tables(0).Rows(1).Item("foto")
    '            Dim ImagenDataURL64_b As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD_b)
    '            Img_b.ImageUrl = ImagenDataURL64_b
    '            Lb_miembro_b.Text = ds_fotos.Tables(0).Rows(1).Item("Apellido y Nombre")
    '            Lb_miembro_b.ToolTip = ds_fotos.Tables(0).Rows(1).Item("Apellido y Nombre")
    '        End If
    '        If i = 2 Then
    '            Dim ImagenBD_c As Byte() = ds_fotos.Tables(0).Rows(2).Item("foto")
    '            Dim ImagenDataURL64_c As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD_c)
    '            Img_c.ImageUrl = ImagenDataURL64_c
    '            Lb_miembro_c.Text = ds_fotos.Tables(0).Rows(2).Item("Apellido y Nombre")
    '            Lb_miembro_c.ToolTip = ds_fotos.Tables(0).Rows(2).Item("Apellido y Nombre")
    '        End If
    '        If i = 3 Then
    '            Dim ImagenBD_d As Byte() = ds_fotos.Tables(0).Rows(3).Item("foto")
    '            Dim ImagenDataURL64_d As String = "data:image/jpg;base64," + Convert.ToBase64String(ImagenBD_d)
    '            Img_d.ImageUrl = ImagenDataURL64_d
    '            Lb_miembro_d.Text = ds_fotos.Tables(0).Rows(3).Item("Apellido y Nombre")
    '            Lb_miembro_d.ToolTip = ds_fotos.Tables(0).Rows(3).Item("Apellido y Nombre")
    '        End If
    '        i = i + 1
    '    End While

    'End Sub
#End Region

    Private Sub DropDownList_instructores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_instructores.SelectedIndexChanged
        'aqui recupero los alumnos del instructor seleccionado en el dropdown
        Dim id As Integer = DropDownList_instructores.SelectedValue
        'Session("usuario_id") = id
        'Response.Redirect("Mensaje_Datos_Personales.aspx")
        Dim usuario_id As Integer = Session("Us_id")
        Dim ds_alumnos As DataSet = DAinstructor.Instructor_obtener_alumnos(id)
        Session("Us_recursivo") = id
        Dim val As String = "si"
        cargar_grilla(id, val)
        If val = "no" Then
            cargar_grilla(usuario_id, "si")
            DropDownList_instructores.SelectedValue = usuario_id
            popupmsj.Visible = True
            ModalPopupExtender_msj_no_alumnos.Show()
            Session("Us_recursivo") = Session("Us_id")

        End If

    End Sub
End Class