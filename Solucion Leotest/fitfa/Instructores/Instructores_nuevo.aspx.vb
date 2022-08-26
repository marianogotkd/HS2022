Imports System.Data.OleDb
Imports System.Data.DataRow
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Public Class Instructores_nuevo
    Inherits System.Web.UI.Page

#Region "DECLARACIONES"
    Dim DAusuario As New Capa_de_datos.usuario
#End Region

#Region "EVENTOS"
    Private Sub DropDownList_provincia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_provincia.Init
        Obtener_provincias()
        Obtener_ciudad()
    End Sub

    Private Sub DropDownList_provincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_provincia.SelectedIndexChanged
        Obtener_ciudad()
    End Sub

    Private Sub DropDownList_graduacion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_graduacion.Init
        Obtener_graduaciones()
    End Sub

    Dim usuario_tipo As String = "alumno"
    Private Sub DropDownList_graduacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_graduacion.SelectedIndexChanged
        'CheckBox_posee_alumnos.Checked = False
        Dim graduacion As Integer = CInt(DropDownList_graduacion.SelectedValue)

        'If graduacion > 11 Then
        '    div_posee_alumnos.Visible = True
        'Else
        '    div_posee_alumnos.Visible = False
        'End If
    End Sub

    Private Sub Instructores_nuevo_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ModalPopupExtender4.Hide()
        ModalPopupExtender3.Hide()
        ModalPopupExtender2.Hide()
        ModalPopupExtender5.Hide()
    End Sub

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'txt_fechanacimiento.Text = Today
            Txt_fechanac_2.Text = Today
            Session("imagen_registro") = ""
            Session("foto_subido_registro") = "no"


            'seleccionamos siempre en el combo de provincia = "santiago del estero" e institucion "ANT"
            Try
                'DropDown_prov_con_institucion.SelectedValue = 14
                'obtener_instituciones_x_provincia()
                'obtener_instructores_x_institucion()
                'DropDownList_instituciones.SelectedValue = 23
                'obtener_instructores_x_institucion()
            Catch ex As Exception

            End Try

        End If
    End Sub

    


#End Region

#Region "METODOS"
    Private Sub Obtener_graduaciones()
        Dim ds_graduaciones As DataSet = DAusuario.Usuario_ObtenerGraduaciones()
        If ds_graduaciones.Tables(0).Rows.Count <> 0 Then
            DropDownList_graduacion.DataSource = ds_graduaciones.Tables(0)
            DropDownList_graduacion.DataTextField = "graduacion_desc"
            DropDownList_graduacion.DataValueField = "graduacion_id"
            DropDownList_graduacion.DataBind()
        End If
    End Sub



    Public Sub Obtener_provincias()
        Dim ds_provincias As DataSet = DAusuario.Usuario_ObtenerProvincias()

        If ds_provincias.Tables(0).Rows.Count <> 0 Then
            DropDownList_provincia.DataSource = ds_provincias.Tables(0)
            DropDownList_provincia.DataTextField = "provincia_desc"
            DropDownList_provincia.DataValueField = "provincia_id"
            DropDownList_provincia.DataBind()
        End If
    End Sub
    Private Sub Obtener_ciudad()
        'filtrar
        DropDownList_ciudad.DataSource = ""
        DropDownList_ciudad.DataBind()

        Dim ds_ciudades As DataSet = DAusuario.Usuario_filtrarciudades_x_Provincias(CInt(DropDownList_provincia.SelectedValue))
        If ds_ciudades.Tables(0).Rows.Count <> 0 Then
            DropDownList_ciudad.DataSource = ds_ciudades.Tables(0)

            DropDownList_ciudad.DataTextField = "ciudad_desc"
            DropDownList_ciudad.DataValueField = "ciudad_id"
            DropDownList_ciudad.DataBind()
        End If
    End Sub


    Private Sub ocultar_div_errores()
        'aqui ocultamos todo y lo llamo antes de guardar, es util cuando reiteradas veces se estan dando errores en la carga
        div_apellido_error.Visible = False
        div_nombre_error.Visible = False
        div_dni_error.Visible = False
        'falta fecha de nacimiento
        'div_domicilio_error.Visible = False
        div_telefono_error.Visible = False
        div_email_error.Visible = False

        'label_error_instituciones.Visible = False
        'label_error_instructor.Visible = False
        'div_usuario_error.Visible = False
        'div_contraseña1_error.Visible = False
        'div_contraseña2_error.Visible = False
        'label_usuario_error.Text = "error!"
        label_dni_error.Text = "error!"
        'div_registroexitoso.Visible = False
        label_error_fechanacimiento.Visible = False
    End Sub

    Private Sub limpiar_boxes()
        Txt_apellido2.Text = ""
        Txt_nombre2.Text = ""
        Txt_Dni2.Text = ""
        'txt_nacionalidad.Text = ""
        'txt_profesion.Text = ""
        txt_domilicio.Text = ""
        'txt_codigopostal.Text = ""
        txt_telefono.Text = ""
        txt_email.Text = ""
        'txt_usuario.Text = ""
        'txt_contraseña1.Text = ""
        'txt_contraseña2.Text = ""
        txt_nrolibreta.Text = ""

        'div_registroexitoso.Visible=false
        Image1.ImageUrl = "~/Registro/imagen/usuario-registrado.jpg"
        Session("imagen") = ""
        foto_cargada = "no"

    End Sub

