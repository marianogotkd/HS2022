Public Class Instructor_institucion_b
    Inherits System.Web.UI.Page
    Dim DAinstitucion As New Capa_de_datos.Instituciones
    Dim DAusuario As New Capa_de_datos.usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim instructor_id As Integer = Session("instructor_id")
            Dim ds_institucion As DataSet = DAinstitucion.institucion_obtener_de_instructor(instructor_id)
            GridView1.DataSource = ds_institucion.Tables(0)
            GridView1.DataBind()
            Label_instructor.Text = ds_institucion.Tables(1).Rows(0).Item(1)
            Label_dni.Text = ds_institucion.Tables(1).Rows(0).Item("usuario_doc")
            seccion_provincia.Visible = False 'no uso
            seccion_institucion.Visible = False 'tampoco uso, siempre se agregan instituciones nuevas
            Btn_asignar.Visible = False 'no lo uso por el momento
            div_modal_OKborrar.Visible = False
            div_modal_errorvacio.Visible = False
            div_modal_erroralumnos.Visible = False
        End If
    End Sub

    Private Sub recuperar_instituciones_vinculadas()
        Dim ds_institucion As DataSet = DAinstitucion.institucion_obtener_de_instructor(Session("instructor_id"))
        GridView1.DataSource = ds_institucion.Tables(0)
        GridView1.DataBind()
        Label_instructor.Text = ds_institucion.Tables(1).Rows(0).Item(1)
        Label_dni.Text = ds_institucion.Tables(1).Rows(0).Item("usuario_doc")
    End Sub
    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "institucion_id") Then
            Dim institucion_id As Integer = Integer.Parse(e.CommandArgument.ToString())
            Session("ID_institucion") = institucion_id
            Response.Redirect("~/Instituciones/Institucion_modificar_datos.aspx")
        Else
            If (e.CommandName = "ID_delete") Then
                'tengo que abrir un dialogo para confirmar eliminacion
                'solo elimino si no queda la grilla vacia.
                If GridView1.Rows.Count > 1 Then
                    Session("eliminar_institucion_id") = Integer.Parse(e.CommandArgument.ToString)
                    'primero veo en la bd si no hay alumnos vinculados a ese instructor y a esa institucion, para ello veo la tabla alumnos_x_institucion
                    Dim ds_alum As DataSet = DAinstitucion.Institucion_obtener_instructor_alumnos(Session("eliminar_institucion_id"), Session("instructor_id"))
                    If ds_alum.Tables(0).Rows.Count = 0 Then
                        'como no hay alumnos lo puedo eliminar
                        DAinstitucion.Institucion_desvincular(Session("instructor_id"), Session("eliminar_institucion_id"))
                        'aqui va mensaje de que se elimino correctamente
                        recuperar_instituciones_vinculadas()
                        div_modal_OKborrar.Visible = True
                        Modal_OKborrar.Show()
                    Else
                        'aqui va mensaje de error, no se puede eliminar ya que tiene alumnos que dependen
                        div_modal_erroralumnos.Visible = True
                        modal_erroralumnos.Show()
                    End If
                Else
                    'aqui va el mensaje de error, no puede quedar la grilla vacia.
                    div_modal_errorvacio.Visible = True
                    Modal_errorvacio.Show()
                End If
            End If
        End If
    End Sub

    Private Sub Nuevo_institucion_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Nuevo_institucion.ServerClick
        Session("procedencia") = "con_instructor"
        Response.Redirect("~/Instituciones/Institucion_alta.aspx")
    End Sub

    Private Sub DropDown_provincia_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_provincia.Init
        Dim ds_provincias As DataSet = DAusuario.Usuario_ObtenerProvincias()

        If ds_provincias.Tables(0).Rows.Count <> 0 Then
            DropDown_provincia.DataSource = ds_provincias.Tables(0)
            DropDown_provincia.DataTextField = "provincia_desc"
            DropDown_provincia.DataValueField = "provincia_id"
            DropDown_provincia.DataBind()

            obtener_instituciones_x_provincia()
        End If
    End Sub

    Private Sub DropDown_provincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDown_provincia.SelectedIndexChanged
        obtener_instituciones_x_provincia()
        'obtener_instructores_x_institucion()
    End Sub
    Private Sub obtener_instituciones_x_provincia()
        'filtrar
        DropDown_institucion.DataSource = ""
        DropDown_institucion.DataBind()
        Dim ds_instituiones As DataSet = DAusuario.Usuario_ObtenerInstituciones_x_provincia(DropDown_provincia.SelectedValue)
        If ds_instituiones.Tables(0).Rows.Count <> 0 Then
            DropDown_institucion.DataSource = ds_instituiones.Tables(0)
            DropDown_institucion.DataTextField = "institucion_abreviacion"
            DropDown_institucion.DataValueField = "institucion_id"
            DropDown_institucion.DataBind()
        End If

    End Sub

    Private Sub Btn_asignar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_asignar.ServerClick

        If DropDown_institucion.SelectedValue <> "" Then

            'validamos primero que no este ya asignada esa institucion.
            Dim i As Integer = 0
            Dim valido As String = "si"
            While i < GridView1.Rows.Count <> 0
                Dim var1 = GridView1.Rows(i).Cells(1).Text
                Dim var2 = CStr(DropDown_institucion.SelectedValue)
                If var1 = var2 Then
                    valido = "no"
                    i = GridView1.Rows.Count
                End If
                i = i + 1
            End While

            If valido = "si" Then
                DAinstitucion.Institucion_asignar(CInt(Session("instructor_id")), CInt(DropDown_institucion.SelectedValue))
                'actualizo la grilla con la nueva institucion asignada
                Dim ds_institucion As DataSet = DAinstitucion.institucion_obtener_de_instructor(Session("instructor_id"))
                GridView1.DataSource = ds_institucion.Tables(0)
                GridView1.DataBind()
                Label_instructor.Text = ds_institucion.Tables(1).Rows(0).Item(1)
                Label_dni.Text = ds_institucion.Tables(1).Rows(0).Item("usuario_doc")
            Else
                MsgBox("La institución seleccionada ya se encuentra asignada al instructor.")
            End If
        Else
            MsgBox("seleccione una institución válida.")
        End If
    End Sub
End Class