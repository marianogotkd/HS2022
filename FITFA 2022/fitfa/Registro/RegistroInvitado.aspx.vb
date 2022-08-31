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
Public Class RegistroInvitado
    Inherits System.Web.UI.Page

#Region "DECLARACIONES"
    Dim DAusuario As New Capa_de_datos.usuario
    Dim DAinstructor As New Capa_de_datos.Instructor
#End Region

#Region "EVENTOS"
    Private Sub DropDownList_instructor_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_instructor.Init
        Obtener_instructores_invitados()
    End Sub

    Private Sub DropDownList_provincia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_provincia.Init
        Obtener_provincias()
        Obtener_ciudad()
    End Sub
    Private Sub DropDownList_provincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_provincia.SelectedIndexChanged
        Obtener_ciudad()
    End Sub

    Private Sub FileUpload1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileUpload1.Init
        FileUpload1.Attributes.Add("onchange", "fileUpload1()")
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_fechanacimiento.Text = Today
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


    Private Sub btn_back_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_back.ServerClick
        Response.Redirect("../index.html")
    End Sub






#End Region

#Region "METODOS"
    Private Sub Obtener_instructores_invitados()
        Dim ds_instructor As DataSet = DAinstructor.Instructor_obtener_invitado
        If ds_instructor.Tables(0).Rows.Count <> 0 Then
            DropDownList_instructor.DataSource = ds_instructor.Tables(0)
            DropDownList_instructor.DataTextField = "Nombre"
            DropDownList_instructor.DataValueField = "instructor_id"
            DropDownList_instructor.DataBind()
        End If
    End Sub


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

#Region "Gestion Foto"
    Dim tamanio As Integer
    Dim ImagenOriginal As Byte()
    Dim ImagenOriginalBinaria As Bitmap
    Dim ImagenDataURL64 As String
    Private Sub Button_adjuntar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_adjuntar.Click
        If FileUpload1.HasFile Then
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If fileExt = ".jpeg" Or fileExt = ".bmp" Or fileExt = ".png" Or fileExt = ".jpg" Then



                tamanio = FileUpload1.PostedFile.ContentLength
                'int Tamanio = fuploadImagen.PostedFile.ContentLength;
                'choco
                ImagenOriginal = New Byte(tamanio - 1) {}
                'byte[] ImagenOriginal = new byte[Tamanio];
                'choco
                FileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio)
                'fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);
                'choco
                ImagenOriginalBinaria = New Bitmap(FileUpload1.PostedFile.InputStream)
                'Bitmap ImagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
                'choco
                ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal)
                'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);

                Session("imagen") = ImagenOriginal
                Image1.ImageUrl = ImagenDataURL64

                Image1.Visible = True
                'lbl_errImg.Visible = False
                'btn_Examinar.Visible = False
                'btn_quitar.Visible = True
            Else
                'lbl_errImg.Visible = True
                'lbl_errImg.InnerText = "Solo Archivos de Tipo Imagen"
            End If

        End If
    End Sub
    Public Function ImageControlToByteArray(ByVal foto)
        Return File.ReadAllBytes(Server.MapPath(foto.ImageUrl))
    End Function

    Dim foto_cargada As String

    Private Sub Btn_aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_aceptar.Click
        Try
            foto_cargada = "no"
            If FileUpload1.HasFile Then
                Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
                If fileExt = ".jpeg" Or fileExt = ".bmp" Or fileExt = ".png" Or fileExt = ".jpg" Then

                    tamanio = FileUpload1.PostedFile.ContentLength
                    'int Tamanio = fuploadImagen.PostedFile.ContentLength;
                    'choco
                    ImagenOriginal = New Byte(tamanio - 1) {}
                    'byte[] ImagenOriginal = new byte[Tamanio];
                    'choco
                    FileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio)
                    'fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);
                    'choco
                    ImagenOriginalBinaria = New Bitmap(FileUpload1.PostedFile.InputStream)
                    'Bitmap ImagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
                    'choco
                    ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal)
                    'string ImagenDataURL64 = "data:image/jpg;base64." + Convert.ToBase64String(ImagenOriginal);
                    Session("imagen") = ImagenOriginal
                    Image1.ImageUrl = ImagenDataURL64
                    'Image1.Visible = True
                    'lbl_errImg.Visible = False
                    'btn_Examinar.Visible = False
                    'btn_quitar.Visible = True
                    foto_cargada = "si"

                    Session("foto_subido_registro") = "si" 'choco: 23-07-2019
                    Session("imagen_registro") = ImagenOriginal 'choco: 23-07-2019
                Else


                End If

            End If
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'boton quitar foto
        Image1.ImageUrl = "~/Registro/imagen/usuario-registrado.jpg"
        Session("imagen") = ""
        Session("foto_subido_registro") = "no"
        Session("foto_subido") = "no"
        FileUpload1.Attributes.Clear()
    End Sub
#End Region














    Private Sub Btn_Guardado_ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Guardado_ok.Click
        'Response.Redirect("../index.html")
    End Sub

    Private Sub Btn_registrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_registrate.Click
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

        If DropDownList_instructor.Items.Count = 0 Then
            'no hay registrados en la bd instructores invitados.
            valido = "no"

        End If

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

                        Dim apellido As String = Txt_apellido2.Text
                        Dim nombre As String = Txt_nombre2.Text
                        Dim dni As Integer = CInt(Txt_Dni2.Text)
                        Dim sexo As String = CStr(DropDownList_sexo.SelectedValue)
                        Dim fecha_nac As Date = CDate(Txt_fechanac_2.Text)
                        Dim domicilio As String = txt_domilicio.Text
                        Dim provincia_id As Integer = CInt(DropDownList_provincia.SelectedValue)
                        Dim ciudad_id As Integer = CInt(DropDownList_ciudad.SelectedValue)
                        Dim telefono As String = txt_telefono.Text
                        Dim email As String = txt_email.Text
                        'Dim DAusuario As New Capa_de_datos.usuario
                        Dim graduacion_id As Integer = DropDownList_graduacion.SelectedValue
                        Dim nrolibreta As String = txt_nrolibreta.Text
                        Dim instructor_id As Integer = CInt(DropDownList_instructor.SelectedValue)

                        'me falta institucion_id
                        Dim ds_info_instructor As DataSet = DAinstructor.Instructor_obtener_institucion_id(instructor_id)
                        Dim institucion_id As Integer = ds_info_instructor.Tables(0).Rows(0).Item("institucion_id")

                        DAusuario.Usuario_alta_invitado(Session("imagen_registro"), apellido, nombre, 2,
                       dni,
                      sexo,
                      "Argentino",
                      1,
                      "",
                      fecha_nac,
                      domicilio,
                      0,
                      provincia_id,
                      ciudad_id,
                      telefono,
                      email,
                      graduacion_id, "", Today, instructor_id, "alumno", "", institucion_id,
                      nrolibreta, "invitado")


                        limpiar_boxes()
                        ModalPopupExtender5.Show()

                        'evento_ds.Tables("Invitado_DatosPersonales").Rows.Add(fila)

                        'Session("TablaInvitados_datospersonales") = evento_ds.Tables("Invitado_DatosPersonales")
                        'Session("Tipo") = "Invitado"
                        'Response.Redirect("../Inscripciones/Evento_seleccionar.aspx")





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