#End Region

#Region "GESTION FOTO"
    Dim tamanio As Integer
    Dim ImagenOriginal As Byte()
    Dim ImagenOriginalBinaria As Bitmap
    Dim ImagenDataURL64 As String

    Public Function ImageControlToByteArray(ByVal foto)
        Return File.ReadAllBytes(Server.MapPath(foto.ImageUrl))
    End Function

    Dim foto_cargada As String

#End Region
    

    
    Private Sub Btn_continua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_continua.Click
        ModalPopupExtender4.Hide()
        ModalPopupExtender3.Hide()
        ModalPopupExtender2.Hide()
        ModalPopupExtender5.Hide()

        '/////////////////////////////////////////
        Panel_error1.Visible = True
        Panel_error2.Visible = True
        Panel_error3.Visible = True
        Panel_msjok.Visible = True
        'nota: esto de poner visible en true lo hago x que cuando carga la pagina, parpadea y se ven momentaneamente los msj modal abajo.
        '////////////////////////////////////////


        If Session("foto_subido_registro") = "no" Then
            Dim imagebytes As Byte() = ImageControlToByteArray(Image1)
            Session("imagen_registro") = imagebytes
        End If

        'limpio
        Txt_apellido2.BackColor = Color.White
        Txt_nombre2.BackColor = Color.White
        Txt_Dni2.BackColor = Color.White
        Txt_fechanac_2.BackColor = Color.White
        txt_telefono.BackColor = Color.White
        txt_email.BackColor = Color.White




        'validamos el ingreso de los parametros requeridos

        Dim valido As String = "si"
        If Txt_apellido2.Text = "" Then
            Txt_apellido2.BackColor = Color.Yellow
            valido = "no"
        End If


        If Txt_nombre2.Text = "" Then
            Txt_nombre2.BackColor = Color.Yellow
            valido = "no"
        End If

        Try
            Dim dni As Integer = CInt(Txt_Dni2.Text)

        Catch ex As Exception
            Txt_Dni2.BackColor = Color.Yellow
            valido = "no"
        End Try

        Try
            Dim fecha_nacimiento As Date = CDate(Txt_fechanac_2.Text)
        Catch ex As Exception
            Txt_fechanac_2.BackColor = Color.Yellow
            valido = "no"
        End Try

        'If txt_telefono.Text = "" Then
        '    txt_telefono.BackColor = Color.Yellow
        '    valido = "no"
        'End If

        'If txt_email.Text = "" Then
        '    txt_email.BackColor = Color.Yellow
        '    valido = "no"
        'End If

        If valido = "si" Then
            'continuo con la validacion
            '1) verifico que el dni no exista ya en la bd
            Dim ds_validardni As DataSet = DAusuario.Usuario_validar_DNI(CInt(Txt_Dni2.Text))
            If ds_validardni.Tables(0).Rows.Count = 0 Then
                'es valido continuo con la proxima validacion..
                '2)valido que la fecha de nacimiento sea menor a la fecha actual para poder calcular correctamente la edad del usuario.
                'aqui continuoo
                Dim fecha_nacimiento As String = Txt_fechanac_2.Text
                'valido la fecha de nacimiento que al menos tenga 3 años

                'Dim fecha_actual = CDate(Today.Date.Year - 1 & "/" & Today.Date.Month & "/" & Today.Day)
                Dim fecha_actual = CDate(Today.Day & "/" & Today.Date.Month & "/" & Today.Date.Year - 3)
                'If CDate(fecha_nacimiento) < fecha_actual Or CDate(fecha_nacimiento) = fecha_actual Then
                If CDate(fecha_nacimiento) < fecha_actual Or CDate(fecha_nacimiento) = fecha_actual Then
                    Dim graduacion As Integer = CInt(DropDownList_graduacion.SelectedValue)
                    If graduacion <> 1 Then

                        Dim evento_ds As New evento_ds
                        evento_ds.Tables("Invitado_DatosPersonales").Rows.Clear()
                        Dim fila As DataRow = evento_ds.Tables("Invitado_DatosPersonales").NewRow
                        fila("Apellido") = Txt_apellido2.Text
                        fila("Nombre") = Txt_nombre2.Text
                        fila("Dni") = Txt_Dni2.Text
                        fila("Sexo") = CStr(DropDownList_sexo.SelectedValue)
                        fila("Fecha_nac") = CDate(Txt_fechanac_2.Text)
                        fila("Provincia_id") = CInt(DropDownList_provincia.SelectedValue)
                        fila("Ciudad_id") = CInt(DropDownList_ciudad.SelectedValue)
                        fila("Domicilio") = txt_domilicio.Text
                        fila("Telefono") = txt_telefono.Text
                        fila("Email") = txt_email.Text
                        fila("Graduacion_id") = DropDownList_graduacion.SelectedValue
                        fila("NroLibreta") = txt_nrolibreta.Text
                        fila("Foto") = Session("imagen_registro")

                        'GUARDO EN LA BD ----EL USUARIO ES TIPO INSTRUCTOR.
                        'GALARRAGA ES INSTRUCTOR_ID = 23. los tengo q vincular con el.
                        'institucion_id de galarraga = 2, taabsas
                        Dim instructor_id As Integer = 23
                        Dim institucion_id As Integer = 2

                        'en el alta_invitado se crea registro en usuario y tambien en alumnos_x_instructor (vinculando asi a este instructor con su maestro galarraga)
                        DAusuario.Usuario_alta_invitado(Session("imagen_registro"), Txt_apellido2.Text, Txt_nombre2.Text, 2,
                       CInt(Txt_Dni2.Text),
                      CStr(DropDownList_sexo.SelectedValue),
                      "Argentino",
                      1,
                      "",
                      CDate(Txt_fechanac_2.Text),
                      txt_domilicio.Text,
                      0,
                      CInt(DropDownList_provincia.SelectedValue),
                      CInt(DropDownList_ciudad.SelectedValue),
                      txt_telefono.Text,
                      txt_email.Text,
                     DropDownList_graduacion.SelectedValue, "", Today, instructor_id, "instructor", "", institucion_id,
                      txt_nrolibreta.Text, "invitado")

                        'en activar_instructorinvitado se crea un registro en la tabla instructor e institucion_x_instructor
                        DAusuario.Activar_InstructorInvitado(CInt(Txt_Dni2.Text), instructor_id, institucion_id)

                        limpiar_boxes()
                        ModalPopupExtender5.Show()

                        'Response.Redirect("../Inicio_Blanco.aspx")

                    End If


                Else
                    'error, ingrese fecha de nacimiento válida!!
                    ModalPopupExtender4.Show()
                End If

            Else
                'error, ya esta registrado
                ModalPopupExtender3.Show()
            End If


        Else
            'aqui va un msj para complete la info solicitada.
            ModalPopupExtender2.Show()
        End If
    End Sub
End Class