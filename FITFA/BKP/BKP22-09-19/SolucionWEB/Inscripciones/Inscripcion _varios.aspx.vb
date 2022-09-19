Imports MessagingToolkit.QRCode.Codec
Imports MessagingToolkit.QRCode.Codec.Data
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging

Public Class Inscripcion__varios
    Inherits System.Web.UI.Page
    Dim ds_a As New inscripciones_DS
    Dim DAinstructor As New Capa_de_datos.Instructor
    Dim DAusuario As New Capa_de_datos.usuario
    Dim DAinscripciones As New Capa_de_datos.Inscripciones
    Dim ds_instructores As New DataSet_miembros
    Dim ChkForma As CheckBox
    Dim ChkLucha As CheckBox
    Dim ChkRPoder As CheckBox
    Dim ChkREsp As CheckBox
    Dim tb_peso As TextBox
    Dim ds_alumnos As DataSet
    Dim ds_Alumnos_Inscriptos As DataSet

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("procedencia") = "choco" Then
        End If
        If Not IsPostBack Then
            popupdatospersonales.Visible = False
            popupmsj.Visible = False
            div_Modal_err.Visible = False
            popupMsjGuardado.Visible = False

            Session("Us_recursivo") = Session("Us_id")
            ' chk_true.Visible = False
            Dim usuario_id As Integer = Session("Us_id")
            ds_alumnos = DAinstructor.Instructor_obtener_alumnos(usuario_id)
            ds_Alumnos_Inscriptos = DAinstructor.Instructor_Buscar_Inscriptos(Session("evento_id"), Session("Us_recursivo"))
            If ds_alumnos.Tables(0).Rows.Count <> 0 Then
                '----carga de instructores en dropdown
                '-------------------------------------
                Dim row_instructor As DataRow = ds_instructores.Tables("Instructores").NewRow()
                row_instructor("usuario_id") = usuario_id
                row_instructor("Apenom") = ds_alumnos.Tables(1).Rows(0).Item("ApellidoyNombre")
                ds_instructores.Tables("Instructores").Rows.Add(row_instructor)
                Traer_instructores(usuario_id)
                Dim ds_ordenado As DataView = New DataView(ds_instructores.Tables("Instructores"))
                ds_ordenado.Sort = "Apenom"
                DropDownList_instructores.DataSource = ds_ordenado
                DropDownList_instructores.DataTextField = "Apenom"
                DropDownList_instructores.DataValueField = "usuario_id"
                DropDownList_instructores.DataBind()
                'selecciono primero, el usuario logueado
                DropDownList_instructores.SelectedValue = usuario_id
                '---------------------------------------------------
                '---------------------------------------------------
                Dim indice As Integer = 0
                Do While indice < ds_alumnos.Tables(0).Rows.Count
                    Dim Agregar = True
                    ''Ciclo de Inscriptos'''''''''''''''''''''''''''
                    Dim indice2 As Integer = 0
                    Do While indice2 < ds_Alumnos_Inscriptos.Tables(0).Rows.Count
                        Dim usu_1 As Integer = ds_alumnos.Tables(0).Rows(indice).Item("ID")
                        Dim usu_2 As Integer = ds_Alumnos_Inscriptos.Tables(0).Rows(indice2).Item("Inscr_Usu_ID")
                        If ds_alumnos.Tables(0).Rows(indice).Item("ID") = ds_Alumnos_Inscriptos.Tables(0).Rows(indice2).Item("Inscr_Usu_ID") Then
                            indice2 = ds_Alumnos_Inscriptos.Tables(0).Rows.Count
                            Agregar = False
                        Else
                        End If
                        indice2 = indice2 + 1
                    Loop
                    ''''''''''''''''''''''''''''''''''''
                    If Agregar = True Then

                        Dim row As DataRow = ds_a.Tables("Tabla_alumnos").NewRow()
                        row("ID") = ds_alumnos.Tables(0).Rows(indice).Item("ID")
                        row("Documento") = ds_alumnos.Tables(0).Rows(indice).Item("Documento")
                        row("Apellido y Nombre") = ds_alumnos.Tables(0).Rows(indice).Item("Apellido y Nombre")
                        row("Edad") = ds_alumnos.Tables(0).Rows(indice).Item("Edad")
                        row("Graduación") = ds_alumnos.Tables(0).Rows(indice).Item("Graduación")
                        row("Sexo") = ds_alumnos.Tables(0).Rows(indice).Item("Sexo")
                        row("graduacion_id") = ds_alumnos.Tables(0).Rows(indice).Item("graduacion_id")
                        row("Tipo") = ds_alumnos.Tables(0).Rows(indice).Item("Tipo")
                        row("Instructor") = ds_alumnos.Tables(0).Rows(indice).Item("Instructor")
                        'row("usuario_id_instructor") = ds_alumnos.Tables(0).Rows(indice).Item("usuario_id_instructor")

                        'Agrego la fila en la Tabla
                        ds_a.Tables("Tabla_alumnos").Rows.Add(row)


                    End If

                    indice = indice + 1

                Loop

                GridView1.DataSource = ds_a.Tables("Tabla_alumnos")
                GridView1.DataBind()

                'Label_alumnosde.Text = ds_alumnos.Tables(1).Rows(0).Item("ApellidoyNombre")
                'ds_a.Tabla_alumnos.Merge(ds_alumnos.Tables(0))
                'GridView1.DataSource = ds_a.Tabla_alumnos
                'GridView1.DataBind()
            Else
                'ds_a.Tabla_alumnos.Rows.Add()
                'ds_a.Tabla_alumnos.Rows.Add()
                'ds_a.Tabla_alumnos.Rows.Add()
                'GridView1.DataSource = ds_a.Tabla_alumnos
                'GridView1.DataBind()
            End If
        End If
        Label_titulo.Text = "Inscripciones para " + Session("evento_desc")
    End Sub
    Private Function cargar_grilla(ByVal id As Integer, ByRef valido As String)
        Dim ds_alumn = DAinstructor.Instructor_obtener_alumnos(id)
        ds_Alumnos_Inscriptos = DAinstructor.Instructor_Buscar_Inscriptos(Session("evento_id"), id)
        If ds_alumn.Tables(0).Rows.Count <> 0 Then
            Dim indice As Integer = 0
            ds_a.Tables("Tabla_alumnos").Rows.Clear()
            Do While indice < ds_alumn.Tables(0).Rows.Count
                Dim Agregar = True
                ''Ciclo de Inscriptos'''''''''''''''''''''''''''
                Dim indice2 As Integer = 0
                Do While indice2 < ds_Alumnos_Inscriptos.Tables(0).Rows.Count
                    Dim usu_1 As Integer = ds_alumn.Tables(0).Rows(indice).Item("ID")
                    Dim usu_2 As Integer = ds_Alumnos_Inscriptos.Tables(0).Rows(indice2).Item("Inscr_Usu_ID")
                    If ds_alumn.Tables(0).Rows(indice).Item("ID") = ds_Alumnos_Inscriptos.Tables(0).Rows(indice2).Item("Inscr_Usu_ID") Then
                        indice2 = ds_Alumnos_Inscriptos.Tables(0).Rows.Count
                        Agregar = False
                    Else
                    End If
                    indice2 = indice2 + 1
                Loop
                ''''''''''''''''''''''''''''''''''''
                If Agregar = True Then
                    Dim row As DataRow = ds_a.Tables("Tabla_alumnos").NewRow()
                    row("ID") = ds_alumn.Tables(0).Rows(indice).Item("ID")
                    row("Documento") = ds_alumn.Tables(0).Rows(indice).Item("Documento")
                    row("Apellido y Nombre") = ds_alumn.Tables(0).Rows(indice).Item("Apellido y Nombre")
                    row("Edad") = ds_alumn.Tables(0).Rows(indice).Item("Edad")
                    row("Graduación") = ds_alumn.Tables(0).Rows(indice).Item("Graduación")
                    row("Sexo") = ds_alumn.Tables(0).Rows(indice).Item("Sexo")
                    row("graduacion_id") = ds_alumn.Tables(0).Rows(indice).Item("graduacion_id")
                    row("Tipo") = ds_alumn.Tables(0).Rows(indice).Item("Tipo")
                    row("Instructor") = ds_alumn.Tables(0).Rows(indice).Item("Instructor")
                    'row("usuario_id_instructor") = ds_alumn.Tables(0).Rows(indice).Item("usuario_id_instructor")
                    'Agrego la fila en la Tabla
                    ds_a.Tables("Tabla_alumnos").Rows.Add(row)
                End If
                indice = indice + 1
            Loop
            GridView1.DataSource = ds_a.Tables("Tabla_alumnos")
            GridView1.DataBind()
            Label_alumnosde.Text = ds_alumn.Tables(1).Rows(0).Item("ApellidoyNombre")
            DropDownList_instructores.SelectedValue = id
            Lb_busqueda_error.Visible = False
        Else
            valido = "no"
        End If


        Return valido
    End Function
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
        If (e.CommandName = "ID") Then
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
        'If (e.CommandName = "ID") Then
        ' Retrieve the row index stored in the CommandArgument property.
        'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        'Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())
        'Session("alumno_id") = id
        'Response.Redirect("/Contraseña/contraseña_cambiar.aspx")
        'End If
    End Sub
    Private Function Ds_col_ocultas(ByRef ds_oculto As DataSet)
        '  Dim ds_oculto As DataSet
        If Session("Us_recursivo") <> Session("Us_id") Then

            Dim usuario_id As Integer = Session("Us_id")
            ds_oculto = DAinstructor.Instructor_obtener_alumnos(usuario_id)


        Else
            Dim usuario_id As Integer = Session("Us_recursivo")
            ds_oculto = DAinstructor.Instructor_obtener_alumnos(usuario_id)
        End If

        Return ds_oculto

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
    Private Sub btn_buscar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.ServerClick
        If txt_buscar.Text <> "" Then
            'aqui hago la busqueda por dni o bien concatenado apellido y nombre
            Dim valido As String = "no"
            ds_a.Tables("Tabla_alumnos").Rows.Clear()
            busqueda_cargar_grilla(Session("Us_id"), valido, ds_a.Tables("Tabla_alumnos"))
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
            Dim contador As Integer = ds_a.Tables("Tabla_alumnos").Rows.Count
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
    Private Function busqueda_cargar_grilla(ByVal id As Integer, ByRef valido As String, ByRef Tabla_de_alumnos As DataTable)
        '-----RECUERDA QUE HAY Q VALIDAR 2 BUSQUEDAS, X APELLIDO Y NOMBRE CON EL "LIKE" Y DOC..EXACTO, ADEMAS Q SEA UNA BUSQUEDA RECURSIVA...SINO ENCUENTRA AL ALUMNO EN DICHA ESCUELA, NO SE LO MUESTRA
        Dim ds_alumn As DataSet = DAinstructor.Instructor_buscar_alumno_recursivo(id)
        ds_Alumnos_Inscriptos = DAinstructor.Instructor_Buscar_Inscriptos(Session("evento_id"), id)

        If ds_alumn.Tables(0).Rows.Count <> 0 Then
            Dim indice As Integer = 0
            'ds_a.Tables("Tabla_alumnos").Rows.Clear()
            Do While indice < ds_alumn.Tables(0).Rows.Count
                Dim Agregar = True
                ''Ciclo de Inscriptos'''''''''''''''''''''''''''
                Dim indice2 As Integer = 0
                Do While indice2 < ds_Alumnos_Inscriptos.Tables(0).Rows.Count
                    Dim usu_1 As Integer = ds_alumn.Tables(0).Rows(indice).Item("ID")
                    Dim usu_2 As Integer = ds_Alumnos_Inscriptos.Tables(0).Rows(indice2).Item("Inscr_Usu_ID")
                    If ds_alumn.Tables(0).Rows(indice).Item("ID") = ds_Alumnos_Inscriptos.Tables(0).Rows(indice2).Item("Inscr_Usu_ID") Then
                        indice2 = ds_Alumnos_Inscriptos.Tables(0).Rows.Count
                        Agregar = False
                    Else
                    End If
                    indice2 = indice2 + 1
                Loop
                ''''''''''''''''''''''''''''''''''''
                If Agregar = True Then
                    'esta aprobado x q no esta en inscriptos...pero ahora veo si realmente es un resultado de la busqueda
                    Dim buscaraqui As String = CStr(ds_alumn.Tables(0).Rows(indice).Item("Apellido y Nombre")).ToUpper
                    Dim buscaresto As String = CStr(txt_buscar.Text).ToUpper
                    Dim primer_caracter_encontrado As Integer = buscaraqui.IndexOf(buscaresto)
                    If CStr(ds_alumn.Tables(0).Rows(indice).Item("Documento")) = CStr(txt_buscar.Text) Or primer_caracter_encontrado <> -1 Then
                        Dim row As DataRow = Tabla_de_alumnos.NewRow()
                        row("ID") = ds_alumn.Tables(0).Rows(indice).Item("ID")
                        row("Documento") = ds_alumn.Tables(0).Rows(indice).Item("Documento")
                        row("Apellido y Nombre") = ds_alumn.Tables(0).Rows(indice).Item("Apellido y Nombre")
                        row("Edad") = ds_alumn.Tables(0).Rows(indice).Item("Edad")
                        row("Graduación") = ds_alumn.Tables(0).Rows(indice).Item("Graduación")
                        row("Sexo") = ds_alumn.Tables(0).Rows(indice).Item("Sexo")
                        row("graduacion_id") = ds_alumn.Tables(0).Rows(indice).Item("graduacion_id")
                        row("Tipo") = ds_alumn.Tables(0).Rows(indice).Item("Tipo")
                        row("Instructor") = ds_alumn.Tables(0).Rows(indice).Item("Instructor")
                        'row("usuario_id_instructor") = ds_alumn.Tables(0).Rows(indice).Item("usuario_id_instructor")
                        'Agrego la fila en la Tabla

                        Tabla_de_alumnos.Rows.Add(row)
                    End If
                End If
                'llamo a rutina recursiva...asi recorra los alumnos
                If ds_alumn.Tables(0).Rows(indice).Item("Tipo") = "instructor" Then
                    busqueda_cargar_grilla(ds_alumn.Tables(0).Rows(indice).Item("ID"), "si", Tabla_de_alumnos)
                End If
                indice = indice + 1
                Dim contador As Integer = Tabla_de_alumnos.Rows.Count
            Loop
            'GridView1.DataSource = ds_a.Tables("Tabla_alumnos")
            'GridView1.DataBind()
            'Label_alumnosde.Text = ds_alumn.Tables(1).Rows(0).Item("ApellidoyNombre")
            'DropDownList_instructores.SelectedValue = id

        Else
            valido = "no"
        End If
        'Dim usuario_id As Integer = Session("Us_id")
        'If ds_alumn.Tables(0).Rows.Count <> 0 Then
        '    Dim i As Integer = 0
        '    While i < ds_alumn.Tables(0).Rows.Count
        '        Dim buscaraqui As String = CStr(ds_alumn.Tables(0).Rows(i).Item("Apellido y Nombre")).ToUpper
        '        Dim buscaresto As String = CStr(txt_buscar.Text).ToUpper
        '        Dim primer_caracter_encontrado As Integer = buscaraqui.IndexOf(buscaresto)
        '        If CStr(ds_alumn.Tables(0).Rows(i).Item("Documento")) = CStr(txt_buscar.Text) Or primer_caracter_encontrado <> -1 Then
        '            'si lo encuentro lo agrego
        '            Dim row As DataRow = ds_a.Tables("Tabla_alumnos").NewRow()
        '            row("ID") = ds_alumn.Tables(0).Rows(i).Item("ID")
        '            row("Documento") = ds_alumn.Tables(0).Rows(i).Item("Documento")
        '            row("Apellido y Nombre") = ds_alumn.Tables(0).Rows(i).Item("Apellido y Nombre")
        '            row("Edad") = ds_alumn.Tables(0).Rows(i).Item("Edad")
        '            row("Graduación") = ds_alumn.Tables(0).Rows(i).Item("Graduación")
        '            row("Sexo") = ds_alumn.Tables(0).Rows(i).Item("Sexo")
        '            row("graduacion_id") = ds_alumn.Tables(0).Rows(i).Item("graduacion_id")
        '            row("Tipo") = ds_alumn.Tables(0).Rows(i).Item("Tipo")
        '            row("Instructor") = ds_alumn.Tables(0).Rows(i).Item("Instructor")
        '            ds_a.Tables("Tabla_alumnos").Rows.Add(row)
        '            valido = "si"
        '        Else
        '            If ds_alumn.Tables(0).Rows(i).Item("Tipo") = "instructor" Then
        '                busqueda_cargar_grilla(ds_alumn.Tables(0).Rows(i).Item("ID"), "si")
        '            End If
        '        End If
        '        i = i + 1
        '    End While
        '    'Label_alumnosde.Text = ds_alumn.Tables(1).Rows(0).Item("ApellidoyNombre")
        'Else
        '    valido = "no"
        'End If
        ''poner texto en rojo los usuarios q estan inactivos
        Return valido
    End Function
    Private Sub AceptarArr_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AceptarArr.ServerClick
        'cargar de nuevo form
        Response.Redirect("/Inscripciones/Evento_seleccionar_varios.aspx")
    End Sub
    Private Sub Guardar_inscripciones()
        Dim indice As Integer = 0
        Dim SELECCIONADO As CheckBox
        Do While indice < Me.GridView1.Rows.Count
            ChkForma = CType(Me.GridView1.Rows(indice).FindControl("chk_formas"), CheckBox)
            ChkLucha = CType(Me.GridView1.Rows.Item(indice).FindControl("chk_lucha"), CheckBox)
            ChkREsp = CType(Me.GridView1.Rows.Item(indice).FindControl("chk_especial"), CheckBox)
            ChkRPoder = CType(Me.GridView1.Rows.Item(indice).FindControl("chk_poder"), CheckBox)
            tb_peso = CType(Me.GridView1.Rows.Item(indice).FindControl("txt_peso"), TextBox)
            Dim Peso As String = tb_peso.Text

            SELECCIONADO = CType(Me.GridView1.Rows.Item(indice).FindControl("CheckBox1"), CheckBox)
            If SELECCIONADO.Checked = True Then
                'recupero el id del instructor---para ello necesito id del alumno y buscar en la bd en la tabla alumno x instructor.
                Dim ds_instructor As DataSet = DAinstructor.Instructor_obtener_id(CInt(GridView1.Rows(indice).Cells(1).Text))
                Dim usuario_id_instructor As Integer = ds_instructor.Tables(0).Rows(0).Item("instructor_id")
                Dim graduacion_selec As Integer = ds_instructor.Tables(0).Rows(0).Item("graduacion_id")
                Dim sexo_selec As String = ds_instructor.Tables(0).Rows(0).Item("Sexo")

                'consulto tipo de evento
                Dim ds_evento As DataSet = DAinscripciones.Inscripcion_consultar_evento(Session("evento_id"))
                Dim tipo_evento As String = ds_evento.Tables(0).Rows(0).Item("tipo_evento")
                If tipo_evento = "Torneo" Then
                    'valido q se haya seleccionado al menos una de las 4 opciones de inscripcion


                    Dim ds_tipoevento As DataSet = DAinscripciones.Inscripcion_alta_masiva(GridView1.Rows(indice).Cells(1).Text, Session("evento_id"), Now, tb_peso.Text, usuario_id_instructor)
                    'ahora veo que tipo de evento es.
                    Dim inscripcion_id As Integer = ds_tipoevento.Tables(0).Rows(0).Item("inscripcion_id")
                    Lucha(inscripcion_id, indice, graduacion_selec, sexo_selec)
                    forma(inscripcion_id, indice, graduacion_selec, sexo_selec)
                    Rotura_Poder(inscripcion_id, indice, graduacion_selec, sexo_selec)
                    Rotura_especial(inscripcion_id, indice, graduacion_selec, sexo_selec)
                    CodigoQR(inscripcion_id)
                    'Variable para Mostrar Error o si se guarda bien
                End If
                If tipo_evento = "Curso" Then
                    'si es un curso, solo doy de alta en inscripcion
                    Dim ds_tipoevento As DataSet = DAinscripciones.Inscripcion_alta_masiva(Session("Us_id"), Session("evento_id"), Now, 0, Session("Us_recursivo"))
                    popupMsjGuardado.Visible = True
                    ModalPopupExtender_guardado.Show()
                End If
            Else
            End If
            indice = indice + 1
        Loop
    End Sub
    Private Sub CodigoQR(ByVal inscripcion_id As Integer)


        Dim Encoder As New QRCodeEncoder

        Dim img As Bitmap = Encoder.Encode(inscripcion_id)
        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream()
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Use appropriate format here
        Dim byteImage As Byte() = ms.ToArray()

        DAinscripciones.inscripcion_imagenQR_Alta(inscripcion_id, byteImage)

    End Sub
    Private Sub btn_insc_abj_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insc_abj.ServerClick
        Dim error_datos As Boolean = False
        Dim error_Check As Boolean = True
        Dim indice2 As Integer = 0
        Dim SELECCIONADO As CheckBox
        ''Cilco Para Verificar si hay un item Tildado''''''
        Do While indice2 < Me.GridView1.Rows.Count
            ChkForma = CType(Me.GridView1.Rows(indice2).FindControl("chk_formas"), CheckBox)
            ChkLucha = CType(Me.GridView1.Rows.Item(indice2).FindControl("chk_lucha"), CheckBox)
            ChkREsp = CType(Me.GridView1.Rows.Item(indice2).FindControl("chk_especial"), CheckBox)
            ChkRPoder = CType(Me.GridView1.Rows.Item(indice2).FindControl("chk_poder"), CheckBox)
            tb_peso = CType(Me.GridView1.Rows.Item(indice2).FindControl("txt_peso"), TextBox)
            Dim Peso As String = tb_peso.Text
            SELECCIONADO = CType(Me.GridView1.Rows.Item(indice2).FindControl("CheckBox1"), CheckBox)
            If SELECCIONADO.Checked = True Then
                error_Check = False
                If (ChkLucha.Checked = True Or ChkForma.Checked = True Or ChkREsp.Checked = True Or ChkRPoder.Checked = True) And Peso <> "" Then
                    GridView1.Rows(indice2).ForeColor = Drawing.Color.Black
                Else
                    error_datos = True
                    GridView1.Rows(indice2).ForeColor = Drawing.Color.Red
                End If
            Else
            End If
            indice2 = indice2 + 1
        Loop
        '''''''''''''''''''''''''''''''''''''''''''''''
        If error_Check = True Then
            lbl_Modal_err.Text = "Debe Seleccionar al menos un Alumno"
            div_Modal_err.Visible = True
            Modal_error.Show()
        Else
            If error_datos = True Then
                lbl_Modal_err.Text = "Verifica los datos Ingresados"
                div_Modal_err.Visible = True
                Modal_error.Show()
            Else
                Guardar_inscripciones()
                popupMsjGuardado.Visible = True
                ModalPopupExtender_guardado.Show()
            End If
        End If
    End Sub
    Private Sub Rotura_especial(ByVal inscripcion_id As Integer, ByVal indice As Integer, ByVal graduacion_selec As Integer, ByVal sexo_selec As String)
        'Dim ds_datos As DataSet
        'Ds_col_ocultas(ds_datos)
        ChkREsp = CType(Me.GridView1.Rows.Item(indice).FindControl("chk_especial"), CheckBox)
        If ChkREsp.Checked = True Then
            Dim ds_cat As DataSet = DAinscripciones.Inscripcion_obtener_categoria_roturaespecial()
            Dim i As Integer = 0
            While i < ds_cat.Tables(0).Rows.Count
                Dim edad_ini As Integer = CInt(ds_cat.Tables(0).Rows(i).Item("categoria_edadinicial"))
                Dim edad_fin As Integer = CInt(ds_cat.Tables(0).Rows(i).Item("categoria_edadfinal"))
                'Dim graduaccion_selec As Integer = ds_datos.Tables(0).Rows(indice).Item("graduacion_id")
                Dim grad_inicial As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_gradinicial")
                Dim grad_final As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_gradfinal")
                Dim cat_sexo As String = ds_cat.Tables(0).Rows(i).Item("categoria_sexo").ToString
                Dim Categoria_id As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_id")
                If graduacion_selec >= grad_inicial And graduacion_selec <= grad_final Then
                    If CInt(GridView1.Rows(indice).Cells(4).Text) >= CInt(edad_ini) And CInt(GridView1.Rows(indice).Cells(4).Text) <= CInt(edad_fin) Then
                        'Dim sexo_selec As String = ds_datos.Tables(0).Rows(indice).Item("Sexo")
                        If cat_sexo = sexo_selec Then
                            'aqui guardo
                            DAinscripciones.Inscripcion_alta_categorias(inscripcion_id, Categoria_id)
                            i = ds_cat.Tables(0).Rows.Count
                        End If
                    End If
                End If
                i = i + 1
            End While
        End If
    End Sub
    Private Sub Rotura_Poder(ByVal inscripcion_id As Integer, ByVal indice As Integer, ByVal graduacion_selec As Integer, ByVal sexo_selec As String)
        'Dim ds_datos As DataSet
        'Ds_col_ocultas(ds_datos)
        ChkRPoder = CType(Me.GridView1.Rows.Item(indice).FindControl("chk_poder"), CheckBox)
        If ChkREsp.Checked = True Then
            Dim ds_cat As DataSet = DAinscripciones.Inscripcion_obtener_categoria_roturapoder()
            Dim i As Integer = 0
            While i < ds_cat.Tables(0).Rows.Count
                Dim edad_ini As Integer = CInt(ds_cat.Tables(0).Rows(i).Item("categoria_edadinicial"))
                Dim edad_fin As Integer = CInt(ds_cat.Tables(0).Rows(i).Item("categoria_edadfinal"))
                'Dim graduaccion_selec As Integer = ds_datos.Tables(0).Rows(indice).Item("graduacion_id")
                Dim grad_inicial As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_gradinicial")
                Dim grad_final As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_gradfinal")
                Dim cat_sexo As String = ds_cat.Tables(0).Rows(i).Item("categoria_sexo").ToString
                Dim Categoria_id As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_id")
                If graduacion_selec >= grad_inicial And graduacion_selec <= grad_final Then
                    If CInt(GridView1.Rows(indice).Cells(4).Text) >= CInt(edad_ini) And CInt(GridView1.Rows(indice).Cells(4).Text) <= CInt(edad_fin) Then

                        'Dim sexo_selec As String = ds_datos.Tables(0).Rows(indice).Item("Sexo")
                        If cat_sexo = sexo_selec Then
                            'aqui guardo
                            DAinscripciones.Inscripcion_alta_categorias(inscripcion_id, Categoria_id)
                            i = ds_cat.Tables(0).Rows.Count
                        End If
                    End If
                End If
                i = i + 1
            End While
        End If
    End Sub
    Private Sub forma(ByVal inscripcion_id As Integer, ByVal indice As Integer, ByVal graduacion_selec As Integer, ByVal sexo_selec As String)
        'Dim ds_datos As DataSet
        'Ds_col_ocultas(ds_datos)
        ChkForma = CType(Me.GridView1.Rows.Item(indice).FindControl("chk_formas"), CheckBox)


        If ChkForma.Checked = True Then
            'recupero las categorias de forma.
            Dim ds_cat As DataSet = DAinscripciones.Inscripcion_obtener_categoria()
            Dim i As Integer = 0
            While i < ds_cat.Tables(1).Rows.Count
                Dim edad_ini As Integer = CInt(ds_cat.Tables(1).Rows(i).Item("categoria_edadinicial"))
                Dim edad_fin As Integer = CInt(ds_cat.Tables(1).Rows(i).Item("categoria_edadfinal"))
                'Dim graduaccion_selec As Integer = ds_datos.Tables(0).Rows(indice).Item("graduacion_id")
                Dim grad_inicial As Integer = ds_cat.Tables(1).Rows(i).Item("categoria_gradinicial")
                Dim grad_final As Integer = ds_cat.Tables(1).Rows(i).Item("categoria_gradfinal")
                Dim cat_sexo As String = ds_cat.Tables(1).Rows(i).Item("categoria_sexo").ToString
                Dim Categoria_id As Integer = ds_cat.Tables(1).Rows(i).Item("categoria_id")
                If graduacion_selec >= grad_inicial And graduacion_selec <= grad_final Then
                    If CInt(GridView1.Rows(indice).Cells(4).Text) >= CInt(edad_ini) And CInt(GridView1.Rows(indice).Cells(4).Text) <= CInt(edad_fin) Then
                        If cat_sexo <> "AMBOS SEXOS" Then
                            'Dim sexo_selec As String = ds_datos.Tables(0).Rows(indice).Item("Sexo")
                            If cat_sexo = sexo_selec Then
                                'aqui guardo
                                DAinscripciones.Inscripcion_alta_categorias(inscripcion_id, Categoria_id)
                                i = ds_cat.Tables(1).Rows.Count
                            End If
                        Else
                            'como no me importa el sexo guardo
                            'Dim sexo_selec As String = ds_datos.Tables(0).Rows(indice).Item("Sexo")
                            DAinscripciones.Inscripcion_alta_categorias(inscripcion_id, Categoria_id)
                            i = ds_cat.Tables(1).Rows.Count
                        End If
                    End If
                End If
                i = i + 1
            End While
        End If
    End Sub
    Private Sub Lucha(ByVal inscripcion_id As Integer, ByVal indice As Integer, ByVal graduacion_selec As Integer, ByVal sexo_selec As String)
        'Dim ds_datos As DataSet
        'Ds_col_ocultas(ds_datos)
        ChkLucha = CType(Me.GridView1.Rows.Item(indice).FindControl("chk_lucha"), CheckBox)
        tb_peso = CType(Me.GridView1.Rows.Item(indice).FindControl("txt_Peso"), TextBox)
        If ChkLucha.Checked = True Then
            'recupero las categorias de lucha.
            Dim ds_cat As DataSet = DAinscripciones.Inscripcion_obtener_categoria()
            Dim i As Integer = 0
            While i < ds_cat.Tables(0).Rows.Count
                'Dim va3332r As Integer = ds_datos.Tables(0).Rows.Count
                Dim edad_ini As Integer = CInt(ds_cat.Tables(0).Rows(i).Item("categoria_edadinicial"))
                Dim edad_fin As Integer = CInt(ds_cat.Tables(0).Rows(i).Item("categoria_edadfinal"))
                'Dim graduaccion_selec As Integer = ds_datos.Tables(0).Rows(indice).Item("graduacion_id") ''este
                Dim grad_inicial As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_gradinicial")
                Dim grad_final As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_gradfinal")
                Dim cat_sexo As String = ds_cat.Tables(0).Rows(i).Item("categoria_sexo").ToString
                Dim Categoria_id As Integer = ds_cat.Tables(0).Rows(i).Item("categoria_id")
                Dim peso_ini As Decimal = ds_cat.Tables(0).Rows(i).Item("categoria_peso_inical")
                Dim peso_final As Decimal = ds_cat.Tables(0).Rows(i).Item("categoria_peso_Final")
                If graduacion_selec >= grad_inicial And graduacion_selec <= grad_final Then
                    If CInt(GridView1.Rows(indice).Cells(4).Text) >= CInt(edad_ini) And CInt(GridView1.Rows(indice).Cells(4).Text) <= CInt(edad_fin) Then
                        If CDec(tb_peso.Text) > peso_ini And CDec(tb_peso.Text) <= peso_final Then
                            If cat_sexo <> "AMBOS SEXOS" Then
                                'Dim sexo_selec As String = ds_datos.Tables(0).Rows(indice).Item("Sexo")
                                If cat_sexo = sexo_selec Then
                                    'aqui guardo
                                    DAinscripciones.Inscripcion_alta_categorias(inscripcion_id, Categoria_id)
                                    i = ds_cat.Tables(0).Rows.Count
                                End If
                            Else
                                'como no me importa el sexo guardo
                                'Dim sexo_selec As String = ds_datos.Tables(0).Rows(indice).Item("Sexo")
                                DAinscripciones.Inscripcion_alta_categorias(inscripcion_id, Categoria_id)
                                i = ds_cat.Tables(0).Rows.Count
                            End If
                        End If
                    End If
                End If
                i = i + 1
            End While
        End If
    End Sub
    Private Sub btn_insc_arr_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insc_arr.ServerClick
        Dim indice As Integer = 0
        Dim SELECCIONADO As CheckBox

        Do While indice < Me.GridView1.Rows.Count
            SELECCIONADO = CType(Me.GridView1.Rows.Item(indice).FindControl("CheckBox1"), CheckBox)
            If SELECCIONADO.Checked = True Then

            Else

            End If
            indice = indice + 1
        Loop
    End Sub
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


    Private Sub Btn_guardado_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_guardado_ok.Click
        Response.Redirect("Evento_seleccionar_varios.aspx")
    End Sub
End Class