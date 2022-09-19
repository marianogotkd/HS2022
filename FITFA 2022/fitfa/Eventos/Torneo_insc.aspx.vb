Public Class Torneo_insc
    Inherits System.Web.UI.Page
    Dim DA_evento As New Capa_de_datos.Eventos
    Dim DAinscripciones As New Capa_de_datos.Inscripciones


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Carga_inicial_LOAD()

            'div_msj_error_eliminar.Visible = False
            div_Modal_eliminar_inscripto.Visible = False


        End If
    End Sub
    Dim Torneo_ds As New Torneo_ds
    Private Sub Carga_inicial_LOAD()
        Torneo_ds.Torneo_recuperar_inscriptos.Rows.Clear()
        Dim evento_id As Integer = CInt(Session("evento_id"))
        HF_evento_id.Value = CInt(Session("evento_id"))
        Dim categoria_id As Integer = CInt(Session("categoria_id"))
        HF_categoria_id.Value = CInt(Session("categoria_id"))

        Dim ds_info As DataSet = DA_evento.Torneo_recuperar_inscriptos_categoria(evento_id, categoria_id)

        Torneo_ds.Torneo_recuperar_inscriptos.Merge(ds_info.Tables(0))


        GridView1.DataSource = Torneo_ds.Torneo_recuperar_inscriptos
        GridView1.DataBind()
        If GridView1.Rows.Count = 0 Then
            Div1.Visible = False
        End If

        Label_evento_b.Text = Session("evento_descripcion")
        Label_evento_fecha_b.Text = Session("evento_fecha")
        Label_evento_categoria.Text = Session("evento_categoria")
        Label_evento_cant_inscriptos_b.Text = "Cantidad de inscriptos: " + CStr(GridView1.Rows.Count)
    End Sub


    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        'op_eliminar

        If (e.CommandName = "op_eliminar") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())

            'aqui pregunto.
            'sino ya esta inscripto
            Session("inscripcion_id") = id
            div_Modal_eliminar_inscripto.Visible = True
            Modal_eliminar_inscripto.Show()

        End If
        'op_modificar
        If (e.CommandName = "op_modificar") Then
            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Integer.Parse(e.CommandArgument.ToString())



            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)


            Session("alumno") = CType(row.Cells(0), DataControlFieldCell).Text
            Session("dni") = CType(row.Cells(1), DataControlFieldCell).Text
            Session("instructor") = CType(row.Cells(3), DataControlFieldCell).Text
            Session("inscripcion_datos") = Session("evento_categoria")
            Session("inscripcion_id") = CType(row.Cells(7), DataControlFieldCell).Text
            Session("evento_id") = HF_evento_id.Value

            Session("categoria_id") = HF_categoria_id.Value
            Response.Redirect("Torneo_insc_modif.aspx")

        End If



    End Sub

    Private Sub Btn_Modal_si_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Modal_si.Click
        Dim ds_info As DataSet = DAinscripciones.Inscripcion_eliminar_alumno_torneo(Session("inscripcion_id"), HF_categoria_id.Value)
        'verifico si el alumno esta inscripto en otra modalidad
        If ds_info.Tables(0).Rows.Count = 0 Then
            'entonces elimino d ela tabla inscripcion tambien
            DAinscripciones.Inscripcion_eliminar_masivo(Session("inscripcion_id"))
        End If

        'recargar formulario.
        Carga_inicial_LOAD()

    End Sub
End Class