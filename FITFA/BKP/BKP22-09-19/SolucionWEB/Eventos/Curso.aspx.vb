﻿Public Class Curso
    Inherits System.Web.UI.Page
    Dim DAinscripciones As New Capa_de_datos.Inscripciones
    Dim DAeventos As New Capa_de_datos.Eventos
    Dim Curso_DS As New Curso_DS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Carga_inicial_LOAD()

            'div_msj_error_eliminar.Visible = False

           

        End If
    End Sub

    Private Sub Carga_inicial_LOAD()
        Curso_DS.Curso_recuperar_inscriptos.Rows.Clear()
        GridView2.DataSource = ""
        GridView2.DataBind()

        Dim evento_id As Integer = CInt(Session("evento_id"))

        'recupero inscriptos
        Dim ds_inscriptos As DataSet = DAeventos.Curso_recuperar_inscriptos(evento_id)
        If ds_inscriptos.Tables(0).Rows.Count <> 0 Then
            'entonces los muestro en el gridview 1
            Curso_DS.Curso_recuperar_inscriptos.Merge(ds_inscriptos.Tables(0))
            GridView2.DataSource = Curso_DS.Curso_recuperar_inscriptos
            GridView2.DataBind()

            Dim i As Integer = 0
            While i < GridView2.Rows.Count
                GridView2.Rows(i).Cells(0).Text = i + 1 'Nro.
                i = i + 1
            End While
            Label_evento_cant_inscriptos_b.Text = ds_inscriptos.Tables(0).Rows.Count
            Label_evento_b.Text = CStr(ds_inscriptos.Tables(0).Rows(0).Item("evento_descripcion"))
            Label_evento_fecha_b.Text = CStr(ds_inscriptos.Tables(0).Rows(0).Item("evento_fecha"))
            Label_evento_direccion_b.Text = CStr(ds_inscriptos.Tables(0).Rows(0).Item("evento_direccion"))


        Else
            div_msj_error_eliminar.Visible = True
        End If

     


    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If (e.CommandName = "op_eliminar") Then
            'If Not IsPostBack Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString()) 'este es el id de la inscripcion = Inscexamen_id
            Session("Inscexamen_id") = id
            'solo se elimina si aun no está calificado.
            'luego de eliminar debo volver a cargar todas las grillas.
            DAinscripciones.inscripciones_CURSO_eliminar(CInt(Session("Inscexamen_id")))
            Carga_inicial_LOAD()
            '---deshabilito el modal para confirmar eliminacion
            'div_Modal_ELIMINAR_inscripto.Visible = True
            'Modal_ELIMINAR_inscripto.Show()
            'End If
        End If
    End Sub

End Class