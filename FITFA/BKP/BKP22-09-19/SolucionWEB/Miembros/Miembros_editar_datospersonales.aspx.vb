Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class Miembros_editar_datospersonales
    Inherits System.Web.UI.Page
    Dim DAusuario As New Capa_de_datos.usuario
    Dim DAllave As New Capa_de_datos.Llave

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_errApe.Visible = False
        lbl_errCP.Visible = False
        lbl_errDir.Visible = False
        lbl_errFecNac.Visible = False
        'lbl_errNac.Visible = False
        lbl_errNom.Visible = False
        lbl_errTel.Visible = False
        lbl_errMail.Visible = False
        lbl_err_libreta.Visible = False
        lbl_err_libreta_validar.Visible = False
        If Not IsPostBack Then
            Cargar_Datos()
            div_modalmsjOK.Visible = False


        End If
    End Sub

    Private Sub Cargar_Datos()
        Dim ds_Usuarios As DataSet = DAusuario.Datos_Personales_Obtener_Datos_Usuarios(Session("Alumno_Us_id"))
        If ds_Usuarios.Tables(0).Rows.Count <> 0 Then
            tb_nombre.Value = ds_Usuarios.Tables(0).Rows(0).Item(0)
            tb_apellido.Value = ds_Usuarios.Tables(0).Rows(0).Item(1)
            tb_fechnacc.Value = ds_Usuarios.Tables(0).Rows(0).Item(2)
            'tb_nacionalidad.Value = ds_Usuarios.Tables(0).Rows(0).Item(3)

            If ds_Usuarios.Tables(0).Rows(0).Item(4) = "Hombre" Then
                combo_Sexo.SelectedValue = "1"
            Else
                combo_Sexo.SelectedValue = "2"
            End If

            'combo_EstCivil.SelectedValue = ds_Usuarios.Tables(0).Rows(0).Item(5)
            'tb_profesion.Value = ds_Usuarios.Tables(0).Rows(0).Item(9)
            tb_dir.Value = ds_Usuarios.Tables(0).Rows(0).Item(8)
            'tb_CP.Value = ds_Usuarios.Tables(0).Rows(0).Item(10)
            textbox_CP.Text = ds_Usuarios.Tables(0).Rows(0).Item(10)
            Combo_provincia.SelectedValue = ds_Usuarios.Tables(0).Rows(0).Item(15)
            combo_ciudad.SelectedValue = ds_Usuarios.Tables(0).Rows(0).Item(16)
            tb_tel.Value = ds_Usuarios.Tables(0).Rows(0).Item(11)
            tb_Email.Value = ds_Usuarios.Tables(0).Rows(0).Item(12)
            tb_nrolibreta.Value = ds_Usuarios.Tables(0).Rows(0).Item("usuario_nrolibreta").ToString

            cmb_instructor.SelectedValue = ds_Usuarios.Tables(3).Rows(0).Item("instructor_id")

            Dim graduacion_id As Integer = ds_Usuarios.Tables(0).Rows(0).Item("graduacion_id")
            'como en el evento init recupero la graduacion, solo tengo que seleccionarla
            Combo_graduacion.SelectedValue = graduacion_id


        End If
    End Sub
    Private Sub obtener_graduaciones()
        Dim ds_graduaciones As DataSet = DAusuario.Usuario_ObtenerGraduaciones()
        If ds_graduaciones.Tables(0).Rows.Count <> 0 Then
            Combo_graduacion.DataSource = ds_graduaciones.Tables(0)
            Combo_graduacion.DataTextField = "graduacion_desc"
            Combo_graduacion.DataValueField = "graduacion_id"
            Combo_graduacion.DataBind()
        End If
    End Sub
    
    Public Sub Obtener_provincias()
        Dim ds_provincias As DataSet = DAusuario.Usuario_ObtenerProvincias()

        If ds_provincias.Tables(0).Rows.Count <> 0 Then
            Combo_provincia.DataSource = ds_provincias.Tables(0)
            Combo_provincia.DataTextField = "provincia_desc"
            Combo_provincia.DataValueField = "provincia_id"
            Combo_provincia.DataBind()
        End If
    End Sub
    Private Sub Obtener_ciudad()
        'filtrar
        combo_ciudad.DataSource = ""
        combo_ciudad.DataBind()

        Dim ds_ciudades As DataSet = DAusuario.Usuario_filtrarciudades_x_Provincias(CInt(Combo_provincia.SelectedValue))
        If ds_ciudades.Tables(0).Rows.Count <> 0 Then
            combo_ciudad.DataSource = ds_ciudades.Tables(0)

            combo_ciudad.DataTextField = "ciudad_desc"
            combo_ciudad.DataValueField = "ciudad_id"
            combo_ciudad.DataBind()
        End If
    End Sub

    Private Sub Obtener_instructores()
        'filtrar
        cmb_instructor.DataSource = ""
        cmb_instructor.DataBind()


        Dim ds_instructor As DataSet = DAusuario.Usuario_ObtenerInstructor(23) '23 es la Institucion ANT
        If ds_instructor.Tables(0).Rows.Count <> 0 Then
            cmb_instructor.DataSource = ds_instructor.Tables(0)
            cmb_instructor.DataTextField = "Nombre"
            cmb_instructor.DataValueField = "instructor_id"
            cmb_instructor.DataBind()
        End If
    End Sub

    Private Sub cmb_instructor_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_instructor.Init
        Obtener_instructores()
    End Sub

    Private Sub Combo_provincia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_provincia.Init
        Obtener_provincias()
        Obtener_ciudad()
        'recuperar las graduaciones
        obtener_graduaciones()
    End Sub


    

    Private Sub Combo_provincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_provincia.SelectedIndexChanged
        Obtener_ciudad()
    End Sub

    Private Sub btn_guardar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.ServerClick
        Dim Vacio As Boolean
        If tb_apellido.Value <> "" Then

        Else
            lbl_errApe.Visible = True
            Vacio = True
        End If

        Dim asfg As String = textbox_CP.Text

        If textbox_CP.Text <> "" Then

            For i = 0 To textbox_CP.Text.Length - 1
                If Not (Char.IsNumber(textbox_CP.Text.Chars(i))) Then
                    lbl_errCP.Visible = True
                    Vacio = True
                End If
            Next


        Else
            lbl_errCP.Visible = True
            Vacio = True
        End If
        If tb_dir.Value <> "" Then

        Else
            lbl_errDir.Visible = True
            Vacio = True
        End If

        If tb_Email.Value <> "" Then

        Else
            lbl_errMail.Visible = True
            Vacio = True
        End If

        If tb_fechnacc.Value <> "" Then

        Else
            lbl_errFecNac.Visible = True
            Vacio = True
        End If


        If tb_nombre.Value <> "" Then

        Else
            lbl_errNom.Visible = True
            Vacio = True
        End If

        If tb_tel.Value <> "" Then

        Else
            lbl_errTel.Visible = True
            Vacio = True
        End If

        'If tb_nrolibreta.Value <> "" Then
        'Else
        '    lbl_err_libreta.Visible = True
        '    Vacio = True
        'End If

        If Vacio <> True Then
            'valido que el numero de libreta ya no exista en la bd para otro alumno.
            Dim valido As String = "si"
            If tb_nrolibreta.Value <> "" Then 'validamos
                Dim ds_validar As DataSet = DAusuario.Datos_Personales_Validar_libreta(tb_nrolibreta.Value)
                If ds_validar.Tables(0).Rows.Count <> 0 Then
                    Dim i As Integer = 0
                    While i < ds_validar.Tables(0).Rows.Count
                        If ds_validar.Tables(0).Rows(i).Item("usuario_id") <> CInt(Session("Alumno_Us_id")) Then
                            valido = "no"
                            Exit While
                        End If
                        i = i + 1
                    End While
                Else
                    valido = "si"
                End If
            End If

            If valido = "si" Then
                DAusuario.Datos_Personales_Actualizar_Datos(CInt(Session("Alumno_Us_id")), tb_nombre.Value, tb_apellido.Value, tb_fechnacc.Value, "Argentino", combo_Sexo.SelectedValue, 1, "", tb_dir.Value, textbox_CP.Text, Combo_provincia.SelectedValue, combo_ciudad.SelectedValue, tb_tel.Value, tb_Email.Value, tb_nrolibreta.Value, Combo_graduacion.SelectedValue)
                'div_registro_guardado.Visible = True

                'Actualizo Instructor 19-10-21 -MGO
                DAusuario.alumuno_x_instructor_Actulizar(cmb_instructor.SelectedValue, Session("Alumno_Us_id"))

                '++++++++++++++Esto hago para que se haga visible el cartel de "datos actualizados"++++++++++++++
                div_modalmsjOK.Visible = True
                Modal_msjOK.Show()
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Else
                lbl_err_libreta_validar.Visible = True
                Vacio = True
            End If

            

        Else
            div_registro_guardado.Visible = False

        End If

    End Sub

    Dim nom1 As Integer = 1111
    Dim nom2 As Integer = 2222
    Dim nom3 As Integer = 3333
    Dim nom4 As Integer = 4444
End Class